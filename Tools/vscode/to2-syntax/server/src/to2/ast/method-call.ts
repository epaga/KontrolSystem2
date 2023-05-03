import { Expression, Node, ValidationError } from ".";
import { BUILTIN_UNIT, TO2Type, UNKNOWN_TYPE } from "./to2-type";
import { InputPosition, WithPosition } from "../../parser";
import { BlockContext } from "./context";
import { SemanticToken } from "../../syntax-token";
import { FunctionType, isFunctionType } from "./function-type";

export class MethodCall extends Expression {
  constructor(
    public readonly target: Expression,
    public readonly methodName: WithPosition<string>,
    public readonly args: Expression[],
    start: InputPosition,
    end: InputPosition
  ) {
    super(start, end);
  }

  public resultType(context: BlockContext): TO2Type {
    return this.findMethod(context)?.returnType ?? UNKNOWN_TYPE;
  }

  public reduceNode<T>(
    combine: (previousValue: T, node: Node) => T,
    initialValue: T
  ): T {
    return this.args.reduce(
      (prev, arg) => arg.reduceNode(combine, prev),
      this.target.reduceNode(combine, combine(initialValue, this))
    );
  }
  public validateBlock(context: BlockContext): ValidationError[] {
    const errors: ValidationError[] = [];

    errors.push(...this.target.validateBlock(context));

    if (errors.length > 0) return errors;

    const methodType = this.findMethod(context);
    if (methodType) {
      if (this.args.length > methodType.maxParams) {
        errors.push({
          status: "error",
          message: `${this.methodName.value} only takes ${methodType.maxParams} arguments`,
          start: this.methodName.start,
          end: this.methodName.end,
        });
      } else if (this.args.length < methodType.requiredParams) {
        errors.push({
          status: "error",
          message: `${this.methodName.value} at least requires ${methodType.requiredParams} arguments`,
          start: this.methodName.start,
          end: this.methodName.end,
        });
      } else {
        for (let i = 0; i < this.args.length; i++) {
          errors.push(
            ...this.args[i].validateBlock(
              context,
              methodType.parameterTypes[i][1].realizedType(context.module)
            )
          );
        }
      }
    } else {
      errors.push({
        status: "error",
        message: `Undefined method ${this.methodName.value} for type ${
          this.target.resultType(context).name
        }`,
        start: this.methodName.start,
        end: this.methodName.end,
      });
    }

    return errors;
  }

  public collectSemanticTokens(semanticTokens: SemanticToken[]): void {
    this.target.collectSemanticTokens(semanticTokens);
    semanticTokens.push({
      type: "method",
      start: this.methodName.start,
      length: this.methodName.end.offset - this.methodName.start.offset,
    });
    for (const arg of this.args) {
      arg.collectSemanticTokens(semanticTokens);
    }
  }

  private findMethod(context: BlockContext): FunctionType | undefined {
    const targetType = this.target
      .resultType(context)
      .realizedType(context.module);

    const method = targetType.findMethod(this.methodName.value);
    if (method) return method;

    const field = targetType
      .findField(this.methodName.value)
      ?.realizedType(context.module);

    return field && isFunctionType(field) ? field : undefined;
  }
}

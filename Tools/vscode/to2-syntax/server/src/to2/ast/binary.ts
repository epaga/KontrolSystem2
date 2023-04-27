import { Expression, Node, ValidationError } from ".";
import { Operator } from "./operator";
import { BUILTIN_BOOL, TO2Type } from "./to2-type";
import { InputPosition } from "../../parser";
import { BlockContext } from "./context";

export class Binary extends Expression {
  constructor(
    public readonly left: Expression,
    public readonly op: Operator,
    public readonly right: Expression,
    start: InputPosition,
    end: InputPosition
  ) {
    super(start, end);
  }

  resultType(): TO2Type {
    return BUILTIN_BOOL;
  }

  public reduceNode<T>(
    combine: (previousValue: T, node: Node) => T,
    initialValue: T
  ): T {
    return this.left.reduceNode(
      combine,
      this.right.reduceNode(combine, combine(initialValue, this))
    );
  }

  public validateBlock(context: BlockContext): ValidationError[] {
    const errors: ValidationError[] = [];

    return errors;
  }
}

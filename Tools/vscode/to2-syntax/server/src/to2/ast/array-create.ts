import { BlockItem, Expression, Node, ValidationError } from ".";
import { BUILTIN_UNIT, TO2Type } from "./to2-type";
import { InputPosition } from "../../parser";
import { BlockContext } from "./context";

export class ArrayCreate extends Expression {
  constructor(
    public readonly elementType: TO2Type | undefined,
    public readonly elements: Expression[],
    start: InputPosition,
    end: InputPosition
  ) {
    super(start, end);
  }

  public resultType(context: BlockContext): TO2Type {
    return BUILTIN_UNIT;
  }

  public reduceNode<T>(
    combine: (previousValue: T, node: Node) => T,
    initialValue: T
  ): T {
    return this.elements.reduce(
      (prev, element) => element.reduceNode(combine, prev),
      combine(initialValue, this)
    );
  }

  public validateBlock(context: BlockContext): ValidationError[] {
    const errors: ValidationError[] = [];

    return errors;
  }
}

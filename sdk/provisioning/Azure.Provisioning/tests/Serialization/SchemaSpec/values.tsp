/**
 * Value node types for the Azure CDK serialization AST.
 *
 * These represent literal/concrete values in the Bicep AST:
 * null, boolean, integer, string, array, and object.
 */

namespace AzureCDK.Serialization;

/** A null literal value. */
model NullValue {
  kind: "null";
  value: null;
}

/** A boolean literal value. */
model BooleanValue {
  kind: "boolean";
  value: boolean;
}

/**
 * An integer literal value.
 * Stored as a string to preserve 64-bit integer fidelity.
 */
model IntegerValue {
  kind: "integer";
  value: string;
}

/** A string literal value. */
model StringValue {
  kind: "string";
  value: string;
}

/** An array of expression nodes. */
model ArrayValue {
  kind: "array";
  items: ExpressionNode[];
}

/** An object with named expression node properties. */
model ObjectValue {
  kind: "object";
  value: Record<ExpressionNode>;
}

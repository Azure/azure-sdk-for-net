/**
 * Expression node types for the Azure CDK serialization AST.
 *
 * These represent runtime expressions in the Bicep AST: identifiers,
 * function calls, member access, and contextual variables.
 * ExpressionNode is a superset that includes all ValueNode variants.
 */
namespace AzureCDK.Serialization;

// ──────────────────────────────────────────────
// Basic expressions
// ──────────────────────────────────────────────

/** A reference to a named identifier (variable, parameter, resource, etc.). */
model IdentifierExpression {
  kind: "identifier";
  id: string;
}

/** A top-level function call (e.g. `toLower(...)`, `concat(...)`). */
model FunctionCallExpression {
  kind: "function-call";

  /** Function name or an expression that resolves to a callable. */
  target: string | ExpressionNode;

  args: ExpressionNode[];
}

/** An instance method call (e.g. `base.method(...)`). */
model InstanceFunctionCallExpression {
  kind: "instance-function-call";
  base: ExpressionNode;
  name: string;
  args: ExpressionNode[];
}

// ──────────────────────────────────────────────
// Member access
// ──────────────────────────────────────────────

/** Property access on an expression (e.g. `base.property` or `base.?property`). */
model PropertyAccessExpression {
  kind: "property-access";
  base: ExpressionNode;
  property: string;
  nullish: boolean;
}

/** Array/index access on an expression (e.g. `base[index]` or `base[^index]`). */
model ArrayAccessExpression {
  kind: "array-access";
  base: ExpressionNode;
  index: ExpressionNode;
  nullish: boolean;
  fromEnd: boolean;
}

// ──────────────────────────────────────────────
// Context access
// ──────────────────────────────────────────────

/** A built-in contextual variable (e.g. `subscription().subscriptionId`). */
model ContextualVariableExpression {
  kind: "contextual-variable";

  /** The context scope (e.g. "subscription", "resourceGroup", "tenant"). */
  context: string;

  /** The property within the context (e.g. "subscriptionId", "tenantId"). */
  property: string;
}

// ──────────────────────────────────────────────
// Operators
// ──────────────────────────────────────────────

/** Binary operators supported in Bicep expressions. */
union BinaryOperator {
  modulo: "%",
  multiply: "*",
  add: "+",
  subtract: "-",
  divide: "/",
  lessThan: "<",
  lessThanOrEqual: "<=",
  equal: "==",
  notEqual: "!=",
  regexMatch: "=~",
  regexNotMatch: "!~",
  greaterThan: ">",
  greaterThanOrEqual: ">=",
  logicalAnd: "&&",
  logicalOr: "||",
  coalesce: "??",
}

/** Unary operators supported in Bicep expressions. */
union UnaryOperator {
  not: "!",
  negate: "-",
}

/** A binary operator expression (e.g. `a + b`, `a ?? b`, `a && b`). */
model BinaryOperationExpression {
  kind: "binary-operation";
  operator: BinaryOperator;
  left: ExpressionNode;
  right: ExpressionNode;
}

/** A unary operator expression (e.g. `!enabled`, `-count`). */
model UnaryOperationExpression {
  kind: "unary-operation";
  operator: UnaryOperator;
  argument: ExpressionNode;
}

/** A ternary conditional expression (e.g. `condition ? whenTrue : whenFalse`). */
model TernaryOperationExpression {
  kind: "ternary-operation";
  condition: ExpressionNode;
  trueValue: ExpressionNode;
  falseValue: ExpressionNode;
}

// ──────────────────────────────────────────────
// Control flow
// ──────────────────────────────────────────────

/** A conditional expression block (e.g. `if (enabled) { ... }`). */
model IfConditionExpression {
  kind: "if-condition";
  condition: ExpressionNode;
  body: ExpressionNode;
}

/** A `for` expression (e.g. `[for item in items: { ... }]`). */
model ForExpression {
  kind: "for-expression";
  itemVariable: string;
  indexVariable?: string;
  expression: ExpressionNode;
  body: ExpressionNode;
  condition?: ExpressionNode;
}

// ──────────────────────────────────────────────
// Expression union
// ──────────────────────────────────────────────

/**
 * Discriminated union of all expression node types.
 * This includes all ValueNode variants plus expression-specific variants.
 */
@discriminated(#{ envelope: "none" })
union ExpressionNode {
  // Value nodes
  null: NullValue,

  boolean: BooleanValue,
  integer: IntegerValue,
  string: StringValue,
  array: ArrayValue,
  object: ObjectValue,

  // Expression nodes
  identifier: IdentifierExpression,

  "function-call": FunctionCallExpression,
  "instance-function-call": InstanceFunctionCallExpression,
  "property-access": PropertyAccessExpression,
  "array-access": ArrayAccessExpression,
  "contextual-variable": ContextualVariableExpression,
  "binary-operation": BinaryOperationExpression,
  "unary-operation": UnaryOperationExpression,
  "ternary-operation": TernaryOperationExpression,
  "if-condition": IfConditionExpression,
  "for-expression": ForExpression,
}

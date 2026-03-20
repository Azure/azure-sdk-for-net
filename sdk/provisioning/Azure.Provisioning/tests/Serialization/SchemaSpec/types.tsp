/**
 * Type node types for the Azure CDK serialization AST.
 *
 * These represent Bicep type annotations used on parameters and outputs:
 * primitive types, named type references, array types, object types,
 * union types, and parameterized type instantiations.
 */

namespace AzureCDK.Serialization;

// ──────────────────────────────────────────────
// Primitive type names
// ──────────────────────────────────────────────

/** The set of Bicep primitive type names. */
union PrimitiveTypeName {
  any: "any",
  array: "array",
  bool: "bool",
  int: "int",
  object: "object",
  string: "string",
}

// ──────────────────────────────────────────────
// Primitive & reference types
// ──────────────────────────────────────────────

/** A built-in primitive type (e.g. `string`, `int`, `bool`). */
model PrimitiveTypeNode {
  kind: "primitive-type";
  name: PrimitiveTypeName;
}

/** A reference to a named/user-defined type. */
model TypeReferenceNode {
  kind: "type-reference";
  name: string;
}

// ──────────────────────────────────────────────
// Literal types (used as union members)
// ──────────────────────────────────────────────

/** A string literal used as a type (e.g. `'Standard_GRS'`). */
model StringTypeLiteralNode {
  kind: "string-type-literal";
  value: string;
}

/** An integer literal used as a type. */
model IntegerTypeLiteralNode {
  kind: "integer-type-literal";
  value: string;
}

/** A boolean literal used as a type. */
model BooleanTypeLiteralNode {
  kind: "boolean-type-literal";
  value: boolean;
}

/** A null literal used as a type. */
model NullTypeLiteralNode {
  kind: "null-type-literal";
  value: null;
}

// ──────────────────────────────────────────────
// Array types
// ──────────────────────────────────────────────

/** An array type (e.g. `string[]`). */
model ArrayTypeNode {
  kind: "array-type";
  item: TypeNode;
}

// ──────────────────────────────────────────────
// Object types
// ──────────────────────────────────────────────

/** A property within an object type definition. */
model ObjectTypePropertyNode {
  kind: "object-type-property";
  key: string;
  valueType: TypeNode;
  optional?: boolean;
  decorators?: DecoratorsNode;
}

/** The additional-properties clause of an object type (`*: T`). */
model ObjectTypeAdditionalPropertiesNode {
  kind: "object-type-additional-properties";
  valueType: TypeNode;
  decorators?: DecoratorsNode;
}

/** An object type with named properties and optional additional properties. */
model ObjectTypeNode {
  kind: "object-type";
  properties: ObjectTypePropertyNode[];
  additionalProperties?: ObjectTypeAdditionalPropertiesNode;
}

// ──────────────────────────────────────────────
// Union types
// ──────────────────────────────────────────────

/** An individual member in a union type. */
model UnionTypeMemberNode {
  kind: "union-type-member";
  valueType: TypeNode;
}

/** A union type (e.g. `string | int`). */
model UnionTypeNode {
  kind: "union-type";
  members: UnionTypeMemberNode[];
}

// ──────────────────────────────────────────────
// Nullable types
// ──────────────────────────────────────────────

/** A nullable type wrapper (e.g. `string?`). */
model NullableTypeNode {
  kind: "nullable-type";
  base: TypeNode;
}

// ──────────────────────────────────────────────
// Parameterized types
// ──────────────────────────────────────────────

/** A type argument in a parameterized type instantiation. */
model ParameterizedTypeArgumentNode {
  kind: "parameterized-type-argument";
  valueType: TypeNode;
}

/** A parameterized type instantiation (e.g. `map<string>`). */
model ParameterizedTypeInstantiationNode {
  kind: "parameterized-type-instantiation";
  base: TypeNode;
  args: ParameterizedTypeArgumentNode[];
}

// ──────────────────────────────────────────────
// Type node union
// ──────────────────────────────────────────────

/** Discriminated union of all type node kinds. */
@discriminator("kind")
union TypeNode {
  primitiveType: PrimitiveTypeNode,
  typeReference: TypeReferenceNode,
  stringTypeLiteral: StringTypeLiteralNode,
  integerTypeLiteral: IntegerTypeLiteralNode,
  booleanTypeLiteral: BooleanTypeLiteralNode,
  nullTypeLiteral: NullTypeLiteralNode,
  arrayType: ArrayTypeNode,
  objectTypeProperty: ObjectTypePropertyNode,
  objectTypeAdditionalProperties: ObjectTypeAdditionalPropertiesNode,
  objectType: ObjectTypeNode,
  unionTypeMember: UnionTypeMemberNode,
  unionType: UnionTypeNode,
  nullableType: NullableTypeNode,
  parameterizedTypeArgument: ParameterizedTypeArgumentNode,
  parameterizedTypeInstantiation: ParameterizedTypeInstantiationNode,
}

/**
 * Declaration node types for the Azure CDK serialization AST.
 *
 * These represent Bicep declarations that the CDK serializer emits:
 * parameters, variables, outputs, resources, and modules.
 */

namespace AzureCDK.Serialization;

// ──────────────────────────────────────────────
// Decorators
// ──────────────────────────────────────────────

/** Decorator metadata that can be applied to declarations and type properties. */
model DecoratorsNode {
  description?: string;
  secure?: true;
  minValue?: int64;
  maxValue?: int64;
  minLength?: int64;
  maxLength?: int64;
  metadata?: Record<ExpressionNode>;
  allowed?: ExpressionNode[];
  discriminator?: string;
  sealed?: true;
  export?: true;
}

// ──────────────────────────────────────────────
// Parameter declarations
// ──────────────────────────────────────────────

/** A Bicep parameter declaration. */
model ParameterDeclarationNode {
  bicepIdentifier: string;
  valueType: TypeNode;
  defaultValue?: ExpressionNode;
  decorators?: DecoratorsNode;
}

// ──────────────────────────────────────────────
// Variable declarations
// ──────────────────────────────────────────────

/** A Bicep variable declaration. */
model VariableDeclarationNode {
  bicepIdentifier: string;
  value: ExpressionNode;
  decorators?: DecoratorsNode;
}

// ──────────────────────────────────────────────
// Output declarations
// ──────────────────────────────────────────────

/** A Bicep output declaration. */
model OutputDeclarationNode {
  bicepIdentifier: string;
  valueType: TypeNode;
  value: ExpressionNode;
  decorators?: DecoratorsNode;
}

// ──────────────────────────────────────────────
// Resource declarations
// ──────────────────────────────────────────────

/** A Bicep resource declaration. */
model ResourceDeclarationNode {
  bicepIdentifier: string;

  /** The Azure resource type (e.g. "Microsoft.Storage/storageAccounts"). */
  type: string;

  /** The API version (e.g. "2024-01-01"). */
  apiVersion: string;

  /** Whether this references an existing resource (`existing` keyword). */
  existing: boolean;

  /** The resource body. */
  value: ObjectValue;

  decorators?: DecoratorsNode;
}

// ──────────────────────────────────────────────
// Module declarations
// ──────────────────────────────────────────────

/** A Bicep module declaration. */
model ModuleDeclarationNode {
  bicepIdentifier: string;

  /** Relative path to the module file. */
  path: string;

  /** The module body. */
  value: ObjectValue;

  decorators?: DecoratorsNode;
}

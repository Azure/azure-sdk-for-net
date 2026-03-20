/**
 * Azure CDK Serialization AST — TypeSpec Schema
 *
 * This is the top-level entry point that defines the complete serialization
 * document produced by the Azure CDK. The document contains one or more
 * Bicep file nodes, each representing a `.bicep` file with its resources,
 * modules, parameters, outputs, and variables.
 *
 * The schema mirrors the TypeScript interfaces in
 * `packages/serialization/src/` of the azure-cdk repository.
 */

import "./values.tsp";
import "./expressions.tsp";
import "./types.tsp";
import "./declarations.tsp";

namespace AzureCDK.Serialization;

// ──────────────────────────────────────────────
// Target scope
// ──────────────────────────────────────────────

/** The deployment scope for a Bicep file. */
union TargetScope {
  resourceGroup: "resourceGroup",
  subscription: "subscription",
  managementGroup: "managementGroup",
  tenant: "tenant",
}

// ──────────────────────────────────────────────
// Bicep file
// ──────────────────────────────────────────────

/** Represents a single Bicep file in the serialization output. */
model BicepFileNode {
  /** The relative file path/name (e.g. "main.bicep", "modules/storage.bicep"). */
  fileName: string;

  /** The deployment target scope. Defaults to "resourceGroup" if omitted. */
  targetScope?: TargetScope;

  /** Parameter declarations, keyed by Bicep identifier. */
  parameters?: Record<ParameterDeclarationNode>;

  /** Variable declarations, keyed by Bicep identifier. */
  variables?: Record<VariableDeclarationNode>;

  /** Output declarations, keyed by Bicep identifier. */
  outputs?: Record<OutputDeclarationNode>;

  /** Resource declarations, keyed by Bicep identifier. */
  resources?: Record<ResourceDeclarationNode>;

  /** Module declarations, keyed by Bicep identifier. */
  modules?: Record<ModuleDeclarationNode>;
}

// ──────────────────────────────────────────────
// Top-level document
// ──────────────────────────────────────────────

/** The root serialization document containing all Bicep files. */
model SerializationDocument {
  /** The collection of Bicep files that make up this deployment. */
  bicepFiles: BicepFileNode[];
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AzureEmitterOptions,
  AzureEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp";
import { Diagnostic, JSONSchemaType } from "@typespec/compiler";

/**
 * Upstream diagnostic codes that are not meaningful for management plane code generation
 * and should be suppressed to avoid noisy output.
 */
export const suppressedUpstreamDiagnosticCodes: ReadonlySet<string> = new Set([
  // TCGC reports this for generic decorator arguments, which don't affect mgmt plane codegen
  "@azure-tools/typespec-client-generator-core/unsupported-generic-decorator-arg-type",
  // Base emitter reports this for PATCH convenience methods, which mgmt plane doesn't use
  "@typespec/http-client-csharp/unsupported-patch-convenience-method"
]);

/**
 * Filters out upstream diagnostics that are not meaningful for management plane.
 */
export function filterSuppressedDiagnostics(
  diagnostics: readonly Diagnostic[]
): readonly Diagnostic[] {
  return diagnostics.filter(
    (d) => !suppressedUpstreamDiagnosticCodes.has(d.code)
  );
}

export interface AzureMgmtEmitterOptions extends AzureEmitterOptions {
  "enable-wire-path-attribute"?: boolean;
  "use-legacy-resource-detection"?: boolean;
  "skip-api-version-override"?: boolean;
  "apply-model-renaming"?: boolean;
  "apply-enum-renaming"?: boolean;
  "apply-method-renaming"?: boolean;
}

export const AzureMgmtEmitterOptionsSchema: JSONSchemaType<AzureMgmtEmitterOptions> =
  {
    type: "object",
    additionalProperties: false,
    properties: {
      ...AzureEmitterOptionsSchema.properties,
      "enable-wire-path-attribute": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to enable the WirePathAttribute on model properties. The default value is 'false'.",
        default: false
      },
      "use-legacy-resource-detection": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to use the legacy custom resource detection logic instead of the standardized resolveArmResources API from @azure-tools/typespec-azure-resource-manager. When true, uses the legacy logic. When false, uses the resolveArmResources API.",
        default: true
      },
      "skip-api-version-override": {
        type: "boolean",
        nullable: true,
        description:
          "Temporary workaround: Whether to pass skipApiVersionOverride: true when instantiating ArmOperation types in generated LRO methods. When true, the LRO polling will not override the api-version from the initial request URI. This option will be removed once the api-version override issue is properly resolved in Azure.Core. The default value is 'false'.",
        default: false
      },
      "apply-model-renaming": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to apply the generator-side automatic model name overrides (e.g., renaming a PATCH body to '{Resource}Patch' / '{Resource}CreateOrUpdateContent', 'Url' -> 'Uri', or prefixing known-type model names like 'Sku' with the resource provider name). When false, the generator-side model renames in NameVisitor are skipped so that names from TypeSpec (including user-provided `@@clientName` decorators) are preserved. The default value is 'true'.",
        default: true
      },
      "apply-enum-renaming": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to apply the generator-side automatic enum name overrides (e.g., prefixing known-type enum names like 'PrivateEndpointServiceConnectionStatus' with the resource provider name). When false, the generator-side enum renames in NameVisitor are skipped so that names from TypeSpec (including user-provided `@@clientName` decorators) are preserved. The default value is 'true'.",
        default: true
      },
      "apply-method-renaming": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to apply the generator-side automatic method name overrides for resource operations (e.g., 'Get', 'GetAll', 'CreateOrUpdate', 'Delete' on resource/collection clients, and 'Get{Resource}s' / 'CreateOrUpdate{Resource}' on extension clients). When false, the generator uses the TypeSpec-provided method names (including names set via the `@@clientName` decorator). The default value is 'true'.",
        default: true
      }
    }
  };

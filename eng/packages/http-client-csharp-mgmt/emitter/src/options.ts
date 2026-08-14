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
      }
    }
  };

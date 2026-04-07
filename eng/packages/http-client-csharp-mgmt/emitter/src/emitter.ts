// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Diagnostic, EmitContext } from "@typespec/compiler";

import { CodeModel, CSharpEmitterContext } from "@typespec/http-client-csharp";

import { emitAzureCodeModel } from "@azure-typespec/http-client-csharp";
import {
  azureSDKContextOptions,
  flattenPropertyDecorator
} from "./sdk-context-options.js";
import { updateClients } from "./resource-detection.js";
import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";
import { AzureMgmtEmitterOptions } from "./options.js";
import { transformSubscriptionIdParameters } from "./subscription-id-transformer.js";
import {
  deduplicateApiVersionEnums,
  fixClientApiVersions
} from "./api-version-fixer.js";

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

export async function $onEmit(context: EmitContext<AzureMgmtEmitterOptions>) {
  context.options["generator-name"] ??= "ManagementClientGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["sdk-context-options"] ??= azureSDKContextOptions;
  context.options["model-namespace"] ??= true;
  const [, diagnostics] = await emitAzureCodeModel(context, updateCodeModel);
  context.program.reportDiagnostics(filterSuppressedDiagnostics(diagnostics));

  function updateCodeModel(
    codeModel: CodeModel,
    sdkContext: CSharpEmitterContext
  ): CodeModel {
    // Transform subscriptionId parameters from client scope to method scope
    // This must happen before other transformations that may depend on method parameters
    transformSubscriptionIdParameters(codeModel);

    // Deduplicate ApiVersionEnum enums to work around base generator crash
    // when multiple services share the same namespace.
    // https://github.com/microsoft/typespec/issues/10055
    deduplicateApiVersionEnums(codeModel);

    // Fix clients with empty apiVersions by inferring from their methods.
    // In TCGC's hierarchical client model, parent clients don't carry apiVersions — child clients
    // inherit from parents. In mgmt SDK we flatten the hierarchy, so we infer from methods instead.
    fixClientApiVersions(codeModel, sdkContext);

    updateClients(codeModel, sdkContext, context.options);
    setFlattenProperty(codeModel, sdkContext);
    return codeModel;
  }
}

function setFlattenProperty(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext
): void {
  for (const model of sdkContext.sdkPackage.models) {
    for (const property of model.properties) {
      if (property.flatten) {
        const flattenPropertyMetadataDecorator: DecoratorInfo = {
          name: flattenPropertyDecorator,
          arguments: {}
        };
        property.decorators.push(flattenPropertyMetadataDecorator);
      }
    }
  }
}

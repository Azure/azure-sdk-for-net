// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Diagnostic, EmitContext, Program } from "@typespec/compiler";

import { CodeModel, CSharpEmitterContext } from "@typespec/http-client-csharp";

import { $onEmit as $onAzureEmit } from "@azure-typespec/http-client-csharp";
import {
  azureSDKContextOptions,
  flattenPropertyDecorator
} from "./sdk-context-options.js";
import { updateClients } from "./resource-detection.js";
import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";
import { AzureMgmtEmitterOptions } from "./options.js";

// Diagnostic codes to suppress as they are not meaningful for management plane generation
const SUPPRESSED_DIAGNOSTICS = [
  "@azure-tools/typespec-client-generator-core/unsupported-generic-decorator-arg-type",
  "@typespec/http-client-csharp/unsupported-patch-convenience-method"
];

export async function $onEmit(context: EmitContext<AzureMgmtEmitterOptions>) {

  context.options["generator-name"] ??= "ManagementClientGenerator";
  context.options["update-code-model"] = updateCodeModel;
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["sdk-context-options"] ??= azureSDKContextOptions;
  context.options["model-namespace"] ??= true;
  await $onAzureEmit(context);

  // TODO -- this is hacky, but this is the only way we could do on this side to remove some diagnostics.
  // the real solution pending on this issue: https://github.com/Azure/azure-sdk-for-net/issues/54788
  // Filter out meaningless upstream diagnostics by overriding the diagnostics property
  filterProgramDiagnostics(context.program);

  function updateCodeModel(
    codeModel: CodeModel,
    sdkContext: CSharpEmitterContext
  ): CodeModel {
    updateClients(codeModel, sdkContext, context.options);
    setFlattenProperty(codeModel, sdkContext);
    return codeModel;
  }
}

/**
 * Filters out suppressed diagnostics from the program by replacing the diagnostics property.
 * This allows us to hide meaningless upstream diagnostic warnings that don't affect
 * management plane code generation.
 */
function filterProgramDiagnostics(program: Program): void {
  const originalDiagnostics = program.diagnostics;

  // Replace the readonly diagnostics property with a dynamically filtered version
  Object.defineProperty(program, "diagnostics", {
    get() {
      // Filter dynamically to ensure any diagnostic changes after filtering are reflected
      return originalDiagnostics.filter(
        (d: Diagnostic) => !SUPPRESSED_DIAGNOSTICS.includes(d.code)
      );
    },
    set: undefined, // Explicitly mark as read-only
    enumerable: true,
    configurable: true
  });
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

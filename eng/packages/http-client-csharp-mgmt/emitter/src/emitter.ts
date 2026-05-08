// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { CodeModel, CSharpEmitterContext } from "@typespec/http-client-csharp";

import { emitAzureCodeModel } from "@azure-typespec/http-client-csharp";
import {
  azureSDKContextOptions,
  flattenPropertyDecorator,
  hasClientNameOverrideDecorator
} from "./sdk-context-options.js";
import { updateClients } from "./resource-detection.js";
import { getAllSdkClients } from "./sdk-client-utils.js";
import {
  DecoratorInfo,
  getClientNameOverride
} from "@azure-tools/typespec-client-generator-core";
import {
  AzureMgmtEmitterOptions,
  filterSuppressedDiagnostics
} from "./options.js";
import { transformSubscriptionIdParameters } from "./subscription-id-transformer.js";
import {
  deduplicateApiVersionEnums,
  fixClientApiVersions
} from "./api-version-fixer.js";

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
    setHasClientNameOverride(codeModel, sdkContext);
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

/**
 * Stamps a marker decorator onto every InputModelType whose underlying TypeSpec model
 * carries a user-supplied `@@clientName` override (csharp scope or unscoped). The
 * management generator's NameVisitor reads this marker to suppress its automatic
 * resource-update-model renaming so user-chosen names are preserved.
 *
 * The base C# emitter copies `decorators` into InputModelType via `getAllModelDecorators`,
 * which produces a fresh array, so we must mutate `codeModel.models[].decorators`
 * directly rather than `sdkPackage.models[].decorators`.
 */
function setHasClientNameOverride(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext
): void {
  // Models: must mutate codeModel.models[].decorators directly because
  // fromSdkModelType builds a fresh decorator array via getAllModelDecorators.
  const sdkModelByKey = new Map<string, (typeof sdkContext.sdkPackage.models)[number]>();
  for (const sdkModel of sdkContext.sdkPackage.models) {
    sdkModelByKey.set(`${sdkModel.namespace}.${sdkModel.name}`, sdkModel);
  }
  for (const inputModel of codeModel.models) {
    const sdkModel = sdkModelByKey.get(
      `${inputModel.namespace}.${inputModel.name}`
    );
    const raw = sdkModel?.__raw;
    if (!raw) {
      continue;
    }
    const override = getClientNameOverride(sdkContext, raw, "csharp");
    if (override === undefined) {
      continue;
    }
    inputModel.decorators ??= [];
    inputModel.decorators.push({
      name: hasClientNameOverrideDecorator,
      arguments: {}
    });
  }

  // Service methods: fromSdkServiceMethodOperation copies SdkServiceMethod.decorators
  // by reference into InputOperation.decorators (operation-converter.js line ~95), so
  // pushing onto sdkMethod.decorators surfaces the marker on
  // InputServiceMethod.Operation.Decorators in the C# generator.
  // (InputServiceMethod itself has no Decorators property.)
  for (const sdkClient of getAllSdkClients(sdkContext)) {
    for (const sdkMethod of sdkClient.methods) {
      const raw = sdkMethod.__raw;
      if (!raw) {
        continue;
      }
      const override = getClientNameOverride(sdkContext, raw, "csharp");
      if (override === undefined) {
        continue;
      }
      sdkMethod.decorators ??= [];
      sdkMethod.decorators.push({
        name: hasClientNameOverrideDecorator,
        arguments: {}
      });
    }
  }
}

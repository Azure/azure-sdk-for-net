// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { CodeModel, CSharpEmitterContext } from "@typespec/http-client-csharp";

import { $onEmit as $onAzureEmit } from "@azure-typespec/http-client-csharp";
import {
  azureSDKContextOptions,
  flattenPropertyDecorator
} from "./sdk-context-options.js";
import { updateClients } from "./resource-detection.js";
import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";
import { AzureMgmtEmitterOptions } from "./options.js";

export async function $onEmit(context: EmitContext<AzureMgmtEmitterOptions>) {
  context.options["generator-name"] ??= "ManagementClientGenerator";
  context.options["update-code-model"] = updateCodeModel;
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["sdk-context-options"] ??= azureSDKContextOptions;
  context.options["model-namespace"] ??= true;
  await $onAzureEmit(context);

  function updateCodeModel(
    codeModel: CodeModel,
    sdkContext: CSharpEmitterContext
  ): CodeModel {
    updateClients(codeModel, sdkContext);
    setFlattenProperty(codeModel, sdkContext);
    updateTrackedResourceWithOptionalLocation(codeModel);
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

function updateTrackedResourceWithOptionalLocation(codeModel: CodeModel): void {
  // Find models that have tags, location, and properties fields directly in the model (not inherited)
  // and extend Resource. This is the pattern for TrackedResourceWithOptionalLocation.
  for (const model of codeModel.models) {
    if (model.baseModel?.crossLanguageDefinitionId === "Azure.ResourceManager.CommonTypes.Resource") {
      // Check if this model has tags, location, and properties directly in its property list
      const hasTags = model.properties?.some(p => p.name === "tags");
      const hasLocation = model.properties?.some(p => p.name === "location");
      const hasProperties = model.properties?.some(p => p.name === "properties");
      
      if (hasTags && hasLocation && hasProperties) {
        // This is a model that extends TrackedResourceWithOptionalLocation
        // Update the cross-language definition ID directly
        model.baseModel.crossLanguageDefinitionId = "Azure.ResourceManager.Legacy.TrackedResourceWithOptionalLocation";
      }
    }
  }
}

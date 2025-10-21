// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { CodeModel, CSharpEmitterContext } from "@typespec/http-client-csharp";

import {
  $onEmit as $onAzureEmit,
  AzureEmitterOptions
} from "@azure-typespec/http-client-csharp";
import {
  azureSDKContextOptions,
  flattenPropertyDecorator
} from "./sdk-context-options.js";
import { updateClients } from "./resource-detection.js";
import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";

export async function $onEmit(context: EmitContext<AzureEmitterOptions>) {
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

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
import { transformSubscriptionIdParameters } from "./subscription-id-transformer.js";

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
    // Transform subscriptionId parameters from client scope to method scope
    // This must happen before other transformations that may depend on method parameters
    transformSubscriptionIdParameters(codeModel);

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

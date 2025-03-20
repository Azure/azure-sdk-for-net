// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";
import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";

import {
  CodeModel,
  CSharpEmitterOptions,
  InputModelType,
  setSDKContextOptions
} from "@typespec/http-client-csharp";

import {$onEmit as $onAzureEmit} from "@azure-typespec/http-client-csharp";
import { azureSDKContextOptions } from "./sdk-context-options.js";
import { calculateResourceTypeFromPath } from "./resource-type.js";

const armResourceOperations = "Azure.ResourceManager.@armResourceOperations";
const armResourceRead = "Azure.ResourceManager.@armResourceRead";
const armResourceCreateOrUpdate =
  "Azure.ResourceManager.@armResourceCreateOrUpdate";
const singleton = "Azure.ResourceManager.@singleton";
const resourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";

export async function $onEmit(context: EmitContext<CSharpEmitterOptions>) {
  context.options["generator-name"] ??= "MgmtClientGenerator";
  context.options["update-code-model"] = updateCodeModel;
  context.options["emitter-extension-path"] ??= import.meta.url;
  setSDKContextOptions(azureSDKContextOptions);
  await $onAzureEmit(context);
}

function updateCodeModel(codeModel: CodeModel): CodeModel {
  for (const client of codeModel.Clients) {
    // TODO: we can implement this decorator in TCGC until we meet the corner case
    // if the client has resourceMetadata decorator, it is a resource client and we don't need to add it again
    if (client.Decorators?.some((d) => d.name == resourceMetadata)) {
      continue;
    }

    // TODO: Once we have the ability to get resource hierarchy from TCGC directly, we can remove this implementation
    // A resource client should have decorator armResourceOperations and contains either a get operation(containing armResourceRead deocrator) or a put operation(containing armResourceCreateOrUpdate decorator)
    if (
      client.Decorators?.some((d) => d.name == armResourceOperations) &&
      client.Operations.some(
        (op) =>
          op.Decorators?.some(
            (d) => d.name == armResourceRead || armResourceCreateOrUpdate
          )
      )
    ) {
      let resourceModel: InputModelType | undefined = undefined;
      let isSingleton: boolean = false;
      let resourceType: string | undefined = undefined;
      // We will try to get resource metadata from put operation firstly, if not found, we will try to get it from get operation
      const putOperation = client.Operations.find(
        (op) => op.Decorators?.some((d) => d.name == armResourceCreateOrUpdate)
      );
      if (putOperation) {
        const path = putOperation.Path;
        resourceType = calculateResourceTypeFromPath(path);
        resourceModel = putOperation.Responses.filter((r) => r.BodyType)[0]
          .BodyType as InputModelType;
        isSingleton =
          resourceModel.decorators?.some((d) => d.name == singleton) ?? false;
      } else {
        const getOperation = client.Operations.find(
          (op) => op.Decorators?.some((d) => d.name == armResourceRead)
        );
        if (getOperation) {
          const path = getOperation.Path;
          resourceType = calculateResourceTypeFromPath(path);
          resourceModel = getOperation.Responses.filter((r) => r.BodyType)[0]
            .BodyType as InputModelType;
          isSingleton =
            resourceModel.decorators?.some((d) => d.name == singleton) ?? false;
        }
      }

      const resourceMetadataDecorator: DecoratorInfo = {
        name: resourceMetadata,
        arguments: {}
      };
      resourceMetadataDecorator.arguments["resourceModel"] =
        resourceModel?.crossLanguageDefinitionId;
      resourceMetadataDecorator.arguments["isSingleton"] =
        isSingleton.toString();
      resourceMetadataDecorator.arguments["resourceType"] = resourceType;
      client.Decorators.push(resourceMetadataDecorator);
    }
  }
  return codeModel;
}

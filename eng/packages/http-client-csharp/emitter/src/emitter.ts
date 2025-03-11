// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";
import {
  createSdkContext,
  DecoratorInfo
} from "@azure-tools/typespec-client-generator-core";

import {
  CSharpEmitterOptions,
  createModel,
  InputModelType,
  Logger,
  LoggerLevel,
  resolveOptions,
  emit
} from "@typespec/http-client-csharp";
import { azureSDKContextOptions } from "./sdk-context-options.js";
import { CalculateResourceTypeFromPath } from "./resource-type.js";

const armResourceOperations = "Azure.ResourceManager.@armResourceOperations";
const armResourceRead = "Azure.ResourceManager.@armResourceRead";
const armResourceCreateOrUpdate =
  "Azure.ResourceManager.@armResourceCreateOrUpdate";
const singleton = "Azure.ResourceManager.@singleton";
const resourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";

export async function $onEmit(context: EmitContext<CSharpEmitterOptions>) {
  const program = context.program;
  context.options["plugin-name"] ??= "AzureClientPlugin";
  context.options["emitter-extension-path"] = import.meta.url;

  const options = resolveOptions(context);
  /* set the log level. */
  const logger = new Logger(program, options.logLevel ?? LoggerLevel.INFO);

  // Write out the dotnet model to the output path
  const sdkContext = {
    ...(await createSdkContext(
      context,
      "@typespec/http-client-csharp",
      azureSDKContextOptions
    )),
    logger: logger,
    __typeCache: {
      crossLanguageDefinitionIds: new Map(),
      types: new Map(),
      models: new Map(),
      enums: new Map()
    }
  };
  program.reportDiagnostics(sdkContext.diagnostics);

  const root = createModel(sdkContext);
  if (!root) {
    return;
  }

  for (const client of root.Clients) {
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
        resourceType = CalculateResourceTypeFromPath(path);
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
          resourceType = CalculateResourceTypeFromPath(path);
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

  await emit(options, logger, sdkContext, context, root);
}

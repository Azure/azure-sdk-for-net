// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  CSharpEmitterContext,
  InputClient,
  InputModelType
} from "@typespec/http-client-csharp";
import {
  calculateResourceTypeFromPath,
  convertResourceMetadataToArguments,
  ResourceMetadata,
  ResourceOperationKind,
  ResourceScope
} from "./resource-metadata.js";
import {
  DecoratorInfo,
  getClientType,
  SdkClientType,
  SdkContext,
  SdkHttpOperation,
  SdkMethod,
  SdkModelType,
  SdkServiceOperation
} from "@azure-tools/typespec-client-generator-core";
import {
  armResourceActionName,
  armResourceCreateOrUpdateName,
  armResourceDeleteName,
  armResourceInternal,
  armResourceListName,
  armResourceReadName,
  armResourceUpdateName,
  parentResourceName,
  resourceGroupResource,
  resourceMetadata,
  singleton,
  subscriptionResource,
  tenantResource
} from "./sdk-context-options.js";
import { DecoratorApplication, Model, NoTarget } from "@typespec/compiler";
import { AzureEmitterOptions } from "@azure-typespec/http-client-csharp";

export async function updateClients(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext
) {
  const serviceMethods = new Map<string, SdkMethod<SdkHttpOperation>>(
    getAllSdkClients(sdkContext)
      .flatMap((c) => c.methods)
      .map((obj) => [obj.crossLanguageDefinitionId, obj])
  );
  const models = new Map<string, SdkModelType>(
    sdkContext.sdkPackage.models.map((m) => [m.crossLanguageDefinitionId, m])
  );
  const resourceModels = getAllResourceModels(codeModel);

  const resourceModelMap = new Map<string, ResourceMetadata>(
    resourceModels.map((m) => [
      m.crossLanguageDefinitionId,
      {
        resourceIdPattern: "", // this will be populated later
        resourceType: "", // this will be populated later
        singletonResourceName: getSingletonResource(
          m.decorators?.find((d) => d.name == singleton)
        ),
        resourceScope: getResourceScope(m),
        methods: [],
        parentResource: getParentResourceModelId(
          sdkContext,
          models.get(m.crossLanguageDefinitionId)
        )
      } as ResourceMetadata
    ])
  );

  // first we flatten all possible clients in the code model
  const clients = getAllClients(codeModel);

  // then we iterate over all the clients and their methods to find the resource operations
  // and add them to the resource model metadata
  // we also calculate the resource type from the path of the operation
  for (const client of clients) {
    for (const method of client.methods) {
      const serviceMethod = serviceMethods.get(
        method.crossLanguageDefinitionId
      );
      const [kind, modelId] =
        parseResourceOperation(serviceMethod, sdkContext) ?? [];
      if (modelId && kind) {
        const entry = resourceModelMap.get(modelId);
        entry?.methods.push({
          id: method.crossLanguageDefinitionId,
          kind
        });
        if (entry && !entry.resourceType) {
          entry.resourceType = calculateResourceTypeFromPath(
            method.operation.path
          );
        }
        if (entry && !entry.resourceIdPattern && isCRUDKind(kind)) {
          entry.resourceIdPattern = method.operation.path;
        }
      }
    }
  }

  // the last step, add the decorator to the resource model
  for (const model of resourceModels) {
    const metadata = resourceModelMap.get(model.crossLanguageDefinitionId);
    if (metadata) {
      addResourceMetadata(sdkContext, model, metadata);
    }
  }
}

function isCRUDKind(kind: ResourceOperationKind): boolean {
  return [
    ResourceOperationKind.Get,
    ResourceOperationKind.Create,
    ResourceOperationKind.Update,
    ResourceOperationKind.Delete
  ].includes(kind);
}

function parseResourceOperation(
  serviceMethod: SdkMethod<SdkHttpOperation> | undefined,
  sdkContext: CSharpEmitterContext
): [ResourceOperationKind, string | undefined] | undefined {
  const decorators = serviceMethod?.__raw?.decorators;
  for (const decorator of decorators ?? []) {
    if (decorator.definition?.name === armResourceReadName) {
      return [
        ResourceOperationKind.Get,
        getResourceModelId(sdkContext, decorator)
      ];
    } else if (decorator.definition?.name == armResourceCreateOrUpdateName) {
      return [
        ResourceOperationKind.Create,
        getResourceModelId(sdkContext, decorator)
      ];
    } else if (decorator.definition?.name == armResourceUpdateName) {
      return [
        ResourceOperationKind.Update,
        getResourceModelId(sdkContext, decorator)
      ];
    } else if (decorator.definition?.name == armResourceDeleteName) {
      return [
        ResourceOperationKind.Delete,
        getResourceModelId(sdkContext, decorator)
      ];
    } else if (decorator.definition?.name == armResourceListName) {
      return [
        ResourceOperationKind.List,
        getResourceModelId(sdkContext, decorator)
      ];
    } else if (decorator.definition?.name == armResourceActionName) {
      return [
        ResourceOperationKind.Action,
        getResourceModelId(sdkContext, decorator)
      ];
    }
  }
  return undefined;
}

function getParentResourceModelId(
  sdkContext: CSharpEmitterContext,
  model: SdkModelType | undefined
): string | undefined {
  const decorators = (model?.__raw as Model)?.decorators;
  const parentResourceDecorator = decorators?.find(
    (d) => d.definition?.name == parentResourceName
  );
  return getResourceModelId(sdkContext, parentResourceDecorator) ?? undefined;
}

function getResourceModelId(
  sdkContext: CSharpEmitterContext,
  decorator?: DecoratorApplication
): string | undefined {
  if (!decorator) return undefined;
  const model = getClientType(
    sdkContext,
    decorator.args[0].value as Model
  ) as SdkModelType;
  if (model) {
    return model.crossLanguageDefinitionId;
  } else {
    sdkContext.logger.reportDiagnostic({
      code: "general-error",
      messageId: "default",
      format: {
        message: `Resource model not found for decorator ${decorator.decorator.name}`
      },
      target: NoTarget,
    });
    return undefined;
  }
}

export function getAllSdkClients(
  sdkContext: SdkContext<AzureEmitterOptions, SdkHttpOperation>
): SdkClientType<SdkServiceOperation>[] {
  const clients: SdkClientType<SdkServiceOperation>[] = [];
  for (const client of sdkContext.sdkPackage.clients) {
    traverseClient(client);
  }

  return clients;

  function traverseClient(client: SdkClientType<SdkServiceOperation>) {
    clients.push(client);
    if (client.children) {
      for (const child of client.children) {
        traverseClient(child);
      }
    }
  }
}

export function getAllClients(codeModel: CodeModel): InputClient[] {
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client);
  }

  return clients;

  function traverseClient(client: InputClient) {
    clients.push(client);
    if (client.children) {
      for (const child of client.children) {
        traverseClient(child);
      }
    }
  }
}

function getAllResourceModels(codeModel: CodeModel): InputModelType[] {
  const resourceModels: InputModelType[] = [];
  for (const model of codeModel.models) {
    if (model.decorators?.some((d) => d.name == armResourceInternal)) {
      model.crossLanguageDefinitionId;
      resourceModels.push(model);
    }
  }
  return resourceModels;
}

function getSingletonResource(
  decorator: DecoratorInfo | undefined
): string | undefined {
  if (!decorator) return undefined;
  const singletonResource = decorator.arguments["keyValue"] as
    | string
    | undefined;
  return singletonResource ?? "default";
}

function getResourceScope(model: InputModelType): ResourceScope {
  const decorators = model.decorators;
  if (decorators?.some((d) => d.name == tenantResource)) {
    return ResourceScope.Tenant;
  } else if (decorators?.some((d) => d.name == subscriptionResource)) {
    return ResourceScope.Subscription;
  } else if (decorators?.some((d) => d.name == resourceGroupResource)) {
    return ResourceScope.ResourceGroup;
  }
  return ResourceScope.ResourceGroup; // all the templates work as if there is a resource group decorator when there is no such decorator
}

function addResourceMetadata(
  sdkContext: CSharpEmitterContext,
  model: InputModelType,
  metadata: ResourceMetadata
) {
  if (metadata.resourceIdPattern === "") {
    sdkContext.logger.reportDiagnostic({
      code: "general-warning", // TODO -- later maybe we could define a specific code for resource hierarchy issues
      messageId: "default",
      format: {
        message: `Cannot figure out resourceIdPatternResource from model ${model.name}.`
      },
      target: NoTarget, // TODO -- we need a method to find the raw target from the crossLanguageDefinitionId of this model
    });
    return;
  }

  const resourceMetadataDecorator: DecoratorInfo = {
    name: resourceMetadata,
    arguments: convertResourceMetadataToArguments(metadata)
  };

  if (!model.decorators) {
    model.decorators = [];
  }

  model.decorators.push(resourceMetadataDecorator);
}

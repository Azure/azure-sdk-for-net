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
  convertMethodMetadataToArguments,
  convertResourceMetadataToArguments,
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
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
  nonResourceMethodMetadata,
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
  const resourceModelMap = new Map<string, InputModelType>(
    resourceModels.map((m) => [m.crossLanguageDefinitionId, m])
  );

  const resourceModelToMetadataMap = new Map<string, ResourceMetadata>(
    resourceModels.map((m) => [
      m.crossLanguageDefinitionId,
      {
        resourceIdPattern: "", // this will be populated later
        resourceType: "", // this will be populated later
        singletonResourceName: getSingletonResource(
          m.decorators?.find((d) => d.name == singleton)
        ),
        resourceScope: ResourceScope.ResourceGroup, // temporary default to ResourceGroup, will be properly set later after methods are populated
        methods: [],
        parentResourceId: undefined, // this will be populated later
        resourceName: m.name
      } as ResourceMetadata
    ])
  );
  const nonResourceMethods: Map<string, NonResourceMethod> = new Map();

  // first we flatten all possible clients in the code model
  const clients = getAllClients(codeModel);

  // then we iterate over all the clients and their methods to find the resource operations
  // and add them to the resource model metadata
  // during the process we populate the resourceIdPattern and resourceType
  for (const client of clients) {
    for (const method of client.methods) {
      const serviceMethod = serviceMethods.get(
        method.crossLanguageDefinitionId
      );
      const [kind, modelId] =
        parseResourceOperation(serviceMethod, sdkContext) ?? [];
      if (modelId && kind) {
        const entry = resourceModelToMetadataMap.get(modelId);
        entry?.methods.push({
          methodId: method.crossLanguageDefinitionId,
          kind,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
        if (entry && !entry.resourceType) {
          entry.resourceType = calculateResourceTypeFromPath(
            method.operation.path
          );
        }
        if (entry && !entry.resourceIdPattern && isCRUDKind(kind)) {
          entry.resourceIdPattern = method.operation.path;
        }
      } else {
        // we add a methodMetadata decorator to this method
        nonResourceMethods.set(method.crossLanguageDefinitionId, {
          methodId: method.crossLanguageDefinitionId,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
      }
    }
  }

  // after the resourceIdPattern has been populated, we can set the parentResourceId and the resource scope of each resource method
  for (const [modelId, metadata] of resourceModelToMetadataMap) {
    // get parent resource model id
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      metadata.parentResourceId = resourceModelToMetadataMap.get(
        parentResourceModelId
      )?.resourceIdPattern;
    }

    // figure out the resourceScope of all resource methods
    for (const method of metadata.methods) {
      method.resourceScope = getResourceScopeOfMethod(
        method.operationPath,
        resourceModelToMetadataMap.values()
      );
    }

    // update the model's resourceScope based on resource scope decorator if exist or based on the Get method's scope. If neither exist, it will be set to ResourceGroup by default
    const model = resourceModelMap.get(modelId);
    if (model) {
      metadata.resourceScope = getResourceScope(model, metadata.methods);
    }
  }

  // the last step, add the decorator to the resource model
  for (const model of resourceModels) {
    const metadata = resourceModelToMetadataMap.get(
      model.crossLanguageDefinitionId
    );
    if (metadata) {
      addResourceMetadata(sdkContext, model, metadata);
    }
  }
  // and add the methodMetadata decorator to the non-resource methods
  addNonResourceMethodDecorators(
    codeModel,
    Array.from(nonResourceMethods.values())
  );
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
  return getResourceModelId(sdkContext, parentResourceDecorator);
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
      target: NoTarget
    });
    return undefined;
  }
}

export function getAllSdkClients(
  sdkContext: SdkContext<AzureEmitterOptions, SdkHttpOperation>
): SdkClientType<SdkServiceOperation>[] {
  const clients: SdkClientType<SdkServiceOperation>[] = [];
  for (const client of sdkContext.sdkPackage.clients) {
    traverseClient(client, clients);
  }

  return clients;
}

export function getAllClients(codeModel: CodeModel): InputClient[] {
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client, clients);
  }

  return clients;
}

function traverseClient<T extends { children?: T[] }>(client: T, clients: T[]) {
  clients.push(client);
  if (client.children) {
    for (const child of client.children) {
      traverseClient(child, clients);
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

function getResourceScope(model: InputModelType, methods?: ResourceMethod[]): ResourceScope {
  // First, check for explicit scope decorators
  const decorators = model.decorators;
  if (decorators?.some((d) => d.name == tenantResource)) {
    return ResourceScope.Tenant;
  } else if (decorators?.some((d) => d.name == subscriptionResource)) {
    return ResourceScope.Subscription;
  } else if (decorators?.some((d) => d.name == resourceGroupResource)) {
    return ResourceScope.ResourceGroup;
  }

  // Fall back to Get method's scope only if no scope decorators are found
  if (methods) {
    const getMethod = methods.find(m => m.kind === ResourceOperationKind.Get);
    if (getMethod) {
      return getMethod.operationScope;
    }
  }

  // Final fallback to ResourceGroup
  return ResourceScope.ResourceGroup; // all the templates work as if there is a resource group decorator when there is no such decorator
}

function getResourceScopeOfMethod(
  path: string,
  resources: MapIterator<ResourceMetadata>
): string | undefined {
  // loop all possible resource metadata and see if some of them match the operation path of this method as a prefix
  const candidates: string[] = [];
  for (const otherMetadata of resources) {
    if (
      otherMetadata.resourceIdPattern &&
      path.startsWith(otherMetadata.resourceIdPattern)
    ) {
      candidates.push(otherMetadata.resourceIdPattern);
    }
  }
  // finds the longest resource path id in candidates as the resource scope
  if (candidates.length > 0) {
    return candidates.reduce((a, b) => (a.length > b.length ? a : b));
  }
  return undefined;
}

// TODO -- this logic needs to be refined in the near future.
function getOperationScope(path: string): ResourceScope {
  if (
    path.startsWith(
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/"
    )
  ) {
    return ResourceScope.ResourceGroup;
  } else if (path.startsWith("/subscriptions/{subscriptionId}/")) {
    return ResourceScope.Subscription;
  }
  return ResourceScope.Tenant; // all the templates work as if there is a tenant decorator when there is no such decorator
}

function addNonResourceMethodDecorators(
  codeModel: CodeModel,
  metadata: NonResourceMethod[]
) {
  codeModel.clients[0].decorators ??= [];
  codeModel.clients[0].decorators.push({
    name: nonResourceMethodMetadata,
    arguments: convertMethodMetadataToArguments(metadata)
  });
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
        message: `Cannot figure out resourceIdPattern from model ${model.name}.`
      },
      target: NoTarget // TODO -- we need a method to find the raw target from the crossLanguageDefinitionId of this model
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

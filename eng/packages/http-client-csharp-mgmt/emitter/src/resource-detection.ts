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
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
  ResourceOperationKind,
  ResourceScope,
  ArmProviderSchema,
  ArmResourceSchema,
  convertArmProviderSchemaToArguments
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
import pluralize from "pluralize";
import {
  armProviderSchema,
  armResourceActionName,
  armResourceCreateOrUpdateName,
  armResourceDeleteName,
  armResourceInternal,
  armResourceListName,
  armResourceReadName,
  armResourceUpdateName,
  armResourceWithParameter,
  extensionResourceOperationName,
  legacyExtensionResourceOperationName,
  legacyResourceOperationName,
  builtInResourceOperationName,
  parentResourceName,
  readsResourceName,
  resourceGroupResource,
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
  // Build the unified ARM provider schema and apply it to the root client
  const armProviderSchema = buildArmProviderSchema(sdkContext, codeModel);
  applyArmProviderSchemaDecorator(codeModel, armProviderSchema);
}

/**
 * Builds the ARM provider schema by detecting all resources and non-resource methods.
 * This is the main function that gathers all ARM-related information from the code model
 * and consolidates it into a unified ArmProviderSchema structure.
 * 
 * This function is exported for testing purposes and can be called directly from tests
 * to validate the schema structure.
 * 
 * @param sdkContext - The emitter context
 * @param codeModel - The code model to analyze
 * @returns The unified ARM provider schema containing all resources and non-resource methods
 */
export function buildArmProviderSchema(
  sdkContext: CSharpEmitterContext,
  codeModel: CodeModel
): ArmProviderSchema {
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

  const resourcePathToMetadataMap = new Map<string, ResourceMetadata>();
  const resourceModelIds = new Set<string>(resourceModels.map(m => m.crossLanguageDefinitionId));
  const resourcePathToClientName = new Map<string, string>();
  const resourcePathToExplicitName = new Map<string, string>();
  const nonResourceMethods: Map<string, NonResourceMethod> = new Map();

  const clients = getAllClients(codeModel);

  // Detect resources and methods (same logic as in updateClients)
  for (const client of clients) {
    for (const method of client.methods) {
      const serviceMethod = serviceMethods.get(
        method.crossLanguageDefinitionId
      );
      const [kind, modelId, explicitResourceName] =
        parseResourceOperation(serviceMethod, sdkContext) ?? [];
     
      if (modelId && kind && resourceModelIds.has(modelId)) {
        let resourcePath = "";
        if (isCRUDKind(kind)) {
          resourcePath = method.operation.path;
        } else {
          const operationPath = method.operation.path;
          for (const [existingKey] of resourcePathToMetadataMap) {
            const [existingModelId, existingPath] = existingKey.split('|');
            if (existingModelId === modelId && existingPath) {
              const existingResourceType = calculateResourceTypeFromPath(existingPath);
              let operationResourceType = "";
              try {
                operationResourceType = calculateResourceTypeFromPath(operationPath);
              } catch {
                // If we can't calculate resource type, try string matching
              }
              
              if (existingResourceType && operationResourceType === existingResourceType) {
                resourcePath = existingPath;
                break;
              }
              
              const existingParentPath = existingPath.substring(0, existingPath.lastIndexOf('/'));
              if (operationPath.startsWith(existingParentPath)) {
                resourcePath = existingPath;
                break;
              }
            }
          }
          if (!resourcePath) {
            resourcePath = operationPath;
          }
        }
        
        const metadataKey = `${modelId}|${resourcePath}`;
        
        if (explicitResourceName && !resourcePathToExplicitName.has(metadataKey)) {
          resourcePathToExplicitName.set(metadataKey, explicitResourceName);
        }
        
        let entry = resourcePathToMetadataMap.get(metadataKey);
        if (!entry) {
          const model = resourceModelMap.get(modelId);
          if (!resourcePathToClientName.has(metadataKey)) {
            resourcePathToClientName.set(metadataKey, client.name);
          }
          
          entry = {
            resourceIdPattern: "",
            resourceType: "",
            singletonResourceName: getSingletonResource(
              model?.decorators?.find((d) => d.name == singleton)
            ),
            resourceScope: ResourceScope.Tenant,
            methods: [],
            parentResourceId: undefined,
            parentResourceModelId: undefined,
            resourceName: model?.name ?? "Unknown"
          } as ResourceMetadata;
          resourcePathToMetadataMap.set(metadataKey, entry);
        }
        
        entry.methods.push({
          methodId: method.crossLanguageDefinitionId,
          kind,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
        if (!entry.resourceType) {
          entry.resourceType = calculateResourceTypeFromPath(
            method.operation.path
          );
        }
        if (!entry.resourceIdPattern && isCRUDKind(kind)) {
          entry.resourceIdPattern = method.operation.path;
        }
      } else if (modelId && kind) {
        nonResourceMethods.set(method.crossLanguageDefinitionId, {
          methodId: method.crossLanguageDefinitionId,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
      } else {
        nonResourceMethods.set(method.crossLanguageDefinitionId, {
          methodId: method.crossLanguageDefinitionId,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
      }
    }
  }

  // Set parent and scope information
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split('|')[0];
    
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      for (const [parentKey, parentMetadata] of resourcePathToMetadataMap) {
        const parentModelId = parentKey.split('|')[0];
        if (parentModelId === parentResourceModelId && parentMetadata.resourceIdPattern) {
          metadata.parentResourceId = parentMetadata.resourceIdPattern;
          metadata.parentResourceModelId = parentResourceModelId;
          break;
        }
      }
    }
    
    if (!metadata.parentResourceId && metadata.resourceIdPattern) {
      for (const [otherKey, otherMetadata] of resourcePathToMetadataMap) {
        if (otherKey !== metadataKey && otherMetadata.resourceIdPattern) {
          const thisPath = metadata.resourceIdPattern;
          const potentialParentPath = otherMetadata.resourceIdPattern;
          
          if (thisPath.startsWith(potentialParentPath + "/") && thisPath.length > potentialParentPath.length + 1) {
            metadata.parentResourceId = potentialParentPath;
            break;
          }
        }
      }
    }

    for (const method of metadata.methods) {
      method.resourceScope = getResourceScopeOfMethod(
        method.operationPath,
        resourcePathToMetadataMap.values()
      );
    }

    const model = resourceModelMap.get(modelId);
    if (model) {
      metadata.resourceScope = getResourceScope(model, metadata.methods);
    }
  }

  // Clean up entries without resourceIdPattern
  const metadataKeysToDelete: string[] = [];
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split('|')[0];
    
    if (metadata.resourceIdPattern === "") {
      let merged = false;
      
      if (metadata.parentResourceModelId) {
        for (const [parentKey, parentMetadata] of resourcePathToMetadataMap) {
          const parentModelId = parentKey.split('|')[0];
          if (parentModelId === metadata.parentResourceModelId && parentMetadata.resourceIdPattern) {
            parentMetadata.methods.push(...metadata.methods);
            metadataKeysToDelete.push(metadataKey);
            merged = true;
            break;
          }
        }
      } else {
        for (const [otherKey, otherMetadata] of resourcePathToMetadataMap) {
          const otherModelId = otherKey.split('|')[0];
          if (otherKey !== metadataKey && otherModelId === modelId && otherMetadata.resourceIdPattern) {
            otherMetadata.methods.push(...metadata.methods);
            metadataKeysToDelete.push(metadataKey);
            merged = true;
            break;
          }
        }
        
        if (!merged) {
          for (const method of metadata.methods) {
            nonResourceMethods.set(method.methodId, {
              methodId: method.methodId,
              operationPath: method.operationPath,
              operationScope: method.operationScope
            });
          }
          metadataKeysToDelete.push(metadataKey);
        }
      }
    }
  }
  
  for (const key of metadataKeysToDelete) {
    resourcePathToMetadataMap.delete(key);
  }

  // Update resource names
  const modelIdToMetadataList = new Map<string, ResourceMetadata[]>();
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split('|')[0];
    if (!modelIdToMetadataList.has(modelId)) {
      modelIdToMetadataList.set(modelId, []);
    }
    modelIdToMetadataList.get(modelId)!.push(metadata);
  }
  
  for (const [modelId, metadataList] of modelIdToMetadataList) {
    if (metadataList.length > 1) {
      for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
        const keyModelId = metadataKey.split('|')[0];
        if (keyModelId === modelId) {
          const explicitName = resourcePathToExplicitName.get(metadataKey);
          if (explicitName) {
            metadata.resourceName = explicitName;
          } else {
            const clientName = resourcePathToClientName.get(metadataKey);
            if (clientName) {
              metadata.resourceName = pluralize.singular(clientName);
            }
          }
        }
      }
    }
  }

  return buildArmProviderSchemaFromDetectedResources(
    sdkContext,
    resourceModels,
    resourcePathToMetadataMap,
    nonResourceMethods
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
): [ResourceOperationKind, string | undefined, string | undefined] | undefined {
  const decorators = serviceMethod?.__raw?.decorators;
  for (const decorator of decorators ?? []) {
    switch (decorator.definition?.name) {
      case readsResourceName:
      case armResourceReadName:
        return [
          ResourceOperationKind.Get,
          getResourceModelId(sdkContext, decorator),
          undefined // No explicit resource name for ARM operations
        ];
      case armResourceCreateOrUpdateName:
        return [
          ResourceOperationKind.Create,
          getResourceModelId(sdkContext, decorator),
          undefined
        ];
      case armResourceUpdateName:
        return [
          ResourceOperationKind.Update,
          getResourceModelId(sdkContext, decorator),
          undefined
        ];
      case armResourceDeleteName:
        return [
          ResourceOperationKind.Delete,
          getResourceModelId(sdkContext, decorator),
          undefined
        ];
      case armResourceListName:
        return [
          ResourceOperationKind.List,
          getResourceModelId(sdkContext, decorator),
          undefined
        ];
      case armResourceActionName:
        return [
          ResourceOperationKind.Action,
          getResourceModelId(sdkContext, decorator),
          undefined
        ];
      case extensionResourceOperationName:
        switch (decorator.args[2].jsValue) {
          case "read":
            return [
              ResourceOperationKind.Get,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "createOrUpdate":
            return [
              ResourceOperationKind.Create,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "update":
            return [
              ResourceOperationKind.Update,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "delete":
            return [
              ResourceOperationKind.Delete,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "list":
            return [
              ResourceOperationKind.List,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "action":
            return [
              ResourceOperationKind.Action,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
        }
        break;
      case legacyExtensionResourceOperationName:
      case legacyResourceOperationName:
        switch (decorator.args[1].jsValue) {
          case "read":
            return [
              ResourceOperationKind.Get,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              // Extract the explicit resource name if available (4th parameter in LegacyOperations)
              decorator.args.length > 3 ? (decorator.args[3].jsValue as string) : undefined
            ];
          case "createOrUpdate":
            return [
              ResourceOperationKind.Create,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              decorator.args.length > 3 ? (decorator.args[3].jsValue as string) : undefined
            ];
          case "update":
            return [
              ResourceOperationKind.Update,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              decorator.args.length > 3 ? (decorator.args[3].jsValue as string) : undefined
            ];
          case "delete":
            return [
              ResourceOperationKind.Delete,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              decorator.args.length > 3 ? (decorator.args[3].jsValue as string) : undefined
            ];
          case "list":
            return [
              ResourceOperationKind.List,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              decorator.args.length > 3 ? (decorator.args[3].jsValue as string) : undefined
            ];
          case "action":
            return [
              ResourceOperationKind.Action,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              decorator.args.length > 3 ? (decorator.args[3].jsValue as string) : undefined
            ];
        }
        return undefined;
      case builtInResourceOperationName:
        switch (decorator.args[2].jsValue) {
          case "read":
            return [
              ResourceOperationKind.Get,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "createOrUpdate":
            return [
              ResourceOperationKind.Create,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "update":
            return [
              ResourceOperationKind.Update,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "delete":
            return [
              ResourceOperationKind.Delete,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "list":
            return [
              ResourceOperationKind.List,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
          case "action":
            return [
              ResourceOperationKind.Action,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              undefined
            ];
        }
        return undefined;
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
  return getResourceModelIdCore(
    sdkContext,
    decorator.args[0].value as Model,
    decorator.definition?.name
  );
}

function getResourceModelIdCore(
  sdkContext: CSharpEmitterContext,
  decoratorModel: Model,
  decoratorName?: string
): string | undefined {
  const model = getClientType(sdkContext, decoratorModel) as SdkModelType;
  if (model) {
    return model.crossLanguageDefinitionId;
  } else {
    sdkContext.logger.reportDiagnostic({
      code: "general-error",
      messageId: "default",
      format: {
        message: `Resource model not found for decorator ${decoratorName}`
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
    if (model.decorators?.some((d) => d.name == armResourceInternal || d.name == armResourceWithParameter)) {
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
function getResourceScope(
  model: InputModelType,
  methods?: ResourceMethod[]
): ResourceScope {
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
    const getMethod = methods.find((m) => m.kind === ResourceOperationKind.Get);
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

function getOperationScope(path: string): ResourceScope {
  if (path.startsWith("/{resourceUri}") || path.startsWith("/{scope}")) {
    return ResourceScope.Extension;
  } else if (
    path.startsWith(
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/"
    )
  ) {
    return ResourceScope.ResourceGroup;
  } else if (path.startsWith("/subscriptions/{subscriptionId}/")) {
    return ResourceScope.Subscription;
  } else if (
    path.startsWith(
      "/providers/Microsoft.Management/managementGroups/{managementGroupId}/"
    )
  ) {
    return ResourceScope.ManagementGroup;
  }
  return ResourceScope.Tenant; // all the templates work as if there is a tenant decorator when there is no such decorator
}

/**
 * Applies the ARM provider schema as a decorator to the root client.
 * @param codeModel - The code model to update
 * @param schema - The ARM provider schema to apply
 */
function applyArmProviderSchemaDecorator(
  codeModel: CodeModel,
  schema: ArmProviderSchema
): void {
  const rootClient = codeModel.clients[0];
  rootClient.decorators ??= [];
  rootClient.decorators.push({
    name: armProviderSchema,
    arguments: convertArmProviderSchemaToArguments(schema)
  });
}


/**
 * Builds the ARM provider schema from detected resources and non-resource methods.
 * This consolidates all ARM resource information into a single unified structure.
 * This is a helper function called by buildArmProviderSchema.
 * 
 * @param sdkContext - The emitter context
 * @param resourceModels - All resource models detected in the code model
 * @param resourcePathToMetadataMap - Map of resource paths to their metadata
 * @param nonResourceMethods - Map of non-resource methods
 * @returns The unified ARM provider schema
 */
function buildArmProviderSchemaFromDetectedResources(
  sdkContext: CSharpEmitterContext,
  resourceModels: InputModelType[],
  resourcePathToMetadataMap: Map<string, ResourceMetadata>,
  nonResourceMethods: Map<string, NonResourceMethod>
): ArmProviderSchema {
  const resources: ArmResourceSchema[] = [];

  // Build resource schemas from the metadata map
  // Group by model ID since multiple paths can share the same model
  const modelIdToMetadataList = new Map<string, ResourceMetadata[]>();
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split('|')[0];
    if (!modelIdToMetadataList.has(modelId)) {
      modelIdToMetadataList.set(modelId, []);
    }
    modelIdToMetadataList.get(modelId)!.push(metadata);
  }

  // Create resource schemas
  for (const model of resourceModels) {
    const metadataList = modelIdToMetadataList.get(model.crossLanguageDefinitionId);
    if (metadataList) {
      for (const metadata of metadataList) {
        if (metadata.resourceIdPattern === "") {
          sdkContext.logger.reportDiagnostic({
            code: "general-warning",
            messageId: "default",
            format: {
              message: `Cannot figure out resourceIdPattern from model ${model.name}.`
            },
            target: NoTarget
          });
          continue;
        }

        resources.push({
          resourceModelId: model.crossLanguageDefinitionId,
          metadata: metadata
        });
      }
    }
  }

  return {
    resources: resources,
    nonResourceMethods: Array.from(nonResourceMethods.values())
  };
}



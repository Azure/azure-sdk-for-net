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
  armResourceWithParameter,
  extensionResourceOperationName,
  legacyExtensionResourceOperationName,
  legacyResourceOperationName,
  builtInResourceOperationName,
  nonResourceMethodMetadata,
  parentResourceName,
  readsResourceName,
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

  // Map to track resource metadata by unique key (modelId + resourcePath)
  // This allows multiple resources to share the same model but have different paths
  const resourcePathToMetadataMap = new Map<string, ResourceMetadata>();
  
  // Map to track which resource models are used (for backward compatibility)
  const resourceModelIds = new Set<string>(resourceModels.map(m => m.crossLanguageDefinitionId));
  
  // Track client names associated with each resource path for name derivation
  const resourcePathToClientName = new Map<string, string>();
  
  // Track explicit resource names from TypeSpec (e.g., from LegacyOperations ResourceName parameter)
  const resourcePathToExplicitName = new Map<string, string>();
  
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
      const [kind, modelId, explicitResourceName] =
        parseResourceOperation(serviceMethod, sdkContext) ?? [];
     
      if (modelId && kind && resourceModelIds.has(modelId)) {
        // Determine the resource path from the CRUD operation
        let resourcePath = "";
        if (isCRUDKind(kind)) {
          resourcePath = method.operation.path;
        } else {
          // For non-CRUD operations like List, try to match with existing resource paths for the same model
          const operationPath = method.operation.path;
          for (const [existingKey] of resourcePathToMetadataMap) {
            const [existingModelId, existingPath] = existingKey.split('|');
            // Check if this is for the same model
            if (existingModelId === modelId && existingPath) {
              // Try to match based on resource type segments
              // Extract the resource type part (after "/providers/")
              const existingResourceType = calculateResourceTypeFromPath(existingPath);
              let operationResourceType = "";
              try {
                operationResourceType = calculateResourceTypeFromPath(operationPath);
              } catch {
                // If we can't calculate resource type, try string matching
              }
              
              // If resource types match, this list operation belongs to this resource
              if (existingResourceType && operationResourceType === existingResourceType) {
                resourcePath = existingPath;
                break;
              }
              
              // Fallback: check if the operation path ends with a segment that matches the existing path
              const existingParentPath = existingPath.substring(0, existingPath.lastIndexOf('/'));
              if (operationPath.startsWith(existingParentPath)) {
                resourcePath = existingPath;
                break;
              }
            }
          }
          // If no match found, use the operation path
          if (!resourcePath) {
            resourcePath = operationPath;
          }
        }
        
        // Create a unique key combining model ID and resource path
        const metadataKey = `${modelId}|${resourcePath}`;
        
        // Store explicit resource name if provided (from LegacyOperations ResourceName parameter)
        if (explicitResourceName && !resourcePathToExplicitName.has(metadataKey)) {
          resourcePathToExplicitName.set(metadataKey, explicitResourceName);
        }
        
        // Get or create metadata entry for this resource path
        let entry = resourcePathToMetadataMap.get(metadataKey);
        if (!entry) {
          const model = resourceModelMap.get(modelId);
          // Store the client name for this resource path for later use (fallback if no explicit name)
          if (!resourcePathToClientName.has(metadataKey)) {
            resourcePathToClientName.set(metadataKey, client.name);
          }
          
          entry = {
            resourceIdPattern: "", // this will be populated later
            resourceType: "", // this will be populated later
            singletonResourceName: getSingletonResource(
              model?.decorators?.find((d) => d.name == singleton)
            ),
            resourceScope: ResourceScope.Tenant, // temporary default to Tenant, will be properly set later after methods are populated
            methods: [],
            parentResourceId: undefined, // this will be populated later
            parentResourceModelId: undefined,
            // Use model name as default; will be updated later if multiple paths exist
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
        // no resource model found for this modelId, treat as non-resource method
        nonResourceMethods.set(method.crossLanguageDefinitionId, {
          methodId: method.crossLanguageDefinitionId,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
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
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    // Extract model ID from the key (format: "modelId|resourcePath")
    const modelId = metadataKey.split('|')[0];
    
    // get parent resource model id
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      // Find parent metadata entry - there might be multiple, so we need to find the right one
      for (const [parentKey, parentMetadata] of resourcePathToMetadataMap) {
        const parentModelId = parentKey.split('|')[0];
        if (parentModelId === parentResourceModelId && parentMetadata.resourceIdPattern) {
          metadata.parentResourceId = parentMetadata.resourceIdPattern;
          metadata.parentResourceModelId = parentResourceModelId;
          break;
        }
      }
    }

    // figure out the resourceScope of all resource methods
    for (const method of metadata.methods) {
      method.resourceScope = getResourceScopeOfMethod(
        method.operationPath,
        resourcePathToMetadataMap.values()
      );
    }

    // update the model's resourceScope based on resource scope decorator if it exists or based on the Get method's scope. If neither exist, it will be set to ResourceGroup by default
    const model = resourceModelMap.get(modelId);
    if (model) {
      metadata.resourceScope = getResourceScope(model, metadata.methods);
    }
  }

  // after the parentResourceId and resource scopes are populated, we can reorganize the metadata that is missing resourceIdPattern
  const metadataKeysToDelete: string[] = [];
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split('|')[0];
    
    // If this entry has no resourceIdPattern, try to merge it with another entry for the same model that does
    if (metadata.resourceIdPattern === "") {
      let merged = false;
      
      // First try to merge with parent if it exists
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
        // No parent - try to find another entry for the same model with a resourceIdPattern
        for (const [otherKey, otherMetadata] of resourcePathToMetadataMap) {
          const otherModelId = otherKey.split('|')[0];
          if (otherKey !== metadataKey && otherModelId === modelId && otherMetadata.resourceIdPattern) {
            // Merge this metadata into the other one
            otherMetadata.methods.push(...metadata.methods);
            metadataKeysToDelete.push(metadataKey);
            merged = true;
            break;
          }
        }
        
        // If there's no parent and no other entry to merge with, treat all methods as non-resource methods
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
  
  // Remove entries that were merged or converted to non-resource methods
  for (const key of metadataKeysToDelete) {
    resourcePathToMetadataMap.delete(key);
  }

  // the last step, add the decorator to the resource model
  // Group metadata by model ID to add all metadata entries to their respective models
  const modelIdToMetadataList = new Map<string, ResourceMetadata[]>();
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split('|')[0];
    if (!modelIdToMetadataList.has(modelId)) {
      modelIdToMetadataList.set(modelId, []);
    }
    modelIdToMetadataList.get(modelId)!.push(metadata);
  }
  
  // Update resource names: prioritize explicit ResourceName from TypeSpec, fallback to deriving from client names
  // This handles the scenario where the same model is used by multiple resource interfaces with different paths.
  // TypeSpec authors should specify explicit ResourceName parameters in LegacyOperations templates.
  for (const [modelId, metadataList] of modelIdToMetadataList) {
    if (metadataList.length > 1) {
      // Multiple resource paths for the same model - use explicit names or derive from client names
      for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
        const keyModelId = metadataKey.split('|')[0];
        if (keyModelId === modelId) {
          // Prioritize explicit resource name from TypeSpec (e.g., LegacyOperations ResourceName parameter)
          const explicitName = resourcePathToExplicitName.get(metadataKey);
          if (explicitName) {
            metadata.resourceName = explicitName;
          } else {
            // Fallback: derive from client name
            const clientName = resourcePathToClientName.get(metadataKey);
            if (clientName) {
              metadata.resourceName = deriveResourceNameFromClient(clientName);
            }
          }
        }
      }
    }
    // If there's only one metadata entry for this model, keep using the model name (already set)
  }
  
  // Add decorators to models
  for (const model of resourceModels) {
    const metadataList = modelIdToMetadataList.get(model.crossLanguageDefinitionId);
    if (metadataList) {
      for (const metadata of metadataList) {
        addResourceMetadata(sdkContext, model, metadata);
      }
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

/**
 * Derives a resource name from a client/interface name by removing pluralization.
 * This is used as a FALLBACK when no explicit ResourceName is specified in TypeSpec.
 * TypeSpec authors should specify explicit ResourceName parameters in LegacyOperations templates
 * to avoid relying on this derivation logic.
 * 
 * Examples: "BestPractices" -> "BestPractice", "BestPracticeVersions" -> "BestPracticeVersion"
 * Other examples: "Employees" -> "Employee", "Companies" -> "Company"
 */
function deriveResourceNameFromClient(clientName: string): string {
  // Handle common plural endings
  if (clientName.endsWith("ies") && clientName.length > 3) {
    // "Practices" -> "Practice", "Companies" -> "Company"
    return clientName.substring(0, clientName.length - 3) + "y";
  } else if (clientName.endsWith("sses") || clientName.endsWith("xes") || clientName.endsWith("ches") || clientName.endsWith("shes")) {
    // "Boxes" -> "Box", "Classes" -> "Class", "Watches" -> "Watch", "Bushes" -> "Bush"
    return clientName.substring(0, clientName.length - 2);
  } else if (clientName.endsWith("s") && clientName.length > 1 && !clientName.endsWith("ss")) {
    // "Employees" -> "Employee", "Dogs" -> "Dog", "BestPracticeVersions" -> "BestPracticeVersion"
    // But not "Class" -> "Clas"
    return clientName.substring(0, clientName.length - 1);
  }
  
  // If no plural pattern matches, return the name as-is
  return clientName;
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

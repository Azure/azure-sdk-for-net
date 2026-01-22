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
  convertArmProviderSchemaToArguments,
  sortResourceMethods
} from "./resource-metadata.js";
import {
  DecoratorInfo,
  getClientType,
  SdkHttpOperation,
  SdkMethod,
  SdkModelType
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
import {
  resolveArmResources,
  getOperationScopeFromPath
} from "./resolve-arm-resources-converter.js";
import { AzureMgmtEmitterOptions } from "./options.js";
import { isPrefix } from "./utils.js";
import { getAllSdkClients, traverseClient } from "./sdk-client-utils.js";

export async function updateClients(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext,
  options: AzureMgmtEmitterOptions
) {
  // Check if the use-legacy-resource-detection flag is disabled (i.e., use new resolveArmResources API)
  const armProviderSchema =
    options?.["use-legacy-resource-detection"] === false
      ? resolveArmResources(sdkContext.program, sdkContext)
      : buildArmProviderSchema(sdkContext, codeModel);

  applyArmProviderSchemaDecorator(codeModel, armProviderSchema);
}

/**
 * Builds the ARM provider schema by detecting all resources and non-resource methods.
 * This is the main function that gathers all ARM-related information from the code model
 * and consolidates it into a unified ArmProviderSchema structure.
 *
 * This function is exported for testing purposes and can be called directly from tests
 * to validate the schema structure using the legacy custom resource detection logic.
 *
 * @param sdkContext - The emitter context
 * @param codeModel - The code model to analyze
 * @returns The unified ARM provider schema containing all resources and non-resource methods
 */
export function buildArmProviderSchema(
  sdkContext: CSharpEmitterContext,
  codeModel: CodeModel
): ArmProviderSchema {
  // Use the existing custom resource detection logic
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
  const resourceModelIds = new Set<string>(
    resourceModels.map((m) => m.crossLanguageDefinitionId)
  );

  // Track client names associated with each resource path for name derivation
  const resourcePathToClientName = new Map<string, string>();

  // Track explicit resource names from TypeSpec (e.g., from LegacyOperations ResourceName parameter)
  const resourcePathToExplicitName = new Map<string, string>();

  const nonResourceMethods: Map<string, NonResourceMethod> = new Map();

  // first we flatten all possible clients in the code model
  const clients = getAllClients(codeModel);

  // Process methods in two passes to ensure CRUD operations establish resource paths first
  // This allows non-CRUD operations (like List) to find existing resource paths regardless of operation order

  // Helper function to process a method and add it to the resource metadata
  // the method type uses any here because its real type `InputServiceMethod` is not exported by MTG's emitter
  const processMethod = (client: InputClient, method: any) => {
    const serviceMethod = serviceMethods.get(method.crossLanguageDefinitionId);
    const { kind, modelId, explicitResourceName } = parseResourceOperation(
      serviceMethod,
      sdkContext
    );

    if (modelId && kind && resourceModelIds.has(modelId)) {
      // Determine the resource path from the CRUD operation
      let resourcePath = "";
      let foundMatchingResource = false;
      if (isCRUDKind(kind)) {
        resourcePath = method.operation.path;
        foundMatchingResource = true;
      } else {
        // For non-CRUD operations like List or Action, try to match with existing resource paths for the same model
        const operationPath = method.operation.path;
        for (const [existingKey] of resourcePathToMetadataMap) {
          const [existingModelId, existingPath] = existingKey.split("|");
          // Check if this is for the same model
          if (existingModelId === modelId && existingPath) {
            // Try to match based on resource type segments
            // Extract the resource type part (after "/providers/")
            const existingResourceType =
              calculateResourceTypeFromPath(existingPath);
            let operationResourceType = "";
            try {
              operationResourceType =
                calculateResourceTypeFromPath(operationPath);
            } catch {
              // If we can't calculate resource type, try string matching
            }

            // If resource types match exactly, this list operation belongs to this resource
            if (
              existingResourceType &&
              operationResourceType === existingResourceType
            ) {
              resourcePath = existingPath;
              foundMatchingResource = true;
              break;
            }

            // Fallback: check if the operation path ends with a segment that matches the existing path
            // But only if we haven't found a better match yet
            if (!resourcePath) {
              const existingParentPath = existingPath.substring(
                0,
                existingPath.lastIndexOf("/")
              );
              if (isPrefix(existingParentPath, operationPath)) {
                // Store this as a potential match, but continue looking for exact matches
                resourcePath = existingPath;
                foundMatchingResource = true;
              }
            }
          }
        }
        // If no match found for Action operations that don't have a resource instance in their path,
        // treat them as non-resource methods (provider operations).
        // List operations are kept because they'll be handled later when moved to parent resources.
        if (!foundMatchingResource && kind === ResourceOperationKind.Action) {
          // Check if the operation path contains the resource type segment
          // by looking for the resource model name in the path
          const model = resourceModelMap.get(modelId);
          const resourceTypeName = model?.name?.toLowerCase();
          const pathLower = operationPath.toLowerCase();
          
          // If the path doesn't include the resource type segment (e.g., "scheduledactions"),
          // it's a provider operation, not a resource action
          if (resourceTypeName && !pathLower.includes(resourceTypeName)) {
            nonResourceMethods.set(method.crossLanguageDefinitionId, {
              methodId: method.crossLanguageDefinitionId,
              operationPath: method.operation.path,
              operationScope: getOperationScopeFromPath(method.operation.path)
            });
            return;
          }
        }
        // If no match found, use the operation path
        // This is used for List operations on resources without CRUD ops,
        // which will be handled later in buildArmProviderSchemaFromDetectedResources
        if (!resourcePath) {
          resourcePath = operationPath;
        }
      }

      // Create a unique key combining model ID and resource path
      const metadataKey = `${modelId}|${resourcePath}`;

      // Store explicit resource name if provided (from LegacyOperations ResourceName parameter)
      if (
        explicitResourceName &&
        !resourcePathToExplicitName.has(metadataKey)
      ) {
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
        operationScope: getOperationScopeFromPath(method.operation.path)
      });
      if (!entry.resourceType) {
        entry.resourceType = calculateResourceTypeFromPath(
          method.operation.path
        );
      }
      if (!entry.resourceIdPattern && isCRUDKind(kind)) {
        entry.resourceIdPattern = method.operation.path;
      }
    } else {
      // we treat this method as a non-resource method when it does not have a kind or an associated resource model
      nonResourceMethods.set(method.crossLanguageDefinitionId, {
        methodId: method.crossLanguageDefinitionId,
        operationPath: method.operation.path,
        operationScope: getOperationScopeFromPath(method.operation.path)
      });
    }
  };

  // First pass: Process CRUD operations to establish resource paths
  for (const client of clients) {
    for (const method of client.methods) {
      const serviceMethod = serviceMethods.get(
        method.crossLanguageDefinitionId
      );
      const { kind } = parseResourceOperation(serviceMethod, sdkContext);

      // Only process CRUD operations in the first pass
      if (kind && isCRUDKind(kind)) {
        processMethod(client, method);
      }
    }
  }

  // Second pass: Process non-CRUD operations (like List) which can now find existing resource paths
  for (const client of clients) {
    for (const method of client.methods) {
      const serviceMethod = serviceMethods.get(
        method.crossLanguageDefinitionId
      );
      const { kind } = parseResourceOperation(serviceMethod, sdkContext);

      // Only process non-CRUD operations in the second pass
      if (kind && !isCRUDKind(kind)) {
        processMethod(client, method);
      } else if (!kind) {
        // Process methods without a kind in the second pass
        processMethod(client, method);
      }
    }
  }

  // after the resourceIdPattern has been populated, we can set the parentResourceId and the resource scope of each resource method
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    // Extract model ID from the key (format: "modelId|resourcePath")
    const modelId = metadataKey.split("|")[0];

    // get parent resource model id
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      // Find parent metadata entry - there might be multiple, so we need to find the right one
      for (const [parentKey, parentMetadata] of resourcePathToMetadataMap) {
        const parentModelId = parentKey.split("|")[0];
        if (
          parentModelId === parentResourceModelId &&
          parentMetadata.resourceIdPattern
        ) {
          metadata.parentResourceId = parentMetadata.resourceIdPattern;
          metadata.parentResourceModelId = parentResourceModelId;
          break;
        }
      }
    }

    // For multiple-path resources (same model at different paths), detect parent-child relationships through path matching
    // This is needed when both parent and child use the same model (e.g., legacy-operations pattern)
    if (!metadata.parentResourceId && metadata.resourceIdPattern) {
      // Check if this resource's path is a child of another resource's path
      for (const [otherKey, otherMetadata] of resourcePathToMetadataMap) {
        if (otherKey !== metadataKey && otherMetadata.resourceIdPattern) {
          // Check if this resource's path starts with the other resource's path
          // e.g., "/providers/MgmtTypeSpec/bestPractices/{name}/versions/{versionName}"
          // is a child of "/providers/MgmtTypeSpec/bestPractices/{name}"
          const thisPath = metadata.resourceIdPattern;
          const potentialParentPath = otherMetadata.resourceIdPattern;

          // The child path should start with the parent path followed by a "/"
          if (
            isPrefix(potentialParentPath, thisPath) &&
            !isPrefix(thisPath, potentialParentPath)
          ) {
            metadata.parentResourceId = potentialParentPath;
            // Note: we don't set parentResourceModelId here since they share the same model
            break;
          }
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

    // update the model's resourceScope based on resource scope decorator if it exists or based on the Read method's scope. If neither exist, it will be set to ResourceGroup by default
    const model = resourceModelMap.get(modelId);
    if (model) {
      metadata.resourceScope = getResourceScope(model, metadata.methods);
    }
  }

  // after the parentResourceId and resource scopes are populated, we can reorganize the metadata that is missing resourceIdPattern
  const metadataKeysToDelete: string[] = [];
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split("|")[0];

    // If this entry has no resourceIdPattern, try to merge it with another entry for the same model that does
    if (metadata.resourceIdPattern === "") {
      let merged = false;

      // First try to merge with parent if it exists
      if (metadata.parentResourceModelId) {
        for (const [parentKey, parentMetadata] of resourcePathToMetadataMap) {
          const parentModelId = parentKey.split("|")[0];
          if (
            parentModelId === metadata.parentResourceModelId &&
            parentMetadata.resourceIdPattern
          ) {
            parentMetadata.methods.push(...metadata.methods);
            metadataKeysToDelete.push(metadataKey);
            merged = true;
            break;
          }
        }
      } else {
        // No parent - try to find another entry for the same model with a resourceIdPattern
        for (const [otherKey, otherMetadata] of resourcePathToMetadataMap) {
          const otherModelId = otherKey.split("|")[0];
          if (
            otherKey !== metadataKey &&
            otherModelId === modelId &&
            otherMetadata.resourceIdPattern
          ) {
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
    const modelId = metadataKey.split("|")[0];
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
        const keyModelId = metadataKey.split("|")[0];
        if (keyModelId === modelId) {
          // Prioritize explicit resource name from TypeSpec (e.g., LegacyOperations ResourceName parameter)
          const explicitName = resourcePathToExplicitName.get(metadataKey);
          if (explicitName) {
            metadata.resourceName = explicitName;
          } else {
            // Fallback: derive from client name using pluralize.singular
            const clientName = resourcePathToClientName.get(metadataKey);
            if (clientName) {
              metadata.resourceName = pluralize.singular(clientName);
            }
          }
        }
      }
    }
    // If there's only one metadata entry for this model, keep using the model name (already set)
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
    ResourceOperationKind.Read,
    ResourceOperationKind.Create,
    ResourceOperationKind.Update,
    ResourceOperationKind.Delete
  ].includes(kind);
}

function parseResourceOperation(
  serviceMethod: SdkMethod<SdkHttpOperation> | undefined,
  sdkContext: CSharpEmitterContext
): {
  kind?: ResourceOperationKind;
  modelId?: string;
  explicitResourceName?: string;
} {
  const decorators = serviceMethod?.__raw?.decorators;
  for (const decorator of decorators ?? []) {
    switch (decorator.definition?.name) {
      case readsResourceName:
      case armResourceReadName:
        return {
          kind: ResourceOperationKind.Read,
          modelId: getResourceModelId(sdkContext, decorator),
          explicitResourceName: undefined // No explicit resource name for ARM operations
        };
      case armResourceCreateOrUpdateName:
        return {
          kind: ResourceOperationKind.Create,
          modelId: getResourceModelId(sdkContext, decorator),
          explicitResourceName: undefined
        };
      case armResourceUpdateName:
        return {
          kind: ResourceOperationKind.Update,
          modelId: getResourceModelId(sdkContext, decorator),
          explicitResourceName: undefined
        };
      case armResourceDeleteName:
        return {
          kind: ResourceOperationKind.Delete,
          modelId: getResourceModelId(sdkContext, decorator),
          explicitResourceName: undefined
        };
      case armResourceListName:
        return {
          kind: ResourceOperationKind.List,
          modelId: getResourceModelId(sdkContext, decorator),
          explicitResourceName: undefined
        };
      case armResourceActionName:
        return {
          kind: ResourceOperationKind.Action,
          modelId: getResourceModelId(sdkContext, decorator),
          explicitResourceName: undefined
        };
      case extensionResourceOperationName:
        switch (decorator.args[2].jsValue) {
          case "read":
            return {
              kind: ResourceOperationKind.Read,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "createOrUpdate":
            return {
              kind: ResourceOperationKind.Create,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "update":
            return {
              kind: ResourceOperationKind.Update,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "delete":
            return {
              kind: ResourceOperationKind.Delete,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "list":
            return {
              kind: ResourceOperationKind.List,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "action":
            return {
              kind: ResourceOperationKind.Action,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
        }
        break;
      case legacyExtensionResourceOperationName:
      case legacyResourceOperationName:
        switch (decorator.args[1].jsValue) {
          case "read":
            return {
              kind: ResourceOperationKind.Read,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              // Extract the explicit resource name if available (4th parameter in LegacyOperations)
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
            };
          case "createOrUpdate":
            return {
              kind: ResourceOperationKind.Create,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
            };
          case "update":
            return {
              kind: ResourceOperationKind.Update,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
            };
          case "delete":
            return {
              kind: ResourceOperationKind.Delete,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
            };
          case "list":
            return {
              kind: ResourceOperationKind.List,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
            };
          case "action":
            return {
              kind: ResourceOperationKind.Action,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
            };
        }
        return {};
      case builtInResourceOperationName:
        switch (decorator.args[2].jsValue) {
          case "read":
            return {
              kind: ResourceOperationKind.Read,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "createOrUpdate":
            return {
              kind: ResourceOperationKind.Create,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "update":
            return {
              kind: ResourceOperationKind.Update,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "delete":
            return {
              kind: ResourceOperationKind.Delete,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "list":
            return {
              kind: ResourceOperationKind.List,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
          case "action":
            return {
              kind: ResourceOperationKind.Action,
              modelId: getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName: undefined
            };
        }
        return {};
    }
  }
  return {};
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

export function getAllClients(codeModel: CodeModel): InputClient[] {
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client, clients);
  }

  return clients;
}

function getAllResourceModels(codeModel: CodeModel): InputModelType[] {
  const resourceModels: InputModelType[] = [];
  for (const model of codeModel.models) {
    if (
      model.decorators?.some(
        (d) =>
          d.name == armResourceInternal || d.name == armResourceWithParameter
      )
    ) {
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

  // Fall back to Read method's scope only if no scope decorators are found
  if (methods) {
    const getMethod = methods.find(
      (m) => m.kind === ResourceOperationKind.Read
    );
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
      isPrefix(otherMetadata.resourceIdPattern, path)
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
 * Applies the ARM provider schema as a decorator to the root client.
 * @param codeModel - The code model to update
 * @param schema - The ARM provider schema to apply
 */
function applyArmProviderSchemaDecorator(
  codeModel: CodeModel,
  schema: ArmProviderSchema
): void {
  // It's technically allowed to have no clients, so we just return early in that case
  if (!codeModel.clients || codeModel.clients.length === 0) {
    return;
  }
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
    const modelId = metadataKey.split("|")[0];
    if (!modelIdToMetadataList.has(modelId)) {
      modelIdToMetadataList.set(modelId, []);
    }
    modelIdToMetadataList.get(modelId)!.push(metadata);
  }

  // Create resource schemas
  for (const model of resourceModels) {
    const metadataList = modelIdToMetadataList.get(
      model.crossLanguageDefinitionId
    );
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

        // Filter out resources without Get/Read operations (non-singleton resources only)
        // Singleton resources can exist without Get operations
        const hasReadOperation = metadata.methods.some(
          (m) => m.kind === ResourceOperationKind.Read
        );
        if (!hasReadOperation && !metadata.singletonResourceName) {
          // For resources without Get operation, List operations should belong to the parent resource
          // Other operations (Create, Update, Delete) should be treated as non-resource methods
          
          // Iterate through all methods and handle List operations separately
          for (const method of metadata.methods) {
            if (method.kind === ResourceOperationKind.List) {
              // Move List operations to parent resource if parent exists
              let parentMetadata: ResourceMetadata | undefined;
              if (metadata.parentResourceModelId) {
                for (const [parentKey, parentMeta] of resourcePathToMetadataMap) {
                  const parentModelId = parentKey.split("|")[0];
                  if (parentModelId === metadata.parentResourceModelId) {
                    parentMetadata = parentMeta;
                    break;
                  }
                }
              }

              if (parentMetadata) {
                parentMetadata.methods.push(method);
                continue; // Skip to next method, don't add to nonResourceMethods
              }
            }

            // Move methods to non-resource methods if not added to parent
            nonResourceMethods.set(method.methodId, {
              methodId: method.methodId,
              operationPath: method.operationPath,
              operationScope: method.operationScope
            });
          }

          sdkContext.logger.reportDiagnostic({
            code: "general-warning",
            messageId: "default",
            format: {
              message: `Resource ${model.name} does not have a Get/Read operation and is not a singleton. List operations will be added to parent resource, other operations will be treated as non-resource methods.`
            },
            target: NoTarget
          });
          continue;
        }

        // Sort methods by kind (CRUD, List, Action) and then by methodId for deterministic ordering
        sortResourceMethods(metadata.methods);

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

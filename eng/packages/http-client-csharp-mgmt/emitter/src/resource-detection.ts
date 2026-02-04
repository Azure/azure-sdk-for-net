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
  postProcessArmResources,
  ParentResourceLookupContext
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
        // Collect all matching candidates with resource type match
        const typeMatchCandidates: Array<{
          existingPath: string;
        }> = [];
        // Collect candidates with both resource type and prefix match (scored by prefix length)
        const prefixMatchCandidates: Array<{
          existingPath: string;
          matchScore: number;
        }> = [];

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

            // If resource types match exactly, this is a potential candidate
            if (
              existingResourceType &&
              operationResourceType === existingResourceType
            ) {
              // Add to type match candidates
              typeMatchCandidates.push({ existingPath });
            }

            // Also check for prefix match as a fallback
            // The resource path without the last segment (resource name parameter) should be a prefix of the operation path
            const existingParentPath = existingPath.substring(
              0,
              existingPath.lastIndexOf("/")
            );
            if (isPrefix(existingParentPath, operationPath)) {
              // Score based on how many segments match (longer prefix = better match)
              const score = existingParentPath
                .split("/")
                .filter((s) => s.length > 0).length;
              prefixMatchCandidates.push({ existingPath, matchScore: score });
            }
          }
        }

        // Selection strategy:
        // 1. If there are prefix matches, use the best one (handles multi-scope resources correctly)
        // 2. If there's only ONE type match candidate and no prefix matches, use it
        //    (handles listBySubscription on a single resource group-scoped resource)
        // 3. Otherwise, no match found - will be handled by post-processing
        if (prefixMatchCandidates.length > 0) {
          prefixMatchCandidates.sort((a, b) => b.matchScore - a.matchScore);
          resourcePath = prefixMatchCandidates[0].existingPath;
          foundMatchingResource = true;
        } else if (typeMatchCandidates.length === 1) {
          // Only one resource with matching type - safe to use it even without prefix match
          // This handles cases like listBySubscription on a resource group-scoped resource
          resourcePath = typeMatchCandidates[0].existingPath;
          foundMatchingResource = true;
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
        // which will be handled later during post-processing
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

  // Convert metadata map to ArmResourceSchema[] for post-processing
  const resources: ArmResourceSchema[] = [];
  const metadataKeyToResource = new Map<string, ArmResourceSchema>();

  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split("|")[0];
    const model = resourceModelMap.get(modelId);

    // Emit diagnostic for resources without resourceIdPattern
    if (metadata.resourceIdPattern === "" && model) {
      sdkContext.logger.reportDiagnostic({
        code: "general-warning",
        messageId: "default",
        format: {
          message: `Cannot figure out resourceIdPattern from model ${model.name}.`
        },
        target: NoTarget
      });
    }

    const resource: ArmResourceSchema = {
      resourceModelId: modelId,
      metadata: metadata
    };
    resources.push(resource);
    metadataKeyToResource.set(metadataKey, resource);
  }

  // Populate parentResourceModelId from decorators BEFORE calling shared post-processing
  // This is specific to legacy resource detection
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split("|")[0];
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      metadata.parentResourceModelId = parentResourceModelId;
    }
  }

  // For multiple-path resources (same model at different paths), detect parent-child relationships through path matching
  // This is needed when both parent and child use the same model (e.g., legacy-operations pattern)
  // This is also specific to legacy resource detection
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    if (!metadata.parentResourceId && metadata.resourceIdPattern) {
      // Check if this resource's path is a child of another resource's path
      for (const [otherKey, otherMetadata] of resourcePathToMetadataMap) {
        if (otherKey !== metadataKey && otherMetadata.resourceIdPattern) {
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
  }

  // Update the model's resourceScope based on resource scope decorator if it exists or based on the Read method's scope.
  // This is specific to legacy resource detection
  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split("|")[0];
    const model = resourceModelMap.get(modelId);
    if (model) {
      metadata.resourceScope = getResourceScope(model, metadata.methods);
    }
  }

  // Create parent lookup context for legacy resource detection
  // In this case, parent information comes from decorators and path matching (already populated above)
  const parentLookup: ParentResourceLookupContext = {
    getParentResource: (
      resource: ArmResourceSchema
    ): ArmResourceSchema | undefined => {
      const parentModelId = resource.metadata.parentResourceModelId;
      if (!parentModelId) return undefined;

      // Find parent resource with matching model ID and a valid resourceIdPattern
      for (const r of resources) {
        if (
          r.resourceModelId === parentModelId &&
          r.metadata.resourceIdPattern
        ) {
          return r;
        }
      }
      return undefined;
    }
  };

  // Convert non-resource methods map to array
  const nonResourceMethodsArray: NonResourceMethod[] = Array.from(
    nonResourceMethods.values()
  );

  // Track resources before post-processing to emit diagnostics for filtered resources
  const resourcesBeforeFiltering = new Set(
    resources.filter((r) => r.metadata.resourceIdPattern !== "")
  );

  // Use the shared post-processing function
  const filteredResources = postProcessArmResources(
    resources,
    nonResourceMethodsArray,
    parentLookup
  );

  // Emit diagnostics for resources that were filtered out (non-singleton resources without Read operations)
  const resourcesAfterFiltering = new Set(filteredResources);
  for (const resource of resourcesBeforeFiltering) {
    if (!resourcesAfterFiltering.has(resource)) {
      const model = resourceModelMap.get(resource.resourceModelId);
      if (model) {
        sdkContext.logger.reportDiagnostic({
          code: "general-warning",
          messageId: "default",
          format: {
            message: `Resource ${model.name} does not have a Get/Read operation and is not a singleton. All operations will be added to parent resource if available, otherwise treated as non-resource methods.`
          },
          target: NoTarget
        });
      }
    }
  }

  // Update resource names: prioritize explicit ResourceName from TypeSpec, fallback to deriving from client names
  // This handles the scenario where the same model is used by multiple resource interfaces with different paths.
  // TypeSpec authors should specify explicit ResourceName parameters in LegacyOperations templates.
  const modelIdToResources = new Map<string, ArmResourceSchema[]>();
  for (const resource of filteredResources) {
    if (!modelIdToResources.has(resource.resourceModelId)) {
      modelIdToResources.set(resource.resourceModelId, []);
    }
    modelIdToResources.get(resource.resourceModelId)!.push(resource);
  }

  for (const [, resourceList] of modelIdToResources) {
    if (resourceList.length > 1) {
      // Multiple resource paths for the same model - use explicit names or derive from client names
      for (const resource of resourceList) {
        // Use the metadataKeyToResource map to efficiently find the metadata key
        // Look for the metadataKey that corresponds to this resource
        for (const [metadataKey, mappedResource] of metadataKeyToResource) {
          if (mappedResource === resource) {
            // Prioritize explicit resource name from TypeSpec (e.g., LegacyOperations ResourceName parameter)
            const explicitName = resourcePathToExplicitName.get(metadataKey);
            if (explicitName) {
              resource.metadata.resourceName = explicitName;
            } else {
              // Fallback: derive from client name using pluralize.singular
              const clientName = resourcePathToClientName.get(metadataKey);
              if (clientName) {
                resource.metadata.resourceName = pluralize.singular(clientName);
              }
            }
            break;
          }
        }
      }
    }
    // If there's only one resource for this model, keep using the model name (already set)
  }

  return {
    resources: filteredResources,
    nonResourceMethods: nonResourceMethodsArray
  };
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

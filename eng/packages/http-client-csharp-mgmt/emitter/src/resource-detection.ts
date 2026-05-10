// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  CSharpEmitterContext,
  InputClient,
  InputModelType
} from "@typespec/http-client-csharp";
import {
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
  ResourceOperationKind,
  ResourceScopeKind,
  ArmScopeInfo,
  ArmProviderSchema,
  ArmResourceSchema,
  convertArmProviderSchemaToArguments,
  expandArmResources,
  postProcessArmResources,
  ParentResourceLookupContext,
  assignNonResourceMethodsToResources,
  resolveResourceApiVersions,
  extractRbacRoles,
  findLongestPrefixMatch,
  RequestPath,
  extractNameConstraintOverrides,
  isResourceIdPatternPrefixMatch
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
  customAzureResource,
  extensionResourceOperationName,
  legacyExtensionResourceOperationName,
  legacyResourceOperationName,
  builtInResourceOperationName,
  parentResourceName,
  readsResourceName,
  singleton
} from "./sdk-context-options.js";
import {
  DecoratorApplication,
  Model,
  NoTarget,
  getPattern,
  getMinLength,
  getMaxLength
} from "@typespec/compiler";
import { resolveArmResources } from "./resolve-arm-resources-converter.js";
import { AzureMgmtEmitterOptions } from "./options.js";
import { getAllSdkClients, traverseClient } from "./sdk-client-utils.js";

export async function updateClients(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext,
  options: AzureMgmtEmitterOptions
) {
  let armProviderSchema: ArmProviderSchema;

  if (options?.["use-legacy-resource-detection"] === false) {
    armProviderSchema = resolveArmResources(sdkContext.program, sdkContext);
  } else {
    armProviderSchema = buildArmProviderSchema(sdkContext, codeModel);
  }

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

  // Build a lookup map from methodId to the page item type's crossLanguageDefinitionId
  // so that relocateCrossResourceListActions can verify type compatibility
  const methodResponseModelIdMap = new Map<string, string>();
  for (const [methodId, method] of serviceMethods) {
    const itemModelId = getPagingItemModelId(method);
    if (itemModelId) {
      methodResponseModelIdMap.set(methodId, itemModelId);
    }
  }

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
      sdkContext,
      resourceModelIds
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
        // Collect existing paths for the same model (for prefix matching)
        const existingPathsForModel: string[] = [];

        for (const [existingKey] of resourcePathToMetadataMap) {
          const [existingModelId, existingPath] = existingKey.split("|");
          // Check if this is for the same model
          if (existingModelId === modelId && existingPath) {
            existingPathsForModel.push(existingPath);

            // Try to match based on resource type segments
            // Extract the resource type part (after "/providers/")
            const existingReqPath = new RequestPath(existingPath);
            const operationReqPath = new RequestPath(operationPath);
            // Only compare resource types when both paths have a determinable resource type
            if (
              existingReqPath.resourceType !== undefined &&
              operationReqPath.resourceType !== undefined &&
              existingReqPath.resourceType === operationReqPath.resourceType
            ) {
              typeMatchCandidates.push({ existingPath });
            }
          }
        }

        // Find the best prefix match using the utility
        const bestPrefixMatch = findLongestPrefixMatch(
          new RequestPath(operationPath),
          existingPathsForModel,
          (path) => new RequestPath(path).trimLastSegment
        );

        // Selection strategy:
        // 1. If there are prefix matches, use the best one (handles multi-scope resources correctly)
        // 2. If there's only ONE type match candidate and no prefix matches, use it
        //    (handles listBySubscription on a single resource group-scoped resource)
        // 3. Otherwise, no match found - will be handled by post-processing
        if (bestPrefixMatch) {
          resourcePath = bestPrefixMatch;
          foundMatchingResource = true;
        } else if (typeMatchCandidates.length === 1) {
          // Only one resource with matching type - safe to use it even without prefix match
          // This handles cases like listBySubscription on a resource group-scoped resource.
          // BUT: if the operation has an explicitResourceName, it belongs to a different resource
          // interface (e.g., PublicSharedConfig vs SharedConfig) and should NOT be merged into
          // the type-matched resource. Let it fall through to create its own metadata entry.
          if (!explicitResourceName) {
            resourcePath = typeMatchCandidates[0].existingPath;
            foundMatchingResource = true;
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

          // If the path doesn't include the resource type segment (e.g., "scheduledactions"),
          // it's a provider operation, not a resource action
          const opPath = new RequestPath(operationPath);
          const hasResourceTypeSegment =
            resourceTypeName &&
            opPath.segments.some((s) => s.toLowerCase() === resourceTypeName);
          if (resourceTypeName && !hasResourceTypeSegment) {
            nonResourceMethods.set(method.crossLanguageDefinitionId, {
              methodId: method.crossLanguageDefinitionId,
              operationPath: opPath,
              scope: buildScopeInfoFromPath(opPath)
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
      // Only store for CRUD operations where the resource path IS the operation path.
      // For non-CRUD operations (like List) that match an existing resource via type matching,
      // the explicit name comes from the matched operation's interface, which may differ from
      // the resource's own interface when two interfaces share the same model.
      if (
        explicitResourceName &&
        isCRUDKind(kind) &&
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
          resourceIdPattern: undefined, // this will be populated later
          resourceType: "", // this will be populated later
          singletonResourceName: getSingletonResource(
            model?.decorators?.find((d) => d.name == singleton)
          ),
          scope: {
            kind: ResourceScopeKind.Tenant,
            scopeIdPattern: RequestPath.empty
          }, // temporary default, will be properly set later
          methods: [],
          parentResourceId: undefined, // this will be populated later
          parentResourceModelId: undefined,
          // Use model name as default; will be updated later if multiple paths exist
          resourceName: model?.name ?? "Unknown",
          nameConstraints: {},
          apiVersions: [],
          rbacRoles: []
        } as ResourceMetadata;
        resourcePathToMetadataMap.set(metadataKey, entry);
      }

      const opPath = new RequestPath(method.operation.path);
      entry.methods.push({
        methodId: method.crossLanguageDefinitionId,
        kind,
        operationPath: opPath,
        scope: buildScopeInfoFromPath(opPath)
      });
      if (!entry.resourceType && opPath.resourceType) {
        entry.resourceType = opPath.resourceType;
      }
      if (!entry.resourceIdPattern && isCRUDKind(kind)) {
        entry.resourceIdPattern = opPath;
      }
    } else {
      // we treat this method as a non-resource method when it does not have a kind or an associated resource model
      const operationPath = new RequestPath(method.operation.path);
      nonResourceMethods.set(method.crossLanguageDefinitionId, {
        methodId: method.crossLanguageDefinitionId,
        operationPath: operationPath,
        scope: buildScopeInfoFromPath(operationPath)
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

  for (const [metadataKey, metadata] of resourcePathToMetadataMap) {
    const modelId = metadataKey.split("|")[0];
    const model = resourceModelMap.get(modelId);

    // Emit diagnostic for resources without resourceIdPattern
    if (metadata.resourceIdPattern === undefined && model) {
      sdkContext.program.reportDiagnostic({
        code: "general-warning",
        severity: "warning",
        message: `Cannot figure out resourceIdPattern from model ${model.name}.`,
        target: NoTarget
      });
    }

    const resource: ArmResourceSchema = {
      resourceModelId: modelId,
      metadata: metadata
    };
    resources.push(resource);
  }

  // Populate parentResourceModelId from decorators BEFORE calling shared post-processing
  // This is specific to legacy resource detection
  for (const resource of resources) {
    const modelId = resource.resourceModelId;
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      resource.metadata.parentResourceModelId = parentResourceModelId;
    }
  }

  // Convert non-resource methods map to array
  const nonResourceMethodsArray: NonResourceMethod[] = Array.from(
    nonResourceMethods.values()
  );

  // Step 1: expand resources with dynamic parent type segments before any
  // path-based parent inference runs, so the inference sees concrete paths.
  const reportWarning = (message: string) =>
    sdkContext.program.reportDiagnostic({
      code: "general-warning",
      severity: "warning",
      message,
      target: NoTarget
    });
  const { expandedResources } = expandArmResources(resources, {
    serviceMethods,
    diagnosticReporter: reportWarning
  });

  // Step 2: legacy-only mutations on the post-expansion list — path-based
  // parent matching for resources that share a model and resource scope
  // assignment based on either the scope decorator or the Read method.
  inferLegacyParentsFromPaths(expandedResources);
  assignLegacyResourceScopes(expandedResources);

  // Step 3: build the parent-lookup context. The legacy path resolves parents
  // via the @parentResourceModelId decorator that was populated above.
  const parentLookup = buildLegacyParentLookup(expandedResources);

  // Step 4: shared post-processing.
  const filteredResources = postProcessArmResources(
    expandedResources,
    nonResourceMethodsArray,
    parentLookup,
    { methodResponseModelIdMap }
  );

  // Emit diagnostics for resources that were filtered out (non-singleton resources without Read operations)
  const resourcesAfterFiltering: Set<ArmResourceSchema> = new Set(
    filteredResources
  );
  for (const resource of expandedResources) {
    if (
      resource.metadata.resourceIdPattern !== undefined &&
      !resourcesAfterFiltering.has(resource)
    ) {
      const model = resourceModelMap.get(resource.resourceModelId);
      if (model) {
        sdkContext.program.reportDiagnostic({
          code: "general-warning",
          severity: "warning",
          message: `Resource ${model.name} does not have a Get/Read operation and is not a singleton. All operations will be added to parent resource if available, otherwise treated as non-resource methods.`,
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
        const metadataKey = `${resource.resourceModelId}|${resource.metadata.resourceIdPattern?.path ?? ""}`;
        // Prioritize explicit resource name from TypeSpec (e.g., LegacyOperations ResourceName parameter)
        const explicitName = resourcePathToExplicitName.get(metadataKey);
        if (explicitName) {
          resource.metadata.resourceName = explicitName;
        } else {
          // Try to derive from client name using pluralize.singular
          const clientName = resourcePathToClientName.get(metadataKey);
          if (clientName) {
            resource.metadata.resourceName = pluralize.singular(clientName);
          }
        }
      }
    }
    // If there's only one resource for this model, keep using the model name (already set)
  }

  for (const resource of filteredResources) {
    const sdkModel = models.get(resource.resourceModelId);
    const typespecModel = sdkModel?.__raw as Model | undefined;
    const nameProperty = typespecModel?.properties.get("name");
    const rawPattern = nameProperty
      ? getPattern(sdkContext.program, nameProperty)
      : undefined;
    resource.metadata.nameConstraints = {
      pattern: rawPattern || undefined,
      minLength: nameProperty
        ? getMinLength(sdkContext.program, nameProperty)
        : undefined,
      maxLength: nameProperty
        ? getMaxLength(sdkContext.program, nameProperty)
        : undefined
    };

    // Override name constraints from @@clientOption decorator if present
    const nameConstraintOverrides = extractNameConstraintOverrides(sdkModel);
    if (nameConstraintOverrides) {
      resource.metadata.nameConstraints = {
        pattern:
          nameConstraintOverrides.pattern ??
          resource.metadata.nameConstraints.pattern,
        minLength:
          nameConstraintOverrides.minLength ??
          resource.metadata.nameConstraints.minLength,
        maxLength:
          nameConstraintOverrides.maxLength ??
          resource.metadata.nameConstraints.maxLength
      };
    }

    // Extract RBAC roles from @@clientOption decorator
    resource.metadata.rbacRoles = extractRbacRoles(sdkModel);
  }

  // Assign non-resource methods to resources based on operationPath prefix matching.
  // If a non-resource method's path has a prefix matching a resource's resourceIdPattern,
  // move it into that resource as an Action (longest prefix wins).
  assignNonResourceMethodsToResources(
    filteredResources,
    nonResourceMethodsArray
  );

  // Compute per-resource API versions after all post-processing is complete,
  // so that merged/moved methods are reflected in the final version set.
  for (const resource of filteredResources) {
    resource.metadata.apiVersions = resolveResourceApiVersions(
      resource.metadata.methods,
      serviceMethods
    );
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
  sdkContext: CSharpEmitterContext,
  resourceModelIds?: Set<string>
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
          // When the decorator is @armResourceCreateOrUpdate but the HTTP verb is PATCH,
          // classify as Update. This handles cases like Legacy.CreateOrReplaceAsync used
          // with @patch override, where the template still produces @armResourceCreateOrUpdate
          // but the operation is semantically an update.
          kind:
            serviceMethod?.operation?.verb === "patch"
              ? ResourceOperationKind.Update
              : ResourceOperationKind.Create,
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
          // If the operation is pageable AND its response item type is a known
          // resource model, it's a list-children operation (e.g., blobContainersList
          // modeled as ArmResourceActionSync but returning paged Container resources).
          // If the item type is NOT a resource model (e.g., metadata), keep it as Action.
          kind: isPagingActionListingResources(serviceMethod, resourceModelIds)
            ? ResourceOperationKind.List
            : ResourceOperationKind.Action,
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
                decorator.args[1].value as Model,
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
                decorator.args[1].value as Model,
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
                decorator.args[1].value as Model,
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
                decorator.args[1].value as Model,
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
                decorator.args[1].value as Model,
                decorator.definition?.name
              ),
              explicitResourceName:
                decorator.args.length > 3
                  ? (decorator.args[3].jsValue as string)
                  : undefined
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
              // Extract the explicit resource name if available (3rd parameter: Resource, kind, ResourceName)
              explicitResourceName:
                decorator.args.length > 2
                  ? (decorator.args[2].jsValue as string)
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
                decorator.args.length > 2
                  ? (decorator.args[2].jsValue as string)
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
                decorator.args.length > 2
                  ? (decorator.args[2].jsValue as string)
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
                decorator.args.length > 2
                  ? (decorator.args[2].jsValue as string)
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
                decorator.args.length > 2
                  ? (decorator.args[2].jsValue as string)
                  : undefined
            };
          case "action": {
            const modelId = getResourceModelIdCore(
              sdkContext,
              decorator.args[0].value as Model,
              decorator.definition?.name
            );
            // When RoutedOperations.ActionSync/ActionAsync is used with an HTTP verb override
            // (e.g., @get, @put, @delete instead of the default @post), reclassify the operation
            // based on the actual HTTP verb and response shape. This is needed because
            // RoutedOperations does not provide Read/Get templates, so services sometimes
            // use ActionSync with @get for actual reads. If the response does not match the
            // resource model, we keep it as Action.
            return {
              kind: reclassifyLegacyAction(
                serviceMethod,
                modelId,
                resourceModelIds
              ),
              modelId,
              explicitResourceName:
                decorator.args.length > 2
                  ? (decorator.args[2].jsValue as string)
                  : undefined
            };
          }
        }
        return {};
      case builtInResourceOperationName: {
        // @builtInResourceOperation parameters: (ParentResource, BuiltInResource, kind, ResourceName?)
        let builtInKind: ResourceOperationKind | undefined;
        switch (decorator.args[2].jsValue) {
          case "read":
            builtInKind = ResourceOperationKind.Read;
            break;
          case "createOrUpdate":
            builtInKind = ResourceOperationKind.Create;
            break;
          case "update":
            builtInKind = ResourceOperationKind.Update;
            break;
          case "delete":
            builtInKind = ResourceOperationKind.Delete;
            break;
          case "list":
            builtInKind = ResourceOperationKind.List;
            break;
          case "action":
            builtInKind = ResourceOperationKind.Action;
            break;
        }
        if (!builtInKind) {
          return {};
        }

        // Check if a Read operation has been overridden with action semantics
        // (e.g., a Read template reused with @action/@post decorators for reconcile operations)
        if (
          builtInKind === ResourceOperationKind.Read &&
          hasActionDecorator(decorators)
        ) {
          builtInKind = ResourceOperationKind.Action;
        }

        // Extract explicit resource name from optional 4th argument
        const builtInExplicitResourceName =
          decorator.args.length > 3
            ? (decorator.args[3].jsValue as string)
            : undefined;

        return {
          kind: builtInKind,
          modelId: getResourceModelIdCore(
            sdkContext,
            decorator.args[1].value as Model,
            decorator.definition?.name
          ),
          explicitResourceName: builtInExplicitResourceName
        };
      }
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

/**
 * Checks if an operation's decorators include @action from @typespec/rest,
 * which indicates the operation has been overridden with action semantics
 * (e.g., a Read template reused with @post @action("reconcile")).
 */
function hasActionDecorator(
  decorators: readonly DecoratorApplication[] | undefined
): boolean {
  return decorators?.some((d) => d.definition?.name === "@action") ?? false;
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

/**
 * Extracts the page item model's crossLanguageDefinitionId from a paging method
 * using the method's response type (which is an array of the item type).
 * Returns undefined if the item type is not a model.
 */
function getPagingItemModelId(
  method: SdkMethod<SdkHttpOperation>
): string | undefined {
  if (method.kind !== "paging" && method.kind !== "lropaging") return undefined;
  const responseType = method.response?.type;
  if (
    responseType?.kind === "array" &&
    responseType.valueType.kind === "model"
  ) {
    return (responseType.valueType as SdkModelType).crossLanguageDefinitionId;
  }
  return undefined;
}

function getResponseModelId(
  method: SdkMethod<SdkHttpOperation> | undefined
): string | undefined {
  const responseType = method?.response?.type;
  return responseType?.kind === "model"
    ? (responseType as SdkModelType).crossLanguageDefinitionId
    : undefined;
}

function hasMatchingNonPathModelParameter(
  serviceMethod: SdkMethod<SdkHttpOperation> | undefined,
  resourceModelId?: string
): boolean {
  if (!serviceMethod?.operation || !resourceModelId) return false;
  return serviceMethod.operation.parameters.some((param) => {
    if (param.kind === "path") return false;
    return (
      param.type.kind === "model" &&
      (param.type as SdkModelType).crossLanguageDefinitionId === resourceModelId
    );
  });
}

/**
 * Checks whether a pageable action actually lists resource models.
 * Returns true only if the method is a paging method AND its page item type
 * matches a known resource model. This prevents metadata-returning pageable actions
 * (e.g., NginxDeployments_WafPolicyList returning WafPolicyMetadata) from being
 * misclassified as List operations.
 */
function isPagingActionListingResources(
  serviceMethod: SdkMethod<SdkHttpOperation> | undefined,
  resourceModelIds?: Set<string>
): boolean {
  if (!serviceMethod || !resourceModelIds) return false;
  const itemModelId = getPagingItemModelId(serviceMethod);
  return !!itemModelId && resourceModelIds.has(itemModelId);
}

/**
 * Reclassifies a legacy "action" operation based on the actual HTTP verb.
 *
 * RoutedOperations.ActionSync/ActionAsync use @legacyResourceOperation(Resource, "action")
 * even when the HTTP verb is overridden (e.g., @get instead of the default @post).
 * This function maps the HTTP verb to the correct operation kind when the
 * response shape proves the operation is really CRUD/list:
 * - GET + pageable + resource-list response → List
 * - GET + matching resource response → Read
 * - PUT + matching resource payload/response → Create
 * - PATCH + matching resource payload/response → Update
 * - DELETE + resource/void response → Delete
 * - POST, mismatched CRUD verb, or unknown → Action (unchanged)
 */
function reclassifyLegacyAction(
  serviceMethod: SdkMethod<SdkHttpOperation> | undefined,
  resourceModelId?: string,
  resourceModelIds?: Set<string>
): ResourceOperationKind {
  const verb = serviceMethod?.operation?.verb;
  const responseModelId = getResponseModelId(serviceMethod);
  const responseMatchesResource =
    !!resourceModelId &&
    !!responseModelId &&
    responseModelId === resourceModelId;
  // PUT/PATCH typically take the resource model as the request body, so accept
  // either a matching response or a matching non-path model parameter.
  const bodyOrResponseMatchesResource =
    responseMatchesResource ||
    hasMatchingNonPathModelParameter(serviceMethod, resourceModelId);

  switch (verb) {
    case "get":
      // A GET that is pageable and returns resource models is a List operation
      if (isPagingActionListingResources(serviceMethod, resourceModelIds)) {
        return ResourceOperationKind.List;
      }
      return responseMatchesResource
        ? ResourceOperationKind.Read
        : ResourceOperationKind.Action;
    case "put":
      return bodyOrResponseMatchesResource
        ? ResourceOperationKind.Create
        : ResourceOperationKind.Action;
    case "patch":
      return bodyOrResponseMatchesResource
        ? ResourceOperationKind.Update
        : ResourceOperationKind.Action;
    case "delete":
      // Most ARM delete operations return void/LRO envelope rather than the
      // resource model. Treat those as valid deletes, but avoid reclassifying
      // deletes that return some unrelated metadata model.
      return !responseModelId || responseMatchesResource
        ? ResourceOperationKind.Delete
        : ResourceOperationKind.Action;
    default:
      return ResourceOperationKind.Action;
  }
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
    sdkContext.program.reportDiagnostic({
      code: "general-error",
      severity: "error",
      message: `Resource model not found for decorator ${decoratorName}`,
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

/**
 * Checks if a model or any of its base models has the @customAzureResource decorator.
 *
 * The @customAzureResource decorator (Azure.ResourceManager.Legacy.@customAzureResource) is used
 * for ARM resources that don't follow standard ARM resource templates. This is commonly used for:
 * - Legacy services that were converted from Swagger to TypeSpec (e.g., TrafficManager)
 * - Services with custom resource hierarchies that don't fit standard ARM patterns
 *
 * Unlike standard ARM resources that use TrackedResource<T> or ProxyResource<T> templates
 * (which automatically get @armResourceInternal decorator), custom resources define their own
 * base Resource model with this decorator.
 *
 * @see https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#customazureresource
 *
 * @param model - The model to check for @customAzureResource decorator
 * @returns true if the model or any ancestor has @customAzureResource decorator
 */
function hasCustomAzureResourceInHierarchy(model: InputModelType): boolean {
  let current: InputModelType | undefined = model;
  while (current) {
    if (current.decorators?.some((d) => d.name === customAzureResource)) {
      return true;
    }
    current = current.baseModel;
  }
  return false;
}

/**
 * Collects all models that represent ARM resources from the code model.
 *
 * ARM resources are detected in two ways:
 *
 * 1. **Standard ARM resources**: Models that use standard ARM templates like TrackedResource<T>
 *    or ProxyResource<T>. These models have @armResourceInternal or @armResourceWithParameter
 *    decorators applied automatically by the typespec-azure-resource-manager library.
 *
 * 2. **Custom Azure resources**: Models that inherit from a custom base Resource model decorated
 *    with @customAzureResource. This pattern is used by legacy services (e.g., TrafficManager)
 *    that were converted from Swagger to TypeSpec and don't fit standard ARM templates.
 *
 * @param codeModel - The code model containing all models
 * @returns Array of resource models
 */
function getAllResourceModels(codeModel: CodeModel): InputModelType[] {
  const resourceModels: InputModelType[] = [];

  for (const model of codeModel.models) {
    // Check for armResource decorators
    if (
      model.decorators?.some(
        (d) =>
          d.name == armResourceInternal || d.name == armResourceWithParameter
      )
    ) {
      resourceModels.push(model);
    }
    // 2. Custom Azure resources: Models inheriting from a @customAzureResource base model
    //    Used by legacy services like TrafficManager that don't use standard ARM templates
    else if (hasCustomAzureResourceInHierarchy(model)) {
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
/**
 * Builds an ArmScopeInfo from an operation path.
 * Extracts the scope ID pattern and resource type from the path's scope portion.
 */
export function buildScopeInfoFromPath(
  operationPath: RequestPath
): ArmScopeInfo {
  return buildScopeInfo(operationPath.operationScope, operationPath.scopePath);
}

/**
 * Builds an ArmScopeInfo from a scope kind and scope path.
 * Computes scopeResourceType from the scope path when it's concrete (no variable segments).
 */
export function buildScopeInfo(
  kind: ResourceScopeKind,
  scopePath: RequestPath
): ArmScopeInfo {
  const resourceType = scopePath.resourceType;
  return {
    kind,
    scopeIdPattern: scopePath,
    // Only include scopeResourceType when it's concrete (no variable segments)
    scopeResourceType:
      resourceType !== undefined && !resourceType.includes("{")
        ? resourceType
        : undefined
  };
}

function getResourceScope(methods?: ResourceMethod[]): ResourceScopeKind {
  // Determine scope from the Read method's operation path, which is the source of truth.
  // Scope decorators (@resourceGroupResource, etc.) can be inherited implicitly from base
  // model types like ProxyResource and may not reflect the actual scope for extension
  // resources that use Legacy.ExtensionOperations with specific parent types.
  if (methods) {
    const getMethod = methods.find(
      (m) => m.kind === ResourceOperationKind.Read
    );
    // We have logic to filter out resources without get/read operations later in post-processing,
    // so it's possible to have a resource with no Read method. In that case, we skip scope detection since the resource will be filtered out anyway.
    if (getMethod) {
      return getMethod.scope.kind;
    }
  }

  // Final fallback to ResourceGroup
  return ResourceScopeKind.ResourceGroup;
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
 * For multiple-path resources (same model at different paths), detects parent-
 * child relationships through path matching. This is needed when both parent
 * and child use the same model (e.g., legacy-operations). Mutates each resource
 * in place to set `parentResourceId`. Does not set `parentResourceModelId`
 * since the parent and child share the same model.
 */
function inferLegacyParentsFromPaths(expanded: ArmResourceSchema[]): void {
  for (const resource of expanded) {
    if (
      resource.metadata.parentResourceId ||
      resource.metadata.resourceIdPattern === undefined
    ) {
      continue;
    }
    const bestParent = findLongestPrefixMatch(
      resource.metadata.resourceIdPattern,
      expanded,
      (candidate) =>
        candidate !== resource &&
        candidate.metadata.resourceIdPattern !== undefined
          ? candidate.metadata.resourceIdPattern
          : undefined,
      true
    );
    if (bestParent) {
      resource.metadata.parentResourceId = bestParent.metadata.resourceIdPattern;
    }
  }
}

/**
 * Updates each resource's scope based on the resource scope decorator if it
 * exists, or based on the Read method's scope otherwise.
 */
function assignLegacyResourceScopes(expanded: ArmResourceSchema[]): void {
  for (const resource of expanded) {
    const scopeKind = getResourceScope(resource.metadata.methods);
    resource.metadata.scope = {
      kind: scopeKind,
      scopeIdPattern:
        resource.metadata.resourceIdPattern?.scopePath ?? RequestPath.empty
    };
  }
}

/**
 * Builds the parent-lookup context for the legacy detection path. Parent
 * information comes from the @parentResourceModelId decorator (or, for shared-
 * model resources, from path matching populated by inferLegacyParentsFromPaths).
 */
function buildLegacyParentLookup(
  expanded: ArmResourceSchema[]
): ParentResourceLookupContext {
  return {
    getParentResource: (resource: ArmResourceSchema) =>
      findLegacyParentResource(resource, expanded)
  };
}

/**
 * Finds the parent ArmResourceSchema for `resource` by scanning `expanded` for
 * entries whose `resourceModelId` matches the resource's
 * `parentResourceModelId` decorator value (and that have a resolved
 * `resourceIdPattern`).
 *
 * When multiple candidates share the same `resourceModelId` (the parent itself
 * was expanded from a `{parentType}` dynamic segment), the candidate whose
 * substituted `resourceIdPattern` is a prefix of the resource's
 * `resourceIdPattern` is chosen — same disambiguator used by the
 * resolveArmResources lookup.
 */
function findLegacyParentResource(
  resource: ArmResourceSchema,
  expanded: readonly ArmResourceSchema[]
): ArmResourceSchema | undefined {
  const parentModelId = resource.metadata.parentResourceModelId;
  if (!parentModelId) return undefined;

  const candidates: ArmResourceSchema[] = [];
  for (const r of expanded) {
    if (
      r.resourceModelId === parentModelId &&
      r.metadata.resourceIdPattern
    ) {
      candidates.push(r);
    }
  }
  if (candidates.length === 0) return undefined;
  return (
    candidates.find((candidate) =>
      isResourceIdPatternPrefixMatch(resource, candidate)
    ) ?? candidates[0]
  );
}

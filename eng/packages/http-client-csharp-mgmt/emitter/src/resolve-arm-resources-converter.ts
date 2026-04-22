// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * This module provides conversion functionality between the resolveArmResources API
 * (from @azure-tools/typespec-azure-resource-manager) and our internal ArmProviderSchema format.
 *
 * The resolveArmResources API is a standardized way to extract ARM resource information
 * from TypeSpec definitions. This converter transforms its output to match our existing
 * schema structure used throughout the codebase.
 *
 * Key differences between the two formats:
 * - resolveArmResources returns a Provider object with ResolvedResource entries
 * - ArmProviderSchema uses ArmResourceSchema with ResourceMetadata
 * - Operation categorization may differ between the two approaches
 *
 * Usage:
 * ```typescript
 * const schema = convertProviderToArmProviderSchema(program, sdkContext);
 * ```
 *
 * Note: This is the first step towards migrating to use resolveArmResources.
 * The converter is designed to maintain compatibility with existing code while
 * allowing gradual migration to the standardized API.
 */

import {
  Program,
  Operation,
  getPattern,
  getMinLength,
  getMaxLength
} from "@typespec/compiler";
import {
  ResolvedResource,
  ResourceType,
  resolveArmResources as resolveArmResourcesFromLibrary
} from "@azure-tools/typespec-azure-resource-manager";
import {
  findLongestPrefixMatch,
  RequestPath,
  ArmProviderSchema,
  ArmResourceSchema,
  NameConstraints,
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
  ResourceOperationKind,
  ResourceScopeKind,
  postProcessArmResources,
  ParentResourceLookupContext,
  assignNonResourceMethodsToResources,
  resolveResourceApiVersions,
  extractRbacRoles
} from "./resource-metadata.js";
import { CSharpEmitterContext } from "@typespec/http-client-csharp";
import {
  getCrossLanguageDefinitionId,
  getClientType,
  SdkModelType
} from "@azure-tools/typespec-client-generator-core";
import { getAllSdkClients } from "./sdk-client-utils.js";
import {
  extensionResourceOperationName,
  legacyExtensionResourceOperationName,
  legacyResourceOperationName,
  builtInResourceOperationName
} from "./sdk-context-options.js";
import {
  buildScopeInfo,
  buildScopeInfoFromPath
} from "./resource-detection.js";

/**
 * Resolves ARM resources from TypeSpec definitions using the standard resolveArmResources API
 * and returns them in our ArmProviderSchema format.
 *
 * This function wraps the standard resolveArmResources API from typespec-azure-resource-manager
 * and converts the result to our internal schema format for compatibility with existing code.
 *
 * @param program - The TypeSpec program
 * @param sdkContext - The emitter context to map models
 * @returns The ARM provider schema in our expected format
 */
export function resolveArmResources(
  program: Program,
  sdkContext: CSharpEmitterContext
): ArmProviderSchema {
  const provider = resolveArmResourcesFromLibrary(program);

  // Convert resources
  const resources: ArmResourceSchema[] = [];
  const processedResources = new Set<string>();
  const schemaToResolvedResource = new Map<
    ArmResourceSchema,
    ResolvedResource
  >();

  // Build a lookup map from methodId (crossLanguageDefinitionId) to apiVersions
  // so that we can efficiently resolve per-resource API versions
  const methodApiVersionsMap = new Map<string, string[]>();
  // Build a lookup map from methodId to SdkMethod kind (basic, paging, lro, lropaging)
  // so that we can detect pageable actions that should be classified as List
  const methodKindMap = new Map<string, string>();
  // Build a lookup map from methodId to the response item type's crossLanguageDefinitionId
  // so that we can verify pageable actions return actual resource models
  const methodResponseModelIdMap = new Map<string, string>();
  for (const client of getAllSdkClients(sdkContext)) {
    for (const method of client.methods) {
      if (!methodApiVersionsMap.has(method.crossLanguageDefinitionId)) {
        methodApiVersionsMap.set(
          method.crossLanguageDefinitionId,
          method.apiVersions
        );
      }
      if (!methodKindMap.has(method.crossLanguageDefinitionId)) {
        methodKindMap.set(method.crossLanguageDefinitionId, method.kind);
      }
      if (
        (method.kind === "paging" || method.kind === "lropaging") &&
        !methodResponseModelIdMap.has(method.crossLanguageDefinitionId)
      ) {
        const responseType = method.response?.type;
        if (
          responseType?.kind === "array" &&
          responseType.valueType.kind === "model"
        ) {
          methodResponseModelIdMap.set(
            method.crossLanguageDefinitionId,
            (responseType.valueType as SdkModelType).crossLanguageDefinitionId
          );
        }
      }
    }
  }

  // Build the set of resource model IDs for validating pageable action responses
  const resourceModelIds = new Set<string>();
  if (provider.resources) {
    for (const resolvedResource of provider.resources) {
      const modelId = getCrossLanguageDefinitionId(
        sdkContext,
        resolvedResource.type
      );
      if (modelId) {
        resourceModelIds.add(modelId);
      }
    }
  }

  if (provider.resources) {
    for (const resolvedResource of provider.resources) {
      // Get the model from SDK context
      const modelId = getCrossLanguageDefinitionId(
        sdkContext,
        resolvedResource.type
      );
      if (!modelId) {
        continue;
      }

      // Create a unique key for this resource to avoid duplicates
      const resourceKey = `${modelId}|${resolvedResource.resourceInstancePath}`;
      if (processedResources.has(resourceKey)) {
        continue;
      }
      processedResources.add(resourceKey);

      // Convert to our resource schema format
      const metadata = convertResolvedResourceToMetadata(
        program,
        sdkContext,
        resolvedResource,
        methodKindMap,
        methodResponseModelIdMap,
        resourceModelIds
      );

      const resource = {
        resourceModelId: modelId,
        metadata
      };
      resources.push(resource);
      schemaToResolvedResource.set(resource, resolvedResource);
    }
  }

  // Assign list operations to the correct resources using prefix matching.
  // The ARM library may assign list operations to the wrong resource when the same
  // model has multiple resources with different path segments (e.g., publicConfigs
  // vs configs). Instead of accepting the ARM library's assignment and fixing it
  // afterwards, we assign list operations ourselves using path matching.
  assignListOperationsToResources(
    sdkContext,
    resources,
    schemaToResolvedResource
  );

  // Convert non-resource methods
  const nonResourceMethods: NonResourceMethod[] = [];

  // Create parent lookup context for resolveArmResources
  // In this case, parent information comes from ResolvedResource objects
  // Build validResourceMap once for efficient lookup
  const validResourceMap = new Map<string, ArmResourceSchema>();
  for (const r of resources.filter(
    (r) => r.metadata.resourceIdPattern !== undefined
  )) {
    const resolvedR = schemaToResolvedResource.get(r);
    if (resolvedR) {
      validResourceMap.set(resolvedR.resourceInstancePath, r);
    }
  }

  const parentLookup: ParentResourceLookupContext = {
    getParentResource: (
      resource: ArmResourceSchema
    ): ArmResourceSchema | undefined => {
      const resolved = schemaToResolvedResource.get(resource);
      if (!resolved) return undefined;

      // Walk up the parent chain to find a valid parent
      let parent = resolved.parent;
      while (parent) {
        const parentResource = validResourceMap.get(
          parent.resourceInstancePath
        );
        if (parentResource) {
          return parentResource;
        }
        parent = parent.parent;
      }
      return undefined;
    }
  };

  // Use the shared post-processing function
  const filteredResources = postProcessArmResources(
    resources,
    nonResourceMethods,
    parentLookup,
    methodResponseModelIdMap
  );

  // Add provider operations as non-resource methods
  if (provider.providerOperations) {
    for (const operation of provider.providerOperations) {
      // Get method ID from the operation
      const methodId = getMethodIdFromOperation(
        sdkContext,
        operation.operation
      );
      if (!methodId) {
        continue;
      }

      const opPath = new RequestPath(operation.path);
      nonResourceMethods.push({
        methodId,
        operationPath: opPath,
        // TODO: this is also temporary because resolveArmResources does not have the scope of a provider operation
        scope: buildScopeInfoFromPath(opPath)
      });
    }
  }

  // Post-processing step: Find operations that were not recognized by the ARM library
  // and add them as non-resource methods
  const includedOperationIds = new Set<string>();
  // Track all operations that are already included
  for (const resource of filteredResources) {
    for (const method of resource.metadata.methods) {
      includedOperationIds.add(method.methodId);
    }
  }
  for (const nonResourceMethod of nonResourceMethods) {
    includedOperationIds.add(nonResourceMethod.methodId);
  }

  // Get all SDK operations
  const allSdkClients = getAllSdkClients(sdkContext);
  for (const client of allSdkClients) {
    for (const method of client.methods) {
      const methodId = method.crossLanguageDefinitionId;
      const operation = method.operation;

      // Skip if already included
      if (includedOperationIds.has(methodId)) {
        continue;
      }

      // Skip if not an HTTP operation with a path
      if (!operation || operation.kind !== "http" || !operation.path) {
        continue;
      }

      const opPath = new RequestPath(operation.path);
      // Add this missing operation as a non-resource method
      nonResourceMethods.push({
        methodId: methodId,
        operationPath: opPath,
        scope: buildScopeInfoFromPath(opPath)
      });
    }
  }

  // Assign non-resource methods to resources based on operationPath prefix matching.
  // If a non-resource method's path has a prefix matching a resource's resourceIdPattern,
  // move it into that resource as an Action (longest prefix wins).
  assignNonResourceMethodsToResources(filteredResources, nonResourceMethods);

  // Compute per-resource API versions after all post-processing is complete,
  // so that merged/moved methods are reflected in the final version set.
  for (const resource of filteredResources) {
    resource.metadata.apiVersions = resolveResourceApiVersions(
      resource.metadata.methods,
      methodApiVersionsMap
    );
  }

  return {
    resources: filteredResources,
    nonResourceMethods
  };
}

/**
 * Converts a ResolvedResource to ResourceMetadata format
 */
function convertResolvedResourceToMetadata(
  program: Program,
  sdkContext: CSharpEmitterContext,
  resolvedResource: ResolvedResource,
  methodKindMap?: Map<string, string>,
  methodResponseModelIdMap?: Map<string, string>,
  resourceModelIds?: Set<string>
): ResourceMetadata {
  const methods: ResourceMethod[] = [];
  let resourceIdPattern = "";

  // Convert lifecycle operations
  if (resolvedResource.operations.lifecycle) {
    const lifecycle = resolvedResource.operations.lifecycle;

    if (lifecycle.read && lifecycle.read.length > 0) {
      for (const readOp of lifecycle.read) {
        const methodId = getMethodIdFromOperation(sdkContext, readOp.operation);
        if (methodId) {
          const opPath = new RequestPath(readOp.path);
          methods.push({
            methodId,
            kind: ResourceOperationKind.Read,
            operationPath: opPath,
            scope: buildScopeInfoFromPath(opPath)
          });
          // Use the first read operation's path as the resource ID pattern
          if (!resourceIdPattern) {
            resourceIdPattern = readOp.path;
          }
        }
      }
    }

    if (lifecycle.createOrUpdate && lifecycle.createOrUpdate.length > 0) {
      for (const createOp of lifecycle.createOrUpdate) {
        const methodId = getMethodIdFromOperation(
          sdkContext,
          createOp.operation
        );
        if (methodId) {
          const opPath = new RequestPath(createOp.path);
          methods.push({
            methodId,
            kind: ResourceOperationKind.Create,
            operationPath: opPath,
            scope: buildScopeInfoFromPath(opPath)
          });
        }
      }
    }

    if (lifecycle.update && lifecycle.update.length > 0) {
      for (const updateOp of lifecycle.update) {
        const methodId = getMethodIdFromOperation(
          sdkContext,
          updateOp.operation
        );
        if (methodId) {
          const opPath = new RequestPath(updateOp.path);
          methods.push({
            methodId,
            kind: ResourceOperationKind.Update,
            operationPath: opPath,
            scope: buildScopeInfoFromPath(opPath)
          });
        }
      }
    }

    if (lifecycle.delete && lifecycle.delete.length > 0) {
      for (const deleteOp of lifecycle.delete) {
        const methodId = getMethodIdFromOperation(
          sdkContext,
          deleteOp.operation
        );
        if (methodId) {
          const opPath = new RequestPath(deleteOp.path);
          methods.push({
            methodId,
            kind: ResourceOperationKind.Delete,
            operationPath: opPath,
            scope: buildScopeInfoFromPath(opPath)
          });
        }
      }
    }
  }

  // Convert action operations
  if (resolvedResource.operations.actions) {
    for (const actionOp of resolvedResource.operations.actions) {
      const methodId = getMethodIdFromOperation(sdkContext, actionOp.operation);
      if (methodId) {
        // Classify as List only if the action is pageable AND its response item type
        // is a known resource model. This prevents metadata-returning pageable actions
        // from being misclassified as List operations.
        const sdkMethodKind = methodKindMap?.get(methodId);
        const responseModelId = methodResponseModelIdMap?.get(methodId);
        const isResourceList =
          sdkMethodKind === "paging" &&
          resourceModelIds !== undefined &&
          resourceModelIds.has(responseModelId!);
        const opPath = new RequestPath(actionOp.path);
        methods.push({
          methodId,
          kind: isResourceList
            ? ResourceOperationKind.List
            : ResourceOperationKind.Action,
          operationPath: opPath,
          scope: buildScopeInfoFromPath(opPath)
        });
      }
    }
  }

  // Convert resource scope
  const resourceScopeValue = convertScopeToResourceScope(
    resolvedResource.scope
  );

  // Build resource type string
  const resourceType = formatResourceType(resolvedResource.resourceType);

  // Use the explicit ResourceName if provided via the OverrideResourceName template parameter.
  // The spec should always define unique resource names for extension resources targeting
  // different parent types — the emitter should not auto-generate disambiguated names.
  let resourceName = resolvedResource.resourceName;
  const explicitName = getExplicitResourceNameFromOperations(resolvedResource);
  if (explicitName) {
    resourceName = explicitName;
  }

  // Extract name constraints from the resource model's "name" property
  const nameProperty = resolvedResource.type.properties.get("name");
  const rawPattern = nameProperty
    ? getPattern(program, nameProperty)
    : undefined;
  const nameConstraints: NameConstraints = {
    pattern: rawPattern || undefined,
    minLength: nameProperty ? getMinLength(program, nameProperty) : undefined,
    maxLength: nameProperty ? getMaxLength(program, nameProperty) : undefined
  };

  // API versions will be computed after post-processing when methods are finalized
  const apiVersions: string[] = [];

  // Extract RBAC roles from @@clientOption decorator
  const sdkModel = getClientType(
    sdkContext,
    resolvedResource.type
  ) as SdkModelType;
  const rbacRoles = extractRbacRoles(sdkModel);

  return {
    // we only assign resourceIdPattern when this resource has a read operation, otherwise this is undefined
    resourceIdPattern: resourceIdPattern
      ? new RequestPath(resourceIdPattern)
      : undefined,
    resourceType,
    methods,
    scope: buildScopeInfo(
      resourceScopeValue,
      resourceIdPattern
        ? new RequestPath(resourceIdPattern).scopePath
        : RequestPath.empty
    ),
    parentResourceId: undefined,
    parentResourceModelId: undefined,
    // TODO: Temporary - waiting for resolveArmResources API update to include singleton information
    // Once the API includes this, we can remove this extraction logic
    singletonResourceName: new RequestPath(
      resolvedResource.resourceInstancePath
    ).singletonName,
    resourceName: resourceName,
    nameConstraints,
    apiVersions,
    rbacRoles
  };
}

/**
 * Get method ID (cross-language definition ID) from an Operation.
 * Uses TCGC's getCrossLanguageDefinitionId utility directly.
 */
function getMethodIdFromOperation(
  sdkContext: CSharpEmitterContext,
  operation: Operation
): string | undefined {
  // Use TCGC's utility to get the cross-language definition ID directly
  // CSharpEmitterContext extends SdkContext which extends TCGCContext
  return getCrossLanguageDefinitionId(sdkContext, operation);
}

/**
 * Convert scope string/object to ResourceScopeKind enum
 */
function convertScopeToResourceScope(
  scope: string | ResolvedResource | undefined
): ResourceScopeKind {
  if (!scope) {
    // TODO: does it make sense that we have something without scope??
    return ResourceScopeKind.ResourceGroup; // Default
  }

  if (typeof scope === "string") {
    switch (scope) {
      case "Tenant":
        return ResourceScopeKind.Tenant;
      case "Subscription":
        return ResourceScopeKind.Subscription;
      case "ResourceGroup":
        return ResourceScopeKind.ResourceGroup;
      case "ManagementGroup":
        return ResourceScopeKind.ManagementGroup;
      case "Scope":
      case "ExternalResource":
        return ResourceScopeKind.Extension;
      default:
        return ResourceScopeKind.ResourceGroup;
    }
  }

  // TODO: Schema update needed - when scope is a ResolvedResource (extension resource),
  // our schema needs to support representing the specific parent resource, not just "Extension"
  // If scope is a ResolvedResource, it's an extension resource
  return ResourceScopeKind.Extension;
}

/**
 * Format ResourceType to a string
 */
function formatResourceType(resourceType: ResourceType): string {
  return `${resourceType.provider}/${resourceType.types.join("/")}`;
}

/**
 * Extracts the explicit resource name from a resolved resource's operations.
 * Checks the CRUD operations' decorators for OverrideResourceName parameters
 * set via @extensionResourceOperation or @legacyExtensionResourceOperation.
 */
function getExplicitResourceNameFromOperations(
  resolvedResource: ResolvedResource
): string | undefined {
  const lifecycle = resolvedResource.operations.lifecycle;
  if (!lifecycle) return undefined;

  // Check all CRUD operations for an explicit resource name
  const operations: Operation[] = [];
  if (lifecycle.read) {
    for (const op of lifecycle.read) operations.push(op.operation);
  }
  if (lifecycle.createOrUpdate) {
    for (const op of lifecycle.createOrUpdate) operations.push(op.operation);
  }
  if (lifecycle.delete) {
    for (const op of lifecycle.delete) operations.push(op.operation);
  }

  for (const operation of operations) {
    const decorators = operation.decorators;
    for (const decorator of decorators) {
      const name = decorator.definition?.name;
      if (
        name === extensionResourceOperationName ||
        name === legacyExtensionResourceOperationName ||
        name === legacyResourceOperationName
      ) {
        // For extensionResourceOperation: args are (TargetResource, ExtensionResource, kind, ResourceName) — index 3
        // For legacyExtensionResourceOperation/legacyResourceOperation: args are (Resource, kind, ResourceName) — index 2
        const argIndex = name === extensionResourceOperationName ? 3 : 2;
        if (
          decorator.args.length > argIndex &&
          decorator.args[argIndex].jsValue &&
          typeof decorator.args[argIndex].jsValue === "string" &&
          (decorator.args[argIndex].jsValue as string).length > 0
        ) {
          return decorator.args[argIndex].jsValue as string;
        }
      }
      // For builtInResourceOperation: args are (ParentResource, BuiltInResource, kind, ResourceName) — index 3
      if (name === builtInResourceOperationName && decorator.args.length > 3) {
        return decorator.args[3].jsValue as string;
      }
    }
  }

  return undefined;
}

/**
 * Assigns list operations from resolved resources to the correct ArmResourceSchema entries
 * using prefix matching.
 *
 * The ARM library may assign list operations to the wrong resource when the same model
 * has multiple resources with different path segments (e.g., `publicConfigs` at subscription
 * scope and `configs` at resource group scope). Instead of accepting the ARM library's
 * assignment and fixing it afterwards, we assign list operations ourselves using path matching:
 *
 * 1. If only one resource exists for the model, use it directly
 * 2. Try prefix matching: find the resource whose path (stripped of the key variable segment)
 *    is the longest prefix of the list operation path
 * 3. Fall back to matching the list path's last segment against each resource's type segment
 * 4. If no match found, fall back to the ARM library's original assignment
 */
function assignListOperationsToResources(
  sdkContext: CSharpEmitterContext,
  resources: ArmResourceSchema[],
  schemaToResolvedResource: Map<ArmResourceSchema, ResolvedResource>
): void {
  // Precompute resources grouped by model ID to avoid repeated full scans
  const resourcesByModelId = new Map<string, ArmResourceSchema[]>();
  for (const r of resources) {
    const existing = resourcesByModelId.get(r.resourceModelId);
    if (existing) {
      existing.push(r);
    } else {
      resourcesByModelId.set(r.resourceModelId, [r]);
    }
  }

  for (const [resource, resolvedResource] of schemaToResolvedResource) {
    if (!resolvedResource.operations.lists) continue;

    const modelId = resource.resourceModelId;
    const resourcesForModel = resourcesByModelId.get(modelId) ?? [];

    for (const listOp of resolvedResource.operations.lists) {
      const methodId = getMethodIdFromOperation(sdkContext, listOp.operation);
      if (!methodId) continue;

      let targetResource: ArmResourceSchema | undefined;

      if (resourcesForModel.length === 1) {
        // Only one resource for this model — no ambiguity
        targetResource = resourcesForModel[0];
      } else {
        // Multiple resources for the same model — use prefix matching to find the correct one
        targetResource = findLongestPrefixMatch(
          new RequestPath(listOp.path),
          resourcesForModel,
          (r) => r.metadata.resourceIdPattern?.trimLastSegment
        );

        // Fall back to resource type matching if prefix matching didn't find a match
        const listPath = new RequestPath(listOp.path);
        const listType = listPath.resourceType;
        if (!targetResource && listType !== undefined) {
          targetResource = resourcesForModel.find((r) => {
            if (
              !r.metadata.resourceIdPattern ||
              !listPath.hasSameScopeNesting(r.metadata.resourceIdPattern)
            ) {
              return false;
            }
            return r.metadata.resourceType === listType;
          });
        }
      }

      // Fall back to the ARM library's original assignment
      if (!targetResource) {
        targetResource = resource;
      }

      const listPath = new RequestPath(listOp.path);
      targetResource.metadata.methods.push({
        methodId,
        kind: ResourceOperationKind.List,
        operationPath: listPath,
        scope: buildScopeInfoFromPath(listPath)
      });
    }
  }
}

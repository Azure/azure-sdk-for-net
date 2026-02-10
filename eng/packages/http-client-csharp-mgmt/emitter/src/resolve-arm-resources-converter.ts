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

import { Program, Operation } from "@typespec/compiler";
import {
  ResolvedResource,
  ResourceType,
  resolveArmResources as resolveArmResourcesFromLibrary
} from "@azure-tools/typespec-azure-resource-manager";
import {
  ArmProviderSchema,
  ArmResourceSchema,
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
  ResourceOperationKind,
  ResourceScope,
  postProcessArmResources,
  ParentResourceLookupContext
} from "./resource-metadata.js";
import { CSharpEmitterContext } from "@typespec/http-client-csharp";
import { getCrossLanguageDefinitionId } from "@azure-tools/typespec-client-generator-core";
import { isVariableSegment, isPrefix } from "./utils.js";
import { getAllSdkClients } from "./sdk-client-utils.js";

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
        sdkContext,
        resolvedResource
      );

      // Debug log after conversion
      console.log(`[DEBUG] Converted resourceName: ${metadata.resourceName}`);

      const resource = {
        resourceModelId: modelId,
        metadata
      };
      resources.push(resource);
      schemaToResolvedResource.set(resource, resolvedResource);
    }
  }

  // Convert non-resource methods
  const nonResourceMethods: NonResourceMethod[] = [];

  // Create parent lookup context for resolveArmResources
  // In this case, parent information comes from ResolvedResource objects
  // Build validResourceMap once for efficient lookup
  const validResourceMap = new Map<string, ArmResourceSchema>();
  for (const r of resources.filter(
    (r) => r.metadata.resourceIdPattern !== ""
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
    parentLookup
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

      nonResourceMethods.push({
        methodId,
        operationPath: operation.path,
        // TODO: this is also temporary because resolveArmResources does not have the scope of a provider operation
        operationScope: getOperationScopeFromPath(operation.path)
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

      // Add this missing operation as a non-resource method
      nonResourceMethods.push({
        methodId: methodId,
        operationPath: operation.path,
        operationScope: getOperationScopeFromPath(operation.path)
      });
    }
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
  sdkContext: CSharpEmitterContext,
  resolvedResource: ResolvedResource
): ResourceMetadata {
  const methods: ResourceMethod[] = [];
  const resourceScope = convertScopeToResourceScope(resolvedResource.scope);
  let resourceIdPattern = "";

  // Convert lifecycle operations
  if (resolvedResource.operations.lifecycle) {
    const lifecycle = resolvedResource.operations.lifecycle;

    if (lifecycle.read && lifecycle.read.length > 0) {
      for (const readOp of lifecycle.read) {
        const methodId = getMethodIdFromOperation(sdkContext, readOp.operation);
        if (methodId) {
          methods.push({
            methodId,
            kind: ResourceOperationKind.Read,
            operationPath: readOp.path,
            operationScope: resourceScope,
            resourceScope: calculateResourceScope(readOp.path, resolvedResource),
            parentResourceType: extractParentResourceTypeFromPath(readOp.path)
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
          methods.push({
            methodId,
            kind: ResourceOperationKind.Create,
            operationPath: createOp.path,
            operationScope: resourceScope,
            resourceScope: calculateResourceScope(createOp.path, resolvedResource),
            parentResourceType: extractParentResourceTypeFromPath(createOp.path)
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
          methods.push({
            methodId,
            kind: ResourceOperationKind.Update,
            operationPath: updateOp.path,
            operationScope: resourceScope,
            resourceScope: calculateResourceScope(updateOp.path, resolvedResource),
            parentResourceType: extractParentResourceTypeFromPath(updateOp.path)
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
          methods.push({
            methodId,
            kind: ResourceOperationKind.Delete,
            operationPath: deleteOp.path,
            operationScope: resourceScope,
            resourceScope: calculateResourceScope(deleteOp.path, resolvedResource),
            parentResourceType: extractParentResourceTypeFromPath(deleteOp.path)
          });
        }
      }
    }
  }

  // Convert list operations
  if (resolvedResource.operations.lists) {
    for (const listOp of resolvedResource.operations.lists) {
      const methodId = getMethodIdFromOperation(sdkContext, listOp.operation);
      if (methodId) {
        methods.push({
          methodId,
          kind: ResourceOperationKind.List,
          operationPath: listOp.path,
          // TODO: resolveArmResources is not returning the operation scope for list operations, so we calculate it from the path.
          operationScope: getOperationScopeFromPath(listOp.path),
          // TODO: resolveArmResources is not returning the resource scope for list operations, so this should be populated later.
          resourceScope: undefined,
          parentResourceType: extractParentResourceTypeFromPath(listOp.path)
        });
      }
    }
  }

  // Convert action operations
  if (resolvedResource.operations.actions) {
    for (const actionOp of resolvedResource.operations.actions) {
      const methodId = getMethodIdFromOperation(sdkContext, actionOp.operation);
      if (methodId) {
        methods.push({
          methodId,
          kind: ResourceOperationKind.Action,
          operationPath: actionOp.path,
          operationScope: resourceScope,
          resourceScope: calculateResourceScope(actionOp.path, resolvedResource),
          parentResourceType: extractParentResourceTypeFromPath(actionOp.path)
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

  // Generate unique resource name for extension resources
  // If this resource has a parent resource type (extension resource pattern),
  // append a discriminator to make the name unique
  let resourceName = resolvedResource.resourceName;
  const parentResourceType = extractParentResourceTypeFromPath(
    resolvedResource.resourceInstancePath
  );
  if (parentResourceType) {
    // Extract the resource type name (e.g., "virtualMachines" -> "VirtualMachine")
    const discriminator = getParentTypeDiscriminator(parentResourceType);
    if (discriminator) {
      resourceName = `${resourceName}For${discriminator}`;
    }
  }

  return {
    // we only assign resourceIdPattern when this resource has a read operation, otherwise this is empty
    resourceIdPattern: resourceIdPattern,
    resourceType,
    methods,
    resourceScope: resourceScopeValue,
    parentResourceId: undefined,
    parentResourceModelId: undefined,
    // TODO: Temporary - waiting for resolveArmResources API update to include singleton information
    // Once the API includes this, we can remove this extraction logic
    singletonResourceName: extractSingletonName(
      resolvedResource.resourceInstancePath
    ),
    resourceName: resourceName
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
 * Convert scope string/object to ResourceScope enum
 */
function convertScopeToResourceScope(
  scope: string | ResolvedResource | undefined
): ResourceScope {
  if (!scope) {
    // TODO: does it make sense that we have something without scope??
    return ResourceScope.ResourceGroup; // Default
  }

  if (typeof scope === "string") {
    switch (scope) {
      case "Tenant":
        return ResourceScope.Tenant;
      case "Subscription":
        return ResourceScope.Subscription;
      case "ResourceGroup":
        return ResourceScope.ResourceGroup;
      case "ManagementGroup":
        return ResourceScope.ManagementGroup;
      case "Scope":
      case "ExternalResource":
        return ResourceScope.Extension;
      default:
        return ResourceScope.ResourceGroup;
    }
  }

  // TODO: Schema update needed - when scope is a ResolvedResource (extension resource),
  // our schema needs to support representing the specific parent resource, not just "Extension"
  // If scope is a ResolvedResource, it's an extension resource
  return ResourceScope.Extension;
}

/**
 * Determine operation scope from path
 */
export function getOperationScopeFromPath(path: string): ResourceScope {
  if (path.startsWith("/{resourceUri}") || path.startsWith("/{scope}")) {
    return ResourceScope.Extension;
  } else if (
    /^\/subscriptions\/\{[^}]+\}\/resourceGroups\/\{[^}]+\}\//.test(path)
  ) {
    return ResourceScope.ResourceGroup;
  } else if (/^\/subscriptions\/\{[^}]+\}\//.test(path)) {
    return ResourceScope.Subscription;
  } else if (
    /^\/providers\/Microsoft\.Management\/managementGroups\/\{[^}]+\}\//.test(
      path
    )
  ) {
    return ResourceScope.ManagementGroup;
  } else if (hasMultipleProviderSegments(path)) {
    // Paths with multiple /providers/ segments indicate extension resources
    // e.g., /providers/Microsoft.Management/serviceGroups/{name}/providers/Microsoft.Edge/sites/{siteName}
    return ResourceScope.Extension;
  }
  return ResourceScope.Tenant; // all the templates work as if there is a tenant decorator when there is no such decorator
}

/**
 * Check if a path has multiple /providers/ segments, indicating an extension resource
 * that extends another ARM resource.
 */
function hasMultipleProviderSegments(path: string): boolean {
  const providerMatches = path.match(/\/providers\//gi);
  return providerMatches !== null && providerMatches.length > 1;
}

/**
 * Format ResourceType to a string
 */
function formatResourceType(resourceType: ResourceType): string {
  return `${resourceType.provider}/${resourceType.types.join("/")}`;
}

/**
 * Extract singleton resource name from path if it exists
 */
function extractSingletonName(path: string): string | undefined {
  // Check if the path ends with a fixed string instead of a parameter
  const segments = path.split("/").filter((s) => s.length > 0);
  const lastSegment = segments[segments.length - 1];

  // If the last segment is not a parameter (doesn't start with {), it's a singleton
  if (lastSegment && !isVariableSegment(lastSegment)) {
    return lastSegment;
  }

  return undefined;
}

function calculateResourceScope(
  operationPath: string,
  resolvedResource: ResolvedResource
): string | undefined {
  if (isPrefix(resolvedResource.resourceInstancePath, operationPath)) {
    return resolvedResource.resourceInstancePath;
  }

  let parent = resolvedResource.parent;
  while (parent) {
    if (isPrefix(parent.resourceInstancePath, operationPath)) {
      return parent.resourceInstancePath;
    }
    parent = parent.parent;
  }

  return undefined;
}

/**
 * Extracts the parent resource type from an extension resource operation path.
 * For paths like /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/...
 * returns "Microsoft.Compute/virtualMachines"
 */
export function extractParentResourceTypeFromPath(
  operationPath: string
): string | undefined {
  // Split the path and find providers segments
  const segments = operationPath.split("/").filter((s) => s.length > 0);
  
  // Find all "providers" occurrences
  const providerIndices: number[] = [];
  for (let i = 0; i < segments.length; i++) {
    if (segments[i] === "providers") {
      providerIndices.push(i);
    }
  }
  
  // If there are at least 2 provider segments (parent resource and extension resource),
  // extract the parent type from the first non-core provider
  if (providerIndices.length >= 2) {
    // Find the first provider that isn't the extension resource provider
    // Start from the first providers segment after resourceGroups
    const rgIndex = segments.findIndex((s) => s === "resourceGroups");
    if (rgIndex >= 0) {
      // Look for the first provider after resourceGroups that has a complete resource path
      for (let i = 0; i < providerIndices.length - 1; i++) {
        const providerIdx = providerIndices[i];
        // Skip if before resourceGroups
        if (providerIdx <= rgIndex) continue;
        
        // Provider namespace is at providerIdx + 1
        // Resource type is at providerIdx + 2
        if (providerIdx + 2 < segments.length) {
          const namespace = segments[providerIdx + 1];
          const resourceType = segments[providerIdx + 2];
          
          // Skip if the next segment is a variable (meaning this is a valid parent)
          if (providerIdx + 3 < segments.length && isVariableSegment(segments[providerIdx + 3])) {
            return `${namespace}/${resourceType}`;
          }
        }
      }
    }
  }
  
  return undefined;
}

/**
 * Converts a parent resource type to a discriminator suitable for appending to resource names.
 * E.g., "Microsoft.Compute/virtualMachines" -> "VirtualMachines"
 *       "Microsoft.HybridCompute/machines" -> "Machines"
 */
export function getParentTypeDiscriminator(parentResourceType: string): string {
  // Known mappings for common parent resource types
  const knownMappings: Record<string, string> = {
    "Microsoft.Compute/virtualMachines": "VirtualMachine",
    "Microsoft.HybridCompute/machines": "Machine",
    "Microsoft.Compute/virtualMachineScaleSets": "VirtualMachineScaleSet",
    "Microsoft.ConnectedVMwarevSphere/virtualMachines": "VMwarevSphereVirtualMachine"
  };

  const mapped = knownMappings[parentResourceType];
  if (mapped) {
    return mapped;
  }

  // Generic fallback: extract the resource type name and convert to PascalCase singular
  const parts = parentResourceType.split("/");
  if (parts.length >= 2) {
    const resourceTypeName = parts[1];
    // Convert to PascalCase and singularize (remove trailing 's' if present)
    let result = resourceTypeName.charAt(0).toUpperCase() + resourceTypeName.slice(1);
    if (result.endsWith("s") && result.length > 1) {
      result = result.slice(0, -1);
    }
    return result;
  }

  return "";
}

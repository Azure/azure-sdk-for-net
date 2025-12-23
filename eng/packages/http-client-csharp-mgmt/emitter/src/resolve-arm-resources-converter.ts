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

import { Program, Model, Operation } from "@typespec/compiler";
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
  ResourceScope
} from "./resource-metadata.js";
import { CSharpEmitterContext } from "@typespec/http-client-csharp";
import {
  SdkModelType,
  SdkMethod,
  SdkHttpOperation,
  getClientType
} from "@azure-tools/typespec-client-generator-core";
import { getAllSdkClients } from "./resource-detection.js";

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
  
  // Build maps for fast lookup
  const operationMaps = buildOperationMap(sdkContext);
  
  // Convert resources
  const resources: ArmResourceSchema[] = [];
  const processedResources = new Set<string>();
  
  if (provider.resources) {
    for (const resolvedResource of provider.resources) {
      // Get the model from SDK context
      const model = getModelFromSdkContext(sdkContext, resolvedResource.type);
      if (!model) {
        continue;
      }
      
      // Create a unique key for this resource to avoid duplicates
      const resourceKey = `${model.crossLanguageDefinitionId}|${resolvedResource.resourceInstancePath}`;
      if (processedResources.has(resourceKey)) {
        continue;
      }
      processedResources.add(resourceKey);
      
      // Convert to our resource schema format
      const metadata = convertResolvedResourceToMetadata(resolvedResource, sdkContext, operationMaps);
      
      resources.push({
        resourceModelId: model.crossLanguageDefinitionId,
        metadata
      });
    }
  }
  
  // Convert non-resource methods
  const nonResourceMethods: NonResourceMethod[] = [];
  if (provider.providerOperations) {
    for (const operation of provider.providerOperations) {
      // Get method ID from the operation
      const methodId = getMethodIdFromOperation(operation.operation, operation.path, operationMaps);
      if (!methodId) {
        continue;
      }
      
      nonResourceMethods.push({
        methodId,
        operationPath: operation.path,
        operationScope: getOperationScopeFromPath(operation.path)
      });
    }
  }
  
  return {
    resources,
    nonResourceMethods
  };
}

/**
 * Build maps of TypeSpec operations to SDK methods for fast lookup.
 * Creates identity-based, name-based, and path-based maps since resolveArmResources
 * may return different Operation instances than the SDK clients.
 */
function buildOperationMap(sdkContext: CSharpEmitterContext): {
  byIdentity: Map<Operation, SdkMethod<SdkHttpOperation>>;
  byName: Map<string, SdkMethod<SdkHttpOperation>>;
  byPath: Map<string, SdkMethod<SdkHttpOperation>[]>;
} {
  const byIdentity = new Map<Operation, SdkMethod<SdkHttpOperation>>();
  const byName = new Map<string, SdkMethod<SdkHttpOperation>>();
  const byPath = new Map<string, SdkMethod<SdkHttpOperation>[]>();
  
  for (const client of getAllSdkClients(sdkContext)) {
    for (const method of client.methods) {
      const operation = method.__raw;
      if (operation) {
        byIdentity.set(operation, method);
        
        // Create a unique key using namespace and operation name
        const nameKey = `${operation.namespace?.name || ""}.${operation.name}`;
        byName.set(nameKey, method);
        
        // Index by path (there can be multiple methods for the same path with different HTTP verbs)
        const httpOperation = method.operation as SdkHttpOperation;
        if (httpOperation?.path) {
          const pathKey = httpOperation.path;
          if (!byPath.has(pathKey)) {
            byPath.set(pathKey, []);
          }
          byPath.get(pathKey)!.push(method);
        }
      }
    }
  }
  
  return { byIdentity, byName, byPath };
}

/**
 * Converts a ResolvedResource to ResourceMetadata format
 */
function convertResolvedResourceToMetadata(
  resolvedResource: ResolvedResource,
  sdkContext: CSharpEmitterContext,
  operationMaps: {
    byIdentity: Map<Operation, SdkMethod<SdkHttpOperation>>;
    byName: Map<string, SdkMethod<SdkHttpOperation>>;
    byPath: Map<string, SdkMethod<SdkHttpOperation>[]>;
  }
): ResourceMetadata {
  const methods: ResourceMethod[] = [];
  const resourceScope = convertScopeToResourceScope(resolvedResource.scope);
  
  // Convert lifecycle operations
  if (resolvedResource.operations.lifecycle) {
    const lifecycle = resolvedResource.operations.lifecycle;
    
    if (lifecycle.read && lifecycle.read.length > 0) {
      for (const readOp of lifecycle.read) {
        const methodId = getMethodIdFromOperation(readOp.operation, readOp.path, operationMaps);
        if (methodId) {
          methods.push({
            methodId,
            kind: ResourceOperationKind.Get,
            operationPath: readOp.path,
            operationScope: resourceScope,
            resourceScope: resolvedResource.resourceInstancePath
          });
        }
      }
    }
    
    if (lifecycle.createOrUpdate && lifecycle.createOrUpdate.length > 0) {
      for (const createOp of lifecycle.createOrUpdate) {
        const methodId = getMethodIdFromOperation(createOp.operation, createOp.path, operationMaps);
        if (methodId) {
          methods.push({
            methodId,
            kind: ResourceOperationKind.Create,
            operationPath: createOp.path,
            operationScope: resourceScope,
            resourceScope: resolvedResource.resourceInstancePath
          });
        }
      }
    }
    
    if (lifecycle.update && lifecycle.update.length > 0) {
      for (const updateOp of lifecycle.update) {
        const methodId = getMethodIdFromOperation(updateOp.operation, updateOp.path, operationMaps);
        if (methodId) {
          methods.push({
            methodId,
            kind: ResourceOperationKind.Update,
            operationPath: updateOp.path,
            operationScope: resourceScope,
            resourceScope: resolvedResource.resourceInstancePath
          });
        }
      }
    }
    
    if (lifecycle.delete && lifecycle.delete.length > 0) {
      for (const deleteOp of lifecycle.delete) {
        const methodId = getMethodIdFromOperation(deleteOp.operation, deleteOp.path, operationMaps);
        if (methodId) {
          methods.push({
            methodId,
            kind: ResourceOperationKind.Delete,
            operationPath: deleteOp.path,
            operationScope: resourceScope,
            resourceScope: resolvedResource.resourceInstancePath
          });
        }
      }
    }
  }
  
  // Convert list operations
  if (resolvedResource.operations.lists) {
    for (const listOp of resolvedResource.operations.lists) {
      const methodId = getMethodIdFromOperation(listOp.operation, listOp.path, operationMaps);
      if (methodId) {
        methods.push({
          methodId,
          kind: ResourceOperationKind.List,
          operationPath: listOp.path,
          operationScope: resourceScope,
          // TODO: This calculation may need refinement - the list operation's resource scope
          // might be different from the resource's own scope
          resourceScope: getListResourceScope(listOp.path, resolvedResource.resourceInstancePath)
        });
      }
    }
  }
  
  // Convert action operations
  if (resolvedResource.operations.actions) {
    for (const actionOp of resolvedResource.operations.actions) {
      const methodId = getMethodIdFromOperation(actionOp.operation, actionOp.path, operationMaps);
      if (methodId) {
        methods.push({
          methodId,
          kind: ResourceOperationKind.Action,
          operationPath: actionOp.path,
          operationScope: resourceScope,
          resourceScope: resolvedResource.resourceInstancePath
        });
      }
    }
  }
  
  // Determine parent resource ID
  const parentResourceId = resolvedResource.parent?.resourceInstancePath;
  
  // Convert resource scope
  const resourceScopeValue = convertScopeToResourceScope(resolvedResource.scope);
  
  // Build resource type string
  const resourceType = formatResourceType(resolvedResource.resourceType);
  
  return {
    resourceIdPattern: resolvedResource.resourceInstancePath,
    resourceType,
    methods,
    resourceScope: resourceScopeValue,
    parentResourceId,
    // TODO: Temporary - waiting for resolveArmResources API update to include singleton information
    // Once the API includes this, we can remove this extraction logic
    singletonResourceName: extractSingletonName(resolvedResource.resourceInstancePath),
    resourceName: resolvedResource.resourceName
  };
}

/**
 * Helper to get a model from SDK context by TypeSpec type
 */
function getModelFromSdkContext(
  sdkContext: CSharpEmitterContext,
  typespecType: Model
): SdkModelType | undefined {
  // Use getClientType to get the SDK model type from the TypeSpec model
  const sdkModel = getClientType(sdkContext, typespecType);
  if (sdkModel && sdkModel.kind === "model") {
    return sdkModel as SdkModelType;
  }
  return undefined;
}

/**
 * Helper to get method ID from an operation using the operation maps.
 * Tries identity-based lookup first, then path-based, then name-based lookup.
 */
function getMethodIdFromOperation(
  operation: Operation,
  operationPath: string,
  operationMaps: {
    byIdentity: Map<Operation, SdkMethod<SdkHttpOperation>>;
    byName: Map<string, SdkMethod<SdkHttpOperation>>;
    byPath: Map<string, SdkMethod<SdkHttpOperation>[]>;
  }
): string | undefined {
  // Try identity-based lookup first
  let method = operationMaps.byIdentity.get(operation);
  
  // Fall back to path-based lookup if identity lookup fails
  if (!method) {
    const methodsByPath = operationMaps.byPath.get(operationPath);
    if (methodsByPath && methodsByPath.length > 0) {
      // If multiple methods share the same path, try to match by operation name
      if (methodsByPath.length === 1) {
        method = methodsByPath[0];
      } else {
        // Try to match by operation name
        method = methodsByPath.find(m => m.__raw?.name === operation.name);
        // If still no match, take the first one
        if (!method) {
          method = methodsByPath[0];
        }
      }
    }
  }
  
  // Last resort: fall back to name-based lookup
  if (!method) {
    const key = `${operation.namespace?.name || ""}.${operation.name}`;
    method = operationMaps.byName.get(key);
  }
  
  return method?.crossLanguageDefinitionId;
}

/**
 * Convert scope string/object to ResourceScope enum
 */
function convertScopeToResourceScope(scope: string | ResolvedResource | undefined): ResourceScope {
  if (!scope) {
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
function getOperationScopeFromPath(path: string): ResourceScope {
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
  return ResourceScope.Tenant;
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
  const segments = path.split("/").filter(s => s.length > 0);
  const lastSegment = segments[segments.length - 1];
  
  // If the last segment is not a parameter (doesn't start with {), it's a singleton
  if (lastSegment && !lastSegment.startsWith("{")) {
    return lastSegment;
  }
  
  return undefined;
}

/**
 * Determine resource scope for list operations
 */
function getListResourceScope(listPath: string, resourceInstancePath: string): string | undefined {
  // If the list path is shorter than the resource instance path, it's listing at parent level
  if (listPath.length < resourceInstancePath.length && resourceInstancePath.startsWith(listPath)) {
    // Extract the parent path from the resource instance path
    const parentPath = resourceInstancePath.substring(0, resourceInstancePath.lastIndexOf("/"));
    if (listPath.startsWith(parentPath)) {
      return parentPath;
    }
  }
  
  return undefined;
}

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
  getClientType,
  getHttpOperationWithCache,
  getCrossLanguageDefinitionId
} from "@azure-tools/typespec-client-generator-core";

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
      const metadata = convertResolvedResourceToMetadata(sdkContext, resolvedResource);
      
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
      const methodId = getMethodIdFromOperation(sdkContext, operation.operation);
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
 * Converts a ResolvedResource to ResourceMetadata format
 */
function convertResolvedResourceToMetadata(
  sdkContext: CSharpEmitterContext,
  resolvedResource: ResolvedResource
): ResourceMetadata {
  const methods: ResourceMethod[] = [];
  const resourceScope = convertScopeToResourceScope(resolvedResource.scope);
  
  // Convert lifecycle operations
  if (resolvedResource.operations.lifecycle) {
    const lifecycle = resolvedResource.operations.lifecycle;
    
    if (lifecycle.read && lifecycle.read.length > 0) {
      for (const readOp of lifecycle.read) {
        const methodId = getMethodIdFromOperation(sdkContext, readOp.operation);
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
        const methodId = getMethodIdFromOperation(sdkContext, createOp.operation);
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
        const methodId = getMethodIdFromOperation(sdkContext, updateOp.operation);
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
        const methodId = getMethodIdFromOperation(sdkContext, deleteOp.operation);
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
      const methodId = getMethodIdFromOperation(sdkContext, listOp.operation);
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
      const methodId = getMethodIdFromOperation(sdkContext, actionOp.operation);
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
 * Get method ID (cross-language definition ID) from an Operation.
 * Uses TCGC's getHttpOperationWithCache to get the cached HttpOperation,
 * then extracts the cldi using getCrossLanguageDefinitionId.
 */
function getMethodIdFromOperation(
  sdkContext: CSharpEmitterContext,
  operation: Operation
): string | undefined {
  try {
    // First get the cached HttpOperation to ensure we're working with the consistent cached version
    const httpOperation = getHttpOperationWithCache(sdkContext, operation);
    if (!httpOperation) {
      return undefined;
    }
    
    // Then get the cross-language definition ID from the original operation
    // Using the cached httpOperation ensures consistency
    return getCrossLanguageDefinitionId(sdkContext, httpOperation.operation);
  } catch {
    // If this fails, return undefined
    return undefined;
  }
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

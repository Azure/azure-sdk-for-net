// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { isPrefix, isVariableSegment } from "./utils.js";

const ResourceGroupScopePrefix =
  "/subscriptions/{subscriptionId}/resourceGroups";
const SubscriptionScopePrefix = "/subscriptions";
const TenantScopePrefix = "/tenants";
const Providers = "/providers";

export function calculateResourceTypeFromPath(path: string): string {
  const providerIndex = path.lastIndexOf(Providers);
  if (providerIndex === -1) {
    if (path.startsWith(ResourceGroupScopePrefix)) {
      return "Microsoft.Resources/resourceGroups";
    } else if (path.startsWith(SubscriptionScopePrefix)) {
      return "Microsoft.Resources/subscriptions";
    } else if (path.startsWith(TenantScopePrefix)) {
      return "Microsoft.Resources/tenants";
    }
    throw `Path ${path} doesn't have resource type`;
  }

  return path
    .substring(providerIndex + Providers.length)
    .split("/")
    .reduce((result, current, index) => {
      if (index === 1 || index % 2 === 0)
        return result === "" ? current : `${result}/${current}`;
      else return result;
    }, "");
}

export enum ResourceScope {
  Tenant = "Tenant",
  Subscription = "Subscription",
  ResourceGroup = "ResourceGroup",
  ManagementGroup = "ManagementGroup",
  Extension = "Extension"
}

export interface ResourceMetadata {
  resourceIdPattern: string;
  resourceType: string;
  methods: ResourceMethod[];
  resourceScope: ResourceScope;
  parentResourceId?: string;
  parentResourceModelId?: string;
  singletonResourceName?: string;
  resourceName: string;
}

export function convertResourceMetadataToArguments(
  metadata: ResourceMetadata
): Record<string, any> {
  return {
    resourceIdPattern: metadata.resourceIdPattern,
    resourceType: metadata.resourceType,
    methods: metadata.methods,
    resourceScope: metadata.resourceScope,
    parentResourceId: metadata.parentResourceId,
    singletonResourceName: metadata.singletonResourceName,
    resourceName: metadata.resourceName
  };
}

export interface NonResourceMethod {
  methodId: string;
  operationPath: string;
  operationScope: ResourceScope;
}

export function convertMethodMetadataToArguments(
  metadata: NonResourceMethod[]
): Record<string, any> {
  return {
    nonResourceMethods: metadata.map((m) => ({
      methodId: m.methodId,
      operationPath: m.operationPath,
      operationScope: m.operationScope
    }))
  };
}

export interface ResourceMethod {
  /**
   * the crossLanguageDefinitionId of the corresponding input method
   */
  methodId: string;
  /**
   * the kind of this resource method
   */
  kind: ResourceOperationKind;
  /**
   * the path of this resource method
   */
  operationPath: string;
  /**
   * the scope of this resource method, it could be tenant/resource group/subscription/management group
   */
  operationScope: ResourceScope;
  /**
   * The maximum scope of this resource method.
   * The value of this could be a resource path pattern of an existing resource
   * or undefined
   */
  resourceScope?: string;
}

export enum ResourceOperationKind {
  Action = "Action",
  Create = "Create",
  Delete = "Delete",
  Read = "Read",
  List = "List",
  Update = "Update"
}

/**
 * Get the sort order for a resource operation kind.
 * Create operations come first, followed by other CRUD operations (Read, Update, Delete), then List, then Action.
 */
function getKindSortOrder(kind: ResourceOperationKind): number {
  switch (kind) {
    case ResourceOperationKind.Create:
      return 1;
    case ResourceOperationKind.Read:
      return 2;
    case ResourceOperationKind.Update:
      return 3;
    case ResourceOperationKind.Delete:
      return 4;
    case ResourceOperationKind.List:
      return 5;
    case ResourceOperationKind.Action:
      return 6;
    default:
      return 99;
  }
}

/**
 * Sort resource methods by kind (CRUD, List, Action) and then by methodId.
 * This ensures deterministic ordering of methods in generated code.
 */
export function sortResourceMethods(methods: ResourceMethod[]): void {
  methods.sort((a, b) => {
    // First, sort by kind
    const kindOrderA = getKindSortOrder(a.kind);
    const kindOrderB = getKindSortOrder(b.kind);

    if (kindOrderA !== kindOrderB) {
      return kindOrderA - kindOrderB;
    }

    // For methods with the same kind, sort by methodId
    return a.methodId.localeCompare(b.methodId);
  });
}

/**
 * Represents a resource in the ARM provider schema.
 */
export interface ArmResourceSchema {
  /**
   * The cross-language definition ID of the resource model
   */
  resourceModelId: string;
  /**
   * The resource metadata containing all information about the resource
   */
  metadata: ResourceMetadata;
}

/**
 * Represents the complete ARM provider schema containing all resources and non-resource methods.
 */
export interface ArmProviderSchema {
  /**
   * All resources in the ARM provider
   */
  resources: ArmResourceSchema[];
  /**
   * All non-resource methods in the ARM provider
   */
  nonResourceMethods: NonResourceMethod[];
}

/**
 * Converts ArmProviderSchema to decorator arguments.
 */
export function convertArmProviderSchemaToArguments(
  schema: ArmProviderSchema
): Record<string, any> {
  return {
    resources: schema.resources.map((r) => ({
      resourceModelId: r.resourceModelId,
      resourceIdPattern: r.metadata.resourceIdPattern,
      resourceType: r.metadata.resourceType,
      methods: r.metadata.methods.map((m) => ({
        methodId: m.methodId,
        kind: m.kind,
        operationPath: m.operationPath,
        operationScope: m.operationScope,
        resourceScope: m.resourceScope
      })),
      resourceScope: r.metadata.resourceScope,
      parentResourceId: r.metadata.parentResourceId,
      singletonResourceName: r.metadata.singletonResourceName,
      resourceName: r.metadata.resourceName
    })),
    nonResourceMethods: schema.nonResourceMethods.map((m) => ({
      methodId: m.methodId,
      operationPath: m.operationPath,
      operationScope: m.operationScope
    }))
  };
}

/**
 * Context for parent resource lookup during post-processing.
 * Different detection methods provide parent information differently.
 */
export interface ParentResourceLookupContext {
  /**
   * Gets the parent resource for a given resource.
   * Returns the parent ArmResourceSchema if found, undefined otherwise.
   */
  getParentResource(resource: ArmResourceSchema): ArmResourceSchema | undefined;
}

/**
 * Post-processes ARM resources to populate parent IDs, merge incomplete resources,
 * populate resource scopes, sort methods, and filter invalid resources.
 *
 * This is a shared post-processing step used by both resolveArmResources
 * and buildArmProviderSchema to ensure consistent behavior.
 *
 * @param resources - Initial list of resources to process
 * @param nonResourceMethods - Array to collect non-resource methods
 * @param parentLookup - Context for looking up parent resources
 * @returns Processed list of valid resources
 */
export function postProcessArmResources(
  resources: ArmResourceSchema[],
  nonResourceMethods: NonResourceMethod[],
  parentLookup: ParentResourceLookupContext
): ArmResourceSchema[] {
  // Step 1: Separate valid resources (with resourceIdPattern) from incomplete ones (without)
  const validResources = resources.filter(
    (r) => r.metadata.resourceIdPattern !== ""
  );
  const incompleteResources = resources.filter(
    (r) => r.metadata.resourceIdPattern === ""
  );

  // Step 2: Populate parentResourceId in all resources
  // Build a map for efficient parent lookup
  const validResourceMap = new Map<string, ArmResourceSchema>();
  for (const resource of validResources) {
    validResourceMap.set(resource.metadata.resourceIdPattern, resource);
  }

  for (const resource of resources) {
    // Use the provided parent lookup context to find parent
    const parentResource = parentLookup.getParentResource(resource);
    if (
      parentResource &&
      validResourceMap.has(parentResource.metadata.resourceIdPattern)
    ) {
      const parent = validResourceMap.get(
        parentResource.metadata.resourceIdPattern
      );
      if (parent) {
        resource.metadata.parentResourceId = parent.metadata.resourceIdPattern;
        resource.metadata.parentResourceModelId = parent.resourceModelId;
      }
    }
  }

  // Step 3: Merge incomplete resources to their parents or siblings
  for (const resource of incompleteResources) {
    const metadata = resource.metadata;
    let merged = false;

    // First try to merge with parent if it exists
    if (metadata.parentResourceModelId) {
      const parent = validResources.find(
        (r) => r.resourceModelId === metadata.parentResourceModelId
      );
      if (parent) {
        parent.metadata.methods.push(...metadata.methods);
        merged = true;
      }
    }

    if (!merged) {
      // No parent or parent not found - try to find another entry for the same model
      const sibling = validResources.find(
        (r) => r.resourceModelId === resource.resourceModelId
      );
      if (sibling) {
        sibling.metadata.methods.push(...metadata.methods);
        merged = true;
      }
    }

    // If there's no parent and no other entry to merge with, treat all methods as non-resource methods
    if (!merged) {
      for (const method of metadata.methods) {
        nonResourceMethods.push({
          methodId: method.methodId,
          operationPath: method.operationPath,
          operationScope: method.operationScope
        });
      }
    }
  }

  // Step 3.5: Reassign misplaced list operations to the correct resource
  // When the same model has multiple resources with different path segments
  // (e.g., publicMaintenanceConfigurations and maintenanceConfigurations),
  // the ARM library may assign list operations to the wrong resource.
  // Fix by matching the last path segment of the list operation (the resource type/collection
  // segment) with the resource type segment in each resource's ID pattern.
  reassignMisplacedListOperations(validResources);

  // Step 4: Populate resourceScope for all resource methods
  // For each method, find the longest matching resource path that is a prefix of the method's operation path
  for (const resource of validResources) {
    for (const method of resource.metadata.methods) {
      // Find all candidate resource paths that could be the scope for this method
      const candidates: string[] = [];
      for (const otherResource of validResources) {
        if (
          otherResource.metadata.resourceIdPattern &&
          isPrefix(
            otherResource.metadata.resourceIdPattern,
            method.operationPath
          )
        ) {
          candidates.push(otherResource.metadata.resourceIdPattern);
        }
      }
      // Use the longest resource path as the resourceScope
      if (candidates.length > 0) {
        method.resourceScope = candidates.reduce((a, b) =>
          a.length > b.length ? a : b
        );
      }
    }
  }

  // Step 5: Populate resourceScope for list operations specifically
  // This is a more targeted approach for list operations
  // first we find all the converted list operations
  const listOperations: ResourceMethod[] = [];
  for (const resource of validResources) {
    for (const method of resource.metadata.methods) {
      if (method.kind === ResourceOperationKind.List) {
        listOperations.push(method);
      }
    }
  }
  // then we gather all the resourceInstancePath for all resources as candidates
  const resourceInstancePaths: Array<string[]> = validResources.map((r) =>
    r.metadata.resourceIdPattern.split("/").filter((s) => s.length > 0)
  );

  // now we assign one of the most matched resourceInstancePath in above candidates to each list operation's resourceScope
  for (const listOp of listOperations) {
    const validCandidates: Array<string[]> = [];
    const listOperationPathSegments = listOp.operationPath
      .split("/")
      .filter((s) => s.length > 0);

    for (const candidatePath of resourceInstancePaths) {
      if (canBeListResourceScope(listOperationPathSegments, candidatePath)) {
        validCandidates.push(candidatePath);
      }
    }

    // Take the longest matching path as the resourceScope
    if (validCandidates.length > 0) {
      validCandidates.sort((a, b) => b.length - a.length);
      listOp.resourceScope = "/" + validCandidates[0].join("/");
    }
  }

  // Step 6: Sort methods in all valid resources for deterministic ordering
  // This is necessary because methods may have been merged from incomplete resources
  // and list operations may have been processed
  for (const resource of validResources) {
    sortResourceMethods(resource.metadata.methods);
  }

  // Step 7: Filter out resources without Get/Read operations (non-singleton resources only)
  // Singleton resources can exist without Get operations
  const filteredResources: ArmResourceSchema[] = [];
  for (const resource of validResources) {
    const hasReadOperation = resource.metadata.methods.some(
      (m) => m.kind === ResourceOperationKind.Read
    );
    if (!hasReadOperation && !resource.metadata.singletonResourceName) {
      // Try to move all methods to parent resource first, otherwise non-resource methods
      let movedToParent = false;

      if (resource.metadata.parentResourceId) {
        // Find parent resource
        const parent = validResources.find(
          (r) =>
            r.metadata.resourceIdPattern === resource.metadata.parentResourceId
        );
        if (parent) {
          // When moving operations to parent resource, convert them to Action kind
          // to avoid naming conflicts (parent might have its own Get/Delete/List methods)
          for (const method of resource.metadata.methods) {
            const movedMethod: ResourceMethod = {
              ...method,
              kind: ResourceOperationKind.Action
            };
            parent.metadata.methods.push(movedMethod);
          }
          movedToParent = true;
        }
      }

      // If no parent or parent not found, move to non-resource methods
      if (!movedToParent) {
        for (const method of resource.metadata.methods) {
          nonResourceMethods.push({
            methodId: method.methodId,
            operationPath: method.operationPath,
            operationScope: method.operationScope
          });
        }
      }
      continue;
    }
    filteredResources.push(resource);
  }

  // Re-sort methods in resources that may have received additional methods from filtered resources
  for (const resource of filteredResources) {
    sortResourceMethods(resource.metadata.methods);
  }

  return filteredResources;
}

/**
 * Helper function to determine if a resource path can be the scope for a list operation.
 * The resource path must be a prefix of the list operation path.
 */
function canBeListResourceScope(
  listPathSegments: string[],
  resourceInstancePathSegments: string[]
): boolean {
  // Check if resourceInstancePath is a prefix of listPath
  if (listPathSegments.length < resourceInstancePathSegments.length) {
    return false;
  }
  for (let i = 0; i < resourceInstancePathSegments.length; i++) {
    // if both segments are variables, we consider it as a match
    if (
      isVariableSegment(listPathSegments[i]) &&
      isVariableSegment(resourceInstancePathSegments[i])
    ) {
      continue;
    }
    // if one of them is a variable, the other is not, we consider it as not a match
    if (
      isVariableSegment(listPathSegments[i]) ||
      isVariableSegment(resourceInstancePathSegments[i])
    ) {
      return false;
    }
    // both are fixed strings, they must match
    if (listPathSegments[i] !== resourceInstancePathSegments[i]) {
      return false;
    }
  }
  // here it means every segment in resourceInstancePath matches the corresponding segment in listPath
  return true;
}

/**
 * Reassigns list operations that were assigned to the wrong resource.
 *
 * When the same model has multiple resources with different path segments
 * (e.g., `publicMaintenanceConfigurations` at subscription scope and
 * `maintenanceConfigurations` at resource-group scope), the ARM library may
 * assign list operations to the first resource it creates for that model,
 * even when the list path's resource type segment matches a different resource.
 *
 * This function fixes the assignment by comparing the last path segment of
 * each list operation (the collection/resource-type segment) with the resource
 * type segment in each resource's ID pattern (the second-to-last segment,
 * since the last segment is the key variable like `{resourceName}`).
 *
 * Only resources sharing the same `resourceModelId` are considered — list
 * operations are never moved across different models.
 */
function reassignMisplacedListOperations(
  validResources: ArmResourceSchema[]
): void {
  // Group resources by modelId — only models with multiple resources need checking
  const modelToResources = new Map<string, ArmResourceSchema[]>();
  for (const resource of validResources) {
    const existing = modelToResources.get(resource.resourceModelId) || [];
    existing.push(resource);
    modelToResources.set(resource.resourceModelId, existing);
  }

  for (const [, resourcesForModel] of modelToResources) {
    if (resourcesForModel.length <= 1) continue;

    // Build a map from resource type segment to resource.
    // The resource type segment is the second-to-last segment of the resource ID pattern
    // (e.g., "maintenanceConfigurations" from ".../maintenanceConfigurations/{resourceName}").
    // If multiple resources share the same type segment, mark it as ambiguous (null)
    // so we don't incorrectly reassign.
    const typeSegmentToResource = new Map<string, ArmResourceSchema | null>();
    for (const resource of resourcesForModel) {
      if (resource.metadata.resourceIdPattern) {
        const typeSegment = getResourceTypeSegment(
          resource.metadata.resourceIdPattern
        );
        if (typeSegment) {
          const key = typeSegment.toLowerCase();
          if (typeSegmentToResource.has(key)) {
            // Collision — mark as ambiguous
            typeSegmentToResource.set(key, null);
          } else {
            typeSegmentToResource.set(key, resource);
          }
        }
      }
    }

    // For each resource, check if any of its list operations should be moved
    for (const resource of resourcesForModel) {
      const listsToRemove: ResourceMethod[] = [];

      for (const method of resource.metadata.methods) {
        if (method.kind !== ResourceOperationKind.List) continue;

        const listTypeSegment = getLastPathSegment(method.operationPath);
        if (!listTypeSegment) continue;

        const targetResource = typeSegmentToResource.get(
          listTypeSegment.toLowerCase()
        );
        if (targetResource && targetResource !== resource) {
          listsToRemove.push(method);
          targetResource.metadata.methods.push(method);
        }
      }

      if (listsToRemove.length > 0) {
        resource.metadata.methods = resource.metadata.methods.filter(
          (m) => !listsToRemove.includes(m)
        );
      }
    }
  }
}

/**
 * Gets the resource type segment from a resource ID pattern.
 * The type segment is the second-to-last segment, since the last is the key variable.
 * E.g., for ".../maintenanceConfigurations/{resourceName}", returns "maintenanceConfigurations".
 */
function getResourceTypeSegment(resourceIdPattern: string): string | undefined {
  const segments = resourceIdPattern.split("/").filter((s) => s !== "");
  if (segments.length < 2) return undefined;
  return segments[segments.length - 2];
}

/**
 * Gets the last segment of a path.
 * For list operation paths, this is the resource type/collection segment.
 * E.g., for ".../maintenanceConfigurations", returns "maintenanceConfigurations".
 */
function getLastPathSegment(path: string): string | undefined {
  const segments = path.split("/").filter((s) => s !== "");
  if (segments.length === 0) return undefined;
  return segments[segments.length - 1];
}

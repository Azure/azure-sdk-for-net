// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  isVariableSegment,
  isPrefix,
  findLongestPrefixMatch,
  countProviderSegments
} from "./utils.js";
import {
  DecoratedType,
  getClientOptions
} from "@azure-tools/typespec-client-generator-core";

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

/**
 * Constraints on the resource name from TypeSpec @pattern, @minLength, @maxLength decorators.
 */
export interface NameConstraints {
  /** The regex pattern constraint for the resource name, from @pattern decorator */
  pattern?: string;
  /** The minimum length constraint for the resource name, from @minLength decorator */
  minLength?: number;
  /** The maximum length constraint for the resource name, from @maxLength decorator */
  maxLength?: number;
}

/**
 * Represents a single RBAC role definition for a resource.
 */
export interface RbacRole {
  /** The role name (e.g., "KeyVaultContributor") */
  name: string;
  /** The role GUID (e.g., "f25e0fa2-a7c8-4377-a976-54943a77a395") */
  value: string;
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
  /** The expected parent resource type for extension resources with specific parent types (e.g., "Microsoft.Compute/virtualMachines") */
  // TODO: consider to calculate this in generator directly within RequestPathPattern instead of carrying it through emitter and post-processing
  parentResourceType?: string;
  /** The name constraints for the resource, from TypeSpec decorators */
  nameConstraints: NameConstraints;
  /** The API versions that this resource is available in */
  apiVersions: string[];
  /** The RBAC roles defined for this resource via @@clientOption */
  rbacRoles: RbacRole[];
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

const rbacRolesKey = "resource-rbac-roles";

/**
 * Extracts RBAC roles from a model's @@clientOption decorator with key "resource-rbac-roles".
 * Uses TCGC's getClientOptions API which handles scope filtering.
 * The value is expected to be a record of role name to role GUID.
 */
export function extractRbacRoles(model: DecoratedType | undefined): RbacRole[] {
  if (!model) return [];
  const value = getClientOptions(model, rbacRolesKey);
  if (!value || typeof value !== "object") return [];
  return Object.entries(value as Record<string, string>).map(
    ([name, guid]) => ({
      name,
      value: guid
    })
  );
}

export interface NonResourceMethod {
  methodId: string;
  operationPath: string;
  operationScope: ResourceScope;
  /** The cross-language definition ID of the resource model this method originally belonged to */
  resourceModelId?: string;
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
 * Resolves the API versions for a resource from its methods.
 * Uses the Create method's versions if available, otherwise falls back to the Read method's versions.
 * @param methods - The resource's methods
 * @param methodApiVersionsMap - A map from methodId to its API versions
 * @returns The API versions for the resource
 */
export function resolveResourceApiVersions(
  methods: ResourceMethod[],
  methodApiVersionsMap: Map<string, string[]>
): string[] {
  const createMethod = methods.find(
    (m) => m.kind === ResourceOperationKind.Create
  );
  const readMethod = methods.find((m) => m.kind === ResourceOperationKind.Read);
  const primaryMethod = createMethod ?? readMethod;
  return primaryMethod
    ? methodApiVersionsMap.get(primaryMethod.methodId) ?? []
    : [];
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
      parentResourceType: r.metadata.parentResourceType,
      singletonResourceName: r.metadata.singletonResourceName,
      resourceName: r.metadata.resourceName,
      nameConstraints: r.metadata.nameConstraints,
      apiVersions: r.metadata.apiVersions,
      rbacRoles: r.metadata.rbacRoles
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
  parentLookup: ParentResourceLookupContext,
  methodResponseModelIdMap?: Map<string, string>
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
    // Skip if parentResourceId was already set by the caller (e.g., path-based detection
    // in legacy resource detection). This preserves scope-accurate parent assignments for
    // cross-scope resources where the same model exists at multiple scopes (e.g., tenant
    // and subscription), since path-based detection picks the correct scope variant.
    if (resource.metadata.parentResourceId) continue;

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
          operationScope: method.operationScope,
          resourceModelId: resource.resourceModelId
        });
      }
    }
  }

  // Step 3.5: Relocate cross-resource list actions
  // When a spec models a list-children operation as an Action on a parent resource
  // (e.g., blobContainersList as ArmResourceActionSync on BlobService that lists BlobContainers),
  // detect that the Action's operationPath matches a child resource's collection path
  // and reclassify it as a List on the child resource.
  relocateCrossResourceListActions(validResources, methodResponseModelIdMap);

  // Step 4: Populate resourceScope for all resource methods
  // For each method, find the longest matching resource path that is a prefix of the method's operation path
  for (const resource of validResources) {
    for (const method of resource.metadata.methods) {
      const bestMatch = findLongestPrefixMatch(
        method.operationPath,
        validResources,
        (r) => r.metadata.resourceIdPattern || undefined
      );
      if (bestMatch) {
        method.resourceScope = bestMatch.metadata.resourceIdPattern;
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
            operationScope: method.operationScope,
            resourceModelId: resource.resourceModelId
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

  // Step 8: Compute parentResourceType for extension resources with specific parent types
  for (const resource of filteredResources) {
    if (countProviderSegments(resource.metadata.resourceIdPattern) > 1) {
      resource.metadata.parentResourceType = getExpectedParentResourceType(
        resource.metadata.resourceIdPattern
      );
    }
  }

  return filteredResources;
}

/**
 * Assigns non-resource methods to resources based on three matching strategies:
 * 1. Prefix matching: if the method's operationPath has a prefix that matches a resource's
 *    resourceIdPattern, the method is moved to that resource as an Action.
 * 2. Resource model ID matching: if prefix matching fails but the method has a resourceModelId,
 *    it is matched to a valid resource with the same model ID and assigned as a List operation.
 *    This handles extension resources where list paths have different parent structures.
 * 3. Resource type matching: if both prefix and model ID matching fail, the resource type
 *    is extracted from the operation path using calculateResourceTypeFromPath (which includes
 *    the provider namespace) and compared against each resource's metadata.resourceType.
 *    The provider hierarchy depth must also match to prevent cross-scope false matches.
 *    This handles operations from resolveArmResources that lack resourceModelId but share
 *    a resource type with a known resource.
 *
 * @param resources - The list of valid resources
 * @param nonResourceMethods - The array of non-resource methods (will be mutated: matched methods are removed)
 */
export function assignNonResourceMethodsToResources(
  resources: ArmResourceSchema[],
  nonResourceMethods: NonResourceMethod[]
): void {
  const methodsToRemove = new Set<string>();

  for (const method of nonResourceMethods) {
    const bestMatch = findLongestPrefixMatch(
      method.operationPath,
      resources,
      (r) => r.metadata.resourceIdPattern || undefined,
      true
    );

    if (bestMatch) {
      bestMatch.metadata.methods.push({
        methodId: method.methodId,
        kind: ResourceOperationKind.Action,
        operationPath: method.operationPath,
        operationScope: method.operationScope,
        resourceScope: bestMatch.metadata.resourceIdPattern
      });
      methodsToRemove.add(method.methodId);
    } else if (method.resourceModelId) {
      // Prefix matching failed — try matching by resource model ID.
      // This handles extension resources where the list path and resource ID pattern
      // have different parent path structures but originate from the same resource type.
      const match = resources.find(
        (r) => r.resourceModelId === method.resourceModelId
      );
      if (match) {
        match.metadata.methods.push({
          methodId: method.methodId,
          kind: ResourceOperationKind.List,
          operationPath: method.operationPath,
          operationScope: method.operationScope,
          resourceScope: undefined
        });
        methodsToRemove.add(method.methodId);
      }
    } else {
      // Both prefix and model ID matching failed — try matching by resource type.
      // Extension resource list paths may have fewer parent segments than the resource
      // ID pattern, causing a structural length mismatch that prefix matching cannot resolve.
      // As a final fallback, compare the resource type (extracted via calculateResourceTypeFromPath,
      // which includes the provider namespace) against each resource's metadata.resourceType.
      // The provider hierarchy depth must also match to prevent cross-scope false matches
      // (e.g., RG-scoped list matching a VM-scoped extension resource).
      if (method.operationPath.includes("/providers/")) {
        const operationType = calculateResourceTypeFromPath(
          method.operationPath
        );
        const operationProviderDepth = countProviderSegments(
          method.operationPath
        );
        const match = resources.find((r) => {
          if (
            countProviderSegments(r.metadata.resourceIdPattern) !==
            operationProviderDepth
          ) {
            return false;
          }
          return r.metadata.resourceType === operationType;
        });
        if (match) {
          match.metadata.methods.push({
            methodId: method.methodId,
            kind: ResourceOperationKind.List,
            operationPath: method.operationPath,
            operationScope: method.operationScope,
            resourceScope: undefined
          });
          methodsToRemove.add(method.methodId);
        }
      }
    }
  }

  // Remove matched methods from non-resource methods array
  if (methodsToRemove.size > 0) {
    for (let i = nonResourceMethods.length - 1; i >= 0; i--) {
      if (methodsToRemove.has(nonResourceMethods[i].methodId)) {
        nonResourceMethods.splice(i, 1);
      }
    }

    // Re-sort methods in resources that received new methods
    for (const resource of resources) {
      sortResourceMethods(resource.metadata.methods);
    }
  }
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
 * Detects List methods that are assigned to the wrong resource and relocates
 * them to the correct child resource.
 *
 * This handles the pattern where a TypeSpec spec models a list-children operation
 * as an ArmResourceActionSync on a parent resource (e.g., blobContainersList on
 * BlobService). The operation is already classified as List by parseResourceOperation
 * (because TCGC detects it as pageable), but is assigned to the parent resource
 * because @armResourceAction points to the parent model.
 *
 * The detection checks two conditions:
 * 1. The operation is pageable (already ensured by kind=List from parseResourceOperation)
 * 2. The operationPath matches a child resource's collection path (resourceIdPattern
 *    minus the last /{parameter} segment)
 *
 * Example:
 *   - Container resourceIdPattern: .../blobServices/default/containers/{containerName}
 *   - Container collection path:   .../blobServices/default/containers
 *   - List operationPath:          .../blobServices/default/containers  ← match!
 *   - Result: List is moved from BlobService to Container
 */
function relocateCrossResourceListActions(
  validResources: ArmResourceSchema[],
  methodResponseModelIdMap?: Map<string, string>
): void {
  // Find List methods that are assigned to the wrong resource and should be
  // relocated to a child resource. This handles the case where a pageable
  // operation uses @armResourceAction on a parent resource (e.g., BlobService)
  // but actually lists child resources (e.g., BlobContainers). The operation
  // is already classified as List (because it's pageable) but is on the wrong
  // resource because @armResourceAction points to the parent model.
  const relocations: Array<{
    sourceResource: ArmResourceSchema;
    targetResource: ArmResourceSchema;
    method: ResourceMethod;
  }> = [];

  for (const resource of validResources) {
    for (const method of resource.metadata.methods) {
      if (method.kind !== ResourceOperationKind.List) continue;

      // Find the child resource whose resourceIdPattern is exactly this
      // operation's path plus one variable segment (the resource name).
      // This means the operation is at the child resource's collection path.
      for (const candidate of validResources) {
        if (candidate === resource) continue;
        if (
          !isPrefix(method.operationPath, candidate.metadata.resourceIdPattern)
        )
          continue;
        // Ensure the difference is exactly one segment (the resource name)
        const opSegments = method.operationPath
          .split("/")
          .filter((s) => s.length > 0);
        const resSegments = candidate.metadata.resourceIdPattern
          .split("/")
          .filter((s) => s.length > 0);
        if (resSegments.length !== opSegments.length + 1) continue;
        // The additional segment must be a variable segment (e.g. `{resourceName}`)
        const lastSegment = resSegments[resSegments.length - 1];
        if (!isVariableSegment(lastSegment)) continue;

        // Verify the response item type matches the target resource's model.
        // This prevents relocating pageable actions that return metadata models
        // (not the resource type) to the wrong collection.
        if (methodResponseModelIdMap) {
          const responseModelId = methodResponseModelIdMap.get(method.methodId);
          if (responseModelId && responseModelId !== candidate.resourceModelId)
            continue;
        }

        relocations.push({
          sourceResource: resource,
          targetResource: candidate,
          method: method
        });
        break;
      }
    }
  }

  // Apply relocations: move methods from source to target
  for (const { sourceResource, targetResource, method } of relocations) {
    // Remove from source
    const sourceIndex = sourceResource.metadata.methods.indexOf(method);
    if (sourceIndex >= 0) {
      sourceResource.metadata.methods.splice(sourceIndex, 1);
    }

    // Add to target (already classified as List)
    targetResource.metadata.methods.push(method);
  }
}

/**
 * Extracts the expected parent resource type from a resource ID pattern that is
 * already known to have multiple /providers/ segments. Returns undefined if the
 * parent segment is not a simple `<namespace>/<type>/{name}` pattern (e.g., for
 * complex paths with nested types or mixed scopes).
 *
 * For example, for a pattern like:
 * /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vm}/providers/MyService/resources/{name}
 * This returns "Microsoft.Compute/virtualMachines".
 */
function getExpectedParentResourceType(
  resourceIdPattern: string
): string | undefined {
  // Find the last /providers/ segment (the extension resource's own provider)
  const lastProvidersIndex = resourceIdPattern.lastIndexOf("/providers/");

  // Find the second-to-last /providers/ segment (the parent resource's provider)
  const parentProvidersIndex = resourceIdPattern.lastIndexOf(
    "/providers/",
    lastProvidersIndex - 1
  );

  if (parentProvidersIndex === -1) {
    return undefined;
  }

  // Extract the parent segment between the two /providers/ markers
  const parentSegment = resourceIdPattern.substring(
    parentProvidersIndex + "/providers/".length,
    lastProvidersIndex
  );

  const segments = parentSegment.split("/");

  // Simple case: "<namespace>/<type>/{name}" — e.g., Microsoft.Compute/virtualMachines/{vmName}
  if (segments.length === 3) {
    const [providerNamespace, resourceType, nameSegment] = segments;
    if (
      providerNamespace.includes("{") ||
      resourceType.includes("{") ||
      !nameSegment.startsWith("{") ||
      !nameSegment.endsWith("}")
    ) {
      return undefined;
    }
    return `${providerNamespace}/${resourceType}`;
  }

  // Complex case: parent path between providers has more segments
  // (e.g., Microsoft.Management/managementGroups/{mgId}/subscriptions/{subId})
  // Fall back to computing the parent scope's resource type from the resource ID pattern.
  // Remove the leaf type/name pair, then extract the resource type from the last /providers/ segment.
  const allSegments = resourceIdPattern.split("/").filter((s) => s !== "");
  // Remove the last two segments (leaf type and name, e.g., "quotaAllocations" and "{location}")
  if (allSegments.length < 2) {
    return undefined;
  }
  const parentPathSegments = allSegments.slice(0, -2);
  const parentPath = "/" + parentPathSegments.join("/");

  // Find the last /providers/ in the parent path
  const parentLastProvidersIndex = parentPath.lastIndexOf("/providers/");
  if (parentLastProvidersIndex === -1) {
    return undefined;
  }

  // Extract everything after the last /providers/ in parent path
  const afterProviders = parentPath
    .substring(parentLastProvidersIndex + "/providers/".length)
    .split("/");

  // Must have at least namespace/type/{name} (3 segments)
  if (afterProviders.length < 3) {
    return undefined;
  }

  const namespace = afterProviders[0];
  // Namespace must be a constant
  if (namespace.includes("{")) {
    return undefined;
  }

  // Collect constant type segments (every other segment starting at index 1)
  const typeSegments: string[] = [];
  for (let i = 1; i < afterProviders.length; i += 2) {
    const typeSeg = afterProviders[i];
    if (typeSeg.includes("{")) {
      return undefined; // variable type segment — can't determine parent type
    }
    typeSegments.push(typeSeg);
  }

  if (typeSegments.length === 0) {
    return undefined;
  }

  return `${namespace}/${typeSegments.join("/")}`;
}

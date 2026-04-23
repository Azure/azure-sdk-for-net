// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  DecoratedType,
  getClientOptions
} from "@azure-tools/typespec-client-generator-core";

// ─── Path utilities ─────────────────────────────────────────────────────────

/**
 * Returns true if the segment is a variable segment like {subscriptionId}
 * @param segment the segment
 */
export function isVariableSegment(segment: string): boolean {
  return segment.startsWith("{") && segment.endsWith("}");
}

/**
 * Represents a parsed ARM request path with pre-computed segment information.
 *
 * This class parses a path string (e.g., "/subscriptions/{subscriptionId}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}")
 * once and caches the resulting segments, avoiding repeated `.split("/")` calls throughout the codebase.
 *
 * Inspired by the C# generator's RequestPathPattern class, it consolidates path parsing,
 * prefix matching, scope detection, and resource type extraction in a single place.
 */
export class RequestPath {
  /** A shared empty RequestPath instance (represents tenant scope) */
  public static readonly empty = new RequestPath("");

  /** Creates a RequestPath from pre-computed segments */
  static fromSegments(segments: readonly string[]): RequestPath {
    return segments.length === 0
      ? RequestPath.empty
      : new RequestPath("/" + segments.join("/"));
  }

  /** The non-empty path segments (e.g., ["subscriptions", "{subscriptionId}", "providers", ...]) */
  public readonly segments: readonly string[];

  /** The original raw path string */
  public readonly path: string;

  constructor(path: string) {
    this.path = path;
    this.segments = path.split("/").filter((s) => s.length > 0);
  }

  /** Serializes to the raw path string (used by JSON.stringify) */
  toJSON(): string {
    return this.path;
  }

  /** Number of segments in this path */
  get length(): number {
    return this.segments.length;
  }

  /**
   * Returns true if this path is a prefix of the other path.
   * Variable segments are considered as matches regardless of their names.
   */
  isPrefixOf(other: RequestPath): boolean {
    const sharedCount = this.getSharedSegmentCount(other);
    return sharedCount === this.length && sharedCount <= other.length;
  }

  /**
   * Returns the number of leading segments shared with another path.
   * Variable segments are considered as matches regardless of their names.
   */
  getSharedSegmentCount(other: RequestPath): number {
    let count = 0;
    const minLength = Math.min(this.length, other.length);
    for (let i = 0; i < minLength; i++) {
      if (
        isVariableSegment(this.segments[i]) &&
        isVariableSegment(other.segments[i])
      ) {
        count++;
      } else if (this.segments[i] === other.segments[i]) {
        count++;
      } else {
        break;
      }
    }
    return count;
  }

  /**
   * Extracts the singleton resource name from this path, if it exists.
   * A path ending with a fixed (non-variable) segment indicates a singleton resource.
   */
  get singletonName(): string | undefined {
    const lastSeg =
      this.length > 0 ? this.segments[this.length - 1] : undefined;
    if (lastSeg && !isVariableSegment(lastSeg)) {
      return lastSeg;
    }
    return undefined;
  }

  /**
   * Returns true if this path is structurally equal to the other path.
   * Variable segments are considered matching regardless of their names,
   * e.g., "/subscriptions/{sub}" equals "/subscriptions/{subscriptionId}".
   */
  equals(other: RequestPath): boolean {
    if (this.length !== other.length) return false;
    for (let i = 0; i < this.length; i++) {
      if (
        isVariableSegment(this.segments[i]) &&
        isVariableSegment(other.segments[i])
      ) {
        continue;
      }
      if (this.segments[i] !== other.segments[i]) return false;
    }
    return true;
  }

  /**
   * Gets the scope path — the portion of the path before the last "/providers/" segment.
   * E.g., for ".../providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/...",
   * the scope is ".../providers/Microsoft.Compute/virtualMachines/{vmName}".
   * Returns an empty RequestPath if the path has no "/providers/" segment (tenant scope).
   */
  get scopePath(): RequestPath {
    // Find the last "providers" segment index
    let lastProvidersIndex = -1;
    for (let i = 0; i < this.segments.length; i++) {
      if (this.segments[i].toLowerCase() === "providers") {
        lastProvidersIndex = i;
      }
    }
    if (lastProvidersIndex < 0) return RequestPath.empty;
    return RequestPath.fromSegments(this.segments.slice(0, lastProvidersIndex));
  }

  /**
   * Returns true if this path has the same scope nesting structure as the other path.
   * Two paths are scope-compatible if their scope chains have the same depth:
   * both have no scope (no /providers/), or both have scopes that are themselves scope-compatible.
   *
   * This correctly distinguishes:
   * - RG-scoped vs MG-scoped resources (different scope chain shapes)
   * - Direct RG resources vs extension resources nested under RG (different depths)
   * while still allowing structural parent-length mismatches within the same scope level
   * (e.g., extension resource list endpoints with fewer parent segments).
   */
  hasSameScopeNesting(other: RequestPath): boolean {
    const scopeA = this.scopePath;
    const scopeB = other.scopePath;
    if (scopeA.length === 0 && scopeB.length === 0) return true;
    if (scopeA.length === 0 || scopeB.length === 0) return false;
    return scopeA.hasSameScopeNesting(scopeB);
  }

  /**
   * Extracts the ARM resource type from this path.
   * E.g., for ".../providers/Microsoft.Compute/virtualMachines/{vmName}", returns "Microsoft.Compute/virtualMachines".
   *
   * For paths without a "/providers/" segment, returns well-known resource types
   * for resourceGroups, subscriptions, and tenants.
   * Returns undefined for paths with no determinable resource type (e.g., /{resourceUri}).
   */
  get resourceType(): string | undefined {
    // Find the last "providers" segment index
    let lastProvidersIndex = -1;
    for (let i = 0; i < this.segments.length; i++) {
      if (this.segments[i].toLowerCase() === "providers") {
        lastProvidersIndex = i;
      }
    }

    if (lastProvidersIndex === -1) {
      // No providers segment — return well-known resource types
      if (this.segments.length === 0) {
        return "Microsoft.Resources/tenants";
      } else if (
        this.segments.length >= 3 &&
        this.segments[0] === "subscriptions" &&
        this.segments[2] === "resourceGroups"
      ) {
        return "Microsoft.Resources/resourceGroups";
      } else if (this.segments[0] === "subscriptions") {
        return "Microsoft.Resources/subscriptions";
      } else if (this.segments[0] === "tenants") {
        return "Microsoft.Resources/tenants";
      }
      return undefined;
    }

    // Segments after "providers": [namespace, type1, {name1}, type2, {name2}, ...]
    // Resource type = namespace/type1/type2/...  (index 0, then odd indices 1, 3, 5, ...)
    const afterProviders = this.segments.slice(lastProvidersIndex + 1);
    const typeParts: string[] = [];
    if (afterProviders.length > 0) {
      typeParts.push(afterProviders[0]); // namespace
      for (let i = 1; i < afterProviders.length; i += 2) {
        typeParts.push(afterProviders[i]); // type segments at odd indices
      }
    }
    return typeParts.join("/");
  }

  /**
   * Determines the operation scope (Tenant, Subscription, ResourceGroup, ManagementGroup, Extension)
   * from the path structure by examining the scope path (portion before the last /providers/ segment).
   */
  get operationScope(): ResourceScopeKind {
    const scope = this.scopePath;

    // No scope (no /providers/ segment) — tenant scope
    if (scope.length === 0) return ResourceScopeKind.Tenant;

    // Check the immediate scope against well-known patterns.
    // If the scope doesn't match any known pattern (e.g., it contains another /providers/
    // segment like nested extension resources), it's an Extension.
    if (scope.equals(ResourceGroupScope))
      return ResourceScopeKind.ResourceGroup;
    if (scope.equals(SubscriptionScope)) return ResourceScopeKind.Subscription;
    if (scope.equals(ManagementGroupScope))
      return ResourceScopeKind.ManagementGroup;

    // Everything else is an extension resource
    return ResourceScopeKind.Extension;
  }

  /**
   * Returns a new RequestPath with the last segment removed.
   * E.g., for ".../virtualMachines/{vmName}", returns ".../virtualMachines".
   * Returns undefined if the path has fewer than 2 segments.
   */
  get trimLastSegment(): RequestPath | undefined {
    if (this.length <= 1) return undefined;
    return RequestPath.fromSegments(this.segments.slice(0, -1));
  }

  toString(): string {
    return this.path;
  }
}

// Well-known scope paths for operationScope detection
const ResourceGroupScope = new RequestPath(
  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
);
const SubscriptionScope = new RequestPath("/subscriptions/{subscriptionId}");
const ManagementGroupScope = new RequestPath(
  "/providers/Microsoft.Management/managementGroups/{managementGroupId}"
);

/**
 * Finds the candidate whose path is the longest prefix match against the target path.
 * @param targetPath the path to match against
 * @param candidates the list of candidates to search
 * @param getPath extracts the path from a candidate; return undefined to skip
 * @param properPrefix if true, requires the candidate path to be a proper prefix (not equal)
 * @returns the best matching candidate, or undefined if no match
 */
export function findLongestPrefixMatch<T>(
  targetPath: RequestPath,
  candidates: T[],
  getPath: (candidate: T) => RequestPath | undefined,
  properPrefix: boolean = false
): T | undefined {
  let bestMatch: T | undefined;
  let bestSegmentCount = 0;

  for (const candidate of candidates) {
    const candidatePath = getPath(candidate);
    if (!candidatePath) continue;
    // Check if candidate is a prefix of the target path
    if (!candidatePath.isPrefixOf(targetPath)) continue;
    // If properPrefix is set, skip candidates that are equal to the target (require strictly shorter)
    if (properPrefix && targetPath.isPrefixOf(candidatePath)) continue;

    // Since candidatePath is confirmed to be a prefix of targetPath,
    // all of its segments match — so candidatePath.length is the shared count.
    if (candidatePath.length > bestSegmentCount) {
      bestSegmentCount = candidatePath.length;
      bestMatch = candidate;
    }
  }
  return bestMatch;
}

export enum ResourceScopeKind {
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

/**
 * Describes the ARM scope of a resource, including the scope kind and the scope's ID pattern.
 */
export interface ArmScopeInfo {
  /** The kind of scope (Tenant, Subscription, ResourceGroup, ManagementGroup, Extension) */
  kind: ResourceScopeKind;
  /** The scope's ID pattern path */
  scopeIdPattern: RequestPath;
  /**
   * The ARM resource type of the scope (e.g., "Microsoft.Compute/virtualMachines").
   * Undefined when the resource type contains variable segments (e.g., "{parentProviderNamespace}/{parentResourceType}").
   */
  scopeResourceType?: string;
}

export interface ResourceMetadata {
  resourceIdPattern?: RequestPath;
  resourceType: string;
  methods: ResourceMethod[];
  scope: ArmScopeInfo;
  parentResourceId?: RequestPath;
  parentResourceModelId?: string;
  singletonResourceName?: string;
  resourceName: string;
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
    resourceIdPattern: metadata.resourceIdPattern?.path,
    resourceType: metadata.resourceType,
    methods: metadata.methods.map((m) => ({
      methodId: m.methodId,
      kind: m.kind,
      operationPath: m.operationPath.path,
      scope: {
        kind: m.scope.kind,
        scopeIdPattern: m.scope.scopeIdPattern.path,
        scopeResourceType: m.scope.scopeResourceType
      }
    })),
    scope: {
      kind: metadata.scope.kind,
      scopeIdPattern: metadata.scope.scopeIdPattern.path,
      scopeResourceType: metadata.scope.scopeResourceType
    },
    parentResourceId: metadata.parentResourceId?.path,
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

const nameConstraintKey = "resource-name-constraint";

/**
 * Extracts name constraints from a model's @@clientOption decorator with key "resource-name-constraint".
 * Uses TCGC's getClientOptions API which handles scope filtering.
 * The value is expected to be a record with optional pattern, minLength, and maxLength fields.
 * Returns undefined if no clientOption is set.
 */
export function extractNameConstraintOverrides(
  model: DecoratedType | undefined
): NameConstraints | undefined {
  if (!model) return undefined;
  const value = getClientOptions(model, nameConstraintKey);
  if (!value || typeof value !== "object") return undefined;
  const record = value as Record<string, unknown>;
  return {
    pattern:
      typeof record["pattern"] === "string" ? record["pattern"] : undefined,
    minLength:
      typeof record["minLength"] === "number" ? record["minLength"] : undefined,
    maxLength:
      typeof record["maxLength"] === "number" ? record["maxLength"] : undefined
  };
}

export interface NonResourceMethod {
  methodId: string;
  operationPath: RequestPath;
  scope: ArmScopeInfo;
  /** The cross-language definition ID of the resource model this method originally belonged to */
  resourceModelId?: string;
}

export function convertMethodMetadataToArguments(
  metadata: NonResourceMethod[]
): Record<string, any> {
  return {
    nonResourceMethods: metadata.map((m) => ({
      methodId: m.methodId,
      operationPath: m.operationPath.path,
      scope: {
        kind: m.scope.kind,
        scopeIdPattern: m.scope.scopeIdPattern.path,
        scopeResourceType: m.scope.scopeResourceType
      }
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
  operationPath: RequestPath;
  /**
   * the scope of this resource method
   */
  scope: ArmScopeInfo;
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
 * An ArmResourceSchema that has been validated to have a resourceIdPattern.
 * After post-processing, all resources in the final schema are guaranteed to have this.
 */
export type ValidArmResourceSchema = ArmResourceSchema & {
  metadata: ResourceMetadata & { resourceIdPattern: RequestPath };
};

/**
 * Represents the complete ARM provider schema containing all resources and non-resource methods.
 */
export interface ArmProviderSchema {
  /**
   * All resources in the ARM provider
   */
  resources: ValidArmResourceSchema[];
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
      resourceIdPattern: r.metadata.resourceIdPattern?.path,
      resourceType: r.metadata.resourceType,
      methods: r.metadata.methods.map((m) => ({
        methodId: m.methodId,
        kind: m.kind,
        operationPath: m.operationPath.path,
        scope: {
          kind: m.scope.kind,
          scopeIdPattern: m.scope.scopeIdPattern.path,
          scopeResourceType: m.scope.scopeResourceType
        }
      })),
      scope: {
        kind: r.metadata.scope.kind,
        scopeIdPattern: r.metadata.scope.scopeIdPattern.path,
        scopeResourceType: r.metadata.scope.scopeResourceType
      },
      parentResourceId: r.metadata.parentResourceId?.path,
      singletonResourceName: r.metadata.singletonResourceName,
      resourceName: r.metadata.resourceName,
      nameConstraints: r.metadata.nameConstraints,
      apiVersions: r.metadata.apiVersions,
      rbacRoles: r.metadata.rbacRoles
    })),
    nonResourceMethods: schema.nonResourceMethods.map((m) => ({
      methodId: m.methodId,
      operationPath: m.operationPath.path,
      scope: {
        kind: m.scope.kind,
        scopeIdPattern: m.scope.scopeIdPattern.path,
        scopeResourceType: m.scope.scopeResourceType
      }
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
): ValidArmResourceSchema[] {
  // Step 1: Separate valid resources (with resourceIdPattern) from incomplete ones (without)
  const validResources = resources.filter(
    (r): r is ValidArmResourceSchema =>
      r.metadata.resourceIdPattern !== undefined
  );
  const incompleteResources = resources.filter(
    (r) => r.metadata.resourceIdPattern === undefined
  );

  // Step 2: Populate parentResourceId in all resources
  // Build a map for efficient parent lookup
  const validResourceMap = new Map<string, ArmResourceSchema>();
  for (const resource of validResources) {
    validResourceMap.set(resource.metadata.resourceIdPattern!.path, resource);
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
      parentResource.metadata.resourceIdPattern &&
      validResourceMap.has(parentResource.metadata.resourceIdPattern.path)
    ) {
      const parent = validResourceMap.get(
        parentResource.metadata.resourceIdPattern.path
      );
      if (parent && parent.metadata.resourceIdPattern) {
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
          scope: method.scope,
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

  // Step 4: Populate scope.scopeIdPattern for all resource methods
  // For each method, find the longest matching resource path that is a prefix of the method's operation path
  for (const resource of validResources) {
    for (const method of resource.metadata.methods) {
      const bestMatch = findLongestPrefixMatch(
        method.operationPath,
        validResources,
        (r) => r.metadata.resourceIdPattern
      );
      if (bestMatch) {
        method.scope = {
          ...method.scope,
          scopeIdPattern: bestMatch.metadata.resourceIdPattern!
        };
      }
    }
  }

  // Step 5: Populate scope.scopeIdPattern for list operations specifically
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
  // then we gather all the resourceInstancePath for all resources
  const resourceInstancePaths: RequestPath[] = validResources.map(
    (r) => r.metadata.resourceIdPattern!
  );

  // now we assign one of the most matched resourceInstancePath in above candidates to each list operation's scope.scopeIdPattern
  for (const listOp of listOperations) {
    const validCandidates: RequestPath[] = [];

    for (const candidatePath of resourceInstancePaths) {
      if (canBeListResourceScope(listOp.operationPath, candidatePath)) {
        validCandidates.push(candidatePath);
      }
    }

    // Take the longest matching path as the ResourceScopeKind
    if (validCandidates.length > 0) {
      validCandidates.sort((a, b) => b.length - a.length);
      listOp.scope = {
        ...listOp.scope,
        scopeIdPattern: validCandidates[0]
      };
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
  const filteredResources: ValidArmResourceSchema[] = [];
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
            r.metadata.resourceIdPattern !== undefined &&
            r.metadata.resourceIdPattern.equals(
              resource.metadata.parentResourceId!
            )
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
            scope: method.scope,
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

  // Step 8: Update scope from resource ID patterns
  // At this point all resources in filteredResources have a valid resourceIdPattern
  for (const resource of filteredResources) {
    const scopePath = resource.metadata.resourceIdPattern.scopePath;
    resource.metadata.scope.scopeIdPattern = scopePath;
    // Include the scope's resource type when it's fully constant (no variable segments)
    const resourceType = scopePath.resourceType;
    if (resourceType !== undefined && !resourceType.includes("{")) {
      resource.metadata.scope.scopeResourceType = resourceType;
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
 *    is extracted from the operation path using RequestPath.resourceType (which includes
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
      (r) => r.metadata.resourceIdPattern,
      true
    );

    if (bestMatch) {
      bestMatch.metadata.methods.push({
        methodId: method.methodId,
        kind: ResourceOperationKind.Action,
        operationPath: method.operationPath,
        scope: {
          kind: method.scope.kind,
          scopeIdPattern: bestMatch.metadata.resourceIdPattern!,
          scopeResourceType: method.scope.scopeResourceType
        }
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
          scope: method.scope
        });
        methodsToRemove.add(method.methodId);
      }
    } else {
      // Both prefix and model ID matching failed — try matching by resource type.
      const operationType = method.operationPath.resourceType;
      if (operationType !== undefined) {
        const match = resources.find((r) => {
          if (
            !r.metadata.resourceIdPattern ||
            !method.operationPath.hasSameScopeNesting(
              r.metadata.resourceIdPattern
            )
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
            scope: method.scope
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
  listPath: RequestPath,
  resourceInstancePath: RequestPath
): boolean {
  // Check if resourceInstancePath is a prefix of listPath
  if (listPath.length < resourceInstancePath.length) {
    return false;
  }
  for (let i = 0; i < resourceInstancePath.length; i++) {
    // if both segments are variables, we consider it as a match
    if (
      isVariableSegment(listPath.segments[i]) &&
      isVariableSegment(resourceInstancePath.segments[i])
    ) {
      continue;
    }
    // if one of them is a variable, the other is not, we consider it as not a match
    if (
      isVariableSegment(listPath.segments[i]) ||
      isVariableSegment(resourceInstancePath.segments[i])
    ) {
      return false;
    }
    // both are fixed strings, they must match
    if (listPath.segments[i] !== resourceInstancePath.segments[i]) {
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
          !candidate.metadata.resourceIdPattern ||
          !method.operationPath.isPrefixOf(candidate.metadata.resourceIdPattern)
        )
          continue;
        // Ensure the difference is exactly one segment (the resource name)
        const opSegments = method.operationPath.segments;
        const resSegments = candidate.metadata.resourceIdPattern.segments;
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

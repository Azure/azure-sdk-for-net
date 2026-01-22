// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
  /**
   * For extension resources, this indicates the specific extension type (e.g., "ExternalResource", "Scope").
   * This allows distinguishing between different kinds of extension resources beyond the generic "Extension" scope.
   */
  specificExtensionScope?: string;
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
    resourceName: metadata.resourceName,
    specificExtensionScope: metadata.specificExtensionScope
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
      resourceName: r.metadata.resourceName,
      specificExtensionScope: r.metadata.specificExtensionScope
    })),
    nonResourceMethods: schema.nonResourceMethods.map((m) => ({
      methodId: m.methodId,
      operationPath: m.operationPath,
      operationScope: m.operationScope
    }))
  };
}

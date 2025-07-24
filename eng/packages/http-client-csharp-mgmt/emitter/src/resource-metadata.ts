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
  ResourceGroup = "ResourceGroup"
}

export interface ResourceMetadata {
  resourceIdPattern: string;
  resourceType: string;
  methods: ResourceMethod[];
  resourceScope: ResourceScope;
  parentResourceId?: string;
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

export interface ResourceMethod {
  id: string;
  kind: ResourceOperationKind;
}

export enum ResourceOperationKind {
  Action = "Action",
  Create = "Create",
  Delete = "Delete",
  Get = "Get",
  List = "List",
  Update = "Update"
  // ListBySubscription = "ListBySubscription",
}

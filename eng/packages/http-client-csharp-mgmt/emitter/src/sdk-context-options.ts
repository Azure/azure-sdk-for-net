// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CreateSdkContextOptions } from "@azure-tools/typespec-client-generator-core";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armprovidernamespace
const armProviderNamespaceRegex =
  "Azure\\.ResourceManager\\.@armProviderNamespace";

// https://github.com/microsoft/typespec/blob/main/packages/rest/README.md#parentresource
export const parentResource = "TypeSpec.Rest.@parentResource";
const parentResourceRegex = "TypeSpec\\.Rest\\.@parentResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armresourceoperations
export const armResourceOperations =
  "Azure.ResourceManager.@armResourceOperations";
const armResourceOperationsRegex =
  "Azure\\.ResourceManager\\.@armResourceOperations";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceRead
export const armResourceRead = "Azure.ResourceManager.@armResourceRead";
const armResourceReadRegex = "Azure\\.ResourceManager\\.@armResourceRead";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armresourcecreateorupdate
export const armResourceCreateOrUpdate =
  "Azure.ResourceManager.@armResourceCreateOrUpdate";
const armResourceCreateOrUpdateRegex =
  "Azure\\.ResourceManager\\.@armResourceCreateOrUpdate";
// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#singleton
export const singleton = "Azure.ResourceManager.@singleton";
const singletonRegex = "Azure\\.ResourceManager\\.@singleton";

const armResourceInternalRegex =
  "Azure\\.ResourceManager\\.Private\\.@armResourceInternal";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#subscriptionresource
export const subscriptionResource =
  "Azure.ResourceManager.@subscriptionResource";
const subscriptionResourceRegex =
  "Azure\\.ResourceManager\\.@subscriptionResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#tenantresource
export const tenantResource = "Azure.ResourceManager.@tenantResource";
const tenantResourceRegex = "Azure\\.ResourceManager\\.@tenantResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#resourcegroupresource
export const resourceGroupResource =
  "Azure.ResourceManager.@resourceGroupResource";
const resourceGroupResourceRegex =
  "Azure\\.ResourceManager\\.@resourceGroupResource";

// TODO: add this decorator to TCGC
export const resourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";
const resourceMetadataRegex =
  "Azure\\.ClientGenerator\\.Core\\.@resourceSchema";

export const azureSDKContextOptions: CreateSdkContextOptions = {
  versioning: {
    previewStringRegex: /-preview$/
  },
  additionalDecorators: [
    resourceMetadataRegex,
    armProviderNamespaceRegex,
    armResourceOperationsRegex,
    armResourceCreateOrUpdateRegex,
    armResourceReadRegex,
    parentResourceRegex,
    singletonRegex,
    armResourceInternalRegex,
    subscriptionResourceRegex,
    resourceGroupResourceRegex,
    tenantResourceRegex
  ]
};

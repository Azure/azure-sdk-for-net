// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CreateSdkContextOptions } from "@azure-tools/typespec-client-generator-core";

export const azureSDKContextOptions: CreateSdkContextOptions = {
  versioning: {
    previewStringRegex: /-preview$/
  },
  additionalDecorators: [
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-client-generator-core/README.md#usesystemtextjsonconverter
    "Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter",
    // TODO: add this decorator to TCGC
    "Azure\\.ClientGenerator\\.Core\\.@resourceSchema",
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armprovidernamespace
    "Azure\\.ResourceManager\\.@armProviderNamespace",
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armresourceoperations
    "Azure\\.ResourceManager\\.@armResourceOperations",
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceRead
    "Azure\\.ResourceManager\\.@armResourceRead",
    // https://github.com/microsoft/typespec/blob/main/packages/rest/README.md#parentresource
    "TypeSpec\\.Rest\\.parentResource",
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#singleton
    "Azure\\.ResourceManager\\.@singleton",
    "Azure\\.ResourceManager\\.Private\\.@armResourceInternal"
  ]
};

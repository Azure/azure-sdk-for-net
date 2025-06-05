// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CreateSdkContextOptions } from "@azure-tools/typespec-client-generator-core";

export const azureSDKContextOptions: CreateSdkContextOptions = {
    versioning: {},
    additionalDecorators: [
        // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-client-generator-core/README.md#usesystemtextjsonconverter
        "Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter",
        // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armprovidernamespace
        "Azure\\.ResourceManager\\.@armProviderNamespace"
    ]
};

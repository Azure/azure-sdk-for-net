// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CreateSdkContextOptions } from "@azure-tools/typespec-client-generator-core";
import {
  armResourceCreateOrUpdateRegex,
  armResourceOperationsRegex,
  armResourceReadRegex,
  parentResourceRegex,
  resourceMetadataRegex,
  singletonRegex
} from "./resource-detection.js";

export const azureSDKContextOptions: CreateSdkContextOptions = {
  versioning: {
    previewStringRegex: /-preview$/
  },
  additionalDecorators: [
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-client-generator-core/README.md#usesystemtextjsonconverter
    "Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter",
    resourceMetadataRegex,
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armprovidernamespace
    "Azure\\.ResourceManager\\.@armProviderNamespace",
    armResourceOperationsRegex,
    armResourceCreateOrUpdateRegex,
    armResourceReadRegex,
    parentResourceRegex,
    singletonRegex,
    "Azure\\.ResourceManager\\.Private\\.@armResourceInternal"
  ]
};

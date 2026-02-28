// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AzureEmitterOptions,
  AzureEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp";
import { JSONSchemaType } from "@typespec/compiler";

export interface AzureProvisioningEmitterOptions
  extends AzureEmitterOptions {}

export const AzureProvisioningEmitterOptionsSchema: JSONSchemaType<AzureProvisioningEmitterOptions> =
  {
    type: "object",
    additionalProperties: false,
    properties: {
      ...AzureEmitterOptionsSchema.properties
    }
  };

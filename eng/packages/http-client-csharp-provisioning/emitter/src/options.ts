// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AzureMgmtEmitterOptions,
  AzureMgmtEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp-mgmt";
import { JSONSchemaType } from "@typespec/compiler";

export interface AzureProvisioningEmitterOptions
  extends AzureMgmtEmitterOptions {}

export const AzureProvisioningEmitterOptionsSchema: JSONSchemaType<AzureProvisioningEmitterOptions> =
  {
    type: "object",
    additionalProperties: false,
    properties: {
      ...AzureMgmtEmitterOptionsSchema.properties
    }
  };

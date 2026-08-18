// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AzureMgmtEmitterOptions,
  AzureMgmtEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp-mgmt";
import { JSONSchemaType } from "@typespec/compiler";

export type AzureProvisioningEmitterOptions = AzureMgmtEmitterOptions;

const apiVersionSchema = {
  oneOf: [
    {
      type: "string",
      nullable: true
    },
    {
      type: "object",
      additionalProperties: true,
      required: [],
      nullable: true
    }
  ],
  description:
    "Selects an API version, or maps nested service namespace segments to API versions for multi-service packages."
} as const;

export const AzureProvisioningEmitterOptionsSchema: JSONSchemaType<AzureProvisioningEmitterOptions> =
  {
    type: "object",
    additionalProperties: false,
    properties: {
      ...AzureMgmtEmitterOptionsSchema.properties,
      "api-version": apiVersionSchema
    }
  };

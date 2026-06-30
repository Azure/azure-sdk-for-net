// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AzureMgmtEmitterOptions,
  AzureMgmtEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp-mgmt";
import { JSONSchemaType } from "@typespec/compiler";

type ApiVersionOption = string | Record<string, string>;

export interface AzureProvisioningEmitterOptions
  extends Omit<AzureMgmtEmitterOptions, "api-version"> {
  "api-version"?: ApiVersionOption;
}

export const AzureProvisioningEmitterOptionsSchema: JSONSchemaType<AzureProvisioningEmitterOptions> =
  {
    type: "object",
    additionalProperties: false,
    properties: {
      ...AzureMgmtEmitterOptionsSchema.properties,
      "api-version": {
        description:
          "For TypeSpec files using the @versioned decorator, set this option to the version that should be used to generate against. Multi-service projects may use a map from service namespace to API version.",
        oneOf: [
          { type: "string" },
          {
            type: "object",
            additionalProperties: { type: "string" },
            required: []
          }
        ]
      }
    }
  };

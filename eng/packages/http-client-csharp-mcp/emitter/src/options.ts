// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { JSONSchemaType } from "@typespec/compiler";
import { CSharpEmitterOptionsSchema } from "@typespec/http-client-csharp";
import {
  AzureMgmtEmitterOptions,
  AzureMgmtEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp-mgmt";

export interface McpEmitterOptions extends AzureMgmtEmitterOptions {
  "management-plane"?: boolean;
}

export const McpEmitterOptionsSchema: JSONSchemaType<McpEmitterOptions> = {
  type: "object",
  additionalProperties: false,
  properties: {
    ...CSharpEmitterOptionsSchema.properties,
    ...AzureMgmtEmitterOptionsSchema.properties,
    "management-plane": { type: "boolean", nullable: true }
  }
};

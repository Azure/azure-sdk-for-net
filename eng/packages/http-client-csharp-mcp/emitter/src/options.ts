// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { JSONSchemaType } from "@typespec/compiler";
import {
  CSharpEmitterOptions,
  CSharpEmitterOptionsSchema
} from "@typespec/http-client-csharp";

export type McpEmitterOptions = CSharpEmitterOptions;

export const McpEmitterOptionsSchema: JSONSchemaType<McpEmitterOptions> = {
  type: "object",
  additionalProperties: false,
  properties: {
    ...CSharpEmitterOptionsSchema.properties
  }
};

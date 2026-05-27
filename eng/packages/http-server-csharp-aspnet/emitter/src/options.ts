// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CSharpEmitterOptions,
  CSharpEmitterOptionsSchema
} from "@typespec/http-client-csharp";
import { JSONSchemaType } from "@typespec/compiler";

/**
 * Emitter options for the ASP.NET Core server-side code generator.
 *
 * Currently this is a pass-through of the upstream CSharp emitter options.
 * Server-specific options (e.g., controller namespace, version registry mode)
 * will be added here as the generator gains real outputs.
 */
export type AspNetServerEmitterOptions = CSharpEmitterOptions;

export const AspNetServerEmitterOptionsSchema: JSONSchemaType<AspNetServerEmitterOptions> =
  {
    ...CSharpEmitterOptionsSchema,
    properties: {
      ...CSharpEmitterOptionsSchema.properties
    }
  };

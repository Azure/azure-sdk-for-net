// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { JSONSchemaType } from "@typespec/compiler";
import { CSharpEmitterOptions, CSharpEmitterOptionsSchema } from "@typespec/http-client-csharp";

export interface AzureEmitterOptions extends CSharpEmitterOptions {
    namespace?: string;
    "model-namespace"?: boolean;
}
  
export const AzureEmitterOptionsSchema: JSONSchemaType<AzureEmitterOptions> = {
  type: "object",
  properties: {
    ...CSharpEmitterOptionsSchema.properties,
    namespace: {
      type: "string",
      description: "The C# namespace to use for the generated code. This will override the TypeSpec namespaces.",
    },
    "model-namespace": {
      type: "boolean",
      description: "Whether to put models under a separate 'Models' sub-namespace. This only applies if the 'namespace' option is set. " + 
      " The default value is 'true' when the 'namespace' option is set. Otherwise, each model will be in the corresponding namespace defined in the TypeSpec.",
    },
  },
};
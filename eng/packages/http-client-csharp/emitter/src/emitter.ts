// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecLibrary, EmitContext, JSONSchemaType } from "@typespec/compiler";

import {
  $onEmit as $onMTGEmit,
  CSharpEmitterOptions,
  CSharpEmitterOptionsSchema,
  $lib as httpClientCSharpLib,
} from "@typespec/http-client-csharp";

export async function $onEmit(context: EmitContext<AzureEmitterOptions>) {
  context.options["generator-name"] ??= "AzureClientGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["license"] ??= { name: "MIT License", company: "Microsoft Corporation" };
  await $onMTGEmit(context);
}

export interface AzureEmitterOptions extends CSharpEmitterOptions {
  namespace?: string;
}

export const AzureEmitterOptionsSchema: JSONSchemaType<AzureEmitterOptions> = {
  type: "object",
  properties: {
    ...CSharpEmitterOptionsSchema.properties,
    namespace: {
      type: "string",
      description: "The C# namespace to use for the generated code. This will override the TypeSpec namespaces.",
    },
  },
};

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp",
  diagnostics: httpClientCSharpLib.diagnostics,
  emitter: {
    options: AzureEmitterOptionsSchema,
  },
});

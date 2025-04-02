// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import {
  $onEmit as $onMTGEmit,
  CSharpEmitterOptions
} from "@typespec/http-client-csharp";

export async function $onEmit(context: EmitContext<CSharpEmitterOptions>) {
  context.options["generator-name"] ??= "AzureClientGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["license"] ??= { name: "MIT License", company: "Microsoft Corporation" };
  await $onMTGEmit(context);
}

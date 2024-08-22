// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import {
  $onEmit as $OnMGCEmit,
  NetEmitterOptions
} from "@typespec/http-client-csharp";

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
  context.options["plugin-name"] = "AzurePlugin";
  context.options["emitter-extension-path"] = import.meta.url;
  await $OnMGCEmit(context);
}

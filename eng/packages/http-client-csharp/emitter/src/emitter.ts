// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import {
  $onEmit as $OnMGCEmit,
  NetEmitterOptions,
  setSDKContextOptions
} from "@typespec/http-client-csharp";
import { azureSDKContextOptions } from "./sdk-context-options.js";

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
  context.options["plugin-name"] = "AzureClientPlugin";
  context.options["emitter-extension-path"] = import.meta.url;
  setSDKContextOptions(azureSDKContextOptions);
  await $OnMGCEmit(context);
}

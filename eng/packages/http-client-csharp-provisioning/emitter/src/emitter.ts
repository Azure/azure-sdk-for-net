// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { $onEmit as $onMgmtEmit } from "@azure-typespec/http-client-csharp-mgmt";
import { AzureProvisioningEmitterOptions } from "./options.js";

export async function $onEmit(
  context: EmitContext<AzureProvisioningEmitterOptions>
) {
  (context.options as any)["generator-name"] ??= "ProvisioningGenerator";
  (context.options as any)["emitter-extension-path"] ??= import.meta.url;
  await $onMgmtEmit(context as any);
}

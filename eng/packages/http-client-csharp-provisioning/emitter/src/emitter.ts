// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { $onEmit as $onMgmtEmit } from "@azure-typespec/http-client-csharp-mgmt";

export async function $onEmit(context: EmitContext<Record<string, never>>) {
  context.options["generator-name"] ??= "ProvisioningGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  await $onMgmtEmit(context);
}

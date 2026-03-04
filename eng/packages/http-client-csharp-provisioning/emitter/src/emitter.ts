// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { $onEmit as $onMgmtEmit } from "@azure-typespec/http-client-csharp-mgmt";
import { AzureProvisioningEmitterOptions } from "./options.js";

export async function $onEmit(
  context: EmitContext<AzureProvisioningEmitterOptions>
) {
  // `as any` casts are needed: generator-name/emitter-extension-path are defined on
  // CSharpEmitterOptions but TypeScript can't resolve the types across npm package
  // boundaries. The $onMgmtEmit cast is needed because the mgmt package doesn't
  // export its AzureMgmtEmitterOptions type from its main entry point.
  (context.options as any)["generator-name"] ??= "ProvisioningGenerator";
  (context.options as any)["emitter-extension-path"] ??= import.meta.url;
  // Provisioning libraries use a flat namespace (no .Models sub-namespace)
  (context.options as any)["model-namespace"] = false;
  await $onMgmtEmit(context as any);
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { emitManagementCodeModel } from "@azure-typespec/http-client-csharp-mgmt";
import { AzureProvisioningEmitterOptions } from "./options.js";
import { updateProvisioningCodeModel } from "./provisioning-code-model.js";

export async function $onEmit(
  context: EmitContext<AzureProvisioningEmitterOptions>
) {
  context.options["generator-name"] ??= "ProvisioningGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  // Provisioning libraries use a flat namespace (no .Models sub-namespace)
  context.options["model-namespace"] = false;
  await emitManagementCodeModel(context, (codeModel, _, armProviderSchema) =>
    updateProvisioningCodeModel(codeModel, armProviderSchema)
  );
}

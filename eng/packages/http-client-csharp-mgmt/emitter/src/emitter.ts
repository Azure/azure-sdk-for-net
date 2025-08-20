// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { CodeModel } from "@typespec/http-client-csharp";

import {
  $onEmit as $onAzureEmit,
  AzureEmitterOptions
} from "@azure-typespec/http-client-csharp";
import { azureSDKContextOptions } from "./sdk-context-options.js";
import { updateClients } from "./resource-detection.js";

export async function $onEmit(context: EmitContext<AzureEmitterOptions>) {
  context.options["generator-name"] ??= "ManagementClientGenerator";
  context.options["update-code-model"] = updateCodeModel;
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["sdk-context-options"] ??= azureSDKContextOptions;
  context.options["model-namespace"] ??= true;
  await $onAzureEmit(context);
}

function updateCodeModel(codeModel: CodeModel): CodeModel {
  updateClients(codeModel);

  return codeModel;
}

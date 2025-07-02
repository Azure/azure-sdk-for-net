// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, NoTarget } from "@typespec/compiler";

import { $onEmit as $onMTGEmit } from "@typespec/http-client-csharp";
import { AzureEmitterOptions } from "./options.js";
import { $lib } from "./lib/lib.js";

export async function $onEmit(context: EmitContext<AzureEmitterOptions>) {
  context.options["generator-name"] ??= "AzureClientGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["license"] ??= {
    name: "MIT License",
    company: "Microsoft Corporation"
  };
  context.options["package-name"] ??= context.options["namespace"];

  // Merge additional decorators
  context.options["sdk-context-options"] ??= {};
  const existingDecorators =
    context.options["sdk-context-options"].additionalDecorators;
  context.options["sdk-context-options"].additionalDecorators = [
    ...(Array.isArray(existingDecorators) ? existingDecorators : []),
    // https://github.com/Azure/typespec-azure/blob/main/packages/typespec-client-generator-core/README.md#usesystemtextjsonconverter
    "Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"
  ];

  // warn if use-model-namespaces is true, but namespace is not set
  if (context.options["model-namespace"] && !context.options["namespace"]) {
    $lib.reportDiagnostic(context.program, {
      code: "invalid-model-namespace-usage",
      target: NoTarget
    });
  }

  await $onMTGEmit(context);
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, NoTarget } from "@typespec/compiler";

import { $onEmit as $onMTGEmit } from "@typespec/http-client-csharp";
import { AzureEmitterOptions } from "./options.js";
import { $lib } from "./lib/lib.js";

const PACKAGE_NAME_TEMPLATE = "{package-name}";

export async function $onEmit(context: EmitContext<AzureEmitterOptions>) {
  context.options["generator-name"] ??= "AzureClientGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  context.options["license"] ??= {
    name: "MIT License",
    company: "Microsoft Corporation"
  };

  // Substitute {package-name} template in namespace option if present
  // This must happen before package-name defaults to namespace
  if (
    context.options["namespace"] &&
    context.options["namespace"].includes(PACKAGE_NAME_TEMPLATE) &&
    context.options["package-name"]
  ) {
    context.options["namespace"] = context.options["namespace"].replace(
      new RegExp(PACKAGE_NAME_TEMPLATE.replace(/[{}]/g, "\\$&"), "g"),
      context.options["package-name"]
    );
  }

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

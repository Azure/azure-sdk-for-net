// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, NoTarget, resolvePath } from "@typespec/compiler";

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

  // Generate metadata.json file
  await generateMetadataFile(context);

  await $onMTGEmit(context);
}

/**
 * Generates a metadata.json file containing API version information.
 * 
 * The emitter automatically generates a `metadata.json` file in the `Generated/` folder. 
 * This file contains information such as the API version and can be used for automation 
 * purposes like building a mapping of package version to supported API version.
 * 
 * The metadata file contains content such as:
 * ```json
 * {
 *   "api-version": "2024-05-01"
 * }
 * ```
 * 
 * This file is not included as an asset of the nupkg. If no API version is specified, 
 * the value will be "not-specified".
 */
async function generateMetadataFile(context: EmitContext<AzureEmitterOptions>): Promise<void> {
  const apiVersion = context.options["api-version"];
  
  const metadata = {
    "api-version": apiVersion || "not-specified"
  };

  const outputPath = resolvePath(context.emitterOutputDir, "Generated", "metadata.json");
  await context.program.host.writeFile(outputPath, JSON.stringify(metadata, null, 2));
}

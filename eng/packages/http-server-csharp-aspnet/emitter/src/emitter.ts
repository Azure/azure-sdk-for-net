// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";
import { emitCodeModel } from "@typespec/http-client-csharp";

import { AspNetServerEmitterOptions } from "./options.js";

/**
 * Name of the C# generator class that the .NET generator host should load.
 * Must match the `[ExportMetadata(GeneratorMetadataName, ...)]` value on
 * `AspNetServerCodeModelGenerator` in the .NET project.
 */
const GENERATOR_NAME = "AspNetServerCodeModelGenerator";

export async function $onEmit(
  context: EmitContext<AspNetServerEmitterOptions>
) {
  // Always force our generator name. Upstream's option schema applies a
  // default of `ScmCodeModelGenerator`, so a `??=` guard would never see the
  // option as unset and our generator would be skipped.
  context.options["generator-name"] = GENERATOR_NAME;
  // Tell the upstream emitter where to find this package on disk so it can
  // locate the .NET generator's `dist/generator` payload.
  context.options["emitter-extension-path"] ??= import.meta.url;
  // The server-side generator currently emits scaffolding types that are
  // not yet wired into the input model graph. Disable the upstream Roslyn
  // post-processor's unreferenced-type pruning so those types survive.
  context.options["unreferenced-types-handling"] ??= "keepAll";

  const [, diagnostics] = await emitCodeModel(context);
  context.program.reportDiagnostics(diagnostics);
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, emitFile, resolvePath } from "@typespec/compiler";
import { emitCodeModel } from "@typespec/http-client-csharp";
import { emitManagementCodeModel } from "@azure-typespec/http-client-csharp-mgmt";
import { getMcpConfiguration } from "./decorators.js";
import { McpEmitterOptions } from "./options.js";

export async function $onEmit(context: EmitContext<McpEmitterOptions>) {
  context = {
    ...context,
    emitterOutputDir: resolvePath(context.emitterOutputDir)
  };
  const configuration = getMcpConfiguration(context.program);
  if (!configuration || context.program.hasError()) {
    return;
  }
  const management = context.options["management-plane"] === true;
  context.options["generator-name"] = management
    ? "ArmMcpGenerator"
    : "McpGenerator";
  context.options["emitter-extension-path"] = import.meta.url;
  // MCP registration/options are externally consumed roots, not REST client dependencies.
  context.options["unreferenced-types-handling"] = "keepAll";
  const path = resolvePath(context.emitterOutputDir, "tspMcpCodeModel.json");
  await emitFile(context.program, {
    path,
    content: JSON.stringify(configuration, null, 2) + "\n"
  });
  try {
    if (management) {
      await emitManagementCodeModel(context);
      return;
    }
    const [, diagnostics] = await emitCodeModel(context);
    context.program.reportDiagnostics(diagnostics);
  } finally {
    if (!context.options["save-inputs"]) {
      await context.program.host.rm(path, { recursive: false });
    }
  }
}

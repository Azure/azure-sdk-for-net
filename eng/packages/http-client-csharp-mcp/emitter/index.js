// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

import { unlink } from "node:fs/promises";
import { fileURLToPath } from "node:url";
import {
  createTypeSpecLibrary,
  emitFile,
  getNamespaceFullName,
  paramMessage,
  resolvePath,
  validateDecoratorUniqueOnNode,
} from "@typespec/compiler";
import { CSharpEmitterOptionsSchema, emitCodeModel } from "@typespec/http-client-csharp";

export const $lib = createTypeSpecLibrary({
  name: "@azure-tools/typespec-mcp",
  diagnostics: {
    "invalid-configuration": {
      severity: "error",
      messages: { default: paramMessage`${"message"}` },
    },
  },
  emitter: { options: CSharpEmitterOptionsSchema },
});

const serviceKey = $lib.createStateSymbol("service");
const toolKey = $lib.createStateSymbol("tool");

function $mcpService(context, target, configuration) {
  if (!validateDecoratorUniqueOnNode(context, target, $mcpService)) {
    $lib.reportDiagnostic(context.program, {
      code: "invalid-configuration",
      format: { message: "@mcpService cannot be repeated." },
      target,
    });
    return;
  }
  context.program.stateMap(serviceKey).set(target, configuration);
}

function $tool(context, target, configuration) {
  if (!validateDecoratorUniqueOnNode(context, target, $tool)) {
    $lib.reportDiagnostic(context.program, {
      code: "invalid-configuration",
      format: { message: "@tool cannot be repeated." },
      target,
    });
    return;
  }
  context.program.stateMap(toolKey).set(target, configuration);
}

export const $decorators = {
  "Azure.Mcp": { mcpService: $mcpService, tool: $tool },
};

function getMcpConfiguration(program) {
  const services = [...program.stateMap(serviceKey)];
  const tools = [...program.stateMap(toolKey)];
  if (services.length !== 1 || tools.length === 0) {
    $lib.reportDiagnostic(program, {
      code: "invalid-configuration",
      format: { message: "Declare exactly one @mcpService namespace and at least one @tool operation." },
      target: program.getGlobalNamespaceType(),
    });
    return;
  }
  const [service, configuration] = services[0];
  const namespace = getNamespaceFullName(service);
  for (const [operation] of tools) {
    const owner = getNamespaceFullName(operation.namespace);
    if (owner !== namespace && !owner.startsWith(namespace + ".")) {
      $lib.reportDiagnostic(program, {
        code: "invalid-configuration",
        format: { message: "Every @tool operation must belong to the @mcpService namespace." },
        target: operation,
      });
    }
  }
  return {
    namespace: configuration.outputNamespace,
    metadataReferences: configuration.metadataReferences,
    composites: configuration.composites,
    operations: tools.map(([operation, tool]) => ({
      ...tool,
      operationId: [
        getNamespaceFullName(operation.namespace),
        operation.interface?.name,
        operation.name,
      ].filter(Boolean).join("."),
    })),
  };
}

export function $onValidate(program) {
  getMcpConfiguration(program);
}

export async function $onEmit(context) {
  context = { ...context, emitterOutputDir: resolvePath(context.emitterOutputDir) };
  const configuration = getMcpConfiguration(context.program);
  if (!configuration || context.program.hasError()) {
    return;
  }
  const path = resolvePath(context.emitterOutputDir, "tspMcpCodeModel.json");
  await emitFile(context.program, { path, content: JSON.stringify(configuration, null, 2) + "\n" });
  try {
    const [, diagnostics] = await emitCodeModel({
      ...context,
      options: {
        ...context.options,
        "generator-name": "McpGenerator",
        "unreferenced-types-handling": "keepAll",
        plugins: [fileURLToPath(new URL("../dist/generator", import.meta.url))],
      },
    });
    context.program.reportDiagnostics(diagnostics);
  } finally {
    if (!context.options["save-inputs"]) {
      await unlink(path);
    }
  }
}

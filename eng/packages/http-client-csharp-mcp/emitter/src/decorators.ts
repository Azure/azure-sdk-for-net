// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  DecoratorContext,
  getNamespaceFullName,
  Namespace,
  Operation,
  Program,
  validateDecoratorUniqueOnNode
} from "@typespec/compiler";
import { SyntaxKind } from "@typespec/compiler/ast";
import { $lib } from "./lib/lib.js";
import {
  CommandConfiguration,
  McpCodeModel,
  McpService,
  ToolConfiguration
} from "./types.js";

const serviceKey = $lib.createStateSymbol("service");
const toolKey = $lib.createStateSymbol("tool");
const commandKey = $lib.createStateSymbol("command");

function $command(
  context: DecoratorContext,
  target: Operation,
  configuration: CommandConfiguration
) {
  // Client interfaces can inherit service operations and their decorators.
  // Selecting a service operation must not opt its inherited aliases into MCP.
  const direct = target.decorators.some((application) => {
    if (application.decorator !== $command || !application.node) {
      return false;
    }
    return application.node.kind === SyntaxKind.AugmentDecoratorStatement
      ? context.program.checker.getTypeForNode(application.node.targetType) ===
          target
      : application.node.parent === target.node &&
          (!target.interface || target.node?.parent === target.interface.node);
  });
  if (!direct) {
    return;
  }
  if (!validateDecoratorUniqueOnNode(context, target, $command)) {
    $lib.reportDiagnostic(context.program, {
      code: "invalid-configuration",
      format: { message: "@command cannot be repeated." },
      target
    });
    return;
  }
  context.program.stateMap(commandKey).set(target, configuration);
}

function $mcpService(
  context: DecoratorContext,
  target: Namespace,
  configuration: McpService
) {
  if (!validateDecoratorUniqueOnNode(context, target, $mcpService)) {
    $lib.reportDiagnostic(context.program, {
      code: "invalid-configuration",
      format: { message: "@mcpService cannot be repeated." },
      target
    });
    return;
  }
  context.program.stateMap(serviceKey).set(target, configuration);
}

function $tool(
  context: DecoratorContext,
  target: Operation,
  configuration: ToolConfiguration
) {
  if (!validateDecoratorUniqueOnNode(context, target, $tool)) {
    $lib.reportDiagnostic(context.program, {
      code: "invalid-configuration",
      format: { message: "@tool cannot be repeated." },
      target
    });
    return;
  }
  context.program.stateMap(toolKey).set(target, configuration);
}

export const $decorators = {
  "Azure.Mcp": { mcpService: $mcpService, tool: $tool, command: $command }
};

export function getMcpConfiguration(
  program: Program
): McpCodeModel | undefined {
  const services = [...program.stateMap(serviceKey)].map(
    ([target, configuration]): [Namespace, McpService] => {
      if (target.kind !== "Namespace") {
        throw new Error("MCP service metadata must target a namespace.");
      }
      return [target, configuration];
    }
  );
  const tools = [...program.stateMap(toolKey)].map(
    ([target, configuration]): [Operation, ToolConfiguration] => {
      if (target.kind !== "Operation") {
        throw new Error("MCP tool metadata must target an operation.");
      }
      return [target, configuration];
    }
  );
  const commands = [...program.stateMap(commandKey)].map(
    ([target, configuration]): [Operation, CommandConfiguration] => {
      if (target.kind !== "Operation") {
        throw new Error("MCP command metadata must target an operation.");
      }
      return [target, configuration];
    }
  );
  if (services.length !== 1 || tools.length + commands.length === 0) {
    $lib.reportDiagnostic(program, {
      code: "invalid-configuration",
      format: {
        message:
          "Declare exactly one @mcpService namespace and at least one @tool or @command operation."
      },
      target: program.getGlobalNamespaceType()
    });
    return undefined;
  }
  const [service, configuration] = services[0];
  const namespace = getNamespaceFullName(service);
  for (const [operation] of [...tools, ...commands]) {
    const owner = operation.namespace
      ? getNamespaceFullName(operation.namespace)
      : "";
    if (owner !== namespace && !owner.startsWith(namespace + ".")) {
      $lib.reportDiagnostic(program, {
        code: "invalid-configuration",
        format: {
          message:
            "Every @tool or @command operation must belong to the @mcpService namespace."
        },
        target: operation
      });
    }
  }
  return {
    namespace: configuration.outputNamespace,
    metadataReferences: configuration.metadataReferences ?? [],
    composites: configuration.composites ?? [],
    commands: commands.map(([operation, command]) => ({
      ...command,
      operationId: operationId(operation)
    })),
    operations: tools.map(([operation, tool]) => ({
      ...tool,
      operationId: operationId(operation)
    }))
  };
}

function operationId(operation: Operation): string {
  return [
    operation.namespace && getNamespaceFullName(operation.namespace),
    operation.interface?.name,
    operation.name
  ]
    .filter(Boolean)
    .join(".");
}

export function $onValidate(program: Program) {
  getMcpConfiguration(program);
}

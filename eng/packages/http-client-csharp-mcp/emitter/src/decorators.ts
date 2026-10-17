// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  DecoratorContext,
  DecoratorFunction,
  getNamespaceFullName,
  getService,
  getSummary,
  Namespace,
  Operation,
  Program,
  validateDecoratorUniqueOnNode
} from "@typespec/compiler";
import { SyntaxKind } from "@typespec/compiler/ast";
import { $lib } from "./lib/lib.js";
import { McpCodeModel, SafetyOverrides, ToolIdentity } from "./types.js";

const toolKey = $lib.createStateSymbol("tool");
const safetyKey = $lib.createStateSymbol("safety");

function isDirect(
  context: DecoratorContext,
  target: Operation,
  decorator: DecoratorFunction
) {
  // Inherited client aliases must not silently become additional MCP tools.
  return target.decorators.some((application) => {
    if (application.decorator !== decorator || !application.node) return false;
    return application.node.kind === SyntaxKind.AugmentDecoratorStatement
      ? context.program.checker.getTypeForNode(application.node.targetType) ===
          target
      : application.node.parent === target.node &&
          (!target.interface || target.node?.parent === target.interface.node);
  });
}

function $tool(
  context: DecoratorContext,
  target: Operation,
  id: string,
  path: string,
  title?: string
) {
  if (
    isDirect(context, target, $tool) &&
    validateDecoratorUniqueOnNode(context, target, $tool)
  ) {
    context.program.stateMap(toolKey).set(target, { id, path, title });
  }
}

function safetyDecorator(name: keyof SafetyOverrides) {
  function decorator(
    context: DecoratorContext,
    target: Operation,
    value = true
  ) {
    if (
      isDirect(context, target, decorator) &&
      validateDecoratorUniqueOnNode(context, target, decorator)
    ) {
      const state = context.program.stateMap(safetyKey);
      state.set(target, { ...state.get(target), [name]: value });
    }
  }
  return decorator;
}

export const $decorators = {
  "Azure.Mcp": {
    tool: $tool,
    destructive: safetyDecorator("destructive"),
    idempotent: safetyDecorator("idempotent"),
    readOnly: safetyDecorator("readOnly"),
    openWorld: safetyDecorator("openWorld")
  }
};

function serviceOf(
  program: Program,
  operation: Operation
): Namespace | undefined {
  for (
    let namespace = operation.namespace;
    namespace;
    namespace = namespace.namespace
  ) {
    if (getService(program, namespace)) return namespace;
  }
  return undefined;
}

export function getMcpConfiguration(
  program: Program
): McpCodeModel | undefined {
  const tools = [...program.stateMap(toolKey)] as [Operation, ToolIdentity][];
  const services = new Set(
    tools.map(([operation]) => serviceOf(program, operation))
  );
  const [service] = services;
  if (tools.length === 0 || services.size !== 1 || !service) {
    $lib.reportDiagnostic(program, {
      code: "invalid-configuration",
      format: {
        message:
          "Select at least one @tool; every selected operation must belong to the same @service namespace."
      },
      target: program.getGlobalNamespaceType()
    });
    return undefined;
  }
  for (const [operation] of program.stateMap(safetyKey)) {
    if (!program.stateMap(toolKey).has(operation)) {
      $lib.reportDiagnostic(program, {
        code: "invalid-configuration",
        format: {
          message:
            "Tool safety overrides require an explicitly selected @tool operation."
        },
        target: operation
      });
    }
  }
  return {
    namespace: getNamespaceFullName(service),
    commands: tools.map(([operation, identity]) => {
      const namespace = getNamespaceFullName(operation.namespace!);
      return {
        ...identity,
        namespace,
        interfaceName: operation.interface?.name,
        name: operation.name,
        operationId: [namespace, operation.interface?.name, operation.name]
          .filter(Boolean)
          .join("."),
        title:
          identity.title ?? getSummary(program, operation) ?? operation.name,
        safety: program.stateMap(safetyKey).get(operation) ?? {}
      };
    })
  };
}

export function $onValidate(program: Program) {
  getMcpConfiguration(program);
}

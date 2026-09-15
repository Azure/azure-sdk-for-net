// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  armResourceAction,
  armResourceCreateOrUpdate,
  armResourceDelete,
  armResourceInternal,
  armResourceList,
  armResourceOperations,
  armResourceRead,
  armResourceUpdate,
  armResourceWithParameter,
  parentResource
} from "./sdk-context-options.js";

const decoratorsWithModelArguments = new Set([
  parentResource,
  armResourceOperations,
  armResourceAction,
  armResourceCreateOrUpdate,
  armResourceRead,
  armResourceUpdate,
  armResourceDelete,
  armResourceList,
  armResourceInternal,
  armResourceWithParameter
]);

export function removeModelDecoratorArguments(
  value: unknown,
  visited = new WeakSet<object>()
): void {
  if (value === null || typeof value !== "object" || visited.has(value)) {
    return;
  }

  visited.add(value);

  if (Array.isArray(value)) {
    for (const item of value) {
      removeModelDecoratorArguments(item, visited);
    }
    return;
  }

  const record = value as Record<string, unknown>;
  if (Array.isArray(record.decorators)) {
    for (const decorator of record.decorators) {
      if (
        decorator !== null &&
        typeof decorator === "object" &&
        "name" in decorator &&
        typeof decorator.name === "string" &&
        decoratorsWithModelArguments.has(decorator.name)
      ) {
        decorator.arguments = {};
      }
    }
  }

  for (const child of Object.values(record)) {
    removeModelDecoratorArguments(child, visited);
  }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { armProviderSchema, clientOption } from "./sdk-context-options.js";

export function removeUnusedDecoratorArguments(
  value: unknown,
  visited = new WeakSet<object>()
): void {
  if (value === null || typeof value !== "object" || visited.has(value)) {
    return;
  }

  visited.add(value);

  if (Array.isArray(value)) {
    for (const item of value) {
      removeUnusedDecoratorArguments(item, visited);
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
        decorator.name !== armProviderSchema &&
        decorator.name !== clientOption
      ) {
        decorator.arguments = {};
      }
    }
  }

  for (const child of Object.values(record)) {
    removeUnusedDecoratorArguments(child, visited);
  }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export function removeReferenceIdsFromUnknownValues(
  value: unknown,
  visited = new WeakSet<object>()
): void {
  if (value === null || typeof value !== "object" || visited.has(value)) {
    return;
  }

  visited.add(value);

  if (Array.isArray(value)) {
    for (const item of value) {
      removeReferenceIdsFromUnknownValues(item, visited);
    }
    return;
  }

  const record = value as Record<string, unknown>;
  if (record.kind === "unknown" && "value" in record) {
    // Work around the C# deserializer interpreting user-defined JSON Schema IDs as
    // code-model reference metadata before reading the value as opaque JSON.
    // Remove this when https://github.com/microsoft/typespec/issues/12022 is fixed.
    removeReferenceIds(record.value, visited);
  }

  for (const child of Object.values(record)) {
    removeReferenceIdsFromUnknownValues(child, visited);
  }
}

function removeReferenceIds(
  value: unknown,
  visited = new WeakSet<object>()
): void {
  if (value === null || typeof value !== "object" || visited.has(value)) {
    return;
  }

  visited.add(value);

  if (Array.isArray(value)) {
    for (const item of value) {
      removeReferenceIds(item, visited);
    }
    return;
  }

  const record = value as Record<string, unknown>;
  delete record.$id;

  for (const child of Object.values(record)) {
    removeReferenceIds(child, visited);
  }
}

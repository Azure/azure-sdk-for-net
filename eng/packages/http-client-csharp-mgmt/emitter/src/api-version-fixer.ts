// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  CSharpEmitterContext,
  InputClient
} from "@typespec/http-client-csharp";
import { NoTarget } from "@typespec/compiler";
import { UsageFlags } from "@azure-tools/typespec-client-generator-core";
import { traverseClient } from "./sdk-client-utils.js";

/**
 * Deduplicates ApiVersionEnum enums in the code model to work around a base generator bug
 * where multiple enums with the same namespace cause duplicate field names in ClientOptionsProvider,
 * crashing in ClientProvider.BuildMethods().
 *
 * In multi-service scenarios (e.g., Compute has Compute, ComputeDisk, ComputeGallery, ComputeSku),
 * each service produces its own Versions enum, all with the same namespace. The base generator
 * creates one API version field per enum, using the namespace to derive the field name — so
 * identical namespaces produce identical field names, causing a Dictionary duplicate key crash.
 *
 * This workaround merges all ApiVersionEnum enums that share the same namespace into a single
 * enum with the union of all values. The mgmt generator does not use the base generator's
 * ClientOptionsProvider API version mechanism, so this is safe.
 *
 * Tracked by: https://github.com/microsoft/typespec/issues/10055
 */
export function deduplicateApiVersionEnums(codeModel: CodeModel): void {
  const apiVersionEnums = codeModel.enums.filter(
    (e) => (e.usage & UsageFlags.ApiVersionEnum) !== 0
  );

  if (apiVersionEnums.length <= 1) {
    return;
  }

  // Group ApiVersionEnum enums by namespace
  const byNamespace = new Map<string, typeof apiVersionEnums>();
  for (const e of apiVersionEnums) {
    const group = byNamespace.get(e.namespace);
    if (group) {
      group.push(e);
    } else {
      byNamespace.set(e.namespace, [e]);
    }
  }

  for (const [, group] of byNamespace) {
    if (group.length <= 1) {
      continue;
    }

    // Merge all values into the first enum, keeping unique values by value
    const primary = group[0];
    const seenValues = new Set(primary.values.map((v) => String(v.value)));
    for (let i = 1; i < group.length; i++) {
      for (const val of group[i].values) {
        if (!seenValues.has(String(val.value))) {
          seenValues.add(String(val.value));
          // Re-parent the enum value to the primary enum
          const mergedValue = { ...val, enumType: primary };
          primary.values.push(mergedValue);
        }
      }
    }

    // Remove the duplicate enums from the code model
    const duplicates = new Set(group.slice(1));
    codeModel.enums = codeModel.enums.filter((e) => !duplicates.has(e));
  }
}

/**
 * Walks the entire client tree in the code model and fixes clients with empty apiVersions.
 *
 * For each client that has methods but no apiVersions:
 * - If all methods share the same apiVersions list, assign it to the client.
 * - If methods have different apiVersions, report an error diagnostic asking the user
 *   to use @@clientLocation to separate methods with different API versions.
 *
 * In TCGC's hierarchical client model, parent clients don't carry apiVersions — child clients
 * inherit from parents. In mgmt SDK we flatten the hierarchy, so each client needs its own
 * apiVersions. We infer them from the client's methods.
 */
export function fixClientApiVersions(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext
): void {
  const allClients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client, allClients);
  }

  for (const client of allClients) {
    if (client.apiVersions.length > 0) {
      continue;
    }

    // Only care about clients that have methods (operations)
    if (!client.methods || client.methods.length === 0) {
      continue;
    }

    // Collect distinct apiVersions lists from all methods
    const methodApiVersionsMap = new Map<string, string[]>();
    for (const method of client.methods) {
      const key = method.apiVersions.join(",");
      if (!methodApiVersionsMap.has(key)) {
        methodApiVersionsMap.set(key, method.apiVersions);
      }
    }

    if (methodApiVersionsMap.size === 1) {
      // All methods share the same apiVersions — assign to the client
      const [sharedVersions] = methodApiVersionsMap.values();
      client.apiVersions = sharedVersions;
    } else {
      // Methods have different apiVersions — report diagnostic
      const details: string[] = [];
      for (const method of client.methods) {
        details.push(`  - ${method.name}: [${method.apiVersions.join(", ")}]`);
      }
      sdkContext.program.reportDiagnostic({
        code: "general-error",
        severity: "error",
        message:
          `Client '${client.name}' has empty apiVersions but its methods have inconsistent API versions. ` +
          `Use @@clientLocation decorator to move methods with different API versions into separate clients.\n` +
          `Methods and their API versions:\n${details.join("\n")}`,
        target: NoTarget
      });
    }
  }
}

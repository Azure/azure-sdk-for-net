// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  CSharpEmitterContext,
  InputClient
} from "@typespec/http-client-csharp";
import { NoTarget } from "@typespec/compiler";
import { traverseClient } from "./sdk-client-utils.js";

/**
 * Walks the entire client tree in the code model and fixes clients with empty apiVersions.
 *
 * For each client that has methods but no apiVersions:
 * - If all methods share the same apiVersions list, assign it to the client.
 * - If methods have different apiVersions, report an error diagnostic asking the user
 *   to use @@clientLocation to separate methods with different API versions.
 *
 * This works around a TCGC bug where combined multi-service clients
 * (created via @client({ service: [...] })) get empty apiVersions despite
 * their methods having known API versions.
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
      sdkContext.logger.reportDiagnostic({
        code: "general-error",
        messageId: "default",
        format: {
          message:
            `Client '${client.name}' has empty apiVersions but its methods have inconsistent API versions. ` +
            `Use @@clientLocation decorator to move methods with different API versions into separate clients.\n` +
            `Methods and their API versions:\n${details.join("\n")}`
        },
        target: NoTarget
      });
    }
  }
}

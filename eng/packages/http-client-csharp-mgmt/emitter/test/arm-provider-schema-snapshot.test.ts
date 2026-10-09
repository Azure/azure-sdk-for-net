// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, expect, it } from "vitest";

import {
  emitArmProviderSchemaSnapshots,
  legacyArmProviderSchemaFileName,
  resolveArmResourcesProviderSchemaFileName
} from "../src/arm-provider-schema-snapshot.js";
import {
  ArmProviderSchema,
  RequestPath,
  ResourceOperationKind,
  ResourceScopeKind
} from "../src/resource-metadata.js";

describe("emitArmProviderSchemaSnapshots", () => {
  it("writes sorted legacy and resolveArmResources schema snapshots", async () => {
    const writes = new Map<string, string>();
    const context = {
      emitterOutputDir: "/out",
      options: {},
      program: {
        host: {
          mkdirp: async () => {},
          writeFile: async (path: string, content: string) => {
            writes.set(path, content);
          }
        }
      }
    } as any;

    await emitArmProviderSchemaSnapshots(context, {
      legacy: createSchema("legacy", [
        "/subscriptions/{subscriptionId}/providers/Microsoft.Sample/widgets/{widgetName}",
        "/subscriptions/{subscriptionId}/providers/Microsoft.Sample/accounts/{accountName}"
      ]),
      resolveArmResources: createSchema("resolve", [
        "/subscriptions/{subscriptionId}/providers/Microsoft.Sample/widgets/{widgetName}"
      ])
    });

    const legacySnapshot = parseWrite(writes, legacyArmProviderSchemaFileName);
    const resolveSnapshot = parseWrite(
      writes,
      resolveArmResourcesProviderSchemaFileName
    );

    expect(
      legacySnapshot.resources.map((r: any) => r.resourceIdPattern)
    ).toEqual([
      "/subscriptions/{subscriptionId}/providers/Microsoft.Sample/accounts/{accountName}",
      "/subscriptions/{subscriptionId}/providers/Microsoft.Sample/widgets/{widgetName}"
    ]);
    expect(resolveSnapshot.resources).toHaveLength(1);
    expect(resolveSnapshot.resources[0].resourceModelId).toBe("resolve-0");
  });
});

function parseWrite(writes: Map<string, string>, fileName: string): any {
  const entry = [...writes.entries()].find(([path]) => path.endsWith(fileName));
  expect(entry).toBeDefined();
  return JSON.parse(entry![1]);
}

function createSchema(
  resourceIdPrefix: string,
  resourceIdPatterns: string[]
): ArmProviderSchema {
  return {
    resources: resourceIdPatterns.map((resourceIdPattern, index) => {
      const path = new RequestPath(resourceIdPattern);
      const scope = {
        kind: ResourceScopeKind.Subscription,
        scopeIdPattern: new RequestPath("/subscriptions/{subscriptionId}")
      };
      return {
        resourceModelId: `${resourceIdPrefix}-${index}`,
        metadata: {
          resourceIdPattern: path,
          resourceType: path.resourceType ?? "Microsoft.Sample/unknown",
          methods: [
            {
              methodId: `${resourceIdPrefix}-${index}.get`,
              kind: ResourceOperationKind.Read,
              operationPath: path,
              scope
            }
          ],
          scope,
          resourceName: `${resourceIdPrefix}${index}`,
          nameConstraints: {},
          apiVersions: [],
          rbacRoles: []
        }
      };
    }),
    nonResourceMethods: []
  };
}

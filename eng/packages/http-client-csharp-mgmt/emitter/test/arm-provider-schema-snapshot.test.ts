// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, it, vi } from "vitest";
import { deepStrictEqual, strictEqual } from "assert";
import { EmitContext } from "@typespec/compiler";
import {
  ArmProviderSchemaSnapshots,
  emitArmProviderSchemaSnapshots,
  legacyArmProviderSchemaFileName,
  resolveArmResourcesProviderSchemaFileName
} from "../src/arm-provider-schema-snapshot.js";
import {
  ArmProviderSchema,
  ResourceScopeKind,
  ResourceOperationKind,
  RequestPath,
  convertArmProviderSchemaToArguments
} from "../src/resource-metadata.js";
import { AzureMgmtEmitterOptions } from "../src/options.js";

describe("ARM provider schema snapshots", () => {
  it("writes both resource detection outputs", async () => {
    const legacySchema = createArmProviderSchema("legacy");
    const resolveArmResourcesSchema = createArmProviderSchema(
      "resolveArmResources"
    );
    const snapshots: ArmProviderSchemaSnapshots = {
      legacy: legacySchema,
      resolveArmResources: resolveArmResourcesSchema
    };

    const writeFile = vi.fn();
    const mkdirp = vi.fn();
    const context = {
      emitterOutputDir: "./generated",
      program: {
        host: {
          mkdirp,
          writeFile
        }
      }
    } as unknown as EmitContext<AzureMgmtEmitterOptions>;

    await emitArmProviderSchemaSnapshots(context, snapshots);

    strictEqual(mkdirp.mock.calls.length, 1);
    strictEqual(mkdirp.mock.calls[0][0], "./generated");
    strictEqual(writeFile.mock.calls.length, 2);

    const writtenFiles = new Map(
      writeFile.mock.calls.map(([path, content]) => [
        path.toString().split("/").at(-1),
        JSON.parse(content)
      ])
    );
    deepStrictEqual(
      writtenFiles.get(legacyArmProviderSchemaFileName),
      toJsonValue(convertArmProviderSchemaToArguments(legacySchema))
    );
    deepStrictEqual(
      writtenFiles.get(resolveArmResourcesProviderSchemaFileName),
      toJsonValue(
        convertArmProviderSchemaToArguments(resolveArmResourcesSchema)
      )
    );
  });
});

function toJsonValue(value: unknown): unknown {
  return JSON.parse(JSON.stringify(value));
}

function createArmProviderSchema(source: string): ArmProviderSchema {
  return {
    resources: [
      {
        resourceModelId: `${source}.Widget`,
        metadata: {
          resourceIdPattern: new RequestPath(
            `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}`
          ),
          resourceType: "Microsoft.Test/widgets",
          methods: [
            {
              methodId: `${source}.Widgets_Get`,
              kind: ResourceOperationKind.Read,
              operationPath: new RequestPath(
                `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}`
              ),
              scope: {
                kind: ResourceScopeKind.ResourceGroup,
                scopeIdPattern: new RequestPath(
                  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
                )
              }
            }
          ],
          scope: {
            kind: ResourceScopeKind.ResourceGroup,
            scopeIdPattern: new RequestPath(
              "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
            )
          },
          resourceName: "Widget",
          nameConstraints: {},
          apiVersions: ["2024-01-01"],
          rbacRoles: []
        }
      }
    ],
    nonResourceMethods: [
      {
        methodId: `${source}.Operations_List`,
        operationPath: new RequestPath(
          "/subscriptions/{subscriptionId}/providers/Microsoft.Test/operations"
        ),
        scope: {
          kind: ResourceScopeKind.Subscription,
          scopeIdPattern: new RequestPath("/subscriptions/{subscriptionId}")
        }
      }
    ]
  };
}

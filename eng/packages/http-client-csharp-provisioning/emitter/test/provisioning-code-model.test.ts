// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { deepStrictEqual, strictEqual } from "assert";
import { describe, it } from "vitest";
import {
  RequestPath,
  ResourceOperationKind,
  ResourceScopeKind,
  type NameConstraints,
  type RbacRole,
  type ValidArmResourceSchema
} from "../../../http-client-csharp-mgmt/emitter/src/resource-metadata.js";
import { buildResourceProjectionMetadata } from "../src/provisioning-code-model.js";

describe("resource projection metadata", () => {
  it("collapses resources and preserves distinct aggregate values", () => {
    const first = createResource({
      path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
      scope: ResourceScopeKind.ResourceGroup,
      apiVersions: ["2024-01-01"],
      methodKinds: [ResourceOperationKind.Read, ResourceOperationKind.Create],
      rbacRoles: [{ name: "FirstRole", value: "11111111" }]
    });
    const second = createResource({
      path: "/subscriptions/{subscriptionId}/providers/Microsoft.Test/widgets/{widgetName}",
      scope: ResourceScopeKind.Subscription,
      apiVersions: ["2024-01-01", "2024-02-01"],
      methodKinds: [ResourceOperationKind.Read],
      rbacRoles: [
        { name: "FirstRole", value: "11111111" },
        { name: "SecondRole", value: "22222222" }
      ]
    });

    const projection = buildResourceProjectionMetadata(
      [first, second],
      "Widget"
    );

    strictEqual(projection.resourceName, "Widget");
    strictEqual(projection.resourceType, "Microsoft.Test/widgets");
    deepStrictEqual(projection.resourceIdPatterns, [
      first.metadata.resourceIdPattern.path,
      second.metadata.resourceIdPattern.path
    ]);
    deepStrictEqual(projection.apiVersions, ["2024-01-01", "2024-02-01"]);
    deepStrictEqual(projection.rbacRoles, [
      { name: "FirstRole", value: "11111111" },
      { name: "SecondRole", value: "22222222" }
    ]);
    deepStrictEqual(projection.readableScopes, [
      ResourceScopeKind.ResourceGroup,
      ResourceScopeKind.Subscription
    ]);
    deepStrictEqual(projection.writableScopes, [
      ResourceScopeKind.ResourceGroup
    ]);
    strictEqual(projection.isExtensionResource, false);
  });

  it("uses conservative defaults for inconsistent per-resource values", () => {
    const first = createResource({
      path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/default",
      resourceName: "FirstResource",
      singletonResourceName: "default",
      parentResourceId:
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
      nameConstraints: { pattern: "[a-z]+", minLength: 1, maxLength: 24 }
    });
    const second = createResource({
      path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/current",
      resourceName: "SecondResource",
      singletonResourceName: "current",
      parentResourceId:
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/otherWidgets/{widgetName}",
      nameConstraints: { pattern: "[0-9]+", minLength: 1, maxLength: 24 }
    });

    const projection = buildResourceProjectionMetadata(
      [first, second],
      "Child"
    );

    strictEqual(projection.resourceName, "Child");
    strictEqual(projection.singletonResourceName, undefined);
    strictEqual(projection.parentResourceId, undefined);
    deepStrictEqual(projection.nameConstraints, {});
  });

  it("compares resource and parent paths structurally", () => {
    const first = createResource({
      path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
      parentResourceId:
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
    });
    const second = createResource({
      path: "/subscriptions/{sub}/resourceGroups/{group}/providers/microsoft.test/widgets/{name}",
      parentResourceId: "/subscriptions/{sub}/resourceGroups/{group}"
    });

    const projection = buildResourceProjectionMetadata(
      [first, second],
      "Widget"
    );

    deepStrictEqual(projection.resourceIdPatterns, [
      first.metadata.resourceIdPattern.path
    ]);
    strictEqual(
      projection.parentResourceId,
      first.metadata.parentResourceId?.path
    );
  });

  it("exposes scope metadata only for createable extension resources", () => {
    const readOnly = createResource({
      path: "/{scope}/providers/Microsoft.Test/extensions/{extensionName}",
      scope: ResourceScopeKind.Extension,
      methodKinds: [ResourceOperationKind.Read, ResourceOperationKind.Update]
    });
    const writable = createResource({
      path: "/{scope}/providers/Microsoft.Test/extensions/{extensionName}",
      scope: ResourceScopeKind.Extension,
      methodKinds: [ResourceOperationKind.Read, ResourceOperationKind.Create]
    });

    const readOnlyProjection = buildResourceProjectionMetadata(
      [readOnly],
      "Extension"
    );
    const writableProjection = buildResourceProjectionMetadata(
      [writable],
      "Extension"
    );

    deepStrictEqual(readOnlyProjection.writableScopes, []);
    strictEqual(readOnlyProjection.isExtensionResource, false);
    deepStrictEqual(writableProjection.writableScopes, [
      ResourceScopeKind.Extension
    ]);
    strictEqual(writableProjection.isExtensionResource, true);
  });
});

interface ResourceOptions {
  path: string;
  resourceName?: string;
  singletonResourceName?: string;
  parentResourceId?: string;
  nameConstraints?: NameConstraints;
  scope?: ResourceScopeKind;
  apiVersions?: string[];
  methodKinds?: ResourceOperationKind[];
  rbacRoles?: RbacRole[];
}

function createResource(options: ResourceOptions): ValidArmResourceSchema {
  const scopeKind = options.scope ?? ResourceScopeKind.ResourceGroup;
  const scope = {
    kind: scopeKind,
    scopeIdPattern: new RequestPath(""),
    scopeResourceType:
      scopeKind === ResourceScopeKind.Extension
        ? "Microsoft.Test/widgets"
        : undefined
  };

  return {
    resourceModelId: "Microsoft.Test.Widget",
    metadata: {
      resourceIdPattern: new RequestPath(options.path),
      resourceType: "Microsoft.Test/widgets",
      methods: (options.methodKinds ?? []).map((kind, index) => ({
        methodId: `Microsoft.Test.Widget.${kind}.${index}`,
        kind,
        operationPath: new RequestPath(options.path),
        scope
      })),
      scope,
      parentResourceId: options.parentResourceId
        ? new RequestPath(options.parentResourceId)
        : undefined,
      singletonResourceName: options.singletonResourceName,
      resourceName: options.resourceName ?? "Widget",
      nameConstraints: options.nameConstraints ?? {},
      apiVersions: options.apiVersions ?? [],
      rbacRoles: options.rbacRoles ?? []
    }
  };
}

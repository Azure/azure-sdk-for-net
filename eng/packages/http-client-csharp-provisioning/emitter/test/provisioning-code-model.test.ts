// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { deepStrictEqual, strictEqual, throws } from "assert";
import { CodeModel } from "@typespec/http-client-csharp";
import { describe, it } from "vitest";
import {
  RequestPath,
  ResourceOperationKind,
  ResourceScopeKind,
  type NameConstraints,
  type RbacRole,
  type ValidArmResourceSchema
} from "../../../http-client-csharp-mgmt/emitter/src/resource-metadata.js";
import {
  buildResourceNameFromResourceType,
  buildResourceProjections,
  buildResourceProjectionMetadata,
  determineResourceProjectionName,
  type ResourceProjection,
  validateResourceProjectionNames
} from "../src/provisioning-code-model.js";

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

    const projection = buildResourceProjectionMetadata([first, second]);

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

    const projection = buildResourceProjectionMetadata([first, second]);

    strictEqual(projection.singletonResourceName, undefined);
    strictEqual(projection.parentResourceId, undefined);
    deepStrictEqual(projection.nameConstraints, {});
  });

  it("builds a resource name from singular resource type segments", () => {
    strictEqual(
      buildResourceNameFromResourceType(
        "Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies"
      ),
      "SiteSlotBasicPublishingCredentialsPolicy"
    );
  });

  it("uses a consistent resource name before the model name", () => {
    strictEqual(
      determineResourceProjectionName(
        "ConsistentWidget",
        "WidgetModel",
        true,
        "Microsoft.Test/widgets"
      ),
      "ConsistentWidget"
    );
  });

  it("uses the model name when the model has one projection", () => {
    strictEqual(
      determineResourceProjectionName(
        undefined,
        "WidgetModel",
        true,
        "Microsoft.Test/widgets"
      ),
      "WidgetModel"
    );
  });

  it("uses resource type segments when the model has multiple projections", () => {
    strictEqual(
      determineResourceProjectionName(
        undefined,
        "PublishingPolicy",
        false,
        "Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies"
      ),
      "SiteSlotBasicPublishingCredentialsPolicy"
    );
  });

  it("resolves distinct names after building all projections", () => {
    const modelId = "Microsoft.Web.PublishingPolicy";
    const resources = [
      createResource({
        resourceModelId: modelId,
        resourceType: "Microsoft.Web/sites/basicPublishingCredentialsPolicies",
        resourceName: "WebSiteFtpPublishingCredentialsPolicy",
        path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/basicPublishingCredentialsPolicies/{policyName}"
      }),
      createResource({
        resourceModelId: modelId,
        resourceType: "Microsoft.Web/sites/basicPublishingCredentialsPolicies",
        resourceName: "ScmSiteBasicPublishingCredentialsPolicy",
        path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/basicPublishingCredentialsPolicies/{policyName}"
      }),
      createResource({
        resourceModelId: modelId,
        resourceType:
          "Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies",
        resourceName: "WebSiteSlotFtpPublishingCredentialsPolicy",
        path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName}/basicPublishingCredentialsPolicies/{policyName}"
      }),
      createResource({
        resourceModelId: modelId,
        resourceType:
          "Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies",
        resourceName: "ScmSiteSlotBasicPublishingCredentialsPolicy",
        path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName}/basicPublishingCredentialsPolicies/{policyName}"
      })
    ];
    const codeModel = {
      models: [
        {
          crossLanguageDefinitionId: modelId,
          name: "PublishingPolicy"
        }
      ]
    } as CodeModel;

    const projections = buildResourceProjections(codeModel, {
      resources
    } as Parameters<typeof buildResourceProjections>[1]);

    deepStrictEqual(
      projections.map((projection) => ({
        resourceName: projection.resourceName,
        resourceType: projection.resourceType
      })),
      [
        {
          resourceName: "SiteBasicPublishingCredentialsPolicy",
          resourceType: "Microsoft.Web/sites/basicPublishingCredentialsPolicies"
        },
        {
          resourceName: "SiteSlotBasicPublishingCredentialsPolicy",
          resourceType:
            "Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies"
        }
      ]
    );
  });

  it("rejects duplicate resolved resource projection names", () => {
    const projection = {
      resourceName: "Widget",
      resourceType: "Microsoft.Test/widgets",
      resourceModelId: "Microsoft.Test.Widget"
    } as ResourceProjection;

    throws(
      () =>
        validateResourceProjectionNames([
          projection,
          {
            ...projection,
            resourceName: "widget",
            resourceType: "Microsoft.Test/widget"
          }
        ]),
      /resolve to the same class name 'widget'/
    );
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

    const projection = buildResourceProjectionMetadata([first, second]);

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

    const readOnlyProjection = buildResourceProjectionMetadata([readOnly]);
    const writableProjection = buildResourceProjectionMetadata([writable]);

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
  resourceModelId?: string;
  resourceType?: string;
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
    resourceModelId: options.resourceModelId ?? "Microsoft.Test.Widget",
    metadata: {
      resourceIdPattern: new RequestPath(options.path),
      resourceType: options.resourceType ?? "Microsoft.Test/widgets",
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

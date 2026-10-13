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
  filterArmProviderSchemaToCodeModel,
  type ResourceProjection,
  validateResourceProjectionNames
} from "../src/provisioning-code-model.js";

describe("resource projection metadata", () => {
  it("filters ARM resources and methods to the selected code model without mutating the schema", () => {
    const resource = createResource({
      path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
      methodKinds: [
        ResourceOperationKind.Read,
        ResourceOperationKind.Create,
        ResourceOperationKind.Delete
      ]
    });
    const [read, create, remove] = resource.metadata.methods;
    const schema = {
      resources: [
        resource,
        {
          ...resource,
          resourceModelId: "Microsoft.Test.PreviewOnlyWidget"
        }
      ],
      nonResourceMethods: [read, create, remove].map((method) => ({
        methodId: method.methodId,
        operationPath: method.operationPath,
        scope: method.scope
      }))
    };
    const serializedSchema = {
      resources: schema.resources.map((entry) => ({
        resourceModelId: entry.resourceModelId,
        resourceType: entry.metadata.resourceType,
        methods: entry.metadata.methods.map((method) => ({
          methodId: method.methodId,
          kind: method.kind
        }))
      })),
      nonResourceMethods: schema.nonResourceMethods
    };
    const codeModel = {
      models: [{ crossLanguageDefinitionId: resource.resourceModelId }],
      clients: [
        {
          decorators: [
            {
              name: "Azure.ClientGenerator.Core.@armProviderSchema",
              arguments: serializedSchema
            }
          ],
          methods: [{ crossLanguageDefinitionId: read.methodId }],
          children: [
            {
              methods: [],
              children: [
                {
                  methods: [{ crossLanguageDefinitionId: create.methodId }]
                }
              ]
            }
          ]
        }
      ]
    } as CodeModel;

    const filtered = filterArmProviderSchemaToCodeModel(codeModel, schema);

    deepStrictEqual(filtered.resources, [
      {
        ...resource,
        metadata: { ...resource.metadata, methods: [read, create] }
      }
    ]);
    deepStrictEqual(
      filtered.nonResourceMethods.map((method) => method.methodId),
      [read.methodId, create.methodId]
    );
    strictEqual(schema.resources.length, 2);
    deepStrictEqual(resource.metadata.methods, [read, create, remove]);
    strictEqual(schema.nonResourceMethods.length, 3);
    deepStrictEqual(serializedSchema.resources, [
      {
        resourceModelId: resource.resourceModelId,
        resourceType: resource.metadata.resourceType,
        methods: [read, create].map((method) => ({
          methodId: method.methodId,
          kind: method.kind
        }))
      }
    ]);
    deepStrictEqual(
      serializedSchema.nonResourceMethods.map((method) => method.methodId),
      [read.methodId, create.methodId]
    );
  });

  it("keeps selected models with no selected methods read-only", () => {
    const resource = createResource({
      path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
      methodKinds: [ResourceOperationKind.Create]
    });
    const codeModel = {
      models: [{ crossLanguageDefinitionId: resource.resourceModelId }],
      clients: []
    } as CodeModel;

    const filtered = filterArmProviderSchemaToCodeModel(codeModel, {
      resources: [resource],
      nonResourceMethods: []
    });

    strictEqual(filtered.resources.length, 1);
    deepStrictEqual(filtered.resources[0].metadata.methods, []);
    deepStrictEqual(
      buildResourceProjectionMetadata(filtered.resources).writableScopes,
      []
    );
  });

  it("removes serialized parent edges outside the selected graph but preserves provisioning parent paths", () => {
    const resources = [
      createResource({ path: "/roots/{root}", resourceModelId: "Root" }),
      createResource({
        path: "/roots/{root}/children/{child}",
        resourceModelId: "Child",
        parentResourceId: "/roots/{root}"
      }),
      createResource({
        path: "/roots/{root}/excluded/{excluded}",
        resourceModelId: "Excluded",
        parentResourceId: "/roots/{root}"
      }),
      createResource({
        path: "/roots/{root}/excluded/{excluded}/children/{child}",
        resourceModelId: "Grandchild",
        parentResourceId: "/roots/{root}/excluded/{excluded}"
      })
    ];
    const serializedResources = resources.map((resource) => ({
      resourceModelId: resource.resourceModelId,
      resourceIdPattern: resource.metadata.resourceIdPattern.path,
      parentResourceId: resource.metadata.parentResourceId?.path,
      methods: []
    }));
    const serializedSchema = {
      resources: serializedResources,
      nonResourceMethods: []
    };
    const codeModel = {
      models: ["Root", "Child", "Grandchild"].map((id) => ({
        crossLanguageDefinitionId: id
      })),
      clients: [
        {
          methods: [],
          decorators: [
            {
              name: "Azure.ClientGenerator.Core.@armProviderSchema",
              arguments: serializedSchema
            }
          ]
        }
      ]
    } as CodeModel;

    const filtered = filterArmProviderSchemaToCodeModel(codeModel, {
      resources,
      nonResourceMethods: []
    });

    strictEqual(serializedSchema.resources.length, 3);
    strictEqual(
      serializedSchema.resources[1].parentResourceId,
      "/roots/{root}"
    );
    strictEqual(serializedSchema.resources[2].parentResourceId, undefined);
    strictEqual(
      serializedResources[3].parentResourceId,
      "/roots/{root}/excluded/{excluded}"
    );
    strictEqual(
      filtered.resources[2].metadata.parentResourceId?.path,
      "/roots/{root}/excluded/{excluded}"
    );
  });

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

  it("disambiguates shared-model name collisions using the full resource type", () => {
    const modelId = "Compute.VirtualMachineRunCommand";
    const resources = [
      createResource({
        resourceModelId: modelId,
        resourceType: "Microsoft.Compute/virtualMachines/runCommands",
        resourceName: "VirtualMachinesRunCommands",
        path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/runCommands/{commandName}"
      }),
      createResource({
        resourceModelId: modelId,
        resourceType:
          "Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands",
        resourceName: "virtualMachinesRunCommands",
        path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{scaleSetName}/virtualMachines/{vmName}/runCommands/{commandName}"
      })
    ];
    const codeModel = {
      models: [
        { crossLanguageDefinitionId: modelId, name: "VirtualMachineRunCommand" }
      ]
    } as CodeModel;

    const projections = buildResourceProjections(codeModel, {
      resources,
      nonResourceMethods: []
    });

    deepStrictEqual(
      projections.map((projection) => projection.resourceName),
      [
        "VirtualMachineRunCommand",
        "VirtualMachineScaleSetVirtualMachineRunCommand"
      ]
    );
  });

  it("rejects name collisions between different resource models", () => {
    const resources = [
      createResource({
        resourceModelId: "Microsoft.Test.FirstWidget",
        path: "/providers/Microsoft.Test/firstWidgets/{name}"
      }),
      createResource({
        resourceModelId: "Microsoft.Test.SecondWidget",
        resourceType: "Microsoft.Test/secondWidgets",
        path: "/providers/Microsoft.Test/secondWidgets/{name}"
      })
    ];
    const codeModel = {
      models: resources.map((resource) => ({
        crossLanguageDefinitionId: resource.resourceModelId,
        name: "Widget"
      }))
    } as CodeModel;

    throws(
      () =>
        buildResourceProjections(codeModel, {
          resources,
          nonResourceMethods: []
        }),
      /resolve to the same class name 'Widget'/
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

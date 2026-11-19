// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, expect, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import type { CSharpEmitterContext } from "../src/code-model-types.js";
import type { Program } from "@typespec/compiler";
import { getLibraryName } from "@azure-tools/typespec-client-generator-core";
import { resolveArmResources as resolveArmResourcesFromLibrary } from "@azure-tools/typespec-azure-resource-manager";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { resolveArmResources } from "../src/resolve-arm-resources-converter.js";
import {
  convertArmProviderSchemaToArguments,
  convertResourceMetadataToArguments
} from "../src/resource-metadata.js";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

function expectResolvedNamesMatchLibrary(
  program: Program,
  sdkContext: CSharpEmitterContext
) {
  const provider = resolveArmResourcesFromLibrary(program, {
    nameResolver: ({ kind, type }) =>
      kind === "resource" || type === undefined
        ? undefined
        : getLibraryName(sdkContext, type)
  });
  const schema = resolveArmResources(program, sdkContext);
  expect(schema.resources).toHaveLength(provider.resources?.length ?? 0);
  for (const resource of schema.resources) {
    const expected = provider.resources?.find(
      (resolved) =>
        resolved.resourceInstancePath ===
        resource.metadata.resourceIdPattern?.path
    );
    expect(expected).toBeDefined();
    expect(resource.metadata.resourceName).toBe(expected!.resourceName);
    expect(
      convertResourceMetadataToArguments(resource.metadata).resourceName
    ).toBe(expected!.resourceName);
  }
  return schema;
}

describe("resource-name provenance", () => {
  it.each(
    [
      ["armResourceRead", "get", "get"],
      ["armResourceCreateOrUpdate", "createOrUpdate", "put"],
      ["armResourceUpdate", "update", "patch"],
      ["armResourceDelete", "delete", "delete"]
    ].flatMap(([decorator, operation, verb]) =>
      [
        undefined,
        "IpWidget",
        ...(operation === "get" ? ["CustomIpWidget"] : [])
      ].map((name) => ({
        decorator,
        operation,
        verb,
        name
      }))
    )
  )(
    "tracks @$decorator with name $name",
    async ({ decorator, operation, verb, name }) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
model WidgetProperties { size?: int32; }
model IpWidget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<IpWidget>;
}
@armResourceOperations
interface Widgets {
  ${operation === "get" ? "" : "get is ArmResourceRead<IpWidget>;"}
  @autoRoute
  @${verb}
  @${decorator}(IpWidget${name === undefined ? "" : `, "${name}"`})
  ${operation}(...ResourceInstanceParameters<IpWidget>): IpWidget | ErrorResponse;
}
`,
        host
      );
      expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
        []
      );
      const sdkContext = await createCSharpSdkContext(
        createEmitterContext(program)
      );
      const [root] = createModel(sdkContext);
      for (const schema of [
        buildArmProviderSchema(sdkContext, root),
        expectResolvedNamesMatchLibrary(program, sdkContext)
      ]) {
        expect(schema.resources).toHaveLength(1);
        const expected = {
          resourceName: name ?? "IpWidget",
          resourceNameIsExplicit: name !== undefined
        };
        expect(
          convertResourceMetadataToArguments(schema.resources[0].metadata)
        ).toMatchObject(expected);
        expect(
          convertArmProviderSchemaToArguments(schema).resources[0]
        ).toMatchObject(expected);
      }
    }
  );

  it.each([false, true])(
    "uses a model client name for a single scope-specific occurrence (singleton: %s)",
    async (singleton) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
@clientName("CustomWidget", "csharp")
${singleton ? '@singleton("default")' : ""}
model Widget is TrackedResource<{}> {
  ...ResourceNameParameter<Widget>;
}
@armResourceOperations
interface Widgets {
  get is Azure.ResourceManager.Extension.Read<Azure.ResourceManager.Extension.ResourceGroup, Widget>;
}
`,
        host
      );
      expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
        []
      );
      const sdkContext = await createCSharpSdkContext(
        createEmitterContext(program)
      );
      const [root] = createModel(sdkContext);
      const legacy = buildArmProviderSchema(sdkContext, root);
      expect(legacy.resources).toHaveLength(1);
      expect(legacy.resources[0].metadata).toMatchObject({
        resourceName: "CustomWidget",
        resourceNameIsExplicit: true
      });
      const resolved = expectResolvedNamesMatchLibrary(program, sdkContext);
      expect(resolved.resources[0].metadata.resourceName).toBe(
        "ResourceGroupCustomWidget"
      );
    }
  );

  it.each([
    ["", "Widget", false],
    ['@@clientName(Widget, "CustomWidget", "csharp");', "CustomWidget", true],
    ['@@clientName(Widget, exact("IpWidget"), "csharp");', "IpWidget", true],
    ['@@clientName(Widget, "CustomWidget");', "CustomWidget", true],
    ['@@clientName(Widget, "CustomWidget", "java");', "Widget", false],
    ['@@clientName(Widget, "CustomWidget", "!csharp");', "Widget", false],
    ['@@clientName(Widget, "Widget", "csharp");', "Widget", true],
    ['@@clientName(Widgets, "CustomWidgets", "csharp");', "Widget", false],
    ['@@clientName(Widgets.get, "FetchWidget", "csharp");', "Widget", false],
    [
      '@@clientOption(Widgets.get, "resource-name", "NamedWidget", "csharp");',
      "NamedWidget",
      true
    ],
    [
      '@@clientOption(Widgets.get, "resource-name", "NamedWidget", "java");',
      "Widget",
      false
    ],
    [
      '@@clientName(Widget, "CustomWidget", "csharp");\n@@clientOption(Widgets.get, "resource-name", "NamedWidget", "csharp");',
      "NamedWidget",
      true
    ]
  ])("tracks %s", async (decorators, name, explicit) => {
    const host = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
model WidgetProperties { size?: int32; }
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}
@armResourceOperations
interface Widgets {
  get is ArmResourceRead<Widget>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Widget>;
}
${decorators.replaceAll("@@clientOption", '#suppress "@azure-tools/typespec-client-generator-core/client-option" "Testing resource-name provenance"\n@@clientOption')}
`,
      host
    );
    expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
      []
    );
    const sdkContext = await createCSharpSdkContext(
      createEmitterContext(program)
    );
    const [root] = createModel(sdkContext);
    const schema = buildArmProviderSchema(sdkContext, root);
    expect(schema.resources).toHaveLength(1);
    const metadata = schema.resources[0].metadata;
    expect(metadata.resourceName).toBe(name);
    expect(metadata.resourceNameIsExplicit).toBe(explicit);
    expect(convertResourceMetadataToArguments(metadata)).toMatchObject({
      resourceName: name,
      resourceNameIsExplicit: explicit
    });
    expect(
      convertArmProviderSchemaToArguments(schema).resources[0]
    ).toMatchObject({
      resourceName: name,
      resourceNameIsExplicit: explicit
    });
    expectResolvedNamesMatchLibrary(program, sdkContext);
  });

  it.each([
    ["csharp", '"CustomWidgets"', "CustomWidget"],
    ["csharp", 'exact("IpWidgets")', "IpWidget"],
    ["java", '"CustomWidgets"', undefined]
  ])(
    "uses %s interface override %s only for multi-path stems",
    async (scope, override, expected) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
model WidgetProperties { size?: int32; }
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}
@armResourceOperations
@clientName(${override}, "${scope}")
interface Widgets {
  get is Azure.ResourceManager.Extension.Read<Azure.ResourceManager.Extension.ResourceGroup, Widget>;
}
@armResourceOperations
interface SubscriptionWidgets {
  get is Azure.ResourceManager.Extension.Read<Azure.ResourceManager.Extension.Subscription, Widget>;
}
`,
        host
      );
      expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
        []
      );
      const sdkContext = await createCSharpSdkContext(
        createEmitterContext(program)
      );
      const [root] = createModel(sdkContext);
      const schema = buildArmProviderSchema(sdkContext, root);
      expect(schema.resources).toHaveLength(2);
      const resource = schema.resources.find(
        (r) => r.metadata.scope.kind === "ResourceGroup"
      )!;
      if (scope === "csharp") {
        expect(resource.metadata.resourceName).toBe(expected);
      } else {
        expect(resource.metadata.resourceName).not.toContain("Custom");
      }
      expect(resource.metadata.resourceNameIsExplicit).toBe(scope === "csharp");
      expect(
        schema.resources.find((r) => r.metadata.scope.kind === "Subscription")!
          .metadata.resourceNameIsExplicit
      ).toBe(false);
      const resolved = expectResolvedNamesMatchLibrary(program, sdkContext);
      expect(
        resolved.resources.map((r) => r.metadata.resourceName).sort()
      ).toEqual(["ResourceGroupWidget", "SubscriptionWidget"]);
    }
  );

  it.each([
    ["", "ResourceGroupWidget", false, "ResourceGroupWidgets"],
    [
      '@@clientName(ResourceGroupWidgets, "CustomWidgets", "csharp");',
      "CustomWidget",
      true,
      "ResourceGroupWidgets"
    ],
    [
      '#suppress "@azure-tools/typespec-client-generator-core/client-option" "Testing path-specific resource-name override"\n@@clientOption(ResourceGroupWidgets.get, "resource-name", "NamedWidget", "csharp");',
      "NamedWidget",
      true,
      "ResourceGroupWidgets"
    ],
    ["", "ResourceGroupAssignment", false, "ResourceGroupAssignments"]
  ])(
    "keeps shared-model stems path-specific: %s",
    async (decorator, name, explicit, interfaceName) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
@clientName("CustomWidget", "csharp")
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}
model WidgetProperties { size?: int32; }
@armResourceOperations
interface ${interfaceName} {
  get is Azure.ResourceManager.Extension.Read<Azure.ResourceManager.Extension.ResourceGroup, Widget>;
}
@armResourceOperations
interface SubscriptionWidgets {
  get is Azure.ResourceManager.Extension.Read<Azure.ResourceManager.Extension.Subscription, Widget>;
}
${decorator}
`,
        host
      );
      expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
        []
      );
      const sdkContext = await createCSharpSdkContext(
        createEmitterContext(program)
      );
      const [root] = createModel(sdkContext);
      const schema = buildArmProviderSchema(sdkContext, root);
      expect(schema.resources).toHaveLength(2);
      expect(
        schema.resources.map((r) => r.metadata.resourceName).sort()
      ).toEqual([name, "SubscriptionWidget"].sort());
      expect(
        schema.resources.find((r) => r.metadata.scope.kind === "ResourceGroup")!
          .metadata.resourceNameIsExplicit
      ).toBe(explicit);
      expect(
        schema.resources.find((r) => r.metadata.scope.kind === "Subscription")!
          .metadata.resourceNameIsExplicit
      ).toBe(false);
      const resolved = expectResolvedNamesMatchLibrary(program, sdkContext);
      expect(
        resolved.resources.map((r) => r.metadata.resourceName).sort()
      ).toEqual(["ResourceGroupCustomWidget", "SubscriptionCustomWidget"]);
    }
  );
});

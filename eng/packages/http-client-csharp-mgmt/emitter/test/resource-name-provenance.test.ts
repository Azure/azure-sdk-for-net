// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, expect, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
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

describe("resource-name provenance", () => {
  it.each([
    ["", "Widget", false],
    ['@@clientName(Widget, "CustomWidget", "csharp");', "CustomWidget", true],
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
    for (const schema of [
      buildArmProviderSchema(sdkContext, root),
      resolveArmResources(program, sdkContext)
    ]) {
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
    }
  });

  it.each(["csharp", "java"])(
    "uses %s interface overrides only for multi-path stems",
    async (scope) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
model WidgetProperties { size?: int32; }
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}
@armResourceOperations
@clientName("CustomWidgets", "${scope}")
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
      for (const schema of [
        buildArmProviderSchema(sdkContext, root),
        resolveArmResources(program, sdkContext)
      ]) {
        expect(schema.resources).toHaveLength(2);
        const resource = schema.resources.find(
          (r) => r.metadata.scope.kind === "ResourceGroup"
        )!;
        if (scope === "csharp") {
          expect(resource.metadata.resourceName).toBe("CustomWidget");
        } else {
          expect(resource.metadata.resourceName).not.toContain("Custom");
        }
        expect(resource.metadata.resourceNameIsExplicit).toBe(
          scope === "csharp"
        );
        expect(
          schema.resources.find(
            (r) => r.metadata.scope.kind === "Subscription"
          )!.metadata.resourceNameIsExplicit
        ).toBe(false);
      }
    }
  );
});

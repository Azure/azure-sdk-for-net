// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, expect, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import {
  removeConstructorRequirednessOverrides,
  removeUnsupportedDeprecations
} from "../src/emitter.js";
import type { InputClient } from "../src/code-model-types.js";
import { traverseClient } from "../src/sdk-client-utils.js";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

describe("Management code model", () => {
  it("removes unsupported model, property, and child-client operation deprecation", async () => {
    const host = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
      #deprecated "Deprecated resource."
      model Widget is ProxyResource<WidgetProperties> {
        ...ResourceNameParameter<Widget>;
      }

      #deprecated "Deprecated properties."
      model WidgetProperties {
        #deprecated "Deprecated property."
        legacy?: string;
        details?: CurrentDetails;
      }

      model CurrentDetails {
        value?: string;
      }

      interface Widgets {
        #deprecated "Deprecated operation."
        get is ArmResourceRead<Widget>;
      }
      `,
      host
    );
    expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
      []
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [original, diagnostics] = createModel(sdkContext);
    expect(diagnostics.filter((d) => d.severity === "error")).toEqual([]);
    expect(
      original.models
        .filter((model) => model.deprecation)
        .map((model) => model.deprecation)
    ).toEqual(
      expect.arrayContaining(["Deprecated resource.", "Deprecated properties."])
    );
    const modelNames = original.models.map((model) => model.name);
    expect(modelNames).toContain("CurrentDetails");
    const legacyProperty = original.models
      .flatMap((model) => model.properties)
      .find((property) => property.name === "legacy");
    expect(legacyProperty?.deprecation).toBe("Deprecated property.");
    const clients: InputClient[] = [];
    for (const client of original.clients) {
      traverseClient(client, clients);
    }
    const operations = clients.flatMap((client) =>
      client.methods.map((method) => method.operation)
    );
    expect(
      operations.some(
        (operation) => operation.deprecated === "Deprecated operation."
      )
    ).toBe(true);
    const operationNames = operations.map((operation) => operation.name);

    removeUnsupportedDeprecations(original);

    for (const model of original.models) {
      expect(model).not.toHaveProperty("deprecation");
    }
    expect(original.models.map((model) => model.name)).toEqual(modelNames);
    expect(legacyProperty).not.toHaveProperty("deprecation");
    for (const operation of operations) {
      expect(operation).not.toHaveProperty("deprecated");
    }
    expect(operations.map((operation) => operation.name)).toEqual(
      operationNames
    );
  });

  it("removes constructor-requiredness overrides without changing wire requiredness", async () => {
    const host = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
      model Widget is TrackedResource<WidgetProperties> {
        ...ResourceNameParameter<Widget>;
      }

      model WidgetProperties {
        @visibility(Lifecycle.Read, Lifecycle.Create)
        requiredOnCreate: string;
        alwaysRequired: string;
        optional?: string;
      }

      interface Widgets {
        createOrReplace is ArmResourceCreateOrReplaceSync<Widget>;
      }
      `,
      host
    );
    expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
      []
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [original, diagnostics] = createModel(sdkContext);
    expect(diagnostics.filter((d) => d.severity === "error")).toEqual([]);
    const relaxedProperties = original.models
      .flatMap((model) => model.properties)
      .filter((property) => property.requiredInConstructor === false);
    expect(relaxedProperties.map((property) => property.name)).toEqual(
      expect.arrayContaining(["location", "requiredOnCreate"])
    );

    removeConstructorRequirednessOverrides(original);

    const properties = original.models.flatMap((model) => model.properties);
    for (const property of properties) {
      expect(property).not.toHaveProperty("requiredInConstructor");
    }
    for (const name of ["location", "requiredOnCreate", "alwaysRequired"]) {
      expect(
        properties.find((property) => property.name === name)
      ).toMatchObject({ optional: false });
    }
    expect(
      properties.find((property) => property.name === "optional")
    ).toMatchObject({ optional: true });
  });
});

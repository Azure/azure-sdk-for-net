// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, expect, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import { removeConstructorRequirednessOverrides } from "../src/emitter.js";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

describe("Management code model", () => {
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

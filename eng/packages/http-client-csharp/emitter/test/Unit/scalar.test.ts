import { TestHost } from "@typespec/compiler/testing";
import { strictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

describe("Test GetInputType for scalar", () => {
  let runner: TestHost;

  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("azureLocation scalar", async () => {
    const program = await typeSpecCompile(
      `
        op test(@query location: azureLocation): void;
      `,
      runner
    );
    const context = await createCSharpSdkContext(createEmitterContext(program));
    const model = createModel(context);

    const inputParamArray =
      model.clients[0].methods[0].operation.parameters.filter(
        (p) => p.name === "location"
      );
    strictEqual(1, inputParamArray.length);
    const type = inputParamArray[0].type;
    strictEqual(type.kind, "string");
    strictEqual(type.name, "azureLocation");
    strictEqual(type.crossLanguageDefinitionId, "Azure.Core.azureLocation");
    strictEqual(type.baseType?.kind, "string");
    strictEqual(type.baseType.name, "string");
    strictEqual(type.baseType.crossLanguageDefinitionId, "TypeSpec.string");
  });
});

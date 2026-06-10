import { beforeEach, describe, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import { strictEqual } from "assert";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import {
  hasClientNameOverrideDecorator,
  setHasClientNameOverride
} from "../src/sdk-context-options.js";
import { TestHost } from "@typespec/compiler/testing";

describe("SDK context options", () => {
  let runner: TestHost;

  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("marks read-only model properties with clientName overrides", async () => {
    const program = await typeSpecCompile(
      `
model TestModel {
  @visibility(Lifecycle.Read)
  privateIpAddress?: string | null;
}

@@clientName(TestModel.privateIpAddress, "PrivateIPAddress", "csharp");
@@alternateType(TestModel.privateIpAddress, Azure.Core.ipV4Address | null, "csharp");

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Test operation intentionally uses a simple route."
@get
op get(): TestModel;
`,
      runner
    );
    const context = await createCSharpSdkContext(createEmitterContext(program));
    const [model] = createModel(context);

    setHasClientNameOverride(model, context);

    const testModel = model.models.find((m) => m.name === "TestModel");
    const property = testModel?.properties.find(
      (p) => p.serializedName === "privateIpAddress"
    );
    strictEqual(property?.name, "PrivateIPAddress");
    strictEqual(property?.type.kind, "nullable");
    strictEqual(property?.type.type.kind, "string");
    strictEqual(property?.type.type.name, "ipV4Address");
    strictEqual(
      property?.decorators?.some(
        (d) => d.name === hasClientNameOverrideDecorator
      ),
      true
    );
  });
});

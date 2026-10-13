import { createModel } from "@typespec/http-client-csharp";
import { ok, strictEqual } from "assert";
import { describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

describe("API-version override", () => {
  it.each(["namespace", "interface"])(
    "Preserves the override applied to a %s",
    async (target) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
        @Azure.Core.Legacy.overrideApiVersion("2022-10-01")
        ${target} Legacy {
          @get
          op get(...Azure.Core.Foundations.ApiVersionParameter): OkResponse;
        }
        `,
        host,
        { AuthDecorator: "" }
      );
      const context = await createCSharpSdkContext(createEmitterContext(program));
      const [model] = createModel(context);
      const root = model.clients[0];
      ok(root.children);
      const child = root.children.find((c) => c.name === "Legacy");
      ok(child);
      ok(child.parameters);
      const apiVersion = child.parameters.find((p) => p.isApiVersion);
      ok(apiVersion);
      strictEqual(apiVersion.defaultValue?.value, "2022-10-01");
      strictEqual(model.apiVersions[0], "2023-01-01-preview");
      const query = child.methods[0].operation.parameters.find(
        (p) => p.isApiVersion
      );
      ok(query);
      strictEqual(query.defaultValue?.value, "2022-10-01");
    }
  );
});

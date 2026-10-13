import { createModel } from "@typespec/http-client-csharp";
import { ok, strictEqual } from "assert";
import { describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { applyApiVersionOverrides } from "../../src/lib/api-version-override.js";

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
        interface Regular {
          @route("/regular")
          @get
          op get(...Azure.Core.Foundations.ApiVersionParameter): OkResponse;
        }
        `,
        host,
        { AuthDecorator: "" }
      );
      const context = await createCSharpSdkContext(
        createEmitterContext(program)
      );
      const [model] = createModel(context);
      applyApiVersionOverrides(context);
      const root = model.clients[0];
      ok(root.children);
      const child = root.children.find((c) => c.name === "Legacy");
      ok(child);
      ok(child.decorators);
      strictEqual(
        child.decorators.some(
          (d) => d.name === "Azure.Core.Legacy.@overrideApiVersion"
        ),
        true
      );
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
      const regular = root.children.find((c) => c.name === "Regular");
      ok(regular);
      ok(regular.decorators);
      strictEqual(
        regular.decorators.some(
          (d) => d.name === "Azure.Core.Legacy.@overrideApiVersion"
        ),
        false
      );
      strictEqual(
        regular.parameters?.find((p) => p.isApiVersion)?.defaultValue?.value,
        "2023-01-01-preview"
      );
    }
  );

  it("Preserves an inherited override when the client hierarchy skips its namespace", async () => {
    const host = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
      @versioned(Versions)
      @service
      @client
      namespace Root {
        enum Versions {
          "2023-01-01-preview"
        }
        @Azure.Core.Legacy.overrideApiVersion("2022-10-01")
        namespace Legacy {
          @client
          interface Child {
            @get
            op get(...Azure.Core.Foundations.ApiVersionParameter): OkResponse;
          }
        }
      }
      `,
      host,
      { IsNamespaceNeeded: false, IsTCGCNeeded: true }
    );
    const context = await createCSharpSdkContext(createEmitterContext(program));
    const [model] = createModel(context);
    applyApiVersionOverrides(context);
    const root = model.clients.find((c) => c.name === "Root");
    ok(root);
    const child = root.children?.find((c) => c.name === "Child");
    ok(child);
    strictEqual(child.parent, root);
    strictEqual(
      child.decorators?.find(
        (d) => d.name === "Azure.Core.Legacy.@overrideApiVersion"
      )?.arguments.version,
      "2022-10-01"
    );
    strictEqual(
      root.decorators?.some(
        (d) => d.name === "Azure.Core.Legacy.@overrideApiVersion"
      ) ?? false,
      false
    );
  });

  it.each([false, true])(
    "Preserves the override on a relocated operation (alias: %s)",
    async (alias) => {
      const host = await createEmitterTestHost();
      const program = await typeSpecCompile(
        `
      @Azure.Core.Legacy.overrideApiVersion("2022-10-01")
      interface Original {
        ${alias ? "" : '@clientLocation("Legacy")'}
        @get
        op get(...Azure.Core.Foundations.ApiVersionParameter): OkResponse;
      }
      ${
        alias
          ? `
      @clientLocation("Legacy")
      @route("/alias")
      op relocated is Original.get;
      `
          : ""
      }
      `,
        host,
        { AuthDecorator: "", IsTCGCNeeded: true }
      );
      const context = await createCSharpSdkContext(
        createEmitterContext(program)
      );
      const [model] = createModel(context);
      applyApiVersionOverrides(context);
      const child = model.clients[0].children?.find((c) => c.name === "Legacy");
      ok(child);
      strictEqual(
        child.decorators?.find(
          (d) => d.name === "Azure.Core.Legacy.@overrideApiVersion"
        )?.arguments.version,
        "2022-10-01"
      );
      strictEqual(
        child.parameters?.find((p) => p.isApiVersion)?.defaultValue?.value,
        "2022-10-01"
      );
    }
  );
});

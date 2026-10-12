import { beforeEach, describe, expect, it } from "vitest";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import {
  apiVersionOverrideMarker,
  markApiVersionOverrides
} from "../src/api-version-override.js";
import type { CodeModel, InputClient } from "../src/code-model-types.js";
import { traverseClient } from "../src/sdk-client-utils.js";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

function getMethods(model: CodeModel) {
  const clients: InputClient[] = [];
  for (const client of model.clients) traverseClient(client, clients);
  return clients.flatMap((c) => c.methods);
}

describe("API-version wire defaults", () => {
  let host: TestHost;
  beforeEach(async () => {
    host = await createEmitterTestHost();
  });

  it("preserves namespace and interface defaults without changing availability", async () => {
    const program = await typeSpecCompile(
      `
      @@Azure.Core.Legacy.overrideApiVersion(Microsoft.ContosoProviderHub, "opaque-namespace");
      interface NamespaceOperations {
        @autoRoute
        check is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
      }
      @Azure.Core.Legacy.overrideApiVersion("opaque-interface")
      interface InterfaceOperations {
        @autoRoute
        checkOther is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
      }
      `,
      host
    );
    expect(program.diagnostics.filter((d) => d.severity === "error")).toEqual(
      []
    );
    const context = await createCSharpSdkContext(createEmitterContext(program));
    const [model, diagnostics] = createModel(context);
    expect(diagnostics.filter((d) => d.severity === "error")).toEqual([]);
    const methods = getMethods(model);
    expect(methods).toHaveLength(2);
    const defaults = methods.map(
      (m) =>
        m.operation.parameters.find((p) => p.isApiVersion)?.defaultValue?.value
    );
    expect(defaults.sort()).toEqual(["opaque-interface", "opaque-namespace"]);
    for (const method of methods) {
      expect(method.apiVersions).toEqual(["2021-10-01-preview"]);
    }
    expect(model.apiVersions).toEqual(["2021-10-01-preview"]);
  });

  it("keeps declaration defaults after relocation into a shared client", async () => {
    const program = await typeSpecCompile(
      `
      namespace Nested {
        @Azure.Core.Legacy.overrideApiVersion("opaque-source")
        interface Source {
          @autoRoute
          moved is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
        }
        @Azure.Core.Legacy.overrideApiVersion("2021-10-01-preview")
        interface SameVersion {
          @autoRoute
          same is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
        }
        interface Ordinary {
          @autoRoute
          ordinary is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
        }
        @@clientLocation(Source.moved, "Shared");
        @@clientLocation(SameVersion.same, "Shared");
        @@clientLocation(Ordinary.ordinary, "Shared");
      }
    `,
      host
    );
    const context = await createCSharpSdkContext(createEmitterContext(program));
    const [model] = createModel(context);
    markApiVersionOverrides(model, context);
    const methods = getMethods(model);
    expect(methods).toHaveLength(3);
    for (const method of methods) {
      const version = method.operation.parameters.find((p) => p.isApiVersion)
        ?.defaultValue?.value;
      expect(version).toBe(
        method.name === "moved" ? "opaque-source" : "2021-10-01-preview"
      );
      expect(
        method.operation.decorators.some(
          (d) => d.name === apiVersionOverrideMarker
        )
      ).toBe(method.name !== "ordinary");
      expect(method.apiVersions).toEqual(["2021-10-01-preview"]);
    }
  });

  it("uses the nearest namespace and follows inherited operation declarations", async () => {
    const program = await typeSpecCompile(
      `
      @Azure.Core.Legacy.overrideApiVersion("outer-wire")
      namespace Outer {
        @Azure.Core.Legacy.overrideApiVersion("inner-wire")
        namespace Inner {
          interface Operations {
            @autoRoute
            nested is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
          }
        }
        @Azure.Core.Legacy.overrideApiVersion("source-wire")
        interface Source {
          @autoRoute
          source is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
        }
      }
      interface Inherited {
        inherited is Outer.Source.source;
      }
    `,
      host
    );
    const context = await createCSharpSdkContext(createEmitterContext(program));
    const [model] = createModel(context);
    markApiVersionOverrides(model, context);
    const methods = getMethods(model);
    for (const [name, expected] of [
      ["nested", "inner-wire"],
      ["inherited", "source-wire"]
    ]) {
      const method = methods.find((m) => m.name === name)!;
      expect(
        method.operation.parameters.find((p) => p.isApiVersion)?.defaultValue
          ?.value
      ).toBe(expected);
      expect(
        method.operation.decorators.some(
          (d) => d.name === apiVersionOverrideMarker
        )
      ).toBe(true);
      expect(method.apiVersions).toEqual(["2021-10-01-preview"]);
    }
  });

  it("retains per-service defaults in a combined cross-RP client", async () => {
    host.addTypeSpecFile(
      "main.tsp",
      `
      import "@typespec/http";
      import "@typespec/versioning";
      import "@azure-tools/typespec-azure-core";
      import "@azure-tools/typespec-client-generator-core";
      using TypeSpec.Http;
      using TypeSpec.Versioning;
      using Azure.ClientGenerator.Core;
      @service @versioned(NetworkVersions)
      namespace Microsoft.Network {
        enum NetworkVersions { current: "2024-05-01" }
        @get @route("/network")
        op getNetwork(@query("api-version") apiVersion: string): string;
      }
      @service @versioned(ComputeVersions)
      @Azure.Core.Legacy.overrideApiVersion("compute-legacy")
      namespace Microsoft.Compute {
        enum ComputeVersions { current: "2023-03-01" }
        @get @route("/compute")
        op getCompute(@query("api-version") apiVersion: string): string;
      }
      @client({name: "Combined", service: [Microsoft.Network, Microsoft.Compute], autoMergeService: true})
      namespace Combined {}
    `
    );
    await host.compile("main.tsp");
    const context = await createCSharpSdkContext(
      createEmitterContext(host.program)
    );
    const [model] = createModel(context);
    markApiVersionOverrides(model, context);
    const methods = getMethods(model);
    expect(methods).toHaveLength(2);
    for (const method of methods) {
      const compute = method.name === "getCompute";
      expect(
        method.operation.parameters.find((p) => p.isApiVersion)?.defaultValue
          ?.value
      ).toBe(compute ? "compute-legacy" : "2024-05-01");
      expect(method.apiVersions).toEqual([
        compute ? "2023-03-01" : "2024-05-01"
      ]);
      expect(
        method.operation.decorators.some(
          (d) => d.name === apiVersionOverrideMarker
        )
      ).toBe(compute);
    }
  });

  it.each(["", "   "])(
    "reports the upstream diagnostic for invalid override %j",
    async (value) => {
      host.addTypeSpecFile(
        "main.tsp",
        `
      import "@azure-tools/typespec-azure-core";
      @Azure.Core.Legacy.overrideApiVersion(${JSON.stringify(value)})
      namespace Test;
    `
      );
      const [, diagnostics] = await host.compileAndDiagnose("main.tsp");
      expect(
        diagnostics.some(
          (d) =>
            d.code ===
            "@azure-tools/typespec-azure-core/invalid-api-version-override"
        )
      ).toBe(true);
    }
  );
});

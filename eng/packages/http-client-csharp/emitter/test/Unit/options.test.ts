import { Program } from "@typespec/compiler";
import { beforeEach, describe, it, vi } from "vitest";
import {
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { AzureEmitterOptions } from "../../src/options.js";
import { $onEmit } from "../../src/emitter.js";
import { strictEqual, deepStrictEqual } from "assert";

describe("Configuration tests", async () => {
  let program: Program;

  beforeEach(async () => {
    const runner = await createEmitterTestHost();
    program = await typeSpecCompile(
      `
          `,
      runner
    );
    vi.mock("@typespec/http-client-csharp", async (importOriginal) => {
      const actual =
        await importOriginal<typeof import("@typespec/http-client-csharp")>();
      return {
        ...actual,
        $onEmit: async () => {
          // do nothing
        }
      };
    });
  });

  it("Diagnostic is logged when model-namespace is set without namespace", async () => {
    const options: AzureEmitterOptions = {
      "model-namespace": true
    };
    const context = createEmitterContext(program, options);
    $onEmit(context);
    strictEqual(program.diagnostics.length, 1);
    strictEqual(
      program.diagnostics[0].code,
      "@azure-typespec/http-client-csharp/invalid-model-namespace-usage"
    );
  });
  it("Diagnostic is NOT logged when model-namespace AND namespace are set", async () => {
    const options: AzureEmitterOptions = {
      "model-namespace": true,
      namespace: "Azure.Testing"
    };
    const context = createEmitterContext(program, options);
    $onEmit(context);
    strictEqual(program.diagnostics.length, 0);
  });
  it("Diagnostic is NOT logged when NEITHER model-namespace NOR namespace are set", async () => {
    const context = createEmitterContext(program);
    $onEmit(context);
    strictEqual(program.diagnostics.length, 0);
  });
  it("package-name defaults to namespace", async () => {
    const options: AzureEmitterOptions = {
      namespace: "Test.Namespace"
    };
    const context = createEmitterContext(program, options);
    $onEmit(context);
    strictEqual(program.diagnostics.length, 0);
    strictEqual(context.options.namespace, "Test.Namespace");
    strictEqual(context.options["package-name"], "Test.Namespace");
  });
  it("package-name undefined if namespace and package-name not set", async () => {
    const context = createEmitterContext(program);
    $onEmit(context);
    strictEqual(program.diagnostics.length, 0);
    strictEqual(context.options["package-name"], undefined);
  });
  it("package-name value used if set", async () => {
    const options: AzureEmitterOptions = {
      namespace: "Test.Namespace",
      "package-name": "Test.Package"
    };
    const context = createEmitterContext(program, options);
    $onEmit(context);
    strictEqual(program.diagnostics.length, 0);
    strictEqual(context.options.namespace, "Test.Namespace");
    strictEqual(context.options["package-name"], "Test.Package");
  });

  describe("Additional decorators configuration", () => {
    it("adds default decorator when sdk-context-options is not set", async () => {
      const context = createEmitterContext(program);
      await $onEmit(context);

      strictEqual(program.diagnostics.length, 0);
      deepStrictEqual(
        context.options["sdk-context-options"]?.additionalDecorators,
        ["Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"]
      );
    });

    it("adds default decorator when sdk-context-options is empty", async () => {
      const options: AzureEmitterOptions = {
        "sdk-context-options": {}
      };
      const context = createEmitterContext(program, options);
      await $onEmit(context);

      strictEqual(program.diagnostics.length, 0);
      deepStrictEqual(
        context.options["sdk-context-options"]?.additionalDecorators,
        ["Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"]
      );
    });

    it("adds default decorator when additionalDecorators is undefined", async () => {
      const options: AzureEmitterOptions = {
        "sdk-context-options": {
          additionalDecorators: undefined
        }
      };
      const context = createEmitterContext(program, options);
      await $onEmit(context);

      strictEqual(program.diagnostics.length, 0);
      deepStrictEqual(
        context.options["sdk-context-options"]?.additionalDecorators,
        ["Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"]
      );
    });

    it("merges with existing decorators when additionalDecorators is an array", async () => {
      const options: AzureEmitterOptions = {
        "sdk-context-options": {
          additionalDecorators: [
            "Existing.Decorator.One",
            "Existing.Decorator.Two"
          ]
        }
      };
      const context = createEmitterContext(program, options);
      await $onEmit(context);

      strictEqual(program.diagnostics.length, 0);
      deepStrictEqual(
        context.options["sdk-context-options"]?.additionalDecorators,
        [
          "Existing.Decorator.One",
          "Existing.Decorator.Two",
          "Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"
        ]
      );
    });

    it("handles non-array additionalDecorators by treating as empty", async () => {
      const options: AzureEmitterOptions = {
        "sdk-context-options": {
          additionalDecorators: "not-an-array" as any
        }
      };
      const context = createEmitterContext(program, options);
      await $onEmit(context);

      strictEqual(program.diagnostics.length, 0);
      deepStrictEqual(
        context.options["sdk-context-options"]?.additionalDecorators,
        ["Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"]
      );
    });
    it("preserves existing properties in sdk-context-options", async () => {
      const options: AzureEmitterOptions = {
        "sdk-context-options": {
          versioning: { previewStringRegex: /-preview$/ },
          additionalDecorators: ["Existing.Decorator"]
        }
      };
      const context = createEmitterContext(program, options);
      await $onEmit(context);

      strictEqual(program.diagnostics.length, 0);
      strictEqual(
        context.options["sdk-context-options"]?.versioning?.previewStringRegex
          ?.source,
        "-preview$"
      );
      deepStrictEqual(
        context.options["sdk-context-options"]?.additionalDecorators,
        [
          "Existing.Decorator",
          "Azure\\.ClientGenerator\\.Core\\.@useSystemTextJsonConverter"
        ]
      );
    });
  });
});

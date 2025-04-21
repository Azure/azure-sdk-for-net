import { Program } from "@typespec/compiler";
import { beforeEach, describe, it } from "vitest";
import {
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { AzureEmitterOptions } from "../../src/options.js";
import { $onEmit } from "../../src/emitter.js";
import { strictEqual } from "assert";

describe("Configuration tests", async () => {
  let program: Program;

  beforeEach(async () => {
    const runner = await createEmitterTestHost();
    program = await typeSpecCompile(
      `
          `,
      runner
    );
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
});

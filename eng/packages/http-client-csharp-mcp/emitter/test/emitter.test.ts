// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { readFile } from "node:fs/promises";
import { EmitContext, perf } from "@typespec/compiler";
import { createTestHost } from "@typespec/compiler/testing";
import { emitCodeModel } from "@typespec/http-client-csharp";
import { HttpTestLibrary } from "@typespec/http/testing";
import { beforeEach, describe, expect, it, vi } from "vitest";
import {
  $decorators,
  $onValidate,
  getMcpConfiguration
} from "../src/decorators.js";
import { $onEmit } from "../src/emitter.js";
import { $lib } from "../src/lib/lib.js";
import { McpEmitterOptions } from "../src/options.js";

vi.mock("@typespec/http-client-csharp", async (importOriginal) => ({
  ...(await importOriginal<typeof import("@typespec/http-client-csharp")>()),
  emitCodeModel: vi.fn()
}));

async function createContext(
  options: McpEmitterOptions = {},
  source?: string
): Promise<EmitContext<McpEmitterOptions>> {
  const host = await createTestHost({ libraries: [HttpTestLibrary] });
  host.addJsFile("mcp.js", { $lib, $decorators, $onValidate });
  const library = await readFile(
    new URL("../../lib/main.tsp", import.meta.url),
    "utf8"
  );
  host.addTypeSpecFile(
    "mcp.tsp",
    library.replace("../dist/emitter/index.js", "./mcp.js")
  );
  const storage =
    source ??
    (await readFile(
      new URL("./fixtures/sdk-binding.tsp", import.meta.url),
      "utf8"
    ));
  host.addTypeSpecFile("main.tsp", 'import "./mcp.tsp";\n' + storage);
  await host.compile("main.tsp");
  return {
    program: host.program,
    emitterOutputDir: "/output",
    options,
    perf
  };
}

describe("MCP emitter", () => {
  beforeEach(() => {
    vi.mocked(emitCodeModel).mockReset();
    vi.mocked(emitCodeModel).mockResolvedValue([undefined, []]);
  });

  it("preserves the legacy SDK-binding projection", async () => {
    const { program } = await createContext();
    const model = getMcpConfiguration(program);
    expect(model?.namespace).toBe("Azure.Mcp.Tools.Storage.GeneratedMcp");
    expect(model?.operations.map((tool) => tool.operationId)).toEqual([
      "StoragePilot.Containers.create"
    ]);
    expect(model?.composites).toHaveLength(3);
  });

  it.each(["augment", "direct"])(
    "selects only the original command operation, not inherited client aliases (%s)",
    async (style) => {
      const configuration = `#{
        id: "12b53c92-f2cf-4a1a-880d-c6f44a0d49d6",
        path: "example item create",
        title: "Create item",
        commandType: "Example.ItemCreateCommand",
        handler: #{type: "Example.IService", member: "CreateAsync"},
        resultName: "Item",
        safety: #{}
      }`;
      const source = `
        using Azure.Mcp;
        using TypeSpec.Http;
        @service @server("{endpoint}", "Endpoint.", {endpoint: url})
        @mcpService(#{outputNamespace: "Example.Generated"})
        namespace Example;
        interface Items {
          ${style === "direct" ? `@command(${configuration})` : ""}
          @put @route("/items/{name}")
          create(@path name: string): void;
          @get @route("/items/{name}")
          get(@path name: string): void;
        }
        @route("/client") interface ItemClient extends Items {}
        ${style === "augment" ? `@@command(Items.create, ${configuration});` : ""}
      `;
      const { program } = await createContext({}, source);
      const model = getMcpConfiguration(program);
      expect(model?.operations).toEqual([]);
      expect(model?.commands.map((command) => command.operationId)).toEqual([
        "Example.Items.create"
      ]);
      expect(model?.metadataReferences).toEqual([]);
      expect(model?.composites).toEqual([]);
      expect(model?.commands[0]).not.toHaveProperty("binding");
      expect(model?.commands[0]).not.toHaveProperty("wire");
      expect(model?.commands[0]).not.toHaveProperty("types");
    }
  );

  it.each([false, true])(
    "retains transport only when save-inputs=%s",
    async (saveInputs) => {
      const context = await createContext({ "save-inputs": saveInputs });
      await $onEmit(context);
      const read = context.program.host.readFile(
        "/output/tspMcpCodeModel.json"
      );
      if (saveInputs) {
        const file = await read;
        expect(JSON.parse(file.text).operations[0].operationId).toBe(
          "StoragePilot.Containers.create"
        );
      } else {
        await expect(read).rejects.toThrow();
      }
    }
  );

  it("uses the sibling emitter-extension-path contract and preserves frontend options", async () => {
    const context = await createContext({
      "package-name": "Azure.Mcp.Tools.Storage",
      "new-project": false,
      "generator-name": "UnreviewedGenerator",
      "unreferenced-types-handling": "removeOrInternalize"
    });
    await $onEmit(context);
    expect(emitCodeModel).toHaveBeenCalledExactlyOnceWith({
      ...context,
      options: {
        ...context.options,
        "generator-name": "McpGenerator",
        "emitter-extension-path": new URL("../src/emitter.ts", import.meta.url)
          .href,
        "unreferenced-types-handling": "keepAll"
      }
    });
    expect(context.options.plugins).toBeUndefined();
  });

  it("deletes private transport on backend failure without hiding the error", async () => {
    const context = await createContext();
    vi.mocked(emitCodeModel).mockRejectedValue(
      new Error("SDK mapping rejected")
    );
    await expect($onEmit(context)).rejects.toThrow("SDK mapping rejected");
    await expect(
      context.program.host.readFile("/output/tspMcpCodeModel.json")
    ).rejects.toThrow();
  });

  it("retains private transport for diagnostics on failure when requested", async () => {
    const context = await createContext({ "save-inputs": true });
    vi.mocked(emitCodeModel).mockRejectedValue(
      new Error("SDK mapping rejected")
    );
    await expect($onEmit(context)).rejects.toThrow("SDK mapping rejected");
    const file = await context.program.host.readFile(
      "/output/tspMcpCodeModel.json"
    );
    expect(JSON.parse(file.text).namespace).toBe(
      "Azure.Mcp.Tools.Storage.GeneratedMcp"
    );
  });
});

import { beforeEach, describe, it, vi } from "vitest";
import {
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { AzureEmitterOptions } from "../../src/options.js";
import { $onEmit } from "../../src/emitter.js";
import { strictEqual, ok, deepStrictEqual } from "assert";

describe("Metadata generation tests", async () => {
  let writeFileMock: any;
  let mkdirpMock: any;

  beforeEach(async () => {
    // Mock the file writing and directory creation to capture what would be written
    writeFileMock = vi.fn().mockResolvedValue(undefined);
    mkdirpMock = vi.fn().mockResolvedValue(undefined);

    vi.mock("@typespec/http-client-csharp", async (importOriginal) => {
      const actual =
        await importOriginal<typeof import("@typespec/http-client-csharp")>();
      return {
        ...actual,
        emitCodeModel: async () => {
          return [undefined, []];
        }
      };
    });
  });

  it("Generates metadata.json with apiVersions map from TypeSpec", async () => {
    const runner = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
      @service(#{
        title: "Test Service",
      })
      namespace TestService {
        @get
        op getItem(): string;
      }
      `,
      runner
    );

    const originalHost = program.host;
    program.host = {
      ...originalHost,
      writeFile: writeFileMock,
      mkdirp: mkdirpMock
    };

    const options: AzureEmitterOptions = {};
    const context = createEmitterContext(program, options);

    await $onEmit(context);

    // Check that metadata file was written
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) =>
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);

    // Check the path
    const filePath = metadataCalls[0][0];
    ok(filePath.includes("metadata.json"));

    // Check the content - should use apiVersions map with namespace as key
    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    ok(parsed.apiVersions !== undefined, "apiVersions property should exist");
    ok(
      parsed.apiVersion === undefined,
      "deprecated apiVersion property should not exist"
    );
    strictEqual(typeof parsed.apiVersions, "object");
    strictEqual(
      parsed.apiVersions["Azure.Csharp.Testing"],
      "2023-01-01-preview"
    );
  });

  it("Generates metadata.json with empty apiVersions when TypeSpec has no versioning", async () => {
    const runner = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
      @service(#{
        title: "Test Service",
      })
      namespace TestService {
        @get
        op getItem(): string;
      }
      `,
      runner,
      { IsNamespaceNeeded: false } // Skip the default namespace which includes versioning
    );

    const originalHost = program.host;
    program.host = {
      ...originalHost,
      writeFile: writeFileMock,
      mkdirp: mkdirpMock
    };

    const options: AzureEmitterOptions = {};
    const context = createEmitterContext(program, options);

    await $onEmit(context);

    // Check that metadata file was written with empty apiVersions object when no versioning is defined
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) =>
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);

    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    ok(parsed.apiVersions !== undefined, "apiVersions property should exist");
    ok(
      parsed.apiVersion === undefined,
      "deprecated apiVersion property should not exist"
    );
    deepStrictEqual(parsed.apiVersions, {});

    strictEqual(program.diagnostics.length, 0);
  });

  it("Generates metadata.json with apiVersions for multi-service TypeSpec", async () => {
    const runner = await createEmitterTestHost();
    const program = await typeSpecCompile(
      `
      @service(#{
        title: "Service A",
      })
      @versioned(ServiceAVersions)
      namespace ServiceA {
        enum ServiceAVersions {
          "2024-01-01"
        }

        @get
        op getItemA(): string;
      }

      @service(#{
        title: "Service B",
      })
      @versioned(ServiceBVersions)
      namespace ServiceB {
        enum ServiceBVersions {
          "2024-06-01"
        }

        @get
        op getItemB(): string;
      }
      `,
      runner,
      { IsNamespaceNeeded: false }
    );

    const originalHost = program.host;
    program.host = {
      ...originalHost,
      writeFile: writeFileMock,
      mkdirp: mkdirpMock
    };

    const options: AzureEmitterOptions = {};
    const context = createEmitterContext(program, options);

    await $onEmit(context);

    // Check that metadata file was written
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) =>
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);

    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    ok(parsed.apiVersions !== undefined, "apiVersions property should exist");
    ok(
      parsed.apiVersion === undefined,
      "deprecated apiVersion property should not exist"
    );
    strictEqual(typeof parsed.apiVersions, "object");
    const keys = Object.keys(parsed.apiVersions);
    ok(keys.length >= 1, "apiVersions should have at least one service entry");
    strictEqual(parsed.apiVersions["ServiceA"], "2024-01-01");
  });
});

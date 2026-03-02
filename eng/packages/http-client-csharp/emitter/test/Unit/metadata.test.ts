import { beforeEach, describe, it, vi } from "vitest";
import {
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { AzureEmitterOptions } from "../../src/options.js";
import { $onEmit } from "../../src/emitter.js";
import { strictEqual, ok } from "assert";

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
        $onEmit: async () => {
          // do nothing
        }
      };
    });
  });

  it("Generates metadata.json with apiVersion from TypeSpec", async () => {
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

    // Single-service should use singular apiVersion property
    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    ok(parsed.apiVersion !== undefined, "apiVersion property should exist");
    ok(parsed.apiVersions === undefined, "apiVersions map should not exist for single-service");
    strictEqual(parsed.apiVersion, "2023-01-01-preview");
  });

  it("Generates metadata.json with not-specified apiVersion when TypeSpec has no versioning", async () => {
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

    // Check that metadata file was written with not-specified apiVersion when no versioning is defined
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) =>
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);

    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    ok(parsed.apiVersion !== undefined, "apiVersion property should exist");
    ok(parsed.apiVersions === undefined, "apiVersions map should not exist");
    strictEqual(parsed.apiVersion, "not-specified");

    strictEqual(program.diagnostics.length, 0);
  });
});
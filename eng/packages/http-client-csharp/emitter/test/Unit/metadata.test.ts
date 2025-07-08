import { Program } from "@typespec/compiler";
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
  let program: Program;
  let writeFileMock: any;

  beforeEach(async () => {
    const runner = await createEmitterTestHost();
    program = await typeSpecCompile(
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
    
    // Mock the file writing to capture what would be written
    writeFileMock = vi.fn().mockResolvedValue(undefined);
    const originalHost = program.host;
    program.host = {
      ...originalHost,
      writeFile: writeFileMock
    };
    
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

  it("Always generates metadata.json file", async () => {
    const options: AzureEmitterOptions = {
      "api-version": "2023-01-01"
    };
    const context = createEmitterContext(program, options);
    
    await $onEmit(context);
    
    // Check that metadata file was written
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) => 
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);
    
    // Check the path
    const filePath = metadataCalls[0][0];
    ok(filePath.includes("Generated/metadata.json"));
    
    // Check the content
    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    strictEqual(parsed["api-version"], "2023-01-01");
    
    strictEqual(program.diagnostics.length, 0);
  });

  it("Includes correct api-version in metadata when specified", async () => {
    const testApiVersion = "2024-05-01";
    const options: AzureEmitterOptions = {
      "api-version": testApiVersion
    };
    const context = createEmitterContext(program, options);
    
    await $onEmit(context);
    
    // Check that metadata file was written with correct api-version
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) => 
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);
    
    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    strictEqual(parsed["api-version"], testApiVersion);
    
    strictEqual(program.diagnostics.length, 0);
  });

  it("Handles missing api-version gracefully", async () => {
    const options: AzureEmitterOptions = {
      // No api-version specified
    };
    const context = createEmitterContext(program, options);
    
    await $onEmit(context);
    
    // Check that metadata file was written with default value
    const metadataCalls = writeFileMock.mock.calls.filter((call: any) => 
      call[0].includes("metadata.json")
    );
    strictEqual(metadataCalls.length, 1);
    
    const content = metadataCalls[0][1];
    const parsed = JSON.parse(content);
    strictEqual(parsed["api-version"], "not-specified");
    
    strictEqual(program.diagnostics.length, 0);
  });
});
import { AzureCoreTestLibrary } from "@azure-tools/typespec-azure-core/testing";
import { AzureResourceManagerTestLibrary } from "@azure-tools/typespec-azure-resource-manager/testing";
import {
  createSdkContext,
  CreateSdkContextOptions
} from "@azure-tools/typespec-client-generator-core";
import { SdkTestLibrary } from "@azure-tools/typespec-client-generator-core/testing";
import { CompilerOptions, EmitContext, Program } from "@typespec/compiler";
import { createTestHost, TestHost } from "@typespec/compiler/testing";
import {
  createCSharpEmitterContext,
  CSharpEmitterContext,
  CSharpEmitterOptions,
  Logger,
  LoggerLevel
} from "@typespec/http-client-csharp";
import { HttpTestLibrary } from "@typespec/http/testing";
import { RestTestLibrary } from "@typespec/rest/testing";
import { VersioningTestLibrary } from "@typespec/versioning/testing";
import { XmlTestLibrary } from "@typespec/xml/testing";
import { AzureEmitterOptions } from "@azure-typespec/http-client-csharp";

export async function createEmitterTestHost(): Promise<TestHost> {
  return createTestHost({
    libraries: [
      RestTestLibrary,
      HttpTestLibrary,
      VersioningTestLibrary,
      AzureCoreTestLibrary,
      AzureResourceManagerTestLibrary,
      SdkTestLibrary,
      XmlTestLibrary
    ]
  });
}

export interface ArmTypeSpecCompileOptions {
  providerNamespace?: string;
  versions?: string[];
}

export async function typeSpecCompile(
  content: string,
  host: TestHost,
  options?: ArmTypeSpecCompileOptions
) {
  const versions = options?.versions ?? [ "2025-05-12"];
  const fileContent = `
    import "@typespec/http";
    import "@typespec/rest";
    import "@typespec/versioning";
    import "@azure-tools/typespec-azure-core";
    import "@azure-tools/typespec-azure-resource-manager";
    import "@azure-tools/typespec-client-generator-core";
    using TypeSpec.Http;
    using TypeSpec.Rest;
    using TypeSpec.Versioning;
    using Azure.Core;
    using Azure.ResourceManager;
    using Azure.ClientGenerator.Core;

    @armProviderNamespace
    @service(#{ title: "Azure Management emitter Testing" })
    @versioned(Versions)
    namespace ${options?.providerNamespace ?? "Microsoft.ContosoProviderHub"};

    /** api versions */
    enum Versions {
      ${versions.map((version) => `/** ${version} version */\n"${version}"`).join("\n")}
    }

    ${content}
    `;
  host.addTypeSpecFile("main.tsp", fileContent);
  const cliOptions = {
    warningAsError: false
  } as CompilerOptions;
  await host.compile("./", cliOptions);
  return host.program;
}

export function createEmitterContext(
  program: Program,
  options: AzureEmitterOptions = {}
): EmitContext<CSharpEmitterOptions> {
  return {
    program: program,
    emitterOutputDir: "./",
    options: options ?? {
      outputFile: "tspCodeModel.json",
      logFile: "log.json",
      "new-project": false,
      "clear-output-folder": false,
      "save-inputs": false,
      "generate-protocol-methods": true,
      "generate-convenience-methods": true,
      "package-name": undefined
    }
  } as EmitContext<CSharpEmitterOptions>;
}

/* We always need to pass in the emitter name now that it is required so making a helper to do this. */
export async function createCSharpSdkContext(
  program: EmitContext<AzureEmitterOptions>,
  sdkContextOptions: CreateSdkContextOptions = {}
): Promise<CSharpEmitterContext> {
  const context = await createSdkContext(
    program,
    "@typespec/http-client-csharp",
    sdkContextOptions
  );
  return createCSharpEmitterContext(context, new Logger(program.program, LoggerLevel.INFO));
}

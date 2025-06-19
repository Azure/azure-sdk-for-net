import { AzureCoreTestLibrary } from "@azure-tools/typespec-azure-core/testing";
import {
  createSdkContext,
  CreateSdkContextOptions
} from "@azure-tools/typespec-client-generator-core";
import { SdkTestLibrary } from "@azure-tools/typespec-client-generator-core/testing";
import { CompilerOptions, EmitContext, Program } from "@typespec/compiler";
import { createTestHost, TestHost } from "@typespec/compiler/testing";
import {
  CSharpEmitterContext,
  createCSharpEmitterContext,
  Logger,
  LoggerLevel
} from "@typespec/http-client-csharp";
import { HttpTestLibrary } from "@typespec/http/testing";
import { RestTestLibrary } from "@typespec/rest/testing";
import { VersioningTestLibrary } from "@typespec/versioning/testing";
import { XmlTestLibrary } from "@typespec/xml/testing";
import { AzureEmitterOptions } from "../../src/options.js";

export async function createEmitterTestHost(): Promise<TestHost> {
  return createTestHost({
    libraries: [
      RestTestLibrary,
      HttpTestLibrary,
      VersioningTestLibrary,
      AzureCoreTestLibrary,
      SdkTestLibrary,
      XmlTestLibrary
    ]
  });
}

export interface TypeSpecCompileOptions {
  IsNamespaceNeeded?: boolean;
  IsTCGCNeeded?: boolean;
  IsXmlNeeded?: boolean;
  AuthDecorator?: string;
}

export async function typeSpecCompile(
  content: string,
  host: TestHost,
  options?: TypeSpecCompileOptions
) {
  const needNamespaces = options?.IsNamespaceNeeded ?? true;
  const needTCGC = options?.IsTCGCNeeded ?? false;
  const needXml = options?.IsXmlNeeded ?? false;
  const authDecorator =
    options?.AuthDecorator ??
    `@useAuth(ApiKeyAuth<ApiKeyLocation.header, "api-key">)`;
  const namespace = `
    @versioned(Versions)
    ${authDecorator}
    @service(#{
      title: "Azure Csharp emitter Testing",
    })

    namespace Azure.Csharp.Testing;

    enum Versions {
    ${"@useDependency(Azure.Core.Versions.v1_0_Preview_1)"}
    "2023-01-01-preview"
    }

    `;
  const fileContent = `
    import "@typespec/rest";
    import "@typespec/http";
    import "@typespec/versioning";
    ${needXml ? 'import  "@typespec/xml";' : ""}
    ${'import "@azure-tools/typespec-azure-core";'}
    ${needTCGC ? 'import "@azure-tools/typespec-client-generator-core";' : ""}
    using TypeSpec.Rest;
    using TypeSpec.Http;
    using TypeSpec.Versioning;
    ${needXml ? "using TypeSpec.Xml;" : ""}
    ${"using Azure.Core;\nusing Azure.Core.Traits;"}
    ${needTCGC ? "using Azure.ClientGenerator.Core;" : ""}

    ${needNamespaces ? namespace : ""}
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
): EmitContext<AzureEmitterOptions> {
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
  } as EmitContext<AzureEmitterOptions>;
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
  return createCSharpEmitterContext(
    context,
    new Logger(program.program, LoggerLevel.INFO)
  );
}

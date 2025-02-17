import { AzureCoreTestLibrary } from "@azure-tools/typespec-azure-core/testing";
import {
  createSdkContext,
  CreateSdkContextOptions,
  SdkContext,
} from "@azure-tools/typespec-client-generator-core";
import { SdkTestLibrary } from "@azure-tools/typespec-client-generator-core/testing";
import {
  CompilerOptions,
  EmitContext,
  isGlobalNamespace,
  Namespace,
  navigateTypesInNamespace,
  Program,
  Type,
} from "@typespec/compiler";
import { createTestHost, TestHost } from "@typespec/compiler/testing";
import { HttpTestLibrary } from "@typespec/http/testing";
import { RestTestLibrary } from "@typespec/rest/testing";
import { VersioningTestLibrary } from "@typespec/versioning/testing";
import { XmlTestLibrary } from "@typespec/xml/testing";
import { LoggerLevel } from "../../../src/lib/log-level.js";
import { Logger } from "../../../src/lib/logger.js";
import { getInputType } from "../../../src/lib/model.js";
import { NetEmitterOptions } from "../../../src/options.js";
import { InputEnumType, InputModelType } from "../../../src/type/input-type.js";

export async function createEmitterTestHost(): Promise<TestHost> {
  return createTestHost({
    libraries: [
      RestTestLibrary,
      HttpTestLibrary,
      VersioningTestLibrary,
      AzureCoreTestLibrary,
      SdkTestLibrary,
      XmlTestLibrary,
    ],
  });
}

export interface TypeSpecCompileOptions {
  IsNamespaceNeeded?: boolean;
  IsAzureCoreNeeded?: boolean;
  IsTCGCNeeded?: boolean;
  IsXmlNeeded?: boolean;
  AuthDecorator?: string;
}

export async function typeSpecCompile(
  content: string,
  host: TestHost,
  options?: TypeSpecCompileOptions,
) {
  const needNamespaces = options?.IsNamespaceNeeded ?? true;
  const needAzureCore = options?.IsAzureCoreNeeded ?? false;
  const needTCGC = options?.IsTCGCNeeded ?? false;
  const needXml = options?.IsXmlNeeded ?? false;
  const authDecorator =
    options?.AuthDecorator ?? `@useAuth(ApiKeyAuth<ApiKeyLocation.header, "api-key">)`;
  const namespace = `
    @versioned(Versions)
    ${authDecorator}
    @service({
      title: "Azure Csharp emitter Testing",
    })

    namespace Azure.Csharp.Testing;

    enum Versions {
    ${needAzureCore ? "@useDependency(Azure.Core.Versions.v1_0_Preview_1)" : ""}
    "2023-01-01-preview"
    }
    
    `;
  const fileContent = `
    import "@typespec/rest";
    import "@typespec/http";
    import "@typespec/versioning";
    ${needXml ? 'import  "@typespec/xml";' : ""}
    ${needAzureCore ? 'import "@azure-tools/typespec-azure-core";' : ""}
    ${needTCGC ? 'import "@azure-tools/typespec-client-generator-core";' : ""}
    using TypeSpec.Rest; 
    using TypeSpec.Http;
    using TypeSpec.Versioning;
    ${needXml ? "using TypeSpec.Xml;" : ""}
    ${needAzureCore ? "using Azure.Core;\nusing Azure.Core.Traits;" : ""}
    ${needTCGC ? "using Azure.ClientGenerator.Core;" : ""}
    
    ${needNamespaces ? namespace : ""}
    ${content}
    `;
  host.addTypeSpecFile("main.tsp", fileContent);
  const cliOptions = {
    warningAsError: false,
  } as CompilerOptions;
  await host.compile("./", cliOptions);
  return host.program;
}

export function createEmitterContext(program: Program): EmitContext<NetEmitterOptions> {
  return {
    program: program,
    emitterOutputDir: "./",
    options: {
      outputFile: "tspCodeModel.json",
      logFile: "log.json",
      skipSDKGeneration: false,
      "new-project": false,
      "clear-output-folder": false,
      "save-inputs": false,
      "generate-protocol-methods": true,
      "generate-convenience-methods": true,
      "package-name": undefined,
    },
  } as EmitContext<NetEmitterOptions>;
}

/* Navigate all the models in the whole namespace. */
export function navigateModels(
  context: SdkContext<NetEmitterOptions>,
  namespace: Namespace,
  models: Map<string, InputModelType>,
  enums: Map<string, InputEnumType>,
) {
  const computeModel = (x: Type) => getInputType(context, x, models, enums) as any;
  const skipSubNamespaces = isGlobalNamespace(context.program, namespace);
  navigateTypesInNamespace(
    namespace,
    {
      model: (x) => x.name !== "" && x.kind === "Model" && computeModel(x),
      scalar: computeModel,
      enum: computeModel,
      union: (x) => x.name !== undefined && computeModel(x),
    },
    { skipSubNamespaces },
  );
}

/* We always need to pass in the emitter name now that it is required so making a helper to do this. */
export async function createNetSdkContext(
  program: EmitContext<NetEmitterOptions>,
  sdkContextOptions: CreateSdkContextOptions = {},
): Promise<SdkContext<NetEmitterOptions>> {
  Logger.initialize(program.program, LoggerLevel.INFO);
  return await createSdkContext(program, "@typespec/http-client-csharp", sdkContextOptions);
}

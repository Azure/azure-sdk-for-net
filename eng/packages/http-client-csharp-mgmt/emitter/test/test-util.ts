import { AzureCoreTestLibrary } from "@azure-tools/typespec-azure-core/testing";
import { AzureResourceManagerTestLibrary } from "@azure-tools/typespec-azure-resource-manager/testing";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import { SdkTestLibrary } from "@azure-tools/typespec-client-generator-core/testing";
import { CompilerOptions, EmitContext, Program } from "@typespec/compiler";
import { createTestHost, TestHost } from "@typespec/compiler/testing";
import {
  createCSharpEmitterContext,
  CSharpEmitterContext,
  Logger,
  LoggerLevel
} from "@typespec/http-client-csharp";
import { HttpTestLibrary } from "@typespec/http/testing";
import { RestTestLibrary } from "@typespec/rest/testing";
import { OpenAPITestLibrary } from "@typespec/openapi/testing";
import { VersioningTestLibrary } from "@typespec/versioning/testing";
import { XmlTestLibrary } from "@typespec/xml/testing";
import { AzureEmitterOptions } from "@azure-typespec/http-client-csharp";
import { azureSDKContextOptions } from "../src/sdk-context-options.js";
import {
  ArmProviderSchema,
  sortResourceMethods
} from "../src/resource-metadata.js";

export async function createEmitterTestHost(): Promise<TestHost> {
  return createTestHost({
    libraries: [
      RestTestLibrary,
      HttpTestLibrary,
      VersioningTestLibrary,
      AzureCoreTestLibrary,
      AzureResourceManagerTestLibrary,
      OpenAPITestLibrary,
      SdkTestLibrary,
      XmlTestLibrary
    ]
  });
}

export interface ArmTypeSpecCompileOptions {
  providerNamespace?: string;
}

export async function typeSpecCompile(
  content: string,
  host: TestHost,
  options?: ArmTypeSpecCompileOptions
) {
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
      @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
      \`2021-10-01-preview\`,
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
  program: Program
): EmitContext<AzureEmitterOptions> {
  const options: AzureEmitterOptions = {
    "new-project": false,
    "save-inputs": false,
    "generate-protocol-methods": true,
    "generate-convenience-methods": true,
    "generator-name": "ManagementClientGenerator",
    "sdk-context-options": azureSDKContextOptions,
    "model-namespace": true
  };
  return {
    program: program,
    emitterOutputDir: "./",
    options: options
  } as EmitContext<AzureEmitterOptions>;
}

/* We always need to pass in the emitter name now that it is required so making a helper to do this. */
export async function createCSharpSdkContext(
  program: EmitContext<AzureEmitterOptions>
): Promise<CSharpEmitterContext> {
  const context = await createSdkContext(
    program,
    "@typespec/http-client-csharp",
    program.options["sdk-context-options"]
  );
  return createCSharpEmitterContext(
    context,
    new Logger(program.program, LoggerLevel.INFO)
  );
}

/**
 * Helper function to normalize ARM provider schemas for comparison.
 * This is useful when comparing schemas from different APIs (e.g., buildArmProviderSchema vs resolveArmResources).
 *
 * @param schema - The ARM provider schema to normalize
 * @returns A normalized schema object suitable for deep comparison
 */
export function normalizeSchemaForComparison(schema: ArmProviderSchema) {
  // Work on a deep copy to avoid mutating the original schema used elsewhere in tests.
  const normalizedSchema: ArmProviderSchema = JSON.parse(
    JSON.stringify(schema)
  );

  // it is a known issue that the following properties might different therefore we need to ignore them:
  // - resources.metadata.resourceName
  // - resources.metadata.parentResourceModelId
  for (const resource of normalizedSchema.resources) {
    resource.metadata.resourceName = "<normalized>";
    resource.metadata.parentResourceModelId = "<normalized>";

    // Sort methods by kind (CRUD, List, Action) and then by methodId for deterministic ordering
    sortResourceMethods(resource.metadata.methods);
  }

  // sort resources by resourceIdPattern
  normalizedSchema.resources.sort((a, b) =>
    a.metadata.resourceIdPattern.localeCompare(b.metadata.resourceIdPattern)
  );

  // sort nonResourceMethods by methodId
  normalizedSchema.nonResourceMethods.sort((a, b) =>
    a.methodId.localeCompare(b.methodId)
  );

  return normalizedSchema;
}

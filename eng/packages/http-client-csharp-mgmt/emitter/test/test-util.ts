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
 * Helper function to compare ARM provider schemas while excluding fields that are known to differ.
 * This is useful when comparing schemas from different APIs (e.g., buildArmProviderSchema vs resolveArmResources)
 * where certain fields may not be populated in the same way.
 * 
 * @param schema - The ARM provider schema to normalize
 * @param options - Options for what to exclude from comparison
 * @returns A normalized schema object suitable for deep comparison
 */
export function normalizeSchemaForComparison(
  schema: any,
  options?: {
    excludeMethods?: boolean;
    excludeNonResourceMethods?: boolean;
  }
) {
  const { excludeMethods = false, excludeNonResourceMethods = false } = options || {};
  
  const result: any = {
    resources: schema.resources.map((r: any) => ({
      resourceModelId: r.resourceModelId,
      metadata: {
        resourceIdPattern: r.metadata.resourceIdPattern,
        resourceType: r.metadata.resourceType,
        resourceScope: r.metadata.resourceScope,
        parentResourceId: r.metadata.parentResourceId,
        singletonResourceName: r.metadata.singletonResourceName,
        resourceName: r.metadata.resourceName,
        ...(excludeMethods ? {} : { methods: r.metadata.methods })
      }
    }))
  };
  
  if (!excludeNonResourceMethods) {
    result.nonResourceMethods = schema.nonResourceMethods;
  }
  
  return result;
}

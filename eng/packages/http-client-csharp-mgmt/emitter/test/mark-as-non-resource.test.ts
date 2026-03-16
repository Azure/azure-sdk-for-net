import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { ok, strictEqual } from "assert";
import { parseResourceClientOptions } from "../src/client-option-processor.js";

describe("markAsNonResource", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("child resource marked as non-resource is removed and methods reassigned to parent", async () => {
    const program = await typeSpecCompile(
      `
/** A Namespace parent resource */
model Namespace is TrackedResource<NamespaceProperties> {
  ...ResourceNameParameter<Namespace>;
}

/** Namespace properties */
model NamespaceProperties {
  /** Description */
  description?: string;

  /** The status of the last operation. */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;
}

/** A NetworkSecurityPerimeterConfiguration child resource */
#suppress "@azure-tools/typespec-client-generator-core/client-option" "markAsNonResource"
@clientOption("markAsNonResource", true, "csharp")
@parentResource(Namespace)
model NetworkSecurityPerimeterConfiguration is ProxyResource<NetworkSecurityPerimeterConfigurationProperties> {
  ...ResourceNameParameter<NetworkSecurityPerimeterConfiguration>;
}

/** NSP config properties */
model NetworkSecurityPerimeterConfigurationProperties {
  /** NSP id */
  nspId?: string;
}

/** The provisioning state of a resource. */
@lroStatus
union ProvisioningState {
  string,
  Succeeded: "Succeeded",
  Failed: "Failed",
  Canceled: "Canceled",
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Namespaces {
  get is ArmResourceRead<Namespace>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Namespace>;
}

@armResourceOperations
interface NetworkSecurityPerimeterConfigurations {
  get is ArmResourceRead<NetworkSecurityPerimeterConfiguration>;
  list is ArmResourceListByParent<NetworkSecurityPerimeterConfiguration>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);

    // Build schema without markAsNonResource to verify baseline
    const baselineSchema = buildArmProviderSchema(sdkContext, root);
    ok(baselineSchema);
    strictEqual(baselineSchema.resources.length, 2); // Namespace + NSP

    // Build schema with markAsNonResource — NSP filtered out before schema construction
    const clientOptionsMap = parseResourceClientOptions(sdkContext);
    const processedSchema = buildArmProviderSchema(
      sdkContext,
      root,
      clientOptionsMap
    );
    ok(processedSchema);

    // NSP resource should be removed
    strictEqual(processedSchema.resources.length, 1);
    strictEqual(
      processedSchema.resources[0].metadata.resourceName,
      "Namespace"
    );

    // NSP methods should be reassigned to the Namespace resource
    const namespaceMethods = processedSchema.resources[0].metadata.methods;
    // Original Namespace methods (Get, Create) + reassigned NSP methods
    ok(namespaceMethods.length > 2);

    // Verify NSP operations are now on the Namespace resource
    const nspMethodPaths = namespaceMethods.filter((m) =>
      m.operationPath.includes("networkSecurityPerimeterConfiguration")
    );
    ok(
      nspMethodPaths.length > 0,
      "NSP methods should be reassigned to parent resource"
    );
  });

  it("resource marked as non-resource removes all scope variants sharing the same model", async () => {
    const program = await typeSpecCompile(
      `
/** Parent resource */
model Namespace is TrackedResource<NamespaceProperties> {
  ...ResourceNameParameter<Namespace>;
}

/** Namespace properties */
model NamespaceProperties {
  /** Description */
  description?: string;

  /** The status of the last operation. */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;
}

/** An extension resource that appears at two different scopes */
#suppress "@azure-tools/typespec-client-generator-core/client-option" "markAsNonResource"
@clientOption("markAsNonResource", true, "csharp")
model NspConfig is ExtensionResource<NspConfigProperties> {
  ...ResourceNameParameter<NspConfig>;
}

/** NSP config properties */
model NspConfigProperties {
  /** NSP id */
  nspId?: string;
}

/** The provisioning state of a resource. */
@lroStatus
union ProvisioningState {
  string,
  Succeeded: "Succeeded",
  Failed: "Failed",
  Canceled: "Canceled",
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Namespaces {
  get is ArmResourceRead<Namespace>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Namespace>;
  listByResourceGroup is ArmResourceListByParent<Namespace>;
}

/** ResourceGroup-scoped NspConfig operations */
@armResourceOperations
interface NspConfigsByResourceGroup {
  get is Extension.Read<Extension.ResourceGroup, NspConfig>;
  list is Extension.ListByTarget<Extension.ResourceGroup, NspConfig>;
}

/** Subscription-scoped NspConfig operations */
@armResourceOperations
interface NspConfigsBySubscription {
  get is Extension.Read<Extension.Subscription, NspConfig>;
  list is Extension.ListByTarget<Extension.Subscription, NspConfig>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);

    // Baseline: NspConfig should appear as 2 resources (RG + Subscription scope)
    const baselineSchema = buildArmProviderSchema(sdkContext, root);
    ok(baselineSchema);
    const nspConfigModel = root.models.find((m) => m.name === "NspConfig");
    ok(nspConfigModel, "NspConfig model should exist");
    const nspResources = baselineSchema.resources.filter(
      (r) => r.resourceModelId === nspConfigModel.crossLanguageDefinitionId
    );
    strictEqual(
      nspResources.length,
      2,
      "Should have 2 NspConfig resources at different scopes"
    );

    // With markAsNonResource: ALL NspConfig scope variants should be removed
    const clientOptionsMap = parseResourceClientOptions(sdkContext);
    const processedSchema = buildArmProviderSchema(
      sdkContext,
      root,
      clientOptionsMap
    );
    ok(processedSchema);

    const remainingNsp = processedSchema.resources.filter(
      (r) => r.resourceModelId === nspConfigModel.crossLanguageDefinitionId
    );
    strictEqual(
      remainingNsp.length,
      0,
      "All NspConfig scope variants should be removed"
    );

    // Namespace resource should still be present
    const namespaceResources = processedSchema.resources.filter(
      (r) => r.metadata.resourceName === "Namespace"
    );
    strictEqual(namespaceResources.length, 1, "Namespace resource should remain");
  });

  it("schema without markAsNonResource is returned unchanged", async () => {
    const program = await typeSpecCompile(
      `
/** A simple resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;

  /** The status of the last operation. */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;
}

/** The provisioning state of a resource. */
@lroStatus
union ProvisioningState {
  string,
  Succeeded: "Succeeded",
  Failed: "Failed",
  Canceled: "Canceled",
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);

    // With empty clientOptionsMap, schema should be identical to baseline
    const clientOptionsMap = parseResourceClientOptions(sdkContext);
    const schema = buildArmProviderSchema(
      sdkContext,
      root,
      clientOptionsMap
    );
    ok(schema);
    strictEqual(schema.resources.length, 1);
    strictEqual(
      schema.resources[0].metadata.resourceName,
      "Employee"
    );
  });
});

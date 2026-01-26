import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile,
  normalizeSchemaForComparison
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { resolveArmResources } from "../src/resolve-arm-resources-converter.js";
import { ok, strictEqual, deepStrictEqual } from "assert";
import { ResourceScope } from "../src/resource-metadata.js";

describe("Non-Resource Methods Detection", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("should detect non-resource methods on subscription scope", async () => {
    const program = await typeSpecCompile(
      `
/** Custom operations using ARM provider action templates */
interface SubscriptionOperations {
  /**
   * Validates configuration settings for the subscription.
   */
  @autoRoute
  validateConfiguration is ArmProviderActionSync<
    Request = ValidationRequest,
    Response = ValidationResponse,
    Scope = SubscriptionActionScope
  >;
}

/** Validation request model */
model ValidationRequest {
  /** Configuration to validate */
  configuration: string;
}

/** Validation response model */
model ValidationResponse {
  /** Whether the configuration is valid */
  isValid: boolean;
  
  /** Validation errors if any */
  errors?: string[];
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);

    // Build ARM provider schema and verify non-resource methods
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult, "Should have ARM provider schema");
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods array"
    );

    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      1,
      "Should have exactly one non-resource method"
    );

    const method = nonResourceMethods[0];
    // The path should be generated from the ARM template
    strictEqual(
      method.operationPath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/validateConfiguration"
    );
    strictEqual(method.operationScope, ResourceScope.Subscription);
    ok(method.methodId, "Method should have an ID");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("should detect non-resource methods on tenant scope", async () => {
    const program = await typeSpecCompile(
      `
/** Tenant-level operations using ARM templates */
interface TenantOperations {
  /**
   * Gets tenant information.
   */
  @autoRoute
  getTenantInfo is ArmProviderActionSync<
    Request = void,
    Response = TenantInfo,
    Scope = TenantActionScope
  >;
  
  /**
   * Updates global settings for the tenant.
   */
  @autoRoute
  updateGlobalSettings is ArmProviderActionSync<
    Request = GlobalSettings,
    Response = GlobalSettings,
    Scope = TenantActionScope
  >;
}

/** Tenant information model */
model TenantInfo {
  /** Tenant ID */
  tenantId: string;
  
  /** Tenant name */
  name: string;
  
  /** Tenant domain */
  domain: string;
}

/** Global settings model */
model GlobalSettings {
  /** Whether feature is enabled globally */
  featureEnabled: boolean;
  
  /** Global configuration */
  configuration: Record<string>;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods array"
    );
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      2,
      "Should have exactly two non-resource methods"
    );

    // All tenant-scope methods should have Tenant scope
    nonResourceMethods.forEach((method: any) => {
      strictEqual(
        method.operationScope,
        ResourceScope.Tenant,
        `Method ${method.operationPath} should have Tenant scope`
      );
    });

    // Verify specific paths
    const tenantInfoMethod = nonResourceMethods.find(
      (m: any) =>
        m.operationPath ===
        "/providers/Microsoft.ContosoProviderHub/getTenantInfo"
    );
    ok(tenantInfoMethod, "Should find tenantInfo method");

    const globalSettingsMethod = nonResourceMethods.find(
      (m: any) =>
        m.operationPath ===
        "/providers/Microsoft.ContosoProviderHub/updateGlobalSettings"
    );
    ok(globalSettingsMethod, "Should find globalSettings method");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("should detect subscription-level list as non-resource method for RG-scoped resource", async () => {
    const program = await typeSpecCompile(
      `
/** A standard ARM resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
  
  /** City of employee */
  city?: string;
}

/** Standard ARM resource operations */
@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  update is ArmCustomPatchSync<
    Employee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<Employee, EmployeeProperties>
  >;
  delete is ArmResourceDeleteWithoutOkAsync<Employee>;
  listByResourceGroup is ArmResourceListByParent<Employee>;
  listBySubscription is ArmListBySubscription<Employee>;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    // listBySubscription should be a non-resource method for a top-level RG-scoped resource
    // because its path (/subscriptions/{subscriptionId}/providers/.../employees) doesn't match
    // the resource's RG-scoped path (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/.../employees/{employeeName})
    ok(armProviderSchemaResult, "Should have ARM provider schema");
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      1,
      "Should have one non-resource method for subscription-level list of RG-scoped resource"
    );

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("should detect mixed resource and non-resource methods", async () => {
    const program = await typeSpecCompile(
      `
/** A standard ARM resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
  
  /** City of employee */
  city?: string;
}

/** Standard ARM resource operations */
@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
}

/** Custom non-resource operations using ARM templates */
interface CustomOperations {
  /**
   * Bulk imports employees to the subscription.
   */
  @autoRoute
  bulkImportEmployees is ArmProviderActionSync<
    Request = BulkImportRequest,
    Response = BulkImportResponse,
    Scope = SubscriptionActionScope
  >;
  
  /**
   * Migrates employees between resource groups.
   */
  @autoRoute
  migrateEmployees is ArmProviderActionSync<
    Request = MigrationRequest,
    Response = MigrationResponse,
    Scope = TenantActionScope
  >;
}

/** Bulk import request */
model BulkImportRequest {
  /** Employees to import */
  employees: Employee[];
}

/** Bulk import response */
model BulkImportResponse {
  /** Number of employees imported */
  importedCount: int32;
  
  /** Import errors */
  errors?: string[];
}

/** Migration request */
model MigrationRequest {
  /** Source resource group */
  sourceResourceGroup: string;
  
  /** Target resource group */
  targetResourceGroup: string;
}

/** Migration response */
model MigrationResponse {
  /** Migration job ID */
  jobId: string;
  
  /** Migration status */
  status: string;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods array"
    );
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      2,
      "Should have exactly two non-resource methods"
    );

    // Check that we have the expected non-resource methods
    const bulkImportMethod = nonResourceMethods.find(
      (m: any) =>
        m.operationPath ===
        "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/bulkImportEmployees"
    );
    ok(bulkImportMethod, "Should find bulk import method");
    strictEqual(bulkImportMethod.operationScope, ResourceScope.Subscription);

    const migrateMethod = nonResourceMethods.find(
      (m: any) =>
        m.operationPath ===
        "/providers/Microsoft.ContosoProviderHub/migrateEmployees"
    );
    ok(migrateMethod, "Should find migrate method");
    strictEqual(migrateMethod.operationScope, ResourceScope.Tenant);

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("should handle complex operation paths correctly", async () => {
    const program = await typeSpecCompile(
      `
/** Complex custom operations using ARM templates with additional path segments */
interface ComplexOperations {
  /**
   * Validates a workspace configuration.
   */
  @autoRoute
  validateWorkspace is ArmProviderActionSync<
    Request = WorkspaceValidationRequest,
    Response = WorkspaceValidationResponse,
    Scope = SubscriptionActionScope,
    Parameters = {
      @path
      @segment("workspaces")
      workspaceName: string;
    }
  >;
}

/** Workspace validation request */
model WorkspaceValidationRequest {
  /** Validation rules */
  rules: string[];
}

/** Workspace validation response */
model WorkspaceValidationResponse {
  /** Validation passed */
  isValid: boolean;
  
  /** Validation details */
  details: string;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods array"
    );
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      1,
      "Should have exactly one non-resource method"
    );

    const method = nonResourceMethods[0];
    // The path should be generated from the ARM template with nested segments
    strictEqual(
      method.operationPath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/workspaces/{workspaceName}/validateWorkspace"
    );
    strictEqual(method.operationScope, ResourceScope.Subscription);
    ok(method.methodId, "Method should have an ID");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("should handle methods with query parameters correctly", async () => {
    const program = await typeSpecCompile(
      `
/** Operations with query parameters using ARM templates */
interface QueryOperations {
  /**
   * Searches for resources with query parameters.
   */
  @autoRoute
  searchResources is ArmProviderActionSync<
    Request = void,
    Response = SearchResponse,
    Scope = SubscriptionActionScope,
    Parameters = {
      @path
      @segment("search")
      action: string;
      
      @query searchTerm: string;
      @query maxResults?: int32;
      @query includeMetadata?: boolean;
    }
  >;
}

/** Search response model */
model SearchResponse {
  /** Search results */
  results: SearchResult[];
  
  /** Total count */
  totalCount: int32;
}

/** Search result model */
model SearchResult {
  /** Resource ID */
  resourceId: string;
  
  /** Resource name */
  name: string;
  
  /** Resource type */
  type: string;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods array"
    );
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      1,
      "Should have exactly one non-resource method"
    );

    const method = nonResourceMethods[0];
    strictEqual(
      method.operationPath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/search/{action}/searchResources"
    );
    strictEqual(method.operationScope, ResourceScope.Subscription);

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("should detect ARM provider actions with location parameters", async () => {
    const program = await typeSpecCompile(
      `
/** Operations with location parameters similar to routes.tsp example */
interface LocationBasedOperations {
  /**
   * Runs input conditions against input object metadata properties and designates matched objects in response.
   */
  @autoRoute
  previewActions is ArmProviderActionSync<
    Request = FooPreviewAction,
    Response = FooPreviewAction,
    Scope = SubscriptionActionScope,
    Parameters = {
      @path
      @segment("locations")
      location: Azure.Core.azureLocation;
    }
  >;
}

/** Preview action model */
model FooPreviewAction {
  /** The action to be performed. */
  action: string;

  @visibility(Lifecycle.Read)
  result?: string;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods array"
    );
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      1,
      "Should have exactly one non-resource method"
    );

    const method = nonResourceMethods[0];
    strictEqual(
      method.operationPath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/locations/{location}/previewActions"
    );
    strictEqual(method.operationScope, ResourceScope.Subscription);

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });
});

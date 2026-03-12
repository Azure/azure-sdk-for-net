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
import {
  ResourceScope,
  ResourceOperationKind,
  assignNonResourceMethodsToResources
} from "../src/resource-metadata.js";
import type {
  ArmResourceSchema,
  NonResourceMethod
} from "../src/resource-metadata.js";

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

  it("should not detect ARM resource operations as non-resource methods", async () => {
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

    // Should not have non-resource methods since all methods are standard ARM operations
    ok(armProviderSchemaResult, "Should have ARM provider schema");
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    strictEqual(
      nonResourceMethods.length,
      0,
      "Should have no non-resource methods for standard ARM operations"
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

  it("should assign non-resource method to resource when operationPath has resource prefix", async () => {
    const program = await typeSpecCompile(
      `
/** A host pool resource */
model HostPool is TrackedResource<HostPoolProperties> {
  ...ResourceNameParameter<HostPool>;
}

/** Host pool properties */
model HostPoolProperties {
  /** Description */
  description?: string;
}

/** Session host provisioning status response */
model SessionHostProvisioningStatus {
  /** The provisioning status */
  status: string;
}

/** Standard ARM resource operations for HostPool */
@armResourceOperations
interface HostPools {
  get is ArmResourceRead<HostPool>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<HostPool>;
  delete is ArmResourceDeleteWithoutOkAsync<HostPool>;
  listByResourceGroup is ArmResourceListByParent<HostPool>;
}

/** Non-resource operations that sit under the HostPool path */
interface SessionHostManagementOperations {
  /**
   * Gets provisioning status under a host pool.
   */
  @autoRoute
  @doc("Gets the provisioning status")
  @armResourceAction(HostPool)
  getProvisioningStatus is ArmResourceActionSync<
    HostPool,
    {},
    SessionHostProvisioningStatus
  >;
}
`,
      runner,
      { providerNamespace: "Microsoft.DesktopVirtualization" }
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");

    // The non-resource method whose path starts with the HostPool resource path
    // should have been moved into the HostPool resource as an Action
    const hostPoolResource = armProviderSchemaResult.resources.find(
      (r) => r.metadata.resourceName === "HostPool"
    );
    ok(hostPoolResource, "Should find HostPool resource");

    // The resource should have an Action method from the non-resource operation
    const actionMethods = hostPoolResource.metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.Action
    );
    ok(
      actionMethods.length > 0,
      "HostPool resource should have at least one Action method from the non-resource operation"
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

  it("should assign non-resource method to longest-prefix-matching resource", async () => {
    const program = await typeSpecCompile(
      `
/** A parent resource */
model ParentResource is TrackedResource<ParentResourceProperties> {
  ...ResourceNameParameter<ParentResource>;
}

/** Parent resource properties */
model ParentResourceProperties {
  /** Description */
  description?: string;
}

/** A child resource under the parent */
model ChildResource is ProxyResource<ChildResourceProperties> {
  @key("childResourceName")
  @segment("childResources")
  @path
  @doc("The name of the child resource")
  @visibility(Lifecycle.Read)
  name: string;
}

/** Child resource properties */
model ChildResourceProperties {
  /** Status */
  status?: string;
}

/** Status response */
model StatusResponse {
  /** The status */
  status: string;
}

/** Standard operations for ParentResource */
@armResourceOperations
interface ParentResources {
  get is ArmResourceRead<ParentResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<ParentResource>;
  delete is ArmResourceDeleteWithoutOkAsync<ParentResource>;
  listByResourceGroup is ArmResourceListByParent<ParentResource>;
}

/** Standard operations for ChildResource */
@armResourceOperations
interface ChildResources {
  get is ArmResourceRead<ChildResource>;
  createOrUpdate is ArmResourceCreateOrReplaceSync<ChildResource>;
  delete is ArmResourceDeleteSync<ChildResource>;
  listByParent is ArmResourceListByParent<ChildResource>;
  /** Gets provisioning status under a child resource. */
  @autoRoute
  getProvisioningStatus is ArmResourceActionSync<
    ChildResource,
    {},
    StatusResponse
  >;
}
`,
      runner,
      { providerNamespace: "Microsoft.TestProvider" }
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult, "Should have ARM provider schema");

    // The child operation with a path that extends the child resource path
    // should be assigned to the ChildResource, not the ParentResource (longest prefix wins)
    const childResource = armProviderSchemaResult.resources.find(
      (r) => r.metadata.resourceName === "ChildResource"
    );
    ok(childResource, "Should find ChildResource");

    const childActionMethods = childResource.metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.Action
    );
    ok(
      childActionMethods.length > 0,
      "ChildResource should have an Action method"
    );

    // ParentResource should NOT have the action method
    const parentResource = armProviderSchemaResult.resources.find(
      (r) => r.metadata.resourceName === "ParentResource"
    );
    ok(parentResource, "Should find ParentResource");

    const parentActionMethods = parentResource.metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.Action
    );
    strictEqual(
      parentActionMethods.length,
      0,
      "ParentResource should NOT have the action method (child resource has longer prefix)"
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

  it("should assign non-resource list methods to resource by resourceModelId", () => {
    // This test directly validates assignNonResourceMethodsToResources with crafted data
    // that mirrors the Maintenance SDK emitter output. The actual issue arises from
    // Legacy.ExtensionOperations interfaces producing list operations with different parent
    // path structures than the resource ID pattern — prefix matching fails, so both list
    // operations stay as nonResourceMethods named "GetAll", causing duplicate method signatures.
    //
    // The fix uses resourceModelId (propagated from the originating resource) to match
    // non-resource methods back to their correct resource.

    // A ConfigurationAssignment extension resource
    const resources: ArmResourceSchema[] = [
      {
        resourceModelId: "Microsoft.Maintenance.ConfigurationAssignment",
        metadata: {
          resourceName: "ConfigurationAssignment",
          resourceType: "Microsoft.Maintenance/configurationAssignments",
          resourceIdPattern:
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
          resourceScope: ResourceScope.Extension,
          singletonResourceName: undefined,
          parentResourceId: undefined,
          parentResourceModelId: undefined,
          methods: [
            {
              methodId: "Microsoft.Maintenance.ConfigurationAssignment.get",
              kind: ResourceOperationKind.Read,
              operationPath:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
              operationScope: ResourceScope.ResourceGroup,
              resourceScope:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}"
            }
          ]
        }
      }
    ];

    // Two list operations from different Legacy.ExtensionOperations interfaces.
    // Both have shorter paths than the resource ID pattern (different parent structures),
    // so prefix matching fails. The resourceModelId links them back to their originating resource.
    const nonResourceMethods = [
      {
        methodId:
          "Microsoft.Maintenance.ConfigurationAssignmentForResourceGroupOperationGroup.list",
        operationPath:
          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments",
        operationScope: ResourceScope.ResourceGroup,
        resourceModelId: "Microsoft.Maintenance.ConfigurationAssignment"
      },
      {
        methodId: "Microsoft.Maintenance.UpdatesOperationGroup.list",
        operationPath:
          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/updates",
        operationScope: ResourceScope.ResourceGroup,
        resourceModelId: "Microsoft.Maintenance.Update"
      }
    ];

    assignNonResourceMethodsToResources(resources, nonResourceMethods);

    // The ConfigurationAssignment list should be moved to the resource
    // (matched by type segment "configurationAssignments" under "Microsoft.Maintenance")
    const configMethods = resources[0].metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.List
    );
    strictEqual(
      configMethods.length,
      1,
      "ConfigurationAssignment resource should have 1 List method from the non-resource list"
    );

    // The Updates list should remain as a nonResourceMethod (no matching resource type)
    strictEqual(
      nonResourceMethods.length,
      1,
      "Only the Updates list should remain as a non-resource method"
    );
    ok(
      nonResourceMethods[0].methodId.includes("Updates"),
      "The remaining non-resource method should be the Updates list"
    );
  });

  it("should assign non-resource list methods by type segment when prefix matching fails due to structural path length mismatch", () => {
    // Reproduces the duplicate GetAll bug: extension resource list paths may have fewer
    // parent segments than the resource ID pattern (e.g., {providerName}/{resourceType}/
    // {resourceName} vs {providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/
    // {resourceName}), causing a structural length mismatch that prefix matching cannot resolve
    // even with variable-as-wildcard semantics. The type-segment fallback matches the operation
    // path's last segment against the resource's type segment to correctly assign the method.

    const resources: ArmResourceSchema[] = [
      {
        resourceModelId: "Microsoft.Maintenance.ConfigurationAssignment",
        metadata: {
          resourceName: "ConfigurationAssignment",
          resourceType: "Microsoft.Maintenance/configurationAssignments",
          resourceIdPattern:
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
          resourceScope: ResourceScope.Extension,
          singletonResourceName: undefined,
          parentResourceId: undefined,
          parentResourceModelId: undefined,
          methods: [
            {
              methodId: "Microsoft.Maintenance.ConfigurationAssignment.get",
              kind: ResourceOperationKind.Read,
              operationPath:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
              operationScope: ResourceScope.ResourceGroup,
              resourceScope:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}"
            }
          ]
        }
      }
    ];

    // The operation path has fewer variable segments than the resource ID pattern
    // (e.g., {providerName}/{resourceType}/{resourceName} vs {providerName}/{resourceParentType}/
    // {resourceParentName}/{resourceType}/{resourceName}). This structural length mismatch means
    // prefix matching fails even with variable-as-wildcard semantics — literal segments at
    // corresponding positions don't align. The type-segment fallback resolves this.
    const nonResourceMethods: NonResourceMethod[] = [
      {
        methodId:
          "Microsoft.Maintenance.ConfigurationAssignmentForResourceGroupOperationGroup.list",
        operationPath:
          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments",
        operationScope: ResourceScope.ResourceGroup
        // resourceModelId intentionally NOT set
      },
      {
        methodId: "Microsoft.Maintenance.UpdatesOperationGroup.list",
        operationPath:
          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/updates",
        operationScope: ResourceScope.ResourceGroup
        // resourceModelId intentionally NOT set
      }
    ];

    assignNonResourceMethodsToResources(resources, nonResourceMethods);

    // The ConfigurationAssignment list should be assigned via type-segment matching:
    // operation path ends with "configurationAssignments" which matches the resource's
    // type segment (second-to-last segment of the resource ID pattern).
    const configMethods = resources[0].metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.List
    );
    strictEqual(
      configMethods.length,
      1,
      "ConfigurationAssignment resource should have 1 List method via type-segment matching"
    );

    // The Updates list should remain as a non-resource method (no matching resource)
    strictEqual(
      nonResourceMethods.length,
      1,
      "Only the Updates list should remain as a non-resource method"
    );
    ok(
      nonResourceMethods[0].methodId.includes("Updates"),
      "The remaining non-resource method should be the Updates list"
    );
  });

  it("should NOT match by type segment when provider hierarchy depth differs", () => {
    // Reproduces the GuestConfiguration false-match bug: the RGList operation
    // at resource-group scope (1 provider: Microsoft.GuestConfiguration) was
    // incorrectly matched to the VM-scoped extension resource (2 providers:
    // Microsoft.Compute + Microsoft.GuestConfiguration) because only the type
    // segment name was compared. With provider-depth validation, this match
    // is correctly rejected.

    const resources: ArmResourceSchema[] = [
      {
        resourceModelId:
          "Microsoft.GuestConfiguration.GuestConfigurationAssignment",
        metadata: {
          resourceName: "GuestConfigurationVmAssignment",
          resourceType:
            "Microsoft.GuestConfiguration/guestConfigurationAssignments",
          resourceIdPattern:
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}",
          resourceScope: ResourceScope.ResourceGroup,
          singletonResourceName: undefined,
          parentResourceId: undefined,
          parentResourceModelId: undefined,
          methods: [
            {
              methodId:
                "Microsoft.GuestConfiguration.GuestConfigurationAssignment.get",
              kind: ResourceOperationKind.Read,
              operationPath:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}",
              operationScope: ResourceScope.ResourceGroup,
              resourceScope:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}"
            },
            {
              methodId:
                "Microsoft.GuestConfiguration.GuestConfigurationAssignment.list",
              kind: ResourceOperationKind.List,
              operationPath:
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments",
              operationScope: ResourceScope.ResourceGroup,
              resourceScope: undefined
            }
          ]
        }
      }
    ];

    // The RGList operation path has only 1 "providers/" segment (Microsoft.GuestConfiguration)
    // while the resource ID pattern has 2 (Microsoft.Compute + Microsoft.GuestConfiguration).
    // Type segment matching should reject this because of the provider depth mismatch.
    const nonResourceMethods: NonResourceMethod[] = [
      {
        methodId:
          "Microsoft.GuestConfiguration.GuestConfigurationAssignmentsOperationGroup.RGList",
        operationPath:
          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments",
        operationScope: ResourceScope.ResourceGroup
        // resourceModelId intentionally NOT set — the list path uses a different model
      }
    ];

    assignNonResourceMethodsToResources(resources, nonResourceMethods);

    // The RGList should NOT be matched — it must remain as a non-resource method
    strictEqual(
      nonResourceMethods.length,
      1,
      "RGList should remain as a non-resource method (not matched to VM-scoped resource)"
    );
    ok(
      nonResourceMethods[0].methodId.includes("RGList"),
      "The remaining non-resource method should be the RGList operation"
    );

    // The resource should NOT have gained an extra List method
    const listMethods = resources[0].metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.List
    );
    strictEqual(
      listMethods.length,
      1,
      "Resource should still have only its original List method (VM-scoped), not the RG-scoped RGList"
    );
  });

  it("should NOT match by type path when resource has intermediate segments the operation lacks", () => {
    // Reproduces the KeyVault/EdgeOrder pattern: the resource ID has intermediate segments
    // (e.g., "locations/{location}") between the provider namespace and the type segment,
    // but the list operation path doesn't. Even though the last segment name matches,
    // the structural difference means these are at different scopes within the same provider.

    const resources: ArmResourceSchema[] = [
      {
        resourceModelId: "Microsoft.KeyVault.DeletedVault",
        metadata: {
          resourceName: "DeletedVault",
          resourceType: "Microsoft.KeyVault/locations/deletedVaults",
          resourceIdPattern:
            "/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}",
          resourceScope: ResourceScope.Subscription,
          singletonResourceName: undefined,
          parentResourceId: undefined,
          parentResourceModelId: undefined,
          methods: [
            {
              methodId: "Microsoft.KeyVault.DeletedVault.get",
              kind: ResourceOperationKind.Read,
              operationPath:
                "/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}",
              operationScope: ResourceScope.Subscription,
              resourceScope:
                "/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}"
            }
          ]
        }
      }
    ];

    // The list operation path has NO "locations/{location}" intermediate segments.
    // The resource type path after the provider namespace differs:
    //   Operation: "deletedVaults"
    //   Resource:  "locations/{}/deletedVaults"
    const nonResourceMethods: NonResourceMethod[] = [
      {
        methodId: "Microsoft.KeyVault.VaultsOperationGroup.listDeleted",
        operationPath:
          "/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults",
        operationScope: ResourceScope.Subscription
      }
    ];

    assignNonResourceMethodsToResources(resources, nonResourceMethods);

    // The list should NOT be matched — different type path structure
    strictEqual(
      nonResourceMethods.length,
      1,
      "listDeleted should remain as a non-resource method (type path mismatch)"
    );

    // The resource should NOT have gained a List method
    const listMethods = resources[0].metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.List
    );
    strictEqual(
      listMethods.length,
      0,
      "DeletedVault resource should have no List methods"
    );
  });
});

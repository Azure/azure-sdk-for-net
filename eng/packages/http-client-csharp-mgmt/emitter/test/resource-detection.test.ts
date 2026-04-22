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
  ArmResourceSchema,
  ResourceScopeKind
} from "../src/resource-metadata.js";

describe("Resource Detection", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("resource group resource", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee parent resource */
model EmployeeParent is TrackedResource<EmployeeParentProperties> {
  ...ResourceNameParameter<EmployeeParent>;
}

/** Employee parent properties */
model EmployeeParentProperties {
  /** Age of employee */
  age?: int32;
}

/** An Employee resource */
@parentResource(EmployeeParent)
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;

  /** City of employee */
  city?: string;

  /** Profile of employee */
  @encode("base64url")
  profile?: bytes;

  /** The status of the last operation. */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;
}

/** The provisioning state of a resource. */
@lroStatus
union ProvisioningState {
  string,

  /** The resource create request has been accepted */
  Accepted: "Accepted",

  /** The resource is being provisioned */
  Provisioning: "Provisioning",

  /** The resource is updating */
  Updating: "Updating",

  /** Resource has been created. */
  Succeeded: "Succeeded",

  /** Resource creation failed. */
  Failed: "Failed",

  /** Resource creation was canceled. */
  Canceled: "Canceled",

  /** The resource is being deleted */
  Deleting: "Deleting",
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface EmployeesParent {
  get is ArmResourceRead<EmployeeParent>;
}

@armResourceOperations
interface Employees1 {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  update is ArmCustomPatchSync<
    Employee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<Employee, EmployeeProperties>
  >;
}

@armResourceOperations
interface Employees2 {
  delete is ArmResourceDeleteWithoutOkAsync<Employee>;
  listByResourceGroup is ArmResourceListByParent<Employee>;
  listBySubscription is ArmListBySubscription<Employee>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);
    strictEqual(armProviderSchema.resources.length, 2); // Employee and EmployeeParent

    // Find the Employee resource in the schema by resource type
    const employeeResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/employeeParents/employees"
    );
    ok(employeeResource);
    const metadata = employeeResource.metadata;
    ok(metadata);

    // Validate resource metadata
    strictEqual(
      metadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents/employees"
    );
    strictEqual(metadata.singletonResourceName, undefined);
    strictEqual(metadata.scope.kind, "ResourceGroup");
    strictEqual(
      metadata.parentResourceId?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );
    strictEqual(metadata.resourceName, "Employee");
    strictEqual(metadata.methods.length, 6);

    // Validate method kinds are present (Read, Create, Update, Delete, List operations)
    const methodKinds = metadata.methods.map((m: any) => m.kind);
    ok(methodKinds.includes("Read"));
    ok(methodKinds.includes("Create"));
    ok(methodKinds.includes("Update"));
    ok(methodKinds.includes("Delete"));
    ok(methodKinds.includes("List"));

    // Validate Read method details
    const getMethod = metadata.methods.find((m: any) => m.kind === "Read");
    ok(getMethod);
    strictEqual(
      getMethod.operationPath.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(getMethod.scope.kind, ResourceScopeKind.ResourceGroup);
    strictEqual(
      getMethod.scope.scopeIdPattern?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Create method details
    const createEntry = metadata.methods.find((m: any) => m.kind === "Create");
    ok(createEntry);
    strictEqual(
      createEntry.operationPath.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(createEntry.scope.kind, ResourceScopeKind.ResourceGroup);
    strictEqual(
      createEntry.scope.scopeIdPattern?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Update method details
    const updateEntry = metadata.methods.find((m: any) => m.kind === "Update");
    ok(updateEntry);
    strictEqual(
      updateEntry.operationPath.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(updateEntry.scope.kind, ResourceScopeKind.ResourceGroup);
    strictEqual(
      updateEntry.scope.scopeIdPattern?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Delete method details
    const deleteEntry = metadata.methods.find((m: any) => m.kind === "Delete");
    ok(deleteEntry);
    strictEqual(
      deleteEntry.operationPath.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(deleteEntry.scope.kind, ResourceScopeKind.ResourceGroup);
    strictEqual(
      deleteEntry.scope.scopeIdPattern?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate ListByResourceGroup (list by parent)
    const listByRgEntry = metadata.methods.find(
      (m: any) =>
        m.kind === "List" && m.operationPath.path.includes("employeeParents")
    );
    ok(listByRgEntry);
    strictEqual(listByRgEntry.kind, "List");
    strictEqual(
      listByRgEntry.operationPath.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees"
    );
    strictEqual(listByRgEntry.scope.kind, ResourceScopeKind.ResourceGroup);
    strictEqual(
      listByRgEntry.scope.scopeIdPattern?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );

    // Validate ListBySubscription
    const listBySubEntry = metadata.methods.find(
      (m: any) =>
        m.kind === "List" && m.scope.kind === ResourceScopeKind.Subscription
    );
    ok(listBySubEntry);
    strictEqual(listBySubEntry.kind, "List");
    strictEqual(
      listBySubEntry.operationPath.path,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees"
    );
    strictEqual(listBySubEntry.scope.kind, ResourceScopeKind.Subscription);
    strictEqual(
      listBySubEntry.scope.scopeIdPattern?.path,
      "/subscriptions/{subscriptionId}"
    );

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    // Note: Methods should now be populated by the converter with the name-based fallback lookup
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("singleton resource", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee singleton resource */
@singleton
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

@singleton("current")
model CurrentEmployee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<CurrentEmployee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;

  /** City of employee */
  city?: string;

  /** Profile of employee */
  @encode("base64url")
  profile?: bytes;

  /** The status of the last operation. */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;
}

/** The provisioning state of a resource. */
@lroStatus
union ProvisioningState {
  string,

  /** The resource create request has been accepted */
  Accepted: "Accepted",

  /** The resource is being provisioned */
  Provisioning: "Provisioning",

  /** The resource is updating */
  Updating: "Updating",

  /** Resource has been created. */
  Succeeded: "Succeeded",

  /** Resource creation failed. */
  Failed: "Failed",

  /** Resource creation was canceled. */
  Canceled: "Canceled",

  /** The resource is being deleted */
  Deleting: "Deleting",
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  update is ArmCustomPatchSync<
    Employee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<Employee, EmployeeProperties>
  >;
}

@armResourceOperations
interface CurrentEmployees {
  get is ArmResourceRead<CurrentEmployee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<CurrentEmployee>;
  update is ArmCustomPatchSync<
    CurrentEmployee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<CurrentEmployee, EmployeeProperties>
  >;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);
    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult);

    // Find the Employee resource in the schema by resource type
    const employeeResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType === "Microsoft.ContosoProviderHub/employees"
    );
    ok(employeeResource);
    const metadata = employeeResource.metadata;
    ok(metadata);

    strictEqual(
      metadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employees/default"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employees"
    );
    strictEqual(metadata.singletonResourceName, "default");
    strictEqual(metadata.scope.kind, "ResourceGroup");
    strictEqual(metadata.methods.length, 3);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      metadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(metadata.resourceName, "Employee");

    // Find the CurrentEmployee resource in the schema by resource type
    const currentEmployeeResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/currentEmployees"
    );
    ok(currentEmployeeResource);
    const currentMetadata = currentEmployeeResource.metadata;
    ok(currentMetadata);
    strictEqual(
      currentMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/currentEmployees/current"
    );
    strictEqual(
      currentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/currentEmployees"
    );
    strictEqual(currentMetadata.singletonResourceName, "current");
    strictEqual(currentMetadata.scope.kind, "ResourceGroup");
    strictEqual(currentMetadata.methods.length, 3);
    strictEqual(currentMetadata.resourceName, "CurrentEmployee");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    // TODO -- now resolveArmResources API has a bug that it cannot recognize singleton resources with non-default names
    // issue tracking here: https://github.com/Azure/typespec-azure/issues/3595
    // deepStrictEqual(
    //   normalizeSchemaForComparison(resolvedSchema),
    //   normalizeSchemaForComparison(armProviderSchemaResult)
    // );
  });

  it("resource with grand parent under a resource group", async () => {
    const program = await typeSpecCompile(
      `
/** A Company grandparent resource */
model Company is TrackedResource<CompanyProperties> {
  ...ResourceNameParameter<Company>;
}

/** Company properties */
model CompanyProperties {
  /** Name of company */
  name?: string;
}

/** A Department parent resource */
@parentResource(Company)
model Department is TrackedResource<DepartmentProperties> {
  ...ResourceNameParameter<Department>;
}

/** Department properties */
model DepartmentProperties {
  /** Name of department */
  name?: string;
}

/** An Employee resource with grandparent */
@parentResource(Department)
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;

  /** City of employee */
  city?: string;

  /** Profile of employee */
  @encode("base64url")
  profile?: bytes;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Companies {
  get is ArmResourceRead<Company>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Company>;
}

@armResourceOperations
interface Departments {
  get is ArmResourceRead<Department>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Department>;
}

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
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);

    // Find the Employee resource in the schema by resource type
    const employeeResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    ok(employeeResource);
    const employeeMetadata = employeeResource.metadata;
    ok(employeeMetadata);

    strictEqual(
      employeeMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(employeeMetadata.singletonResourceName, undefined);
    strictEqual(employeeMetadata.scope.kind, "ResourceGroup");
    strictEqual(employeeMetadata.methods.length, 5);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      employeeMetadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(
      employeeMetadata.parentResourceId?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(employeeMetadata.resourceName, "Employee");

    // Find the Department resource in the schema by resource type
    const departmentResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/companies/departments"
    );
    ok(departmentResource);
    const departmentMetadata = departmentResource.metadata;
    ok(departmentMetadata);

    strictEqual(
      departmentMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(departmentMetadata.singletonResourceName, undefined);
    strictEqual(departmentMetadata.scope.kind, "ResourceGroup");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      departmentMetadata.parentResourceId?.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(departmentMetadata.resourceName, "Department");

    // Find the Company resource in the schema by resource type
    const companyResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType === "Microsoft.ContosoProviderHub/companies"
    );
    ok(companyResource);
    const companyMetadata = companyResource.metadata;
    ok(companyMetadata);

    strictEqual(
      companyMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(companyMetadata.singletonResourceName, undefined);
    strictEqual(companyMetadata.scope.kind, "ResourceGroup");
    strictEqual(companyMetadata.methods.length, 2);
    strictEqual(companyMetadata.parentResourceId, undefined);
    strictEqual(companyMetadata.resourceName, "Company");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("resource with grand parent under a subscription", async () => {
    const program = await typeSpecCompile(
      `
/** A Company grandparent resource */
@subscriptionResource
model Company is TrackedResource<CompanyProperties> {
  ...ResourceNameParameter<Company>;
}

/** Company properties */
model CompanyProperties {
  /** Name of company */
  name?: string;
}

/** A Department parent resource */
@subscriptionResource
@parentResource(Company)
model Department is TrackedResource<DepartmentProperties> {
  ...ResourceNameParameter<Department>;
}

/** Department properties */
model DepartmentProperties {
  /** Name of department */
  name?: string;
}

/** An Employee resource with grandparent */
@subscriptionResource
@parentResource(Department)
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;

  /** City of employee */
  city?: string;

  /** Profile of employee */
  @encode("base64url")
  profile?: bytes;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Companies {
  get is ArmResourceRead<Company>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Company>;
}

@armResourceOperations
interface Departments {
  get is ArmResourceRead<Department>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Department>;
}

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
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);

    // Find the Employee resource in the schema by resource type
    const employeeResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    ok(employeeResource);
    const employeeMetadata = employeeResource.metadata;
    ok(employeeMetadata);

    strictEqual(
      employeeMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(employeeMetadata.singletonResourceName, undefined);
    strictEqual(employeeMetadata.scope.kind, "Subscription");
    strictEqual(employeeMetadata.methods.length, 5);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      employeeMetadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(
      employeeMetadata.parentResourceId?.path,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(employeeMetadata.resourceName, "Employee");

    // Find the Department resource in the schema by resource type
    const departmentResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/companies/departments"
    );
    ok(departmentResource);
    const departmentMetadata = departmentResource.metadata;
    ok(departmentMetadata);

    strictEqual(
      departmentMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(departmentMetadata.singletonResourceName, undefined);
    strictEqual(departmentMetadata.scope.kind, "Subscription");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      departmentMetadata.parentResourceId?.path,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(departmentMetadata.resourceName, "Department");

    // Find the Company resource in the schema by resource type
    const companyResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType === "Microsoft.ContosoProviderHub/companies"
    );
    ok(companyResource);
    const companyMetadata = companyResource.metadata;
    ok(companyMetadata);

    strictEqual(
      companyMetadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(companyMetadata.singletonResourceName, undefined);
    strictEqual(companyMetadata.scope.kind, "Subscription");
    strictEqual(companyMetadata.methods.length, 2);
    strictEqual(companyMetadata.parentResourceId, undefined);
    strictEqual(companyMetadata.resourceName, "Company");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("resource with grand parent under a tenant", async () => {
    const program = await typeSpecCompile(
      `
/** A Company grandparent resource */
@tenantResource
model Company is TrackedResource<CompanyProperties> {
  ...ResourceNameParameter<Company>;
}

/** Company properties */
model CompanyProperties {
  /** Name of company */
  name?: string;
}

/** A Department parent resource */
@tenantResource
@parentResource(Company)
model Department is TrackedResource<DepartmentProperties> {
  ...ResourceNameParameter<Department>;
}

/** Department properties */
model DepartmentProperties {
  /** Name of department */
  name?: string;
}

/** An Employee resource with grandparent */
@tenantResource
@parentResource(Department)
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;

  /** City of employee */
  city?: string;

  /** Profile of employee */
  @encode("base64url")
  profile?: bytes;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Companies {
  get is ArmResourceRead<Company>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Company>;
}

@armResourceOperations
interface Departments {
  get is ArmResourceRead<Department>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Department>;
}

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
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);
    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult);
    ok(armProviderSchemaResult.resources);
    strictEqual(armProviderSchemaResult.resources.length, 3); // Employee, Department, Company

    // Find the Employee resource in the schema by resource type
    const employeeResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    ok(employeeResource);
    const metadata = employeeResource.metadata;
    ok(metadata);

    strictEqual(
      metadata.resourceIdPattern.path,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(metadata.singletonResourceName, undefined);
    strictEqual(metadata.scope.kind, "Tenant");
    strictEqual(metadata.methods.length, 5);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      metadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(
      metadata.parentResourceId?.path,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(metadata.resourceName, "Employee");

    // Find the Department resource in the schema by resource type
    const departmentResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/companies/departments"
    );
    ok(departmentResource);
    const departmentMetadata = departmentResource.metadata;
    ok(departmentMetadata);

    strictEqual(
      departmentMetadata.resourceIdPattern.path,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(departmentMetadata.singletonResourceName, undefined);
    strictEqual(departmentMetadata.scope.kind, "Tenant");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      departmentMetadata.parentResourceId?.path,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(departmentMetadata.resourceName, "Department");

    // Find the Company resource in the schema by resource type
    const companyResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType === "Microsoft.ContosoProviderHub/companies"
    );
    ok(companyResource);
    const companyMetadata = companyResource.metadata;
    ok(companyMetadata);

    strictEqual(
      companyMetadata.resourceIdPattern.path,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(companyMetadata.singletonResourceName, undefined);
    strictEqual(companyMetadata.scope.kind, "Tenant");
    strictEqual(companyMetadata.methods.length, 2);
    strictEqual(companyMetadata.parentResourceId, undefined);
    strictEqual(companyMetadata.resourceName, "Company");

    // Validate using resolveArmResources API
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    ok(resolvedSchema.resources);

    // Compare both schemas using deepStrictEqual
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("resource scope determined from Read method when no explicit decorator", async () => {
    const program = await typeSpecCompile(
      `
@parentResource(SubscriptionLocationResource)
model Employee is ProxyResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee, Type = EmployeeType>;
}

model EmployeeProperties {
  age?: int32;
}

union EmployeeType {
  string,
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);
    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult);
    ok(armProviderSchemaResult.resources);
    strictEqual(armProviderSchemaResult.resources.length, 1); // Employee

    // Find the Employee resource in the schema (should be the only one)
    const employeeResource = armProviderSchemaResult.resources[0];
    ok(employeeResource);
    const metadata = employeeResource.metadata;
    ok(metadata);

    // The model should inherit its ResourceScopeKind from the Read method's operationScope (Subscription)
    // because the Read method operates at subscription scope and there are no explicit scope decorators
    strictEqual(metadata.scope.kind, "Subscription");

    // Verify the Read method itself has the correct scope
    const getMethodEntry = metadata.methods.find((m: any) => m.kind === "Read");
    ok(getMethodEntry);
    strictEqual(getMethodEntry.kind, "Read");
    strictEqual(getMethodEntry.scope.kind, ResourceScopeKind.Subscription);

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("parent-child resource with list operation", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee parent resource */
model EmployeeParent is TrackedResource<EmployeeParentProperties> {
  ...ResourceNameParameter<EmployeeParent>;
}

/** Employee parent properties */
model EmployeeParentProperties {
  /** Name of parent */
  name?: string;
}

/** An Employee resource */
@parentResource(EmployeeParent)
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

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface EmployeeParents {
  get is ArmResourceRead<EmployeeParent>;
}

@armResourceOperations
interface Employees {
  listByParent is ArmResourceListByParent<Employee>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);

    const [root] = createModel(sdkContext);
    // Build ARM provider schema and verify its structure

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);
    strictEqual(armProviderSchema.resources.length, 1); // Only EmployeeParent (Employee has no CRUD ops)

    // Find the EmployeeParent resource in the schema by resource type
    const employeeParentResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/employeeParents"
    );
    ok(employeeParentResource);
    const metadata = employeeParentResource.metadata;
    ok(metadata);

    strictEqual(
      metadata.resourceIdPattern.path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents"
    );
    strictEqual(metadata.scope.kind, "ResourceGroup");
    strictEqual(metadata.parentResourceId, undefined);
    strictEqual(metadata.resourceName, "EmployeeParent");
    strictEqual(metadata.methods.length, 2); // Get and ListByParent

    // Validate EmployeeParent has listByParent method
    const listByParentEntry = metadata.methods.find(
      (m: any) => m.kind === "List"
    );
    ok(listByParentEntry);

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("resource scope as ManagementGroup", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee resource */
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

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
    get is Extension.Read<
    Extension.ManagementGroup<"managementGroupId">,
    Employee
  >;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult);
    ok(armProviderSchemaResult.resources);
    strictEqual(armProviderSchemaResult.resources.length, 1); // Employee

    // Find the Employee resource in the schema by resource type
    const employeeResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType === "Microsoft.ContosoProviderHub/employees"
    );
    ok(employeeResource);
    const metadata = employeeResource.metadata;
    ok(metadata);
    strictEqual(metadata.scope.kind, "ManagementGroup");

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchemaResult)
    );
  });

  it("interface with only action operations (no get)", async () => {
    const program = await typeSpecCompile(
      `
/** A ScheduledAction resource model */
model ScheduledAction is TrackedResource<ScheduledActionProperties> {
  ...ResourceNameParameter<ScheduledAction>;
}

/** ScheduledAction properties */
model ScheduledActionProperties {
  /** Action type */
  actionType?: string;
}

/** Request model for GetAssociatedScheduledActions */
model GetAssociatedScheduledActionsRequest {
  /** Resource IDs to query */
  resourceIds: string[];
}

/** Response model for GetAssociatedScheduledActions */
model GetAssociatedScheduledActionsResponse {
  /** List of scheduled actions */
  scheduledActions: ScheduledAction[];
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface ScheduledActionExtension {
  @post
  @segment("getAssociatedScheduledActions")
  getAssociatedScheduledActions is ArmResourceActionSync<
    ScheduledAction,
    GetAssociatedScheduledActionsRequest,
    GetAssociatedScheduledActionsResponse
  >;

  @doc("Action to retrieve the PostgreSQL versions.")
  @autoRoute
  @armResourceAction(ScheduledAction)
  @post
  getPostgresVersions(
    ...ResourceInstanceParameters<GetAssociatedScheduledActionsRequest>
  ): ArmResponse<GetAssociatedScheduledActionsResponse> | ErrorResponse;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult);

    // ScheduledAction should NOT have a resource entry since it has no CRUD operations
    ok(armProviderSchemaResult.resources);
    const scheduledActionResource = armProviderSchemaResult.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/scheduledActions"
    );
    strictEqual(
      scheduledActionResource,
      undefined,
      "ScheduledAction should not have resource metadata without CRUD operations"
    );

    // Check that the method is treated as a non-resource method
    ok(
      armProviderSchemaResult.nonResourceMethods,
      "Should have non-resource methods"
    );
    ok(
      armProviderSchemaResult.nonResourceMethods.length >= 1,
      "Should have at least one non-resource method"
    );

    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    const methodEntry = nonResourceMethods.find((m: any) =>
      m.operationPath.path.includes("getAssociatedScheduledActions")
    );
    ok(
      methodEntry,
      "getAssociatedScheduledActions should be in non-resource methods"
    );
    strictEqual(methodEntry.scope.kind, ResourceScopeKind.ResourceGroup);

    // Verify getPostgresVersions is also a non-resource method
    const getPostgresVersionsEntry = nonResourceMethods.find((m: any) =>
      m.operationPath.path.includes("getPostgresVersions")
    );
    ok(
      getPostgresVersionsEntry,
      "getPostgresVersions should be in non-resource methods"
    );
    strictEqual(
      getPostgresVersionsEntry.scope.kind,
      ResourceScopeKind.ResourceGroup
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

  it("multiple resources sharing same model", async () => {
    // This test validates the scenario where the SAME model is used by two different
    // resource interfaces operating at different paths using LegacyOperations (similar to the legacy-operations example)
    const program = await typeSpecCompile(
      `
/** A best practice resource - used by both interfaces */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "For sample purpose"
@tenantResource
model BestPractice is ProxyResource<BestPracticeProperties> {
  ...ResourceNameParameter<
    Resource = BestPractice,
    KeyName = "bestPracticeName",
    SegmentName = "bestPractices",
    NamePattern = ""
  >;
  ...Azure.ResourceManager.Legacy.ExtendedLocationOptionalProperty;
}
/** Best practice properties */
model BestPracticeProperties {
  ...DefaultProvisioningStateProperty;
  description?: string;
}
// Define operation aliases with different path patterns using LegacyOperations
alias BestPracticeOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
  },
  {
    @segment("bestPractices")
    @key
    @TypeSpec.Http.path
    bestPracticeName: string;
  }
>;
alias BestPracticesVersionOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
    @segment("bestPractices")
    @key
    @TypeSpec.Http.path
    bestPracticeName: string;
  },
  {
    @segment("versions")
    @key
    @TypeSpec.Http.path
    versionName: string;
  }
>;
/** Best practice operations */
@armResourceOperations
interface BestPractices {
  get is BestPracticeOps.Read<BestPractice>;
  createOrUpdate is BestPracticeOps.CreateOrUpdateSync<BestPractice>;
  delete is BestPracticeOps.DeleteSync<BestPractice>;
}
/** Best practice version operations - uses the SAME BestPractice model */
@armResourceOperations
interface BestPracticeVersions {
  get is BestPracticesVersionOps.Read<BestPractice>;
  createOrUpdate is BestPracticesVersionOps.CreateOrUpdateSync<BestPractice>;
  delete is BestPracticesVersionOps.DeleteSync<BestPractice>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchemaResult);

    // Verify BestPractice model exists
    const bestPracticeModel = root.models.find(
      (m) => m.name === "BestPractice"
    );
    ok(bestPracticeModel, "BestPractice model should exist");

    // Verify the ARM provider schema has TWO resource entries for the same model
    // (one for each interface using the BestPractice model)
    const bestPracticeModelId = bestPracticeModel.crossLanguageDefinitionId;
    const resourcesForModel = armProviderSchemaResult.resources.filter(
      (r) => r.resourceModelId === bestPracticeModelId
    );
    strictEqual(
      resourcesForModel.length,
      2,
      "Should have TWO resource entries for the same model"
    );

    // Find metadata for BestPractices resource (parent-level)
    const bestPracticesResource = resourcesForModel.find(
      (r) =>
        r.metadata.resourceIdPattern.path.includes(
          "/bestPractices/{bestPracticeName}"
        ) && !r.metadata.resourceIdPattern.path.includes("/versions")
    );
    ok(bestPracticesResource, "Should have metadata for parent-level resource");
    const bestPracticesMetadata = bestPracticesResource.metadata;
    strictEqual(
      bestPracticesMetadata.resourceName,
      "BestPractice",
      "Parent resource should be named BestPractice"
    );
    strictEqual(
      bestPracticesMetadata.resourceIdPattern.path,
      "/providers/Microsoft.ContosoProviderHub/bestPractices/{bestPracticeName}"
    );
    strictEqual(
      bestPracticesMetadata.resourceType,
      "Microsoft.ContosoProviderHub/bestPractices"
    );
    strictEqual(
      bestPracticesMetadata.methods.length,
      3,
      "Should have 3 methods"
    );

    // Find metadata for BestPracticeVersions resource (child-level)
    const bestPracticeVersionsResource = resourcesForModel.find((r) =>
      r.metadata.resourceIdPattern.path.includes("/versions/{versionName}")
    );
    ok(
      bestPracticeVersionsResource,
      "Should have metadata for child-level resource"
    );
    const bestPracticeVersionsMetadata = bestPracticeVersionsResource.metadata;
    strictEqual(
      bestPracticeVersionsMetadata.resourceName,
      "BestPracticeVersion",
      "Child resource should be named BestPracticeVersion"
    );
    strictEqual(
      bestPracticeVersionsMetadata.resourceIdPattern.path,
      "/providers/Microsoft.ContosoProviderHub/bestPractices/{bestPracticeName}/versions/{versionName}"
    );
    strictEqual(
      bestPracticeVersionsMetadata.resourceType,
      "Microsoft.ContosoProviderHub/bestPractices/versions"
    );
    strictEqual(
      bestPracticeVersionsMetadata.methods.length,
      3,
      "Should have 3 methods"
    );
    // Note: parentResourceId is not set for legacy operations as there's no explicit @parentResource decorator
    // The parent-child relationship is inferred from the path structure in the generator
    strictEqual(
      bestPracticeVersionsMetadata.parentResourceId?.path,
      bestPracticesMetadata.resourceIdPattern.path
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

  it("3-level nested legacy resources use longest prefix match for parent detection", async () => {
    // This test validates that when 3+ levels of nesting exist using LegacyOperations,
    // the parent detection correctly uses the longest matching prefix (most specific parent).
    // Without the fix, BestPracticeVersionDetail could be assigned to BestPractice (grandparent)
    // instead of BestPracticeVersion (correct parent) if the map iteration order placed
    // BestPractice before BestPracticeVersion.
    const program = await typeSpecCompile(
      `
/** A best practice resource */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "For sample purpose"
@tenantResource
model BestPractice is ProxyResource<BestPracticeProperties> {
  ...ResourceNameParameter<
    Resource = BestPractice,
    KeyName = "bestPracticeName",
    SegmentName = "bestPractices",
    NamePattern = ""
  >;
  ...Azure.ResourceManager.Legacy.ExtendedLocationOptionalProperty;
}
/** Best practice properties */
model BestPracticeProperties {
  ...DefaultProvisioningStateProperty;
  description?: string;
}
alias BestPracticeOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
  },
  {
    @segment("bestPractices")
    @key
    @TypeSpec.Http.path
    bestPracticeName: string;
  }
>;
alias BestPracticesVersionOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
    @segment("bestPractices")
    @key
    @TypeSpec.Http.path
    bestPracticeName: string;
  },
  {
    @segment("versions")
    @key
    @TypeSpec.Http.path
    versionName: string;
  }
>;
alias BestPracticeVersionDetailOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
    @segment("bestPractices")
    @key
    @TypeSpec.Http.path
    bestPracticeName: string;
    @segment("versions")
    @key
    @TypeSpec.Http.path
    versionName: string;
  },
  {
    @segment("details")
    @key
    @TypeSpec.Http.path
    detailName: string;
  }
>;
/** Best practice operations */
@armResourceOperations
interface BestPractices {
  get is BestPracticeOps.Read<BestPractice>;
  createOrUpdate is BestPracticeOps.CreateOrUpdateSync<BestPractice>;
  delete is BestPracticeOps.DeleteSync<BestPractice>;
}
/** Best practice version operations */
@armResourceOperations
interface BestPracticeVersions {
  get is BestPracticesVersionOps.Read<BestPractice>;
  createOrUpdate is BestPracticesVersionOps.CreateOrUpdateSync<BestPractice>;
  delete is BestPracticesVersionOps.DeleteSync<BestPractice>;
}
/** Best practice version detail operations - 3rd level nesting */
@armResourceOperations
interface BestPracticeVersionDetails {
  get is BestPracticeVersionDetailOps.Read<BestPractice>;
  createOrUpdate is BestPracticeVersionDetailOps.CreateOrUpdateSync<BestPractice>;
  delete is BestPracticeVersionDetailOps.DeleteSync<BestPractice>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(
      armProviderSchema.resources.length,
      3,
      "Should have 3 resource entries (BestPractice, BestPracticeVersion, BestPracticeVersionDetail)"
    );

    // Find each resource by its path pattern
    const bestPractice = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/providers/Microsoft.ContosoProviderHub/bestPractices/{bestPracticeName}"
    );
    ok(bestPractice, "Should have BestPractice resource");

    const bestPracticeVersion = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/providers/Microsoft.ContosoProviderHub/bestPractices/{bestPracticeName}/versions/{versionName}"
    );
    ok(bestPracticeVersion, "Should have BestPracticeVersion resource");

    const bestPracticeVersionDetail = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/providers/Microsoft.ContosoProviderHub/bestPractices/{bestPracticeName}/versions/{versionName}/details/{detailName}"
    );
    ok(
      bestPracticeVersionDetail,
      "Should have BestPracticeVersionDetail resource"
    );

    // Critical assertion: BestPracticeVersion's parent should be BestPractice
    strictEqual(
      bestPracticeVersion.metadata.parentResourceId?.path,
      bestPractice.metadata.resourceIdPattern.path,
      "BestPracticeVersion's parent should be BestPractice"
    );

    // Critical assertion: BestPracticeVersionDetail's parent should be BestPracticeVersion (NOT BestPractice)
    // This is the exact scenario the longest-prefix-match fix addresses
    strictEqual(
      bestPracticeVersionDetail.metadata.parentResourceId?.path,
      bestPracticeVersion.metadata.resourceIdPattern.path,
      "BestPracticeVersionDetail's parent should be BestPracticeVersion, not BestPractice"
    );

    // Validate resource names
    strictEqual(bestPractice.metadata.resourceName, "BestPractice");
    strictEqual(
      bestPracticeVersion.metadata.resourceName,
      "BestPracticeVersion"
    );
    strictEqual(
      bestPracticeVersionDetail.metadata.resourceName,
      "BestPracticeVersionDetail"
    );

    // Validate using resolveArmResources API and compare
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("resource without get operation should be filtered", async () => {
    const program = await typeSpecCompile(
      `
/** A parent resource */
model Parent is TrackedResource<ParentProperties> {
  ...ResourceNameParameter<Parent>;
}

/** Parent properties */
model ParentProperties {
  /** Description */
  description?: string;
}

/** A resource without Get operation */
@parentResource(Parent)
model NoGetResource is TrackedResource<NoGetResourceProperties> {
  ...ResourceNameParameter<NoGetResource>;
}

/** NoGetResource properties */
model NoGetResourceProperties {
  /** Description */
  description?: string;
}

@armResourceOperations
interface Parents {
  get is ArmResourceRead<Parent>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Parent>;
  delete is ArmResourceDeleteWithoutOkAsync<Parent>;
  listByResourceGroup is ArmResourceListByParent<Parent>;
}

@armResourceOperations
interface NoGetResources {
  // Note: No Get operation
  createOrUpdate is ArmResourceCreateOrReplaceAsync<NoGetResource>;
  delete is ArmResourceDeleteWithoutOkAsync<NoGetResource>;
  listByResourceGroup is ArmResourceListByParent<NoGetResource>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    // This uses the legacy buildArmProviderSchema which properly filters resources without Get
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);

    // Should only have Parent resource, NoGetResource should be filtered out
    strictEqual(armProviderSchema.resources.length, 1);

    // Verify Parent resource exists
    const parentResource = armProviderSchema.resources.find(
      (r) => r.metadata.resourceType === "Microsoft.ContosoProviderHub/parents"
    );
    ok(parentResource);
    strictEqual(parentResource.metadata.resourceName, "Parent");

    // Parent should have 7 methods: its own 4 methods (get, createOrUpdate, delete, listByResourceGroup)
    // plus all 3 operations from NoGetResource (createOrUpdate, delete, listByResourceGroup)
    strictEqual(
      parentResource.metadata.methods.length,
      7,
      "Parent should have 7 methods including all operations from NoGetResource"
    );

    // Verify the list operation for NoGetResource is in parent's methods as Action
    const noGetListInParent = parentResource.metadata.methods.find(
      (m) =>
        m.kind === "Action" &&
        m.operationPath.path.includes("noGetResources") &&
        m.operationPath.path.endsWith("/noGetResources")
    );
    ok(
      noGetListInParent,
      "Parent resource should have the list operation for NoGetResource as Action"
    );

    // Verify the create operation for NoGetResource is in parent's methods as Action
    const noGetCreateInParent = parentResource.metadata.methods.find(
      (m) =>
        m.kind === "Action" && m.operationPath.path.includes("noGetResources")
    );
    ok(
      noGetCreateInParent,
      "Parent resource should have the create operation for NoGetResource as Action"
    );

    // Verify the delete operation for NoGetResource is in parent's methods as Action
    const noGetDeleteInParent = parentResource.metadata.methods.find(
      (m) =>
        m.kind === "Action" && m.operationPath.path.includes("noGetResources")
    );
    ok(
      noGetDeleteInParent,
      "Parent resource should have the delete operation for NoGetResource as Action"
    );

    // Verify NoGetResource is NOT in resources
    const noGetResource = armProviderSchema.resources.find(
      (r) => r.metadata.resourceName === "NoGetResource"
    );
    strictEqual(noGetResource, undefined);

    // Verify NO NoGetResource operations are in non-resource methods (all should be on parent)
    ok(armProviderSchema.nonResourceMethods);
    const noGetMethods = armProviderSchema.nonResourceMethods.filter((m) =>
      m.operationPath.path.includes("noGetResources")
    );
    strictEqual(
      noGetMethods.length,
      0,
      "Should have no NoGetResource operations in non-resource methods"
    );
  });

  it("multi-scope resource with same model at different scopes", async () => {
    // This test validates the fix for the scenario where the same model is used by multiple
    // resource interfaces at different scopes (ResourceGroup, Subscription, and ServiceGroup/Tenant).
    // Each List operation should be correctly assigned to its corresponding resource.
    const program = await typeSpecCompile(
      `
/** Site properties */
model SiteProperties {
  /** Display name of Site */
  displayName?: string;
  /** Description of Site */
  description?: string;
}

/** Site as Extension Resource */
model Site is ExtensionResource<SiteProperties> {
  ...ResourceNameParameter<
    Resource = Site,
    KeyName = "siteName",
    SegmentName = "sites",
    NamePattern = "^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$"
  >;
}

/** Site operations as base operations which will be extended for each scope */
interface SiteOps<Scope extends Azure.ResourceManager.Foundations.SimpleResource> {
  list is Extension.ListByTarget<Scope, Site>;
  get is Extension.Read<Scope, Site>;
  createOrUpdate is Extension.CreateOrUpdateAsync<Scope, Site>;
  delete is Extension.DeleteSync<Scope, Site>;
}

@armResourceOperations
interface Sites extends SiteOps<Extension.ResourceGroup> {}

@armResourceOperations
interface SitesBySubscription extends SiteOps<Extension.Subscription> {}

alias ServiceGroup = Extension.ExternalResource<
  TargetNamespace = "Microsoft.Management",
  ResourceType = "serviceGroups",
  ResourceParameterName = "servicegroupName",
  NamePattern = "^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$",
  Description = "The name of the service group",
  ParentType = "Tenant"
>;

@armResourceOperations
interface SitesByServiceGroup extends SiteOps<ServiceGroup> {}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema using legacy detection
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);

    // Should have 3 resources for the Site model (one for each scope)
    const siteModel = root.models.find((m) => m.name === "Site");
    ok(siteModel, "Site model should exist");

    const siteModelId = siteModel.crossLanguageDefinitionId;
    const siteResources = armProviderSchema.resources.filter(
      (r) => r.resourceModelId === siteModelId
    );
    strictEqual(
      siteResources.length,
      3,
      "Should have 3 resources for the Site model"
    );

    // Verify each resource exists with the correct resource ID pattern
    const rgSite = siteResources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/sites/{siteName}"
    );
    ok(rgSite, "Should have ResourceGroup-scoped Site");

    const subSite = siteResources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/sites/{siteName}"
    );
    ok(subSite, "Should have Subscription-scoped Site");

    const sgSite = siteResources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.ContosoProviderHub/sites/{siteName}"
    );
    ok(sgSite, "Should have ServiceGroup-scoped Site");

    // This is the critical assertion: each resource should have exactly 1 List method
    // and the List operation path should match the resource's scope
    for (const resource of siteResources) {
      const listMethods = resource.metadata.methods.filter(
        (m) => m.kind === "List"
      );
      strictEqual(
        listMethods.length,
        1,
        `Resource ${resource.metadata.resourceIdPattern.path} should have exactly 1 List method`
      );
    }

    // Validate using resolveArmResources API and compare using deepStrictEqual
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Compare the entire schemas using deep equality
    // Note: The two APIs have a known difference in how they classify ServiceGroup scope:
    // - Legacy detection (buildArmProviderSchema): uses Tenant scope
    // - resolveArmResources: uses Extension scope
    // We normalize ResourceScopeKind and operationScope only for the ServiceGroup-scoped resource
    const serviceGroupResourcePattern =
      "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.ContosoProviderHub/sites/{siteName}";
    const normalizeServiceGroupScopes = (resource: ArmResourceSchema) => {
      if (
        resource.metadata.resourceIdPattern.path === serviceGroupResourcePattern
      ) {
        (resource.metadata as { scope: { kind: unknown } }).scope.kind =
          "<normalized>";
        for (const method of resource.metadata.methods) {
          (method as { scope: { kind: unknown } }).scope.kind = "<normalized>";
        }
      }
    };
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema, normalizeServiceGroupScopes),
      normalizeSchemaForComparison(
        armProviderSchema,
        normalizeServiceGroupScopes
      )
    );
  });

  it("OverrideResourceName with shared model at different scopes assigns names correctly", async () => {
    // This test validates that when two resources share the same model but at different scopes,
    // and one uses OverrideResourceName via ExtensionOperations, the explicit name is NOT
    // cross-contaminated to the other resource. This was a bug where the subscription-scoped
    // list operation's explicitResourceName would overwrite the RG resource's name.
    const program = await typeSpecCompile(
      `
/** Shared config properties */
model SharedConfigProperties {
  /** Display name */
  displayName?: string;
  ...DefaultProvisioningStateProperty;
}

/** Shared config model used at both RG and Subscription scope */
model SharedConfig is TrackedResource<SharedConfigProperties> {
  ...ResourceNameParameter<
    Resource = SharedConfig,
    KeyName = "configName",
    SegmentName = "sharedConfigs",
    NamePattern = ""
  >;
}

// Subscription-scoped resource with OverrideResourceName
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing OverrideResourceName"
alias PublicSharedConfigOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
  },
  {
    ...Azure.ResourceManager.Extension.ExtensionProviderNamespace<SharedConfig>;
    ...ParentKeysOf<SharedConfig>;
  },
  {
    ...Azure.ResourceManager.Extension.ExtensionProviderNamespace<SharedConfig>;
    ...KeysOf<ResourceNameParameter<
      Resource = SharedConfig,
      KeyName = "configName",
      SegmentName = "publicSharedConfigs",
      NamePattern = ""
    >>;
  },
  "PublicSharedConfig"
>;

@armResourceOperations
interface PublicSharedConfigs {
  get is PublicSharedConfigOps.Read<SharedConfig>;
  list is PublicSharedConfigOps.List<SharedConfig>;
}

@armResourceOperations
interface SharedConfigs {
  get is Azure.ResourceManager.Extension.Read<Azure.ResourceManager.Extension.ResourceGroup, SharedConfig>;
  createOrUpdate is Azure.ResourceManager.Extension.CreateOrUpdateAsync<Azure.ResourceManager.Extension.ResourceGroup, SharedConfig>;
  delete is Azure.ResourceManager.Extension.DeleteSync<Azure.ResourceManager.Extension.ResourceGroup, SharedConfig>;
  list is Azure.ResourceManager.Extension.ListByTarget<Azure.ResourceManager.Extension.ResourceGroup, SharedConfig>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);

    const sharedConfigModel = root.models.find(
      (m) => m.name === "SharedConfig"
    );
    ok(sharedConfigModel, "SharedConfig model should exist");

    const sharedConfigModelId = sharedConfigModel.crossLanguageDefinitionId;
    const resources = armProviderSchema.resources.filter(
      (r) => r.resourceModelId === sharedConfigModelId
    );
    strictEqual(
      resources.length,
      2,
      "Should have 2 resources for SharedConfig model"
    );

    // Find each resource by its path pattern
    const rgResource = resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/sharedConfigs/{configName}"
    );
    ok(rgResource, "Should have ResourceGroup-scoped SharedConfig resource");

    const subResource = resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path ===
        "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/publicSharedConfigs/{configName}"
    );
    ok(
      subResource,
      "Should have Subscription-scoped PublicSharedConfig resource"
    );

    // CRITICAL: The RG resource should keep its default name (SharedConfig), NOT be overwritten
    // by the subscription-scoped resource's OverrideResourceName ("PublicSharedConfig")
    strictEqual(
      rgResource.metadata.resourceName,
      "SharedConfig",
      "RG resource should keep default name 'SharedConfig', not be overwritten by OverrideResourceName"
    );
    strictEqual(
      subResource.metadata.resourceName,
      "PublicSharedConfig",
      "Subscription resource should have OverrideResourceName 'PublicSharedConfig'"
    );

    // Each resource should have its own list operation
    const rgListMethods = rgResource.metadata.methods.filter(
      (m) => m.kind === "List"
    );
    strictEqual(
      rgListMethods.length,
      1,
      "RG resource should have exactly 1 List method"
    );

    const subListMethods = subResource.metadata.methods.filter(
      (m) => m.kind === "List"
    );
    strictEqual(
      subListMethods.length,
      1,
      "Subscription resource should have exactly 1 List method"
    );
  });

  it("list operations correctly assigned when same model has different path segments", async () => {
    // This test validates the fix for the Maintenance SDK scenario where the same model
    // is used by two different resource interfaces with DIFFERENT path segments:
    // - publicConfigs (read-only, subscription scope)
    // - configs (CRUD + list, resource group scope)
    // The RG-scoped list operation must be assigned to the RG resource, not the subscription one.
    const program = await typeSpecCompile(
      `
/** Config properties */
model ConfigProperties {
  /** Display name */
  displayName?: string;
  ...DefaultProvisioningStateProperty;
}

/** Configuration resource shared by multiple interfaces */
model Config is ExtensionResource<ConfigProperties> {
  ...ResourceNameParameter<
    Resource = Config,
    KeyName = "resourceName",
    SegmentName = "configs",
    NamePattern = ""
  >;
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "For testing"
alias PublicConfigOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter,
    ...SubscriptionIdParameter,
  },
  {
    ...Extension.ExtensionProviderNamespace<Config>,
    ...ParentKeysOf<Config>,
  },
  {
    ...Extension.ExtensionProviderNamespace<Config>,
    ...KeysOf<ResourceNameParameter<
      Resource = Config,
      KeyName = "resourceName",
      SegmentName = "publicConfigs",
      NamePattern = ""
    >>,
  }
>;

/** Read-only interface at subscription scope with different segment */
@armResourceOperations
interface PublicConfigs {
  get is PublicConfigOps.Read<Config>;
}

/** Full CRUD interface at resource group scope */
@armResourceOperations
interface ConfigOperations {
  get is Extension.Read<Extension.ResourceGroup, Config>;
  createOrUpdate is Extension.CreateOrUpdateAsync<Extension.ResourceGroup, Config>;
  delete is Extension.DeleteSync<Extension.ResourceGroup, Config>;
  list is Extension.ListByTarget<Extension.ResourceGroup, Config>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema using legacy detection
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);

    const configModel = root.models.find((m) => m.name === "Config");
    ok(configModel, "Config model should exist");

    const configModelId = configModel.crossLanguageDefinitionId;
    const configResources = armProviderSchema.resources.filter(
      (r) => r.resourceModelId === configModelId
    );
    strictEqual(
      configResources.length,
      2,
      "Should have TWO resource entries for the same model"
    );

    // Find the public (subscription-scoped, read-only) resource
    const publicResource = configResources.find((r) =>
      r.metadata.resourceIdPattern.path.includes("publicConfigs")
    );
    ok(publicResource, "Should have public resource");

    // Find the RG-scoped CRUD resource
    const rgResource = configResources.find(
      (r) =>
        r.metadata.resourceIdPattern.path.includes("/configs/") &&
        !r.metadata.resourceIdPattern.path.includes("/publicConfigs/")
    );
    ok(rgResource, "Should have RG-scoped resource");

    // Critical assertion: the RG-scoped list operation must be on the RG resource
    const rgListMethods = rgResource.metadata.methods.filter(
      (m) => m.kind === "List"
    );
    strictEqual(
      rgListMethods.length,
      1,
      "RG resource should have exactly 1 List method"
    );

    // The list path should be at RG scope with the configs segment
    ok(
      rgListMethods[0].operationPath.path.includes("resourceGroups") &&
        rgListMethods[0].operationPath.path.endsWith("/configs"),
      "RG resource's list should be at resource group scope with configs segment"
    );

    // The public resource should have NO list operations
    const publicListMethods = publicResource.metadata.methods.filter(
      (m) => m.kind === "List"
    );
    strictEqual(
      publicListMethods.length,
      0,
      "Public resource should have no List methods (it has no list interface)"
    );

    // Validate using resolveArmResources API and compare
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("custom Azure resource with @customAzureResource decorator (TrafficManager pattern)", async () => {
    const program = await typeSpecCompile(
      `
using Azure.ResourceManager.Legacy;

// Custom base Resource model with @customAzureResource decorator
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
@Azure.ResourceManager.Legacy.customAzureResource
model CustomResource {
  id?: string;
  name?: string;
  type?: string;
}

// Custom ProxyResource extending CustomResource
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/no-empty-model" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
model CustomProxyResource extends CustomResource {}

// Custom TrackedResource extending CustomResource
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
model CustomTrackedResource extends CustomResource {
  @visibility(Lifecycle.Create, Lifecycle.Read, Lifecycle.Update)
  tags?: Record<string>;
  @visibility(Lifecycle.Create, Lifecycle.Read)
  location?: string;
}

// Traffic Profile (parent resource) extending custom tracked resource
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
model TrafficProfile extends CustomTrackedResource {
  properties?: TrafficProfileProperties;
}

model TrafficProfileProperties {
  profileStatus?: string;
}

// Traffic Endpoint (child resource) extending custom proxy resource
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
@parentResource(TrafficProfile)
model TrafficEndpoint extends CustomProxyResource {
  properties?: TrafficEndpointProperties;
}

model TrafficEndpointProperties {
  target?: string;
}

// Define legacy operations for TrafficProfile
alias TrafficProfileOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider<TrafficProfile>;
  },
  {
    @path
    @segment("trafficProfiles")
    profileName: string;
  },
  ErrorResponse,
  "TrafficProfile"
>;

@armResourceOperations
interface TrafficProfiles {
  get is TrafficProfileOps.Read<TrafficProfile>;
  createOrUpdate is TrafficProfileOps.CreateOrUpdateSync<TrafficProfile>;
  delete is TrafficProfileOps.DeleteSync<TrafficProfile>;
  list is TrafficProfileOps.List<TrafficProfile>;
}

// Define legacy operations for TrafficEndpoint
alias TrafficEndpointOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider<TrafficEndpoint>;
    @path
    @segment("trafficProfiles")
    profileName: string;
  },
  {
    @path
    @segment("endpoints")
    endpointName: string;
  },
  ErrorResponse,
  "TrafficEndpoint"
>;

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "Testing LegacyOperations pattern"
interface TrafficEndpoints {
  get is TrafficEndpointOps.Read<TrafficEndpoint>;
  createOrUpdate is TrafficEndpointOps.CreateOrUpdateSync<TrafficEndpoint>;
  delete is TrafficEndpointOps.DeleteSync<TrafficEndpoint>;
}
`,
      runner
    );

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);

    // Should have TrafficProfile and TrafficEndpoint as resources
    strictEqual(
      armProviderSchema.resources.length,
      2,
      "Should have 2 resources: TrafficProfile and TrafficEndpoint"
    );

    // Find the TrafficProfile resource
    const trafficProfileResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/trafficProfiles"
    );
    ok(trafficProfileResource, "TrafficProfile resource should be detected");
    strictEqual(
      trafficProfileResource.resourceModelId,
      "Microsoft.ContosoProviderHub.TrafficProfile",
      "TrafficProfile resource model ID should match"
    );
    strictEqual(
      trafficProfileResource.metadata.resourceName,
      "TrafficProfile",
      "Resource name should be TrafficProfile"
    );
    strictEqual(
      trafficProfileResource.metadata.methods.length,
      4,
      "TrafficProfile should have 4 methods (get, createOrUpdate, delete, list)"
    );

    // Find the TrafficEndpoint resource
    const trafficEndpointResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/trafficProfiles/endpoints"
    );
    ok(trafficEndpointResource, "TrafficEndpoint resource should be detected");
    strictEqual(
      trafficEndpointResource.resourceModelId,
      "Microsoft.ContosoProviderHub.TrafficEndpoint",
      "TrafficEndpoint resource model ID should match"
    );
    strictEqual(
      trafficEndpointResource.metadata.resourceName,
      "TrafficEndpoint",
      "Resource name should be TrafficEndpoint"
    );
    strictEqual(
      trafficEndpointResource.metadata.methods.length,
      3,
      "TrafficEndpoint should have 3 methods (get, createOrUpdate, delete)"
    );

    // Verify the parent-child relationship
    strictEqual(
      trafficEndpointResource.metadata.parentResourceId?.path,
      trafficProfileResource.metadata.resourceIdPattern.path,
      "TrafficEndpoint should have TrafficProfile as parent"
    );

    // Validate using resolveArmResources API
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Note: resolveArmResources does not detect custom Azure resources
    // (those using @customAzureResource decorator), so the resolved schema
    // will have no resources. This is a known gap — custom resources are only
    // detected by the legacy buildArmProviderSchema path.
    strictEqual(
      resolvedSchema.resources.length,
      0,
      "resolveArmResources does not detect custom Azure resources"
    );
  });

  it("builtInResourceOperation - NspConfiguration pattern", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee parent resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

/** NSP configuration model */
@parentResource(Employee)
model NspConfiguration
  is Azure.ResourceManager.CommonTypes.NspConfigurationResource<"networkSecurityPerimeterConfigurationName"> {
}

// NspConfigurationOperations templates implicitly apply @builtInResourceOperation decorator
alias NspConfigurationOps = Azure.ResourceManager.CommonTypes.NspConfigurationOperations<NspConfiguration>;

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
}

@armResourceOperations
@tag("NetworkSecurityPerimeter")
interface NetworkSecurityPerimeterConfigurations {
  // Implicitly gets @builtInResourceOperation(Employee, NspConfiguration, "read")
  getConfiguration is NspConfigurationOps.Read<
    ParentResource = Employee,
    Resource = NspConfiguration
  >;

  // Implicitly gets @builtInResourceOperation(Employee, NspConfiguration, "list")
  @list
  listConfigurations is NspConfigurationOps.ListByParent<
    ParentResource = Employee,
    Resource = NspConfiguration
  >;

  // Reuses Read template so implicitly gets @builtInResourceOperation(..., "read"),
  // but @post @action("reconcile") overrides it — should be classified as Action, not Read
  @post
  @action("reconcile")
  reconcileConfiguration is NspConfigurationOps.Read<
    ParentResource = Employee,
    Resource = NspConfiguration,
    Response = ArmAcceptedLroResponse
  >;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);

    // Should have Employee and NspConfiguration as resources
    const nspResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/employees/networkSecurityPerimeterConfigurations"
    );
    ok(nspResource, "NspConfiguration resource should be detected");

    // Validate resource has the correct operations
    const methods = nspResource.metadata.methods;

    // Should have exactly 3 operations: Read, List, and Action
    strictEqual(
      methods.length,
      3,
      "NspConfiguration resource should have exactly 3 operations (Read, List, Action)"
    );

    const readMethods = methods.filter((m: any) => m.kind === "Read");
    strictEqual(
      readMethods.length,
      1,
      "NspConfiguration resource should have exactly 1 Read operation"
    );

    const listMethods = methods.filter((m: any) => m.kind === "List");
    strictEqual(
      listMethods.length,
      1,
      "NspConfiguration resource should have exactly 1 List operation"
    );

    // The reconcile operation (decorated with @post @action but using Read template)
    // should be treated as an Action, not a Read
    const actionMethods = nspResource.metadata.methods.filter(
      (m: any) => m.kind === "Action"
    );
    strictEqual(
      actionMethods.length,
      1,
      "reconcileConfiguration should be classified as an Action operation, not a Read"
    );

    // Validate using resolveArmResources API
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Both schemas should detect the NSP resource
    const resolvedNspResource = resolvedSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/employees/networkSecurityPerimeterConfigurations"
    );
    ok(
      resolvedNspResource,
      "resolveArmResources should also detect NspConfiguration resource"
    );

    // Validate operation kinds in the resolveArmResources path
    const resolvedMethods = resolvedNspResource.metadata.methods;
    const resolvedMethodKinds = resolvedMethods.map((m: any) => m.kind);
    ok(
      resolvedMethodKinds.includes("Read"),
      "Should have Read operation in resolveArmResources"
    );
    ok(
      resolvedMethodKinds.includes("List"),
      "Should have List operation in resolveArmResources"
    );

    // Note: The upstream resolveArmResources API from @azure-tools/typespec-azure-resource-manager
    // does not currently handle @action decorator overrides on @builtInResourceOperation templates.
    // The reconcile operation may be classified as Read instead of Action in this path.
    // The legacy path (buildArmProviderSchema) correctly handles this override.
  });

  it("CreateOrReplaceAsync with @patch should be classified as Update not Create", async () => {
    const program = await typeSpecCompile(
      `
/** Monitor properties */
model MonitorProperties {
  /** The status */
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

/** A Monitor resource */
model MonitorResource is TrackedResource<MonitorProperties> {
  ...ResourceNameParameter<MonitorResource, SegmentName = "monitors">;
}

/** Update parameters */
model MonitorUpdateParameters {
  /** Tags */
  tags?: Record<string>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface MonitorResources {
  get is ArmResourceRead<MonitorResource>;
  create is Azure.ResourceManager.Legacy.CreateOrUpdateAsync<MonitorResource>;
  @patch(#{ implicitOptionality: false })
  update is Azure.ResourceManager.Legacy.CreateOrReplaceAsync<
    MonitorResource,
    Request = MonitorUpdateParameters,
    Response = ArmResponse<MonitorResource> | ArmResourceCreatedResponse<MonitorResource>
  >;
  delete is ArmResourceDeleteWithoutOkAsync<MonitorResource>;
  listByResourceGroup is ArmResourceListByParent<MonitorResource>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    ok(armProviderSchema.resources);
    strictEqual(armProviderSchema.resources.length, 1);

    const monitorResource = armProviderSchema.resources[0];
    ok(monitorResource);
    const metadata = monitorResource.metadata;
    ok(metadata);

    // Should have Read, Create, Update, Delete, List
    const methodKinds = metadata.methods.map((m: any) => m.kind);
    ok(methodKinds.includes("Read"), "Should have Read method");
    ok(
      methodKinds.includes("Create"),
      "Should have Create method (from CreateOrUpdateAsync PUT)"
    );
    ok(
      methodKinds.includes("Update"),
      "Should have Update method (from CreateOrReplaceAsync PATCH)"
    );
    ok(methodKinds.includes("Delete"), "Should have Delete method");
    ok(methodKinds.includes("List"), "Should have List method");

    // Ensure there is exactly one Create and one Update
    const createMethods = metadata.methods.filter(
      (m: any) => m.kind === "Create"
    );
    const updateMethods = metadata.methods.filter(
      (m: any) => m.kind === "Update"
    );
    strictEqual(
      createMethods.length,
      1,
      "Should have exactly one Create method"
    );
    strictEqual(
      updateMethods.length,
      1,
      "Should have exactly one Update method"
    );

    // Validate using resolveArmResources API
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    strictEqual(
      resolvedSchema.resources.length,
      1,
      "resolveArmResources should detect 1 resource"
    );

    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    const resolvedMethods = resolvedResource.metadata.methods;
    const resolvedMethodKinds = resolvedMethods.map((m: any) => m.kind);
    ok(
      resolvedMethodKinds.includes("Create"),
      "resolveArmResources should have Create method"
    );
    ok(
      resolvedMethodKinds.includes("Delete"),
      "resolveArmResources should have Delete method"
    );
    ok(
      resolvedMethodKinds.includes("List"),
      "resolveArmResources should have List method"
    );

    // Note: The upstream resolveArmResources API from @azure-tools/typespec-azure-resource-manager
    // classifies both Legacy.CreateOrUpdateAsync (PUT) and Legacy.CreateOrReplaceAsync + @patch (PATCH)
    // as createOrUpdate, resulting in 2 Create methods. The legacy buildArmProviderSchema path uses
    // HTTP verb to distinguish them: PUT → Create, PATCH → Update.
    const resolvedCreateMethods = resolvedMethods.filter(
      (m: any) => m.kind === "Create"
    );
    const resolvedUpdateMethods = resolvedMethods.filter(
      (m: any) => m.kind === "Update"
    );
    strictEqual(
      resolvedCreateMethods.length,
      2,
      "resolveArmResources has 2 Create methods (both classified as createOrUpdate)"
    );
    strictEqual(
      resolvedUpdateMethods.length,
      0,
      "resolveArmResources has 0 Update methods (PATCH not distinguished)"
    );
  });

  it("cross-scope LegacyOperations assigns correct parent per scope", async () => {
    // This test validates the scenario from the Support SDK where the same model is used
    // at both subscription and tenant scopes via LegacyOperations. The child resource's
    // @parentResource points to a subscription-scoped model, but when the child also
    // operates at tenant scope, the tenant-scoped child should get the tenant-scoped
    // parent (not the subscription-scoped one).
    const program = await typeSpecCompile(
      `
/** A support ticket resource */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing cross-scope parent"
@subscriptionResource
model SupportTicket is ProxyResource<SupportTicketProperties> {
  ...ResourceNameParameter<
    Resource = SupportTicket,
    KeyName = "ticketName",
    SegmentName = "tickets",
    NamePattern = ""
  >;
}
/** Support ticket properties */
model SupportTicketProperties {
  /** Description */
  description?: string;
}

/** A chat transcript child resource */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing cross-scope parent"
@parentResource(SupportTicket)
model ChatTranscript is ProxyResource<ChatTranscriptProperties> {
  ...ResourceNameParameter<
    Resource = ChatTranscript,
    KeyName = "transcriptName",
    SegmentName = "transcripts",
    NamePattern = ""
  >;
}
/** Chat transcript properties */
model ChatTranscriptProperties {
  /** Content */
  content?: string;
}

// Subscription-scoped ticket operations
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing cross-scope parent"
alias SubTicketOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...Azure.ResourceManager.Legacy.Provider;
  },
  {
    @segment("tickets")
    @key
    @TypeSpec.Http.path
    ticketName: string;
  }
>;

// Tenant-scoped ticket operations (no SubscriptionIdParameter)
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing cross-scope parent"
alias TenantTicketOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
  },
  {
    @segment("tickets")
    @key
    @TypeSpec.Http.path
    ticketName: string;
  }
>;

// Subscription-scoped transcript operations (parent = subscription ticket)
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing cross-scope parent"
alias SubTranscriptOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...Azure.ResourceManager.Legacy.Provider;
    @segment("tickets")
    @key
    @TypeSpec.Http.path
    ticketName: string;
  },
  {
    @segment("transcripts")
    @key
    @TypeSpec.Http.path
    transcriptName: string;
  }
>;

// Tenant-scoped transcript operations (parent = tenant ticket)
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing cross-scope parent"
alias TenantTranscriptOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
    @segment("tickets")
    @key
    @TypeSpec.Http.path
    ticketName: string;
  },
  {
    @segment("transcripts")
    @key
    @TypeSpec.Http.path
    transcriptName: string;
  }
>;

@armResourceOperations
interface SubscriptionTickets {
  get is SubTicketOps.Read<SupportTicket>;
  list is SubTicketOps.List<SupportTicket>;
}

@armResourceOperations
interface TenantTickets {
  get is TenantTicketOps.Read<SupportTicket>;
  list is TenantTicketOps.List<SupportTicket>;
}

@armResourceOperations
interface SubscriptionTranscripts {
  get is SubTranscriptOps.Read<ChatTranscript>;
  list is SubTranscriptOps.List<ChatTranscript>;
}

@armResourceOperations
interface TenantTranscripts {
  get is TenantTranscriptOps.Read<ChatTranscript>;
  list is TenantTranscriptOps.List<ChatTranscript>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Build ARM provider schema
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);

    // Should have 4 resources: sub ticket, tenant ticket, sub transcript, tenant transcript
    strictEqual(
      armProviderSchema.resources.length,
      4,
      "Should have 4 resources (2 tickets + 2 transcripts at different scopes)"
    );

    // Find each resource by its path pattern
    const subTicket = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path.includes("/subscriptions/") &&
        r.metadata.resourceIdPattern.path.endsWith("/tickets/{ticketName}")
    );
    const tenantTicket = armProviderSchema.resources.find(
      (r) =>
        !r.metadata.resourceIdPattern.path.includes("/subscriptions/") &&
        r.metadata.resourceIdPattern.path.endsWith("/tickets/{ticketName}")
    );
    const subTranscript = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceIdPattern.path.includes("/subscriptions/") &&
        r.metadata.resourceIdPattern.path.endsWith(
          "/transcripts/{transcriptName}"
        )
    );
    const tenantTranscript = armProviderSchema.resources.find(
      (r) =>
        !r.metadata.resourceIdPattern.path.includes("/subscriptions/") &&
        r.metadata.resourceIdPattern.path.endsWith(
          "/transcripts/{transcriptName}"
        )
    );

    ok(subTicket, "Should have subscription-scoped ticket");
    ok(tenantTicket, "Should have tenant-scoped ticket");
    ok(subTranscript, "Should have subscription-scoped transcript");
    ok(tenantTranscript, "Should have tenant-scoped transcript");

    // KEY ASSERTION: Tenant-scoped transcript should have tenant-scoped ticket as parent
    // (not the subscription-scoped ticket from @parentResource decorator)
    strictEqual(
      tenantTranscript.metadata.parentResourceId?.path,
      tenantTicket.metadata.resourceIdPattern.path,
      "Tenant transcript's parent should be the tenant ticket (same scope)"
    );

    // Subscription-scoped transcript should have subscription-scoped ticket as parent
    strictEqual(
      subTranscript.metadata.parentResourceId?.path,
      subTicket.metadata.resourceIdPattern.path,
      "Subscription transcript's parent should be the subscription ticket (same scope)"
    );

    // Verify the list operations have correct ResourceScopeKind for tenant transcript
    const tenantTranscriptList = tenantTranscript.metadata.methods.find(
      (m: any) => m.kind === "List"
    );
    ok(tenantTranscriptList, "Tenant transcript should have a List method");
    strictEqual(
      tenantTranscriptList.scope.scopeIdPattern?.path,
      tenantTicket.metadata.resourceIdPattern.path,
      "Tenant transcript list should scope to tenant ticket"
    );

    // Validate using resolveArmResources API
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    // Note: resolveArmResources merges subscription-scoped and tenant-scoped operations
    // for the same model into fewer resources, while the legacy buildArmProviderSchema
    // correctly separates them into distinct resources per scope. This is a known gap in
    // resolveArmResources for cross-scope LegacyOperations patterns.
    // The legacy path (4 resources) is the correct behavior for SDK generation.
    strictEqual(
      armProviderSchema.resources.length,
      4,
      "Legacy detection should produce 4 resources (2 per scope)"
    );
  });

  it("name constraints with all decorators via NamePattern and direct decorators", async () => {
    const program = await typeSpecCompile(
      `
/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

/** An Employee resource with name constraints via NamePattern */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<
    Resource = Employee,
    KeyName = "employeeName",
    SegmentName = "employees",
    NamePattern = "^[a-zA-Z0-9-]{3,24}$"
  >;
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
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);

    const employeeResource = armProviderSchema.resources[0];
    ok(employeeResource);
    const constraints = employeeResource.metadata.nameConstraints;
    ok(constraints);
    strictEqual(constraints.pattern, "^[a-zA-Z0-9-]{3,24}$");

    // Also validate resolveArmResources produces the same constraints
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    deepStrictEqual(resolvedResource.metadata.nameConstraints, constraints);
  });

  it("name constraints with minLength and maxLength decorators", async () => {
    const program = await typeSpecCompile(
      `
/** Widget properties */
model WidgetProperties {
  /** Color of widget */
  color?: string;
}

/** A Widget resource with direct name decorators */
model Widget is TrackedResource<WidgetProperties> {
  @doc("The widget name.")
  @key("widgetName")
  @segment("widgets")
  @path
  @minLength(3)
  @maxLength(63)
  @pattern("^[a-z][a-z0-9]*$")
  name: string;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Widgets {
  get is ArmResourceRead<Widget>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Widget>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);

    const widgetResource = armProviderSchema.resources[0];
    ok(widgetResource);
    const constraints = widgetResource.metadata.nameConstraints;
    ok(constraints);
    strictEqual(constraints.pattern, "^[a-z][a-z0-9]*$");
    strictEqual(constraints.minLength, 3);
    strictEqual(constraints.maxLength, 63);

    // Also validate resolveArmResources produces the same constraints
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    deepStrictEqual(resolvedResource.metadata.nameConstraints, constraints);
  });

  it("name constraints are empty when no decorators are applied", async () => {
    const program = await typeSpecCompile(
      `
/** Gadget properties */
model GadgetProperties {
  /** Size of gadget */
  size?: int32;
}

/** A Gadget resource with no name constraints */
model Gadget is TrackedResource<GadgetProperties> {
  @doc("The gadget name.")
  @key("gadgetName")
  @segment("gadgets")
  @path
  name: string;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Gadgets {
  get is ArmResourceRead<Gadget>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Gadget>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);

    const gadgetResource = armProviderSchema.resources[0];
    ok(gadgetResource);
    const constraints = gadgetResource.metadata.nameConstraints;
    ok(constraints);
    strictEqual(constraints.pattern, undefined);
    strictEqual(constraints.minLength, undefined);
    strictEqual(constraints.maxLength, undefined);

    // Also validate resolveArmResources produces the same constraints
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    deepStrictEqual(resolvedResource.metadata.nameConstraints, constraints);
  });

  it("name constraints with only pattern via NamePattern", async () => {
    const program = await typeSpecCompile(
      `
/** Item properties */
model ItemProperties {
  /** Description */
  description?: string;
}

/** An Item resource with only a pattern constraint */
model Item is TrackedResource<ItemProperties> {
  ...ResourceNameParameter<
    Resource = Item,
    KeyName = "itemName",
    SegmentName = "items",
    NamePattern = "^[a-zA-Z0-9]+$"
  >;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Items {
  get is ArmResourceRead<Item>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Item>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);

    const itemResource = armProviderSchema.resources[0];
    ok(itemResource);
    const constraints = itemResource.metadata.nameConstraints;
    ok(constraints);
    strictEqual(constraints.pattern, "^[a-zA-Z0-9]+$");
    strictEqual(constraints.minLength, undefined);
    strictEqual(constraints.maxLength, undefined);

    // Also validate resolveArmResources produces the same constraints
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    deepStrictEqual(resolvedResource.metadata.nameConstraints, constraints);
  });

  it("api versions populated for single version resource", async () => {
    const program = await typeSpecCompile(
      `
/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

/** An Employee resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
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
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);
    deepStrictEqual(armProviderSchema.resources[0].metadata.apiVersions, [
      "2021-10-01-preview"
    ]);

    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    deepStrictEqual(resolvedSchema.resources[0].metadata.apiVersions, [
      "2021-10-01-preview"
    ]);
  });

  it("api versions populated for multi-version resources", async () => {
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
    namespace Microsoft.ContosoProviderHub;

    /** api versions */
    enum Versions {
      @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
      \`2024-04-01\`,
      @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
      \`2024-05-01\`,
    }

    /** Widget properties */
    model WidgetProperties {
      /** Color of widget */
      color?: string;
    }

    /** A Widget resource - available in all versions */
    model Widget is TrackedResource<WidgetProperties> {
      ...ResourceNameParameter<Widget>;
    }

    /** Gadget properties */
    model GadgetProperties {
      /** Size of gadget */
      size?: int32;
    }

    /** A Gadget resource - added in second version only */
    @added(Versions.\`2024-05-01\`)
    @parentResource(Widget)
    model Gadget is ProxyResource<GadgetProperties> {
      ...ResourceNameParameter<Gadget>;
    }

    interface Operations extends Azure.ResourceManager.Operations {}

    @armResourceOperations
    interface Widgets {
      get is ArmResourceRead<Widget>;
      createOrUpdate is ArmResourceCreateOrReplaceAsync<Widget>;
    }

    @added(Versions.\`2024-05-01\`)
    @armResourceOperations
    interface Gadgets {
      get is ArmResourceRead<Gadget>;
      createOrUpdate is ArmResourceCreateOrReplaceAsync<Gadget>;
    }
    `;
    runner.addTypeSpecFile("main.tsp", fileContent);
    await runner.compile("./", { warningAsError: false });
    const program = runner.program;

    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    // Test buildArmProviderSchema (legacy path)
    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 2);

    const widgetResource = armProviderSchema.resources.find(
      (r) => r.metadata.resourceType === "Microsoft.ContosoProviderHub/widgets"
    );
    ok(widgetResource);
    deepStrictEqual(widgetResource.metadata.apiVersions, [
      "2024-04-01",
      "2024-05-01"
    ]);

    const gadgetResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/widgets/gadgets"
    );
    ok(gadgetResource);
    deepStrictEqual(gadgetResource.metadata.apiVersions, ["2024-05-01"]);

    // Test resolveArmResources (new path)
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    const resolvedWidget = resolvedSchema.resources.find(
      (r) => r.metadata.resourceType === "Microsoft.ContosoProviderHub/widgets"
    );
    ok(resolvedWidget);
    deepStrictEqual(resolvedWidget.metadata.apiVersions, [
      "2024-04-01",
      "2024-05-01"
    ]);

    const resolvedGadget = resolvedSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/widgets/gadgets"
    );
    ok(resolvedGadget);
    deepStrictEqual(resolvedGadget.metadata.apiVersions, ["2024-05-01"]);
  });

  it("rbac roles from clientOption decorator", async () => {
    const program = await typeSpecCompile(
      `
/** Widget properties */
model WidgetProperties {
  /** Color of widget */
  color?: string;
}

/** A Widget resource with RBAC roles */
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Widgets {
  get is ArmResourceRead<Widget>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Widget>;
}

#suppress "@azure-tools/typespec-client-generator-core/client-option" "RBAC roles"
@@clientOption(Widget, "resource-rbac-roles", #{
  WidgetContributor: "00000000-0000-0000-0000-000000000001",
  WidgetReader: "00000000-0000-0000-0000-000000000002",
}, "csharp");
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);

    const widgetResource = armProviderSchema.resources[0];
    ok(widgetResource);
    deepStrictEqual(widgetResource.metadata.rbacRoles, [
      {
        name: "WidgetContributor",
        value: "00000000-0000-0000-0000-000000000001"
      },
      { name: "WidgetReader", value: "00000000-0000-0000-0000-000000000002" }
    ]);

    // Also validate resolveArmResources produces the same roles
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    deepStrictEqual(
      resolvedResource.metadata.rbacRoles,
      widgetResource.metadata.rbacRoles
    );
  });

  it("rbac roles empty when no clientOption decorator", async () => {
    const program = await typeSpecCompile(
      `
/** Gadget properties */
model GadgetProperties {
  /** Size of gadget */
  size?: int32;
}

/** A Gadget resource without RBAC roles */
model Gadget is TrackedResource<GadgetProperties> {
  ...ResourceNameParameter<Gadget>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Gadgets {
  get is ArmResourceRead<Gadget>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Gadget>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);
    strictEqual(armProviderSchema.resources.length, 1);

    const gadgetResource = armProviderSchema.resources[0];
    ok(gadgetResource);
    deepStrictEqual(gadgetResource.metadata.rbacRoles, []);

    // Also validate resolveArmResources produces empty roles
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);
    const resolvedResource = resolvedSchema.resources[0];
    ok(resolvedResource);
    deepStrictEqual(resolvedResource.metadata.rbacRoles, []);
  });

  it("action on parent singleton that lists child resources should be reassigned to child resource", async () => {
    // This test reproduces the Storage SDK pattern where a list operation
    // (e.g., blobContainersList) is modeled as an ArmResourceActionSync on a
    // singleton parent (BlobService) rather than as ArmResourceListByParent on
    // the child interface (BlobContainers).
    //
    // The emitter classifies it as kind=Action on the parent resource.
    // The generator then routes it to the parent's Resource class instead of
    // the child's Collection class, breaking backward compatibility.
    //
    // Expected behavior: the emitter should detect that this Action's operation
    // path matches a child resource's collection path and reclassify it as a
    // List on the child resource.

    const program = await typeSpecCompile(
      `
/** Storage account resource */
model StorageAccount is TrackedResource<StorageAccountProperties> {
  ...ResourceNameParameter<StorageAccount>;
}

/** Storage account properties */
model StorageAccountProperties {
  /** Account description */
  description?: string;
}

/** Blob service singleton resource */
@singleton
@parentResource(StorageAccount)
model BlobService is ProxyResource<BlobServiceProperties> {
  ...ResourceNameParameter<BlobService>;
}

/** Blob service properties */
model BlobServiceProperties {
  /** Whether versioning is enabled */
  isVersioningEnabled?: boolean;
}

/** Container child resource */
@parentResource(BlobService)
model Container is ProxyResource<ContainerProperties> {
  ...ResourceNameParameter<Container>;
}

/** Container properties */
model ContainerProperties {
  /** Public access level */
  publicAccess?: string;
}

/** List of containers */
model ListContainerItems {
  /** The list of containers */
  @pageItems
  value?: Container[];

  /** The next link */
  @nextLink
  nextLink?: string;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface StorageAccounts {
  get is ArmResourceRead<StorageAccount>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<StorageAccount>;
}

@armResourceOperations
interface BlobServices {
  get is ArmResourceRead<BlobService>;
  setProperties is ArmResourceCreateOrReplaceSync<BlobService>;

  /** Lists all containers in the blob service - modeled as action on parent */
  @get
  @list
  containers is ArmResourceActionSync<
    BlobService,
    void,
    ListContainerItems
  >;
}

@armResourceOperations
interface Containers {
  get is ArmResourceRead<Container>;
  createOrUpdate is ArmResourceCreateOrReplaceSync<Container>;
  delete is ArmResourceDeleteSync<Container>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);

    // Find the resources
    const storageAccountResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/storageAccounts"
    );
    ok(storageAccountResource, "StorageAccount resource should exist");

    const blobServiceResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/storageAccounts/blobServices"
    );
    ok(blobServiceResource, "BlobService resource should exist");

    const containerResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/storageAccounts/blobServices/containers"
    );
    ok(containerResource, "Container resource should exist");

    // Verify BlobService is a singleton with correct parent
    strictEqual(blobServiceResource.metadata.singletonResourceName, "default");
    strictEqual(
      blobServiceResource.metadata.parentResourceId,
      storageAccountResource.metadata.resourceIdPattern
    );

    // Verify Container's parent is BlobService
    strictEqual(
      containerResource.metadata.parentResourceId,
      blobServiceResource.metadata.resourceIdPattern
    );

    // After fix: listContainers should have been moved from BlobService to Container
    const blobServiceMethods = blobServiceResource.metadata.methods;
    const containerMethods = containerResource.metadata.methods;

    // The listContainers method should be on Container as kind=List
    const listOnContainer = containerMethods.find(
      (m: any) => m.kind === "List"
    );
    ok(
      listOnContainer,
      "listContainers should be on Container as a List method"
    );
    strictEqual(listOnContainer!.kind, "List");
    ok(
      listOnContainer!.operationPath.path.includes("/containers"),
      "The List method should be the relocated containers operation"
    );

    // BlobService should NOT have the listContainers action anymore
    const listContainersOnService = blobServiceMethods.find(
      (m: any) =>
        m.kind === "Action" && m.operationPath?.includes("/containers")
    );
    strictEqual(
      listContainersOnService,
      undefined,
      "listContainers should no longer be on BlobService"
    );

    // BlobService should still have its own methods (Read + Create)
    ok(
      blobServiceMethods.some((m: any) => m.kind === "Read"),
      "BlobService should still have Read"
    );
    ok(
      blobServiceMethods.some((m: any) => m.kind === "Create"),
      "BlobService should still have Create"
    );

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });

  it("ArmResourceListByParent in parent interface routes list to child resource", async () => {
    // Validates the spec-level fix: using ArmResourceListByParent<Container>
    // in the BlobServices interface (instead of ArmResourceActionSync) produces
    // kind=List and correctly assigns it to the Container resource — even though
    // the operation is defined in the parent's interface.

    const program = await typeSpecCompile(
      `
/** Storage account resource */
model StorageAccount is TrackedResource<StorageAccountProperties> {
  ...ResourceNameParameter<StorageAccount>;
}

/** Storage account properties */
model StorageAccountProperties {
  /** Account description */
  description?: string;
}

/** Blob service singleton resource */
@singleton
@parentResource(StorageAccount)
model BlobService is ProxyResource<BlobServiceProperties> {
  ...ResourceNameParameter<BlobService>;
}

/** Blob service properties */
model BlobServiceProperties {
  /** Whether versioning is enabled */
  isVersioningEnabled?: boolean;
}

/** Container child resource */
@parentResource(BlobService)
model Container is ProxyResource<ContainerProperties> {
  ...ResourceNameParameter<Container>;
}

/** Container properties */
model ContainerProperties {
  /** Public access level */
  publicAccess?: string;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface StorageAccounts {
  get is ArmResourceRead<StorageAccount>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<StorageAccount>;
}

@armResourceOperations
interface BlobServices {
  get is ArmResourceRead<BlobService>;
  setProperties is ArmResourceCreateOrReplaceSync<BlobService>;

  /** Lists all containers - uses ArmResourceListByParent in parent interface */
  listContainers is ArmResourceListByParent<Container>;
}

@armResourceOperations
interface Containers {
  get is ArmResourceRead<Container>;
  createOrUpdate is ArmResourceCreateOrReplaceSync<Container>;
  delete is ArmResourceDeleteSync<Container>;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    ok(armProviderSchema);

    const containerResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/storageAccounts/blobServices/containers"
    );
    ok(containerResource, "Container resource should exist");

    const blobServiceResource = armProviderSchema.resources.find(
      (r) =>
        r.metadata.resourceType ===
        "Microsoft.ContosoProviderHub/storageAccounts/blobServices"
    );
    ok(blobServiceResource, "BlobService resource should exist");

    // Container should have the List method (routed from BlobServices interface)
    const listOnContainer = containerResource.metadata.methods.find(
      (m: any) => m.kind === "List"
    );
    ok(listOnContainer, "Container should have a List method");
    strictEqual(listOnContainer!.kind, "List");

    // BlobService should NOT have the list operation
    const listOnService = blobServiceResource.metadata.methods.find(
      (m: any) =>
        m.kind === "List" ||
        (m.kind === "Action" && m.operationPath?.includes("/containers"))
    );
    strictEqual(
      listOnService,
      undefined,
      "BlobService should not have the list containers operation"
    );

    // BlobService should still have its own methods (Read + Create)
    ok(
      blobServiceResource.metadata.methods.some((m: any) => m.kind === "Read")
    );
    ok(
      blobServiceResource.metadata.methods.some((m: any) => m.kind === "Create")
    );

    // Validate using resolveArmResources API - use deep equality to ensure schemas match
    const resolvedSchema = resolveArmResources(program, sdkContext);
    ok(resolvedSchema);

    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(armProviderSchema)
    );
  });
});

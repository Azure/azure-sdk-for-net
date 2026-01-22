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
    const root = createModel(sdkContext);

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
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents/employees"
    );
    strictEqual(metadata.singletonResourceName, undefined);
    strictEqual(metadata.resourceScope, "ResourceGroup");
    strictEqual(
      metadata.parentResourceId,
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
      getMethod.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(getMethod.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      getMethod.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Create method details
    const createEntry = metadata.methods.find((m: any) => m.kind === "Create");
    ok(createEntry);
    strictEqual(
      createEntry.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(createEntry.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      createEntry.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Update method details
    const updateEntry = metadata.methods.find((m: any) => m.kind === "Update");
    ok(updateEntry);
    strictEqual(
      updateEntry.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(updateEntry.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      updateEntry.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Delete method details
    const deleteEntry = metadata.methods.find((m: any) => m.kind === "Delete");
    ok(deleteEntry);
    strictEqual(
      deleteEntry.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(deleteEntry.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      deleteEntry.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate ListByResourceGroup (list by parent)
    const listByRgEntry = metadata.methods.find(
      (m: any) =>
        m.kind === "List" && m.operationPath.includes("employeeParents")
    );
    ok(listByRgEntry);
    strictEqual(listByRgEntry.kind, "List");
    strictEqual(
      listByRgEntry.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees"
    );
    strictEqual(listByRgEntry.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      listByRgEntry.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );

    // Validate ListBySubscription
    const listBySubEntry = metadata.methods.find(
      (m: any) =>
        m.kind === "List" && m.operationScope === ResourceScope.Subscription
    );
    ok(listBySubEntry);
    strictEqual(listBySubEntry.kind, "List");
    strictEqual(
      listBySubEntry.operationPath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees"
    );
    strictEqual(listBySubEntry.operationScope, ResourceScope.Subscription);
    strictEqual(listBySubEntry.resourceScope, undefined);

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
    const root = createModel(sdkContext);
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
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employees/default"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employees"
    );
    strictEqual(metadata.singletonResourceName, "default");
    strictEqual(metadata.resourceScope, "ResourceGroup");
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
      currentMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/currentEmployees/current"
    );
    strictEqual(
      currentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/currentEmployees"
    );
    strictEqual(currentMetadata.singletonResourceName, "current");
    strictEqual(currentMetadata.resourceScope, "ResourceGroup");
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
    const root = createModel(sdkContext);

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
      employeeMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(employeeMetadata.singletonResourceName, undefined);
    strictEqual(employeeMetadata.resourceScope, "ResourceGroup");
    strictEqual(employeeMetadata.methods.length, 5);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      employeeMetadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(
      employeeMetadata.parentResourceId,
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
      departmentMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(departmentMetadata.singletonResourceName, undefined);
    strictEqual(departmentMetadata.resourceScope, "ResourceGroup");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      departmentMetadata.parentResourceId,
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
      companyMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(companyMetadata.singletonResourceName, undefined);
    strictEqual(companyMetadata.resourceScope, "ResourceGroup");
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
    const root = createModel(sdkContext);

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
      employeeMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(employeeMetadata.singletonResourceName, undefined);
    strictEqual(employeeMetadata.resourceScope, "Subscription");
    strictEqual(employeeMetadata.methods.length, 5);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      employeeMetadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(
      employeeMetadata.parentResourceId,
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
      departmentMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(departmentMetadata.singletonResourceName, undefined);
    strictEqual(departmentMetadata.resourceScope, "Subscription");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      departmentMetadata.parentResourceId,
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
      companyMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(companyMetadata.singletonResourceName, undefined);
    strictEqual(companyMetadata.resourceScope, "Subscription");
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
    const root = createModel(sdkContext);
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
      metadata.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(metadata.singletonResourceName, undefined);
    strictEqual(metadata.resourceScope, "Tenant");
    strictEqual(metadata.methods.length, 5);
    // Verify a Read method exists (position may vary due to sorting)
    ok(
      metadata.methods.find((m: any) => m.kind === "Read"),
      "Should have a Read method"
    );
    strictEqual(
      metadata.parentResourceId,
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
      departmentMetadata.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(departmentMetadata.singletonResourceName, undefined);
    strictEqual(departmentMetadata.resourceScope, "Tenant");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      departmentMetadata.parentResourceId,
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
      companyMetadata.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(companyMetadata.singletonResourceName, undefined);
    strictEqual(companyMetadata.resourceScope, "Tenant");
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
    const root = createModel(sdkContext);
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

    // The model should inherit its resourceScope from the Read method's operationScope (Subscription)
    // because the Read method operates at subscription scope and there are no explicit scope decorators
    strictEqual(metadata.resourceScope, "Subscription");

    // Verify the Read method itself has the correct scope
    const getMethodEntry = metadata.methods.find((m: any) => m.kind === "Read");
    ok(getMethodEntry);
    strictEqual(getMethodEntry.kind, "Read");
    strictEqual(getMethodEntry.operationScope, ResourceScope.Subscription);

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

    const root = createModel(sdkContext);
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
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents"
    );
    strictEqual(metadata.resourceScope, "ResourceGroup");
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
    const root = createModel(sdkContext);

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
    strictEqual(metadata.resourceScope, "ManagementGroup");

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
    const root = createModel(sdkContext);

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
      m.operationPath.includes("getAssociatedScheduledActions")
    );
    ok(
      methodEntry,
      "getAssociatedScheduledActions should be in non-resource methods"
    );
    strictEqual(methodEntry.operationScope, ResourceScope.ResourceGroup);

    // Verify getPostgresVersions is also a non-resource method
    const getPostgresVersionsEntry = nonResourceMethods.find((m: any) =>
      m.operationPath.includes("getPostgresVersions")
    );
    ok(
      getPostgresVersionsEntry,
      "getPostgresVersions should be in non-resource methods"
    );
    strictEqual(getPostgresVersionsEntry.operationScope, ResourceScope.ResourceGroup);

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
    const root = createModel(sdkContext);

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
        r.metadata.resourceIdPattern.includes(
          "/bestPractices/{bestPracticeName}"
        ) && !r.metadata.resourceIdPattern.includes("/versions")
    );
    ok(bestPracticesResource, "Should have metadata for parent-level resource");
    const bestPracticesMetadata = bestPracticesResource.metadata;
    strictEqual(
      bestPracticesMetadata.resourceName,
      "BestPractice",
      "Parent resource should be named BestPractice"
    );
    strictEqual(
      bestPracticesMetadata.resourceIdPattern,
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
      r.metadata.resourceIdPattern.includes("/versions/{versionName}")
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
      bestPracticeVersionsMetadata.resourceIdPattern,
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
      bestPracticeVersionsMetadata.parentResourceId,
      bestPracticesMetadata.resourceIdPattern
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
    const root = createModel(sdkContext);

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
        m.kind === "Action" && m.operationPath.includes("noGetResources") && m.operationPath.endsWith("/noGetResources")
    );
    ok(
      noGetListInParent,
      "Parent resource should have the list operation for NoGetResource as Action"
    );

    // Verify the create operation for NoGetResource is in parent's methods as Action
    const noGetCreateInParent = parentResource.metadata.methods.find(
      (m) =>
        m.kind === "Action" && m.operationPath.includes("noGetResources")
    );
    ok(
      noGetCreateInParent,
      "Parent resource should have the create operation for NoGetResource as Action"
    );

    // Verify the delete operation for NoGetResource is in parent's methods as Action
    const noGetDeleteInParent = parentResource.metadata.methods.find(
      (m) =>
        m.kind === "Action" && m.operationPath.includes("noGetResources")
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
      m.operationPath.includes("noGetResources")
    );
    strictEqual(
      noGetMethods.length,
      0,
      "Should have no NoGetResource operations in non-resource methods"
    );
  });

  it("validation step should not affect valid resources and methods", async () => {
    // This test verifies that the validation/pruning step added to resolveArmResources
    // doesn't affect valid resources and methods (i.e., those with valid crossLanguageDefinitionIds)
    const program = await typeSpecCompile(
      `
/** A test resource */
model TestResource is TrackedResource<TestResourceProperties> {
  ...ResourceNameParameter<TestResource>;
}

/** Test resource properties */
model TestResourceProperties {
  /** A test property */
  testProperty?: string;
}

@armResourceOperations
interface TestResources {
  get is ArmResourceRead<TestResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<TestResource>;
  update is ArmCustomPatchSync<TestResource, TestResourceProperties>;
  delete is ArmResourceDeleteWithoutOkAsync<TestResource>;
  listByResourceGroup is ArmResourceListByParent<TestResource>;
}

interface Operations extends Azure.ResourceManager.Operations {}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);

    // Build ARM provider schema using both methods
    const legacySchema = buildArmProviderSchema(sdkContext, root);
    const resolvedSchema = resolveArmResources(program, sdkContext);

    // Verify both schemas produce the same results
    // The validation step should not have pruned anything since all IDs are valid
    ok(resolvedSchema);
    ok(resolvedSchema.resources);
    strictEqual(resolvedSchema.resources.length, 1);
    
    // Verify the resource has all expected methods
    const resource = resolvedSchema.resources[0];
    ok(resource);
    strictEqual(resource.metadata.methods.length, 5); // get, create, update, delete, list
    
    // Verify non-resource methods (should have Operations interface)
    ok(resolvedSchema.nonResourceMethods);
    
    // Compare with legacy schema to ensure validation didn't change behavior
    deepStrictEqual(
      normalizeSchemaForComparison(resolvedSchema),
      normalizeSchemaForComparison(legacySchema)
    );
  });
});

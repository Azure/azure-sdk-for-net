import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { getAllClients, updateClients } from "../src/resource-detection.js";
import { ok, strictEqual } from "assert";
import { resourceMetadata } from "../src/sdk-context-options.js";
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
    updateClients(root, sdkContext);
    const client = getAllClients(root).find((c) => c.name === "Employees1");
    ok(client);
    const client2 = getAllClients(root).find((c) => c.name === "Employees2");
    ok(client2);
    const model = root.models.find((m) => m.name === "Employee");
    ok(model);
    const parentModel = root.models.find((m) => m.name === "EmployeeParent");
    ok(parentModel);
    const getMethod = client.methods.find((m) => m.name === "get");
    ok(getMethod);
    const createOrUpdateMethod = client.methods.find(
      (m) => m.name === "createOrUpdate"
    );
    ok(createOrUpdateMethod);
    const updateMethod = client.methods.find((m) => m.name === "update");
    ok(updateMethod);
    const deleteMethod = client2.methods.find((m) => m.name === "delete");
    ok(deleteMethod);
    const listByResourceGroupMethod = client2.methods.find(
      (m) => m.name === "listByResourceGroup"
    );
    ok(listByResourceGroupMethod);
    const listBySubscriptionMethod = client2.methods.find(
      (m) => m.name === "listBySubscription"
    );
    ok(listBySubscriptionMethod);

    const resourceMetadataDecorator = model.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(resourceMetadataDecorator);
    ok(resourceMetadataDecorator.arguments);
    strictEqual(
      resourceMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(
      resourceMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents/employees"
    );
    strictEqual(
      resourceMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      resourceMetadataDecorator.arguments.resourceScope,
      "ResourceGroup"
    );
    strictEqual(
      resourceMetadataDecorator.arguments.parentResourceId,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );
    strictEqual(resourceMetadataDecorator.arguments.resourceName, "Employee");
    strictEqual(resourceMetadataDecorator.arguments.methods.length, 6);
    strictEqual(
      resourceMetadataDecorator.arguments.methods[0].methodId,
      getMethod.crossLanguageDefinitionId
    );
    strictEqual(resourceMetadataDecorator.arguments.methods[0].kind, "Get");
    strictEqual(resourceMetadataDecorator.arguments.methods[0].operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(resourceMetadataDecorator.arguments.methods[0].operationScope,
      ResourceScope.ResourceGroup
    );
    strictEqual(resourceMetadataDecorator.arguments.methods[0].resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Create
    const createEntry = resourceMetadataDecorator.arguments.methods.find(
      (m: any) => m.methodId === createOrUpdateMethod.crossLanguageDefinitionId
    );
    ok(createEntry);
    strictEqual(createEntry.kind, "Create");
    strictEqual(
      createEntry.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(createEntry.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      createEntry.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Update
    const updateEntry = resourceMetadataDecorator.arguments.methods.find(
      (m: any) => m.methodId === updateMethod.crossLanguageDefinitionId
    );
    ok(updateEntry);
    strictEqual(updateEntry.kind, "Update");
    strictEqual(
      updateEntry.operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(updateEntry.operationScope, ResourceScope.ResourceGroup);
    strictEqual(
      updateEntry.resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Delete
    const deleteEntry = resourceMetadataDecorator.arguments.methods.find(
      (m: any) => m.methodId === deleteMethod.crossLanguageDefinitionId
    );
    ok(deleteEntry);
    strictEqual(deleteEntry.kind, "Delete");
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
    const listByRgEntry = resourceMetadataDecorator.arguments.methods.find(
      (m: any) => m.methodId === listByResourceGroupMethod.crossLanguageDefinitionId
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
    const listBySubEntry = resourceMetadataDecorator.arguments.methods.find(
      (m: any) => m.methodId === listBySubscriptionMethod.crossLanguageDefinitionId
    );
    ok(listBySubEntry);
    strictEqual(listBySubEntry.kind, "List");
    strictEqual(listBySubEntry.operationPath, "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees");
    strictEqual(listBySubEntry.operationScope, ResourceScope.Subscription);
    strictEqual(listBySubEntry.resourceScope, undefined);
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
    updateClients(root, sdkContext);
    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);
    const currentEmployeeClient = getAllClients(root).find(
      (c) => c.name === "CurrentEmployees"
    );
    ok(currentEmployeeClient);
    const employeeModel = root.models.find((m) => m.name === "Employee");
    ok(employeeModel);
    const employeeGetMethod = employeeClient.methods.find(
      (m) => m.name === "get"
    );
    ok(employeeGetMethod);

    const employeeMetadataDecorator = employeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(employeeMetadataDecorator);
    ok(employeeMetadataDecorator.arguments);
    strictEqual(
      employeeMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employees/default"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/employees"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.singletonResourceName,
      "default"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceScope,
      "ResourceGroup"
    );
    strictEqual(employeeMetadataDecorator.arguments.methods.length, 3);
    strictEqual(
      employeeMetadataDecorator.arguments.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(employeeMetadataDecorator.arguments.methods[0].kind, "Get");
    strictEqual(employeeMetadataDecorator.arguments.resourceName, "Employee");

    const currentEmployeeModel = root.models.find(
      (m) => m.name === "CurrentEmployee"
    );
    ok(currentEmployeeModel);
    const currentMetdataDecorator = currentEmployeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(currentMetdataDecorator);
    ok(currentMetdataDecorator.arguments);
    strictEqual(
      currentMetdataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/currentEmployees/current"
    );
    strictEqual(
      currentMetdataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/currentEmployees"
    );
    strictEqual(
      currentMetdataDecorator.arguments.singletonResourceName,
      "current"
    );
    strictEqual(
      currentMetdataDecorator.arguments.resourceScope,
      "ResourceGroup"
    );
    strictEqual(currentMetdataDecorator.arguments.methods.length, 3);
    strictEqual(
      currentMetdataDecorator.arguments.resourceName,
      "CurrentEmployee"
    );
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
    updateClients(root, sdkContext);
    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);
    const employeeModel = root.models.find((m) => m.name === "Employee");
    ok(employeeModel);
    const departmentModel = root.models.find((m) => m.name === "Department");
    ok(departmentModel);
    const companyModel = root.models.find((m) => m.name === "Company");
    ok(companyModel);
    const employeeGetMethod = employeeClient.methods.find(
      (m) => m.name === "get"
    );
    ok(employeeGetMethod);

    const employeeMetadataDecorator = employeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(employeeMetadataDecorator);
    ok(employeeMetadataDecorator.arguments);
    strictEqual(
      employeeMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceScope,
      "ResourceGroup"
    );
    strictEqual(employeeMetadataDecorator.arguments.methods.length, 5);
    strictEqual(
      employeeMetadataDecorator.arguments.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(employeeMetadataDecorator.arguments.methods[0].kind, "Get");

    const departmentMetadataDecorator = departmentModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(departmentMetadataDecorator);
    ok(departmentMetadataDecorator.arguments);
    strictEqual(
      departmentMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceScope,
      "ResourceGroup"
    );
    strictEqual(departmentMetadataDecorator.arguments.methods.length, 2);
    strictEqual(
      departmentMetadataDecorator.arguments.parentResourceId,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceName,
      "Department"
    );

    const companyMetadataDecorator = companyModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(companyMetadataDecorator);
    ok(companyMetadataDecorator.arguments);
    strictEqual(
      companyMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(
      companyMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      companyMetadataDecorator.arguments.resourceScope,
      "ResourceGroup"
    );
    strictEqual(companyMetadataDecorator.arguments.methods.length, 2);
    strictEqual(companyMetadataDecorator.arguments.parentResourceId, undefined);
    strictEqual(companyMetadataDecorator.arguments.resourceName, "Company");

    strictEqual(
      employeeMetadataDecorator.arguments.parentResourceId,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(employeeMetadataDecorator.arguments.resourceName, "Employee");
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
    updateClients(root, sdkContext);
    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);
    const employeeModel = root.models.find((m) => m.name === "Employee");
    ok(employeeModel);
    const departmentModel = root.models.find((m) => m.name === "Department");
    ok(departmentModel);
    const companyModel = root.models.find((m) => m.name === "Company");
    ok(companyModel);
    const employeeGetMethod = employeeClient.methods.find(
      (m) => m.name === "get"
    );
    ok(employeeGetMethod);

    const employeeMetadataDecorator = employeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(employeeMetadataDecorator);
    ok(employeeMetadataDecorator.arguments);
    strictEqual(
      employeeMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceScope,
      "Subscription"
    );
    strictEqual(employeeMetadataDecorator.arguments.methods.length, 5);
    strictEqual(
      employeeMetadataDecorator.arguments.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(employeeMetadataDecorator.arguments.methods[0].kind, "Get");

    const departmentMetadataDecorator = departmentModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(departmentMetadataDecorator);
    ok(departmentMetadataDecorator.arguments);
    strictEqual(
      departmentMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceScope,
      "Subscription"
    );
    strictEqual(departmentMetadataDecorator.arguments.methods.length, 2);
    strictEqual(
      departmentMetadataDecorator.arguments.parentResourceId,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceName,
      "Department"
    );

    const companyMetadataDecorator = companyModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(companyMetadataDecorator);
    ok(companyMetadataDecorator.arguments);
    strictEqual(
      companyMetadataDecorator.arguments.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(
      companyMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(
      companyMetadataDecorator.arguments.resourceScope,
      "Subscription"
    );
    strictEqual(companyMetadataDecorator.arguments.methods.length, 2);
    strictEqual(companyMetadataDecorator.arguments.parentResourceId, undefined);
    strictEqual(companyMetadataDecorator.arguments.resourceName, "Company");

    strictEqual(
      employeeMetadataDecorator.arguments.parentResourceId,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(employeeMetadataDecorator.arguments.resourceName, "Employee");
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
    updateClients(root, sdkContext);
    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);
    const employeeModel = root.models.find((m) => m.name === "Employee");
    ok(employeeModel);
    const departmentModel = root.models.find((m) => m.name === "Department");
    ok(departmentModel);
    const companyModel = root.models.find((m) => m.name === "Company");
    ok(companyModel);
    const employeeGetMethod = employeeClient.methods.find(
      (m) => m.name === "get"
    );
    ok(employeeGetMethod);

    const employeeMetadataDecorator = employeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(employeeMetadataDecorator);
    ok(employeeMetadataDecorator.arguments);
    strictEqual(
      employeeMetadataDecorator.arguments.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(
      employeeMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(employeeMetadataDecorator.arguments.resourceScope, "Tenant");
    strictEqual(employeeMetadataDecorator.arguments.methods.length, 5);
    strictEqual(
      employeeMetadataDecorator.arguments.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(employeeMetadataDecorator.arguments.methods[0].kind, "Get");

    const departmentMetadataDecorator = departmentModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(departmentMetadataDecorator);
    ok(departmentMetadataDecorator.arguments);
    strictEqual(
      departmentMetadataDecorator.arguments.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(departmentMetadataDecorator.arguments.resourceScope, "Tenant");
    strictEqual(departmentMetadataDecorator.arguments.methods.length, 2);
    strictEqual(
      departmentMetadataDecorator.arguments.parentResourceId,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      departmentMetadataDecorator.arguments.resourceName,
      "Department"
    );

    const companyMetadataDecorator = companyModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(companyMetadataDecorator);
    ok(companyMetadataDecorator.arguments);
    strictEqual(
      companyMetadataDecorator.arguments.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      companyMetadataDecorator.arguments.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(
      companyMetadataDecorator.arguments.singletonResourceName,
      undefined
    );
    strictEqual(companyMetadataDecorator.arguments.resourceScope, "Tenant");
    strictEqual(companyMetadataDecorator.arguments.methods.length, 2);
    strictEqual(companyMetadataDecorator.arguments.parentResourceId, undefined);
    strictEqual(companyMetadataDecorator.arguments.resourceName, "Company");

    strictEqual(
      employeeMetadataDecorator.arguments.parentResourceId,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(employeeMetadataDecorator.arguments.resourceName, "Employee");
  });
});

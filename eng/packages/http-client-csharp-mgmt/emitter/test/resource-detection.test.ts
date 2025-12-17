import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { getAllClients, buildArmProviderSchema } from "../src/resource-detection.js";
import { ok, strictEqual } from "assert";
import {
  tenantResource,
  subscriptionResource,
  resourceGroupResource
} from "../src/sdk-context-options.js";
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
    
    // Find the Employee resource
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

    // Find the Employee resource in the schema
    const employeeResource = armProviderSchema.resources.find(
      (r) => r.resourceModelId === model.crossLanguageDefinitionId
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
    
    // Validate Get method
    strictEqual(
      metadata.methods[0].methodId,
      getMethod.crossLanguageDefinitionId
    );
    strictEqual(metadata.methods[0].kind, "Get");
    strictEqual(
      metadata.methods[0].operationPath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.methods[0].operationScope,
      ResourceScope.ResourceGroup
    );
    strictEqual(
      metadata.methods[0].resourceScope,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}"
    );

    // Validate Create
    const createEntry = metadata.methods.find(
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
    const updateEntry = metadata.methods.find(
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
    const deleteEntry = metadata.methods.find(
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
    const listByRgEntry = metadata.methods.find(
      (m: any) =>
        m.methodId === listByResourceGroupMethod.crossLanguageDefinitionId
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
        m.methodId === listBySubscriptionMethod.crossLanguageDefinitionId
    );
    ok(listBySubEntry);
    strictEqual(listBySubEntry.kind, "List");
    strictEqual(
      listBySubEntry.operationPath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees"
    );
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
    // Build ARM provider schema and verify its structure

    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult);

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

    // Find the resource in the schema

    const employeeResource = armProviderSchemaResult.resources.find(

      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId

    );

    ok(employeeResource);

    const employeeMetadataDecorator = employeeResource;

    ok(employeeMetadataDecorator);

    const metadata = employeeMetadataDecorator.metadata;
    ok(employeeMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employees/default"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employees"
    );
    strictEqual(
      metadata.singletonResourceName,
      "default"
    );
    strictEqual(
      metadata.resourceScope,
      "ResourceGroup"
    );
    strictEqual(metadata.methods.length, 3);
    strictEqual(
      metadata.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(metadata.methods[0].kind, "Get");
    strictEqual(metadata.resourceName, "Employee");

    const currentEmployeeModel = root.models.find(
      (m) => m.name === "CurrentEmployee"
    );
    ok(currentEmployeeModel);
    // Find the resource in the schema
    const currentEmployeeResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === currentEmployeeModel.crossLanguageDefinitionId
    );
    const currentMetdataDecorator = currentEmployeeResourceInSchema;
    ok(currentMetdataDecorator);
    const currentMetadata = currentMetdataDecorator.metadata;
    ok(currentMetadata);
    strictEqual(
      currentMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/currentEmployees/current"
    );
    strictEqual(
      currentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/currentEmployees"
    );
    strictEqual(
      currentMetadata.singletonResourceName,
      "current"
    );
    strictEqual(
      currentMetadata.resourceScope,
      "ResourceGroup"
    );
    strictEqual(currentMetadata.methods.length, 3);
    strictEqual(
      currentMetadata.resourceName,
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
    // Build ARM provider schema and verify its structure

    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult);

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

    // Find the resource in the schema

    const employeeResource = armProviderSchemaResult.resources.find(

      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId

    );

    ok(employeeResource);

    const employeeMetadataDecorator = employeeResource;

    ok(employeeMetadataDecorator);

    const metadata = employeeMetadataDecorator.metadata;
    ok(employeeMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(
      metadata.resourceScope,
      "ResourceGroup"
    );
    strictEqual(metadata.methods.length, 5);
    strictEqual(
      metadata.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(metadata.methods[0].kind, "Get");

    // Find the resource in the schema
    const departmentResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === departmentModel.crossLanguageDefinitionId
    );
    const departmentMetadataDecorator = departmentResourceInSchema;
    ok(departmentMetadataDecorator);
    const departmentMetadata = departmentMetadataDecorator.metadata;
    ok(departmentMetadata);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(
      metadata.resourceScope,
      "ResourceGroup"
    );
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      metadata.parentResourceId,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      metadata.resourceName,
      "Department"
    );

    // Find the resource in the schema
    const companyResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === companyModel.crossLanguageDefinitionId
    );
    const companyMetadataDecorator = companyResourceInSchema;
    ok(companyMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(
      metadata.resourceScope,
      "ResourceGroup"
    );
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(departmentMetadata.parentResourceId, undefined);
    strictEqual(departmentMetadata.resourceName, "Company");

    strictEqual(
      metadata.parentResourceId,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(departmentMetadata.resourceName, "Employee");
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

    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);

    ok(armProviderSchemaResult);

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

    // Find the resource in the schema

    const employeeResource = armProviderSchemaResult.resources.find(

      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId

    );

    ok(employeeResource);

    const employeeMetadataDecorator = employeeResource;

    ok(employeeMetadataDecorator);

    const metadata = employeeMetadataDecorator.metadata;
    ok(employeeMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(
      metadata.resourceScope,
      "Subscription"
    );
    strictEqual(metadata.methods.length, 5);
    strictEqual(
      metadata.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(metadata.methods[0].kind, "Get");

    // Find the resource in the schema
    const departmentResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === departmentModel.crossLanguageDefinitionId
    );
    const departmentMetadataDecorator = departmentResourceInSchema;
    ok(departmentMetadataDecorator);
    const departmentMetadata = departmentMetadataDecorator.metadata;
    ok(departmentMetadata);
    
    strictEqual(
      departmentMetadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(
      departmentMetadata.singletonResourceName,
      undefined
    );
    strictEqual(
      metadata.resourceScope,
      "Subscription"
    );
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      metadata.parentResourceId,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      metadata.resourceName,
      "Department"
    );

    // Find the resource in the schema
    const companyResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === companyModel.crossLanguageDefinitionId
    );
    const companyMetadataDecorator = companyResourceInSchema;
    ok(companyMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(
      metadata.resourceScope,
      "Subscription"
    );
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(departmentMetadata.parentResourceId, undefined);
    strictEqual(departmentMetadata.resourceName, "Company");

    strictEqual(
      metadata.parentResourceId,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(departmentMetadata.resourceName, "Employee");
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

    // Find the resource in the schema

    const employeeResource = armProviderSchemaResult.resources.find(

      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId

    );

    ok(employeeResource);

    const employeeMetadataDecorator = employeeResource;

    ok(employeeMetadataDecorator);

    const metadata = employeeMetadataDecorator.metadata;
    ok(employeeMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments/employees"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(metadata.resourceScope, "Tenant");
    strictEqual(metadata.methods.length, 5);
    strictEqual(
      metadata.methods[0].methodId,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(metadata.methods[0].kind, "Get");

    // Find the resource in the schema
    const departmentResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === departmentModel.crossLanguageDefinitionId
    );
    const departmentMetadataDecorator = departmentResourceInSchema;
    ok(departmentMetadataDecorator);
    const departmentMetadata = departmentMetadataDecorator.metadata;
    ok(departmentMetadata);
    
    strictEqual(
      departmentMetadata.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(
      departmentMetadata.resourceType,
      "Microsoft.ContosoProviderHub/companies/departments"
    );
    strictEqual(
      departmentMetadata.singletonResourceName,
      undefined
    );
    strictEqual(departmentMetadata.resourceScope, "Tenant");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(
      metadata.parentResourceId,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      metadata.resourceName,
      "Department"
    );

    // Find the resource in the schema
    const companyResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === companyModel.crossLanguageDefinitionId
    );
    const companyMetadataDecorator = companyResourceInSchema;
    ok(companyMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/companies"
    );
    strictEqual(
      metadata.singletonResourceName,
      undefined
    );
    strictEqual(departmentMetadata.resourceScope, "Tenant");
    strictEqual(departmentMetadata.methods.length, 2);
    strictEqual(departmentMetadata.parentResourceId, undefined);
    strictEqual(departmentMetadata.resourceName, "Company");

    strictEqual(
      metadata.parentResourceId,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}"
    );
    strictEqual(departmentMetadata.resourceName, "Employee");
  });

  it("resource scope determined from Get method when no explicit decorator", async () => {
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


    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);
    const employeeModel = root.models.find((m) => m.name === "Employee");


    ok(employeeModel);
    const getMethod = employeeClient.methods.find((m) => m.name === "get");
    ok(getMethod);

    // Find the resource in the schema


    const employeeResource = armProviderSchemaResult.resources.find(


      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId


    );


    ok(employeeResource);


    const resourceMetadataDecorator = employeeResource;


    ok(resourceMetadataDecorator);


    const metadata = resourceMetadataDecorator.metadata;
    ok(resourceMetadataDecorator);
    

    // Verify that the model has NO scope-related decorators
    const hasNoScopeDecorators = !employeeModel.decorators?.some(
      (d) =>
        d.name === tenantResource ||
        d.name === subscriptionResource ||
        d.name === resourceGroupResource
    );
    ok(
      hasNoScopeDecorators,
      "Model should have no scope-related decorators to test fallback logic"
    );

    // The model should inherit its resourceScope from the Get method's operationScope (Subscription)
    // because the Get method operates at subscription scope and there are no explicit scope decorators
    strictEqual(
      metadata.resourceScope,
      "Subscription"
    );

    // Verify the Get method itself has the correct scope
    const getMethodEntry = metadata.methods.find(
      (m: any) => m.methodId === getMethod.crossLanguageDefinitionId
    );
    ok(getMethodEntry);
    strictEqual(getMethodEntry.kind, "Get");
    strictEqual(getMethodEntry.operationScope, ResourceScope.Subscription);
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


    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);


    ok(armProviderSchemaResult);


    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);
    const employeeParentClient = getAllClients(root).find(
      (c) => c.name === "EmployeeParents"
    );
    ok(employeeParentClient);

    const employeeModel = root.models.find((m) => m.name === "Employee");


    ok(employeeModel);
    const employeeParentModel = root.models.find(
      (m) => m.name === "EmployeeParent"
    );
    ok(employeeParentModel);

    const listByParentMethod = employeeClient.methods.find(
      (m) => m.name === "listByParent"
    );
    ok(listByParentMethod);
    const getMethod = employeeParentClient.methods.find(
      (m) => m.name === "get"
    );
    ok(getMethod);

    // Validate Employee resource metadata should be null (no CRUD operations)
    // Find the resource in the schema


    const employeeResource = armProviderSchemaResult.resources.find(


      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId


    );


    ok(employeeResource);


    const employeeResourceMetadataDecorator = employeeResource;


    ok(employeeResourceMetadataDecorator);


    const metadata = employeeResourceMetadataDecorator.metadata;
    strictEqual(
      employeeResourceMetadataDecorator,
      undefined,
      "Employee should not have resource metadata decorator without CRUD operations"
    );

    // Validate EmployeeParent resource metadata
    const parentResourceMetadataDecorator =
      employeeParentModel.decorators?.find((d) => d.name === resourceMetadata);
    ok(parentResourceMetadataDecorator);
    
    strictEqual(
      metadata.resourceIdPattern,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}"
    );
    strictEqual(
      metadata.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents"
    );
    strictEqual(
      metadata.resourceScope,
      "ResourceGroup"
    );
    strictEqual(
      metadata.parentResourceId,
      undefined
    );
    strictEqual(
      metadata.resourceName,
      "EmployeeParent"
    );
    strictEqual(metadata.methods.length, 2);

    // Validate EmployeeParent listByParent method
    const listByParentEntry =
      metadata.methods.find(
        (m: any) => m.methodId === listByParentMethod.crossLanguageDefinitionId
      );
    ok(listByParentEntry);
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

    const employeeClient = getAllClients(root).find(
      (c) => c.name === "Employees"
    );
    ok(employeeClient);

    const employeeModel = root.models.find((m) => m.name === "Employee");
    ok(employeeModel);

    // Validate Employee resource metadata should be null (no CRUD operations)
    // Find the resource in the schema
    const employeeResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === employeeModel.crossLanguageDefinitionId
    );
    const employeeResourceMetadataDecorator = employeeResourceInSchema;
    ok(employeeResourceMetadataDecorator);
    const metadata = employeeResourceMetadataDecorator.metadata;
    ok(metadata);
    strictEqual(
      metadata.resourceScope,
      "ManagementGroup"
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

    const scheduledActionExtensionClient = getAllClients(root).find(
      (c) => c.name === "ScheduledActionExtension"
    );
    ok(scheduledActionExtensionClient, "ScheduledActionExtension client should exist");

    const scheduledActionModel = root.models.find((m) => m.name === "ScheduledAction");
    ok(scheduledActionModel, "ScheduledAction model should exist");

    const getAssociatedMethod = scheduledActionExtensionClient.methods.find(
      (m) => m.name === "getAssociatedScheduledActions"
    );
    ok(getAssociatedMethod, "getAssociatedScheduledActions method should exist");

    // Check if resource metadata exists for ScheduledAction
    // Find the resource in the schema
    const scheduledActionResourceInSchema = armProviderSchemaResult.resources.find(
      (r) => r.resourceModelId === scheduledActionModel.crossLanguageDefinitionId
    );
    const resourceMetadataDecorator = scheduledActionResourceInSchema;
    
    // The resource should NOT have metadata since it has no CRUD operations
    strictEqual(
      resourceMetadataDecorator,
      undefined,
      "ScheduledAction should not have resource metadata decorator without CRUD operations"
    );
    
    // Check that the method is treated as a non-resource method
    ok(armProviderSchemaResult.nonResourceMethods, "Should have non-resource methods");
    
    const nonResourceMethods = armProviderSchemaResult.nonResourceMethods;
    const methodEntry = nonResourceMethods.find(
      (m: any) => m.methodId === getAssociatedMethod.crossLanguageDefinitionId
    );
    ok(methodEntry, "getAssociatedScheduledActions should be in non-resource methods");
    strictEqual(methodEntry.operationScope, ResourceScope.ResourceGroup);
  });
});

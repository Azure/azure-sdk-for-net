// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * This test file verifies if the resolveArmResources API from
 * @azure-tools/typespec-azure-resource-manager can provide the same information
 * that is currently extracted using the decorator-based resource detection logic
 * in resource-detection.ts.
 *
 * Each test case corresponds to a case in resource-detection.test.ts and verifies
 * whether resolveArmResources API can return the expected resource information.
 *
 * KNOWN BUGS IN resolveArmResources API (as of @azure-tools/typespec-azure-resource-manager v0.62.0):
 *
 * 1. Multiple singleton resources with different @singleton keys are not properly distinguished.
 *    When both Employee and CurrentEmployee are defined with different singleton keys,
 *    the API returns all resources pointing to the same Employee type only.
 *    See: "singleton resource - demonstrates bug with multiple singletons" test case
 *    See also: resolve-arm-resources-bug.test.ts for dedicated tests
 *
 * 2. Singleton child resources return incorrect resourceInstancePath.
 *    For @singleton("current") @parentResource(Bar) BarSettings,
 *    the API returns the parent path /bars/{barName} instead of /bars/{barName}/settings/current.
 *    Existing TypeSpec: generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp (BarSettingsResource)
 *    See: "singleton child resource - demonstrates path bug" test case below
 *
 * 3. Duplicate resources are returned for the same model.
 *    The API can return 2-4 resolved resources for the same TypeSpec model.
 *    Existing TypeSpec: generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp (BarSettingsResource)
 *    See: "singleton child resource - demonstrates duplicate resources bug" test case below
 *
 * 4. Parent information is often undefined even when @parentResource is specified.
 *    Existing TypeSpec: generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp (BarSettingsResource)
 *    See: "singleton child resource - demonstrates parent undefined bug" test case below
 *
 * 5. Resource type for child resources uses the parent's type instead of the full type path.
 *    Existing TypeSpec: generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp (BarSettingsResource)
 *    See: "singleton child resource - demonstrates resource type bug" test case below
 *
 * These bugs prevent using resolveArmResources as a direct replacement for the
 * decorator-based resource detection logic in resource-detection.ts.
 * Once these bugs are fixed in the TypeSpec ARM library, the replacement can be completed.
 */

import { beforeEach, describe, it } from "vitest";
import { createEmitterTestHost, typeSpecCompile } from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import {
  resolveArmResources,
  getSingletonResourceKey,
  ResolvedResource
} from "@azure-tools/typespec-azure-resource-manager";
import { strictEqual, ok } from "assert";

describe("resolveArmResources API Validation", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  /**
   * Helper to get resource type string from ResourceType object
   */
  function getResourceTypeString(resource: ResolvedResource): string {
    return `${resource.resourceType.provider}/${resource.resourceType.types.join("/")}`;
  }

  /**
   * Helper to determine resource scope from path
   */
  function getResourceScope(
    resource: ResolvedResource
  ): "ResourceGroup" | "Subscription" | "Tenant" | "ManagementGroup" | "Extension" {
    const path = resource.resourceInstancePath;
    if (path.startsWith("/{resourceUri}") || path.startsWith("/{scope}")) {
      return "Extension";
    } else if (
      path.startsWith(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/"
      )
    ) {
      return "ResourceGroup";
    } else if (path.startsWith("/subscriptions/{subscriptionId}/")) {
      return "Subscription";
    } else if (
      path.startsWith(
        "/providers/Microsoft.Management/managementGroups/{managementGroupId}/"
      )
    ) {
      return "ManagementGroup";
    }
    return "Tenant";
  }

  it("resource group resource - basic validation", async () => {
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find Employee and EmployeeParent resources
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );
    const employeeParentResource = resolvedResources.find(
      (r) => r.type.name === "EmployeeParent"
    );

    ok(employeeResource, "Should find Employee resource");
    ok(employeeParentResource, "Should find EmployeeParent resource");

    // Verify Employee resource properties
    strictEqual(
      employeeResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}/employees/{employeeName}",
      "Employee resourceInstancePath should match"
    );
    strictEqual(
      getResourceTypeString(employeeResource),
      "Microsoft.ContosoProviderHub/employeeParents/employees",
      "Employee resource type should match"
    );
    strictEqual(
      getResourceScope(employeeResource),
      "ResourceGroup",
      "Employee should be ResourceGroup scoped"
    );

    // Verify parent relationship
    ok(employeeResource.parent, "Employee should have a parent");
    strictEqual(
      employeeResource.parent.type.name,
      "EmployeeParent",
      "Employee's parent should be EmployeeParent"
    );
    strictEqual(
      employeeResource.parent.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}",
      "Parent resourceInstancePath should match"
    );

    // Verify EmployeeParent resource properties
    strictEqual(
      employeeParentResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employeeParents/{employeeParentName}",
      "EmployeeParent resourceInstancePath should match"
    );
    strictEqual(
      getResourceTypeString(employeeParentResource),
      "Microsoft.ContosoProviderHub/employeeParents",
      "EmployeeParent resource type should match"
    );

    // Verify operations are present (lifecycle operations are arrays)
    ok(
      employeeResource.operations.lifecycle.read &&
        employeeResource.operations.lifecycle.read.length > 0,
      "Employee should have read operation"
    );
    ok(
      employeeResource.operations.lifecycle.createOrUpdate &&
        employeeResource.operations.lifecycle.createOrUpdate.length > 0,
      "Employee should have createOrUpdate operation"
    );
    ok(
      employeeResource.operations.lifecycle.update &&
        employeeResource.operations.lifecycle.update.length > 0,
      "Employee should have update operation"
    );
    ok(
      employeeResource.operations.lifecycle.delete &&
        employeeResource.operations.lifecycle.delete.length > 0,
      "Employee should have delete operation"
    );
    ok(
      employeeResource.operations.lists.length > 0,
      "Employee should have list operations"
    );
  });

  /**
   * This test validates the KNOWN BUG in resolveArmResources API with multiple singletons.
   *
   * BUG DESCRIPTION:
   * When multiple singleton resources are defined with different @singleton keys
   * (e.g., Employee with default key and CurrentEmployee with "current" key),
   * the resolveArmResources API does not properly distinguish between them.
   * All resolved resources point to the same model type (Employee) instead of
   * their respective types.
   *
   * This test intentionally asserts the CURRENT BUGGY BEHAVIOR to document it.
   * Once the bug is fixed in @azure-tools/typespec-azure-resource-manager,
   * these assertions should be updated to verify correct behavior.
   */
  it("singleton resource - demonstrates bug with multiple singletons", async () => {
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Get unique resource types
    const resourceTypeNames = resolvedResources.map((r) => r.type.name);
    const uniqueTypes = new Set(resourceTypeNames);

    // KNOWN BUG: resolveArmResources does not properly distinguish multiple singletons
    // Expected behavior (when bug is fixed): Should return both "Employee" and "CurrentEmployee"
    // Current buggy behavior: Returns only "Employee" for all resources
    //
    // When the bug is fixed, update these assertions to:
    //   strictEqual(uniqueTypes.size, 2, "Should have 2 unique resource types");
    //   ok(resourceTypeNames.includes("CurrentEmployee"), "Should include CurrentEmployee");
    strictEqual(
      uniqueTypes.size,
      1,
      "KNOWN BUG: Only 1 unique resource type returned instead of 2"
    );
    ok(
      !resourceTypeNames.includes("CurrentEmployee"),
      "KNOWN BUG: CurrentEmployee is NOT returned by resolveArmResources"
    );

    // Find Employee resource and verify singleton key can be obtained via getSingletonResourceKey
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );
    ok(employeeResource, "Should find Employee resource");

    // getSingletonResourceKey works correctly when called directly on the model
    const employeeSingletonKey = getSingletonResourceKey(
      program,
      employeeResource.type
    );
    strictEqual(
      employeeSingletonKey,
      "default",
      "Employee singleton key should be 'default'"
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find resources
    const companyResource = resolvedResources.find(
      (r) => r.type.name === "Company"
    );
    const departmentResource = resolvedResources.find(
      (r) => r.type.name === "Department"
    );
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );

    ok(companyResource, "Should find Company resource");
    ok(departmentResource, "Should find Department resource");
    ok(employeeResource, "Should find Employee resource");

    // Verify Employee resource
    strictEqual(
      employeeResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}",
      "Employee resourceInstancePath should match"
    );
    strictEqual(
      getResourceTypeString(employeeResource),
      "Microsoft.ContosoProviderHub/companies/departments/employees",
      "Employee resource type should match"
    );
    strictEqual(
      getResourceScope(employeeResource),
      "ResourceGroup",
      "Employee should be ResourceGroup scoped"
    );

    // Verify parent chain
    ok(employeeResource.parent, "Employee should have a parent");
    strictEqual(
      employeeResource.parent.type.name,
      "Department",
      "Employee's parent should be Department"
    );
    ok(employeeResource.parent.parent, "Department should have a parent");
    strictEqual(
      employeeResource.parent.parent.type.name,
      "Company",
      "Department's parent should be Company"
    );

    // Verify Department resource
    strictEqual(
      departmentResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}",
      "Department resourceInstancePath should match"
    );
    strictEqual(
      getResourceTypeString(departmentResource),
      "Microsoft.ContosoProviderHub/companies/departments",
      "Department resource type should match"
    );

    // Verify Company resource
    strictEqual(
      companyResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/companies/{companyName}",
      "Company resourceInstancePath should match"
    );
    strictEqual(
      getResourceTypeString(companyResource),
      "Microsoft.ContosoProviderHub/companies",
      "Company resource type should match"
    );
    strictEqual(companyResource.parent, undefined, "Company should have no parent");
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find resources
    const companyResource = resolvedResources.find(
      (r) => r.type.name === "Company"
    );
    const departmentResource = resolvedResources.find(
      (r) => r.type.name === "Department"
    );
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );

    ok(companyResource, "Should find Company resource");
    ok(departmentResource, "Should find Department resource");
    ok(employeeResource, "Should find Employee resource");

    // Verify Employee resource
    strictEqual(
      employeeResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}",
      "Employee resourceInstancePath should match"
    );
    strictEqual(
      getResourceScope(employeeResource),
      "Subscription",
      "Employee should be Subscription scoped"
    );

    // Verify Department resource
    strictEqual(
      departmentResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}",
      "Department resourceInstancePath should match"
    );
    strictEqual(
      getResourceScope(departmentResource),
      "Subscription",
      "Department should be Subscription scoped"
    );

    // Verify Company resource
    strictEqual(
      companyResource.resourceInstancePath,
      "/subscriptions/{subscriptionId}/providers/Microsoft.ContosoProviderHub/companies/{companyName}",
      "Company resourceInstancePath should match"
    );
    strictEqual(
      getResourceScope(companyResource),
      "Subscription",
      "Company should be Subscription scoped"
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find resources
    const companyResource = resolvedResources.find(
      (r) => r.type.name === "Company"
    );
    const departmentResource = resolvedResources.find(
      (r) => r.type.name === "Department"
    );
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );

    ok(companyResource, "Should find Company resource");
    ok(departmentResource, "Should find Department resource");
    ok(employeeResource, "Should find Employee resource");

    // Verify Employee resource
    strictEqual(
      employeeResource.resourceInstancePath,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}/employees/{employeeName}",
      "Employee resourceInstancePath should match"
    );
    strictEqual(
      getResourceScope(employeeResource),
      "Tenant",
      "Employee should be Tenant scoped"
    );

    // Verify Department resource
    strictEqual(
      departmentResource.resourceInstancePath,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}/departments/{departmentName}",
      "Department resourceInstancePath should match"
    );
    strictEqual(
      getResourceScope(departmentResource),
      "Tenant",
      "Department should be Tenant scoped"
    );

    // Verify Company resource
    strictEqual(
      companyResource.resourceInstancePath,
      "/providers/Microsoft.ContosoProviderHub/companies/{companyName}",
      "Company resourceInstancePath should match"
    );
    strictEqual(
      getResourceScope(companyResource),
      "Tenant",
      "Company should be Tenant scoped"
    );
  });

  it("resource scope determined from Get method (SubscriptionLocationResource parent)", async () => {
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find Employee resource
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );
    ok(employeeResource, "Should find Employee resource");

    // Verify scope is Subscription based on path
    strictEqual(
      getResourceScope(employeeResource),
      "Subscription",
      "Employee should be Subscription scoped based on path"
    );

    // Verify operations (lifecycle operations are arrays)
    ok(
      employeeResource.operations.lifecycle.read &&
        employeeResource.operations.lifecycle.read.length > 0,
      "Employee should have read operation"
    );
  });

  it("parent-child resource with list operation only", async () => {
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find resources
    const employeeParentResource = resolvedResources.find(
      (r) => r.type.name === "EmployeeParent"
    );
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );

    ok(employeeParentResource, "Should find EmployeeParent resource");
    ok(employeeResource, "Should find Employee resource");

    // Employee has only list operation, no CRUD (arrays will be undefined or empty)
    ok(
      !employeeResource.operations.lifecycle.read ||
        employeeResource.operations.lifecycle.read.length === 0,
      "Employee should NOT have read operation"
    );
    ok(
      !employeeResource.operations.lifecycle.createOrUpdate ||
        employeeResource.operations.lifecycle.createOrUpdate.length === 0,
      "Employee should NOT have createOrUpdate operation"
    );
    ok(
      !employeeResource.operations.lifecycle.delete ||
        employeeResource.operations.lifecycle.delete.length === 0,
      "Employee should NOT have delete operation"
    );
    ok(
      employeeResource.operations.lists.length > 0,
      "Employee should have list operations"
    );

    // EmployeeParent has read operation
    ok(
      employeeParentResource.operations.lifecycle.read &&
        employeeParentResource.operations.lifecycle.read.length > 0,
      "EmployeeParent should have read operation"
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

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Find Employee resource
    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );
    ok(employeeResource, "Should find Employee resource");

    // Verify ManagementGroup scope from path
    strictEqual(
      getResourceScope(employeeResource),
      "ManagementGroup",
      "Employee should be ManagementGroup scoped"
    );
  });

  it("API returns operation details for lifecycle operations", async () => {
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
  delete is ArmResourceDeleteWithoutOkAsync<Employee>;
  listByResourceGroup is ArmResourceListByParent<Employee>;
}
`,
      runner
    );

    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    const employeeResource = resolvedResources.find(
      (r) => r.type.name === "Employee"
    );
    ok(employeeResource, "Should find Employee resource");

    // Verify all lifecycle operations are present (they are arrays)
    ok(
      employeeResource.operations.lifecycle.read &&
        employeeResource.operations.lifecycle.read.length > 0,
      "Should have read operation"
    );
    ok(
      employeeResource.operations.lifecycle.createOrUpdate &&
        employeeResource.operations.lifecycle.createOrUpdate.length > 0,
      "Should have createOrUpdate operation"
    );
    ok(
      employeeResource.operations.lifecycle.update &&
        employeeResource.operations.lifecycle.update.length > 0,
      "Should have update operation"
    );
    ok(
      employeeResource.operations.lifecycle.delete &&
        employeeResource.operations.lifecycle.delete.length > 0,
      "Should have delete operation"
    );

    // Verify list operations
    ok(
      employeeResource.operations.lists.length > 0,
      "Should have list operations"
    );

    // Verify operation path information (lifecycle operations are arrays)
    const readOps = employeeResource.operations.lifecycle.read;
    ok(readOps && readOps.length > 0, "Read operations should exist");
    strictEqual(
      readOps[0].path,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/employees/{employeeName}",
      "Read operation path should match"
    );
  });

  /**
   * TypeSpec for testing singleton child resource bugs.
   * This matches the structure in generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp
   * where BarSettingsResource is a @singleton("current") @parentResource(Bar) resource.
   */
  const singletonChildResourceSchema = `
/** A parent resource */
model Bar is TrackedResource<BarProperties> {
  ...ResourceNameParameter<Bar>;
}

model BarProperties {
  name?: string;
}

/** A singleton child resource with "current" key - similar to BarSettingsResource in bar.tsp */
@singleton("current")
@parentResource(Bar)
model BarSettings is ProxyResource<BarSettingsProperties> {
  ...ResourceNameParameter<BarSettings, SegmentName = "settings">;
}

model BarSettingsProperties {
  enabled?: boolean;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Bars {
  get is ArmResourceRead<Bar>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Bar>;
}

@armResourceOperations
interface BarSettingsOps {
  get is ArmResourceRead<BarSettings>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<BarSettings>;
}
`;

  /**
   * BUG 2: Singleton child resources return incorrect resourceInstancePath.
   *
   * Expected: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/bars/{barName}/settings/current
   * Actual: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/bars/{barName}
   *
   * This bug affects BarSettingsResource in generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp
   */
  it("singleton child resource - demonstrates path bug (BUG 2)", async () => {
    const program = await typeSpecCompile(singletonChildResourceSchema, runner);

    const provider = resolveArmResources(program);
    const resources = provider.resources ?? [];

    // Find BarSettings resource
    const barSettingsResources = resources.filter(
      (r) => r.type.name === "BarSettings"
    );

    ok(barSettingsResources.length > 0, "Should find BarSettings resource");

    const barSettings = barSettingsResources[0];

    // KNOWN BUG: The path should include /settings/current but it only shows parent path
    // Expected (when bug is fixed):
    //   strictEqual(
    //     barSettings.resourceInstancePath,
    //     "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/bars/{barName}/settings/current",
    //     "BarSettings path should include /settings/current"
    //   );

    // Current buggy behavior: path is same as parent's path
    strictEqual(
      barSettings.resourceInstancePath,
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/bars/{barName}",
      "KNOWN BUG: BarSettings path is parent path instead of /bars/{barName}/settings/current"
    );
  });

  /**
   * BUG 3: Duplicate resources are returned for the same model.
   *
   * Expected: 2 unique resources (Bar and BarSettings)
   * Actual: 4 resources (2 Bar and 2 BarSettings)
   *
   * This bug affects all resources, including BarSettingsResource in bar.tsp
   */
  it("singleton child resource - demonstrates duplicate resources bug (BUG 3)", async () => {
    const program = await typeSpecCompile(singletonChildResourceSchema, runner);

    const provider = resolveArmResources(program);
    const resources = provider.resources ?? [];

    // Count resources by type
    const barCount = resources.filter((r) => r.type.name === "Bar").length;
    const barSettingsCount = resources.filter(
      (r) => r.type.name === "BarSettings"
    ).length;

    // KNOWN BUG: Multiple duplicate resources are returned
    // Expected (when bug is fixed):
    //   strictEqual(barCount, 1, "Should have exactly 1 Bar resource");
    //   strictEqual(barSettingsCount, 1, "Should have exactly 1 BarSettings resource");

    // Current buggy behavior: duplicates are returned
    ok(barCount > 1, "KNOWN BUG: More than 1 Bar resource returned");
    ok(barSettingsCount > 1, "KNOWN BUG: More than 1 BarSettings resource returned");
    ok(resources.length > 2, "KNOWN BUG: Total resources should be > 2 due to duplicates");
  });

  /**
   * BUG 4: Parent information is undefined even when @parentResource is specified.
   *
   * Expected: BarSettings.parent.type.name === "Bar"
   * Actual: BarSettings.parent === undefined
   *
   * This bug affects BarSettingsResource in generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp
   */
  it("singleton child resource - demonstrates parent undefined bug (BUG 4)", async () => {
    const program = await typeSpecCompile(singletonChildResourceSchema, runner);

    const provider = resolveArmResources(program);
    const resources = provider.resources ?? [];

    // Find BarSettings resource
    const barSettings = resources.find((r) => r.type.name === "BarSettings");
    ok(barSettings, "Should find BarSettings resource");

    // KNOWN BUG: Parent is undefined even though @parentResource(Bar) is specified
    // Expected (when bug is fixed):
    //   ok(barSettings.parent, "BarSettings should have a parent");
    //   strictEqual(barSettings.parent.type.name, "Bar", "Parent should be Bar");

    // Current buggy behavior: parent is undefined
    strictEqual(
      barSettings.parent,
      undefined,
      "KNOWN BUG: BarSettings.parent is undefined despite @parentResource(Bar)"
    );
  });

  /**
   * BUG 5: Resource type for child resources uses parent's type instead of full path.
   *
   * Expected: Microsoft.ContosoProviderHub/bars/settings
   * Actual: Microsoft.ContosoProviderHub/bars
   *
   * This bug affects BarSettingsResource in generator/TestProjects/Local/Mgmt-TypeSpec/bar.tsp
   */
  it("singleton child resource - demonstrates resource type bug (BUG 5)", async () => {
    const program = await typeSpecCompile(singletonChildResourceSchema, runner);

    const provider = resolveArmResources(program);
    const resources = provider.resources ?? [];

    // Find BarSettings resource
    const barSettings = resources.find((r) => r.type.name === "BarSettings");
    ok(barSettings, "Should find BarSettings resource");

    const resourceTypeString = `${barSettings.resourceType.provider}/${barSettings.resourceType.types.join("/")}`;

    // KNOWN BUG: Resource type should include child segment but only shows parent type
    // Expected (when bug is fixed):
    //   strictEqual(
    //     resourceTypeString,
    //     "Microsoft.ContosoProviderHub/bars/settings",
    //     "BarSettings resource type should be bars/settings"
    //   );

    // Current buggy behavior: uses parent's resource type
    strictEqual(
      resourceTypeString,
      "Microsoft.ContosoProviderHub/bars",
      "KNOWN BUG: BarSettings uses parent's resource type instead of bars/settings"
    );
  });
});

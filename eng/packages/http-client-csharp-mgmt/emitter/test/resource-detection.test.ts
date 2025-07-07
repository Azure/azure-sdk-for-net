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
    const model = root.models.find((m) => m.name === "Employee");
    ok(model);
    const parentModel = root.models.find((m) => m.name === "EmployeeParent");
    ok(parentModel);
    const getMethod = client.methods.find((m) => m.name === "get");
    ok(getMethod);

    const resourceMetadataDecorator = model.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(resourceMetadataDecorator);
    strictEqual(
      resourceMetadataDecorator.arguments?.resourceType,
      "Microsoft.ContosoProviderHub/employeeParents/employees"
    );
    strictEqual(resourceMetadataDecorator.arguments?.singletonResourceName, undefined);
    strictEqual(
      resourceMetadataDecorator.arguments?.resourceScope,
      "ResourceGroup"
    );
    strictEqual(resourceMetadataDecorator.arguments?.methods.length, 6);
    strictEqual(
      resourceMetadataDecorator.arguments?.methods[0].id,
      getMethod.crossLanguageDefinitionId
    );
    strictEqual(resourceMetadataDecorator.arguments?.methods[0].kind, "Get");
    strictEqual(
      resourceMetadataDecorator.arguments?.parentResource,
      parentModel.crossLanguageDefinitionId
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
    updateClients(root, sdkContext);
    const employeeClient = getAllClients(root).find((c) => c.name === "Employees");
    ok(employeeClient);
    const currentEmployeeClient = getAllClients(root).find(
      (c) => c.name === "CurrentEmployees"
    );
    ok(currentEmployeeClient);
    const employeeModel = root.models.find((m) => m.name === "Employee");
    ok(employeeModel);
    const employeeGetMethod = employeeClient.methods.find((m) => m.name === "get");
    ok(employeeGetMethod);

    const employeeMetadataDecorator = employeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(employeeMetadataDecorator);
    strictEqual(
      employeeMetadataDecorator.arguments?.resourceType,
      "Microsoft.ContosoProviderHub/employees"
    );
    strictEqual(employeeMetadataDecorator.arguments?.singletonResourceName, "default");
    strictEqual(
      employeeMetadataDecorator.arguments?.resourceScope,
      "ResourceGroup"
    );
    strictEqual(employeeMetadataDecorator.arguments?.methods.length, 3);
    strictEqual(
      employeeMetadataDecorator.arguments?.methods[0].id,
      employeeGetMethod.crossLanguageDefinitionId
    );
    strictEqual(employeeMetadataDecorator.arguments?.methods[0].kind, "Get");

    const currentEmployeeModel = root.models.find(
      (m) => m.name === "CurrentEmployee"
    );
    ok(currentEmployeeModel);
    const currentMetdataDecorator = currentEmployeeModel.decorators?.find(
      (d) => d.name === resourceMetadata
    );
    ok(currentMetdataDecorator);
    strictEqual(
      currentMetdataDecorator.arguments?.resourceType,
      "Microsoft.ContosoProviderHub/currentEmployees"
    );
    strictEqual(
      currentMetdataDecorator.arguments?.singletonResourceName,
      "current"
    );
    strictEqual(
      currentMetdataDecorator.arguments?.resourceScope,
      "ResourceGroup"
    );
    strictEqual(currentMetdataDecorator.arguments?.methods.length, 3);
  });
});

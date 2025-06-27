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
    strictEqual(resourceMetadataDecorator.arguments?.isSingleton, false);
    strictEqual(
      resourceMetadataDecorator.arguments?.resourceScope,
      "ResourceGroup"
    );
    strictEqual(
      resourceMetadataDecorator.arguments?.methods.length,
      6
    );
    strictEqual(
      resourceMetadataDecorator.arguments?.methods[0].id,
      getMethod.crossLanguageDefinitionId
    );
    strictEqual(
      resourceMetadataDecorator.arguments?.methods[0].kind,
      "Get"
    );
    strictEqual(
      resourceMetadataDecorator.arguments?.parentResource,
      parentModel.crossLanguageDefinitionId
    );
  });
});

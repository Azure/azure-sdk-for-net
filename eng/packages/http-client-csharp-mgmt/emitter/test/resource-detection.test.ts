import { beforeEach, describe, it } from "vitest";
import { createCSharpSdkContext, createEmitterContext, createEmitterTestHost, typeSpecCompile } from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { updateClients } from "../src/resource-detection.js";
import { ok } from "assert";

describe("Resource Detection", () => {
  let runner: TestHost;
    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("resource group resource", async () => {
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
    delete is ArmResourceDeleteWithoutOkAsync<Employee>;
    listByResourceGroup is ArmResourceListByParent<Employee>;
    listBySubscription is ArmListBySubscription<Employee>;
}`, runner);
        const context = createEmitterContext(program);
        const sdkContext = await createCSharpSdkContext(context);
        const root = createModel(sdkContext);
        updateClients(root);
        const client = root.clients.find((c) => c.name === "Employees");
        ok(client);
    });
});
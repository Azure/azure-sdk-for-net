import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

@doc("The virtual machine instance resource definition.")
@singleton("default")
model HciVmInstance
  is ExtensionResource<HciVmInstanceProperties> {
    ...ResourceNameParameter<HciVmInstance, SegmentName = "virtualMachineInstances">;
}

model HciVmInstanceProperties {
    sku: string;
    arrayProperty: string[];
}

@armResourceOperations
interface HciVmInstances {
  @doc("Gets a virtual machine instance")
  get is ArmResourceRead<HciVmInstance>;
}
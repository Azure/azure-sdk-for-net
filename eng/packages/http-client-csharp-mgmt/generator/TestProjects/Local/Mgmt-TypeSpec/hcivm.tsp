import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-invalid-envelope-property" "For backward compatibility"
#suppress "@azure-tools/typespec-azure-core/no-openapi" "x-ms-azure-resource legacy"
@doc("The virtual machine instance resource definition.")
@extension("x-ms-azure-resource", true)
@singleton("default")
model HciVmInstance
  is ExtensionResource<HciVmInstanceProperties> {
  @doc("name of virtual machine")
  @pattern("^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,62}[a-zA-Z0-9]$")
  @key("virtualMachineInstance")
  @segment("virtualMachineInstances")
  @visibility(Lifecycle.Read)
  @path
  name: string;
}

model HciVmInstanceProperties {
    sku: string;
}

@armResourceOperations
interface HciVmInstances {
  @doc("Gets a virtual machine instance")
  get is ArmResourceRead<HciVmInstance>;
}
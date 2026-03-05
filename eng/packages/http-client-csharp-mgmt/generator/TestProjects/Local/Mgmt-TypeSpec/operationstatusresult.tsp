import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Custom operation status that extends OperationStatusResult.
 * This reproduces the lose base type bug where models extending
 * Azure.ResourceManager.CommonTypes.OperationStatusResult would
 * lose their base type because OperationStatusResult was only in
 * _idToSystemTypeMap and not in _idToInheritableSystemTypeMap.
 */
model CustomOperationStatus extends Azure.ResourceManager.CommonTypes.OperationStatusResult {
  /** Custom field specific to this operation status */
  customField?: string;
}

@armResourceOperations
interface FooOperationStatuses {
  /** Get custom operation status for a Foo resource. */
  @get
  @action("operationStatuses")
  getOperationStatus is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<CustomOperationStatus>
  >;
}

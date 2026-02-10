import "@typespec/rest";
import "@typespec/http";

namespace Azure.ResourceManager.Legacy;

using Http;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;
using Rest;

/**
 * This is the interface that implements the standard Azure Resource Manager operation that returns
 * all supported RP operations. You should have exactly one declaration for each
 * Azure Resource Manager service. It implements
 *   GET "/providers/{provider-namespace}/operations"
 *
 * @template Response The response returned by the operation list.
 * @template Error the error response returned by the operation list.
 * @template Parameters Additional request parameters for the list operation.
 */
interface Operations<
  Response extends {} = ArmResponse<OperationListResult>,
  Error extends {} = ErrorResponse,
  Parameters extends {} = {}
> {
  @tag("Operations")
  @autoRoute
  @armUpdateProviderNamespace
  @doc("List the operations for the provider")
  @segment("operations")
  @get
  @list
  list(
    ...CommonTypes.ApiVersionParameter,

    @path
    @segment("providers")
    @doc("The provider namespace (this parameter will not show up in operations).")
    provider: "Microsoft.ThisWillBeReplaced",

    ...Parameters,
  ): Response | Error;
}

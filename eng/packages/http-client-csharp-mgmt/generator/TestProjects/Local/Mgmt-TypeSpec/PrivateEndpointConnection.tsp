import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

#suppress "@azure-tools/typespec-providerhub-controller/no-resource-operations" "Expected for private links"
model PrivateLink is ProxyResource<PrivateLinkResourceProperties> {
  ...PrivateLinkResourceParameter;
  ...ManagedServiceIdentityProperty;
}

@armResourceOperations(PrivateLink)
interface PrivateLinks {
  /** list private links on the given resource */
  @clientName("GetAllPrivateLinkResources")
  listByMongoCluster is ArmResourceListByParent<PrivateLink>;
  
  /**
   * Starts the SAP Application Server Instance.
   */
  start is ArmResourceActionAsync<
    PrivateLink,
    {
      @doc("SAP Application server instance start request body.")
      @body
      body?: StartRequest;
    },
    Foundations.OperationStatusResult
  >;
  
  @doc("Starts a failed runtime resource")
  @post
  startFailedServerlessRuntime(
  ): ArmNoContentResponse | ErrorResponse;
}

/**
 * Start SAP instance(s) request body.
 */
model StartRequest {
  /**
   * The boolean value indicates whether to start the virtual machines before starting the SAP instances.
   */
  startVm?: boolean;
}

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
}
@parentResource(StorageSyncService)
model PrivateEndpointConnection is PrivateEndpointConnectionResource;
alias PrivateEndpointOperations = Azure.ResourceManager.PrivateEndpoints<PrivateEndpointConnection>;

@armResourceOperations
interface PrivateEndpointConnections {
  /**
   * Gets the specified private endpoint connection associated with the storage sync service.
   */
  get is PrivateEndpointOperations.Read<
    StorageSyncService,
  >;

  /**
   * Update the state of specified private endpoint connection associated with the storage sync service.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-put-operation-response-codes" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  @Azure.Core.useFinalStateVia("location")
  create is PrivateEndpointOperations.CreateOrUpdateAsync<
    StorageSyncService,
    Response = ArmResourceUpdatedResponse<PrivateEndpointConnection> | (ArmAcceptedLroResponse<LroHeaders = ArmCombinedLroHeaders<FinalResult = PrivateEndpointConnection> &
      Azure.Core.Foundations.RetryAfterHeader> & {
      @header("x-ms-correlation-request-id")
      @doc("correlation request id")
      correlationRequestId?: string;

      @header("x-ms-request-id")
      @doc("Request id")
      requestId?: string;
    }),
  >;
}

model StorageSyncService
  is Azure.ResourceManager.TrackedResource<StorageSyncServiceProperties> {
  ...ResourceNameParameter<
    Resource = StorageSyncService,
    KeyName = "storageSyncServiceName",
    SegmentName = "storageSyncServices",
    NamePattern = ""
  >;
  ...Azure.ResourceManager.ManagedServiceIdentityProperty;
}

model StorageSyncServiceProperties {
  /** The storage sync service location. */
  storageSyncServiceLocation: string;
}

@armResourceOperations
interface StorageSyncServices {
  /** Gets the specified storage sync service. */
  get is ArmResourceRead<StorageSyncService>;
}
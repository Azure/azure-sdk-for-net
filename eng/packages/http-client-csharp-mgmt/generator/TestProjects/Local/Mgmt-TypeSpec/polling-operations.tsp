using TypeSpec.Http;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

// Standalone polling routes can be returned by an LRO header without an
// explicit TypeSpec operation link. They should not become public extensions.
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "Custom polling routes"
interface PollingOperations {
  /** Get subscription polling status. */
  @get
  @route("/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/operationStatuses/{operationId}")
  getSubscriptionPollingStatus(...ApiVersionParameter, ...SubscriptionIdParameter, ...Azure.ResourceManager.CommonTypes.OperationIdParameter): ArmResponse<Azure.ResourceManager.CommonTypes.OperationStatusResult> | ErrorResponse;

  /** Get tenant polling status. */
  @get
  @route("/providers/MgmtTypeSpec/operationStatuses/{operationId}")
  getTenantPollingStatus(...ApiVersionParameter, ...Azure.ResourceManager.CommonTypes.OperationIdParameter): ArmResponse<Azure.ResourceManager.CommonTypes.OperationStatusResult> | ErrorResponse;

  /** Get subscription polling result. */
  @get
  @route("/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/operationResults/{operationId}")
  getSubscriptionPollingResult(...ApiVersionParameter, ...SubscriptionIdParameter, ...Azure.ResourceManager.CommonTypes.OperationIdParameter): ArmResponse<PollingDetails> | ErrorResponse;

  /** Get a normal provider operation. */
  @get
  @route("/providers/MgmtTypeSpec/operationStatuses/{operationId}/details")
  getPollingDetails(...ApiVersionParameter, ...Azure.ResourceManager.CommonTypes.OperationIdParameter): ArmResponse<PollingDetails> | ErrorResponse;
}

/** A normal provider operation response. */
model PollingDetails {
  /** Detail value. */
  detail?: string;
}

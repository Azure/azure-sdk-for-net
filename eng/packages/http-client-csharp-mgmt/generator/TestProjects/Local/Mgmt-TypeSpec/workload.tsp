using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;
using Azure.ResourceManager.Foundations;

namespace MgmtTypeSpec;
/**
 * Define the Virtual Instance for SAP solutions resource.
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "SAP is used for representing the company product."
model SAPVirtualInstance is Azure.ResourceManager.TrackedResource<SAPVirtualInstanceProperties> {
  ...ResourceNameParameter<
    Resource = SAPVirtualInstance,
    KeyName = "sapVirtualInstanceName",
    SegmentName = "sapVirtualInstances",
    NamePattern = "^[a-zA-Z][a-zA-Z0-9]{2}$"
  >;
}

model SAPVirtualInstanceProperties {
  name: string;
}

#suppress "@azure-tools/typespec-azure-core/casing-style" "SAP is used for representing the company product."
@armResourceOperations
interface SAPVirtualInstances {
  /**
   * Gets a Virtual Instance for SAP solutions resource
   */
  get is ArmResourceRead<SAPVirtualInstance>;

  /**
   * Creates a Virtual Instance for SAP solutions (VIS) resource
   */
  create is ArmResourceCreateOrReplaceAsync<SAPVirtualInstance>;

  /**
   * Get the recommended SAP Availability Zone Pair Details for your region.
   */
  #suppress "@azure-tools/typespec-azure-core/no-openapi" "Added Operation ID as it determines the PowerShell verb used."
  @operationId("SapVirtualInstances_InvokeAvailabilityZoneDetails")
  getAvailabilityZoneDetails is VirtualResourceActionSync<
    SAPVirtualInstanceMetadata,
    SAPAvailabilityZoneDetailsRequest,
    SAPAvailabilityZoneDetailsResult
  >;
}

#suppress "@azure-tools/typespec-azure-core/casing-style" "SAP is used for representing the company product."
@singleton
@parentResource(SubscriptionLocationResource)
@armVirtualResource
model SAPVirtualInstanceMetadata {

  @path
  @visibility(Lifecycle.Read)
  @segment("sapVirtualInstanceMetadata")
  @key
  default: "string";
}

model SAPAvailabilityZoneDetailsRequest {
  /** The preferred availability zone */
  preferredAvailabilityZone: string;
}

model SAPAvailabilityZoneDetailsResult {
  /** The recommended availability zone pair */
  recommendedAvailabilityZonePair: string;
}

/**
 * A synchronous resource action.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 */
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-operation" "Custom template"
// THIS IS TO PROVIDE a temp workaround. The standard ArmResourceXX operations will be expected to support
// ARM virtual resources. Until then, use this custom template
@autoRoute
@armResourceAction(Resource)
@post
@returnsDoc("Azure operation completed successfully.")
op VirtualResourceActionSync<
  Resource extends Foundations.Resource,
  Request extends TypeSpec.Reflection.Model | void,
  Response extends TypeSpec.Reflection.Model | void,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse
>(
  ...ResourceInstanceParameters<Resource, BaseParameters>,
  ...Parameters,

  @doc("The content of the action request")
  @bodyRoot
  body: Request,
): Response | Error;

/**
 * @dev A long-running resource action.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 */
#suppress "@azure-tools/typespec-azure-core/documentation-required" "template"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-operation" "template"
@returnsDoc("Azure operation completed successfully.")
@autoRoute
@armResourceAction(Resource)
@post
op CustomizedArmResourceActionAsync<
  Resource extends Azure.ResourceManager.Foundations.Resource,
  Request extends TypeSpec.Reflection.Model | void,
  Response extends TypeSpec.Reflection.Model | void,
  BaseParameters extends TypeSpec.Reflection.Model = Azure.ResourceManager.Foundations.DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Response,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse
>(
  ...ResourceInstanceParameters<Resource, BaseParameters>,
  ...Parameters,
  @bodyRoot body?: Request,
): ArmAcceptedLroResponse<
  "Resource operation accepted.",
  LroHeaders
> | Response | Error;


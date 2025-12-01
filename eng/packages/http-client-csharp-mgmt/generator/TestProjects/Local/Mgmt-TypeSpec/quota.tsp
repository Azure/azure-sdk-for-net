import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

/**
 * The new quota limit request status.
 */
@resource("quotas")
model GroupQuotaSubscriptionRequestStatus
  is Azure.ResourceManager.ProxyResource<GroupQuotaLimitProperties> {
  ...ResourceNameParameter<
    Resource = GroupQuotaSubscriptionRequestStatus,
    KeyName = "requestId",
    SegmentName = "subscriptionRequests",
    NamePattern = ""
  >;
}

@armResourceOperations
interface GroupQuotaSubscriptionRequestStatuses {
  /**
   * Get API to check the status of a subscriptionIds request by requestId.  Use the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status. This API provides the finals status with the request details and status.
   */
  get is Extension.Read<
    Extension.ManagementGroup<"managementGroupId">,
    GroupQuotaSubscriptionRequestStatus
  >;
}

model GroupQuotaLimitProperties extends GroupQuotaDetails {}

/**
 * Group Quota details.
 */
model GroupQuotaDetails {
  /**
   * The resource name, such as SKU name.
   */
  resourceName?: string;

  /**
   * The current Group Quota Limit at the parentId level.
   */
  limit?: int64;

  /**
   * Any comment related to quota request.
   */
  comment?: string;

  /**
   *  The usages units, such as Count and Bytes. When requesting quota, use the **unit** value returned in the GET response in the request body of your PUT operation.
   */
  @visibility(Lifecycle.Read)
  unit?: string;

  /**
   * The available Group Quota Limit at the MG level. This Group quota can be allocated to subscription(s).
   */
  @visibility(Lifecycle.Read)
  availableLimit?: int64;

  /**
   * Quota allocated to subscriptions
   */
  @visibility(Lifecycle.Read)
  allocatedToSubscriptions?: AllocatedQuotaToSubscriptionList;
}

/**
 * Quota allocated to subscriptions
 */
model AllocatedQuotaToSubscriptionList {
  /**
   * List of Group Quota Limit allocated to subscriptions.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/missing-x-ms-identifiers" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  value?: AllocatedToSubscription[];
}

/**
 * SubscriptionIds and quota allocated to subscriptions from the GroupQuota.
 */
model AllocatedToSubscription {
  /**
   * An Azure subscriptionId.
   */
  subscriptionId?: string;

  /**
   * The amount of quota allocated to this subscriptionId from the GroupQuotasEntity.
   */
  quotaAllocated?: int64;
}

model GroupQuotaLimitList
  is Azure.ResourceManager.ProxyResource<GroupQuotaLimitListProperties> {
  ...ResourceNameParameter<
    Resource = GroupQuotaLimitList,
    KeyName = "location",
    SegmentName = "groupQuotaLimits",
    NamePattern = ""
  >;
}

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model GroupQuotaLimitListProperties {
  /**
   * The URL to use for getting the next set of results.
   */
  @visibility(Lifecycle.Read)
  nextLink?: string;
}

alias GroupQuotaLimitListsOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter;

    /** the provider namespace */
    @path
    @segment("providers")
    @key
    providerNamespace: "Microsoft.Management";

    /**
     * The management group ID.
     */
    @path
    @segment("managementGroups")
    @key
    @minLength(3)
    @maxLength(63)
    managementGroupId: string;
  },
  {
  },
  {
    /**
     * The GroupQuota name. The name should be unique for the provided context tenantId/MgId.
     */
    @path
    @segment("groupQuotas")
    @minLength(3)
    @maxLength(63)
    @key
    @pattern("^[a-z][a-z0-9]*$")
    groupQuotaName: string;

    /**
     * The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API.
     */
    @path
    @key
    @segment("resourceProviders")
    @pattern("^((?!-)[a-zA-Z0-9-]{1,63}(?<!-)\\.)+[a-zA-Z]{2,63}$")
    resourceProviderName: string;

    /**
     * The name of the Azure region.
     */
    @path
    @minLength(1)
    @segment("groupQuotaLimits")
    location: Azure.Core.azureLocation;
  }
>;

@armResourceOperations
interface GroupQuotaLimitLists {
  /**
   * Gets the GroupQuotaLimits for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.
   */
  list is GroupQuotaLimitListsOps.Read<GroupQuotaLimitList>;

  createOrUpdate is GroupQuotaLimitListsOps.CreateOrUpdateAsync<
    GroupQuotaLimitList,
    Response = ArmResourceUpdatedResponse<GroupQuotaLimitList> | ArmResourceCreatedResponse<
      GroupQuotaLimitList,
      ArmCombinedLroHeaders<FinalResult = GroupQuotaLimitList> &
        Azure.Core.Foundations.RetryAfterHeader
    >,
    OptionalRequestBody = true
  >;

  /**
   * Create the GroupQuota requests for a specific ResourceProvider/Location/Resource. The resourceName properties are specified in the request body. Only 1 resource quota can be requested. Please note that patch request creates a new groupQuota request.
   * Use the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status. This API provides the finals status with the request details and status.
   */
  @patch(#{ implicitOptionality: false })
  update is GroupQuotaLimitListsOps.CustomPatchAsync<
    GroupQuotaLimitList,
    PatchModel = GroupQuotaLimitList,
    OptionalRequestBody = true,
    Response = ArmResponse<GroupQuotaLimitList> | ArmAcceptedLroResponse<LroHeaders = ArmCombinedLroHeaders<FinalResult = GroupQuotaLimitList> &
      Azure.Core.Foundations.RetryAfterHeader>
  >;
}
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
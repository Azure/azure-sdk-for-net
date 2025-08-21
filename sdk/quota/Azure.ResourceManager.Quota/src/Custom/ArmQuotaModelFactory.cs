// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Quota.Models
{
    public static partial class ArmQuotaModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.GroupQuotaDetails"/>. </summary>
        /// <param name="resourceName"> The resource name, such as SKU name. </param>
        /// <param name="limit"> The current Group Quota Limit at the parentId level. </param>
        /// <param name="comment"> Any comment related to quota request. </param>
        /// <param name="unit"> The usages units, such as Count and Bytes. When requesting quota, use the **unit** value returned in the GET response in the request body of your PUT operation. </param>
        /// <param name="value"> Resource name. </param>
        /// <param name="localizedValue"> Resource display name. </param>
        /// <param name="availableLimit"> The available Group Quota Limit at the MG level. This Group quota can be allocated to subscription(s). </param>
        /// <param name="allocatedToSubscriptionsValue"> Quota allocated to subscriptions. </param>
        /// <returns> A new <see cref="Models.GroupQuotaDetails"/> instance for mocking. </returns>
        public static GroupQuotaDetails GroupQuotaDetails(string resourceName, long? limit, string comment, string unit, long? availableLimit = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> allocatedToSubscriptionsValue = null, string value = null, string localizedValue = null)
        {
            return GroupQuotaDetails(
                resourceName,
                limit,
                comment,
                unit,
                value,
                localizedValue,
                availableLimit,
                allocatedToSubscriptionsValue);
        }

        /// <summary> Initializes a new instance of <see cref="Models.GroupQuotaLimitProperties"/>. </summary>
        /// <param name="resourceName"> The resource name, such as SKU name. </param>
        /// <param name="limit"> The current Group Quota Limit at the parentId level. </param>
        /// <param name="comment"> Any comment related to quota request. </param>
        /// <param name="unit"> The usages units, such as Count and Bytes. When requesting quota, use the **unit** value returned in the GET response in the request body of your PUT operation. </param>
        /// <param name="value"> Resource name. </param>
        /// <param name="localizedValue"> Resource display name. </param>
        /// <param name="availableLimit"> The available Group Quota Limit at the MG level. This Group quota can be allocated to subscription(s). </param>
        /// <param name="allocatedToSubscriptionsValue"> Quota allocated to subscriptions. </param>
        /// <returns> A new <see cref="Models.GroupQuotaLimitProperties"/> instance for mocking. </returns>
        public static GroupQuotaLimitProperties GroupQuotaLimitProperties(string resourceName, long? limit, string comment, string unit, long? availableLimit = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> allocatedToSubscriptionsValue = null, string value = null, string localizedValue = null)
        {
            return GroupQuotaLimitProperties(
                resourceName,
                limit,
                comment,
                unit,
                value,
                localizedValue,
                availableLimit,
                allocatedToSubscriptionsValue);
        }

        // Add this custom code because its properties order changed, but the changed properties are all string, this actually replaces its generated overload.
        /// <summary> Initializes a new instance of <see cref="Models.GroupQuotaRequestBase"/>. </summary>
        /// <param name="limit"> The new quota limit for the subscription. The incremental quota will be allocated from pre-approved group quota. </param>
        /// <param name="value"> Resource name. </param>
        /// <param name="localizedValue"> Resource display name. </param>
        /// <param name="region"> Location/Azure region for the quota requested for resource. </param>
        /// <param name="comments"> GroupQuota Request comments and details for request. This is optional paramter to provide more details related to the requested resource. </param>
        /// <returns> A new <see cref="Models.GroupQuotaRequestBase"/> instance for mocking. </returns>
        public static GroupQuotaRequestBase GroupQuotaRequestBase(long? limit = default(long?), string region = null, string comments = null, string value = null, string localizedValue = null)
        {
            return new GroupQuotaRequestBase(
                limit,
                value,
                localizedValue,
                region,
                comments,
                serializedAdditionalRawData: null);
        }
    }
}

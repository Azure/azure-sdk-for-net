// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: GA exposed this AzureLocation overload; the generated split task resource does not emit this resource-id helper.
    public partial class SubscriptionSecurityTaskResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="ascLocation"> The ascLocation. </param>
        /// <param name="taskName"> Name of the task object. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation ascLocation, string taskName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}

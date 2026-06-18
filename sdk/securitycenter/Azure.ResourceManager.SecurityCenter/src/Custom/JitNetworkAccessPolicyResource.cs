// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    // Backward compatibility: preserve the previous AzureLocation overload for resource identifier creation.
    public partial class JitNetworkAccessPolicyResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="ascLocation"> The ascLocation. </param>
        /// <param name="jitNetworkAccessPolicyName"> The jitNetworkAccessPolicyName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, AzureLocation ascLocation, string jitNetworkAccessPolicyName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, ascLocation.ToString(), jitNetworkAccessPolicyName);
    }
}

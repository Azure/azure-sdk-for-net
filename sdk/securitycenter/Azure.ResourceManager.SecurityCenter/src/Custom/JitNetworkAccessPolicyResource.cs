// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    // The current TypeSpec-generated resource identifier helper uses the regenerated path parameter shape, but GA exposed an AzureLocation overload; keep that overload and translate it to the generated identifier.
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

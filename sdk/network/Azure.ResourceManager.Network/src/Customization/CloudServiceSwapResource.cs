// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class CloudServiceSwapResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="groupName"> The resource group name. </param>
        /// <param name="resourceName"> The cloud service name. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string resourceName)
            => CreateResourceIdentifier(subscriptionId, groupName, resourceName, "default");
    }
}

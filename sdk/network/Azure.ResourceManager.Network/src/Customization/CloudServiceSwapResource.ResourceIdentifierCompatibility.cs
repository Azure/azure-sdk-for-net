// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CloudServiceSwapResource type. </summary>
    public partial class CloudServiceSwapResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudServiceName, "default");
    }
}

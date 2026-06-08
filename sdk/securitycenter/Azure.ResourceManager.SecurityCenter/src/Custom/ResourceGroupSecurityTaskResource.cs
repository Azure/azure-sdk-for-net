// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    // Backward compatibility: preserve the previous AzureLocation overload for resource identifier creation.
    public partial class ResourceGroupSecurityTaskResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, AzureLocation ascLocation, string taskName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, ascLocation.ToString(), taskName);
    }
}

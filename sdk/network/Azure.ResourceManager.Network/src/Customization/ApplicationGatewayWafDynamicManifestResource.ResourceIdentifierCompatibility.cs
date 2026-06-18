// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ApplicationGatewayWafDynamicManifestResource type. </summary>
    public partial class ApplicationGatewayWafDynamicManifestResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location)
            => CreateResourceIdentifier(subscriptionId, location.ToString());
    }
}

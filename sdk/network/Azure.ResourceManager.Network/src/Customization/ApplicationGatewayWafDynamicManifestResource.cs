// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayWafDynamicManifestResource
    {
        // Preserve the string overload released during migration; native generation restores AzureLocation.
        // Null previously interpolated as empty; otherwise use AzureLocation's normal conversion.
        /// <summary> Generates the regional manifest resource identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CreateResourceIdentifier(subscriptionId, new AzureLocation(location)) instead.")]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location)
            => CreateResourceIdentifier(subscriptionId, location is null ? default(AzureLocation) : new AzureLocation(location));
    }
}

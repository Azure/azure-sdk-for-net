// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputeLicenseProfileResource
    {
        /// <summary>
        /// Creates a resource identifier for <see cref="HybridComputeLicenseProfileResource"/> with 3 parameters (backward compat).
        /// The old API had a single default licenseProfile name; the new API requires the licenseProfileName explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, machineName, "default");
    }
}

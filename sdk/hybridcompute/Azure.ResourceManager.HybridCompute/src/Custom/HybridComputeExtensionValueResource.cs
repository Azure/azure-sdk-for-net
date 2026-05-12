// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputeExtensionValueResource
    {
        /// <summary>
        /// Creates a resource identifier for <see cref="HybridComputeExtensionValueResource"/>.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string publisher, string extensionType, string version)
            => CreateResourceIdentifier(subscriptionId, location.ToString(), publisher, extensionType, version);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added a required constructor parameter (networkDeviceSku). This preserves the
    // old constructor signature from v1.1.2 that only required location.
    public partial class NetworkDeviceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDeviceData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkDeviceData(AzureLocation location) : this(location, default)
        {
        }
    }
}

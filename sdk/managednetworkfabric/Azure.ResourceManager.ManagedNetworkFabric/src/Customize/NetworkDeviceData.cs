// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the TypeSpec migration. The new generator requires
    // serialNumber in the generated constructor.
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkDeviceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDeviceData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkDeviceData(AzureLocation location) : base(location)
        {
        }
    }
}

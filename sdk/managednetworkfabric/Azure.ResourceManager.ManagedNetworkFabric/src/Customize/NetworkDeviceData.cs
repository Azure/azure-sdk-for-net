// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the TypeSpec migration. The new generator requires
    // networkDeviceSku in the generated constructor and exposes NetworkRackId from the properties bag.
    // Removing this file would drop the shipped location-only constructor and NetworkRackId accessor.
    public partial class NetworkDeviceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDeviceData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkDeviceData(AzureLocation location) : this(location, default)
        {
        }

        /// <summary> Reference to network rack resource id. </summary>
        [CodeGenMember("NetworkRackId")]
        public ResourceIdentifier NetworkRackId => Properties?.NetworkRackId is null ? default : new ResourceIdentifier(Properties.NetworkRackId);
    }
}

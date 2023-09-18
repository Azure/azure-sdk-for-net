// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the virtual network resource settings. </summary>
    public partial class MoverVirtualNetworkResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of MoverVirtualNetworkResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MoverVirtualNetworkResourceSettings(string targetResourceName) : this()
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            AddressSpace = new ChangeTrackingList<string>();
            DnsServers = new ChangeTrackingList<string>();
            Subnets = new ChangeTrackingList<SubnetResourceSettings>();
            ResourceType = "Microsoft.Network/virtualNetworks";
        }
    }
}

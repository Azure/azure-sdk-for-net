// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the network interface resource settings. </summary>
    public partial class NetworkInterfaceResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of NetworkInterfaceResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        public NetworkInterfaceResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            IPConfigurations = new ChangeTrackingList<NicIPConfigurationResourceSettings>();
            ResourceType = "Microsoft.Network/networkInterfaces";
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the NSG resource settings. </summary>
    public partial class NetworkSecurityGroupResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of NetworkSecurityGroupResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        public NetworkSecurityGroupResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            SecurityRules = new ChangeTrackingList<NetworkSecurityGroupSecurityRule>();
            ResourceType = "Microsoft.Network/networkSecurityGroups";
        }
    }
}

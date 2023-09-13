// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the public IP address resource settings. </summary>
    public partial class PublicIPAddressResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of PublicIPAddressResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        public PublicIPAddressResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            ResourceType = "Microsoft.Network/publicIPAddresses";
        }
    }
}

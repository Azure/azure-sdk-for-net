// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the IpamPoolData type. </summary>
    public partial class IpamPoolData
    {
        /// <summary> Initializes a new instance of the IpamPoolData class. </summary>
        public IpamPoolData(IpamPoolProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }

        /// <summary> Invokes the this compatibility operation. </summary>
        public IpamPoolData(AzureLocation location, IpamPoolProperties properties) : this(properties)
        {
            Location = location;
        }
    }
}

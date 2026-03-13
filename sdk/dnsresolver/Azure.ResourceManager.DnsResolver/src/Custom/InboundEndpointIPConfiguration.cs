// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Suppress generated string-typed property/constructor to provide ResourceIdentifier versions for backward compat.
    [CodeGenSuppress("InboundEndpointIPConfiguration", typeof(string))]
    [CodeGenSuppress("SubnetId")]
    public partial class InboundEndpointIPConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="InboundEndpointIPConfiguration"/>. </summary>
        /// <param name="subnetId"> The reference to the subnet. </param>
        public InboundEndpointIPConfiguration(ResourceIdentifier subnetId)
        {
            SubnetId = subnetId;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InboundEndpointIPConfiguration(WritableSubResource subnet) : this(subnet?.Id)
        {
        }

        /// <summary> The reference to the subnet. </summary>
        public ResourceIdentifier SubnetId { get; set; }
    }
}

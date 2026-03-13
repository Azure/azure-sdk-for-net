// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver
{
    // Suppress generated string-typed property/constructor to provide ResourceIdentifier versions for backward compat.
    [CodeGenSuppress("DnsResolverOutboundEndpointData", typeof(AzureLocation), typeof(string))]
    [CodeGenSuppress("SubnetId")]
    public partial class DnsResolverOutboundEndpointData
    {
        /// <summary> Initializes a new instance of <see cref="DnsResolverOutboundEndpointData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="subnetId"> The reference to the subnet. </param>
        public DnsResolverOutboundEndpointData(AzureLocation location, ResourceIdentifier subnetId) : base(location)
        {
            Properties = new Models.OutboundEndpointProperties(subnetId?.ToString());
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverOutboundEndpointData(AzureLocation location, WritableSubResource subnet) : this(location, subnet?.Id)
        {
        }

        /// <summary> The reference to the subnet. </summary>
        public ResourceIdentifier SubnetId
        {
            get => Properties?.SubnetId != null ? new ResourceIdentifier(Properties.SubnetId) : null;
            set
            {
                if (Properties is null) Properties = new Models.OutboundEndpointProperties();
                Properties.SubnetId = value?.ToString();
            }
        }
    }
}

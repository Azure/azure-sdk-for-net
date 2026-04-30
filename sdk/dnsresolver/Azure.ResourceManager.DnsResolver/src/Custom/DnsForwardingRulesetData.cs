// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsForwardingRulesetData
    {
        // Justification: the pre-migration SDK exposed this public constructor directly on
        // DnsForwardingRulesetData. The TypeSpec-generated model now stores these values in an
        // internal Properties bag and no longer emits the same constructor shape, so this partial
        // preserves the existing API surface for backward compatibility.
        /// <summary> Initializes a new instance of <see cref="DnsForwardingRulesetData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="dnsResolverOutboundEndpoints"> The reference to the DNS resolver outbound endpoints. </param>
        public DnsForwardingRulesetData(AzureLocation location, IEnumerable<WritableSubResource> dnsResolverOutboundEndpoints) : base(location)
        {
            Properties = new DnsForwardingRulesetProperties(dnsResolverOutboundEndpoints?.ToList() ?? new List<WritableSubResource>());
        }
    }
}

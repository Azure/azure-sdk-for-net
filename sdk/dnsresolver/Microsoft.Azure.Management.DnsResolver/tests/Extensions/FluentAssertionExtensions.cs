// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests.Extensions
{
    using Microsoft.Azure.Management.DnsResolver.Models;

    public static class FluentAssertionExtensions
    {
        public static InboundEndpointAssertions Should(this InboundEndpoint inboundEndpoint)
        {
            return new InboundEndpointAssertions(inboundEndpoint);
        }

        public static DnsResolverModelAssertions Should(this DnsResolverModel dnsResolverModel)
        {
            return new DnsResolverModelAssertions(dnsResolverModel);
        }
    }
}

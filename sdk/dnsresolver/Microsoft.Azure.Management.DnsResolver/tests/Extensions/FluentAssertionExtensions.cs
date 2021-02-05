// ------------------------------------------------------------------------------------------------
// <copyright file="FluentAssertionExtensions.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Management.DnsResolver.Tests.Extensions.Assertions
{
    using Microsoft.Azure.Management.DnsResolver.Models;
    using Microsoft.Azure.Management.DnsResolver.Tests.Assertions;

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

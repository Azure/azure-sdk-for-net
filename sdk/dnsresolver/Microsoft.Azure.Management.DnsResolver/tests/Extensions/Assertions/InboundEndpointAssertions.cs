// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests
{
    using FluentAssertions;
    using FluentAssertions.Primitives;
    using Microsoft.Azure.Management.DnsResolver.Models;

    public class InboundEndpointAssertions : ReferenceTypeAssertions<InboundEndpoint, InboundEndpointAssertions>
    {
        public InboundEndpointAssertions(InboundEndpoint subject)
        {
            this.Subject = subject;
        }

        protected override string Identifier => nameof(InboundEndpoint);

        public AndConstraint<InboundEndpointAssertions> BeSuccessfullyCreated()
        {
            var InboundEndpoint = this.Subject;
            InboundEndpoint.Should().NotBeNull();
            InboundEndpoint.Id.Should().NotBeNull();
            InboundEndpoint.Etag.Should().NotBeNullOrEmpty();
            InboundEndpoint.ResourceGuid.Should().NotBeNullOrWhiteSpace();
            InboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);

            return new AndConstraint<InboundEndpointAssertions>(this);
        }

        public AndConstraint<InboundEndpointAssertions> BeSameAsExpected(InboundEndpoint expected)
        {
            var InboundEndpoint = this.Subject;
            InboundEndpoint.ProvisioningState.Should().Be(expected.ProvisioningState);
            InboundEndpoint.ResourceGuid.Should().Be(expected.ResourceGuid);
            InboundEndpoint.Metadata.Should().BeEquivalentTo(expected.Metadata);
            InboundEndpoint.Name.Should().Be(expected.Name);
            return new AndConstraint<InboundEndpointAssertions>(this);
        }
    }
}

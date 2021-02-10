// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests
{
    using FluentAssertions;
    using FluentAssertions.Primitives;
    using Microsoft.Azure.Management.DnsResolver.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Provides customized assertions for DnsResolver.
    /// </summary>
    public class DnsResolverModelAssertions : ReferenceTypeAssertions<DnsResolverModel, DnsResolverModelAssertions>
    {
        public DnsResolverModelAssertions(DnsResolverModel subject)
        {
            this.Subject = subject;
        }

        protected override string Identifier => nameof(DnsResolverModel);

        public AndConstraint<DnsResolverModelAssertions> BeSuccessfullyCreated()
        {
            var DnsResolverModel = this.Subject;
            DnsResolverModel.Name.Should().NotBeNull();
            DnsResolverModel.Should().NotBeNull();
            DnsResolverModel.Id.Should().NotBeNull();
            DnsResolverModel.Etag.Should().NotBeNullOrEmpty();
            DnsResolverModel.ResourceGuid.Should().NotBeNullOrWhiteSpace();
            DnsResolverModel.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);

            return new AndConstraint<DnsResolverModelAssertions>(this);
        }

        public AndConstraint<DnsResolverModelAssertions> BeSameAsExpected(DnsResolverModel expected)
        {
            var DnsResolverModel = this.Subject;
            DnsResolverModel.Location.Should().Be(expected.Location);
            DnsResolverModel.VirtualNetwork.Id.Should().Be(expected.VirtualNetwork.Id);
            DnsResolverModel.Tags.Should().BeEquivalentTo(expected.Tags);
            DnsResolverModel.ProvisioningState.Should().Be(expected.ProvisioningState);
            return new AndConstraint<DnsResolverModelAssertions>(this);
        }

        public AndConstraint<DnsResolverModelAssertions> BeSuccessfullyUpdatedWithExpectedTags(DnsResolverModel previous, IDictionary<string, string> expectedTags)
        {
            var DnsResolverModel = this.Subject;
            DnsResolverModel.Should().NotBeNull();
            DnsResolverModel.Name.Should().Be(previous.Name);
            DnsResolverModel.Id.Should().Be(previous.Id);
            DnsResolverModel.ProvisioningState.Should().Be(previous.ProvisioningState);
            DnsResolverModel.Location.Should().Be(previous.Location);
            DnsResolverModel.ResourceGuid.Should().NotBeNullOrWhiteSpace();
            DnsResolverModel.VirtualNetwork.Id.Should().Be(previous.VirtualNetwork.Id);
            return new AndConstraint<DnsResolverModelAssertions>(this);
        }
    }
}


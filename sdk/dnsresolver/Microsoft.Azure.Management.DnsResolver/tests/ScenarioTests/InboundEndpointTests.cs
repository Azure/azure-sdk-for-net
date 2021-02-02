// ------------------------------------------------------------------------------------------------
// <copyright file="InboundEndpointTests.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace DnsResolver.Tests.ScenarioTests
{
    using FluentAssertions;
    using Microsoft.Azure.Management.DnsResolver;
    using Microsoft.Azure.Management.DnsResolver.Models;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;
    using Xunit.Abstractions;

    public class InboundEndpointTests : BaseScenarioTests
    {
        public InboundEndpointTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void PutInboundEndpoint_InboundEndpointNotExistsWithIpConfigurationsNoMetadata_ExpectInboundEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: createdDnsResolver.Name, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations);

            createdInboundEndpoint.Name.Should().Be(inboundEndpointName);
            createdInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            createdInboundEndpoint.Metadata.Should().BeNull();
            createdInboundEndpoint.IpConfigurations.Should().BeEquivalentTo(ipConfigurations);
        }

        [Fact]
        public void PutInboundEndpoint_InboundEndpointNotExistsWithIpConfigurationsAndMetadata_ExpectInboundEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var metadata = TestDataGenerator.GenerateTags();

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: createdDnsResolver.Name, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations, metadata: metadata);

            createdInboundEndpoint.Name.Should().Be(inboundEndpointName);
            createdInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            createdInboundEndpoint.Metadata.Should().NotBeNull();
            createdInboundEndpoint.IpConfigurations.Should().BeEquivalentTo(metadata);
            createdInboundEndpoint.IpConfigurations.Should().NotBeNull();
            createdInboundEndpoint.IpConfigurations.Should().BeEquivalentTo(ipConfigurations);
        }

        [Fact]
        public void PutInboundEndpoint_InboundEndpointNotExistsNoIpConfigurations_ExpectFailure()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();

            Action putInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName, 
                dnsResolverName: createdDnsResolver.Name, 
                inboundEndpointName: inboundEndpointName);

            putInboundEndpointAction.Should().NotBeNull();
            putInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


    }
}


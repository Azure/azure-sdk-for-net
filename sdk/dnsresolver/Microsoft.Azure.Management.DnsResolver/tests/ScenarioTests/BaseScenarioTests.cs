// ------------------------------------------------------------------------------------------------
// <copyright file="BaseScenarioTests.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace DnsResolver.Tests.ScenarioTests
{
    using DnsResolver.Tests.Extensions;
    using DnsResolver.Tests.Helpers;
    using FluentAssertions;
    using Microsoft.Azure.Management.DnsResolver;
    using Microsoft.Azure.Management.DnsResolver.Models;
    using Microsoft.Azure.Management.DnsResolver.Tests.Extensions;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Xunit.Abstractions;
    using SubResource = Microsoft.Azure.Management.DnsResolver.Models.SubResource;

    public class BaseScenarioTests : IDisposable
    {
        public BaseScenarioTests(ITestOutputHelper output)
        {
            var testName = GetTestName(output);

            this.TestContext = MockContext.Start(this.GetType().Name, testName);
            this.ResourceHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            this.ResourceManagementClient = ClientFactory.GetResourcesClient(this.TestContext, this.ResourceHandler);
            this.DnsResolverManagementClient = ClientFactory.GetDnsResolverClient(this.TestContext, this.ResourceHandler);
            this.NetworkManagementClient = ClientFactory.GetNetworkClient(this.TestContext, this.ResourceHandler);
            this.SubscriptionId = TestEnvironmentFactory.GetTestEnvironment().SubscriptionId;
        }

        protected MockContext TestContext { get; private set; }

        protected RecordedDelegatingHandler ResourceHandler { get; private set; }

        protected ResourceManagementClient ResourceManagementClient { get; private set; }

        protected DnsResolverManagementClient DnsResolverManagementClient { get; private set; }

        protected NetworkManagementClient NetworkManagementClient { get; private set; }

        protected string SubscriptionId { get; private set; }

        public virtual void Dispose()
        {
            TestContext?.Dispose();
        }

        protected ResourceGroup CreateResourceGroup(string resourceGroupName = null)
        {
            return this.ResourceManagementClient.CreateResourceGroup(resourceGroupName: resourceGroupName);
        }

        protected DnsResolverModel CreateDnsResolver(string location = null, string resourceGroupName = null, string dnsResolverName = null,  IDictionary<string, string> tags = null) 
        {
            location = location ?? Constants.DnsResolverLocation;
            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroup().Name;
            dnsResolverName = dnsResolverName ?? TestDataGenerator.GenerateDnsResolverName();

            return this.DnsResolverManagementClient.DnsResolvers.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: dnsResolverName,
                parameters: GenerateDnsResolverWithNewlyCreatedVirtualNetwork(location: location, resourceGroupName: resourceGroupName));
        }

        protected InboundEndpoint CreateInboundEndpoint(DnsResolverModel createdDnsResolver, string resourceGroupName = null, string inboundEndpointName = null, IDictionary<string, string> tags = null)
        {
            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroup().Name;
            inboundEndpointName = inboundEndpointName ?? TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var metadata = TestDataGenerator.GenerateTags();

            return this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName, 
                dnsResolverName: createdDnsResolver.Name, 
                inboundEndpointName: inboundEndpointName, 
                ipConfigurations: ipConfigurations, 
                metadata: metadata);
        }

        protected ICollection<DnsResolverModel> CreateDnsResolvers( string resourceGroupName = null, int numDnsResolvers = 3)
        {
            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroup().Name;

            var createdDnsResolvers = new List<DnsResolverModel>();
            for (var i = 0; i < numDnsResolvers; i++)
            {
                createdDnsResolvers.Add(this.CreateDnsResolver(resourceGroupName: resourceGroupName));
            }

            return createdDnsResolvers;
        }

        protected ICollection<InboundEndpoint> CreateInboundEndpoints(DnsResolverModel createdDnsResolver, string resourceGroupName = null, int numInboundEndpoints = 3)
        {
            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroup().Name;

            var createdInboundEndpoints = new List<InboundEndpoint>();
            for (var i = 0; i < numInboundEndpoints; i++)
            {
                createdInboundEndpoints.Add(this.CreateInboundEndpoint(createdDnsResolver, resourceGroupName: resourceGroupName));
            }

            return createdInboundEndpoints;
        }

        protected static string ExtractArmResourceName(string armResourceId)
        {
            var pathDelimiter = "/";
            var splitedArmResourceId = armResourceId.Split(pathDelimiter);
            return splitedArmResourceId.Last();
        }

        protected SubResource CreateVirtualNetwork(string resourceGroupName, string virtualNetworkName = null)
        {
            virtualNetworkName = virtualNetworkName ?? TestDataGenerator.GenerateVirtualNetworkName();
            var createdVirtualNetwork = this.NetworkManagementClient.CreateVirtualNetwork(resourceGroupName: resourceGroupName, virtualNetworkName: virtualNetworkName);

            createdVirtualNetwork.Should().NotBeNull();

            var derivedVirtualNetworkSubResource = new SubResource()
            {
                Id = createdVirtualNetwork.Id
            };

            return derivedVirtualNetworkSubResource;
        }

        protected DnsResolverModel GenerateDnsResolverWithNewlyCreatedVirtualNetwork(string location = null, string resourceGroupName = null, IDictionary<string, string> tags = null)
        {
            var dnsResolver = TestDataGenerator.GenerateDnsResolverWithoutVirtualNetwork(location: location, tags: tags);
            //dnsResolver.VirtualNetwork = CreateVirtualNetwork(resourceGroupName: resourceGroupName);
            dnsResolver.VirtualNetwork = TestDataGenerator.GenerateNonExistentVirtualNetwork(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName);
            return dnsResolver;
        }

        private static string GetTestName(ITestOutputHelper output)
        {
            // Reference: https://github.com/xunit/xunit/issues/416
            var type = output.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(output);
            var fullyQualifiedTestName = test.DisplayName;
            return fullyQualifiedTestName.Split('.').Last();
        }
    }
}

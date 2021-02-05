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
    using Microsoft.Azure.Management.DnsResolver.Tests.Extensions.Assertions;
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
        public void PutInboundEndpoint_EndpointNotExistsWithIpConfigurationsNoMetadata_ExpectEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: createdDnsResolver.Name, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations);

            createdInboundEndpoint.Should().BeSuccessfullyCreated();
            createdInboundEndpoint.Metadata.Should().BeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
        }

        [Fact]
        public void PutInboundEndpoint_DnsResolverNotExists_ExpectFailure()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var dnsResolverName = TestDataGenerator.GenerateDnsResolverName();
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var virtualNetworkName = TestDataGenerator.GenerateVirtualNetworkName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: virtualNetworkName);

            Action putInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: dnsResolverName, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations);

            putInboundEndpointAction.Should().NotBeNull();
            putInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PutInboundEndpoint_EndpointNotExistsWithIpConfigurationsAndMetadata_ExpectInboundEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var metadata = TestDataGenerator.GenerateTags();

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: createdDnsResolver.Name, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations, metadata: metadata);

            createdInboundEndpoint.Should().BeSuccessfullyCreated();
            createdInboundEndpoint.Metadata.Should().NotBeNull();
            createdInboundEndpoint.Metadata.Should().BeEquivalentTo(metadata);
            createdInboundEndpoint.IpConfigurations.Should().NotBeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
        }

        [Fact]
        public void PutInboundEndpoint_MultipleIpConfigurationsMetadata_ExpectEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var metadata = TestDataGenerator.GenerateTags();

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: createdDnsResolver.Name, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations, metadata: metadata);

            createdInboundEndpoint.Should().BeSuccessfullyCreated();
            createdInboundEndpoint.Metadata.Should().NotBeNull();
            createdInboundEndpoint.Metadata.Should().BeEquivalentTo(metadata);
            createdInboundEndpoint.IpConfigurations.Should().NotBeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
        }

        [Fact]
        public void PutInboundEndpoint_EndpointNotExistsNoIpConfigurations_ExpectFailure()
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

        [Fact]
        public void PutInboundEndpoint_EndpointExistsUpdateIpConfigurations_ExpectSuccess()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var createdInboundEndpoint = this.CreateInboundEndpoint(createdDnsResolver: createdDnsResolver, resourceGroupName: resourceGroupName);
            var ipConfigurationsForUpdate = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));

            var updatedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: createdInboundEndpoint.Name,
                ipConfigurations: ipConfigurationsForUpdate);

            updatedInboundEndpoint.Name.Should().Be(createdInboundEndpoint.Name);
            updatedInboundEndpoint.ProvisioningState.Should().Be(createdDnsResolver.ProvisioningState);
            updatedInboundEndpoint.Metadata.Should().BeNull();
            updatedInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurationsForUpdate));

        }

        [Fact]
        public void PutInboundEndpoint_IfNoneMatchSuccess_ExpectEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ifNoneMatch: "*",
                ipConfigurations: ipConfigurations);

            createdInboundEndpoint.Should().BeSuccessfullyCreated();
            createdInboundEndpoint.Metadata.Should().BeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
        }

        [Fact]
        public void PutInboundEndpoint_EndpointExistsWithAddMetadata_ExpectEndpointUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations);
            var metadata = TestDataGenerator.GenerateTags();

            var updatedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);

            updatedInboundEndpoint.Name.Should().Be(inboundEndpointName);
            updatedInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            updatedInboundEndpoint.Metadata.Should().NotBeNull();
            updatedInboundEndpoint.Metadata.Should().BeEquivalentTo(metadata);
        }

        [Fact]
        public void PutInboundEndpoint_EndpointExistsIfMatchSuccess_ExpectEndpointUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var metadata = TestDataGenerator.GenerateTags();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);


            var updatedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                ifMatch: createdInboundEndpoint.Etag,
                metadata: null);

            updatedInboundEndpoint.Name.Should().Be(inboundEndpointName);
            updatedInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            updatedInboundEndpoint.Etag.Should().NotBe(createdInboundEndpoint.Etag);
            updatedInboundEndpoint.Metadata.Should().BeNull();
        }

        [Fact]
        public void PutInboundEndpoint_EndpointExistsIfMatchFailure_ExpectFailure()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var metadata = TestDataGenerator.GenerateTags();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);


            Action updateInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                ifMatch: Guid.NewGuid().ToString(),
                metadata: null);

            updateInboundEndpointAction.Should().NotBeNull();
            updateInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public void PatchInboundEndpoint_AddMetadata_ExpectEndpointUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: null);

            var metadata = TestDataGenerator.GenerateTags();
            var updatedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.Update(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);

            updatedInboundEndpoint.Name.Should().Be(inboundEndpointName);
            updatedInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            updatedInboundEndpoint.Metadata.Should().BeEquivalentTo(metadata);
        }

        [Fact]
        public void PatchInboundEndpoint_ndpointExistsIfMatchSuccessRemoveMetadata_ExpectEndpointUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var metadata = TestDataGenerator.GenerateTags();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);

            var updatedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.Update(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                ifMatch: createdInboundEndpoint.Etag,
                metadata: null);

            updatedInboundEndpoint.Name.Should().Be(inboundEndpointName);
            updatedInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            updatedInboundEndpoint.Etag.Should().NotBe(createdInboundEndpoint.Etag);
            updatedInboundEndpoint.Metadata.Should().BeEmpty();
        }

        [Fact]
        public void PatchInboundEndpoint_EndpointNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();

            Action patchInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.Update(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                metadata: null);

            patchInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PatchInboundEndpoint_EmptyRequest_ExpectSuccess()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var metadata = TestDataGenerator.GenerateTags();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count: 2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);

            var updatedDnsResolver = this.DnsResolverManagementClient.InboundEndpoints.Update(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName,
                ipConfigurations: ipConfigurations,
                metadata: metadata);

            updatedDnsResolver.Should().BeSameAsExpected(createdInboundEndpoint);
        }

        [Fact]
        public void GetInboundEndpoint_EndpointExists_ExpecEndpointRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var createdInboundEndpoint = this.CreateInboundEndpoint(createdDnsResolver, resourceGroupName: resourceGroupName, inboundEndpointName: inboundEndpointName);

            var retrievedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.Get(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName);

            retrievedInboundEndpoint.Should().BeSuccessfullyCreated();
        }

        [Fact]
        public void GetListInboundEndpoint_EndpointNotExists_ExpectNotFoundError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);

            Action getInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.Get(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: TestDataGenerator.GenerateInboundEndpointName());

            getInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void ListInboundEndpointsInResourceGroup_MultipleEndpointsPresent_ExpectMultipleEndpointsRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var createdInboundEndpoints = this.CreateInboundEndpoints(createdDnsResolver, resourceGroupName: resourceGroupName);

            var retrievedInboundEndpoints = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);

            retrievedInboundEndpoints.All(inboundEndpoint => ValidateInboundEndpointIsExpected(inboundEndpoint, createdInboundEndpoints));
        }

        [Fact]
        public void ListInboundEndpointsInResourceGroup_WithTopParameter_ExpectSpecifiedEndpointsRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var numInboundEndpoints = 2;
            var top = 1;
            var createdInboundEndpoints = this.CreateInboundEndpoints(createdDnsResolver, resourceGroupName: resourceGroupName, numInboundEndpoints: numInboundEndpoints);
            var expectedInboundEndpoints = createdInboundEndpoints.OrderBy(x => x.Name).Take(top);

            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                top: top);

            var listedInboundEndpoints = listResult.ToArray();
            listedInboundEndpoints.Count().Should().Be(top);
            listedInboundEndpoints.All(inboundEndpoint => ValidateInboundEndpointIsExpected(inboundEndpoint, expectedInboundEndpoints));
        }

        [Fact]
        public void ListInboundEndpointsInResourceGroup_ListNextPage_ExpectNextEndpointsRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var numInboundEndpoints = 2;
            var top = 1;
            var createdInboundEndpoints = this.CreateInboundEndpoints(createdDnsResolver, resourceGroupName: resourceGroupName, numInboundEndpoints: numInboundEndpoints);
            var expectedInboundEndpoints = createdInboundEndpoints.OrderBy(x => x.Name).Skip(top);
            var initialListResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                top: top);


            var nextListResult = this.DnsResolverManagementClient.InboundEndpoints.ListNext(
                initialListResult.NextPageLink);

            var listedInboundEndpoints = nextListResult.ToArray();
            listedInboundEndpoints.Count().Should().Be(numInboundEndpoints - top);
            listedInboundEndpoints.All(inboundEndpoint => ValidateInboundEndpointIsExpected(inboundEndpoint, expectedInboundEndpoints));
        }

        [Fact]
        public void ListInboundEndpointsInResourceGroup_NoEndpointPresents_ExpectNoEndpointRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);

            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);

            listResult.Should().NotBeNull();
            listResult.Count().Should().Be(0);
        }

        [Fact]
        public void DeleteInboundEndpoint_EndpointExists_ExpectEndpointDeleted()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var creatednboundEndpoint = this.CreateInboundEndpoint(createdDnsResolver: createdDnsResolver, resourceGroupName: resourceGroupName);

            this.DnsResolverManagementClient.InboundEndpoints.Delete(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: creatednboundEndpoint.Name);

            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);

            listResult.Should().NotBeNull();
            listResult.Count().Should().Be(0);
        }

        [Fact]
        public void DeleteInboundEndpoint_EndpointExistsIfMatchSuccess_ExpectEndpointDeleted()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var creatednboundEndpoint = this.CreateInboundEndpoint(createdDnsResolver: createdDnsResolver, resourceGroupName: resourceGroupName);

            this.DnsResolverManagementClient.InboundEndpoints.Delete(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: creatednboundEndpoint.Name,
                ifMatch: creatednboundEndpoint.Etag);

            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);

            listResult.Should().NotBeNull();
            listResult.Should().BeEmpty();
        }

        [Fact]
        public void DeleteInboundEndpoint_EndpointExistsIfMatchFailure_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var creatednboundEndpoint = this.CreateInboundEndpoint(createdDnsResolver: createdDnsResolver, resourceGroupName: resourceGroupName);

            Action deleteInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.Delete(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: creatednboundEndpoint.Name,
                ifMatch: new Guid().ToString());

            deleteInboundEndpointAction.Should().NotBeNull();
            deleteInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
            var retrievedInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.Get(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: creatednboundEndpoint.Name);

            retrievedInboundEndpoint.Should().BeSameAsExpected(creatednboundEndpoint);
        }


        [Fact]
        public void DeleteInboundEndpoint_EndpointNotExists_ExpectNoError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();

            Action deleteInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.Delete(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointName);

            deleteInboundEndpointAction.Should().NotBeNull();
            deleteInboundEndpointAction.Should().NotThrow();

            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);

            listResult.Should().NotBeNull();
            listResult.Should().BeEmpty();
        }

        [Fact]
        public void DeleteInboundEndpoint_MultipleEndpointsPresentDeleteOne_ExpectOneEndpointDeleted()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var numInboundEndpoints = 2;
            var createdInboundEndpoints = this.CreateInboundEndpoints(createdDnsResolver, resourceGroupName: resourceGroupName, numInboundEndpoints: numInboundEndpoints);
            var orderedInboundEndpoints = createdInboundEndpoints.OrderBy(x => x.Name);
            var inboundEndpointForDeletion = orderedInboundEndpoints.First();
            var expectedInboundEndpoints = orderedInboundEndpoints.Skip(1);

            Action deleteInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.Delete(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name,
                inboundEndpointName: inboundEndpointForDeletion.Name);

            deleteInboundEndpointAction.Should().NotBeNull();
            deleteInboundEndpointAction.Should().NotThrow();

            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);

            listResult.Should().NotBeNull();
            listResult.Count().Should().Be(1);
            listResult.All(inboundEndpoint => ValidateInboundEndpointIsExpected(inboundEndpoint, expectedInboundEndpoints));
        }


        private static bool ValidateIpConfigurationIsExpected(IpConfiguration ipConfigurationForValidation, IEnumerable<IpConfiguration> expectedIpConfigurations)
        {
            return expectedIpConfigurations.Any(
                expectedIpConfiguration => string.Equals(expectedIpConfiguration.Subnet.Id, ipConfigurationForValidation.Subnet.Id, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(expectedIpConfiguration.PrivateIpAllocationMethod, ipConfigurationForValidation.PrivateIpAllocationMethod, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(expectedIpConfiguration.PrivateIpAddress, ipConfigurationForValidation.PrivateIpAddress, StringComparison.OrdinalIgnoreCase));
        }

        private static bool ValidateInboundEndpointIsExpected(InboundEndpoint inboundEndpointForValidation, IEnumerable<InboundEndpoint> expectedInboundEndpoints)
        {
            return expectedInboundEndpoints.Any(
                expectedInboundEndpoint => string.Equals(expectedInboundEndpoint.Id, inboundEndpointForValidation.Id, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(expectedInboundEndpoint.Name, inboundEndpointForValidation.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}


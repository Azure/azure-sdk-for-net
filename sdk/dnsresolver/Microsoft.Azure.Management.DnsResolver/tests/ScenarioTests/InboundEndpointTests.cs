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
        public void PutInboundEndpoint_InboundEndpointNotExistsWithIpConfigurationsNoMetadata_ExpectInboundEndpointCreated()
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
            createdInboundEndpoint.Metadata.Should().BeEquivalentTo(metadata);
            createdInboundEndpoint.IpConfigurations.Should().NotBeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
        }

        [Fact]
        public void PutInboundEndpoint_InboundEndpointNotExistsWithMultipleIpConfigurationsAndMetadata_ExpectInboundEndpointCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();
            var ipConfigurations = TestDataGenerator.GenerateRandomIpConfigurations(count:2, subscriptionId: this.SubscriptionId, resourceGroupName: resourceGroupName, virtualNetworkName: ExtractArmResourceName(createdDnsResolver.VirtualNetwork.Id));
            var metadata = TestDataGenerator.GenerateTags();

            var createdInboundEndpoint = this.DnsResolverManagementClient.InboundEndpoints.CreateOrUpdate(resourceGroupName: resourceGroupName, dnsResolverName: createdDnsResolver.Name, inboundEndpointName: inboundEndpointName, ipConfigurations: ipConfigurations, metadata: metadata);

            createdInboundEndpoint.Name.Should().Be(inboundEndpointName);
            createdInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            createdInboundEndpoint.Metadata.Should().NotBeNull();
            createdInboundEndpoint.Metadata.Should().BeEquivalentTo(metadata);
            createdInboundEndpoint.IpConfigurations.Should().NotBeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
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

        [Fact]
        public void PutInboundEndpoint_IfNoneMatchSuccess_ExpectInboundEndpointCreated()
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

            createdInboundEndpoint.Name.Should().Be(inboundEndpointName);
            createdInboundEndpoint.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            createdInboundEndpoint.Metadata.Should().BeNull();
            createdInboundEndpoint.IpConfigurations.All(ipConfiguration => ValidateIpConfigurationIsExpected(ipConfiguration, ipConfigurations));
        }

        [Fact]
        public void PutInboundEndpoint_InboundEndpointExistsWithAddMetadata_ExpectInboundEndpointUpdated()
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
        public void PutInboundEndpoint_InboundEndpointExistsIfMatchSuccess_ExpectInboundEndpointUpdated()
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
        public void PutInboundEndpoint_InboundEndpointExistsIfMatchFailure_ExpectFailure()
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
        public void PatchInboundEndpoint_AddMetadata_ExpectInboundEndpointUpdated()
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
        public void PatchInboundEndpoint_InboundEndpointExistsIfMatchSuccessRemoveMetadata_ExpectInboundEndpointUpdated()
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
            updatedInboundEndpoint.Etag.Should().NotBe(updatedInboundEndpoint.Etag);
            updatedInboundEndpoint.Metadata.Should().BeEmpty();
        }

        [Fact]
        public void PatchInboundEndpoint_InboundEndpointNotExists_ExpectError()
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

            updatedDnsResolver.Should().NotBeNull();
            updatedDnsResolver.ProvisioningState.Should().BeEquivalentTo(Constants.ProvisioningStateSucceeded);
        }

        [Fact]
        public void GetInboundEndpoint_InboundEndpointExists_ExpectInboundEndpointRetrieved()
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
        public void GetListInboundEndpoint_InboundEndpointNotExists_ExpectNotFoundError()
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
        public void ListInboundEndpointsInResourceGroup_MultipleInboundEndpointsPresent_ExpectMultipleInboundEndpointsRetrieved() 
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
        public void ListInboundEndpointsInResourceGroup_WithTopParameter_ExpectSpecifiedInboundEndpointsRetrieved()
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
        public void ListInboundEndpointsInResourceGroup_ListNextPage_ExpectNextInboundEndpointsRetrieved()
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
        public void ListInboundEndpointsInResourceGroup_NoInboundEndpointPresents_ExpectNoInboundEndpointRetrieved()
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
        public void DeleteInboundEndpoint_InboundEndpointExists_ExpectInboundEndpointDeleted()
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
        public void DeleteInboundEndpoint_InboundEndpointExistsIfMatchSuccess_ExpectInboundEndpointDeleted()
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
            listResult.Count().Should().Be(0);
        }

        [Fact]
        public void DeleteInboundEndpoint_InboundEndpointExistsIfMatchFailure_ExpectError()
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
            var listResult = this.DnsResolverManagementClient.InboundEndpoints.List(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name);
            listResult.Should().NotBeNull();
            listResult.Count().Should().Be(1);
        }


        [Fact]
        public void DeleteInboundEndpoint_InboundEndpointNotExists_ExpectNotFoundError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdDnsResolver = this.CreateDnsResolver(resourceGroupName: resourceGroupName);
            var inboundEndpointName = TestDataGenerator.GenerateInboundEndpointName();

            Action deleteInboundEndpointAction = () => this.DnsResolverManagementClient.InboundEndpoints.Delete(
                resourceGroupName: resourceGroupName,
                dnsResolverName: createdDnsResolver.Name, 
                inboundEndpointName: inboundEndpointName);

            deleteInboundEndpointAction.Should().NotBeNull();
            deleteInboundEndpointAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
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


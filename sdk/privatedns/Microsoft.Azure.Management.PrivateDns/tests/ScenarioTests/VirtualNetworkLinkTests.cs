// ------------------------------------------------------------------------------------------------
// <copyright file="VirtualNetworkLinkScenarioTests.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using FluentAssertions;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.PrivateDns;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using PrivateDns.Tests.Extensions;
    using PrivateDns.Tests.Helpers;
    using Xunit;
    using Xunit.Abstractions;

    public class VirtualNetworkLinkScenarioTests : BaseScenarioTests
    {
        public VirtualNetworkLinkScenarioTests(ITestOutputHelper output)
            : base(output)
        {
            this.NetworkManagementClient = ClientFactory.GetNetworkClient(this.TestContext, this.ResourceHandler);
        }

        private NetworkManagementClient NetworkManagementClient { get; set; }

        [Fact]
        public void PutLink_LinkNotExistsWithoutRegistration_ExpectLinkCreated()
        {
            this.PutLink_LinkNotExists_ExpectLinkCreated(registrationEnabled: false);
        }

        [Fact]
        public void PutLink_LinkNotExistsWithRegistration_ExpectLinkCreated()
        {
            this.PutLink_LinkNotExists_ExpectLinkCreated(registrationEnabled: true);
        }

        [Fact]
        public void PutLink_LinkNotExistsIfNoneMatchSuccess_ExpectLinkCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var virtualNetworkId = this.CreateVirtualNetwork(resourceGroupName).Id;
            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            var createdVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: virtualNetworkLinkName,
                ifNoneMatch: "*",
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(location: Constants.PrivateDnsZonesVirtualNetworkLinksLocation, virtualNetworkId: virtualNetworkId, registrationEnabled: false));

            createdVirtualNetworkLink.Should().NotBeNull();
            createdVirtualNetworkLink.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
        }

        [Fact]
        public void PutLink_LinkExistsIfMatchSuccess_ExpectLinkUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName);

            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                ifMatch: createdVirtualNetworkLink.Etag,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(location: createdVirtualNetworkLink.Location, virtualNetworkId: createdVirtualNetworkLink.VirtualNetwork.Id, registrationEnabled: createdVirtualNetworkLink.RegistrationEnabled));

            updatedVirtualNetworkLink.Should().NotBeNull();
            updatedVirtualNetworkLink.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            updatedVirtualNetworkLink.Etag.Should().NotBeNullOrEmpty().And.NotBe(createdVirtualNetworkLink.Etag);
        }

        [Fact]
        public void PutLink_LinkExistsIfMatchFailure_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName);

            Action updatedVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                ifMatch: Guid.NewGuid().ToString(),
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(location: createdVirtualNetworkLink.Location, virtualNetworkId: createdVirtualNetworkLink.VirtualNetwork.Id, registrationEnabled: createdVirtualNetworkLink.RegistrationEnabled));

            updatedVirtualNetworkLinkAction.Should().Throw<CloudException>().Which.Response.ExtractAsyncErrorCode().Should().Be(HttpStatusCode.PreconditionFailed.ToString());
        }

        [Fact]
        public void PatchLink_ZoneNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = TestDataGenerator.GeneratePrivateZoneName();
            var virtualNetworkId = TestDataGenerator.GenerateVirtualNetworkArmId(this.SubscriptionId);
            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            Action updatedVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: virtualNetworkLinkName,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(location: Constants.PrivateDnsZonesVirtualNetworkLinksLocation, virtualNetworkId: virtualNetworkId, registrationEnabled: false));

            updatedVirtualNetworkLinkAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PatchLink_LinkNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var virtualNetworkId = TestDataGenerator.GenerateVirtualNetworkArmId(this.SubscriptionId);
            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            Action updateVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: virtualNetworkLinkName,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(location: Constants.PrivateDnsZonesVirtualNetworkLinksLocation, virtualNetworkId: virtualNetworkId, registrationEnabled: false));

            updateVirtualNetworkLinkAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PatchLink_LinkExistsEmptyRequest_ExpectNoError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName);

            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink());

            updatedVirtualNetworkLink.Should().NotBeNull();
        }

        [Fact]
        public void PatchLink_EnableRegistration_ExpectRegistrationEnabled()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName, registrationEnabled: false);

            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(registrationEnabled: true));

            updatedVirtualNetworkLink.RegistrationEnabled.Should().BeTrue();
        }

        [Fact]
        public void PatchLink_DisableRegistration_ExpectRegistrationDisabled()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName, registrationEnabled: true);

            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(registrationEnabled: false));

            updatedVirtualNetworkLink.RegistrationEnabled.Should().BeFalse();
        }

        [Fact]
        public void PatchLink_LinkExistsAddTags_ExpectTagsAdded()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName, tags: null);

            var virtualNetworkLinkTags = TestDataGenerator.GenerateTags();
            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(tags: virtualNetworkLinkTags));

            updatedVirtualNetworkLink.Should().NotBeNull();
            updatedVirtualNetworkLink.Tags.Should().NotBeNull().And.BeEquivalentTo(virtualNetworkLinkTags);
        }

        [Fact]
        public void PatchLink_LinkExistsChangeTags_ExpectTagsChanged()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName, tags: TestDataGenerator.GenerateTags());

            var updatedVirtualNetworkLinkTags = TestDataGenerator.GenerateTags(startFrom: createdVirtualNetworkLink.Tags.Count);
            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(tags: updatedVirtualNetworkLinkTags));

            updatedVirtualNetworkLink.Should().NotBeNull();
            updatedVirtualNetworkLink.Tags.Should().NotBeNull().And.BeEquivalentTo(updatedVirtualNetworkLinkTags);
        }

        [Fact]
        public void PatchLink_LinkExistsRemoveTags_ExpectTagsRemoved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName, tags: TestDataGenerator.GenerateTags());

            var updatedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(tags: new Dictionary<string, string>()));

            updatedVirtualNetworkLink.Should().NotBeNull();
            updatedVirtualNetworkLink.Tags.Should().BeEmpty();
        }

        [Fact]
        public void PatchLink_LinkExistsChangeVirtualNetwork_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLink = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName, tags: TestDataGenerator.GenerateTags());

            var updatedVirtualNetworkId = TestDataGenerator.GenerateVirtualNetworkArmId(this.SubscriptionId);
            Action updateVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: createdVirtualNetworkLink.Name,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(virtualNetworkId: updatedVirtualNetworkId));

            updateVirtualNetworkLinkAction.Should().Throw<CloudException>().Which.Response.ExtractAsyncErrorCode().Should().Be(HttpStatusCode.BadRequest.ToString());
        }

        [Fact]
        public void GetLink_ZoneNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var nonExistentPrivateZoneName = TestDataGenerator.GeneratePrivateZoneName();
            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            Action retrieveVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Get(resourceGroupName, nonExistentPrivateZoneName, virtualNetworkLinkName);
            retrieveVirtualNetworkLinkAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void GetLink_LinkNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var nonExistentVirtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            Action retrieveVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Get(resourceGroupName, privateZoneName, nonExistentVirtualNetworkLinkName);
            retrieveVirtualNetworkLinkAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void GetLink_LinkExists_ExpectLinkRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var virtualNetworkLinkName = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName).Name;

            var retrievedVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.Get(resourceGroupName, privateZoneName, virtualNetworkLinkName);
            retrievedVirtualNetworkLink.Should().NotBeNull();
            retrievedVirtualNetworkLink.Id.Should().Be(TestDataGenerator.GenerateVirtualNetworkLinkArmId(this.SubscriptionId, resourceGroupName, privateZoneName, virtualNetworkLinkName));
            retrievedVirtualNetworkLink.Name.Should().Be(virtualNetworkLinkName);
            retrievedVirtualNetworkLink.Type.Should().Be(Constants.PrivateDnsZonesVirtualNetworkLinksResourceType);
            retrievedVirtualNetworkLink.Location.Should().Be(Constants.PrivateDnsZonesVirtualNetworkLinksLocation);
        }

        [Fact]
        public void ListLinks_NoLinksPresent_ExpectNoLinksRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var listResult = this.PrivateDnsManagementClient.VirtualNetworkLinks.List(resourceGroupName, privateZoneName);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listVirtualNetworkLinks = listResult.ToArray();
            listVirtualNetworkLinks.Count().Should().Be(0);
        }

        [Fact]
        public void ListLinks_MultipleLinksPresent_ExpectMultipleLinksRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLinks = this.CreateVirtualNetworkLinks(resourceGroupName, privateZoneName);

            var listResult = this.PrivateDnsManagementClient.VirtualNetworkLinks.List(resourceGroupName, privateZoneName);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listVirtualNetworkLinks = listResult.ToArray();
            listVirtualNetworkLinks.Count().Should().Be(createdVirtualNetworkLinks.Count());
            listVirtualNetworkLinks.All(listedVirtualNetworkLink => ValidateListedVirtualNetworkLinkIsExpected(listedVirtualNetworkLink, createdVirtualNetworkLinks));
        }

        [Fact]
        public void ListLinks_WithTopParameter_ExpectSpecifiedLinksRetrieved()
        {
            const int numVirtualNetworkLinks = 2;
            const int topValue = numVirtualNetworkLinks - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLinks = this.CreateVirtualNetworkLinks(resourceGroupName, privateZoneName, numVirtualNetworkLinks: numVirtualNetworkLinks);
            var expectedVirtualNetworkLinks = createdVirtualNetworkLinks.OrderBy(x => x.Name).Take(topValue);

            var listResult = this.PrivateDnsManagementClient.VirtualNetworkLinks.List(resourceGroupName, privateZoneName, top: topValue);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().NotBeNullOrEmpty();

            var listVirtualNetworkLinks = listResult.ToArray();
            listVirtualNetworkLinks.Count().Should().Be(topValue);
            listVirtualNetworkLinks.All(listedVirtualNetworkLink => ValidateListedVirtualNetworkLinkIsExpected(listedVirtualNetworkLink, expectedVirtualNetworkLinks));
        }

        [Fact]
        public void ListLinks_ListNextPage_ExpectNextLinksRetrieved()
        {
            const int numVirtualNetworkLinks = 2;
            const int topValue = numVirtualNetworkLinks - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdVirtualNetworkLinks = this.CreateVirtualNetworkLinks(resourceGroupName, privateZoneName, numVirtualNetworkLinks: numVirtualNetworkLinks);
            var expectedNextVirtualNetworkLinks = createdVirtualNetworkLinks.OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.VirtualNetworkLinks.List(resourceGroupName, privateZoneName, top: topValue);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.VirtualNetworkLinks.ListNext(nextLink);
            nextListResult.Should().NotBeNull();
            nextListResult.NextPageLink.Should().BeNull();

            var nextListedVirtualNetworkLinks = nextListResult.ToArray();
            nextListedVirtualNetworkLinks.Count().Should().Be(topValue);
            nextListedVirtualNetworkLinks.All(listedVirtualNetworkLink => ValidateListedVirtualNetworkLinkIsExpected(listedVirtualNetworkLink, expectedNextVirtualNetworkLinks));
        }

        [Fact]
        public void DeleteLink_ZoneNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var nonExistentPrivateZoneName = TestDataGenerator.GeneratePrivateZoneName();
            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            Action deleteVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Delete(resourceGroupName, nonExistentPrivateZoneName, virtualNetworkLinkName);
            deleteVirtualNetworkLinkAction.Should().NotThrow();
        }

        [Fact]
        public void DeleteLink_LinkNotExists_ExpectNoError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var nonExistentVirtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            Action deleteVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Delete(resourceGroupName, privateZoneName, nonExistentVirtualNetworkLinkName);
            deleteVirtualNetworkLinkAction.Should().NotThrow();
        }

        [Fact]
        public void DeleteLink_LinkExists_ExpectLinkDeleted()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var virtualNetworkLinkName = this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName).Name;

            Action deleteVirtualNetworkLinkAction = () => this.PrivateDnsManagementClient.VirtualNetworkLinks.Delete(resourceGroupName, privateZoneName, virtualNetworkLinkName);
            deleteVirtualNetworkLinkAction.Should().NotThrow();

        }

        private void PutLink_LinkNotExists_ExpectLinkCreated(bool registrationEnabled)
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var virtualNetworkId = this.CreateVirtualNetwork(resourceGroupName).Id;

            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();
            var virtualNetworkLinkParams = TestDataGenerator.GenerateVirtualNetworkLink(
                location: Constants.PrivateDnsZonesVirtualNetworkLinksLocation,
                virtualNetworkId: virtualNetworkId,
                registrationEnabled: registrationEnabled);

            var createdVirtualNetworkLink = this.PrivateDnsManagementClient.VirtualNetworkLinks.CreateOrUpdate(resourceGroupName, privateZoneName, virtualNetworkLinkName, virtualNetworkLinkParams);
            createdVirtualNetworkLink.Should().NotBeNull();
            createdVirtualNetworkLink.Id.Should().Be(TestDataGenerator.GenerateVirtualNetworkLinkArmId(this.SubscriptionId, resourceGroupName, privateZoneName, virtualNetworkLinkName));
            createdVirtualNetworkLink.Name.Should().Be(virtualNetworkLinkName);
            createdVirtualNetworkLink.Location.Should().Be(Constants.PrivateDnsZonesVirtualNetworkLinksLocation);
            createdVirtualNetworkLink.Type.Should().Be(Constants.PrivateDnsZonesVirtualNetworkLinksResourceType);
            createdVirtualNetworkLink.Etag.Should().NotBeNullOrEmpty();
            createdVirtualNetworkLink.VirtualNetwork.Should().NotBeNull();
            createdVirtualNetworkLink.VirtualNetwork.Id.Should().Be(virtualNetworkId);
            createdVirtualNetworkLink.RegistrationEnabled.Should().Be(registrationEnabled);
            createdVirtualNetworkLink.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            createdVirtualNetworkLink.VirtualNetworkLinkState.Should().Be(registrationEnabled ? Constants.VirtualNetworkLinkStateInProgress : Constants.VirtualNetworkLinkStateCompleted);
            createdVirtualNetworkLink.Tags.Should().BeNull();
        }

        private VirtualNetwork CreateVirtualNetwork(string resourceGroupName, string virtualNetworkName = null)
        {
            virtualNetworkName = virtualNetworkName ?? TestDataGenerator.GenerateVirtualNetworkName();

            var createdVirtualNetwork = this.NetworkManagementClient.CreateVirtualNetwork(resourceGroupName: resourceGroupName, virtualNetworkName: virtualNetworkName);

            createdVirtualNetwork.Should().NotBeNull();
            return createdVirtualNetwork;
        }

        private VirtualNetworkLink CreateVirtualNetworkLink(
            string resourceGroupName,
            string privateZoneName,
            bool registrationEnabled = false,
            IDictionary<string, string> tags = null)
        {
            var virtualNetworkId = this.CreateVirtualNetwork(resourceGroupName).Id;
            var virtualNetworkLinkName = TestDataGenerator.GenerateVirtualNetworkLinkName();

            return this.PrivateDnsManagementClient.VirtualNetworkLinks.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                virtualNetworkLinkName: virtualNetworkLinkName,
                parameters: TestDataGenerator.GenerateVirtualNetworkLink(
                    location: Constants.PrivateDnsZonesVirtualNetworkLinksLocation,
                    virtualNetworkId: virtualNetworkId,
                    registrationEnabled: registrationEnabled,
                    tags: tags));
        }

        private ICollection<VirtualNetworkLink> CreateVirtualNetworkLinks(string resourceGroupName, string privateZoneName, int numVirtualNetworkLinks = 2)
        {
            var createdVirtualNetworkLinks = new List<VirtualNetworkLink>();
            for (var i = 0; i < numVirtualNetworkLinks; i++)
            {
                createdVirtualNetworkLinks.Add(this.CreateVirtualNetworkLink(resourceGroupName, privateZoneName));
            }

            return createdVirtualNetworkLinks;
        }

        private static bool ValidateListedVirtualNetworkLinkIsExpected(VirtualNetworkLink listedVirtualNetworkLink, IEnumerable<VirtualNetworkLink> expectedVirtualNetworkLinks)
        {
            return expectedVirtualNetworkLinks.Any(expectedVirtualNetworkLink => string.Equals(expectedVirtualNetworkLink.Id, listedVirtualNetworkLink.Id, StringComparison.OrdinalIgnoreCase));
        }
    }
}

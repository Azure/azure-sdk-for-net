// ------------------------------------------------------------------------------------------------
// <copyright file="PrivateZoneScenarioTests.cs" company="Microsoft Corporation">
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
    using Microsoft.Azure.Management.PrivateDns;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using PrivateDns.Tests.Extensions;
    using Xunit;
    using Xunit.Abstractions;

    public class PrivateZoneScenarioTests : BaseScenarioTests
    {
        public PrivateZoneScenarioTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        public void PutZone_ZoneNotExists_ExpectZoneCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = TestDataGenerator.GeneratePrivateZoneName();

            var createdPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation));

            createdPrivateZone.Should().NotBeNull();
            createdPrivateZone.Id.Should().Be(TestDataGenerator.GeneratePrivateZoneArmId(this.SubscriptionId, resourceGroupName, privateZoneName));
            createdPrivateZone.Name.Should().Be(privateZoneName);
            createdPrivateZone.Location.Should().Be(Constants.PrivateDnsZonesLocation);
            createdPrivateZone.Type.Should().Be(Constants.PrivateDnsZonesResourceType);
            createdPrivateZone.Etag.Should().NotBeNullOrEmpty();
            createdPrivateZone.Tags.Should().BeNull();
            createdPrivateZone.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            createdPrivateZone.MaxNumberOfRecordSets.Should().BePositive();
            createdPrivateZone.MaxNumberOfVirtualNetworkLinks.Should().BePositive();
            createdPrivateZone.MaxNumberOfVirtualNetworkLinksWithRegistration.Should().BePositive();
            createdPrivateZone.NumberOfRecordSets.Should().Be(1);
            createdPrivateZone.NumberOfVirtualNetworkLinks.Should().Be(0);
            createdPrivateZone.NumberOfVirtualNetworkLinksWithRegistration.Should().Be(0);
        }

        [Fact]
        public void PutZone_ZoneNotExistsWithTags_ExpectZoneCreatedWithTags()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;

            var privateZoneName = TestDataGenerator.GeneratePrivateZoneName();
            var privateZoneTags = TestDataGenerator.GenerateTags();

            var createdPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation, tags: privateZoneTags));

            createdPrivateZone.Should().NotBeNull();
            createdPrivateZone.Tags.Should().NotBeNull().And.BeEquivalentTo(privateZoneTags);
        }

        [Fact]
        public void PutZone_ZoneNotExistsIfNoneMatchSuccess_ExpectZoneCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = TestDataGenerator.GeneratePrivateZoneName();

            var createdPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                ifNoneMatch: "*",
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation));

            createdPrivateZone.Should().NotBeNull();
            createdPrivateZone.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
        }

        [Fact]
        public void PutZone_ZoneExistsIfMatchSuccess_ExpectZoneUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName);

            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                ifMatch: createdPrivateZone.Etag,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.ProvisioningState.Should().Be(Constants.ProvisioningStateSucceeded);
            updatedPrivateZone.Etag.Should().NotBeNullOrEmpty().And.NotBe(createdPrivateZone.Etag);
        }

        [Fact]
        public void PutZone_ZoneExistsIfMatchFailure_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName);

            Action updatedPrivateZoneAction = () => this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                ifMatch: Guid.NewGuid().ToString(),
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation));

            updatedPrivateZoneAction.Should().Throw<CloudException>().Which.Response.ExtractAsyncErrorCode().Should().Be(HttpStatusCode.PreconditionFailed.ToString());
        }

        [Fact]
        public void PutZone_ZoneExistsAddTags_ExpectTagsAdded()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName, tags: null);

            var privateZoneTags = TestDataGenerator.GenerateTags();
            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation, tags: privateZoneTags));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.Tags.Should().NotBeNull().And.BeEquivalentTo(privateZoneTags);
        }

        [Fact]
        public void PutZone_ZoneExistsChangeTags_ExpectTagsChanged()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName, tags: TestDataGenerator.GenerateTags());

            var updatedPrivateZoneTags = TestDataGenerator.GenerateTags(startFrom: createdPrivateZone.Tags.Count);
            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation, tags: updatedPrivateZoneTags));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.Tags.Should().NotBeNull().And.BeEquivalentTo(updatedPrivateZoneTags);
        }

        [Fact]
        public void PutZone_ZoneExistsRemoveTags_ExpectTagsRemoved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName, tags: TestDataGenerator.GenerateTags());

            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation, tags: null));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.Tags.Should().BeNull();
        }

        [Fact]
        public void PatchZone_ZoneNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = TestDataGenerator.GeneratePrivateZoneName();

            Action updateZoneAction = () => this.PrivateDnsManagementClient.PrivateZones.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                parameters: TestDataGenerator.GeneratePrivateZone());

            updateZoneAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PatchZone_ZoneExistsEmptyRequest_ExpectNoError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName);

            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone());

            updatedPrivateZone.Should().NotBeNull();
        }

        [Fact]
        public void PatchZone_ZoneExistsAddTags_ExpectTagsAdded()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName, tags: null);

            var privateZoneTags = TestDataGenerator.GenerateTags();
            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone(tags: privateZoneTags));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.Tags.Should().NotBeNull().And.BeEquivalentTo(privateZoneTags);
        }

        [Fact]
        public void PatchZone_ZoneExistsChangeTags_ExpectTagsChanged()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName, tags: TestDataGenerator.GenerateTags());

            var updatedPrivateZoneTags = TestDataGenerator.GenerateTags(startFrom: createdPrivateZone.Tags.Count);
            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone(tags: updatedPrivateZoneTags));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.Tags.Should().NotBeNull().And.BeEquivalentTo(updatedPrivateZoneTags);
        }

        [Fact]
        public void PatchZone_ZoneExistsRemoveTags_ExpectTagsRemoved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName, tags: TestDataGenerator.GenerateTags());

            var updatedPrivateZone = this.PrivateDnsManagementClient.PrivateZones.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: createdPrivateZone.Name,
                parameters: TestDataGenerator.GeneratePrivateZone(tags: new Dictionary<string, string>()));

            updatedPrivateZone.Should().NotBeNull();
            updatedPrivateZone.Tags.Should().BeEmpty();
        }

        [Fact]
        public void GetZone_ZoneExists_ExpectZoneRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName);

            var retrievedZone = this.PrivateDnsManagementClient.PrivateZones.Get(resourceGroupName, createdPrivateZone.Name);
            retrievedZone.Should().NotBeNull();
            retrievedZone.Id.Should().Be(TestDataGenerator.GeneratePrivateZoneArmId(this.SubscriptionId, resourceGroupName, createdPrivateZone.Name));
            retrievedZone.Name.Should().Be(createdPrivateZone.Name);
            retrievedZone.Type.Should().Be(Constants.PrivateDnsZonesResourceType);
            retrievedZone.Location.Should().Be(Constants.PrivateDnsZonesLocation);
        }

        [Fact]
        public void GetZone_ZoneNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var nonExistentPrivateZoneName = TestDataGenerator.GeneratePrivateZoneName();

            Action retrieveZoneAction = () => this.PrivateDnsManagementClient.PrivateZones.Get(resourceGroupName, nonExistentPrivateZoneName);
            retrieveZoneAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void ListZonesInSubscription_MultipleZonesPresent_ExpectMultipleZonesRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZones = this.CreatePrivateZones(resourceGroupName);

            var listResult = this.PrivateDnsManagementClient.PrivateZones.List();
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedZones = listResult.ToArray();
            listedZones.Count().Should().BeGreaterOrEqualTo(createdPrivateZones.Count());
            listedZones.All(listedZone => ValidateListedZoneIsExpected(listedZone, createdPrivateZones));
        }

        [Fact]
        public void ListZonesInSubscription_WithTopParameter_ExpectSpecifiedZonesRetrieved()
        {
            const int numPrivateZones = 2;
            const int topValue = numPrivateZones - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZones = this.CreatePrivateZones(resourceGroupName, numPrivateZones: numPrivateZones);
            var expectedZones = createdPrivateZones.OrderBy(x => x.Name).Take(topValue);

            var listResult = this.PrivateDnsManagementClient.PrivateZones.List(top: topValue);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().NotBeNullOrEmpty();

            var listedZones = listResult.ToArray();
            listedZones.Count().Should().Be(topValue);
        }

        [Fact]
        public void ListZonesInSubscription_ListNextPage_ExpectNextZonesRetrieved()
        {
            const int numPrivateZones = 2;
            const int topValue = numPrivateZones - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZones = this.CreatePrivateZones(resourceGroupName, numPrivateZones: numPrivateZones);
            var expectedNextZones = createdPrivateZones.OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.PrivateZones.List(top: topValue);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.PrivateZones.ListNext(nextLink);
            nextListResult.Should().NotBeNull();

            var nextListedZones = nextListResult.ToArray();
            nextListedZones.Count().Should().Be(topValue);
        }

        [Fact]
        public void ListZonesInResourceGroup_NoZonesPresent_ExpectNoZonesRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var extraResourceGroupName = this.CreateResourceGroup().Name;

            var createdExtraPrivateZones = this.CreatePrivateZones(extraResourceGroupName, numPrivateZones: 1);

            var listResult = this.PrivateDnsManagementClient.PrivateZones.ListByResourceGroup(resourceGroupName);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedZones = listResult.ToArray();
            listedZones.Count().Should().Be(0);
        }

        [Fact]
        public void ListZonesInResourceGroup_MultipleZonesPresent_ExpectMultipleZonesRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var extraResourceGroupName = this.CreateResourceGroup().Name;

            var createdPrivateZones = this.CreatePrivateZones(resourceGroupName);
            var createdExtraPrivateZones = this.CreatePrivateZones(extraResourceGroupName, numPrivateZones: 1);

            var listResult = this.PrivateDnsManagementClient.PrivateZones.ListByResourceGroup(resourceGroupName);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedZones = listResult.ToArray();
            listedZones.Count().Should().Be(createdPrivateZones.Count());
            listedZones.All(listedZone => ValidateListedZoneIsExpected(listedZone, createdPrivateZones));
        }

        [Fact]
        public void ListZonesInResourceGroup_WithTopParameter_ExpectSpecifiedZonesRetrieved()
        {
            const int numPrivateZones = 2;
            const int topValue = numPrivateZones - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var extraResourceGroupName = this.CreateResourceGroup().Name;

            var createdPrivateZones = this.CreatePrivateZones(resourceGroupName, numPrivateZones: numPrivateZones);
            var createdExtraPrivateZones = this.CreatePrivateZones(extraResourceGroupName, numPrivateZones: 1);

            var expectedZones = createdPrivateZones.OrderBy(x => x.Name).Take(topValue);

            var listResult = this.PrivateDnsManagementClient.PrivateZones.ListByResourceGroup(resourceGroupName, top: topValue);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().NotBeNullOrEmpty();

            var listedZones = listResult.ToArray();
            listedZones.Count().Should().Be(topValue);
            listedZones.All(listedZone => ValidateListedZoneIsExpected(listedZone, expectedZones));
        }

        [Fact]
        public void ListZonesInResourceGroup_ListNextPage_ExpectNextZonesRetrieved()
        {
            const int numPrivateZones = 2;
            const int topValue = numPrivateZones - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var extraResourceGroupName = this.CreateResourceGroup().Name;

            var createdPrivateZones = this.CreatePrivateZones(resourceGroupName, numPrivateZones: numPrivateZones);
            var createdExtraPrivateZones = this.CreatePrivateZones(extraResourceGroupName, numPrivateZones: 1);

            var expectedNextZones = createdPrivateZones.OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.PrivateZones.ListByResourceGroup(resourceGroupName, top: topValue);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.PrivateZones.ListByResourceGroupNext(nextLink);
            nextListResult.Should().NotBeNull();
            nextListResult.NextPageLink.Should().BeNull();

            var nextListedZones = nextListResult.ToArray();
            nextListedZones.Count().Should().Be(topValue);
            nextListedZones.All(listedZone => ValidateListedZoneIsExpected(listedZone, expectedNextZones));
        }

        [Fact]
        public void DeleteZone_ZoneExists_ExpectZoneDeleted()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var createdPrivateZone = this.CreatePrivateZone(resourceGroupName);

            Action deleteZoneAction = () => this.PrivateDnsManagementClient.PrivateZones.Delete(resourceGroupName, createdPrivateZone.Name);
            deleteZoneAction.Should().NotThrow();
        }

        [Fact]
        public void DeleteZone_ZoneNotExists_ExpectNoError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var nonExistentPrivateZoneName = TestDataGenerator.GeneratePrivateZoneName();

            Action deleteZoneAction = () => this.PrivateDnsManagementClient.PrivateZones.Delete(resourceGroupName, nonExistentPrivateZoneName);
            deleteZoneAction.Should().NotThrow();
        }

        private static bool ValidateListedZoneIsExpected(PrivateZone listedZone, IEnumerable<PrivateZone> expectedZones)
        {
            return expectedZones.Any(expectedZone => string.Equals(expectedZone.Id, listedZone.Id, StringComparison.OrdinalIgnoreCase));
        }
    }
}

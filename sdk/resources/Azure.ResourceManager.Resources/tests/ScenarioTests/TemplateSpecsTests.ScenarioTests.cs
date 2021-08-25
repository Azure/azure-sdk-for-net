// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

using static FluentAssertions.FluentActions;

namespace Azure.ResourceManager.Resources.Tests.ScenarioTests
{
    public class LiveTemplateSpecsTests : ResourceOperationsTestsBase
    {
        private const string TestLocation = "westus";

        private static readonly ResourceGroup TestResourceGroup = new(TestLocation);

        public LiveTemplateSpecsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task TemplateSpec_Crud_Succeeds()
        {
            var resourceGroupName = NewResourceGroupName();
            var resourceGroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, TestResourceGroup)).Value;

            var templateSpecName = NewTemplateSpecName();
            var templateSpecToCreate = new TemplateSpec(TestLocation)
            {
                Description = "Description of my Template Spec",
                DisplayName = $"{templateSpecName} (Test)",
            };

            var createdTemplateSpec = (await TemplateSpecsOperations.CreateOrUpdateAsync(
                resourceGroupName,
                templateSpecName,
                templateSpecToCreate
            )).Value;

            // Validate user specified details.
            createdTemplateSpec.Should().NotBeNull();
            createdTemplateSpec.Location.Should().Be(TestLocation);
            createdTemplateSpec.Name.Should().Be(templateSpecName);
            createdTemplateSpec.Description.Should().Be(templateSpecToCreate.Description);
            createdTemplateSpec.DisplayName.Should().Be(templateSpecToCreate.DisplayName);

            // Validate readonly properties are present.
            createdTemplateSpec.Id.Should().NotBeNull();
            createdTemplateSpec.Type.Should().NotBeNull();
            createdTemplateSpec.SystemData?.CreatedAt.Should().NotBeNull();
            createdTemplateSpec.SystemData?.CreatedBy.Should().NotBeNull();
            createdTemplateSpec.SystemData?.CreatedByType.Should().NotBeNull();
            createdTemplateSpec.SystemData?.LastModifiedAt.Should().NotBeNull();
            createdTemplateSpec.SystemData?.LastModifiedBy.Should().NotBeNull();
            createdTemplateSpec.SystemData?.LastModifiedByType.Should().NotBeNull();

            // Make sure our object returned from GET is equal to the one which was returned from the creation.
            var templateSpecFromGet = (await TemplateSpecsOperations.GetAsync(resourceGroupName, templateSpecName)).Value;
            createdTemplateSpec.Should().BeEquivalentTo(templateSpecFromGet);

            // Validate we can perform an update on the existing template spec.
            var templateSpecToUpdate = templateSpecToCreate;
            templateSpecToUpdate.Description = "This is an updated description";

            var updatedTemplateSpec = (await TemplateSpecsOperations.CreateOrUpdateAsync(
                resourceGroupName,
                templateSpecName,
                templateSpecToUpdate
            )).Value;

            updatedTemplateSpec.Description.Should().Be(templateSpecToUpdate.Description);

            // Validate we can list template specs within the resource group.
            var templateSpecsAtResourceGroup = await TemplateSpecsOperations.ListByResourceGroupAsync(resourceGroupName).ToEnumerableAsync();
            templateSpecsAtResourceGroup.Should().NotBeEmpty();

            var templateSpecFromList = templateSpecsAtResourceGroup.Find(x => x.Name.Equals(templateSpecName));
            templateSpecFromList.Should().NotBeNull();

            // Validate we can get the template spec from a List at the subscription level:
            var templateSpecsAtSubscription = await TemplateSpecsOperations.ListBySubscriptionAsync().ToEnumerableAsync();
            templateSpecsAtSubscription.Should().NotBeEmpty();

            templateSpecFromList = templateSpecsAtSubscription.Find(x => x.Name.Equals(templateSpecName));
            templateSpecFromList.Should().NotBeNull();

            // Now delete the template spec and make sure it is no longer retrievable:
            await TemplateSpecsOperations.DeleteAsync(resourceGroupName, templateSpecName);
            await Invoking(async () => await TemplateSpecsOperations.GetAsync(resourceGroupName, templateSpecName))
                .Should()
                .ThrowAsync<Exception>();
        }

        [Test]
        public async Task TemplateSpecVersion_Crud_Succeeds()
        {
            var resourceGroupName = NewResourceGroupName();
            var resourceGroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, TestResourceGroup)).Value;

            var templateSpecName = NewTemplateSpecName();
            var templateSpecToCreate = new TemplateSpec(TestLocation)
            {
                Description = "Description of my Template Spec",
                DisplayName = $"{templateSpecName} (Test)",
            };

            var createdTemplateSpec = (await TemplateSpecsOperations.CreateOrUpdateAsync(
                resourceGroupName,
                templateSpecName,
                templateSpecToCreate
            )).Value;

            createdTemplateSpec.Should().NotBeNull();

            const string version = "v1";
            var templateSpecVersionToCreate = new Models.TemplateSpecVersion(TestLocation)
            {
                Description = "My first version",
                MainTemplate = TemplateLoader.LoadTemplateContents("simple-storage-account"),
            };

            var createdTemplateSpecVersion = (await TemplateSpecVersionsOperations.CreateOrUpdateAsync(
                resourceGroupName,
                templateSpecName,
                version,
                templateSpecVersionToCreate
            )).Value;

            // Validate user specified details.
            createdTemplateSpecVersion.Should().NotBeNull();
            createdTemplateSpecVersion.Location.Should().Be(TestLocation);
            createdTemplateSpecVersion.Name.Should().Be(version);
            createdTemplateSpecVersion.Description.Should().Be(templateSpecVersionToCreate.Description);

            var mainTemplateCreated = JsonDocument.Parse(createdTemplateSpecVersion.MainTemplate).RootElement;
            var mainTemplateToCreate = JsonDocument.Parse(templateSpecVersionToCreate.MainTemplate).RootElement;
            mainTemplateCreated.Should().BeEquivalentTo(mainTemplateToCreate, opt => opt.ComparingByMembers<JsonElement>());

            // Validate readonly properties are present.
            createdTemplateSpecVersion.Id.Should().NotBeNull();
            createdTemplateSpecVersion.Type.Should().NotBeNull();
            createdTemplateSpecVersion.SystemData?.CreatedAt.Should().NotBeNull();
            createdTemplateSpecVersion.SystemData?.CreatedBy.Should().NotBeNull();
            createdTemplateSpecVersion.SystemData?.CreatedByType.Should().NotBeNull();
            createdTemplateSpecVersion.SystemData?.LastModifiedAt.Should().NotBeNull();
            createdTemplateSpecVersion.SystemData?.LastModifiedBy.Should().NotBeNull();
            createdTemplateSpecVersion.SystemData?.LastModifiedByType.Should().NotBeNull();

            // Make sure our object returned from GET is equal to the one which was returned from the creation.
            var templateSpecVersionFromGet = (await TemplateSpecVersionsOperations.GetAsync(resourceGroupName, templateSpecName, version)).Value;
            createdTemplateSpecVersion.Should().BeEquivalentTo(templateSpecVersionFromGet, opt => opt.ComparingByMembers<JsonElement>());

            // Validate we can perform an update on the existing version.
            var templateSpecVersionUpdate = templateSpecVersionToCreate;
            templateSpecVersionUpdate.Description = "This is an updated description";

            var updatedTemplateSpecVersion = (await TemplateSpecVersionsOperations.CreateOrUpdateAsync(
                resourceGroupName,
                templateSpecName,
                version,
                templateSpecVersionUpdate
            )).Value;

            updatedTemplateSpecVersion.Description.Should().Be(templateSpecVersionUpdate.Description);

            // Validate we can get the version when listing versions on the template spec.
            var templateSpecVersions = await TemplateSpecVersionsOperations.ListAsync(resourceGroupName, templateSpecName).ToEnumerableAsync();
            templateSpecVersions.Should().NotBeEmpty();

            var templateSpecVersionFromList = templateSpecVersions.Find(x => x.Name.Equals(version));
            templateSpecVersionFromList.Should().NotBeNull();

            // Now delete the template spec and make sure the version is no longer retrievable:

            await TemplateSpecVersionsOperations.DeleteAsync(resourceGroupName, templateSpecName, version);
            await Invoking(async () => await TemplateSpecVersionsOperations.GetAsync(resourceGroupName, templateSpecName, version))
                .Should()
                .ThrowAsync<Exception>();
        }

        private string NewResourceGroupName() => $"{Recording.GenerateAssetName("TS-SDKTest-")}-RG";

        private string NewTemplateSpecName() => Recording.GenerateAssetName("TS-SDKTest-");
    }
}

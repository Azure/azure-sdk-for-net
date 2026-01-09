// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Playwright.Models;
using Azure.ResourceManager.Playwright.Tests.Helper;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Playwright.Tests.Scenario
{
    public class PlaywrightWorkspaceOperations : PlaywrightManagementTestBase
    {
        private PlaywrightWorkspaceCollection _workspaceCollection { get; set; }
        private PlaywrightWorkspaceResource _workspaceResource { get; set; }
        private PlaywrightWorkspaceData _workspaceData { get; set; }

        public PlaywrightWorkspaceOperations(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }

            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            _workspaceCollection = (await CreateResourceGroup(subscription, ResourceHelper.RESOURCE_GROUP_NAME, ResourceHelper.RESOURCE_LOCATION)).GetPlaywrightWorkspaces();

            _workspaceData = new PlaywrightWorkspaceData(ResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceCreateOperationTest()
        {
            // Test Create API
            ArmOperation<PlaywrightWorkspaceResource> createResponse = await _workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, ResourceHelper.WORKSPACE_NAME, _workspaceData);

            Assert.That(createResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createResponse.HasCompleted, Is.True);
                Assert.That(createResponse.HasValue, Is.True);
                Assert.That(createResponse.Value.HasData, Is.True);
                Assert.That(createResponse.Value.Data.Name, Is.EqualTo(ResourceHelper.WORKSPACE_NAME));
                Assert.That(createResponse.Value.Data.Location.Name, Is.EqualTo(ResourceHelper.RESOURCE_LOCATION));
                Assert.That(createResponse.Value.Data.Properties.ProvisioningState, Is.EqualTo(PlaywrightProvisioningState.Succeeded));
                Assert.That(createResponse.Value.Data.Properties.LocalAuth, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(createResponse.Value.Data.Properties.LocalAuth, Is.EqualTo(PlaywrightEnablementStatus.Disabled));
                Assert.That(createResponse.Value.Data.Properties.DataplaneUri, Is.Not.Null);
            });

            _workspaceResource = createResponse.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceGetOperationTest()
        {
            // Setup: Create workspace first
            await WorkspaceCreateOperationTest();

            // Test GET API
            Response<PlaywrightWorkspaceResource> getResponse = await _workspaceCollection.GetAsync(ResourceHelper.WORKSPACE_NAME);
            PlaywrightWorkspaceResource workspaceResource = getResponse.Value;

            Assert.That(workspaceResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(workspaceResource.HasData, Is.True);
                Assert.That(workspaceResource.Data.Name, Is.EqualTo(ResourceHelper.WORKSPACE_NAME));
                Assert.That(workspaceResource.Data.Location.Name, Is.EqualTo(ResourceHelper.RESOURCE_LOCATION));
                Assert.That(workspaceResource.Data.Properties.ProvisioningState, Is.EqualTo(PlaywrightProvisioningState.Succeeded));
                Assert.That(workspaceResource.Data.Properties.LocalAuth, Is.Not.Null);
            });
            Assert.That(workspaceResource.Data.Properties.LocalAuth, Is.EqualTo(PlaywrightEnablementStatus.Disabled));
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceGetResourceDirectOperationTest()
        {
            // Setup: Create workspace first
            await WorkspaceCreateOperationTest();

            // Test GET from resource directly
            Response<PlaywrightWorkspaceResource> getResourceResponse = await _workspaceResource.GetAsync();
            PlaywrightWorkspaceResource workspaceResource = getResourceResponse.Value;

            Assert.That(workspaceResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(workspaceResource.HasData, Is.True);
                Assert.That(workspaceResource.Data.Name, Is.EqualTo(ResourceHelper.WORKSPACE_NAME));
                Assert.That(workspaceResource.Data.Location.Name, Is.EqualTo(ResourceHelper.RESOURCE_LOCATION));
                Assert.That(workspaceResource.Data.Properties.ProvisioningState, Is.EqualTo(PlaywrightProvisioningState.Succeeded));
                Assert.That(workspaceResource.Data.Properties.LocalAuth, Is.Not.Null);
                Assert.That(workspaceResource.Data.Properties.DataplaneUri, Is.Not.Null);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceGetAllOperationTest()
        {
            // Setup: Create workspace first
            await WorkspaceCreateOperationTest();

            // Test GETALL API
            List<PlaywrightWorkspaceResource> getAllResponse = await _workspaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllResponse, Is.Not.Empty);
            Assert.That(getAllResponse, Is.Not.Null);

            bool foundWorkspace = false;
            foreach (PlaywrightWorkspaceResource resource in getAllResponse)
            {
                Assert.That(resource, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(resource.HasData, Is.True);
                    Assert.That(resource.Data.Id, Is.Not.Null);
                    Assert.That(resource.Data.Name, Is.Not.Null);
                    Assert.That(resource.Data.Properties.ProvisioningState, Is.EqualTo(PlaywrightProvisioningState.Succeeded));
                    Assert.That(resource.Data.Properties.LocalAuth, Is.Not.Null);
                });

                if (resource.Data.Name == ResourceHelper.WORKSPACE_NAME)
                {
                    foundWorkspace = true;
                }
            }
            Assert.That(foundWorkspace, Is.True, "Created workspace should be found in GetAll results");
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceUpdateOperationTest()
        {
            // Setup: Create workspace first
            await WorkspaceCreateOperationTest();

            // Test UPDATE API
            PlaywrightWorkspacePatch patchPayload = new PlaywrightWorkspacePatch();
            patchPayload.Tags.Add("Environment", "Test");
            patchPayload.Tags.Add("Team", "SDK");
            patchPayload.Properties = new PlaywrightWorkspaceUpdateProperties
            {
                RegionalAffinity = PlaywrightEnablementStatus.Enabled,
                LocalAuth = PlaywrightEnablementStatus.Enabled
            };

            Response<PlaywrightWorkspaceResource> updateResponse = await _workspaceResource.UpdateAsync(patchPayload);
            PlaywrightWorkspaceResource updatedResource = updateResponse.Value;

            Assert.That(updatedResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedResource.HasData, Is.True);
                Assert.That(updatedResource.Data.Name, Is.EqualTo(ResourceHelper.WORKSPACE_NAME));
                Assert.That(updatedResource.Data.Location.Name, Is.EqualTo(ResourceHelper.RESOURCE_LOCATION));
                Assert.That(updatedResource.Data.Properties.ProvisioningState, Is.EqualTo(PlaywrightProvisioningState.Succeeded));
                Assert.That(updatedResource.Data.Properties.RegionalAffinity, Is.EqualTo(PlaywrightEnablementStatus.Enabled));
                Assert.That(updatedResource.Data.Properties.LocalAuth, Is.EqualTo(PlaywrightEnablementStatus.Enabled));
                Assert.That(updatedResource.Data.Tags.ContainsKey("Environment"), Is.True);
                Assert.That(updatedResource.Data.Tags["Environment"], Is.EqualTo("Test"));
                Assert.That(updatedResource.Data.Tags.ContainsKey("Team"), Is.True);
                Assert.That(updatedResource.Data.Tags["Team"], Is.EqualTo("SDK"));
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceDeleteOperationTest()
        {
            // Setup: Create workspace first
            await WorkspaceCreateOperationTest();

            // Test DELETE API
            ArmOperation deleteResponse = await _workspaceResource.DeleteAsync(WaitUntil.Completed);
            await deleteResponse.WaitForCompletionResponseAsync();
            Assert.That(deleteResponse.HasCompleted, Is.True);

            // Verify workspace is deleted by trying to get it (should fail)
            try
            {
                await _workspaceCollection.GetAsync(ResourceHelper.WORKSPACE_NAME);
                Assert.Fail("Getting deleted workspace should throw an exception");
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Status, Is.EqualTo(404), "Should get 404 for deleted resource");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceExistsOperationTest()
        {
            // Test workspace doesn't exist initially
            Response<bool> existsResponse = await _workspaceCollection.ExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.That(existsResponse.Value, Is.False, "Workspace should not exist initially");

            // Create workspace
            await WorkspaceCreateOperationTest();

            // Test workspace exists after creation
            existsResponse = await _workspaceCollection.ExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.That(existsResponse.Value, Is.True, "Workspace should exist after creation");
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceTryGetOperationTest()
        {
            // Test TryGet when workspace doesn't exist
            NullableResponse<PlaywrightWorkspaceResource> tryGetResponse = await _workspaceCollection.GetIfExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.That(tryGetResponse.HasValue, Is.False, "TryGet should return null for non-existent workspace");

            // Create workspace
            await WorkspaceCreateOperationTest();

            // Test TryGet when workspace exists
            tryGetResponse = await _workspaceCollection.GetIfExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.Multiple(() =>
            {
                Assert.That(tryGetResponse.HasValue, Is.True, "TryGet should return workspace when it exists");
                Assert.That(tryGetResponse.Value, Is.Not.Null);
            });
            Assert.That(tryGetResponse.Value.Data.Name, Is.EqualTo(ResourceHelper.WORKSPACE_NAME));
        }
    }
}

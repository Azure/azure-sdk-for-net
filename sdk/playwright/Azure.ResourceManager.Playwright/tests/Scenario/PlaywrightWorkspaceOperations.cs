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

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, createResponse.Value.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, createResponse.Value.Data.Location.Name);
            Assert.AreEqual(PlaywrightProvisioningState.Succeeded, createResponse.Value.Data.Properties.ProvisioningState);
            Assert.IsNotNull(createResponse.Value.Data.Properties.LocalAuth);
            Assert.AreEqual(PlaywrightEnablementStatus.Disabled, createResponse.Value.Data.Properties.LocalAuth);
            Assert.IsNotNull(createResponse.Value.Data.Properties.DataplaneUri);

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

            Assert.IsNotNull(workspaceResource);
            Assert.IsTrue(workspaceResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, workspaceResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, workspaceResource.Data.Location.Name);
            Assert.AreEqual(PlaywrightProvisioningState.Succeeded, workspaceResource.Data.Properties.ProvisioningState);
            Assert.IsNotNull(workspaceResource.Data.Properties.LocalAuth);
            Assert.AreEqual(PlaywrightEnablementStatus.Disabled, workspaceResource.Data.Properties.LocalAuth);
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

            Assert.IsNotNull(workspaceResource);
            Assert.IsTrue(workspaceResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, workspaceResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, workspaceResource.Data.Location.Name);
            Assert.AreEqual(PlaywrightProvisioningState.Succeeded, workspaceResource.Data.Properties.ProvisioningState);
            Assert.IsNotNull(workspaceResource.Data.Properties.LocalAuth);
            Assert.IsNotNull(workspaceResource.Data.Properties.DataplaneUri);
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceGetAllOperationTest()
        {
            // Setup: Create workspace first
            await WorkspaceCreateOperationTest();

            // Test GETALL API
            List<PlaywrightWorkspaceResource> getAllResponse = await _workspaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(getAllResponse);
            Assert.IsNotNull(getAllResponse);

            bool foundWorkspace = false;
            foreach (PlaywrightWorkspaceResource resource in getAllResponse)
            {
                Assert.IsNotNull(resource);
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.Name);
                Assert.AreEqual(PlaywrightProvisioningState.Succeeded, resource.Data.Properties.ProvisioningState);
                Assert.IsNotNull(resource.Data.Properties.LocalAuth);
                
                if (resource.Data.Name == ResourceHelper.WORKSPACE_NAME)
                {
                    foundWorkspace = true;
                }
            }
            Assert.IsTrue(foundWorkspace, "Created workspace should be found in GetAll results");
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

            Assert.IsNotNull(updatedResource);
            Assert.IsTrue(updatedResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, updatedResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, updatedResource.Data.Location.Name);
            Assert.AreEqual(PlaywrightProvisioningState.Succeeded, updatedResource.Data.Properties.ProvisioningState);
            Assert.AreEqual(PlaywrightEnablementStatus.Enabled, updatedResource.Data.Properties.RegionalAffinity);
            Assert.AreEqual(PlaywrightEnablementStatus.Enabled, updatedResource.Data.Properties.LocalAuth);
            Assert.IsTrue(updatedResource.Data.Tags.ContainsKey("Environment"));
            Assert.AreEqual("Test", updatedResource.Data.Tags["Environment"]);
            Assert.IsTrue(updatedResource.Data.Tags.ContainsKey("Team"));
            Assert.AreEqual("SDK", updatedResource.Data.Tags["Team"]);
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
            Assert.IsTrue(deleteResponse.HasCompleted);

            // Verify workspace is deleted by trying to get it (should fail)
            try
            {
                await _workspaceCollection.GetAsync(ResourceHelper.WORKSPACE_NAME);
                Assert.Fail("Getting deleted workspace should throw an exception");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Should get 404 for deleted resource");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceExistsOperationTest()
        {
            // Test workspace doesn't exist initially
            Response<bool> existsResponse = await _workspaceCollection.ExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.IsFalse(existsResponse.Value, "Workspace should not exist initially");

            // Create workspace
            await WorkspaceCreateOperationTest();

            // Test workspace exists after creation
            existsResponse = await _workspaceCollection.ExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.IsTrue(existsResponse.Value, "Workspace should exist after creation");
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceTryGetOperationTest()
        {
            // Test TryGet when workspace doesn't exist
            NullableResponse<PlaywrightWorkspaceResource> tryGetResponse = await _workspaceCollection.GetIfExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.IsFalse(tryGetResponse.HasValue, "TryGet should return null for non-existent workspace");

            // Create workspace
            await WorkspaceCreateOperationTest();

            // Test TryGet when workspace exists
            tryGetResponse = await _workspaceCollection.GetIfExistsAsync(ResourceHelper.WORKSPACE_NAME);
            Assert.IsTrue(tryGetResponse.HasValue, "TryGet should return workspace when it exists");
            Assert.IsNotNull(tryGetResponse.Value);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, tryGetResponse.Value.Data.Name);
        }
    }
}

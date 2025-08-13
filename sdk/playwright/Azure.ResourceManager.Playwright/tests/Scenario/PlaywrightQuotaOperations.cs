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
    public class PlaywrightQuotaOperations : PlaywrightManagementTestBase
    {
        private PlaywrightWorkspaceCollection _workspaceCollection { get; set; }
        private PlaywrightWorkspaceResource _workspaceResource { get; set; }
        private PlaywrightWorkspaceData _workspaceData { get; set; }
        private PlaywrightQuotaCollection _quotaCollection { get; set; }

        public PlaywrightQuotaOperations(bool isAsync) : base(isAsync)
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

            // Create workspace for quota tests
            ArmOperation<PlaywrightWorkspaceResource> createResponse = await _workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, ResourceHelper.WORKSPACE_NAME, _workspaceData);
            _workspaceResource = createResponse.Value;
            _quotaCollection = subscription.GetAllPlaywrightQuota(ResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaGetOperationTest()
        {
            // Test GET quota by name
            Response<PlaywrightQuotaResource> getResponse = await _quotaCollection.GetAsync(PlaywrightQuotaName.ExecutionMinutes);
            PlaywrightQuotaResource quotaResource = getResponse.Value;

            Assert.IsNotNull(quotaResource);
            Assert.IsTrue(quotaResource.HasData);
            Assert.IsNotNull(quotaResource.Data.Properties);
            Assert.AreEqual(PlaywrightProvisioningState.Succeeded, quotaResource.Data.Properties.ProvisioningState);
            Assert.IsNotNull(quotaResource.Data.Properties.FreeTrial);
            Assert.IsTrue(quotaResource.Data.Name.Contains("ExecutionMinutes"));
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaGetAllOperationTest()
        {
            // Test List quotas for the workspace
            List<PlaywrightQuotaResource> allQuotas = await _quotaCollection.GetAllAsync().ToEnumerableAsync();

            Assert.IsNotEmpty(allQuotas);
            bool foundExecutionMinutesQuota = false;

            foreach (PlaywrightQuotaResource quota in allQuotas)
            {
                Assert.IsNotNull(quota);
                Assert.IsTrue(quota.HasData);
                Assert.IsNotNull(quota.Data.Properties);
                Assert.AreEqual(PlaywrightProvisioningState.Succeeded, quota.Data.Properties.ProvisioningState);
                Assert.IsNotNull(quota.Data.Properties.FreeTrial);

                if (quota.Data.Name.Contains("ExecutionMinutes"))
                {
                    foundExecutionMinutesQuota = true;
                }
            }

            Assert.IsTrue(foundExecutionMinutesQuota, "ExecutionMinutes quota should be found in GetAll results");
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaExistsOperationTest()
        {
            // Test if quota exists
            Response<bool> existsResponse = await _quotaCollection.ExistsAsync(PlaywrightQuotaName.ExecutionMinutes);
            Assert.IsTrue(existsResponse.Value, "ExecutionMinutes quota should exist");
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaResourceTypeValidationTest()
        {
            // Test quota resource type
            Response<PlaywrightQuotaResource> quotaResponse = await _quotaCollection.GetAsync(PlaywrightQuotaName.ExecutionMinutes);
            PlaywrightQuotaResource quotaResource = quotaResponse.Value;

            Assert.AreEqual("Microsoft.LoadTestService/locations/playwrightQuotas", quotaResource.Data.Id.ResourceType.ToString());
            Assert.AreEqual(PlaywrightQuotaResource.ResourceType, quotaResource.Data.Id.ResourceType);
        }
    }
}

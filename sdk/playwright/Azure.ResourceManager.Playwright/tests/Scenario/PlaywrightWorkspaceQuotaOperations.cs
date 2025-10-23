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
    public class PlaywrightWorkspaceQuotaOperations : PlaywrightManagementTestBase
    {
        private PlaywrightWorkspaceCollection _workspaceCollection { get; set; }
        private PlaywrightWorkspaceResource _workspaceResource { get; set; }
        private PlaywrightWorkspaceData _workspaceData { get; set; }
        private PlaywrightWorkspaceQuotaCollection _quotaCollection { get; set; }

        public PlaywrightWorkspaceQuotaOperations(bool isAsync) : base(isAsync)
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
            _quotaCollection = _workspaceResource.GetAllPlaywrightWorkspaceQuota();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceQuotaOperationTestsQuotaName()
        {
            //GET API
            try
            {
                Response<PlaywrightWorkspaceQuotaResource> getResponse = await _quotaCollection.GetAsync(PlaywrightQuotaName.ExecutionMinutes);
                Assert.IsNotNull(getResponse, "The response should not be null.");
                Assert.IsNotNull(getResponse.Value, "The response value should not be null.");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Expected a 404 status code.");
                Assert.AreEqual("NotFound", ex.ErrorCode, "Expected the error code to be 'NotFound'.");
                StringAssert.Contains(
                    "The data was not found. Please check the request and try again.",
                    ex.Message,
                    "The error message did not match the expected text."
                );

                Assert.IsTrue(ex.Message.Contains("NotFound"), "The error message should contain 'NotFound'.");
                return;
            }

            Assert.Fail("Expected a RequestFailedException with a 404 status, but the API returned a valid response.");
        }

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceQuotaGetAllTest()
        {
            // Test Quota List API
            try
            {
                List<PlaywrightWorkspaceQuotaResource> allQuotas = await _workspaceResource.GetAllPlaywrightWorkspaceQuota().GetAllAsync().ToEnumerableAsync();
                Assert.IsNotNull(allQuotas, "The response should not be null.");
                Assert.IsNotEmpty(allQuotas, "The response list should not be empty.");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Expected a 404 status code.");
                Assert.AreEqual("NotFound", ex.ErrorCode, "Expected the error code to be 'NotFound'.");
                StringAssert.Contains(
                    "The data was not found. Please check the request and try again.",
                    ex.Message,
                    "The error message did not match the expected text."
                );

                Assert.IsTrue(ex.Message.Contains("NotFound"), "The error message should contain 'NotFound'.");
                return;
            }

            Assert.Fail("Expected a RequestFailedException with a 404 status, but the API returned a valid response.");
        }
    }
}
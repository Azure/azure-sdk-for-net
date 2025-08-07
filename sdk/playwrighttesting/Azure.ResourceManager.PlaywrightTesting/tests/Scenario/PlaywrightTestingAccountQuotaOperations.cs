// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PlaywrightTesting.Models;
using Azure.ResourceManager.PlaywrightTesting.Tests.Helper;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PlaywrightTesting.Tests.Scenario
{
    public class PlaywrightTestingAccountQuotaOperations : PlaywrightTestingManagementTestBase
    {
        private PlaywrightTestingAccountQuotaCollection _quotaCollection { get; set; }
        private PlaywrightTestingAccountQuotaResource _quotaResource { get; set; }
        private PlaywrightTestingAccountQuotaData _quotaData { get; set; }

        public PlaywrightTestingAccountQuotaOperations(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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

            ResourceIdentifier playwrightTestingAccountResourceId = PlaywrightTestingAccountResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, ResourceHelper.RESOURCE_GROUP_NAME_TEST, ResourceHelper.WORKSPACE_NAME);
            PlaywrightTestingAccountResource playwrightTestingAccount = new PlaywrightTestingAccountResource(Client, playwrightTestingAccountResourceId);

            _quotaCollection = playwrightTestingAccount.GetAllPlaywrightTestingAccountQuota();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task AccountQuotaOperationTestsScalable()
        {
            //GET API
            PlaywrightTestingQuotaName quotaName = PlaywrightTestingQuotaName.ScalableExecution;

            try
            {
                Response<PlaywrightTestingAccountQuotaResource> getResponse = await _quotaCollection.GetAsync(quotaName);
                Assert.IsNotNull(getResponse, "The response should not be null.");
                Assert.IsNotNull(getResponse.Value, "The response value should not be null.");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Expected a 404 status code.");
                Assert.AreEqual("NotFound", ex.ErrorCode, "Expected the error code to be 'NotFound'.");
                StringAssert.Contains(
                    "The data for the account or free-trial was not found. Please check the request and try again.",
                    ex.Message,
                    "The error message did not match the expected text."
                );

                Assert.IsTrue(ex.Message.Contains("NotFound"), "The error message should contain 'NotFound'.");
                return;
            }

            Assert.Fail("Expected a RequestFailedException with a 404 status, but the API returned a valid response.");

            //List API
            List<PlaywrightTestingAccountQuotaResource> listResponse = await _quotaCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listResponse);
        }

        [TestCase]
        [RecordedTest]
        public async Task AccountQuotaOperationTestsReporting()
        {
            //GET API
            PlaywrightTestingQuotaName quotaName = PlaywrightTestingQuotaName.Reporting;

            try
            {
                Response<PlaywrightTestingAccountQuotaResource> getResponse = await _quotaCollection.GetAsync(quotaName);
                Assert.IsNotNull(getResponse, "The response should not be null.");
                Assert.IsNotNull(getResponse.Value, "The response value should not be null.");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Expected a 404 status code.");
                Assert.AreEqual("NotFound", ex.ErrorCode, "Expected the error code to be 'NotFound'.");
                StringAssert.Contains(
                    "The data for the account or free-trial was not found. Please check the request and try again.",
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

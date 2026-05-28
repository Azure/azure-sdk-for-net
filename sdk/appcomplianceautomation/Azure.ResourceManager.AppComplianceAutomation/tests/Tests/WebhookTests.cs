// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.AppComplianceAutomation;
using NUnit.Framework;
using Azure.ResourceManager.AppComplianceAutomation.Models;
using System.Collections.Generic;
using Azure.Core;
using System.Linq;
using System.Security.Policy;

namespace Azure.ResourceManager.AppComplianceAutomation.Tests.Tests
{
    public class WebhookTests : AppComplianceAutomationManagementTestBase
    {
        public WebhookTests(bool isAsync) : base(isAsync)
        {
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [SetUp]
        public void Init()
        {
            InitializeUserTokenClients();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
        }

        [TestCase]
        public async Task WebhookCRUD()
        {
            string reportName = "sdk-test-report";
            string webhookName = "webhook-test";

            ResourceIdentifier appComplianceReportId = AppComplianceReportResource.CreateResourceIdentifier(reportName);
            AppComplianceReportResource appComplianceReport = Client.GetAppComplianceReportResource(appComplianceReportId);
            AppComplianceReportWebhookCollection webhooks = appComplianceReport.GetAppComplianceReportWebhooks();

            // Create webhook
            // Create webhook: prepare data
            AppComplianceReportWebhookData webhookData = new AppComplianceReportWebhookData();
            AppComplianceReportWebhookProperties properties = new AppComplianceReportWebhookProperties();
            properties.PayloadUri = new Uri("https://example1.com");
            properties.EnableSslVerification = EnableSslVerification.True;
            properties.SendAllEvents = SendAllEvent.True;
            properties.Events.Add(WebhookNotificationEvent.AssessmentFailure);
            properties.Status = WebhookStatus.Enabled;
            properties.ContentType = WebhookContentType.ApplicationJson;
            webhookData.Properties = properties;
            // Create webhook: send request
            ArmOperation<AppComplianceReportWebhookResource> createResponse = await webhooks.CreateOrUpdateAsync(WaitUntil.Completed, webhookName, webhookData);
            // Create webhook: verify result
            AppComplianceReportWebhookResource webhook = createResponse.Value;
            Assert.AreEqual(webhook.Data.Properties.PayloadUri, new Uri("https://example1.com"));

            // Patch webhook
            // Patch webhook: prepare data
            ResourceIdentifier appComplianceReportWebhookResourceId = AppComplianceReportWebhookResource.CreateResourceIdentifier(reportName, webhookName);
            AppComplianceReportWebhookResource appComplianceReportWebhook = Client.GetAppComplianceReportWebhookResource(appComplianceReportWebhookResourceId);
            AppComplianceReportWebhookPatch webhookPatchData = new AppComplianceReportWebhookPatch();
            properties.PayloadUri = new Uri("https://example2.com");
            webhookPatchData.Properties = properties;
            //Patch webhook: send request
            AppComplianceReportWebhookResource patchResult = await appComplianceReportWebhook.UpdateAsync(webhookPatchData);
            //Patch webhook: verify result
            Assert.AreEqual(patchResult.Data.Properties.PayloadUri, new Uri("https://example2.com"));

            // Get webhook
            // Get webhook: send request
            AppComplianceReportWebhookResource getResult = await appComplianceReportWebhook.GetAsync();
            // Get webhook: verify result
            Assert.IsNotNull(getResult.Data.Id);

            // Delete webhook
            // Delete webhook: send request
            var operation = await appComplianceReportWebhook.DeleteAsync(WaitUntil.Completed);
            // Delete webhook: verify result
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}

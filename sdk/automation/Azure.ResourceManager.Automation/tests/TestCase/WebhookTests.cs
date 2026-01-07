// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    internal class WebhookTests : AutomationManagementTestBase
    {
        private AutomationRunbookResource _runbook;
        private AutomationWebhookCollection _webhookCollection;

        public WebhookTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroupAsync();
            string automationAccountName = Recording.GenerateAssetName("automation");
            string runbookName = Recording.GenerateAssetName("runbook");
            var automationAccount = await rg.GetAutomationAccounts().CreateOrUpdateAsync(WaitUntil.Completed, automationAccountName, ResourceDataHelpers.GetAccountData());
            var runbook = await automationAccount.Value.GetAutomationRunbooks().CreateOrUpdateAsync(WaitUntil.Completed, runbookName, ResourceDataHelpers.GetRunbookData());
            _runbook = runbook.Value;
            _webhookCollection = automationAccount.Value.GetAutomationWebhooks();
            await _runbook.PublishAsync(WaitUntil.Completed);
        }

        private async Task<AutomationWebhookResource> CreateWebhook(string webhookName)
        {
            var data = new AutomationWebhookCreateOrUpdateContent(webhookName)
            {
                RunbookName = _runbook.Data.Name,
                ExpireOn = Recording.UtcNow.AddDays(1),
            };
            var webhook = await _webhookCollection.CreateOrUpdateAsync(WaitUntil.Completed, webhookName, data);
            return webhook.Value;
        }

        [RecordedTest]
        [LiveOnly]// Uri contains Credential info that should be sanitized, and `new Uri("Sanitized")` cannot pass the playback.
        public async Task CreateOrUpdateExistGetGetAll()
        {
            // CreateOrUpdate
            string webhookName = Recording.GenerateAssetName("webhook");
            var webhook = await CreateWebhook(webhookName);
            ValidateWebhook(webhook.Data, webhookName);
            Assert.That(webhook.Data.Uri, Is.Not.Null);

            // Exist
            var flag = await _webhookCollection.ExistsAsync(webhookName);
            Assert.That((bool)flag, Is.True);

            // Get
            var getwebhook = await _webhookCollection.GetAsync(webhookName);
            ValidateWebhook(getwebhook.Value.Data, webhookName);
            Assert.That(getwebhook.Value.Data.Uri, Is.Null);

            // GetAll
            var list = await _webhookCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateWebhook(list.FirstOrDefault().Data, webhookName);
            Assert.That(list.FirstOrDefault().Data.Uri, Is.Null);
        }

        private void ValidateWebhook(AutomationWebhookData webhook, string webhookName)
        {
            Assert.That(webhook, Is.Not.Null);
            Assert.IsNotEmpty(webhook.Id);
            Assert.That(webhook.Name, Is.EqualTo(webhookName));
            Assert.That(webhook.RunbookName, Is.EqualTo(_runbook.Data.Name));
        }
    }
}

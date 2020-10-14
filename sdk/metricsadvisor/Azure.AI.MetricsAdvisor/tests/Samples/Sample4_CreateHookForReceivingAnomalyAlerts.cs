// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [RecordedTest]
        public async Task CreateHookForReceivingAnomalyAlerts()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            #region Snippet:CreateHookForReceivingAnomalyAlerts
            string hookName = "Sample hook";
            var emailsToAlert = new List<string>()
            {
                "email1@sample.com",
                "email2@sample.com"
            };

            var emailHook = new EmailHook(hookName, emailsToAlert);

            Response<AlertingHook> response = adminClient.CreateHook(emailHook);

            AlertingHook hook = response.Value;

            Console.WriteLine($"Hook ID: {hook.Id}");
            #endregion

            // Delete the created hook to clean up the Metrics Advisor resource. Do not perform this
            // step if you intend to keep using the hook.

            await adminClient.DeleteHookAsync(hook.Id);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    [LiveOnly]
    public class Snippets : MetricsAdvisorTestEnvironment
    {
        [Test]
        public void CreateMetricsAdvisorClient()
        {
            #region Snippet:CreateMetricsAdvisorClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string subscriptionKey = "<subscriptionKey>";
            string apiKey = "<apiKey>";
#else
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
#endif
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);
            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);
            #endregion
        }

        [Test]
        public void CreateMetricsAdvisorClientWithAad()
        {
            #region Snippet:CreateMetricsAdvisorClientWithAad
#if SNIPPET
            string endpoint = "<endpoint>";
#else
            string endpoint = MetricsAdvisorUri;
#endif
            var client = new MetricsAdvisorClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void CreateMetricsAdvisorAdministrationClient()
        {
            #region Snippet:CreateMetricsAdvisorAdministrationClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string subscriptionKey = "<subscriptionKey>";
            string apiKey = "<apiKey>";
#else
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
#endif
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);
            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);
            #endregion
        }

        [Test]
        public void CreateMetricsAdvisorAdministrationClientWithAad()
        {
            #region Snippet:CreateMetricsAdvisorAdministrationClientWithAad
#if SNIPPET
            string endpoint = "<endpoint>";
#else
            string endpoint = MetricsAdvisorUri;
#endif
            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public async Task MetricsAdvisorNotFound()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;

            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);
            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            #region Snippet:MetricsAdvisorNotFound
            string dataFeedId = "00000000-0000-0000-0000-000000000000";

            try
            {
                Response<DataFeed> response = await adminClient.GetDataFeedAsync(dataFeedId);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}

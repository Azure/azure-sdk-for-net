// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Samples
{
    public partial class OnlineExperimentationSamples
    {
        [Test]
        [SyncOnly]
        public void CreateEventCountMetric()
        {
            #region Snippet:OnlineExperimentation_CreateEventCountMetric
            // Create a client with your Azure Online Experimentation workspace endpoint and credentials
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the Event Count metric - counts all occurrences of a specific event type
            var promptSentMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Total number of prompts sent",
                "Counts the total number of prompts sent by users to the chatbot",
                ["Usage"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("PromptSent")
            );

            // Create the metric with ID "PromptSentCount"
            var response = client.CreateMetric("prompt_sent_count", promptSentMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            Console.WriteLine($"Display name: {response.Value.DisplayName}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void CreateUserCountMetric()
        {
            #region Snippet:OnlineExperimentation_CreateUserCountMetric
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the User Count metric with a filter - counts unique users who performed a specific action
            var usersPromptSentMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Users with at least one prompt sent on checkout page",
                "Counts unique users who sent at least one prompt while on the checkout page",
                ["Usage"],
                DesiredDirection.Increase,
                new UserCountMetricDefinition("PromptSent")
                {
                    Event = { Filter = "Page == 'checkout.html'" }
                }
            );

            // Create the metric with ID "UsersPromptSent"
            var response = client.CreateMetric("users_prompt_sent", usersPromptSentMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void CreateEventRateMetric()
        {
            #region Snippet:OnlineExperimentation_CreateEventRateMetric
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the Event Rate metric - measures a percentage of events meeting a condition
            var relevanceMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "% evaluated conversations with good relevance",
                "Percentage of evaluated conversations where the LLM response has good relevance (score >= 4)",
                ["Quality"],
                DesiredDirection.Increase,
                new EventRateMetricDefinition("EvaluateLLM", rateCondition: "Relevance > 4")
            );

            // Create the metric
            var response = client.CreateMetric("momo_pct_relevance_good", relevanceMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void CreateUserRateMetric()
        {
            #region Snippet:OnlineExperimentation_CreateUserRateMetric
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the User Rate metric - measures percentage of users who performed action B after action A
            var conversionMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "% users with LLM interaction who made a high-value purchase",
                "Percentage of users who received a response from the LLM and then made a purchase of $100 or more",
                ["Business"],
                DesiredDirection.Increase,
                new UserRateMetricDefinition(startEventName: "ResponseReceived", endEventName: "Purchase")
                {
                    EndEvent = { Filter = "Revenue > 100" }
                }
            );

            // Create the metric
            var response = client.CreateMetric("pct_chat_to_high_value_purchase_conversion", conversionMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void CreateSumMetric()
        {
            #region Snippet:OnlineExperimentation_CreateSumMetric
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the Sum metric - sums a numeric value across all events of a type
            var revenueMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Total revenue",
                "Sum of revenue from all purchase transactions",
                ["Business"],
                DesiredDirection.Increase,
                new SumMetricDefinition("Purchase", eventProperty: "Revenue")
                {
                    Value = { Filter = "Revenue > 0" }
                }
            );

            // Create the metric
            var response = client.CreateMetric("total_revenue", revenueMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void CreateAverageMetric()
        {
            #region Snippet:OnlineExperimentation_CreateAverageMetric
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the Average metric - calculates the mean of a numeric value across events
            var avgRevenueMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Average revenue per purchase",
                "The average revenue per purchase transaction in USD",
                ["Business"],
                DesiredDirection.Increase,
                new AverageMetricDefinition(eventName: "Purchase", eventProperty: "Revenue")
            );

            // Create the metric
            var response = client.CreateMetric("avg_revenue_per_purchase", avgRevenueMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void CreatePercentileMetric()
        {
            #region Snippet:OnlineExperimentation_CreatePercentileMetric
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define the Percentile metric - calculates a specific percentile of a numeric value
            var p95ResponseTimeMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "P95 LLM response time [seconds]",
                "The 95th percentile of response time in seconds for LLM responses",
                ["Performance"],
                DesiredDirection.Decrease,
                new PercentileMetricDefinition(eventName: "ResponseReceived", eventProperty: "ResponseTimeSeconds", percentile: 95)
            );

            // Create the metric
            var response = client.CreateMetric("p95_response_time_seconds", p95ResponseTimeMetric);

            Console.WriteLine($"Created metric: {response.Value.Id}");
            #endregion
        }
    }
}

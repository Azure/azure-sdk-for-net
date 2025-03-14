// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Identity;

using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Tests
{
    [TestFixture]
    public class OnlineExperimentationHeroScenarios
    {
        private ExperimentMetrics GetExperimentMetricsClient()
        {
            // Create a client with your Azure Online Experimentation workspace endpoint and credentials
            var endpoint = new Uri("https://{workspaceId}.{region}.exp.azure.net");
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            return client.GetExperimentMetricsClient();
        }

        [Test]
        [Description("Example showing how to create an Event Count metric for counting prompts sent to a chatbot")]
        public void CreateAnEventCountMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the Event Count metric - counts all occurrences of a specific event type
            var promptSentMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Total number of prompts sent",
                "Counts the total number of prompts sent by users to the chatbot",
                ["Usage"],
                DesiredDirection.Increase,
                new EventCountDefinition("PromptSent")
            );

            // Create the metric with ID "PromptSentCount"
            var response = metricsClient.CreateOrUpdate("PromptSentCount", promptSentMetric);

            Console.WriteLine($"Created metric: {response.Id}");
            Console.WriteLine($"Display name: {response.DisplayName}");
        }

        [Test]
        [Description("Example showing how to create a User Count metric with a filter condition")]
        public void CreateAUserCountMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the User Count metric with a filter - counts unique users who performed a specific action
            var usersPromptSentMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Users with at least one prompt sent on checkout page",
                "Counts unique users who sent at least one prompt while on the checkout page",
                ["Usage"],
                DesiredDirection.Increase,
                new UserCountDefinition("PromptSent", filter: "Page eq 'checkout.html'")
            );

            // Create the metric with ID "UsersPromptSent"
            var response = metricsClient.CreateOrUpdate("UsersPromptSent", usersPromptSentMetric);

            Console.WriteLine($"Created metric: {response.Id}");
        }

        [Test]
        [Description("Example showing how to create an Event Rate metric for measuring LLM response quality")]
        public void CreateAnEventRateMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the Event Rate metric - measures a percentage of events meeting a condition
            var relevanceMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "% evaluated conversations with good relevance",
                "Percentage of evaluated conversations where the LLM response has good relevance (score >= 4)",
                ["Quality"],
                DesiredDirection.Increase,
                new EventRateDefinition(eventName: "EvaluateLLM", rateCondition: "Relevance ge 4")
            );

            // Create the metric
            var response = metricsClient.CreateOrUpdate("MoMo_PctRelevanceGood", relevanceMetric);

            Console.WriteLine($"Created metric: {response.Id}");
        }

        [Test]
        [Description("Example showing how to create a User Rate metric for measuring conversion rates")]
        public void CreateAUserRateMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the User Rate metric - measures percentage of users who performed action B after action A
            var conversionMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "% users with LLM interaction who made a high-value purchase",
                "Percentage of users who received a response from the LLM and then made a purchase of $100 or more",
                ["Business"],
                DesiredDirection.Increase,
                new UserRateDefinition(
                    new ObservedEvent("ResponseReceived"),
                    new ObservedEvent("Purchase", filter: "Revenue ge 100")
                )
            );

            // Create the metric
            var response = metricsClient.CreateOrUpdate("PctChatToHighValuePurchaseConversion", conversionMetric);

            Console.WriteLine($"Created metric: {response.Id}");
        }

        [Test]
        [Description("Example showing how to create a Sum metric for measuring total revenue")]
        public void CreateASumMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the Sum metric - sums a numeric value across all events of a type
            var revenueMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Total revenue",
                "Sum of revenue from all purchase transactions",
                ["Business"],
                DesiredDirection.Increase,
                new SumDefinition(eventName: "Purchase", eventProperty: "Revenue")
            );

            // Create the metric
            var response = metricsClient.CreateOrUpdate("TotalRevenue", revenueMetric);

            Console.WriteLine($"Created metric: {response.Id}");
        }

        [Test]
        [Description("Example showing how to create an Average metric for measuring average revenue per purchase")]
        public void CreateAnAverageMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the Average metric - calculates the mean of a numeric value across events
            var avgRevenueMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "Average revenue per purchase",
                "The average revenue per purchase transaction in USD",
                ["Business"],
                DesiredDirection.Increase,
                new AverageDefinition(eventName: "Purchase", eventProperty: "Revenue")
            );

            // Create the metric
            var response = metricsClient.CreateOrUpdate("AvgRevenuePerPurchase", avgRevenueMetric);

            Console.WriteLine($"Created metric: {response.Id}");
        }

        [Test]
        [Description("Example showing how to create a Percentile metric for measuring P95 response time")]
        public void CreateAPercentileMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define the Percentile metric - calculates a specific percentile of a numeric value
            var p95ResponseTimeMetric = new ExperimentMetric(
                LifecycleStage.Active,
                "P95 LLM response time [seconds]",
                "The 95th percentile of response time in seconds for LLM responses",
                ["Performance"],
                DesiredDirection.Decrease,
                new PercentileDefinition(
                    eventName: "ResponseReceived",
                    eventProperty: "ResponseTimeSeconds",
                    percentile: 95
                )
            );

            // Create the metric
            var response = metricsClient.CreateOrUpdate("P95ResponseTimeSeconds", p95ResponseTimeMetric);

            Console.WriteLine($"Created metric: {response.Id}");
        }

        [Test]
        [Description("Example showing how to retrieve a specific metric by ID")]
        public void RetrieveAMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Get a specific metric by ID
            var metric = metricsClient.GetExperimentMetric("AvgRevenuePerPurchase");

            // Access metric properties to view or use the metric definition
            Console.WriteLine($"Metric ID: {metric.Value.Id}");
            Console.WriteLine($"Display name: {metric.Value.DisplayName}");
            Console.WriteLine($"Description: {metric.Value.Description}");
            Console.WriteLine($"Lifecycle stage: {metric.Value.Lifecycle}");
            Console.WriteLine($"Desired direction: {metric.Value.DesiredDirection}");
        }

        [Test]
        [Description("Example showing how to list all metrics in the workspace")]
        public void ListAllMetrics()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // List all metrics in the workspace
            Console.WriteLine("Listing all metrics:");
            foreach (var metric in metricsClient.GetExperimentMetrics())
            {
                Console.WriteLine($"- {metric.Id}: {metric.DisplayName}");
            }
        }

        [Test]
        [Description("Example showing how to update properties of an existing metric")]
        public void UpdateAnExistingMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // First, get the existing metric
            var existingMetric = metricsClient.GetExperimentMetric("AvgRevenuePerPurchase").Value;

            existingMetric.DisplayName = "Average revenue per purchase [USD]";
            existingMetric.Description = "The average revenue per purchase transaction in USD. Refund transactions are excluded.";

            // Update the metric - the CreateOrUpdate method is used for both creating and updating
            var response = metricsClient.CreateOrUpdate(existingMetric.Id, existingMetric);

            Console.WriteLine($"Updated metric: {response.Id}");
            Console.WriteLine($"New display name: {response.DisplayName}");
            Console.WriteLine($"New description: {response.Description}");
        }

        [Test]
        [Description("Example showing how to validate a metric definition before creating it")]
        public void ValidateAMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Define a metric to validate
            var metricToValidate = new ExperimentMetric(
                LifecycleStage.Active,
                "Test metric for validation",
                "This metric definition will be validated before creation",
                ["Test"],
                DesiredDirection.Increase,
                new EventCountDefinition("TestEvent")
            );

            // Validate the metric - checks for errors in the definition
            var validationResult = metricsClient.Validate("test_metric_id", metricToValidate);

            // Check if the metric definition is valid
            if (validationResult.Value.IsValid())
            {
                Console.WriteLine("Metric definition is valid");

                // Now create the validated metric
                var createdMetric = metricsClient.CreateOrUpdate("test_metric_id", metricToValidate);
                Console.WriteLine($"Created metric: {createdMetric.Id}");
            }
            else
            {
                // Handle validation errors
                Console.WriteLine("Metric definition has errors:");
                foreach (var error in validationResult.Value.Diagnostics)
                {
                    Console.WriteLine($"- [{error.Code}] {error.Message}");
                }
            }
        }

        [Test]
        [Description("Example showing how to delete a metric by ID")]
        public void DeleteAMetric()
        {
            // Initialize the client
            var metricsClient = GetExperimentMetricsClient();

            // Delete a metric by ID - removes it from the workspace
            var response = metricsClient.Delete("test_metric_id");

            Console.WriteLine($"Delete operation status: {response.Status}");
        }
    }
}

# Azure Online Experimentation SDK Hero Scenarios

This document provides several code snippets covering the most common Online Experimentation tasks using the .NET SDK.

## Key Scenarios

* [Initialize the Client](#initialize-the-client)
* [Create an Event Count Metric](#create-an-event-count-metric)
* [Create a User Count Metric](#create-a-user-count-metric)
* [Create an Event Rate Metric](#create-an-event-rate-metric)
* [Create a User Rate Metric](#create-a-user-rate-metric)
* [Create a Sum Metric](#create-a-sum-metric)
* [Create an Average Metric](#create-an-average-metric)
* [Create a Percentile Metric](#create-a-percentile-metric)
* [Retrieve a Metric](#retrieve-a-metric)
* [List All Metrics](#list-all-metrics)
* [Update an Existing Metric](#update-an-existing-metric)
* [Validate a Metric](#validate-a-metric-definition)
* [Delete a Metric](#delete-a-metric)

## Initialize the Client

To begin working with the Azure Online Experimentation service, you need to create a client instance:

``` csharp
// Create a client with your Azure Online Experimentation workspace endpoint and credentials
var endpoint = new Uri("https://{workspaceId}.{region}.exp.azure.net");
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// Get the ExperimentMetrics client
var metricsClient = client.GetExperimentMetricsClient();
```

## Create an Event Count Metric

This example creates a metric to count the total number of prompts sent by users to a chatbot:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the Event Count metric
var promptSentMetric = new ExperimentMetric(
    LifecycleStage.Active,
    "Total number of prompts sent",
    "Counts the total number of prompts sent by users to the chatbot",
    ["Usage"],
    DesiredDirection.Increase,
    new EventCountDefinition("PromptSent")
);

// Create the metric with ID "PromptSentCount"
var response = await metricsClient.CreateOrUpdateAsync("PromptSentCount", promptSentMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
Console.WriteLine($"Display name: {response.Value.DisplayName}");
```

## Create a User Count Metric

This example creates a metric to count unique users who sent prompts while on the checkout page:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the User Count metric with a filter
var usersPromptSentMetric = new ExperimentMetric(
    LifecycleStage.Active,
    "Users with at least one prompt sent on checkout page",
    "Counts unique users who sent at least one prompt while on the checkout page",
    ["Usage"],
    DesiredDirection.Increase,
    new UserCountDefinition("PromptSent", filter: "Page eq 'checkout.html'")
);

// Create the metric with ID "UsersPromptSent"
var response = await metricsClient.CreateOrUpdateAsync("UsersPromptSent", usersPromptSentMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
```

## Create an Event Rate Metric

This example creates a metric to check the percentage of LLM responses that have good relevance:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the Event Rate metric
var relevanceMetric = new ExperimentMetric(
    LifecycleStage.Active,
    "% evaluated conversations with good relevance",
    "Percentage of evaluated conversations where the LLM response has good relevance (score >= 4)",
    ["Quality"],
    DesiredDirection.Increase,
    new EventRateDefinition(eventName: "EvaluateLLM", rateCondition: "Relevance ge 4")
);

// Create the metric
var response = await metricsClient.CreateOrUpdateAsync("MoMo_PctRelevanceGood", relevanceMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
```

## Create a User Rate Metric

This example creates a metric to track the percentage of users who received an LLM response and then made a high-value purchase:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the User Rate metric
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
var response = await metricsClient.CreateOrUpdateAsync("PctChatToHighValuePurchaseConversion", conversionMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
```

## Create a Sum Metric

This example creates a metric to track the total revenue generated from purchases:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the Sum metric
var revenueMetric = new ExperimentMetric(
    LifecycleStage.Active,
    "Total revenue",
    "Sum of revenue from all purchase transactions",
    ["Business"],
    DesiredDirection.Increase,
    new SumDefinition(eventName: "Purchase", eventProperty: "Revenue")
);

// Create the metric
var response = await metricsClient.CreateOrUpdateAsync("TotalRevenue", revenueMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
```

## Create an Average Metric

This example creates a metric to track the average revenue per purchase:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the Average metric
var avgRevenueMetric = new ExperimentMetric(
    LifecycleStage.Active,
    "Average revenue per purchase",
    "The average revenue per purchase transaction in USD",
    ["Business"],
    DesiredDirection.Increase,
    new AverageDefinition(eventName: "Purchase", eventProperty: "Revenue")
);

// Create the metric
var response = await metricsClient.CreateOrUpdateAsync("AvgRevenuePerPurchase", avgRevenueMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
```

## Create a Percentile Metric

This example creates a metric to measure the 95th percentile of LLM response time:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Define the Percentile metric
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
var response = await metricsClient.CreateOrUpdateAsync("P95ResponseTimeSeconds", p95ResponseTimeMetric);

Console.WriteLine($"Created metric: {response.Value.Id}");
```

## Retrieve a Metric

This example shows how to retrieve a specific metric by its ID:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Get a specific metric by ID
var metric = await metricsClient.GetExperimentMetricAsync("AvgRevenuePerPurchase");

// Access metric properties
Console.WriteLine($"Metric ID: {metric.Value.Id}");
Console.WriteLine($"Display name: {metric.Value.DisplayName}");
Console.WriteLine($"Description: {metric.Value.Description}");
Console.WriteLine($"Lifecycle stage: {metric.Value.Lifecycle}");
Console.WriteLine($"Desired direction: {metric.Value.DesiredDirection}");
```

## List All Metrics

This example shows how to list all metrics:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// List all metrics
Console.WriteLine("Listing all metrics:");
await foreach (var metric in metricsClient.GetExperimentMetricsAsync())
{
    Console.WriteLine($"- {metric.Id}: {metric.DisplayName}");
}
```

## Update an Existing Metric

This example shows how to update an existing metric:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// First, get the existing metric
var existingMetric = await metricsClient.GetExperimentMetricAsync("AvgRevenuePerPurchase");

// Update the metric properties
existingMetric.DisplayName = "Average revenue per purchase [USD]";
existingMetric.Description = "The average revenue per purchase transaction in USD. Refund transactions are excluded.";

// Update the metric - the CreateOrUpdate method is used for both creating and updating
var response = metricsClient.CreateOrUpdate(existingMetric.Id, existingMetric);

Console.WriteLine($"Updated metric: {response.Value.Id}");
Console.WriteLine($"New display name: {response.Value.DisplayName}");
Console.WriteLine($"New description: {response.Value.Description}");
```

## Validate a Metric Definition

This example shows how to validate a metric definition before creating it:

``` csharp
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

// Validate the metric
var validationResult = await metricsClient.ValidateAsync("test_metric_id", metricToValidate);

if (validationResult.Value.IsValid())
{
    Console.WriteLine("Metric definition is valid");

    // Now create the validated metric
    var createdMetric = await metricsClient.CreateOrUpdateAsync("test_metric_id", metricToValidate);
    Console.WriteLine($"Created metric: {createdMetric.Value.Id}");
}
else
{
    Console.WriteLine("Metric definition has errors:");
    foreach (var error in validationResult.Value.Diagnostics)
    {
        Console.WriteLine($"- [{error.Code}] {error.Message}");
    }
}
```

## Delete a Metric

This example shows how to delete a metric:

``` csharp
// Initialize the client
var metricsClient = GetExperimentMetricsClient();

// Delete a metric by ID
var response = await metricsClient.DeleteAsync("test_metric_id");

Console.WriteLine($"Delete operation status: {response.Status}");
```

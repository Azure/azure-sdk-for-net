# Creating Experiment Metrics

This sample demonstrates how to create different types of metrics for your experimentation workspace.

## Creating an Event Count Metric

Event Count metrics count all occurrences of a specific event type.

```C# Snippet:OnlineExperimentation_CreateEventCountMetric
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
```

## Creating a User Count Metric

User Count metrics count unique users who performed a specific action.

```C# Snippet:OnlineExperimentation_CreateUserCountMetric
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
```

## Creating an Event Rate Metric

Event Rate metrics measure the percentage of events meeting a condition.

```C# Snippet:OnlineExperimentation_CreateEventRateMetric
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
```

## Creating a User Rate Metric

User Rate metrics measure the percentage of users who performed action B after action A.

```C# Snippet:OnlineExperimentation_CreateUserRateMetric
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
```

## Creating a Sum Metric

Sum metrics compute the sum of a numeric property across events.

```C# Snippet:OnlineExperimentation_CreateSumMetric
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
```

## Creating an Average Metric

Average metrics calculate the mean of a numeric value across events.

```C# Snippet:OnlineExperimentation_CreateAverageMetric
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
```

## Creating a Percentile Metric

Percentile metrics calculate a specific percentile of a numeric value.

```C# Snippet:OnlineExperimentation_CreatePercentileMetric
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
```

# Updating an Experiment Metric

This sample demonstrates how to update an existing metric by retrieving it, modifying its properties, and saving the changes.

```C# Snippet:OnlineExperimentation_UpdateMetric
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINE_EXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// First, get the existing metric
var existingMetric = client.GetMetric("avg_revenue_per_purchase").Value;

existingMetric.DisplayName = "Average revenue per purchase [USD]";
existingMetric.Description = "The average revenue per purchase transaction in USD. Refund transactions are excluded.";

// Update the metric - the CreateOrUpdate method is used for both creating and updating
var response = client.CreateOrUpdateMetric(existingMetric.Id, existingMetric);

Console.WriteLine($"Updated metric: {response.Value.Id}");
Console.WriteLine($"New display name: {response.Value.DisplayName}");
Console.WriteLine($"New description: {response.Value.Description}");
```

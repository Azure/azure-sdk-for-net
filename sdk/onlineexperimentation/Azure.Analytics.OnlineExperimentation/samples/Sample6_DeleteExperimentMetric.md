# Deleting an Experiment Metric

This sample demonstrates how to delete a metric from your experimentation workspace when it's no longer needed.

```C# Snippet:OnlineExperimentation_DeleteMetric
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// Delete a metric by ID - removes it from the workspace
var response = client.DeleteMetric("test_metric_id");

Console.WriteLine($"Delete operation status: {response.Status}");
```

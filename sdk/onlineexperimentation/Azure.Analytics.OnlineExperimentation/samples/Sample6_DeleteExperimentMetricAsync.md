# Deleting an Experiment Metric Asynchronously

This sample demonstrates how to delete a metric from your experimentation workspace when it's no longer needed using asynchronous operations.

```C# Snippet:OnlineExperimentation_DeleteMetricAsync
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// Delete a metric by ID - removes it from the workspace
var response = await client.DeleteMetricAsync("test_metric_id");

Console.WriteLine($"Delete operation status: {response.Status}");
```

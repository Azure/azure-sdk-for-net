# Validating and Deleting Metrics Asynchronously

This sample demonstrates how to validate metric definitions before creating them and how to delete metrics when they're no longer needed using asynchronous operations.

## Validating a Metric Definition

Validate a metric definition to check for any errors before creating it.

```C# Snippet:OnlineExperimentation_ValidateMetricAsync
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// Define a metric to validate
var metricToValidate = new ExperimentMetric(
    LifecycleStage.Active,
    "Test metric for validation",
    "This metric definition will be validated before creation",
    ["Test"],
    DesiredDirection.Increase,
    new EventCountMetricDefinition("TestEvent")
);

// Validate the metric - checks for errors in the definition
var validationResult = await client.ValidateMetricAsync(metricToValidate);

// Check if the metric definition is valid
if (validationResult.Value.IsValid)
{
    Console.WriteLine("Metric definition is valid");

    // Now create the validated metric
    var createdMetric = await client.CreateOrUpdateMetricAsync("test_metric_id", metricToValidate);
    Console.WriteLine($"Created metric: {createdMetric.Value.Id}");
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
```

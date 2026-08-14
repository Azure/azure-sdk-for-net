# Insights

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

Insights provide analysis and recommendations for your load test runs. You can generate insights for a test run and retrieve them to understand performance patterns.

## Create LoadTestRunClient
```C# Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting TestRun Client
LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);
```

## Generate Insights

Generate insights for a specific test run.

```C# Snippet:Azure_Developer_LoadTesting_GenerateTestRunInsights
string testRunId = "my-test-run-id";

try
{
    Operation operation = loadTestRunClient.GenerateTestRunInsights(WaitUntil.Completed, testRunId);
    Console.WriteLine($"Operation has value: {operation.HasCompleted}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## Get Latest Insights

Retrieve the latest insights for a test run.

```C# Snippet:Azure_Developer_LoadTesting_GetLatestTestRunInsights
try
{
    Response<TestRunInsights> response = loadTestRunClient.GetLatestTestRunInsights(testRunId);
    Console.WriteLine(response.Value);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
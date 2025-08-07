# Begin Test Run

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to get metrics for a loadtest using `LoadTestRunClient`.

## Create TestRunClient
```C# Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting TestRun Client
LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);
```

## Calling CreateAndUpdateTest
```C# Snippet:Azure_Developer_LoadTesting_GetMetrics
string testId = "my-loadtest";
string resourceId = TestEnvironment.ResourceId;
string testRunId = "my-loadtest-run";

// all other data to be sent to testRun
var data = new
{
    testid = testId,
    displayName = "My display name"
};

try
{
    var getTestRunResponse = loadTestRunClient.GetTestRun(testRunId);
    var testRun = getTestRunResponse.Value;

    var getMetricNamespaces = loadTestRunClient.GetMetricNamespaces(testRunId);
    var metricNamespaces = getMetricNamespaces.Value;

    var getMetricDefinitions = loadTestRunClient.GetMetricDefinitions(
        testRunId, metricNamespaces.Value.First().Name
        );
    var metricDefinitions = getMetricDefinitions.Value;

    var metrics = loadTestRunClient.GetMetrics(
            testRunId,
            metricNamespaces.Value.First().Name,
            metricDefinitions.Value.First().Name,
            testRun.StartDateTime.Value.ToString("o") + "/" + testRun.EndDateTime.Value.ToString("o")
        );
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

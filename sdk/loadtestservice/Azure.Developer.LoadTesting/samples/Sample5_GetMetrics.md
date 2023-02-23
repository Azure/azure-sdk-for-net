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
    filters = new[]
    {
        new
        {
            name = "SamplerName",
            values= new[] { "HTTP Request" }
        }
    },
};

try
{
    Response getTestRunResponse = loadTestRunClient.GetTestRun(testRunId);
    JsonDocument testRunJson = JsonDocument.Parse(getTestRunResponse.Content.ToString());

    Response getMetricNamespaces = loadTestRunClient.GetMetricNamespaces(testRunId);
    JsonDocument metricNamespacesJson = JsonDocument.Parse(getMetricNamespaces.Content.ToString());

    Response getMetricDefinitions = loadTestRunClient.GetMetricDefinitions(
        testRunId, metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").ToString()
        );
    JsonDocument metricDefinitionsJson = JsonDocument.Parse(getMetricDefinitions.Content.ToString());

    Pageable<BinaryData> metrics = loadTestRunClient.GetMetrics(
            testRunId,
            metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
            metricDefinitionsJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
            testRunJson.RootElement.GetProperty("startDateTime").GetString() + "/" + testRunJson.RootElement.GetProperty("endDateTime"),
            RequestContent.Create(data)
        );
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

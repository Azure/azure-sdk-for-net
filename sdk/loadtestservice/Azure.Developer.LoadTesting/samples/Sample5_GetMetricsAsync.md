# Begin Test Run

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateAndUpdateTest` method from client `LoadTestRunClient`

## Create TestRunClient
```C# Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
string endpoint = TestEnvironment.Endpoint;
Uri enpointUrl = new Uri("https://" + endpoint);
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting TestRun Client
LoadTestRunClient loadTestRunClient = new LoadTestRunClient(enpointUrl, credential);
```

## Calling CreateAndUpdateTest
```C# Snippet:Azure_Developer_LoadTesting_GetMetricsAsync
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
    Response getTestRunResponse = await loadTestRunClient.GetTestRunAsync(testRunId);
    JsonDocument testRunJson = JsonDocument.Parse(getTestRunResponse.Content.ToString());

    Response getMetricNamespaces = await loadTestRunClient.GetMetricNamespacesAsync(testRunId);
    JsonDocument metricNamespacesJson = JsonDocument.Parse(getMetricNamespaces.Content.ToString());

    Response getMetricDefinitions = await loadTestRunClient.GetMetricDefinitionsAsync(
        testRunId, metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").ToString()
        );
    JsonDocument metricDefinitionsJson = JsonDocument.Parse(getMetricDefinitions.Content.ToString());

    AsyncPageable<BinaryData> metrics = loadTestRunClient.GetMetricsAsync(
            testRunId,
            metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
            metricDefinitionsJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
            testRunJson.RootElement.GetProperty("startDateTime").GetString() + "/" + testRunJson.RootElement.GetProperty("endDateTime"),
            null
        );
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

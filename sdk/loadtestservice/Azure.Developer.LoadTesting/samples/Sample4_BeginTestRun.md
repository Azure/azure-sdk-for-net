# Begin Test Run

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to run a load test using `LoadTestRunClient`.

## Create TestRunClient
```C# Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting TestRun Client
LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);
```

## Calling BeginTestRun
```C# Snippet:Azure_Developer_LoadTesting_BeginTestRun
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
    TestRunResultOperation operation = loadTestRunClient.BeginTestRun(
            WaitUntil.Started, testRunId, RequestContent.Create(data)
       );

    // get initial response
    Response initialResponse = operation.GetRawResponse();
    Console.WriteLine(initialResponse.Content.ToString());

    // waiting for test run to get completed
    operation.WaitForCompletion();

    // final response
    Response finalResponse = operation.GetRawResponse();
    Console.WriteLine(finalResponse.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

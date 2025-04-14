# Create or Update Test Profile

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to create a test profile run using the `LoadTestRunClient` client.

## Create LoadTestRunClient

```C# Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting TestRun Client
LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);
```

## Calling BeginTestProfile

```C# Snippet:Azure_Developer_LoadTesting_BeginTestProfileRunAsync
string testProfileRunId = "my-test-profile-run-id";
string testProfileId = "my-test-profile-id"; // This test profile is already created

var data = new
{
    description = "This is created using SDK",
    displayName = "SDK's Test Profile Run",
    testProfileId = testProfileId,
};

try
{
    var operation = await loadTestRunClient.BeginTestProfileRunAsync(WaitUntil.Started, testProfileRunId, RequestContent.Create(data));

    // get initial response
    Response initialResponse = operation.GetRawResponse();
    Console.WriteLine(initialResponse.Content.ToString());

    // waiting for test profile run to get completed
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

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

## Calling BeginTestRun
```C# Snippet:Azure_Developer_LoadTesting_BeginTestRunAsync
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
    TestRunOperation operation = await loadTestRunClient.BeginTestRunAsync(
            WaitUntil.Started, testRunId, RequestContent.Create(data)
       );

    // get inital response
    Response initialResponse = operation.GetRawResponse();
    Console.WriteLine(initialResponse.Content.ToString());

    // waiting for testrun to get completed
    await operation.WaitForCompletionAsync();

    // final reponse
    Response finalResponse = operation.GetRawResponse();
    Console.WriteLine(finalResponse.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

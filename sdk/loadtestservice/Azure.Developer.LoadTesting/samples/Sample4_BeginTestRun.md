# Begin Test Run

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to run a load test using `LoadTestRunClient`.

## Create TestRunClient
```C# Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
string endpoint = TestEnvironment.Endpoint;
Uri enpointUrl = new Uri("https://" + endpoint);
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting TestRun Client
LoadTestRunClient loadTestRunClient = new LoadTestRunClient(enpointUrl, credential);
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
    TestRunOperation operation = loadTestRunClient.BeginTestRun(
            WaitUntil.Started, testRunId, RequestContent.Create(data)
       );

    // get inital response
    Response initialResponse = operation.GetRawResponse();
    Console.WriteLine(initialResponse.Content.ToString());

    // waiting for testrun to get completed
    operation.WaitForCompletion();

    // final reponse
    Response finalResponse = operation.GetRawResponse();
    Console.WriteLine(finalResponse.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

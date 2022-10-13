# Create And Update Test

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateAndUpdateTest` method from SubClient `LoadTestAdministrationClient`

## Create TestRunClient
```C# Snippet:CreatingTestRunClient
string endpoint = TestEnvironment.Endpoint;
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Client
LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

// getting appropirate Subclient
TestRunClient testRunClient = loadTestingClient.getLoadTestRun();
```

## Calling CreateAndUpdateTest
```C# Snippet:CreateAndUpdateTest
// provide unique identifier for your test
string testId = "my-test-id";

// provide unique testrun id
string testRunId = "my-test-run-id";

// all other data to be sent to testRun
var data = new
{
    testid = testId,
    displayName = "Some display name"
};

try
{
    // uploading file
    Response response = testRunClient.CreateAndUpdateTest(testRunId, RequestContent.Create(data));
    // if the test is created successfully, printing response
    Console.WriteLine(response.Content);
}
catch (Exception e)
{
    Console.WriteLine(String.Format("Error : ", e.Message));
}
```
To see the full example source files, see:
* [Sample4_CreateAndUpdateTest.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/tests/Samples/Sample4_CreateAndUpdateTest.cs)
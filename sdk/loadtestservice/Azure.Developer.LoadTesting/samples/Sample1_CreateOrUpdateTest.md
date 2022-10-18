# Create or Update Load Test 

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateOrUpdateTest` method from SubClient `LoadTestAdministrationClient`

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreatingClient
string endpoint = TestEnvironment.Endpoint;
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Client
LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

// getting appropriate Subclient
LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();
```

## Calling CreateOrUpdateTest
```C# Snippet:Azure_Developer_LoadTesting_CreatOrUpdateTest
// provide unique identifier for your test
string testId = "my-test-id";

// all data needs to be passed while creating a loadtest
var data = new
{
    description = "This is created using SDK",
    displayName = "SDK's LoadTest",
    loadTestConfig = new
    {
        engineInstances = 1,
        splitAllCSVs = false,
    },
    secrets = new { },
    enviornmentVariables = new { },
    passFailCriteria = new
    {
        passFailMetrics = new { },
    }
};

try
{
    Response response = loadTestAdministrationClient.CreateOrUpdateTest(testId, RequestContent.Create(data));

    // if the test is created successfully, printing response
    Console.WriteLine(response.Content);
}
catch (Exception e)
{
    Console.WriteLine(String.Format("Error : ", e.Message));
}
```

To see the full example source files, see:
* [Sample1_CreateOrUpdateTest.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/tests/Samples/Sample1_CreateOrUpdateTest.cs) 
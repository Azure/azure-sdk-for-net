# Create or Update App Component

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateOrUpdateAppComponentAsync` method from SubClient `LoadTestAdministrationClient`

## Create LoadTestAdministrationClient
```C# Snippet:CreatingClient
string endpoint = TestEnvironment.Endpoint;
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Client
LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

// getting appropirate Subclient
LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();
```

## Calling CreateOrUpdateAppComponent
```C# Snippet:CreateOrUpdateAppComponentAsync
// provide unique identifier for your test
string testId = "my-test-id";

// provide unique app component id
string appComponentId = "my-app-component-id";

string appComponentConnectionString = "/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";
// all other data to be sent to AppCompoent
var data = new
{
    testid = testId,
    name = "New App Component",
    value = new
    {
        appComponentConnectionString = new
        {
            resourceId = appComponentConnectionString,
            resourceName = "App-Service-Sample-Demo",
            resourceType = "Microsoft.Web/sites",
            subscriptionId = "7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a"
        }
    }
};

try
{
    // uploading file
    Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(appComponentId, RequestContent.Create(data));
    // if the test is created successfully, printing response
    Console.WriteLine(response.Content);
}
catch (Exception e)
{
    Console.WriteLine(String.Format("Error : ", e.Message));
}
```
To see the full example source files, see:
* [Sample3_CreateOrUpdateAppComponentAsync.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/tests/Samples/Sample3_CreateOrUpdateAppComponentAsync.cs)

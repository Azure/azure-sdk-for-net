# Create or Update App Component

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateOrUpdateAppComponentAsync` method from SubClient `LoadTestAdministrationClient`

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreatingClient
string endpoint = TestEnvironment.Endpoint;
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Client
LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

// getting appropriate Subclient
LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();
```

## Calling CreateOrUpdateAppComponent
```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateAppComponentAsync
// provide unique identifier for your test
string testId = "my-test-id";

// provide unique app component id
string appComponentId = "my-app-component-id";
string subscriptionId = "00000000-0000-0000-0000-000000000000";

string appComponentConnectionString = "/subscriptions/" + subscriptionId + "/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";

// all other data to be sent to AppComponent
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
            subscriptionId = subscriptionId
        }
    }
};

try
{
    // create or update app component
    Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(appComponentId, RequestContent.Create(data));

    // if successfully, printing response
    Console.WriteLine(response.Content);
}
catch (Exception e)
{
    Console.WriteLine(String.Format("Error : ", e.Message));
}
```
To see the full example source files, see:
* [Sample3_CreateOrUpdateAppComponentAsync.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/tests/Samples/Sample3_CreateOrUpdateAppComponentAsync.cs)

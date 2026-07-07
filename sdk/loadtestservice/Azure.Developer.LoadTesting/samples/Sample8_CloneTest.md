# Clone Test

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

Cloning a test creates a new test from an existing test, copying the configuration, files, and settings.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Clone a Test

Create a new test by cloning from an existing test using the `sourceTestId` property.

```C# Snippet:Azure_Developer_LoadTesting_CloneTest
string sourceTestId = "existing-test-id";
string newTestId = "cloned-test-id";

var data = new
{
    sourceTestId = sourceTestId,
};

try
{
    Response response = loadTestAdministrationClient.CreateOrUpdateTest(newTestId, RequestContent.Create(data));
    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
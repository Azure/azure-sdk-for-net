# Create or Update Test Profile

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to create a new test profile using the `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient

```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Calling CreateOrUpdateTestProfile

```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTestProfileAsync
string testProfileId = "my-test-profile-id";
string testId = "my-test-id"; // This test is already created
string targetResourceId = TestEnvironment.TargetResourceId;

var data = new
{
    description = "This is created using SDK",
    displayName = "SDK's Test Profile",
    testId = testId,
    targetResourceId = targetResourceId,
    targetResourceConfigurations = new
    {
        kind = "FunctionsFlexConsumption",
        configurations = new
        {
            config1 = new
            {
                instanceMemoryMB = 2048,
                httpConcurrency = 20
            },
            config2 = new
            {
                instanceMemoryMB = 4096,
                httpConcurrency = 20
            }
        }
    }
};

try
{
    Response response = await loadTestAdministrationClient.CreateOrUpdateTestProfileAsync(testProfileId, RequestContent.Create(data));
    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

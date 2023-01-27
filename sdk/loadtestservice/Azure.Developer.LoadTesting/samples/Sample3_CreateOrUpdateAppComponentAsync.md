# Create or Update App Component

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to create or update app components using `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Calling CreateOrUpdateAppComponent
```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateAppComponentAsync
string testId = "my-loadtest";
string resourceId = TestEnvironment.ResourceId;

try
{
    Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(testId,
            RequestContent.Create(
                    new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                    {
                        { "components",  new Dictionary<string, Dictionary<string, string>>
                            {
                                { resourceId, new Dictionary<string, string>
                                    {
                                        { "resourceId", resourceId },
                                        { "resourceName", "App-Service-Sample-Demo" },
                                        { "resourceType", "Microsoft.Web/sites" },
                                        { "kind", "web" }
                                    }
                                }
                            }
                        }
                    }
                )
        );

    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

# Create or Update App Component

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateOrUpdateAppComponent` method from client `LoadTestAdministrationClient`

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
string endpoint = TestEnvironment.Endpoint;
Uri enpointUrl = new Uri("https://"+endpoint);
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(enpointUrl, credential);
```

## Calling CreateOrUpdateAppComponent
```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateAppComponent
string testId = "my-loadtest";
string resourceId = TestEnvironment.ResourceId;

try
{
    Response response = loadTestAdministrationClient.CreateOrUpdateAppComponents(testId, RequestContent.Create(
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
        ));

    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

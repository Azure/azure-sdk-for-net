# Test Plan Recommendation

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

Test plan recommendation generates an optimized test plan configuration based on the target resource, helping you configure your load test.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Generate Test Plan Recommendation

Generate a test plan recommendation for a given test and target resource.

```C# Snippet:Azure_Developer_LoadTesting_GenerateTestPlanRecommendation
string testId = "my-test-id";

try
{
    Operation operation = loadTestAdministrationClient.GenerateTestPlanRecommendations(WaitUntil.Completed,testId, null);
    Console.WriteLine($"Operation has value: {operation.HasCompleted}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
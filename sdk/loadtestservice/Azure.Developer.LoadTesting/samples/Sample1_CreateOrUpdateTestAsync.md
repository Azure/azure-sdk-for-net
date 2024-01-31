# Create or Update Load Test

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to create a new load test using the `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Calling CreateOrUpdateTest
```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTestAsync
string testId = "my-test-id";
Uri keyVaultSecretUrl = new Uri("https://sdk-testing-keyvault.vault.azure.net/secrets/sdk-secret");

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
    secrets = new
    {
        secret1 = new
        {
            value = keyVaultSecretUrl.ToString(),
            type = "AKV_SECRET_URI"
        }
    },
    enviornmentVariables = new
    {
        myVariable = "my-value"
    },
    passFailCriteria = new
    {
        passFailMetrics = new
        {
            condition1 = new
            {
                clientmetric = "response_time_ms",
                aggregate = "avg",
                condition = ">",
                value = 300
            },
            condition2 = new
            {
                clientmetric = "error",
                aggregate = "percentage",
                condition = ">",
                value = 50
            },
            condition3 = new
            {
                clientmetric = "latency",
                aggregate = "avg",
                condition = ">",
                value = 200,
                requestName = "GetCustomerDetails"
            }
        },
    }
};

try
{
    Response response = await loadTestAdministrationClient.CreateOrUpdateTestAsync(testId, RequestContent.Create(data));
    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

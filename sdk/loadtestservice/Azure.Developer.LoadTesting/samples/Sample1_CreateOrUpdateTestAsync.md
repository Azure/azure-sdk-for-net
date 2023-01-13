# Create or Update Load Test

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to create a new load test using the `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
string endpoint = TestEnvironment.Endpoint;
Uri enpointUrl = new Uri("https://"+endpoint);
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(enpointUrl, credential);
```

## Calling CreateOrUpdateTest
```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTestAsync
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
    secrets = new
    {
        secret1 = new
        {
            value = "https://sdk-testing-keyvault.vault.azure.net/secrets/sdk-secret",
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

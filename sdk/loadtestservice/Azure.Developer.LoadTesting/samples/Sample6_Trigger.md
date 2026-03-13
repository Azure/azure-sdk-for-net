# Triggers

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

Triggers allow you to schedule load tests to run at a specified time with optional recurrence.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Create or Update a Trigger

Create a scheduled trigger that runs a load test daily.

```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTrigger
string triggerId = "my-trigger-id";
string testId = "my-test-id";

var data = new
{
    displayName = "My Scheduled Trigger",
    kind = "ScheduleTestsTrigger",
    testIds = new[] { testId },
    startDateTime = DateTimeOffset.UtcNow.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
    recurrence = new
    {
        frequency = "Daily",
        interval = 1,
        recurrenceEnd = new
        {
            endDateTime = DateTimeOffset.UtcNow.AddDays(30).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        }
    }
};

try
{
    Response response = loadTestAdministrationClient.CreateOrUpdateTrigger(triggerId, RequestContent.Create(data));
    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## Get a Trigger

Retrieve a trigger by its Id.

```C# Snippet:Azure_Developer_LoadTesting_GetTrigger
string triggerId = "my-trigger-id";

try
{
    Response<LoadTestingTrigger> response = loadTestAdministrationClient.GetTrigger(triggerId);
    Console.WriteLine($"Trigger Id: {response.Value.TriggerId}");
    Console.WriteLine($"Display Name: {response.Value.DisplayName}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## List Triggers

List all triggers in the load testing resource.

```C# Snippet:Azure_Developer_LoadTesting_ListTriggers
try
{
    Pageable<LoadTestingTrigger> triggers = loadTestAdministrationClient.GetTriggers();

    foreach (LoadTestingTrigger trigger in triggers)
    {
        Console.WriteLine($"Trigger Id: {trigger.TriggerId}");
        Console.WriteLine($"Display Name: {trigger.DisplayName}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## Delete a Trigger

Delete a trigger by its Id.

```C# Snippet:Azure_Developer_LoadTesting_DeleteTrigger
string triggerId = "my-trigger-id";

try
{
    Response response = loadTestAdministrationClient.DeleteTrigger(triggerId);
    Console.WriteLine($"Trigger {triggerId} deleted successfully. Status: {response.Status}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
# Notification Rules

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

Notification rules allow you to configure alerts for load test events such as test run started, test run ended, trigger completed, and trigger disabled.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Create or Update a Notification Rule

Create a notification rule that sends alerts when a test run starts or ends.

```C# Snippet:Azure_Developer_LoadTesting_CreateOrUpdateNotificationRule
string notificationRuleId = "my-notification-rule-id";
string actionGroupResourceId = "/subscriptions/<subscription-id>/resourceGroups/<resource-group>/providers/microsoft.insights/actionGroups/<action-group-name>";

var data = new
{
    displayName = "My Notification Rule",
    scope = "Tests",
    actionGroupIds = new[] { actionGroupResourceId },
    events = new object[]
    {
        new
        {
            eventType = "TestRunEnded",
            condition = new
            {
                testRunStatuses = new[] { "DONE", "CANCELLED", "FAILED" },
                testRunResults = new[] { "PASSED", "NOT_APPLICABLE" }
            }
        },
        new
        {
            eventType = "TestRunStarted"
        }
    }
};

try
{
    Response response = loadTestAdministrationClient.CreateOrUpdateNotificationRule(notificationRuleId, RequestContent.Create(data));
    Console.WriteLine(response.Content.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## Get a Notification Rule

Retrieve a notification rule by its Id.

```C# Snippet:Azure_Developer_LoadTesting_GetNotificationRule
string notificationRuleId = "my-notification-rule-id";

try
{
    Response<NotificationRule> response = loadTestAdministrationClient.GetNotificationRule(notificationRuleId);
    Console.WriteLine($"Notification Rule Id: {response.Value.NotificationRuleId}");
    Console.WriteLine($"Display Name: {response.Value.DisplayName}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## List Notification Rules

List all notification rules in the load testing resource.

```C# Snippet:Azure_Developer_LoadTesting_ListNotificationRules
try
{
    Pageable<NotificationRule> notificationRules = loadTestAdministrationClient.GetNotificationRules();

    foreach (NotificationRule rule in notificationRules)
    {
        Console.WriteLine($"Notification Rule Id: {rule.NotificationRuleId}");
        Console.WriteLine($"Display Name: {rule.DisplayName}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## Delete a Notification Rule

Delete a notification rule by its Id.

```C# Snippet:Azure_Developer_LoadTesting_DeleteNotificationRule
string notificationRuleId = "my-notification-rule-id";

try
{
    Response response = loadTestAdministrationClient.DeleteNotificationRule(notificationRuleId);
    Console.WriteLine($"Notification Rule {notificationRuleId} deleted successfully. Status: {response.Status}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
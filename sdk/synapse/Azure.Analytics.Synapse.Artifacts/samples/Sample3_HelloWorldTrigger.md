```C# Snippet:CreateTriggerClientPrep
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

string triggerName = "Test-Trigger";
```

```C# Snippet:CreateTriggerClient
TriggerClient client = new TriggerClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

```C# Snippet:CreateTrigger
TriggerResource triggerResource = new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence()));
TriggerCreateOrUpdateTriggerOperation operation = client.StartCreateOrUpdateTrigger(triggerName, triggerResource);
Response<TriggerResource> createdTrigger = await operation.WaitForCompletionAsync();
```

```C# Snippet:RetrieveTrigger
TriggerResource retrievedTrigger = client.GetTrigger(triggerName);
```

```C# Snippet:ListTriggers
Pageable<TriggerResource> triggers = client.GetTriggersByWorkspace();
foreach (TriggerResource trigger in triggers)
{
    System.Console.WriteLine(trigger.Name);
}
```

```C# Snippet:DeleteTrigger
TriggerDeleteTriggerOperation deleteOperation = client.StartDeleteTrigger(triggerName);
await deleteOperation.WaitForCompletionAsync();
```
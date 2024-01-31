# Understand how to work with long-running operations

This sample demonstrates how to work with long-running operations, which consist of an initial request to start the operation followed by polling to determine when the operation has completed or failed. Several features of the Azure Cognitive Service for Language are implemented as long-running operations, such as [analyzing healthcare entities][analyze-healthcare-entities].

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Poll a long-running operation automatically

To automatically poll the status of a long-running operation until it has completed, pass `WaitUntil.Completed` as a parameter in the initial request.

```C# Snippet:Sample7_AnalyzeHealthcareEntitiesConvenienceAsync_WaitForCompletion
// Perform the text analysis operation.
AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, batchedDocuments);
```

By default, this will retrieve the latest status of the operation from the service once per second, but a different polling interval can be specified as a parameter. Similarly, the service can return a `Retry-After` header as a way of suggesting a polling interval itself, which is automatically honored by default.

## Poll a long-running operation manually

This approach is for users who want to retain synchronous behavior and/or who have specific code paths that must run during the polling process. To manually poll the status of a long-running operation until it has completed, first pass `WaitUntil.Started` as a parameter in the initial request. Then, call the `UpdateStatus` method on the operation and check its `HasCompleted` property. Repeat until `HasCompleted` is `true` while using a moderate polling interval and keeping in mind that the service can suddenly start returning errors (such as `429 Too Many Requests`) to throttle overly aggressive pollers. The service can also return a `Retry-After` header in any of its responses as a way of requesting that the client wait a specific amount of time before polling again and can throttle a client that does not respect this interval.

```C# Snippet:SampleLROPolling_PollOperation
// Perform the text analysis operation.
AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Started, batchedDocuments);
TimeSpan pollingInterval = new(1000);

while (true)
{
    // View the operation status.
    Console.WriteLine($"Created On   : {operation.CreatedOn}");
    Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
    Console.WriteLine($"Id           : {operation.Id}");
    Console.WriteLine($"Status       : {operation.Status}");
    Console.WriteLine($"Last Modified: {operation.LastModified}");
    Console.WriteLine();

    operation.UpdateStatus();
    if (operation.HasCompleted)
    {
        break;
    }

    Thread.Sleep(pollingInterval);
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[analyze-healthcare-entities]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample7_AnalyzeHealthcareEntities.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md

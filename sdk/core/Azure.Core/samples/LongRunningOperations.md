# Azure.Core long-running operation samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. 

Some operations take long time to complete and require polling for their status. Methods starting long-running operations return either `*Operation<T>` or `*PageableOperation<T>` types.

## Awaiting completion of the operation

The `WaitForCompletionAsync` method is an easy way to wait for operation completion and get the resulting value.

```C# Snippet:OperationCompletion
// create a client
SecretClient client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

// Start the operation
DeleteSecretOperation operation = await client.StartDeleteSecretAsync("SecretName");

Response<DeletedSecret> response = await operation.WaitForCompletionAsync();
DeletedSecret value = response.Value;

Console.WriteLine(value.Name);
Console.WriteLine(value.ScheduledPurgeDate);
```

## Manually updating the status

The `UpdateStatusAsync` method can be used to manually poll for the operation status. The `HasCompleted` property would be updated to indicate if operation is completed.

```C# Snippet:OperationUpdateStatus
// Start the operation
DeleteSecretOperation operation = await client.StartDeleteSecretAsync("SecretName");

await operation.UpdateStatusAsync();

// HasCompleted indicates if operation has completed successfully or otherwise
Console.WriteLine(operation.HasCompleted);
// HasValue indicated is operation Value is available, for some operations it can return true even when operation
// hasn't completed yet.
Console.WriteLine(operation.HasValue);
```

## Accessing results for Pageable Operations

A Pageable Operation is use when the service call returns multiple values in pages after the Long Running Operation completes. The results can be access with the `GetValues()`, `GetValuesAsync()` methods which return `Pageable<T>/AsyncPageable<T>` respectively.

To access the result you can iterate over the `Pageable<T>/AsyncPageable<T>`. For more information see [Consuming Service Methods Returning Pageable/AsyncPageable](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core#consuming-service-methods-returning-asyncpageablet).

### Using `GetValuesAsync()`
The `GetValuesAsync` method will contain the `AsyncPageable<T>` results.

```C# Snippet:PageableOperationGetValuesAsync
// create a client
var client = new TextAnalyticsClient(new Uri("http://example.com"), new DefaultAzureCredential());
var document = new List<string>() { "document with information" };

// Start the operation
AnalyzeHealthcareEntitiesOperation healthOperation = client.StartAnalyzeHealthcareEntities(document);

await healthOperation.WaitForCompletionAsync();

await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.GetValuesAsync())
{
    foreach (HealthcareEntity entity in documentsInPage[0].Entities)
    {
        Console.WriteLine($"    Entity: {entity.Text}");
    }
}
```

### Using `GetValues()`
The `GetValues` method will contain the `Pageable<T>` results.

```C# Snippet:PageableOperationGetValues
// create a client
var client = new TextAnalyticsClient(new Uri("http://example.com"), new DefaultAzureCredential());
var document = new List<string>() { "document with information" };

// Start the operation
AnalyzeHealthcareEntitiesOperation healthOperation = client.StartAnalyzeHealthcareEntities(document);

await healthOperation.WaitForCompletionAsync();

foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.GetValues())
{
    foreach (HealthcareEntity entity in documentsInPage[0].Entities)
    {
        Console.WriteLine($"    Entity: {entity.Text}");
    }
}
```

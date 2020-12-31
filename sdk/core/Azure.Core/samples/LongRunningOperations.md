# Azure.Core long-running operation samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. 

Some operations take long time to complete and require polling for their status. Methods starting long-running operations return `*Operation<T>` types.

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

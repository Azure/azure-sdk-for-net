# Azure.Core long-running operation samples

Some operations take long time to complete and requre polling for status such operations are exposed as methods returning `*Operation<T>` types.

## Awaiting completion of the operation

```C# Snippet:OperationCompletion
// create a client
SecretClient client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

// Start the operation
DeleteSecretOperation operation = client.StartDeleteSecret("SecretName");

Response<DeletedSecret> response = await operation.WaitForCompletionAsync();
DeletedSecret value = response.Value;

Console.WriteLine(value.Name);
Console.WriteLine(value.ScheduledPurgeDate);
```

## Manually updating the status

```C# Snippet:OperationUpdateStatus
// Start the operation
DeleteSecretOperation operation = client.StartDeleteSecret("SecretName");

await operation.UpdateStatusAsync();

// HasCompleted indicates if operation has completed successfully or otherwise
Console.WriteLine(operation.HasCompleted);
// HasValue indicated is operation Value is available, for some operations it can return true even when operation
// hasn't completed yet.
Console.WriteLine(operation.HasValue);
```

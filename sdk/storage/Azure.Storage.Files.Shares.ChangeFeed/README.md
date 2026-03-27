# Azure Storage Files Shares Change Feed client library for .NET

> Server Version: 2026-02-06

Azure Files Change Feed tracks data and metadata operations in an Azure file share and writes them
to an append-only, immutable log. The change feed enables you to determine what changed over time,
build efficient incremental backup solutions, and react to file share mutations in near real-time.

Change feed is enabled per file share and records operations performed via both SMB and REST protocols,
including creates, renames, deletes, writes, metadata updates, and security descriptor changes.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Files Shares Change Feed client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Storage.Files.Shares.ChangeFeed --prerelease
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] with an Azure File Share that has change feed enabled.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

Change feed must be enabled on the file share by setting the `x-ms-file-enable-change-feed: true`
header when creating or updating the share (requires API version 2026-02-06 or later).

### Authenticate the Client

```C#
// Using a connection string
ShareChangeFeedClient changeFeedClient = new ShareChangeFeedClient(
    connectionString,
    "myfileshare");

// Using a shared key credential
ShareChangeFeedClient changeFeedClient = new ShareChangeFeedClient(
    new Uri("https://myaccount.file.core.windows.net"),
    "myfileshare",
    new StorageSharedKeyCredential(accountName, accountKey));

// Using the extension method on ShareClient
ShareServiceClient serviceClient = new ShareServiceClient(connectionString);
ShareClient shareClient = serviceClient.GetShareClient("myfileshare");
ShareChangeFeedClient changeFeedClient = shareClient.GetShareChangeFeedClient();
```

## Key concepts

The change feed is stored as blobs in a hidden container in the same storage account as the file share.
Each share that has change feed enabled gets its own container (named `$fileschangefeed-<GUID>`).
Events are recorded in Apache Avro format and organized into 15-minute time-windowed segments.

Each `ShareChangeFeedEvent` contains:
- **Reason** - The operation type (e.g., `SmbCreate`, `RestDelete`, `SmbWrite`)
- **Protocol** - The protocol used (`SMB` or `REST`)
- **EventTime** - When the event occurred
- **EventData** - File-specific details including `FileId`, `FileName`, `FullFilePath`, and `Identity`
- **ContainerVersionNumber** - Used for filtering events between snapshots

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Get all events in the change feed

```C#
List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>();
await foreach (ShareChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync())
{
    events.Add(changeFeedEvent);
}
```

### Get events between a start and end time

```C#
// The client will round start time down and end time up to the nearest 15-minute boundary.
DateTimeOffset startTime = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero);
DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero);

await foreach (ShareChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
    start: startTime,
    end: endTime))
{
    events.Add(changeFeedEvent);
}
```

### Resume with continuationToken

```C#
string continuationToken = null;
await foreach (Page<ShareChangeFeedEvent> page in changeFeedClient.GetChangesAsync().AsPages(pageSizeHint: 10))
{
    foreach (ShareChangeFeedEvent changeFeedEvent in page.Values)
    {
        events.Add(changeFeedEvent);
    }

    // Save the continuation token to resume later.
    continuationToken = page.ContinuationToken;
    break;
}

// Resume iterating from the previous position.
await foreach (ShareChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
    continuationToken: continuationToken))
{
    events.Add(changeFeedEvent);
}
```

### Get changes between two snapshots

```C#
// Query events that occurred between two file share snapshots, filtered by container version ID.
await foreach (ShareChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesBetweenSnapshotsAsync(
    beginSnapshot: "2024-01-15T08:00:00.000Z",
    endSnapshot: "2024-01-15T12:00:00.000Z"))
{
    events.Add(changeFeedEvent);
}
```

## Troubleshooting

All Azure Storage service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes]. Many of these errors are recoverable.

Common issues:
- **Change Feed not enabled**: Ensure `x-ms-file-enable-change-feed: true` was set when creating or updating the share.
- **Container not found**: The change feed container is created asynchronously after enabling. Allow a few minutes for it to appear.

## Next steps

For more information about Azure Files Change Feed, see the [product documentation][product_docs].

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Files.Shares.ChangeFeed/src
[package]: https://www.nuget.org/packages/Azure.Storage.Files.Shares.ChangeFeed/
[product_docs]: https://learn.microsoft.com/azure/storage/files/storage-files-change-feed
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/file-service-error-codes
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

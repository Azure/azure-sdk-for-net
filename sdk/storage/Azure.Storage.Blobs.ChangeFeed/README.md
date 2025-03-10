# Azure Storage Blobs Change Feed client library for .NET

> Server Version: 2021-02-12, 2020-12-06, 2020-10-02, 2020-08-04, 2020-06-12 2020-04-08, 2020-02-10, and 2019-12-12

The purpose of the change feed is to provide transaction logs of all the changes that occur to
the blobs and the blob metadata in your storage account. The change feed provides ordered,
guaranteed, durable, immutable, read-only log of these changes. Client applications can read these
logs at any time. The change feed enables you to build efficient and scalable solutions that
process change events that occur in your Blob Storage account at a low cost.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Blobs client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Storage.Blobs.ChangeFeed --prerelease
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

### Authenticate the Client

Authentication works the same as in [Azure.Storage.Blobs][authenticating_with_blobs].

## Key concepts

The change feed is stored as blobs in a special container in your storage account at standard blob
pricing cost. You can control the retention period of these files based on your requirements
(See the conditions of the current release). Change events are appended to the change feed as records
in the Apache Avro format specification: a compact, fast, binary format that provides rich data structures
with inline schema. This format is widely used in the Hadoop ecosystem, Stream Analytics, and Azure Data
Factory.

You can process these logs incrementally or in-full. Any number of client applications can independently
read the change feed, in parallel, and at their own pace. Analytics applications such as Apache Drill or
Apache Spark can consume logs directly as Avro files, which let you process them at a low-cost, with
high-bandwidth, and without having to write a custom application.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Get all events in the Change Feed
```C# Snippet:SampleSnippetsChangeFeed_GetAllEvents
// Get all the events in the change feed.
List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();
await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync())
{
    changeFeedEvents.Add(changeFeedEvent);
}
```

### Get events between a start and end time
```C# Snippet:SampleSnippetsChangeFeed_GetEventsBetweenStartAndEndTime
// Create the start and end time.  The change feed client will round start time down to
// the nearest hour, and round endTime up to the next hour if you provide DateTimeOffsets
// with minutes and seconds.
DateTimeOffset startTime = new DateTimeOffset(2017, 3, 2, 15, 0, 0, TimeSpan.Zero);
DateTimeOffset endTime = new DateTimeOffset(2020, 10, 7, 2, 0, 0, TimeSpan.Zero);

// You can also provide just a start or end time.
await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
    start: startTime,
    end: endTime))
{
    changeFeedEvents.Add(changeFeedEvent);
}
```

### Resume with continuationToken
```C# Snippet:SampleSnippetsChangeFeed_ResumeWithCursor
string continuationToken = null;
await foreach (Page<BlobChangeFeedEvent> page in changeFeedClient.GetChangesAsync().AsPages(pageSizeHint: 10))
{
    foreach (BlobChangeFeedEvent changeFeedEvent in page.Values)
    {
        changeFeedEvents.Add(changeFeedEvent);
    }

    // Get the change feed continuation token.  The continuation token is not required to get each page of events,
    // it is intended to be saved and used to resume iterating at a later date.
    continuationToken = page.ContinuationToken;
    break;
}

// Resume iterating from the pervious position with the continuation token.
await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
    continuationToken: continuationToken))
{
    changeFeedEvents.Add(changeFeedEvent);
}
```

## Troubleshooting
All Blob service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.
If multiple failures occur, an [AggregateException][AggregateException] will be thrown,
containing each failure instance.

## Next steps

Get started with our [Change Feed samples][samples]:

1. [Hello World](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs.ChangeFeed/samples/Sample01a_HelloWorld.cs): Get changes that have occurred in your storage account (or [asynchronously](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs.ChangeFeed/samples/Sample01b_HelloWorldAsync.cs))
2. [Auth](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs.ChangeFeed/samples/Sample02_Auth.cs): Authenticate with connection strings, public access, shared keys, shared access signatures, and Azure Active Directory.


## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs.ChangeFeed/src
[package]: https://www.nuget.org/packages/Azure.Storage.Blobs.ChangeFeed/
[product_docs]: https://learn.microsoft.com/azure/storage/blobs/storage-blob-change-feed
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[authenticating_with_blobs]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/samples/Sample02_Auth.cs
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/blob-service-error-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs.ChangeFeed/samples/
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[AggregateException]: https://learn.microsoft.com/dotnet/api/system.aggregateexception?view=net-9.0

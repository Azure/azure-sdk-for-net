# Release History

## 5.0.0-beta.2 (Unreleased)


## 5.0.0-beta.1 (2020-11-10)

This is the first preview of the next generation of `Microsoft.Azure.WebJobs.Extension.Storage` which has been integrated with latest Azure Storage SDK that follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

The `Microsoft.Azure.WebJobs.Extension.Storage` offers drop-in replacement for scenarios where `Queue`, `QueueTrigger`, `Blob` and `BlobTrigger` attributes were bound to BCL types or user defined POCOs. Advanced scenarios may require code changes. `Table` attribute is not supported in this version.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Major changes and features 
The `Microsoft.Azure.WebJobs.Extension.Storage` has been split per storage service. Please refer to [`Microsoft.Azure.WebJobs.Extension.Storage.Blobs`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/CHANGELOG.md) and [`Microsoft.Azure.WebJobs.Extension.Storage.Queues`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Queues/CHANGELOG.md) for detailed list of changes.

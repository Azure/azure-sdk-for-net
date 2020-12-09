# Release History

## 5.0.0-beta.2 (Unreleased)


## 5.0.0-beta.1 (2020-11-10)

This is the first preview of the next generation of `Microsoft.Azure.WebJobs.Extension.Storage` which has been integrated with latest Azure Storage SDK that follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

The `Microsoft.Azure.WebJobs.Extension.Storage.Queues` offers drop-in replacement for scenarios where `Queue` and `QueueTrigger` attributes were bound to BCL types or user defined POCOs. Advanced scenarios like binding to Azure Storage Queues SDK types or using `QueueProcessor` may require code changes.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Major changes and features 
- The extension has been split per storage service, i.e. `Microsoft.Azure.WebJobs.Extension.Storage.Queues` has been created.
- The extension uses V12 Azure Storage SDK.
- Added support for token credential authentication using Azure.Identity library, including support for managed identity and client secret credentials.
- This version does not Base64-encode queue messages. Support for that is planned for future releases. 

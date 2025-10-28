# Release History

## 5.3.7 (2025-10-29)

### Features Added
- The following optimizations were added to Blob Trigger processing:
  - Exclude containers that are not intended for monitoring.
  - Do not perform unnecessary scanning for container(s) detected during the initial write log.
  - Cache recently found write entry to avoid analyzing log blobs again.
  - Migrate ScaleMonitor to TargetScaler.

## 5.3.6 (2025-09-09)

### Bugs Fixed
- Reverted change where the scan will continue scanning AzureWebJobsStorage even when configuring a target storage account

## 5.3.5 (2025-07-21)

### Bugs Fixed
- Fixed bug where the scan will continue scanning AzureWebJobsStorage even when configuring a target storage account

## 5.3.4 (2025-02-11)

### Other Changes
- This release contains bug fixes to improve quality.

## 5.3.3 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 5.3.2 (2024-09-19)

### Other Changes
- This release contains bug fixes to improve quality.

## 5.3.1 (2024-07-17)

### Bugs Fixed
- Rely on PeekMessagesAsync when calculating message queue length
- Fixing target base scale instance concurrency for queues
- Bumped version of Azure.Storage.Blobs to resolve issue where Blob Path was being truncated at '#' character.

## 5.3.0 (2024-04-18)
- Includes all features from 5.3.0-beta.1.
- Bumped Azure.Identity dependency to 1.11.1 to resolve security vulnerability.

## 5.3.0-beta.1 (2024-04-15)
- This release contains bug fixes to improve quality.

## 5.2.2 (2023-12-12)
- This release contains bug fixes to improve quality.

## 5.2.1 (2023-09-25)
- This release contains bug fixes to improve quality.

## 5.2.0 (2023-08-29)

### Bugs Fixed
- Updating ParameterBindingData  "Connection" value to the full connection name instead of the connection section key

### Features Added
- Added support for `BlobsOptions.PoisonBlobThreshold`

## 5.1.3 (2023-06-26)
- Loosen parameter binding data parsing and validation to allow binding BlobContainerClient without blob name. (#37124)

## 5.1.2 (2023-04-27)
- Fixed bug where the blob container would scan from the beginning due not correctly updating the latest scan time. (#35145)

## 5.1.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 5.1.0 (2023-02-21)
- Includes all features from 5.1.0-beta.1.
- Added Target Based Scaling support for Storage Queues and Blobs

## 5.1.0-beta.1 (2023-02-07)
- Added logging for details of a storage blob listener on start/stop operations.
- Updated BlobNameValidationAttribute to allow $web as a container name.
- Added Blob storage support for ParameterBindingData reference type.

## 5.0.1 (2022-05-02)
- Implemented caching blobs in shared memory for faster I/O.

## 5.0.0 (2021-10-26)
- General availability of Microsoft.Azure.WebJobs.Extensions.Storage.Blobs 5.0.0.
- Fixed bug where internal message format of blob trigger didn't interop with previous major versions of the extension.
- Adding Dynamic Concurrency support.
- Execution log when using Event Grid Blob Trigger vs Blob Trigger.
- Fix bug where dynamic SKU is not recognized correctly.

## 5.0.0-beta.5 (2021-07-09)
- This release contains bug fixes to improve quality.

## 5.0.0-beta.4 (2021-05-18)
- Added new configuration formats so extensions that need multiple storage services can specify them in one connection configuration.

Sample config:
```json
{
    "MyStorageConnection1": {
        "blobServiceUri": "https://<my_account>.blob.core.windows.net",
        "queueServiceUri": "https://<my_account>.queue.core.windows.net"
    },

    "MyStorageConnection2": {
        "accountName": "<my_account>"
    }
}
```

## 5.0.0-beta.3 (2021-03-09)

### Breaking Changes

- The configuration section name for URI configuration was changed from `endpoint` to `serviceUri` to be consistent with other clients.

In case of JSON, from:
```json
{
    "MyConnection": {
        "endpoint": "https://<my_account>.blob.core.windows.net"
    }
}
```

To
```json
{
    "MyConnection": {
        "serviceUri": "https://<my_account>.blob.core.windows.net"
    }
}
```

Or using environment variables, from:
```
MyConnection__endpoint=https://<my_account>.blob.core.windows.net
```
To
```
MyConnection__serviceUri=https://<my_account>.blob.core.windows.net
```

## 5.0.0-beta.2 (2021-02-09)

### Major changes and features
- EventGrid support for the Blob Trigger was added. Details of the feature can be found [here](https://github.com/Azure/azure-sdk-for-net/pull/17137#issue-525036753).

## 5.0.0-beta.1 (2020-11-10)

This is the first preview of the next generation of `Microsoft.Azure.WebJobs.Extension.Storage` which has been integrated with latest Azure Storage SDK that follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

The `Microsoft.Azure.WebJobs.Extension.Storage.Blobs` offers drop-in replacement for scenarios where `Blob` and `BlobTrigger` attributes were bound to BCL types or user defined POCOs. Advanced scenarios like binding to Azure Storage Blobs SDK types or using `BlobsOptions` may require code changes.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Major changes and features 
- The extension has been split per storage service, i.e. `Microsoft.Azure.WebJobs.Extension.Storage.Blobs` has been created.
- The extension uses V12 Azure Storage SDK.
- Added support for token credential authentication using Azure.Identity library, including support for managed identity and client secret credentials.
- Simplified parallelism control through single `BlobsOptions.MaxDegreeOfParallelism` property.
- The `BlobsOptions.CentralizedPoisonQueue` has been removed. The implicit poison queue for a `BlobTrigger` is located in target blob's account by default.

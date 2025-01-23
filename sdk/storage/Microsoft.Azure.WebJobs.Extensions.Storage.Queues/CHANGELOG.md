# Release History

## 5.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fixed bug where calling StopAsync in QueueListener while drain mode was enabled would cancel the execution cancellation token.
- Fixed bug where the cancellation token passed to QueueListener.ProcessMessageAsync was being propagated to the QueueProcessor.CompleteProcessingMessageAsync call. Since this token is always canceled when QueueListener.StopAsync is invoked, it caused messages to be processed but not deleted.

### Other Changes

## 5.3.3 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 5.3.2 (2024-09-19)

### Bugs Fixed
- When grabbing Queue Metrics for amount of messages, will now use the QueueTriggerMetrics.QueueLength instead of the ApproximateMessagesCount for less stale metrics.

### Other Changes
- Improvement in logging exceptions when retrieving queue metrics.

## 5.3.1 (2024-07-17)

### Bugs Fixed
- Rely on PeekMessagesAsync when calculating message queue length
- Fixing target base scale instance concurrency for queues

## 5.3.0 (2024-04-18)
- Includes all features from 5.3.0-beta.1.
- Bumped Azure.Identity dependency to 1.11.1 to resolve secruity vulnerability.

## 5.3.0-beta.1 (2024-04-15)
- When binding to a CancellationToken, the token will no longer be signaled when in Drain Mode. To detect if the function app is in Drain Mode, use dependency injection to inject the IDrainModeManager, and check the IsDrainModeEnabled property.

## 5.2.1 (2023-12-12)
- This release contains bug fixes to improve quality.

## 5.2.0 (2023-09-25)
- This release contains bug fixes to improve quality.

## 5.1.3 (2023-06-26)
- Trigger binding support for ParameterBindingData reference type

## 5.1.2 (2023-04-27)
- Bumped Azure.Storage.Queue depedency to 12.14.0

## 5.1.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 5.1.0 (2023-02-21)
- Includes all features from 5.1.0-beta.1.
- Added Target Based Scaling support for Storage Queues and Blobs

## 5.1.0-beta.1 (2023-02-07)
- Added logging for details of a storage queue listener on start/stop operations.

## 5.0.1 (2022-05-02)
- Fixed queue message is not removed from the queue after stopping QueueListener. (#28156)

## 5.0.0 (2021-10-26)
- General availability of Microsoft.Azure.WebJobs.Extensions.Storage.Queues 5.0.0.
- Change `QueueProcessor.MessageAddedToPoisonQueue` to async event and rename to `QueueProcessor.MessageAddedToPoisonQueueAsync`.
- QueuesOptions.MaxPollingInterval other than default is now honored in "Development" environment.
- Adding Dynamic Concurrency support.
- Fix bug where dynamic SKU is not recognized correctly.

## 5.0.0-beta.5 (2021-07-09)
- Fixed bug where QueueTrigger would fail to renew ownership of message if function runs for long period of time (i.e. 15 minutes and longer).

## 5.0.0-beta.4 (2021-05-18)
- Fixed bug where custom implementations of `IQueueProcessorFactory` could overwrite each other settings.
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
- This version Base64-encodes/decodes queue messages by default. This reverses the breaking change in 5.0.0-beta1, and preserves compability with previous major versions. This behavior can be changed by setting `QueuesOptions.MessageEncoding`. For example, to configure Azure Functions to perform no base64 encoding/decoding, specify the following in host.json

```
  "extensions": {
    "queues": {
      "messageEncoding": "none"
    }
  }
```

## 5.0.0-beta.1 (2020-11-10)

This is the first preview of the next generation of `Microsoft.Azure.WebJobs.Extension.Storage` which has been integrated with latest Azure Storage SDK that follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

The `Microsoft.Azure.WebJobs.Extension.Storage.Queues` offers drop-in replacement for scenarios where `Queue` and `QueueTrigger` attributes were bound to BCL types or user defined POCOs. Advanced scenarios like binding to Azure Storage Queues SDK types or using `QueueProcessor` may require code changes.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Major changes and features 
- The extension has been split per storage service, i.e. `Microsoft.Azure.WebJobs.Extension.Storage.Queues` has been created.
- The extension uses V12 Azure Storage SDK.
- Added support for token credential authentication using Azure.Identity library, including support for managed identity and client secret credentials.
- This version does not Base64-encode queue messages. Support for that is planned for future releases. 

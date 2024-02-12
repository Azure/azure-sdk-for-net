# Release History

## 5.14.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 5.13.5 (2023-12-04)

### Bugs Fixed

- Fixed cleanup behavior when targeting .NET Framework so that Service Bus clients are properly disposed.

### Other Changes

- Updated the `Azure.Messaging.ServiceBus` dependency, which includes optimized defaults of the host platform to be 
  used for AMQP buffers.  This offers non-trivial performance increase on Linux-based platforms and a minor 
  improvement on macOS. This update also enables support for TLS 1.3. Additionally, this update contains a fix for 
  session messages to ensure FIFO ordering.

## 5.13.4 (2023-11-09)

### Other Changes

- Bump dependency on `Microsoft.Extensions.Azure` to prevent transitive dependency on deprecated version of `Azure.
  Identity`.

## 5.13.3 (2023-10-20)

### Bugs Fixed

- Fixed issue where deadlettering a message without specifying properties to modify could throw 
  an exception from out of proc extension.
- Include underlying exception details in RpcException when a failure occurs.

## 5.13.2 (2023-10-18)

### Other Changes

- Updated proto service definition to use StringValue rather than string for deadletter error reason and description.

## 5.13.1 (2023-10-17)

### Bugs Fixed

- Fixed the disposal pattern for cached Service Bus clients so that they are disposed only on 
  host shutdown.

### Other Changes

- Updated the proto service definition to use bytes for application properties.

## 5.13.0 (2023-10-11)

### Features Added

- Added `MaxConcurrentCallsPerSession` to `ServiceBusOptions` to allow configuring the maximum number of concurrent calls per session.

### Other Changes

- Added dependency on Grpc libraries in order to support message settlement from isolated worker.

## 5.12.0 (2023-08-11)

### Bugs Fixed

- When binding to a `CancellationToken`, the token will no longer be signaled when in Drain Mode.
  To detect if the function app is in Drain Mode, use dependency injection to inject the 
  `IDrainModeManager`, and check the `IsDrainModeEnabled` property.

## 5.11.0 (2023-06-06)

### Bugs Fixed

- Fixed issue where the main entity was not queried by the scale monitor when listening to the deadletter queue.

### Other Changes

- Updated dependency on `Azure.Messaging.ServiceBus` to 7.15.0.

## 5.10.0 (2023-05-10)

### Features Added

- Added `MinMessageBatchSize` and `MaxBatchWaitTime` to `ServiceBusOptions` to allow configuring the minimum number of messages to process in a batch and the maximum time to wait for a batch to be filled before processing.

## 5.9.0 (2023-02-23)

### Features Added

- Target-based scaling support has been added, allowing instances for Service Bus-triggered Functions to more accurately calculate their scale needs and adjust more quickly as the number of messages waiting to be processed changes.

## 5.8.1 (2022-11-09)

### Bugs Fixed

- Fixed issue where custom `MessagingProvider` could be replaced by the library `MessagingProvider`.

## 5.8.0 (2022-10-11)

### Features Added

- Support binding to `PartitionKey` and `TransactionPartitionKey`.
- Add `PeekMessagesAsync` method to `ServiceBusReceiveActions`.
- Add `DeadletterMessageAsync` overload to `ServiceBusMessageActions` that allows passing the properties dictionary in addition to the deadletter error reason and description.

### Bugs Fixed

- Fixed resource string usage to prevent `MissingManifestResourceException` when throwing exceptions from the extension.

### Other Changes

- Update exception messages to link to the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/TROUBLESHOOTING.md).

## 5.7.0 (2022-08-11)

### Features Added

- Added distributed tracing span when for functions that process a batch of messages.

### Bugs Fixed

- Fixed issue related to function apps that are bound to multiple namespaces using the same entity names, which caused messages to not be processed from the second namespace.

## 5.6.0 (2022-07-28)

### Features Added

- Added ability to register a callback for ` SessionInitializingAsync` and `SessionClosingAsync` to the `ServiceBusOptions`. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

### Bugs Fixed

- `SessionIdleTimeout` now will be applied for batch functions in addition to single-message 
  functions.

## 5.5.1 (2022-06-07)

### Bugs Fixed

- Fixed race condition when starting up function app.

## 5.5.0 (2022-05-16)

### Bugs Fixed

- Updated dependency on `Azure.Messaging.ServiceBus` to benefit from bug fix.
- Messages will now be abandoned if the function invocation throws for multiple dispatch functions. This was already the behavior for single dispatch functions.

## 5.4.0 (2022-05-10)

### Features Added

- Added the `ServiceBusReceiveActions` type to support receiving additional messages from a function invocation.
- Added the ability to bind to the `SessionId` property.

## 5.3.0 (2022-03-09)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added

- Added the ability to renew message and session locks using the `ServiceBusMessageActions` and `ServiceBusSessionActions`.

### Bugs Fixed

- Ignore scheduled/deferred messages when computing scale monitor metrics. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

## 5.2.0 (2021-12-08)

### Features Added

- Add listener details.
- Add protected constructors to `ServiceBusMessageActions` and `ServiceBusSessionMessageActions` for mocking.

### Bugs Fixed

- Make `ServiceBusMessageActions` thread-safe.

## 5.1.0 (2021-11-10)

### Features Added
- Added `EnableCrossEntityTransactions` option
- Added ability to bind to `ServiceBusClient`

## 5.0.0 (2021-10-21)

### Features Added
- Added DynamicConcurrency support.
- General availability of Microsoft.Azure.WebJobs.Extensions.ServiceBus 5.0.0.

## 5.0.0-beta.6 (2021-09-07)

### Features Added
- Support binding to `BinaryData` instances.

## 5.0.0-beta.5 (2021-07-07)

### Breaking Changes
- Renamed `ServiceBusEntityType` property to `EntityType`.
- Renamed `messageActions` and `sessionActions` parameters to `actions` in `MessageProcessor` and `SessionMessageProcessor`.
- Renamed `MaxBatchSize` to `MaxMessageBatchSize` in `ServiceBusOptions`.

## 5.0.0-beta.4 (2021-06-22)

### Added
- Added `AutoCompleteMessages` property to `ServiceBusTriggerAttribute` which allows configuring autocompletion at the function level.

### Key Bug Fixes
- Fix binding for DateTime parameters
- Avoid exception that occurred when a function settles messages and `AutoCompleteMessages` is true for multiple dispatch functions.
- Avoid null reference exception that could occur when no messages are available for a multiple dispatch function.

## 5.0.0-beta.3 (2021-05-18)

### Added
- Added `JsonSerializerSettings` property to `ServiceBusOptions`.

### Breaking Changes
- Made `Constants` class internal.
- Made `ServiceBusWebJobsStartup` class internal.
- Renamed `EntityType` to `ServiceBusEntityType`.
- Removed `receiver` parameter from `MessageProcessor` constructor.
- Removed `client` parameter from `SessionMessageProcessor` constructor.

### Key Bug Fixes
- The web proxy specified in configuration is now respected.
- Binding to JObject is now supported.

## 5.0.0-beta.2 (2021-04-07)

### Added
- Add AAD support

### Breaking Changes
- Changed the API signatures for the methods in `MessagingProvider`.
- Added `receiver` parameter to `MessageProcessor` constructor.
- Added `client` parameter to `SessionMessageProcessor` constructor.

## 5.0.0-beta.1 (2021-03-23)

- The initial release of Microsoft.Azure.WebJobs.Extensions.ServiceBus 5.0.0

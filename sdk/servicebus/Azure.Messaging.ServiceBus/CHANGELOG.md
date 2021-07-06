# Release History

## 7.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Key Bugs Fixed

### Fixed


## 7.2.0 (2021-06-22)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Jason Dryhurst-Smith _([GitHub](https://github.com/jasond-s))_
- Oscar Cabrero _([GitHub](https://github.com/oscarcabrero))_

### Fixed

- The retry policy used by clients will no longer overflow the `TimeSpan` maximum when using an `Exponential` strategy with a large number of retries and long delay set.

- The name of the property displayed in the `ArgumentOutOfRangeException` in the `MaxDeliveryCount` property in `SubscriptionProperties` was updated to use the correct property name.  (A community contribution, courtesy of _[oscarcabrero](https://github.com/oscarcabrero))_

## 7.2.0-beta.3 (2021-05-12)

### Added
* Added `SubQueue` option to `ServiceBusProcessorOptions` to allow for processing the deadletter queue
* Added Verbose event source events for the following scenarios that previously had Error events which resulted in unnecessary noise in application logs: 
  * Accepting a session times out because there are no sessions available.
  * TaskCanceledException occurs while stopping the processor.

## 7.1.2 (2021-04-09)

### Key Bug Fixes
- Updated dependency on Microsoft.Azure.Amqp to benefit from a performance enhancement involving message settlement.
- Updated dependency on System.Text.Encodings.Web


## 7.2.0-beta.2 (2021-04-07)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_
- Mikael Kolkinn _([GitHub](https://github.com/mikaelkolkinn))_

### Added
- Updated dependency on Azure.Core.Amqp to support Value/Sequence AMQP message bodies.
- Updated dependency on Microsoft.Azure.Amqp to benefit from a performance enhancement involving message settlement.
- Added `OnProcessMessageAsync` and `OnProcessErrorAsync` methods to help with mocking scenarios involving the processor.
- Added the ability to construct a `ServiceBusClient` and `ServiceBusAdministrationClient` using the `AzureNamedKeyCredential` and `AzureSasCredential` types to allow for updating credentials for long-lived clients.
- Added the ability to cancel receive operations which allows `StopProcessingAsync` calls on the processor to complete more quickly. (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_

### Fixed
- Multiple enhancements were made to the transport paths for publishing and reading events to reduce memory allocations and increase performance. (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_
- Fixed an issue where constructing a new `CreateRuleOption` from a `RuleProperties` would fail if the `CorrelationId` was null. (A community contribution, courtesy of _[mikaelkolkinn](https://github.com/mikaelkolkinn))_

## 7.1.1 (2021-03-10)

### Key Bug Fixes
- Fixed issue where batch size calculation was not taking diagnostic tracing information into account.

## 7.2.0-beta.1 (2021-03-08)
### Added
- Added `EnableCrossEntityTransactions` property to `ServiceBusClientOptions` to support transactions spanning multiple entities.
- Added `SessionIdleTimeout` property to `ServiceBusSessionProcessorOptions` to allow configuration of when to switch to the next session when using the session processor. 

### Key Bug Fixes
- Fixed issue where batch size calculation was not taking diagnostic tracing information into account.
- Retry on authorization failures to reduce likelihood of transient failures bubbling up to user application.
- Reduce maximum refresh interval to prevent Timer exceptions involving long-lived SAS tokens.

## 7.1.0 (2021-02-09)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Aaron Dandy _([GitHub](https://github.com/aarondandy))_

### Added
- Added virtual keyword to all client properties to enable mocking scenarios.
- Added `ServiceBusModelFactory.ServiceBusMessageBatch` to allow mocking a `ServiceBusMessageBatch`.

### Key Bug Fixes
- Fixed an issue with the `ServiceBusProcessor` where closing and disposing or disposing multiple times resulted in an exception.  (A community contribution, courtesy of _[aarondandy](https://github.com/aarondandy)_)
- Fixed issue with batch size calculation when using `ServiceBusMessageBatch`.

## 7.0.1 (2021-01-12)

### Fixed
- Fixed race condition that could occur when using the same `ServiceBusSessionReceiverOptions` instance 
for several receivers.
- Increased the authorization refresh buffer to make it less likely that authorization will expire.


## 7.0.0 (2020-11-23)
### Breaking Changes
- Renamed GetRawMessage method to GetRawAmqpMessage.
- Removed LinkCloseMode.
- Rename ReceiveMode type to ServiceBusReceiveMode.
- Remove ServiceBusFailureReason of Unauthorized in favor of using UnauthorizedAccessException.

## 7.0.0-preview.9 (2020-11-04)

### Added
- Added dependency on Azure.Core.Amqp library.
- Added dependency on System.Memory.Data library.

### Breaking Changes
- Removed `AmqpMessage` property in favor of a `GetRawMessage` method on `ServiceBusMessage` and `ServiceBusReceivedMessage`.
- Renamed `Properties` to `ApplicationProperties` in `CorrelationRuleFilter`.
- Removed `ServiceBusSenderOptions`.
- Removed `TransactionEntityPath` from `ServiceBusSender`.

## 7.0.0-preview.8 (2020-10-06)

### Added
- Added `AcceptSessionAsync` that accepts a specific session based on session ID.

### Breaking Changes
- Renamed `ViaQueueOrTopicName` to `TransactionQueueOrTopicName`.
- Renamed `ViaPartitionKey` to `TransactionPartitionKey`.
- Renamed `ViaEntityPath` to `TransactionEntityPath`.
- Renamed `Proxy` to `WebProxy`.
- Made `MaxReceiveWaitTime` in `ServiceBusProcessorOptions` and `ServiceBusSessionProcessorOptions` internal.
- Renamed `CreateSessionReceiverAsync` to `AcceptNextSessionAsync`.
- Removed `SessionId` from `ServiceBusClientOptions` in favor of `AcceptSessionAsync`.

## 7.0.0-preview.7 (2020-09-10)

### Added
- Added AmqpMessage property on `ServiceBusMessage` and `ServiceBusReceivedMessage` that gives full access to underlying AMQP details.
- Added explicit Close methods on `ServiceBusReceiver`, `ServiceBusSessionReceiver`, `ServiceBusSender`, `ServiceBusProcessor`, and `ServiceBusSessionProcessor`.

### Breaking Changes
- Renamed `ServiceBusManagementClient` to `ServiceBusAdministrationClient`.
- Renamed `ServiceBusManagementClientOptions` to `ServiceBusAdministrationClientOptions`.
- Renamed `IsDisposed` to `IsClosed` on `ServiceBusSender`, `ServiceBusReceiver`, and `ServiceBusSessionReceiver`.
- Made `ServiceBusProcessor` and `ServiceBusSessionProcessor` implement `IAsyncDisposable`
- Removed public constructors for `QueueProperties` and `RuleProperties`.
- Added `version` parameter to `ServiceBusAdministrationClientOptions` constructor.
- Removed `CreateDeadLetterReceiver` methods in favor of new `SubQueue` property on `ServiceBusReceiverOptions`.
- Made `EntityNameFormatter` internal.
- Made settlement methods on `ProcessMessageEventArgs` and `ProcessSessionMessageEventArgs` virtual for mocking.
- Made all Create methods on `ServiceBusClient` virtual for mocking.

## 7.0.0-preview.6 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 7.0.0-preview.5 (2020-08-11)

### Acknowledgements
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions and design input for this release:
- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_
- Sean Feldman _([GitHub](https://github.com/SeanFeldman))_

### Added
- Added MaxConcurrentCallsPerSession option to ServiceBusSessionProcessor
  
### Breaking Changes
- Change MaxConcurrentCalls to MaxConcurrentSessions in ServiceBusSessionProcessor.
- Replace (Queue|Topic|Subscription|Rule)Description with (Queue|Topic|Subscription|Rule)Properties.
- Add Create(Queue|Topic|Subscription|Rule)Options for creating entities.
- Replace (Queue|Topic|Subscription)RuntimeInfo with (Queue|Topic|Subscription)RuntimeProperties.
- Remove MessageCountDetails and move the properties directly into the RuntimeProperties types.

## 7.0.0-preview.4 (2020-07-07)

### Acknowledgements
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions and design input for this release:
- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_
- Sean Feldman _([GitHub](https://github.com/SeanFeldman))_

### Added
- Add IAsyncEnumerable Receive overload
- Add batch schedule/cancel schedule messages
  
### Breaking Changes
- Remove use of "Batch" in Peek/Receive methods.
- Add Message/Messages suffix to Peek/Send/Receive/Abandon/Defer/Complete/DeadLetter methods.
- Rename ServiceBusSender.CreateBatch to ServiceBusSender.CreateMessageBatch
- Rename CreateBatchOptions to CreateMessageBatchOptions
- Rename ServiceBusMessageBatch.TryAdd to ServiceBusMessageBatch.TryAddMessage
- Change output list type from IList<ServiceBusReceivedMessage> to IReadOnlyList<ServiceBusReceivedMessage>
- Removed ServiceBusException.FailureReason.ClientClosed in favor of throwing ObjectDisposedException

## 7.0.0-preview.3 (2020-06-08)

### Acknowledgements
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions and design input for this release:
- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_
- Sean Feldman _([GitHub](https://github.com/SeanFeldman))_

### Added
- Add the ServiceBusManagementClient for CRUD operations on a namespace
- Add constructor for ServiceBusMessage taking a string
- Use the BinaryData type for ServiceBusMessage.Body
- Add diagnostic tracing
  
### Breaking Changes
- Introduce ServiceBusSessionReceiverOptions/ServiceBusSessionProcessorOptions for creating
  ServiceBusSessionReceiver/ServiceBusSessionProcessor
- Make ServiceBusReceivedMessage.Properties IReadOnlyDictionary rather than IDictionary

## 7.0.0-preview.2 (2020-05-04)

### Acknowledgements
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions and design input for this release:
- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_
- Sean Feldman _([GitHub](https://github.com/SeanFeldman))_

### Added
- Allow specifying a list of named sessions when using ServiceBusSessionProcessor
- Transactions/Send via support
- Add SessionInitializingAsync/SessionClosingAsync events in ServiceBusSessionProcessor
- Do not attempt to autocomplete messages with the processor if the user settled the message in their callback
- Add SendAsync overload accepting an IEnumerable of ServiceBusMessage
- Various performance improvements  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- Improve the way exception stack traces are captured  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
  
### Breaking Changes
- Change from using a static factory method for creating a sendable message from a received message to instead
  using a constructor  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- CreateSessionProcessor parameter sessionId renamed to sessionIds (also changed from string to params string array). 
- Remove cancellation token from CreateProcessor and CreateSessionProcessor  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- Rename SendBatchAsync to SendAsync
- Add SenderOptions parameter to CreateSender method.

## 7.0.0-preview.1 (2020-04-07)
- Initial preview for new version of Service Bus library.
- Includes sending/receiving/settling messages from queues/topics and session support.

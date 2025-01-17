# Release History

## 7.19.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 7.18.3 (2025-01-17)

### Bugs Fixed

- Fixed an issue where identifier generation for senders did not correctly include the entity path as an informational element.  ([#46952](https://github.com/Azure/azure-sdk-for-net/issues/46952))

### Other Changes

- Added annotations to make the package compatible with trimming and native AOT compilation.

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.9, which contains several bug fixes. _(see: [commits](https://github.com/Azure/azure-amqp/commits/hotfix/))_

- Updated the transitive dependency on `System.Text.Json` to 6.0.10 via `Azure.Core` 1.44.1.  Though Service Bus does not perform JSON serialization and was not vulnerable, the .NET 9 SDK was emitting warnings during scans due to a flaw in the previous `System.Text.Json` dependency.

## 7.18.2 (2024-10-08)

### Other Changes

- Enhanced the logs emitted when acquiring a session with `ServiceBusClient` times out or is canceled.  As these are known and expected exception conditions, they are now correctly logged as verbose information rather than an error.  Previously, these scenarios were special-cased for processors, but receivers were treated as standard errors.  Going forward, the processor and client/receiver scenarios are handled consistently.

## 7.18.1 (2024-07-31)

### Other Changes

- Bump `Azure.Core.Amqp` dependency to 1.3.1, which includes a fix to serialization of binary application properties.

## 7.18.0 (2024-07-18)

### Acknowledgments

Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Martin Costello _([GitHub](https://github.com/martincostello))_

### Bugs Fixed

- Fixed an issue that caused connection strings using host names without a scheme to fail parsing and be considered invalid.

- Fixed an issue where the scheduled enqueue time was not cleared when creating a new message from a received message.

- Fixed an issue that prevented relative URIs from being used with [application properties](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-application-properties) in the `ServiceBusMessage.ApplicationProperties` and `ServiceBusReceivedMessage.ApplicationProperties` collections.

- Fixed an issue that caused `ServiceBusMessageBatch` to accept more than the allowed 1mb batch limit when sending to Service Bus entities with large message sizes enabled.

- Fixed issue where the `SupportOrdering` property was not being respected when set on `CreateTopicOptions`.

### Other Changes

- The client will now refresh the maximum message size each time a new AMQP link is opened; this is necessary for large message support, where the maximum message size for entities can be reconfigureed adjusted on the fly.  Because the client had cached the value, it would not be aware of the change and would enforce the wrong size for batch creation.

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.7, which contains a fix for decoding messages with a null format code as the body.

- Improved efficiency of subclient creation, reducing allocations when no explicit options are passed.

- Reduced the number of allocations of various option types. _(A community contribution, courtesy of [martincostello](https://github.com/martincostello))_

## 7.18.0-beta.1 (2024-05-08)

### Features Added

- `ServiceBusReceiver` now supports the ability to delete all messages from an entity using the `PurgeMessagesAsync` method.  Callers may optionally request to limit the target messages to those earlier than a given date.

- `ServiceBusReceiver` now supports the ability to delete messages from an entity in batches using the `DeleteMessagesAsync` method.  The messages selected for deletion will be the oldest in the entity, based on the enqueued date and callers may optionally request to limit them to only those earlier than a given date.

### Bugs Fixed

- Fixed issue where the `SupportOrdering` property was not being respected when set on `CreateTopicOptions`.

### Other Changes

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.6, which includes a bug fix for an internal `NullReferenceException` that would sometimes impact creating new links. _(see: [#258](https://github.com/azure/azure-amqp/issues/258))_

## 7.17.5 (2024-04-09)

### Bugs Fixed

- Fixed an edge case where a cancellation token signaled while waiting for a throttling delay would cause a failure to reset state and service operations would continue to apply the throttle delay going forward.  ([#42952](https://github.com/Azure/azure-sdk-for-net/issues/42952))

- Fixed an issue where the `ServiceBusSessionProcessor` was not respecting `ServiceBusSessionProcessorOptions.MaxConcurrentCallsPerSession` when `ServiceBusSessionProcessorOptions.SessionIds` was set to a value. ([#43157](https://github.com/Azure/azure-sdk-for-net/pull/43157))

### Other Changes

- Added missing documentation for `ServiceBusModelFactory` members with a focus on clarifying what model properties each parameter to the factory methods will populate.  In some cases, parameter names differ from the associated model properties, causing confusion.  ([#42772](https://github.com/Azure/azure-sdk-for-net/issues/42772))

## 7.17.4 (2024-03-05)

### Bugs Fixed

- When creating a new `ServiceBusMessage` from an existing `ServiceBusReceivedMessage`, diagnostic properties will now be properly reset.  Previously, they were incorrectly retained which led to the new message being indistinguishable from the old in traces.

### Other Changes

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.5, which includes several bug fixes.  One notable fix addresses an obscure race condition when a cancellation token is signaled while service operations are being invoked concurrently which caused those operations to hang.  Another notable fix is for an obscure race condition that occurred when attempting to complete a message which caused the operation to hang.

## 7.17.3 (2024-02-14)

### Bugs Fixed

- Fixed draining of credits when prefetch is enabled.
- No longer drain credits when using the `ServiceBusSessionProcessor` as it is not necessary unless the `ServiceBusSessionProcessorOptions.SessionIds` property is set.

### Other Changes

- Loosened validation for the fully qualified namespace name passed to the `ServiceBusClient` constructor.  A URI is now also accepted as a valid format.  This is intended to improve the experience when using the management library, CLI, Bicep, or ARM template to create the namespace, as they return only an endpoint for the namespace.  Previously, callers were responsible for parsing the endpoint and extracting the host name for use with the client.

## 7.17.2 (2024-01-16)

### Bugs Fixed

- Fixed the logic used to set the TimeToLive value of the AmqpMessageHeader for received messages to be based on the difference of the AbsoluteExpiryTime and CreationTime properties of the AmqpMessageProperties.
- Prevent `NullReferenceException` from being thrown when the `ReceiveMessagesAsync` method is called using a high degree of concurrency.

## 7.17.1 (2023-12-04)

### Bugs Fixed

- Adjusted retries to consider an unreachable host address as terminal.  Previously, all socket-based errors were considered transient and would be retried.
- Updated the `ServiceBusMessage` constructor that takes a `ServiceBusReceivedMessage` to no longer copy over the
  `x-opt-partition-id` key as this is meant to apply only to the original message.
- Drain excess credits when attempting to receive using sessions to ensure FIFO ordering.

### Other Changes

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.4, which enables support for TLS 1.3.
- Removed the custom sizes for the AMQP sending and receiving buffers, allowing the optimized defaults of the host platform to be used.  This offers non-trivial performance increase on Linux-based platforms and a minor improvement on macOS.  Windows performance remains unchanged as the default and custom buffer sizes are equivalent.

## 7.17.0 (2023-11-14)

### Breaking Changes

The following breaking changes were made for the experimental support of Open Telemetry:
- Change `ActivitySource` name used to report message activity from `Azure.Messaging.ServiceBus` to `Azure.Messaging.ServiceBus.Message`.
- Updated tracing attributes names to conform to OpenTelemetry semantic conventions version 1.23.0.

## 7.16.2 (2023-10-11)

### Bugs Fixed

- Fixed issue where `ActivitySource` activities were not being created even when the experimental
  flag was set.

### Other Changes

- The reference for the AMQP transport library, `Microsoft.Azure.Amqp`, has been bumped to 2.6.3. This fixes an issue with timeout duration calculations during link creation and includes several efficiency improvements.

## 7.16.1 (2023-08-15)

### Bugs Fixed

- Fixed race condition that could lead to an `ObjectDisposedException` when using the `ServiceBusSessionProcessor`.

## 7.16.0 (2023-08-07)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added

- `ProcessMessageEventArgs` provides a `MessageLockLostAsync` event that can be subscribed to in
  order to be notified when the message lock is lost.
- `ProcessSessionMessageEventArgs` provides a `SessionLockLostAsync` event that can be subscribed to in
  order to be notified when the session lock is lost.
- A constructor for `ServiceBusMessage` taking an `AmqpAnnotatedMessage` has been added.

### Bugs Fixed

- The `CancellationTokenSource` used by the `ServiceBusSessionProcessor` in order to renew session
  locks is now disposed when the session is no longer being processed, thereby preventing a memory leak.

## 7.15.0 (2023-06-06)

### Bugs Fixed

- Do not copy over `DeliveryAnnotations` when constructing a new `ServiceBusMessage` from a `ServiceBusReceivedMessage`.

### Other Changes

- The reference for the AMQP transport library, Microsoft.Azure.Amqp, has been bumped to 2.6.2. This resolves a potential issue opening TLS connections on .NET 6+.

## 7.14.0 (2023-05-09)

### Features Added

- The client-side idle timeout for connections can now be configured using `ServiceBusClientOptions`.

### Bugs Fixed

- Removed the 30 second cap applied when opening AMQP links; this allows developers to fully control the timeout for service operations by tuning the `TryTimeout` as appropriate for the application.

- Fixed potential `NullReferenceException` when using the `ServiceBusProcessor` or `ServiceBusSessionProcessor`.

## 7.13.1 (2023-03-13)

### Bugs Fixed

- Fixed issue with Guid writing during message settlement that could result in an `ArgumentException` if the ArrayPool returned a buffer that is larger than the size of the Guid.

## 7.13.0 (2023-03-08)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added

- `ActivitySource` activities that are used when using the [experimental OpenTelemetry support](https://devblogs.microsoft.com/azure-sdk/introducing-experimental-opentelemetry-support-in-the-azure-sdk-for-net/) will include the `az.schema_url` tag indicating the OpenTelemetry schema version. They will also include the messaging attribute specified [here](https://github.com/Azure/azure-sdk/blob/main/docs/tracing/distributed-tracing-conventions.yml#L98).

### Bugs Fixed

- Fixed deserialization of the lock token to take into account endianness. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

### Other Changes

- Some checks for cancellation that were occurring after a service operation had been completed have been removed.  Because the service operation was already complete, cancellation was not actually performed and the results of the operation should be returned.

- Exceptions related to the cancellation token being signaled on a receive operation will now be logged as Verbose rather than Error.

## 7.12.0 (2023-01-12)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added

- Added `UpdatePrefetchCount` methods to `ServiceBusProcessor` and `ServiceBusSessionProcessor` to allow updating the prefetch count of a running processor. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

### Other Changes

- Update AMQP library dependency to leverage new `DrainAsync` method.

### Bugs Fixed

- Fixed issue with `MaxConcurrentCallsPerSession` setting which resulted in the setting not always being respected.

## 7.11.1 (2022-11-08)

### Bugs Fixed

- Telemetry will now use a parent activity instead of links when using the `ServiceBusProcessor` or `ServiceBusSessionProcessor`.
- Attempt to drain the receiver when closing if there are outstanding credits.

## 7.11.0 (2022-10-11)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Bugs Fixed

- Fixed issue where shared AMQP session was incorrectly closed when `AcceptNextSessionAsync` call timed out and `EnableCrossEntityTransaction` is set to `true`.
- Dispose semaphores in `ServiceBusProcessor` to avoid memory leak. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

### Other Changes

- Optimized message body copying when accessing the `Body` property of a received message. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- Removed locking from the `ServiceBusRetryPolicy` to improve performance and prevent deadlocks. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- Added link to [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/TROUBLESHOOTING.md) in exception messages.

## 7.11.0-beta.1 (2022-09-06)

### Features Added

- Added `DeadletterMessageAsync` overload that allows passing the properties dictionary in addition to the deadletter error reason and description.
- Added `PeekMessagesAsync` method to `ProcessorReceiveActions`.

### Breaking Changes

- Improved performance of sending messages by using the `ServiceBusMessageBatch` type, by caching the underlying AMQP message as opposed to recalculating it when sending. Because of this change, any changes to a `ServiceBusMessage` after it has already been added to the batch will no longer be reflected in the batch and what is ultimately sent to the service. To avoid any issues from this change, ensure that yo are not modifying the `ServiceBusMessage` after adding it to a batch.

### Bugs Fixed

- Fixed performance issues in the `ServiceBusSessionProcessor` that could lead to thread starvation when using a high number of concurrent sessions.
- Fixed diagnostic tracing of the `ServiceBusReceiver.Receive` operation to correctly include links to the `Message` operation for the received messages.
- Fixed issue where the TryTimeout was not respected for times over 1 minute and 5 seconds when attempting to accept the next available session.

### Other Changes

- Improved performance of sending messages by using the `ServiceBusMessageBatch` type, by caching the underlying AMQP message as opposed to recalculating it when sending.

## 7.10.0 (2022-08-11)

### Features Added

- Added the ability to set the a custom Identifier on the various client options types.
- The processor Identifier will now be included in the underlying receiver logs when using the `ServiceBusProcessor` or `ServiceBusSessionProcessor`.
- Added the ability to set a custom endpoint that will be used when connecting to the service, via the `ServiceBusClientOptions.CustomEndpointAddress` property.
- Added the `ReleaseSession` and `RenewSessionLockAsync` methods to the `ProcessSessionEventArgs` class to allow the user to manage the session in the `SessionInitializingAsync` and the `SessionClosingAsync` event handlers.

### Bugs Fixed

- Fixed issue where the AMQP footer would not be populated on received messages.
- Fixed issue where the client timeout was not respected when establishing the AMQP connection and the AMQP session.
- Fixed issue where closing the rule manager link could result in the AMQP session being closed even when `EnableCrossEntityTransactions` is set to `true` in the `ServiceBusClientOptions`.

### Other Changes

- Reduced memory allocations when converting messages into the underlying AMQP primitives. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

## 7.9.0 (2022-07-11)

### Features Added

- Stable release of `ServiceBusRuleManager`.
- `EntityPath` and `FullyQualifiedNamespace` are now included on the various processor event args.

## 7.9.0-beta.1 (2022-06-06)

### Features Added

- Added `ServiceBusRuleManager` for managing rules.

### Bugs Fixed

- Updated behavior of `ServiceBusSessionReceiver.IsClosed` to return `true` if the underlying link was closed.

### Other Changes

- Include lock token in additional event source logs.

## 7.8.1 (2022-05-16)

### Bugs Fixed

- Fixed issue that could result in the message lock renewal not being cancelled if the user message handler threw an exception.
- Abandon messages that are received from the `ProcessorReceiveActions` in the event of the user message handler throwing an exception.

## 7.8.0 (2022-05-09)

### Features Added

- Added the `GetReceiveActions` method to `ProcessMessageEventArgs` and `ProcessSessionMessageEventArgs` to allow for receiving additional messages from the processor callback.

### Breaking Changes

- `ServiceBusTransportMetrics` and `ServiceBusRuleManager` have been removed from the prior beta versions. These will be evaluated for inclusion in a future GA release.

### Bugs Fixed

- Prevent exception when stopping processor that can occur if custom registrations were added to the `CancellationToken` that is exposed via the event args.
- Don't close entire AMQP session when closing individual AMQP links when `EnableCrossEntityTransactions` is set to `true`, since with this configuration, all links will share the same session.

### Other Changes

- Retries related to accepting sessions when using the `ServiceBusSessionProcessor` are now logged as `Verbose` rather than `Warning`.

## 7.8.0-beta.2 (2022-04-07)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added

- Added `ServiceBusTransportMetrics` that can be used to get transport metric information.

### Bugs Fixed

- Relaxed `ServiceBusMessage` validation to allow the `SessionId` property to be changed after the `PartitionKey` property is already set.

### Other Changes

- Removed allocations and boxing from `EventSource` logging. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

## 7.8.0-beta.1 (2022-03-10)

### Features Added

- Added the `ServiceBusRuleManager` which allows managing rules for subscriptions.

## 7.7.0 (2022-03-09)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added

- Add the ability to manually renew message and session locks when using the processor.

### Bugs Fixed

- Fixed name of ServiceBusAdministrationClient extension method.
- Fixed entity name validation when passing in a subscription entity path into the
  CreateReceiver method.

### Other Changes

- Removed LINQ allocations when sending messages. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

## 7.6.0 (2022-02-08)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Max Hamulyak _([GitHub](https://github.com/kaylumah))_
- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Bugs Fixed

- Fix unnecessary task scheduling in ServiceBusProcessor and ServiceBusSessionProcessor
- Remove array allocation when creating linked token sources from the ServiceBusProcessor

### Features Added

- The `State` property has been added to `ServiceBusReceivedMessage` which indicates whether a message is `Active`, `Scheduled`, or `Deferred`. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- Extension methods have been added for registering the `ServiceBusAdministrationClient` via dependency injection for use in ASP.NET Core applications. _(A community contribution, courtesy of [kaylumah](https://github.com/kaylumah))_

- Support for cancellation tokens has been improved for AMQP operations, enabling earlier detection of cancellation requests without needing to wait for the configured timeout to elapse.

## 7.5.1 (2021-12-07)

### Bugs Fixed

- Add a delay when retrying if we are being throttled by the service.

## 7.5.0 (2021-11-10)

### Breaking Changes

- Default `To`, `ReplyTo`, and `CorrelationId` properties of `ServiceBusMessage` to null, rather than empty string.
To retain the old behavior, you can set the properties to empty string when constructing your message:
```c#
var message = new ServiceBusMessage
{
    ReplyTo = "",
    To = "",
    CorrelationId = ""
};
```

### Bugs Fixed

- Fixed memory leak in ServiceBusSessionProcessor.
- Fixed bug where AMQP sequence/value messages could not be created from a received message.
- Fixed bug where a named session of empty string could not be accepted.

## 7.5.0-beta.1 (2021-10-05)

### Features Added
- Added support for specifying the maximum message size for entities in Premium namespaces.

## 7.4.0 (2021-10-05)

### Features Added
- Added support for cancelling send and receives while in-flight.

### Bugs Fixed
- Leveraged fix in AMQP library that allows messages to be properly unlocked when shutting down the processor.

## 7.3.0 (2021-09-07)

### Acknowledgments

Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- John Call _([GitHub](https://github.com/johnthcall))_

### Bugs Fixed

- Fixed an issue with refreshing authorization where redundant requests were made to acquire AAD tokens that were due to expire.  Refreshes will now coordinate to ensure a single AAD token acquisition.

- Fixed an issue with authorization refresh where attempts may have been made to authorize a faulted link.  Links that fail to open are no longer be considered valid for authorization.

### Other Changes

- Serialization of messages read from Service Bus has been tweaked for greater efficiency.  _(A community contribution, courtesy of [johnthcall](https://github.com/johnthcall))_

## 7.3.0-beta.1 (2021-08-10)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Timothee Lecomte _([GitHub](https://github.com/tlecomte))_
- Shlomi Assaf _([GitHub](https://github.com/shlomiassaf))_

### Features Added
- Added the `ReleaseSession` method to `ProcessSessionMessageEventArgs` which allows processing for a session to terminated early.
- Added protected constructors to `ServiceBusProcessor`, `ServiceBusReceiver`, `ServiceBusSender`, and `ServiceBusSessionProcessor` to allow these types to be extended.
- Added `UpdateConcurrency` methods to `ServiceBusProcessor` and `ServiceBusSessionProcessor` to allow concurrency to be changed for an already created processor.
- Allow a TimeSpan of zero to be passed as the `maxWaitTime` for the various receive overloads if Prefetch mode is enabled.

### Bugs Fixed
- Fixed bug where receiving a message with `AbsoluteExpiryTime` of DateTime.MaxValue would cause an `ArgumentException'. (A community contribution, courtesy of _[tlecomte](https://github.com/tlecomte))_

### Other Changes
- Fixed reference name conflicts in `ServiceBusModelFactory` ref docs. (A community contribution, courtesy of _[shlomiassaf](https://github.com/shlomiassaf))_

## 7.2.1 (2021-07-07)

### Fixed
- Fixed bug in the `ServiceBusProcessor` where message locks stopped being automatically renewed after `StopProcessingAsync` was called.

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
- Mikael Kolkinn

### Added
- Updated dependency on Azure.Core.Amqp to support Value/Sequence AMQP message bodies.
- Updated dependency on Microsoft.Azure.Amqp to benefit from a performance enhancement involving message settlement.
- Added `OnProcessMessageAsync` and `OnProcessErrorAsync` methods to help with mocking scenarios involving the processor.
- Added the ability to construct a `ServiceBusClient` and `ServiceBusAdministrationClient` using the `AzureNamedKeyCredential` and `AzureSasCredential` types to allow for updating credentials for long-lived clients.
- Added the ability to cancel receive operations which allows `StopProcessingAsync` calls on the processor to complete more quickly. (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_

### Fixed
- Multiple enhancements were made to the transport paths for publishing and reading events to reduce memory allocations and increase performance. (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_
- Fixed an issue where constructing a new `CreateRuleOption` from a `RuleProperties` would fail if the `CorrelationId` was null. (A community contribution, courtesy of Mikael Kolkinn

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

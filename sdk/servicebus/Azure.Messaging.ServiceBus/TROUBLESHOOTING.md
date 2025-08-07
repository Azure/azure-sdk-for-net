# Troubleshooting Service Bus issues

This troubleshooting guide covers failure investigation techniques, common errors for the credential types in the Azure Service Bus .NET client library, and mitigation steps to resolve these errors.

## Table of contents
- [Handle Service Bus Exceptions](#handle-service-bus-exceptions)
  - [Find information about a ServiceBusException](#find-information-about-a-servicebusexception)
  - [Other common exceptions](#other-common-exceptions)
- [Permissions Issues](#permissions-issues)
- [Connectivity issues](#connectivity-issues)
  - [Timeout when connecting to service](#timeout-when-connecting-to-service)
  - [SSL handshake failures](#ssl-handshake-failures)
  - [Socket exhaustion errors](#socket-exhaustion-errors)
  - [Adding components to the connection string does not work](#adding-components-to-the-connection-string-does-not-work)
    - ["TransportType=AmqpWebSockets" Alternative](#transporttypeamqpwebsockets-alternative)
    - ["Authentication=Managed Identity" Alternative](#authenticationmanaged-identity-alternative)
- [Logging and Diagnostics](#logging-and-diagnostics)
  - [Enable logging](#enable-logging)
  - [Distributed tracing](#distributed-tracing)
- [Troubleshoot sender issues](#troubleshoot-sender-issues)
  - [Cannot set multiple partition keys (or multiple sessions when partitions are enabled) for messages in ServiceBusMessageBatch](#cannot-send-batch-with-multiple-partition-keys)
  - [Batch fails to send](#batch-fails-to-send)
- [Troubleshoot receiver issues](#troubleshoot-receiver-issues)
  - [Number of messages returned doesn't match number requested in batch receive](#number-of-messages-returned-does-not-match-number-requested-in-batch-receive)
  - [Message or session lock is lost before lock expiration time](#message-or-session-lock-is-lost-before-lock-expiration-time)
  - [How to browse scheduled or deferred messages](#how-to-browse-scheduled-or-deferred-messages)
  - [How to browse session messages across all sessions](#how-to-browse-session-messages-across-all-sessions)
  - [NotSupportedException thrown when accessing Body property](#notsupportedexception-thrown-when-accessing-message-body)
- [Troubleshoot processor issues](#troubleshoot-processor-issues)
  - [Autolock renewal does not appear to be working](#autolock-renewal-is-not-working)
  - [Processor appears to hang or have latency issues when using extremely high concurrency](#processor-appears-to-hang-or-have-latency-issues-when-using-high-concurrency)
  - [Session processor takes too long to switch sessions](#session-processor-takes-too-long-to-switch-sessions)
  - [Processor stops immediately](#processor-stops-immediately)
- [Troubleshoot transaction issues](#troubleshoot-transactions)
  - [Supported operations](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions#operations-within-a-transaction-scope)
  - [Operations in transactions are not retried](#operations-in-a-transaction-are-not-retried)
  - [Transactions across entities are not working](#transactions-across-entities-are-not-working)
- [Quotas](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quotas)

## Handle Service Bus Exceptions
The Service Bus client library will surface exceptions when an error is encountered by a service operation or within the client. When possible, standard .NET exception types are used to convey error information. For scenarios specific to Service Bus, a [ServiceBusException][ServiceBusException] is thrown; this is the most common exception type that applications will encounter.

The Service Bus clients will automatically retry exceptions that are considered transient, following the configured [retry options][ServiceBusRetryOptions]. When an exception is surfaced to the application, either all retries were applied unsuccessfully, or the exception was considered non-transient. More information on configuring retry options can be found in the [Customizing the retry options][RetryOptionsSample] sample.

For more information on Service Bus error scenarios and recommended ways to resolve them, please see the [Service Bus Messaging Exceptions][ServiceBusMessagingExceptions] guidance.


### Find information about a ServiceBusException

The exception includes some contextual information to assist in understanding the context of the error and its relative severity.  These are:

- `EntityPath` : Identifies the Service Bus entity from which the exception occurred, if available.

- `IsTransient` : Indicates whether or not the exception is considered recoverable. In the case where it was deemed transient, the appropriate retry policy has already been applied and all retries were unsuccessful.

- `Message` : Provides a description of the error that occurred and relevant context.

- `StackTrace` : Represents the immediate frames of the call stack, highlighting the location in the code where the error occurred.

- `InnerException` : When an exception was the result of a service operation, this will often be a `Microsoft.Azure.Amqp.AmqpException` instance describing the error, following the [OASIS AMQP 1.0 spec][AmqpSpec].

- `Reason` : Provides a set of well-known reasons for the failure that help to categorize and clarify the root cause. These are intended to allow for applying exception filtering and other logic where inspecting the text of an exception message wouldn't be ideal. Some key failure reasons are:

  - **ServiceTimeout** : This indicates that the Service Bus service did not respond to an operation within the expected amount of time. This may have been caused by a transient network issue or service problem. The Service Bus service may or may not have successfully completed the request; the status is not known. In the case of accepting the next available session, this exception indicates that there were no unlocked sessions available in the entity. These are transient errors that will be automatically retried.

  - **QuotaExceeded** : This typically indicates that there are too many active receive operations for a single entity. In order to avoid this error, reduce the number of potential concurrent receives. You can use batch receives to attempt to receive multiple messages per receive request. Please see [Service Bus quotas][ServiceBusQuotas] for more information.

  - **MessageSizeExceeded** : This indicates that the max message size has been exceeded. The message size includes the body of the message, as well as any associated metadata and system overhead. The best approach for resolving this error is to reduce the number of messages being sent in a batch or the size of the body included in the message. Because size limits are subject to change, please refer to [Service Bus quotas][ServiceBusQuotas] for specifics.  
  
  - **MessageLockLost** : This indicates that the lock on the message is lost. Callers should attempt to receive and process the message again. This only applies to non-session entities. This error occurs if processing takes longer than the lock duration and the message lock is not renewed. Note that this error can also occur when the link is detached due to a transient network issue or when the link is idle for 10 minutes. See [Message or session lock is lost before lock expiration time](#message-or-session-lock-is-lost-before-lock-expiration-time) for more information.
  
  - **SessionLockLost**: This indicates that the lock on the session has expired. Callers should attempt to accept the session again. This only applies to session-enabled entities. This error occurs if processing takes longer than the lock duration and the session lock is not renewed. Note that this error can also occur when the link is detached due to a transient network issue or when the link is idle for 10 minutes. See [Message or session lock is lost before lock expiration time](#message-or-session-lock-is-lost-before-lock-expiration-time) for more information.

  - **MessageNotFound**: This occurs when attempting to receive a deferred message by sequence number for a message that either doesn't exist in the entity, or is currently locked. 
  
  - **SessionCannotBeLocked**: This indicates that the requested session cannot be locked because the lock is already held elsewhere. Once the lock expires, the session can be accepted.

  - **GeneralError**: This indicates that the Service Bus service encountered an error while processing the request. This is often caused by service upgrades and restarts. These are transient errors that will be automatically retried.

  - **ServiceCommunicationProblem**: This indicates that there was an error communicating with the service. The issue may stem from a transient network problem, or a service problem. These are transient errors that will be automatically retried.

  - **ServiceBusy**: This indicates that a request was throttled by the service. The details describing what can cause a request to be throttled and how to avoid being throttled can be found [here][Throttling]. Throttled requests are retried, but the client library will automatically apply a 10 second back off before attempting any additional requests using the same `ServiceBusClient` (or any subtypes created from that client). This can cause issues if your entity's lock duration is less than 10 seconds, as message or session locks are likely to be lost for any unsettled messages or locked sessions. Because throttled requests are generally retried successfully, the exceptions generated would be logged as warnings rather than errors - the specific warning-level event source event is 43 (RunOperation encountered an exception and will retry).

As an example of how to handle a `ServiceBusException` and filter by the `Reason`, see the following:

```C# Snippet:ServiceBusExceptionFailureReasonUsage
try
{
    // Receive messages using the receiver client
}
catch (ServiceBusException ex) when
    (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
{
    // Take action based on a service timeout
}
```

### Other common exceptions

- **ArgumentException** : An exception deriving from `ArgumentException` is thrown by clients when a parameter provided when interacting with the client is invalid. Information about the specific parameter and the nature of the problem can be found in the `Message`.

- **InvalidOperationException** : Occurs when attempting to perform an operation that isn't valid for its current configuration. This typically occurs when a client was not configured to support the operation. Often, it can be mitigated by adjusting the options passed to the client.

- **NotSupportedException** : Occurs when a requested operation is valid for the client, but not supported by its current state.  Information about the scenario can be found in the `Message`.

- **AggregateException** : Occurs when an operation may encounter multiple exceptions and is surfacing them as a single failure. This is most commonly encountered when starting or stopping the [ServiceBusProcessor][ServiceBusProcessor] or [ServiceBusSessionProcessor][ServiceBusSessionProcessor].

## Permissions issues

An [UnauthorizedAccessException][UnauthorizedAccessException] indicates that the provided credentials do not allow for the requested action to be performed. The `Message` property contains details about the failure.

The following verification steps are recommended, depending on the type of authorization provided when constructing the [ServiceBusClient][ServiceBusClient]:

- [Verify the connection string is correct][GetConnectionString]
- [Verify the SAS token was generated correctly][AuthorizeSAS]
- [Verify the correct RBAC roles were granted][RBAC]

For more possible solutions, see: [Troubleshooting guide for Azure Service Bus][TroubleshootingGuide].

## Connectivity issues

### Timeout when connecting to service

Depending on the host environment and network, this may present to applications as either a `TimeoutException`, `OperationCanceledException`, or a `ServiceBusException` with `Reason` of `ServiceTimeout` and most often occurs when the client cannot find a network path to the service.

To troubleshoot:

- Verify that the connection string or fully qualified domain name specified when creating the client is correct. For information on how to acquire a connection string, see: [Get a Service Bus connection string][GetConnectionString].

- Check the firewall and port permissions in your hosting environment and that the AMQP ports 5671 and 5672 are open and that the endpoint is allowed through the firewall.

- Try using the Web Socket transport option, which connects using port 443. For details, see: [configure the transport][TransportSample].

- See if your network is blocking specific IP addresses. For details, see: [What IP addresses do I need to allow?][ServiceBusIPAddresses].

- If applicable, verify the proxy configuration. For details, see: [Configuring the transport][TransportSample].

- For more information about troubleshooting network connectivity, see: [Troubleshooting guide for Azure Service Bus][TroubleshootingGuide].

### SSL handshake failures

This error can occur when an intercepting proxy is used. To verify, it is recommended that the application be tested in the host environment with the proxy disabled.

### Socket exhaustion errors

Applications should prefer treating the Service Bus types as singletons, creating and using a single instance through the lifetime of the application. Each new [ServiceBusClient][ServiceBusClient] created results in a new AMQP connection, which uses a socket. The [ServiceBusClient][ServiceBusClient] type manages the connection for all types created from that instance. Each [ServiceBusReceiver][ServiceBusReceiver], [ServiceBusSessionReceiver][ServiceBusSessionReceiver], [ServiceBusSender][ServiceBusSender], and [ServiceBusProcessor][ServiceBusProcessor] manages its own AMQP link for the associated Service Bus entity. When using a [ServiceBusSessionProcessor][ServiceBusSessionProcessor], multiple AMQP links may be established depending on the number of sessions that are being processed concurrently.

The clients are safe to cache when idle; they will ensure efficient management of network, CPU, and memory use, minimizing their impact during periods of inactivity. It is also important that either `CloseAsync` or `DisposeAsync` be called when a client is no longer needed to ensure that network resources are properly cleaned up.

### Adding components to the connection string does not work

The current generation of the Service Bus client library supports connection strings only in the form published by the Azure portal. These are intended to provide basic location and shared key information only; configuring behavior of the clients is done through its options.

Previous generations of the Service Bus clients allowed for some behavior to be configured by adding key/value components to a connection string. These components are no longer recognized and have no effect on client behavior.

#### "TransportType=AmqpWebSockets" Alternative

To configure web socket use, see: [Configuring the transport][TransportSample].

#### "Authentication=Managed Identity" Alternative

To authenticate with Managed Identity, see: [Identity and Shared Access Credentials][IdentitySample].

For more information about the `Azure.Identity` library, see: [Authentication and the Azure SDK][AuthenticationAndTheAzureSDK].

## Logging and diagnostics

The Service Bus client library is fully instrumented for logging information at various levels of detail using the .NET `EventSource` to emit information. Logging is performed for each operation and follows the pattern of marking the starting point of the operation, it's completion, and any exceptions encountered. Additional information that may offer insight is also logged in the context of the associated operation.

### Enable logging

The Service Bus client logs are available to any `EventListener` by opting into the sources starting with "Azure-Messaging-ServiceBus" or by opting into all sources that have the trait "AzureEventSource". To make capturing logs from the Azure client libraries easier, the `Azure.Core` library used by Service Bus offers an `AzureEventSourceListener`.

For more information, see: [Logging with the Azure SDK for .NET][Logging].

### Distributed tracing

The Service Bus client library supports distributed tracing though integration with the Application Insights SDK. It also has **experimental** support for the the OpenTelemetry specification via the .NET [ActivitySource][ActivitySource] type introduced in .NET 5. In order to enable `ActivitySource` support for use with OpenTelemetry, see [ActivitySource support][ActivitySourceSupport].

In order to use the GA DiagnosticActivity support, you can integrate with the Application Insights SDK. More details can be found in [ApplicationInsights with Azure Monitor][AppInsights].

The library creates the following spans:

`Message`  
`ServiceBusSender.Send`  
`ServiceBusSender.Schedule`  
`ServiceBusSender.Cancel`  
`ServiceBusReceiver.Receive`  
`ServiceBusReceiver.ReceiveDeferred`  
`ServiceBusReceiver.Peek`  
`ServiceBusReceiver.Abandon`  
`ServiceBusReceiver.Complete`  
`ServiceBusReceiver.DeadLetter`  
`ServiceBusReceiver.Defer`  
`ServiceBusReceiver.RenewMessageLock`  
`ServiceBusSessionReceiver.RenewSessionLock`  
`ServiceBusSessionReceiver.GetSessionState`  
`ServiceBusSessionReceiver.SetSessionState`  
`ServiceBusProcessor.ProcessMessage`  
`ServiceBusSessionProcessor.ProcessSessionMessage`  
`ServiceBusRuleManager.CreateRule`  
`ServiceBusRuleManager.DeleteRule`  
`ServiceBusRuleManager.GetRules`  

Most of the spans are self-explanatory and are started and stopped during the operation that bears its name. The span that ties the others together is `Message`. The way that the message is traced is via the the `Diagnostic-Id` that is set in the [ServiceBusMessage.ApplicationProperties][ApplicationProperties] property by the library during send and schedule operations. In Application Insights, `Message` spans will be displayed as linking out to the various other spans that were used to interact with the message, e.g. the `ServiceBusReceiver.Receive` span, the `ServiceBusSender.Send` span, and the `ServiceBusReceiver.Complete` span would all be linked from the `Message` span. Here is an example of what this looks like in Application Insights:

![image](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/assets/Tracing.png)

In the above screenshot, we see the end-to-end transaction that can be viewed in Application Insights in the portal. In this scenario, the application is sending messages and using the [ServiceBusSessionProcessor][ServiceBusSessionProcessor] to process them. The `Message` activity is linked to `ServiceBusSender.Send`, `ServiceBusReceiver.Receive`, `ServiceBusSessionProcessor.ProcessSessionMessage`, and `ServiceBusReceiver.Complete`. 

## Troubleshoot sender issues

### Cannot send batch with multiple partition keys

When sending to a partition-enabled entity, all messages included in a single send operation must have the same `PartitionKey`. If your entity is session-enabled, the same requirement holds true for the `SessionId` property. In order to send messages with different `PartitionKey` or `SessionId` values, group the messages in separate [ServiceBusMessageBatch][ServiceBusMessageBatch] instances or include them in separate calls to the [SendMessagesAsync][SendMessages] overload that takes a set of [ServiceBusMessage] instances.

### Batch fails to send

We define a message batch as either [ServiceBusMessageBatch][ServiceBusMessageBatch] containing 2 or more messages, or a call to [SendMessagesAsync][SendMessages] where 2 or more messages are passed in. The service does not allow a message batch to exceed 1MB. This is true whether or not the [Premium large message support][LargeMessageSupport] feature is enabled. If you intend to send a message greater than 1MB, it must be sent individually rather than grouped with other messages. Unfortunately, the [ServiceBusMessageBatch][ServiceBusMessageBatch] type does not currently support validating that a batch does not contain any messages greater than 1MB as the size is constrained by the service and may change. So if you intend to use the premium large message support feature, you will need to ensure you send messages over 1MB individually. See this [GitHub discussion][GitHubDiscussionOnBatching] for more info.

## Troubleshoot receiver issues

### Number of messages returned does not match number requested in batch receive

When attempting to do a batch receive, i.e. passing a `maxMessages` value of 2 or greater to the [ReceiveMessagesAsync][ReceiveMessages] method, you are not guaranteed to receive the number of messages requested, even if the queue or subscription has that many messages available at that time, and even if the entire configured `maxWaitTime` has not yet elapsed. To maximize throughput and avoid lock expiration, once the first message comes over the wire, the receiver will wait an additional 20ms for any additional messages before dispatching the messages for processing.  The `maxWaitTime` controls how long the receiver will wait to receive the *first* message - subsequent messages will be waited for 20ms. Therefore, your application should not assume that all messages available will be received in one call.

### Message or session lock is lost before lock expiration time

A Service Bus queue or topic subscription has a lock duration set at the resource level. When the receiver client pulls a message from the resource, the Service Bus broker applies an initial lock to the message. The initial lock lasts for the lock duration set at the resource level. If the message lock isn't renewed before it expires, then the Service Bus broker releases the message to make it available for other receivers. If the application tries to complete or abandon a message after the lock expiration, the call fails.

Service Bus leverages the AMQP protocol, which is stateful. Due to the nature of the protocol, if the link that connects the client and the service is detached after a message is received, but before the message is settled, the message is not able to be settled on reconnecting the link. Links can be detached due to a short-term transient network failure, a network outage, or due to the service enforced 10-minute idle timeout. The reconnection of the link happens automatically as a part of any operation that requires the link, i.e. settling or receiving messages. Because of this, you may encounter `ServiceBusException` with `Reason` of `MessageLockLost` or `SessionLockLost` even if the lock expiration time has not yet passed. 

In addition, the following usage patterns and scenarios may cause locks to be lost:

- When using a receiver type, the application's message processing time exceeds the lock duration set at the resource level and the lock has not been renewed.  Locks are renewed by calling [RenewMessageLockAsync](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceiver.renewmessagelockasync?view=azure-dotnet) or [RenewSessionLockAsync](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionreceiver.renewsessionlockasync?view=azure-dotnet) on the receiver.

- The application's message processing time exceeds both the lock duration set at the resource level and the [MaxAutoLockRenewalDuration](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusprocessoroptions.maxautolockrenewalduration?view=azure-dotnet) configured for your `ServiceBusProcessor` or [MaxAutoLockRenewalDuration](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions.maxautolockrenewalduration?view=azure-dotnet) for your `ServiceBusSessionProcessor`.  Note that if the lock renew duration is not set explicitly, it defaults to 5 minutes.

  This can be mitigated by manually renewing locks by calling [RenewMessageLockAsync](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.processmessageeventargs.renewmessagelockasync?view=azure-dotnet#azure-messaging-servicebus-processmessageeventargs-renewmessagelockasync(azure-messaging-servicebus-servicebusreceivedmessage-system-threading-cancellationtoken)) or [RenewSessionLockAsync](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.processsessionmessageeventargs.renewsessionlockasync?view=azure-dotnet) on the event arguments passed to your handler.  

- The application has turned on the Prefetch feature by setting the `PrefetchCount` property in the options to a non-zero value. When Prefetch is enabled, the client will retrieve the number of messages equal to the count from Service Bus and store them in a memory buffer. The messages stay in the prefetch buffer until they're read by the application. The client cannot access messages in the prefetch buffer and is unable to extend their locks. If the application processing takes long enough that message locks expire while held in prefetch, the application will read the messages with an already expired lock. For more information, see [Why is Prefetch not the default option?](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-prefetch?tabs=net#why-is-prefetch-not-the-default-option)

- The host environment lacks enough CPUs or has shortages of CPU cycles intermittently that delays the lock renew task from running on time.

- The host system time isn't accurate - for example, the clock is skewed - delaying the lock renew task and keeping it from running on time.

- The application has configured a degree of concurrency too aggressive for the host's resources using the [MaxConcurrentCals](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusprocessoroptions.maxconcurrentcalls?view=azure-dotnet) option for `ServiceBusProcessor` or a combination of [MaxConcurrentSessions](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions.maxconcurrentsessions?view=azure-dotnet) and [MaxConcurrentCallsPerSession](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions.maxconcurrentcallspersession?view=azure-dotnet) for `ServiceBusSessionProcessor`.  This will cause a high number of concurrent background network operations to run, competing for resources and potentially either being queued on the client or triggering Service Bus throttles.

  **NOTE:** If the application host environment is not sufficiently resourced, locks can still be lost even if there are only a few lock renew tasks running.  When using processor types, we recommend at least two full CPU cores.  For more context and discussion, see [Processor appears to hang or have latency issues when using high concurrency](#processor-appears-to-hang-or-have-latency-issues-when-using-high-concurrency).

### How to browse scheduled or deferred messages

Scheduled and deferred messages are included when peeking messages. They can be identified by the [ServiceBusReceivedMessage.State][MessageState] property. Once you have the [SequenceNumber][SequenceNumber] of a deferred message, you can receive it with a lock via the [ReceiveDeferredMessagesAsync][ReceiveDeferredMessages] method.

When working with topics, you cannot peek scheduled messages on the subscription, as the messages remain in the topic until the scheduled enqueue time. As a workaround, you can construct a [ServiceBusReceiver][ServiceBusReceiver] passing in the topic name in order to peek such messages. Note that no other operations with the receiver will work when using a topic name.

### How to browse session messages across all sessions

You can use a regular [ServiceBusReceiver][ServiceBusReceiver] to peek across all sessions. To peek for a specific session you can use the [ServiceBusSessionReceiver][ServiceBusSessionReceiver], but you will need to obtain a session lock.

### NotSupportedException thrown when accessing message body

This issue occurs most often in interop scenarios when receiving a message sent from a different library that uses a different AMQP message body format. If you are interacting with these types of messages, see the [AMQP message body sample][MessageBody] to learn how to access the message body. 

## Troubleshoot processor issues

### Autolock renewal is not working

Autolock renewal relies on the system time to determine when to renew a lock for a message or session. If your system time is not accurate, e.g. your clock is slow, then lock renewal may not happen before the lock is lost. Ensure that your system time is accurate if autolock renewal is not working.

### Processor appears to hang or have latency issues when using high concurrency

This is often caused by thread starvation, particularly when using the session processor and using a very high value for [MaxConcurrentSessions][MaxConcurrentSessions], relative to the number of cores on the machine. The first thing to check would be to make sure you are not doing sync-over-async in any of your event handlers. Sync-over-async is an easy way to cause deadlocks and thread starvation. Even if you are not doing sync over async, any pure sync code in your handlers could contribute to thread starvation. If you've determined that this is not the issue, e.g. because you have pure async code, you can try increasing your [TryTimeout][TryTimeout]. This will relieve pressure on the threadpool by reducing the number of context switches and timeouts that may occur when using the session processor in particular. The default value for [TryTimeout][TryTimeout] is 60 seconds, but it can be set all the way up to 1 hour.  We recommend testing with the `TryTimeout` set to 5 minutes as a starting point and iterate from there. If none of these suggestions work, you may simply need to scale out to multiple hosts, reducing the concurrency in your application, but running the application on multiple hosts to achieve the desired overall concurrency.

Further reading:
- [Debug ThreadPool Starvation][DebugThreadPoolStarvation]
- [Diagnosing .NET Core ThreadPool Starvation with PerfView (Why my service is not saturating all cores or seems to stall)](https://learn.microsoft.com/archive/blogs/vancem/diagnosing-net-core-threadpool-starvation-with-perfview-why-my-service-is-not-saturating-all-cores-or-seems-to-stall)
- [Diagnosing ThreadPool Exhaustion Issues in .NET Core Apps][DiagnoseThreadPoolExhaustion] _(video)_

### Session processor takes too long to switch sessions

This can be configured using the [SessionIdleTimeout][SessionIdleTimeout], which tells the processor how long to wait to receive a message from a session, before giving up and moving to another one. This is useful if you have many sparsely populated sessions, where each session may only have a few messages. If you expect that each session will have many messages that trickle in, setting this too low can be counter productive, as it will result in unnecessary closing of the session.

### Processor stops immediately

This is often observed for demo or testing scenarios.  `StartProcessingAsync` returns immediately after the processor has started. Calling this method will not block and keep your application alive while the processor is running, so you'll need some other mechanism to do so.  For demos or testing, it may be sufficient to just add a `Console.ReadKey()` call after you start the processor. For production scenarios, you will likely want to use some sort of framework integration like [BackgroundService][BackgroundService] to provide convenient application lifecycle hooks that can be used for starting and disposing the processor.

## Troubleshoot transactions

For general information about transactions in Service Bus, see the [Overview of Service Bus transaction processing][Transactions].

### Supported operations

Not all operations are supported when using transactions. To see the list of supported transactions, see [Operations within a transaction scope][TransactionOperations].

### Timeout

A transaction times out after a [period of time][TransactionTimeout], so it is important that processing that occurs within a transaction scope adheres to this timeout.

### Operations in a transaction are not retried

This is by design. Consider the following scenario - you are attempting to complete a message within a transaction, but there is some transient error that occurs, e.g. `ServiceBusException` with a `Reason` of `ServiceCommunicationProblem`. Suppose the request does actually make it to the service. If the client were to retry, the service would see two complete requests. The first complete will not be finalized until the transaction is committed. The second complete is not able to even be evaluated before the first complete finishes. The transaction on the client is waiting for the complete to finish. This creates a deadlock where the service is waiting for the client to complete the transaction, but the client is waiting for the service to acknowledge the second complete operation. The transaction will eventually timeout after 2 minutes, but this is a bad user experience. For this reason, we do not retry operations within a transaction.

### Transactions across entities are not working

In order to perform transactions that involve multiple entities, you'll need to set the `ServiceBusClientOptions.EnableCrossEntityTransactions` property to `true`. For details, see the [Transactions across entities][CrossEntityTransactions] sample. 

## Quotas

Information about Service Bus quotas can be found [here][ServiceBusQuotas].

[ServiceBusException]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusexception?view=azure-dotnet
[ServiceBusRetryOptions]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusretryoptions?view=azure-dotnet
[ServiceBusQuotas]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quotas
[UnauthorizedAccessException]: https://learn.microsoft.com/dotnet/api/system.unauthorizedaccessexception
[RetryOptionsSample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample13_AdvancedConfiguration.md#customizing-the-retry-options
[TransportSample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample13_AdvancedConfiguration.md#configuring-the-transport
[ServiceBusMessagingExceptions]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messaging-exceptions
[AmqpSpec]: https://www.amqp.org/resources/specifications
[GetConnectionString]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quickstart-portal#get-the-connection-string
[AuthorizeSAS]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-sas
[RBAC]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-managed-service-identity
[TroubleshootingGuide]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-troubleshooting-guide
[ServiceBusIPAddresses]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-faq#what-ip-addresses-do-i-need-to-add-to-allowlist-
[ServiceBusProcessor]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusprocessor?view=azure-dotnet
[ServiceBusSessionProcessor]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessor?view=azure-dotnet
[MaxConcurrentSessions]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions.maxconcurrentsessions?view=azure-dotnet
[SessionIdleTimeout]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions.sessionidletimeout?view=azure-dotnet
[ServiceBusClient]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusclient?view=azure-dotnet
[TryTimeout]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusretryoptions.trytimeout?view=azure-dotnet
[ServiceBusReceiver]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceiver?view=azure-dotnet
[ServiceBusSessionReceiver]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionreceiver?view=azure-dotnet
[ServiceBusSender]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussender?view=azure-dotnet
[ServiceBusMessageBatch]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusmessagebatch?view=azure-dotnet
[ServiceBusMessage]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusmessage?view=azure-dotnet
[SendMessages]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussender.sendmessagesasync?view=azure-dotnet#azure-messaging-servicebus-servicebussender-sendmessagesasync(system-collections-generic-ienumerable((azure-messaging-servicebus-servicebusmessage))-system-threading-cancellationtoken)
[ReceiveMessages]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceiver.receivemessagesasync?view=azure-dotnet#azure-messaging-servicebus-servicebusreceiver-receivemessagesasync(system-int32-system-nullable((system-timespan))-system-threading-cancellationtoken)
[ReceiveDeferredMessages]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceiver.receivedeferredmessagesasync?view=azure-dotnet
[MessageState]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage.state?view=azure-dotnet#azure-messaging-servicebus-servicebusreceivedmessage-state
[SequenceNumber]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage.sequencenumber?view=azure-dotnet
[Logging]: https://learn.microsoft.com/dotnet/azure/sdk/logging
[ActivitySourceSupport]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#activitysource-support
[ActivitySource]: https://learn.microsoft.com/dotnet/api/system.diagnostics.activitysource?view=dotnet
[ApplicationProperties]: https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusmessage.applicationproperties?view=azure-dotnet
[AppInsights]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#applicationinsights-with-azure-monitor
[TransactionOperations]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions#operations-within-a-transaction-scope
[Transactions]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions
[CrossEntityTransactions]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample06_Transactions.md#transactions-across-entities
[LargeMessageSupport]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-premium-messaging#large-messages-support
[GitHubDiscussionOnBatching]: https://github.com/Azure/azure-sdk-for-net/issues/25381#issuecomment-1227917960
[BackgroundService]: https://learn.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice?view=dotnet
[AuthenticationAndTheAzureSDK]: https://devblogs.microsoft.com/azure-sdk/authentication-and-the-azure-sdk
[IdentitySample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Azure.Messaging.ServiceBus#authenticating-with-azureidentity
[DebugThreadPoolStarvation]: https://learn.microsoft.com/dotnet/core/diagnostics/debug-threadpool-starvation
[DiagnoseThreadPoolExhaustion]: https://learn.microsoft.com/shows/on-net/diagnosing-thread-pool-exhaustion-issues-in-net-core-apps
[TransactionTimeout]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions#timeout
[MessageBody]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample14_AMQPMessage.md#message-body
[Throttling]: https://learn.microsoft.com/azure/service-bus-messaging/service-bus-throttling

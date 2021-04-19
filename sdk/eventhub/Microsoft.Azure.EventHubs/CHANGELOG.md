# Release History

## 4.4.0-beta.1 (Unreleased)


## 4.3.1 (2020-10-29)
### Breaking Changes
None

### Improvements
- AMQP connection idle timeout set to 60 seconds to detect broken or idle connections much quicker. (https://github.com/Azure/azure-sdk-for-net/pull/15926)

### Bug Fixes
- Diagnostics listener batch overhead allocation increased to avoid failures during batch sends. (https://github.com/Azure/azure-sdk-for-net/pull/15193)
- Client now converts InvalidOperationException into a retriable EventHubsException thrown during AMQP link clouse. This helps upper layers to retry the failed operation instead of them bailing out. (https://github.com/Azure/azure-sdk-for-net/pull/15984)


## 4.3.0 (2020-08-11)
### Breaking Changes
None

### Improvements
- Batch size can be accessed as a property on the EventDataBatch objects. (https://github.com/Azure/azure-sdk-for-net/pull/13976)
- ContentType is provided as a property on EventData objects. (https://github.com/Azure/azure-sdk-for-net/pull/14047)

### Bug Fixes
- Batch size calculation issue when diagnostics enabled is now fixed. (https://github.com/Azure/azure-sdk-for-net/pull/13966)
- Senders and receivers can now throw more descriptive error when underlying client is closed. (https://github.com/Azure/azure-sdk-for-net/pull/14030)
- Send APIs to handle provided EventData enumerators properly when enumerator is not re-scannable. (https://github.com/Azure/azure-sdk-for-net/pull/14053)

## 4.2.0
### Breaking Changes
None

### Improvements
- Client to retry on PublisherRevokedException. (https://github.com/Azure/azure-sdk-for-net/pull/9361)
- ManagedIdentityTokenProvider now supports custom AzureServiceTokenProvider where developers can use customized service token providers per deployment environment. (https://github.com/Azure/azure-sdk-for-net/pull/9943)
 
### Bug fixes
- Closing an EventHubClient now closes all senders and receivers created from that client. (https://github.com/Azure/azure-sdk-for-net/pull/7443)
- Enforce token refresh interval under max allowed TimeSpan to avoid failures. (https://github.com/Azure/azure-sdk-for-net/pull/8541)
- Fix for managed identity connection string setting to handle value set. (https://github.com/Azure/azure-sdk-for-net/pull/10618)

## 4.1.0
### Breaking Changes
None

### Improvements
- Diagnostics event names shorted as recommended by https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md#event-names (https://github.com/Azure/azure-sdk-for-net/pull/7186)
- Added ErrorLevelType to base class EventHubsException. This will help developers to take better actions while handling exceptions. (https://github.com/Azure/azure-sdk-for-net/pull/7194)
- Safe-Close AMQP session when link creation fails instead of abort. (https://github.com/Azure/azure-sdk-for-net/pull/7216)
- EventHubClient, PartitionSender, and PartitionReceiver to expose closed state. (https://github.com/Azure/azure-sdk-for-net/pull/7365)

### Bug fixes
- FixedAsyncLock's semaphore implementation to limit concurrent requests to always 1. (https://github.com/Azure/azure-sdk-for-net/pull/7203)

# Release History

## 4.3.0 (Unreleased)


## 4.2.1 (Unreleased)


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

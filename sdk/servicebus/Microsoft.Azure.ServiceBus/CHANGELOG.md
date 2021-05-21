# Release History

## 5.1.3 (2021-04-15)

Update package description to include pointer to the new Azure.Messaging.ServiceBus package and the migration guide.

## 5.1.2 (2021-02-24)
- Update dependency of Microsoft.Azure.Amqp to version 2.4.11 to take in the fix: In auto-flow mode, do not issue more credits when the receiver link is closing. 
  This solves the bug when prefetch mode is enabled, unexpected number of messages will not be released properly so their delivery count will increase.
- Remove unnecessary Manage claim from sender and receiver. This will fix the scenario where customized TokenProvider is not giving Manage claims [PR 18740](https://github.com/Azure/azure-sdk-for-net/pull/18740)
- Fix Unregister and Re-Register a Message/Session Handler results in System.ObjectDisposedException [PR 18899](https://github.com/Azure/azure-sdk-for-net/pull/18899)

## 5.1.1 (2021-01-12)
- Update dependency of Microsoft.Azure.Amqp to version 2.4.9

## 5.1.0 (2020-11-20)
- Bugfix - Fixing a bug in management client that is sending atom xml elements out of order [PR 16488](https://github.com/Azure/azure-sdk-for-net/pull/16488)
- Bugfix - Convert "Invalid operation while connection is closing" to retriable ServiceBusException [PR 17023](https://github.com/Azure/azure-sdk-for-net/pull/17023)

## 5.0.0 (2020-09-11)
### Breaking Changes
- Setting sessionId to be same as partition key and adding validation [PR 13961](https://github.com/Azure/azure-sdk-for-net/pull/13961)

### Improvements
- Enable a way to Unregister Message Handler and Session Handler [PR 14021](https://github.com/Azure/azure-sdk-for-net/pull/14021)
- Documentation: Add `SendAsync` warning for partition entities when batching is enabled [PR 14021](https://github.com/Azure/azure-sdk-for-net/pull/11028)

## 4.1.3 (2020-04-17)
- Add `GetQueuesRuntimeInfoAsync`, `GetTopicsRuntimeInfoAsync` and `GetSubscriptionsRuntimeInfoAsync` to `ManagementClient` to allow retrieval of batched entity runtime information. [PR 10261](https://github.com/Azure/azure-sdk-for-net/pull/10261)
- Increase version range allowed for `System.IdentityModel.Tokens.Jwt` [PR 10885](https://github.com/Azure/azure-sdk-for-net/pull/10885)
- Improved XML API-documentation [PR 11028](https://github.com/Azure/azure-sdk-for-net/pull/11028)
- Bugfix - `ForwardTo` should not error on 260 character name [PR 11059](https://github.com/Azure/azure-sdk-for-net/pull/11059)

## 4.1.2
- Same as version 4.1.1 but has pdb symbols published

## 4.1.1
### Bug fixes
- Ignore OperationCanceledException while closing Message Pump. [PR 8449](https://github.com/Azure/azure-sdk-for-net/pull/8449)

## 4.1.0
### Improvements
- Support for creation of `SqlFilter` for subscriptions with parameter of type `TimeSpan`. [PR 7325](https://github.com/Azure/azure-sdk-for-net/pull/7325)

### Bug fixes
- Fix bug from RBAC which points to the incorrect audience [PR 7303](https://github.com/Azure/azure-sdk-for-net/pull/7303)
- Ensure creation of `AMQP-link` (i.e, any client) to a non-existing subscription throws `MessagingEntityNotFoundException` instead of `ServiceBusCommunicationException` [PR 7942](https://github.com/Azure/azure-sdk-for-net/pull/7942)
- Avoid reporting `OperationCanceledException` in message pump (invoked via `RegisterMessageHandler`) when the pump is being closed. [PR 7935](https://github.com/Azure/azure-sdk-for-net/pull/7935)
- Avoid potential dead-locks. [PR 8059](https://github.com/Azure/azure-sdk-for-net/pull/8059)
- Adding default idle timeout for the underlying `AmqpConnection` object. [PR 7944](https://github.com/Azure/azure-sdk-for-net/pull/7944)

## 4.0.0
### Breaking Changes
- Allow clients to report if they own or share the underlying connection string [PR 6037](https://github.com/Azure/azure-sdk-for-net/pull/6037)
- RBAC support - Allow more flexible ways to provide authentication [PR 6393](https://github.com/Azure/azure-sdk-for-net/pull/6393) (broken)
- Updating RBAC API signatures [PR 6578](https://github.com/Azure/azure-sdk-for-net/pull/6578)
- RBAC and ManagedIdentity fixes [PR 6637](https://github.com/Azure/azure-sdk-for-net/pull/6637)

### Improvements
- Remove explicit offloading in TaskExtensionHelper [PR 6545](https://github.com/Azure/azure-sdk-for-net/pull/6545)
- Make ConcurrentExpiringSet not leak the cleanup task for the period of delayBetweenCleanups - lock free [PR 6577](https://github.com/Azure/azure-sdk-for-net/pull/6577)
- Unblock message pump while receiving message to improve performance [PR 6804](https://github.com/Azure/azure-sdk-for-net/pull/6804)
- Message sender now exposes `viaEntityPath` that points to the via-entity. [PR 6941](https://github.com/Azure/azure-sdk-for-net/pull/6941)
- Throwing `ServiceBusCommunicationException` when it is connectionError instead of `ServiceBusException` [PR 6942](https://github.com/Azure/azure-sdk-for-net/pull/6942)
- Updating xmldoc - remarks on MessageHandlerOptions.MaxAutoRenewDuration [PR 6951](https://github.com/Azure/azure-sdk-for-net/pull/6951)

### Bug fixes
- Fixes session pump stop when auto-renew lock task expires [PR 6483](https://github.com/Azure/azure-sdk-for-net/pull/6483)
- Fix session pump stops on some exceptions  [PR 6485](https://github.com/Azure/azure-sdk-for-net/pull/6485)
- Prevent pump from stop processing by ignoring ObjectDisposedException [PR 6510](https://github.com/Azure/azure-sdk-for-net/pull/6510)
- Ensure that when AcceptMessageSession times out, it doesnt report it as Exception in AppInsights (DiagnosticSource) [PR 6919](https://github.com/Azure/azure-sdk-for-net/pull/6919)
- Ensure client side timeouts are honored [PR 6920](https://github.com/Azure/azure-sdk-for-net/pull/6920)
- Throw ServiceBusCommunicationException when session is being created at the same time when connection is being closed. [PR 6940](https://github.com/Azure/azure-sdk-for-net/pull/6940)
- Ensure if link has been authorized for a time less than TokenRefreshBuffer, it doesn't lead to unexpected errors. [PR 7053](https://github.com/Azure/azure-sdk-for-net/pull/7053)

### For older releases, please check https://github.com/Azure/azure-service-bus-dotnet/releases

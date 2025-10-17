# Release History

## 1.7.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

- Updated `System.IdentityModel.Tokens.Jwt` to 8.14.0

## 1.6.0 (2025-05-07)

### Features Added
- Added method `serviceClient.ListConnectionsInGroup` and `serviceClient.ListConnectionsInGroupAsync`.`

## 1.5.0 (2025-02-27)

### Features Added
- Added support for SocketIO when generating ClientAccessURI

## 1.4.0 (2024-07-31)

### Features Added

- Added method overloads `serviceClient.GetClientAccessUri`, `serviceClient.GetClientAccessUri` for MQTT clients.
- Added method `serviceClient.AddConnectionsToGroups` to add filtered connections to specified multiple groups.
- Added method `serviceClient.RemoveConnectionsFromGroups` to remove filtered connections from specified multiple groups.

## 1.3.0 (2022-11-20)

### Features Added

- Added method `serviceClient.RemoveConnectionFromAllGroups` to remove the connection from all the groups it is in.
- Added a `groups` option in `serviceClient.GetClientAccessUri`, to enable connections join initial groups once it is connected.
- Added a `filter` parameter when sending messages to connections in a hub/group/user to filter out the connections recieving message, details about `filter` syntax please see [OData filter syntax for Azure Web PubSub](https://aka.ms/awps/filter-syntax).
- Provided a utility class `ClientConnectionFilter` to generate the `filter` parameter, e.g. `ClientConnectionFilter.Create($"{group1} in groups and not({group2} in groups)"))`

## 1.2.0 (2022-11-04)

### Bugs Fixed

- Fix the issue that the token lifetime is 0 when `expiresAfter` is not given.

## 1.1.0 (2022-10-28)

### Bugs Fixed
- Fix the issue that `expiresAfter` might be 0

## 1.1.0-beta.1 (2022-08-06)

### Bugs Fixed
- Fix the issue that when `expiresAfter` is less than 1 minute it requests a token with 0 ttl

## 1.0.0 (2021-11-09)

### Features Added
- Added extension method `AddWebPubSubServiceClient` for `TokenCredential`
- Added `CloseGroupConnections`, `CloseAllConnections` and `CloseUserConnections`

### Breaking Changes
- Renamed `GenerateClientAccessUri` to `GetClientAccessUri`

## 1.0.0-beta.3 (2021-09-07)

### Features Added
- Support for [Azure Active Directory](https://learn.microsoft.com/azure/active-directory/authentication/) based authentication. Users can specify a [`TokenCredential`](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential) when creating a `WebPubSubServiceClient`. For example, you can get started with `new WebPubSubServiceClient(endpoint, hub, new DefaultAzureCredential())` to authenticate via AAD using [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## 1.0.0-beta.2 (2021-07-16)

### Features Added
- Added support for [RequestOptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md#using-requestoptions-to-customize-behavior) on protocol methods.
- Added support for API management with `ReverseProxyEndpoint` option. https://github.com/Azure/azure-webpubsub/issues/194 describes how to integrate with the API Management service.
- Removed dependency on `System.IdentityModel.Tokens.Jwt`.

### Bugs Fixed
- https://github.com/Azure/azure-webpubsub/issues/166
- https://github.com/Azure/azure-webpubsub/issues/90

## 1.0.0-beta.1 (2021-04-23)
- Initial beta release.

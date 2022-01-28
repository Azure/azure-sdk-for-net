# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2021-11-09)

### Features Added
- Added extension method `AddWebPubSubServiceClient` for `TokenCredential`
- Added `CloseGroupConnections`, `CloseAllConnections` and `CloseUserConnections`

### Breaking Changes
- Renamed `GenerateClientAccessUri` to `GetClientAccessUri`

## 1.0.0-beta.3 (2021-09-07)

### Features Added
- Support for [Azure Active Directory](https://docs.microsoft.com/azure/active-directory/authentication/) based authentication. Users can specify a [`TokenCredential`](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential) when creating a `WebPubSubServiceClient`. For example, you can get started with `new WebPubSubServiceClient(endpoint, hub, new DefaultAzureCredential())` to authenticate via AAD using [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

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

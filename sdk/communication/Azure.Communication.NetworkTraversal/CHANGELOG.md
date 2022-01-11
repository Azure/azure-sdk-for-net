# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2021-11-18)

### Features Added

- RouteType is a new added parameter that allows the user to specify the desired routing protocol for the 
  requested RelayConfiguration
- Introducing GetRelayConfigurationOptions which contains the optional parameters UserIdentity and RouteType
  when calling the methods GetRelayConfiguration and GetRelayConfigurationAsync. 

## 1.0.0-beta.2 (2021-07-14)

### Breaking Changes

- Renamed `CommunicationTurnServer` to `CommunicationIceServer`
- Renamed field `turnServers` to `iceServers` in `CommunicationRelayConfiguration`

## 1.0.0-beta.1 (2021-05-24)

This is the first release of Azure Communication Services for Network Traversal. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.NetworkTraversal/README.md

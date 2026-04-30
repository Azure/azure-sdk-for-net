# Release History

## 1.0.0 (2026-04-29)

### Features Added

- General Availability release of `Azure.ResourceManager.FileShares`.
- Upgraded API version to `2026-06-01`
- Added new type `NfsProtocolProperties` with `RootSquash` and `EncryptionInTransitRequired` properties
- Added new extensible enum `EncryptionInTransitRequired` with values `Enabled` and `Disabled`
- `FileShareSnapshotProperties.InitiatorId` is now settable

### Breaking Changes

- `FileShareProperties.NfsProtocolRootSquash` has been replaced by `FileShareProperties.NfsProtocolProperties`
- `FileSharePatchProperties.NfsProtocolRootSquash` has been replaced by `FileSharePatchProperties.NfsProtocolProperties`
- `FileSharePatchProperties.ProvisionedStorageInGiB` has been renamed to `FileSharePatchProperties.ProvisionedStorageGiB`

## 1.0.0-beta.1 (2026-01-06)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

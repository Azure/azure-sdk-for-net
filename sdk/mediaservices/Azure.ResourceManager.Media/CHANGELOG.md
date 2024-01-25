# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.0 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.3.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.2.0 (2023-03-22)

### Features Added

- Added MediaServicesMinimumTlsVersion property to MediaServicesAccount
- Added EncryptionScope property to MediaAsset

## 1.1.0 (2023-01-27)

### Features Added

- Added support for Fade In/Out On Filters class for StandardEncoderPreset

## 1.0.0 (2022-09-26)

This release is the first stable release of the Media Management client library.

### Breaking Changes

- All `Asset-` models renamed to `MediaAsset-`.
- Prepended `MediaServices` prefix to some special models.
- Prepended `Media` prefix to all `Job` models.
- Renamed `MediaTransformJob` to `MediaJob`.
- Shorted `HttpLiveStreaming` to `Hls`.
- Renamed `ContentKeyPolicyPlayReadySecurityLevel` to `PlayReadySecurityLevel`.
- Renamed `LiveEvent` to `MediaLiveEvent`.
- Renamed `LiveOutput` to `MediaLiveOutput`.
- Removed operations related methods that have been supported by core lib.
- Other renames.

## 1.0.0-beta.3 (2022-09-14)

### Features Added

- Upgraded the API version to `2022-08-01`

### Breaking Changes

- Renamed `TransformOutputsPriority` to `MediaTransformOutputsPriority`.
- Renamed `ContentKeyPolicyPreference` to `ContentKeyPolicyOption`.
- Renamed `GetContainerSasContent` to `GetStorageContainersContent`.
- Renamed `MediaPreset` to `MediaTransformPreset`.
- Removed all get LRO operation status / result methods that is natively supported by the LRO object ArmOperation.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `Media` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResourceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Media` to `Azure.ResourceManager.Media`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

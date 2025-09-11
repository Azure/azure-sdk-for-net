# Release History

## 1.1.0 (2025-09-15)

### Features Added

- Updated Microsoft.IoTFirmwareDefense API version to `2025-08-02`
- Improve backwards compatibility for CVE data models

## 1.1.0-beta.1 (2025-06-02)

### Features Added

- Updated Microsoft.IoTfirmwareDefense API version to `2025-04-01-preview`
- Added new get operations for fetching workspace usage metrics

### Breaking Changes

- Renamed models as per previous API/SDK review instructions to align with standard naming conventions

## 1.0.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.0.0 (2024-02-28)

This release is the first stable release of the IoT Firmware Defense Management client library.

### Features Added

- Updated Microsoft.IoTfirmwareDefense API version to `2024-01-10`
- Added new Get operations and models for fetching firmware analysis results and result summaries as resources.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Removed Generate* action operations (post actions) for fetching firmware analysis results
- Deprecated several unused properties in firmware results models

## 1.0.0-beta.2 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.1 (2023-06-27)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

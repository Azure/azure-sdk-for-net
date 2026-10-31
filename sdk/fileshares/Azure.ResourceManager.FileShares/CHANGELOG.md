# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Upgraded API version to `2026-09-01`.
- Added managed identity support: `FileShareData.Identity` and `FileSharePatch.Identity`.
- Added encryption settings through `FileShareProperties.Encryption` and `FileSharePatchProperties.Encryption`, covering customer-managed keys (`CustomerManagedKeyEncryption`, `KeyEncryptionKeyIdentity`) and infrastructure encryption (`InfrastructureEncryption`).
- Added redundancy conversion: `FileShareResource.StartRedundancyConversion` and `FileShareResource.GetRedundancyConversionStatus` (with async variants), and `FileShareProperties.RedundancyConversionInProgress`.
- Added `GetLimits` and `GetLimitsAsync` overloads that accept a `FileShareLimitsContent` describing the offer to query. The existing overloads are unchanged.
- Added `FileShareProvisioningRecommendationContent.Properties` for the additional provisioning recommendation inputs.
- Added `FileShareMediaTier.HDD` and `FileShareProperties.ScaleMode`.

## 1.0.0 (2026-04-30)

### Features Added

- Upgraded API version to `2026-06-01` (GA)
- General availability of the Azure.ResourceManager.FileShares package

## 1.0.0-beta.2 (2026-02-05)

### Features Added

- Upgraded API version to `2025-09-01-preview`
- Updated to latest API specification commit

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

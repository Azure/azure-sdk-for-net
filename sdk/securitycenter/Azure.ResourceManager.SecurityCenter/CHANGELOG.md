# Release History

## 1.2.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.5 (2024-01-15)

### Features Added

- Switch to use tag `package-dotnet-sdk` for autorest generation
- Add `securityConnectorsDevOps` at `2023-09-01-preview`
- Add `apiCollections` at `2023-11-15`
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

- Removed IngestionSettings (deprecated)

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.37.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.0

## 1.2.0-beta.4 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.3 (2023-09-18)

### Features Added

- Bump api-version of `Pricings` to `2023-03-01`.

### Other Changes

- Upgraded Azure.Core from 1.32.0 to 1.35.0
- Upgraded Azure.ResourceManager from 1.6.0 to 1.7.0

## 1.2.0-beta.2 (2023-06-02)

### Features Added

- Bump api-version of `SqlVulnerabilityAssessmentsScanOperations` to `2023-02-01-preview`.
- Bump api-version of `SqlVulnerabilityAssessmentsScanResultsOperations` to `2023-02-01-preview`.
- Bump api-version of `SqlVulnerabilityAssessmentsBaselineRuleOperations` to `2023-02-01-preview`.

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-02-13)

### Bugs Fixed

- Fixed `AddRules` methods in `SqlVulnerabilityAssessmentBaselineRuleCollection`.
- Fixed parameter mapping in `AdaptiveNetworkHardeningResource`, `ServerVulnerabilityAssessmentResource` and `SoftwareInventoryResource`.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.
- Improved polymorphic models.

## 1.0.0 (2022-11-04)

This package is the first stable release of the Microsoft Azure Security Center management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `SecurityCenter` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected all acronyms that don't follow [.NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.SecurityCenter` to `Azure.ResourceManager.SecurityCenter`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

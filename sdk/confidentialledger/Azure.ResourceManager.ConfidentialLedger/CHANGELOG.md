# Release History

## 1.1.0-beta.7 (Unreleased)

### Features Added

- Upgraded api-version tag from 'package-preview-2024-09' to 'package-preview-2025-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/01fab3a22af7bc6f37b7b96156372d0217a31e6d/specification/confidentialledger/resource-manager/readme.md

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.6 (2025-05-08)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-06' to 'package-preview-2024-09'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/96955c9cf1998abe8b24d44a79ea2c5cce9b9c46/specification/confidentialledger/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.45.0 to 1.46.0
- Upgraded Azure.ResourceManager from 1.13.0 to 1.13.1

## 1.1.0-beta.5 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0-beta.4 (2024-05-07)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-01' to 'package-preview-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/de1bc645b4c91e6cb3fddb5588c102ca050dd4da/specification/confidentialledger/resource-manager/readme.md.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Enable long-running operation rehydration.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.39.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.11.1

## 1.1.0-beta.3 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.2 (2023-06-21)

### Features Added

- Support for deploying and managing Azure Managed CCF instances.

### Other Changes

- Upgraded API version to 2023-01-26-preview.

## 1.1.0-beta.1 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-13)

This release is the first stable release of the Confidential Ledger management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `ConfidentialLedger` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

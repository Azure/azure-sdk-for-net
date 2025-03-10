# Release History

## 1.1.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.3 (2025-02-14)

### Features Added

- Upgraded api-version tag from 'package-2024-06-01-preview' to 'package-2024-11-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/7a3f210cf6924c6139e2493f5fd0625919af1f32/specification/nginx/resource-manager/readme.md.
    - Added Nginx Deployment API Key support.
- Rename `AnalysisResultData` to `NginxAnalysisResultDetails`.
- Removed location support from `NginxConfigurationData`.

### Other Changes

- Upgraded Azure.Core from 1.44.1 to 1.45.0

## 1.1.0-beta.2 (2024-10-30)

### Features Added

- Upgraded api-version tag from 'package-2024-01-01-preview' to 'package-2024-06-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/eea7584434f9225cad0327d83d5c6d84257a4d7d/specification/nginx/resource-manager/readme.md
    - Added NGINX App Protect Web Application Firewall (WAF) support.

### Other Changes

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0-beta.1 (2024-05-17)

### Features Added

- Upgraded api-version tag from 'package-2023-04-01' to 'package-2024-01-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/d1f4d6fcf1bbb2e71a32bb2079de12f17fedf56a/specification/nginx/resource-manager/readme.md
    - Added AutoScaling and AutoUpgrade
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.39.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.0.0 (2024-01-04)

### Features Added

- Upgrade to Nginx API version 2023-04-01.
    - Added support for scaling.
- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.2 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.1 (2022-11-17)

### Breaking Changes

- New design of track 2 initial commit.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

# Release History

## 1.6.0 (2025-01-20)

### Features Added

- Upgraded to Azure API version 2024-04-13.
- Introduced callout policy functionality.
- Introduced a new cluster principal role called `AllDatabasesMonitor`.
- Introduced the ability to specify a baseImageName for SandboxCustomImages. Now, either languageVersion or baseImageName is required.
- Added clusterLevel and principalsPermissionAction to script properties.

### Other Changes

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.5.1 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.5.0 (2023-10-25)

### Features Added

- Introduced Cluster Sandbox Custom Image functionality.

### Other Changes

- Upgraded to Azure API version 2023-08-15.

## 1.4.0 (2023-07-05)

### Features Added

- Introduced Cluster Migrate functionality.
- Introduced Database invite follower functionality.
- Introduced Database CMK functionality.

### Other Changes

- Upgraded to Azure API version 2023-05-02.

## 1.4.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.3.0 (2023-02-12)

### Features Added

- Introduce management of table functions sharing for follower database
- Introduce new SKU

### Other Changes

- Upgraded API version to 2022-12-29.

## 1.2.0 (2023-01-10)

### Features Added

- Supported CosmosDB data connection.
- Supported cluster creation with LanguageExtensionImage.
- Added method `GetSkus` to get available skus by location.

### Other Changes

- Upgraded API version to 2022-11-11.

## 1.1.0 (2022-11-17)

### Features Added

- Ability to exclude caller from being an admin on Database create/update.
- EH and IoT hub data connection new property for lookback – start collecting data that was generated a while ago.
- Follower name override/prefix – ability to define either different name for Read-Only-Following DB, or define prefix name for all DBs (in case of full cluster following scenario).
- Enhancing Follower GET-related APIs to improve demonstration of follower-leader linage in Azure portal.

### Bugs Fixed

- Added `KustoClusterPrincipalAssignmentData.ClusterPrincipalId` to replace the old property `KustoClusterPrincipalAssignmentData.PrincipalId` to fix the issue https://github.com/Azure/azure-sdk-for-net/issues/32331.

### Other Changes

- Upgraded API version to 2022-07-07.
- New API has the following new SKUs: Standard_L8s_v3, Standard_L16s_v3, Standard_L8as_v3, Standard_L16as_v3, Standard_E16s_v5+4TB_PS, Standard_E2d_v4, Standard_E4d_v4, Standard_E8d_v4, Standard_E16d_v4, Standard_E2d_v5, Standard_E4d_v5, Standard_E8d_v5, Standard_E16d_v5.

## 1.0.1 (2022-10-09)

### Bugs Fixed

- Added `KustoDatabasePrincipalAssignmentData.DatabasePrincipalId` to replace the old property `KustoDatabasePrincipalAssignmentData.PrincipalId` to fix the issue https://github.com/Azure/azure-sdk-for-net/issues/31618.

## 1.0.0 (2022-09-19)

This release is the first stable release of the Kusto Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Kusto` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-18)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Kusto` to `Azure.ResourceManager.Kusto`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).


# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.0 (2025-05-21)

### Features Added

- Upgraded api-version tag to 'package-2024-05' from 'package-preview-2023-03'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2d973fccf9f28681a481e9760fa12b2334216e21/specification/apimanagement/resource-manager/readme.md.
    - Added Gateway resource operation.
    - Added Workspace Backend operations.
    - Added Workspace Certificate Operations.
    - Added Workspace Logger Operations
    - Added WorkspaceLinks Operations
    - Added Workspace Api diagnostics Operations
    - Added OperationStatus Operations which follow the Azure-AsyncOperation flow

## 1.3.0-beta.2 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.3.0-beta.1 (2024-09-09)

### Features Added

- Upgraded api-version tag from 'package-2022-08' to 'package-preview-2023-03'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2d973fccf9f28681a481e9760fa12b2334216e21/specification/apimanagement/resource-manager/readme.md.
    - Added supportablity for SkuV2 CRUD operations.

### Other Changes

- Upgraded Azure.Core from 1.40.0 to 1.42.0
- Upgraded Azure.ResourceManager from 1.12.0 to 1.13.0

## 1.2.0 (2024-07-05)

### Features Added

- Upgraded api-version tag from 'package-2021-08' to 'package-2022-08'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2d973fccf9f28681a481e9760fa12b2334216e21/specification/apimanagement/resource-manager/readme.md.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Bugs Fixed

- Fixed bugs caused by applying to the lastest 'require url' for opeartion_Id_:ContentType_CreateOrUpdate and ContentItem_CreateOrUpdate in apimcontenttypes.json

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.40.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.2.0-beta.1 (2024-04-22)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Bugs Fixed

- Fixed [a bug](https://github.com/Azure/azure-sdk-for-net/issues/38076) by changing the way how `BackendResponseCode` is serialized and deserialized.
- Fixed [a bug](https://github.com/Azure/azure-sdk-for-net/issues/42865) by by changing `TermsOfServiceUri` and `ServiceUri` to string

## 1.1.0 (2023-11-27)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Bugs Fixed

- Added property `PrivateUriString` instead of `PrivateUri` in ApiRevisionContract to fix Uri deserialization issue.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-25)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-15)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-29)

This release is the first stable release of the Api Management Management library.

### Breaking Changes

- Changed the type of parameter `ifMatch` from `string` to `ETag`.
- Marked `ApiManagementContentItem` and `ApiManagementContentType` from resource to non-resource.
- Changed the return type of methods `CreateGroupUser` and `GetGroupUsers` from `ApiManagementUserResource` to `ApiManagementGroupUserData`.
- Changed the return type of methods `CreateOrUpdateGatewayApi` and `GetGatewayApisByService` from `ApiResource` to `GatewayApiData`.
- Changed the return type of methods `CreateOrUpdateProductApi` and `GetProductApis` from `ApiResource` to `ProductApiData`.
- Changed the return type of methods `CreateOrUpdateProductGroup` and `GetProductGroups` from `ApiManagementGroupResource` to `ProductGroupData`.
- Renamed `ExpiresOn` to `ExpireOn`.
- Renamed method `GetProductSubscriptions` to `GetAllProductSubscriptionData`.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `ApiManagement` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ApiManagement` to `Azure.ResourceManager.ApiManagement`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

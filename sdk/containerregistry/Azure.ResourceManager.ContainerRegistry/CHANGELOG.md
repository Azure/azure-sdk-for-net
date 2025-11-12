# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0 (2025-11-05)

### Features Added

- Upgraded api-version to 2025-11-01.

## 1.3.1 (2025-08-11)

### Features Added

- Make `Azure.ResourceManager.ContainerRegistry` AOT-compatible

## 1.3.0 (2025-04-22)

### Features Added

- Upgraded api-version tag from `package-2022-12` to `package-2025-04`. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/a55917cb512540bc3d0aec760d4e28712c3a4ae0/specification/containerregistry/resource-manager/readme.md.
- Added new classes and methods for the following features
    - Connected Registry
    - Artifact Cache

## 1.3.0-beta.3 (2025-04-10)

### Features Added

- Upgraded api-version tag from 'package-2024-11-preview' to 'package-2025-03-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/cb262725d128f6dfec4622cca03bc9e04e2d0f1f/specification/containerregistry/resource-manager/readme.md.
- Added new struct `RoleAssignmentMode`.
- Added new class `SourceRegistryCredentials`.
- Added new attribute `RoleAssignmentMode` in `ContainerRegistryData` and `ContainerRegistryPatch`.
- Added new attribute `SourceRegistry` in `ContainerRegistryCredentials`.
- Added the following methods to `ContainerRegistryResource` with new signature:
    - `ScheduleRun`
    - `ScheduleRunAsync`
- Added the following methods to `ContainerRegistryRunResource` with new signature:
    - `Cancel`
    - `CancelAsync`
    - `Update`
    - `UpdateAsync`
- Added the following methods to `ContainerRegistryTaskResource` with new signature:
    - `Update`
    - `UpdateAsync`

## 1.3.0-beta.2 (2025-01-24)

### Features Added

- Upgraded api-version tag from 'package-2023-01-preview' to 'package-2024-11-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/0a27976a58c16279e827bda36004d1b74b3d922a/specification/containerregistry/resource-manager/readme.md.

## 1.3.0-beta.1 (2024-10-15)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.1 (2024-04-29)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.2.0 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.1 (2023-05-29)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-02-15)

### Features Added

- Added support for new resources of `ContainerRegistryToken` and `ScopeMap`.
- Added `GenerateCredentials` methods for `ContainerRegistryResource`.

### Other Changes

- Upgraded container registry API version to `2022-12-01`.
- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0-beta.3 (2022-10-21)

### Bugs Fixed

- Deprecate `RegistryUri` property and replace it with `RegistryAddress` in `ContainerRegistryImportSource`.

## 1.0.2 (2022-10-21)

### Bug Fixes

- Deprecate `RegistryUri` property and replace it with `RegistryAddress` in `ContainerRegistryImportSource`.

## 1.1.0-beta.2 (2022-09-14)

### Breaking Changes

Modified the following classes to abstract classes and changed their constructors from public to protected:
- `ContainerRegistryRunContent`
- `ContainerRegistryTaskStepProperties`
- `ContainerRegistryTaskStepUpdateContent`

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.1 (2022-09-13)

### Breaking Changes

Modified the following classes to abstract classes and changed their constructors from public to protected:
- `ContainerRegistryRunContent`
- `ContainerRegistryTaskStepProperties`
- `ContainerRegistryTaskStepUpdateContent`

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.1.0-beta.1 (2022-08-26)

### Features Added

- Added support for new resources of ConnectedRegistry, ImportPipeline, ExportPipeline, ContainerRegistryPipelineRun, ContainerRegistryToken and ScopeMap.
- Added GenerateCredentials methods for ContainerRegistryResource.

## 1.0.0 (2022-08-12)

### Breaking Changes

- General renaming and formatting due to requirements of .NET Azure SDK guidelines.

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ContainerRegistry` to `Azure.ResourceManager.ContainerRegistry`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

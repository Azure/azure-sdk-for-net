# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).


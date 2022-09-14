# Release History

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

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

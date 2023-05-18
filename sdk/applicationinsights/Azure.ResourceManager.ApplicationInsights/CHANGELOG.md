# Release History

## 1.0.0-beta.3 (2023-05-23)

### Breaking Changes

- Removed method 'Response<ComponentLinkedStorageAccountResource> GetComponentLinkedStorageAccount(ResourceGroupResource resourceGroupResource, String resourceName, StorageType storageType, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ApplicationInsightsExtensions
- Removed method 'Task<Response<ComponentLinkedStorageAccountResource>> GetComponentLinkedStorageAccountAsync(ResourceGroupResource resourceGroupResource, String resourceName, StorageType storageType, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ApplicationInsightsExtensions
- Removed method 'ComponentLinkedStorageAccountCollection GetComponentLinkedStorageAccounts(ResourceGroupResource resourceGroupResource)' in type Azure.ResourceManager.ApplicationInsights.ApplicationInsightsExtensions

### Other Changes

- Upgraded api-version tag from 'package-2022-07-27-only' to 'package-2022-12-09-only'. Tag detail available at C:\git\azure-rest-api-specs\specification\applicationinsights\resource-manager\readme.md
- Upgraded Azure.Core from 1.28.0 to 1.32.0
- Upgraded Azure.ResourceManager from 1.4.0 to 1.5.0
- Obsoleted method 'ArmOperation<ComponentLinkedStorageAccountResource> CreateOrUpdate(WaitUntil waitUntil, String resourceName, StorageType storageType, ComponentLinkedStorageAccountData data, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection
- Obsoleted method 'Task<ArmOperation<ComponentLinkedStorageAccountResource>> CreateOrUpdateAsync(WaitUntil waitUntil, String resourceName, StorageType storageType, ComponentLinkedStorageAccountData data, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection
- Obsoleted method 'Response<Boolean> Exists(String resourceName, StorageType storageType, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection
- Obsoleted method 'Task<Response<Boolean>> ExistsAsync(String resourceName, StorageType storageType, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection
- Obsoleted method 'Response<ComponentLinkedStorageAccountResource> Get(String resourceName, StorageType storageType, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection
- Obsoleted method 'Task<Response<ComponentLinkedStorageAccountResource>> GetAsync(String resourceName, StorageType storageType, CancellationToken cancellationToken)' in type Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection

## 1.0.0-beta.2 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.1 (2022-09-14)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ApplicationInsights` to `Azure.ResourceManager.ApplicationInsights`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
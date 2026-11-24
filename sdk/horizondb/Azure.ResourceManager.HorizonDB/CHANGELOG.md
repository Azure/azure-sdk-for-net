# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

- Upgraded Microsoft.HorizonDb from 2026-05-01-preview to 2026-10-01-preview

### Breaking Changes

The 2026-10-01-preview service contract changes several APIs from beta.2. When migrating:

- Replace `HorizonDBReplicaResource`, `HorizonDBReplicaCollection`, and `HorizonDBReplicaData` with `HorizonDBNodeResource`, `HorizonDBNodeCollection`, and `HorizonDBNodeData`. Use the pool's `GetHorizonDBNodes()` accessor instead of `GetHorizonDBReplicas()`.
- On `HorizonDBClusterProperties`, replace `Version` with the extensible `PostgreSqlVersion` value, `CreateMode` with `CreationMode`, `PointInTimeUtcOn` with `PointInTimeOn`, and `SourceClusterResourceId` with `CreationSourceClusterResourceId`.
- Configure compute on the pool using `HorizonDBPoolProperties.ComputeModel` rather than the cluster's previous `ComputeModel` property. Cluster creation and pool creation are separate operations.
- Replace cluster `AuthConfig` and administrator-login configuration with the cluster's `GetMicrosoftEntraAuthentication()` and `GetHorizonDBPasswordAuthentication()` singleton resources.
- For `HorizonDBClusterData.Identity`, `HorizonDBClusterPatch.Identity`, and the corresponding model-factory arguments, replace `Azure.ResourceManager.Models.ManagedServiceIdentity` with `HorizonDBClusterManagedServiceIdentity`.
  - Replace the identity's `ManagedServiceIdentityType` property with `Type`, using `HorizonDBClusterIdentityType.UserAssigned` or `HorizonDBClusterIdentityType.None`.
  - The `UserAssignedIdentities` dictionary now uses full resource-ID strings as keys instead of `ResourceIdentifier` keys. Convert existing keys with `ToString()` when copying assignments.
  - Omitting the entire identity property preserves existing assignments. When `UserAssignedIdentities` is supplied, PUT replaces the complete set and PATCH merges entries; a null PATCH entry removes that identity. Setting `Type` to `None` clears all assignments, but an identity referenced by a change data capture identity assignment cannot be removed until that referencing assignment is deleted.

Firewall-rule access is unchanged: continue using `HorizonDBPoolResource.GetHorizonDBFirewallRules()`.

### Bugs Fixed

- Corrected regional capability resource identifiers. Use `subscription.GetHorizonDBCapability(location)` with an explicit `AzureLocation`; the retained parameterless overload now throws an explanatory `InvalidOperationException` instead of returning an invalid resource identifier.
- Corrected authentication listing to honor the authentication resource's API-version override independently of the cluster's override.
- Fixed null handling for flattened patch properties and the cluster's designated-pool getter.
- Corrected the newly introduced change data capture configuration and destination patch members to `DesiredState`, and the Microsoft Entra authentication patch member to `State`, without changing their JSON contracts.
- Exposed the compute-capability discriminator as a publicly readable property, including unknown service values.

### Other Changes

- Upgraded Azure.Core from 1.62.0 to 1.64.0
- Kept `ChangeDataCaptureConfigurationProperties.LogicalStreamId` as `string` to preserve its existing property and model-factory signatures. The service-generated identifier is returned unchanged; applications that require a GUID can use `Guid.TryParse`.

## 1.0.0-beta.2 (2026-08-27)

### Features Added

Upgraded api-verion to 2026-05-01-preview.

## 1.0.0-beta.1 (2026-06-15)

### Features Added

- Initial release of the Azure HorizonDB management library for .NET.
- Support for managing HorizonDB clusters.
- Support for managing HorizonDB pools.
- Support for managing HorizonDB pool replicas.
- Support for managing HorizonDB pool firewall rules.

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

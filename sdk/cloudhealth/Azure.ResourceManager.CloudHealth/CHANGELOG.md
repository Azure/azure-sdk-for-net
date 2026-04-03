# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Added support for the `HealthModelRelationship` resource type (`Microsoft.CloudHealth/healthmodels/relationships`), which represents a directed edge (parent–child relationship) between two entities in a health model.
  - `HealthModelRelationshipResource` — get, create/update, and delete individual relationships.
  - `HealthModelRelationshipCollection` — list and enumerate all relationships under a health model.
  - `HealthModelRelationshipData` / `HealthModelRelationshipProperties` — data model for relationship resources, including `ParentEntityName`, `ChildEntityName`, `DisplayName`, `Labels`, `DiscoveredBy`, and `DeletedOn`.
  - `DiscoveryRuleRelationshipDiscoveryBehavior` — enum (`Enabled` / `Disabled`) that controls whether a discovery rule automatically discovers relationships.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2025-06-20)

### Features Added

-   Initial SDK release for 'Microsoft.CloudHealth' resource provider/namespace.

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

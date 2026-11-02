# Release History

## 1.0.0 (2026-10-19)

This is the first stable release of the Relationships management client library.

### Features Added

- Updated the service API version to `2026-08-01`.
- Added APIs for listing `Contains` relationships at resource group and subscription scopes.
- Added resource and collection APIs for managing `DependencyOf` relationships scoped to a service group.
- Added pageable enumeration for `DependencyOf` and service group member relationship collections.

### Breaking Changes

- Corrected the source and target semantics of `ServiceGroupMemberRelationshipProperties`. The constructor now accepts `sourceId`, `SourceId` is settable, `TargetId` is read-only, and `SourceTenant` replaces `TargetTenant`.

### Bugs Fixed

- Fixed relationship collection paging to handle relative continuation tokens and propagate cancellation tokens during async enumeration.
- Fixed `Contains` relationship operations to honor configured API version overrides.

## 1.0.0-beta.1 (2026-04-03)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

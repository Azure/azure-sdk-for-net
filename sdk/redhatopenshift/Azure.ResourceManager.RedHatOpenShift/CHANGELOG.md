# Release History

## 1.0.0-beta.2 (Unreleased)

### Breaking Changes

- Migrated SDK code generation from AutoRest/Swagger to TypeSpec. Notable API surface changes:
  - Resource and collection types `OpenShiftPlatformWorkloadIdentityRoleSetResource`/`OpenShiftPlatformWorkloadIdentityRoleSetCollection` were renamed to `PlatformWorkloadIdentityRoleSetResource`/`PlatformWorkloadIdentityRoleSetCollection` to align with the resource model name. The corresponding `MockableRedHatOpenShiftSubscriptionResource` and `RedHatOpenShiftExtensions` accessor methods were renamed accordingly.
  - URL-typed properties were renamed to use the `Uri` suffix, e.g. `OpenShiftClusterData.ConsoleUrl` → `ConsoleUri`, `OpenShiftApiServerProfile.Url` → `Uri`.
  - `OpenShiftLoadBalancerProfile.EffectiveOutboundIPs` was renamed to `EffectiveOutboundIps` and now uses a dedicated `EffectiveOutboundIP` model instead of `Azure.ResourceManager.Resources.Models.SubResource`.
  - `OpenShiftFipsValidatedModule` was renamed to `OpenShiftFipsValidatedModules` to match the underlying enum.
  - Read-only resources (`OpenShiftVersionData`, `PlatformWorkloadIdentityRoleSetData`, `OpenShiftPlatformWorkloadIdentityRole`) now have `internal` constructors and read-only properties to reflect their server-only nature.

## 1.0.0-beta.1 (2026-04-01)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides all core capabilities of Azure Red Hat OpenShift's 2025-07-25 API version.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

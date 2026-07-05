# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0 (2026-06-17)

### Features Added

- Upgraded API version to 2026-07-01.
- Added `SharedLimitCapResource`, `SharedLimitCapCollection`, and `SharedLimitCapData` for managing shared compute limit cap configurations per VM family. The resource is scoped per region (`/locations/{location}/sharedLimitCaps/{vmFamilyName}`).
- Added `MemberCapOverrideResource`, `MemberCapOverrideCollection`, and `MemberCapOverrideData` for managing per-member subscription cap overrides under a `SharedLimitCap`.
- Added `SetMemberCapOverrides` action on `SharedLimitCapResource` (with `ComputeLimitSetMemberCapOverridesContent`) for replacing the full set of per-member cap overrides in a single call.

## 1.1.0 (2026-06-04)

### Features Added

- Upgraded API version to 2026-06-01.
- Added `ComputeLimitFeatureEnableContent` and an optional `content` parameter to `ComputeLimitFeatureResource.Enable` and `EnableAsync` for passing a Service Tree ID when enabling a feature.

## 1.0.0 (2026-04-30)

### Features Added

- Upgraded API version to 2026-04-30.
- Added `ComputeLimitVmFamilyResource`, `ComputeLimitVmFamilyCollection`, and `ComputeLimitVmFamilyData` for managing VM family resources.
- Added `Disable` operation on `ComputeLimitFeatureResource`.

## 1.0.0-beta.1 (2025-11-21)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

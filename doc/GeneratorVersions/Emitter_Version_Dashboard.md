# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-10-13 18:27:39 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261012.3)
  └─ @azure-typespec/http-client-csharp (alpha.20261012.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261013.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261013.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261013.2 | 1.0.0-alpha.20261012.3 | [da255e1](https://github.com/microsoft/typespec/commit/da255e1e1fca6e8eff520f07f3b8069422f3806f) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261009.2 | 1.0.0-alpha.20261012.4 | [19a04be](https://github.com/Azure/azure-sdk-for-net/commit/19a04be5960eeb9ee241a45ea8afb558aae945fb) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20261012.2 | 1.0.0-alpha.20261013.1 | [b1535bd](https://github.com/Azure/azure-sdk-for-net/commit/b1535bd11142a55ea8632c640dd0a0da5d413c4c) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

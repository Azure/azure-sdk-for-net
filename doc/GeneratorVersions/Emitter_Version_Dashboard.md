# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-10-12 20:22:44 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261011.1)
  └─ @azure-typespec/http-client-csharp (alpha.20261012.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261012.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261011.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261012.3 | 1.0.0-alpha.20261011.1 | [d2730ee](https://github.com/microsoft/typespec/commit/d2730eeb9f79966acf60ca469fe214870f44bd0c) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261009.2 | 1.0.0-alpha.20261012.2 | [19a04be](https://github.com/Azure/azure-sdk-for-net/commit/19a04be5960eeb9ee241a45ea8afb558aae945fb) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260929.3 | 1.0.0-alpha.20261012.1 | [0169bf3](https://github.com/Azure/azure-sdk-for-net/commit/0169bf3b837db6490f96e1fad2374e309df8e67c) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

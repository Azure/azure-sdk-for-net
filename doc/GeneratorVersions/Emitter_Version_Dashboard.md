# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-10-26 22:09:05 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261023.3)
  └─ @azure-typespec/http-client-csharp (alpha.20261026.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261026.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261013.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261026.3 | 1.0.0-alpha.20261023.3 | [dd71649](https://github.com/microsoft/typespec/commit/dd71649221df0d5d4422d4bddbf7793f8f4c62b4) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261023.4 | 1.0.0-alpha.20261026.2 | [069157e](https://github.com/Azure/azure-sdk-for-net/commit/069157e5b18b91081781e39a0a106e264c0c945c) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20261012.2 | 1.0.0-alpha.20261026.2 | [b1535bd](https://github.com/Azure/azure-sdk-for-net/commit/b1535bd11142a55ea8632c640dd0a0da5d413c4c) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

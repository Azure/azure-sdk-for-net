# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-05 18:24:05 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260805.2)
  └─ @azure-typespec/http-client-csharp (alpha.20260805.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260804.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260804.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260805.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260805.2) | [1.0.0-alpha.20260805.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260805.2) | [3aa5d51](https://github.com/microsoft/typespec/commit/3aa5d51fc0eabf2ed4333d4b53c94f23c8a122d2) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260728.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260728.2) | [1.0.0-alpha.20260805.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260805.2) | [d2016a6](https://github.com/Azure/azure-sdk-for-net/commit/d2016a68de75c7813168f97542a2737a8982b4f2) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260727.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260727.4) | [1.0.0-alpha.20260804.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260804.2) | [85a0497](https://github.com/Azure/azure-sdk-for-net/commit/85a0497f98e00224fccb972ec5c03440c7f79441) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

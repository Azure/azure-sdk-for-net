# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-25 01:47:20 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260824.4)
  └─ @azure-typespec/http-client-csharp (alpha.20260824.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260824.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260824.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260824.4](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260824.4) | [1.0.0-alpha.20260824.4](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260824.4) | [58bf2c4](https://github.com/microsoft/typespec/commit/58bf2c4b2dba2524455ab4dde9980bd728bb2926) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260824.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260824.2) | [1.0.0-alpha.20260824.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260824.2) | [a7515de](https://github.com/Azure/azure-sdk-for-net/commit/a7515de6ddd42c44ce16f805aa7037e783d3f3dc) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260820.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260820.2) | [1.0.0-alpha.20260824.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260824.2) | [d494ea1](https://github.com/Azure/azure-sdk-for-net/commit/d494ea1320e5162efe56bc1cf93ab4c89e7fec63) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

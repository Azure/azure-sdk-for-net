# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-17 21:02:52 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260817.6)
  └─ @azure-typespec/http-client-csharp (alpha.20260817.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260817.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260817.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260817.6 | 1.0.0-alpha.20260817.6 | [1a7f2f4](https://github.com/microsoft/typespec/commit/1a7f2f4d05e819a8312528e8d207af2f90597d63) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260812.4 | 1.0.0-alpha.20260817.4 | [100eace](https://github.com/Azure/azure-sdk-for-net/commit/100eaceb37db1fce20f5db3a34aca2d8ec7de7d7) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260812.1 | 1.0.0-alpha.20260817.1 | [ad23c92](https://github.com/Azure/azure-sdk-for-net/commit/ad23c928f50a12ca01629266a2d8d4ad3798dcad) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

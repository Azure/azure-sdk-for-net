# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-18 01:59:22 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260817.7)
  └─ @azure-typespec/http-client-csharp (alpha.20260817.5)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260817.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260817.3)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260817.7](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260817.7) | [1.0.0-alpha.20260817.7](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260817.7) | [1a7f2f4](https://github.com/microsoft/typespec/commit/1a7f2f4d05e819a8312528e8d207af2f90597d63) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260817.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260817.5) | [1.0.0-alpha.20260817.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260817.5) | [1521b0f](https://github.com/Azure/azure-sdk-for-net/commit/1521b0f232793eb35ad8ce96b23f0ea889759d3e) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260812.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260812.1) | [1.0.0-alpha.20260817.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260817.1) | [ad23c92](https://github.com/Azure/azure-sdk-for-net/commit/ad23c928f50a12ca01629266a2d8d4ad3798dcad) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

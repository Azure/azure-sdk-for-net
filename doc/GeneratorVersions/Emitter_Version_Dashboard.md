# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-11 03:47:59 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260810.10)
  └─ @azure-typespec/http-client-csharp (alpha.20260810.6)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260810.3)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260810.5)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260810.10](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260810.10) | [1.0.0-alpha.20260810.10](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260810.10) | [825454a](https://github.com/microsoft/typespec/commit/825454ae88d4c72768233749267fa14fd0d0f75f) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260803.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260803.3) | [1.0.0-alpha.20260810.6](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260810.6) | [bc1f707](https://github.com/Azure/azure-sdk-for-net/commit/bc1f70737abffc645abb8cb3e90815b2c8e990df) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260729.1 | 1.0.0-alpha.20260810.3 | [34e4817](https://github.com/Azure/azure-sdk-for-net/commit/34e4817e0a0dd6e2dd562cfe56de45bddc13433b) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

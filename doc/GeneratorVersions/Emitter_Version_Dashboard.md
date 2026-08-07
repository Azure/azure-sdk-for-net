# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-07 07:04:26 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260806.6)
  └─ @azure-typespec/http-client-csharp (alpha.20260806.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260805.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260805.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260806.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260806.5) | [1.0.0-alpha.20260806.6](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260806.6) | [205ceec](https://github.com/microsoft/typespec/commit/205ceeca7a7c0c1b3876650167c172b069574bf5) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260805.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260805.3) | [1.0.0-alpha.20260806.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260806.3) | [1b63f15](https://github.com/Azure/azure-sdk-for-net/commit/1b63f151ee8503720199dac4a8caa974322bfa6a) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260729.1 | [1.0.0-alpha.20260805.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260805.1) | [34e4817](https://github.com/Azure/azure-sdk-for-net/commit/34e4817e0a0dd6e2dd562cfe56de45bddc13433b) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

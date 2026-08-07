# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-07 13:39:25 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260807.3)
  └─ @azure-typespec/http-client-csharp (alpha.20260807.1)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260807.3)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260805.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260807.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260807.3) | [1.0.0-alpha.20260807.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260807.3) | [02ef0c1](https://github.com/microsoft/typespec/commit/02ef0c13ad26a286d6e403c42d6098eee44e65a0) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260729.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260729.2) | 1.0.0-alpha.20260807.1 | [fef8881](https://github.com/Azure/azure-sdk-for-net/commit/fef888180824df20cc976bc086008ec109f05844) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260729.1 | 1.0.0-alpha.20260807.3 | [34e4817](https://github.com/Azure/azure-sdk-for-net/commit/34e4817e0a0dd6e2dd562cfe56de45bddc13433b) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

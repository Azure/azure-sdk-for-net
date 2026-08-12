# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-12 17:39:18 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260812.4)
  └─ @azure-typespec/http-client-csharp (alpha.20260812.1)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260811.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260811.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260812.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260812.2) | [1.0.0-alpha.20260812.4](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260812.4) | [d457ff7](https://github.com/microsoft/typespec/commit/d457ff7fae3032837fa62b4309cdb4c4ba531e57) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260810.7](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260810.7) | 1.0.0-alpha.20260812.1 | [bda3ab5](https://github.com/Azure/azure-sdk-for-net/commit/bda3ab50d4cc40578c94678d8eee29d0b0eb5bcc) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260729.1 | [1.0.0-alpha.20260811.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260811.2) | [34e4817](https://github.com/Azure/azure-sdk-for-net/commit/34e4817e0a0dd6e2dd562cfe56de45bddc13433b) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

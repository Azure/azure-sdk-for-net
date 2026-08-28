# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-28 16:56:08 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260827.10)
  └─ @azure-typespec/http-client-csharp (alpha.20260825.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260827.4)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260826.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260828.3 | 1.0.0-alpha.20260827.10 | [0afccbc](https://github.com/microsoft/typespec/commit/0afccbc4930e05472e8894e509f5d9ea6ef1e3ac) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260825.4 | 1.0.0-alpha.20260825.4 | [6327049](https://github.com/Azure/azure-sdk-for-net/commit/6327049a2b5121156bc3ebcc3f110d0a0c5231e6) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260820.2 | 1.0.0-alpha.20260827.4 | [d84ccb7](https://github.com/Azure/azure-sdk-for-net/commit/d84ccb7c940cba3ac9d146e53732f3d89c39f144) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

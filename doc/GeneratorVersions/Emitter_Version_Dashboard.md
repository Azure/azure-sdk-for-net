# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-09-03 04:52:07 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260902.6)
  └─ @azure-typespec/http-client-csharp (alpha.20260902.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260902.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260902.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260902.4 | 1.0.0-alpha.20260902.6 | [85a4285](https://github.com/microsoft/typespec/commit/85a42853a731f71755e152f7552334ab8f89a6c7) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260828.4 | 1.0.0-alpha.20260902.4 | [0448cad](https://github.com/Azure/azure-sdk-for-net/commit/0448cad84f12ada9dca89fba4a95a1595e4c86a2) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260820.2 | 1.0.0-alpha.20260902.2 | [d84ccb7](https://github.com/Azure/azure-sdk-for-net/commit/d84ccb7c940cba3ac9d146e53732f3d89c39f144) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

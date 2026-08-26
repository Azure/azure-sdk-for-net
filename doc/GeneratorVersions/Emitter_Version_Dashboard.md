# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-25 23:58:37 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260825.9)
  └─ @azure-typespec/http-client-csharp (alpha.20260825.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260825.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260824.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260825.9 | 1.0.0-alpha.20260825.9 | [210f84c](https://github.com/microsoft/typespec/commit/210f84c0dee6cfb8226ce95700562c9bf0922822) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260819.3 | 1.0.0-alpha.20260825.3 | [b77d431](https://github.com/Azure/azure-sdk-for-net/commit/b77d43115c7ebe317d6e736c77cd81ae9a735ee1) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260820.2 | 1.0.0-alpha.20260825.1 | [d84ccb7](https://github.com/Azure/azure-sdk-for-net/commit/d84ccb7c940cba3ac9d146e53732f3d89c39f144) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

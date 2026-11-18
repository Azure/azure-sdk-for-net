# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-11-16 22:46:39 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261116.2)
  └─ @azure-typespec/http-client-csharp (alpha.20261116.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261112.3)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261112.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261116.3 | 1.0.0-alpha.20261116.2 | [a7d3882](https://github.com/microsoft/typespec/commit/a7d388236bc5663a7f225e9ef839c754515a29fc) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261115.1 | 1.0.0-alpha.20261116.4 | [1779d38](https://github.com/Azure/azure-sdk-for-net/commit/1779d38fb710ff98f3c6742c2bc2954991dfac61) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20261026.6 | 1.0.0-alpha.20261112.3 | [6a07a90](https://github.com/Azure/azure-sdk-for-net/commit/6a07a90a3a2b9871d5ebe94577e92687397e86a3) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

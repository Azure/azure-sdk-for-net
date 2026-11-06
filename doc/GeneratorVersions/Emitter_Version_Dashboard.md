# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-11-06 01:11:30 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261105.3)
  └─ @azure-typespec/http-client-csharp (alpha.20261104.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261105.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261103.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261105.5 | 1.0.0-alpha.20261105.3 | [6fa1664](https://github.com/microsoft/typespec/commit/6fa166417eb2943c2d637cc873f28cccbb1d5099) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261023.4 | 1.0.0-alpha.20261104.3 | [069157e](https://github.com/Azure/azure-sdk-for-net/commit/069157e5b18b91081781e39a0a106e264c0c945c) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20261026.6 | 1.0.0-alpha.20261105.1 | [6a07a90](https://github.com/Azure/azure-sdk-for-net/commit/6a07a90a3a2b9871d5ebe94577e92687397e86a3) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

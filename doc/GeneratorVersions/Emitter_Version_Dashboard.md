# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-10-29 19:24:30 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261026.4)
  └─ @azure-typespec/http-client-csharp (alpha.20261027.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261027.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261027.3)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261029.3 | 1.0.0-alpha.20261026.4 | [ecbbf0d](https://github.com/microsoft/typespec/commit/ecbbf0d27ba48ef1afb7f80c8d0781a645450012) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261023.4 | 1.0.0-alpha.20261027.4 | [069157e](https://github.com/Azure/azure-sdk-for-net/commit/069157e5b18b91081781e39a0a106e264c0c945c) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20261026.6 | 1.0.0-alpha.20261027.2 | [6a07a90](https://github.com/Azure/azure-sdk-for-net/commit/6a07a90a3a2b9871d5ebe94577e92687397e86a3) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

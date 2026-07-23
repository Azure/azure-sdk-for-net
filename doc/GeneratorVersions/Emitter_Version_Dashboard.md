# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-23 15:29:33 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260722.8)
  └─ @azure-typespec/http-client-csharp (alpha.20260722.6)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260723.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260722.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260722.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260722.8) | [1.0.0-alpha.20260722.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260722.8) | unknown |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260722.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260722.4) | [1.0.0-alpha.20260722.6](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260722.6) | [c9beb46](https://github.com/Azure/azure-sdk-for-net/commit/c9beb468266e0970f196686a8601f9f756fa697f) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260719.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260719.1) | [1.0.0-alpha.20260723.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260723.1) | [8bec971](https://github.com/Azure/azure-sdk-for-net/commit/8bec9717217b05aed52ff467f06fe5670acaf6e5) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

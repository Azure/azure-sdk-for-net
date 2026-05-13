# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-05-13 19:20:42 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260513.4)
  └─ @azure-typespec/http-client-csharp (alpha.20260513.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260512.4)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260508.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260513.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260513.2) | [1.0.0-alpha.20260513.4](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260513.4) | [1e5f02d](https://github.com/microsoft/typespec/commit/1e5f02d01d803365ff8e37701b30fe48154cf5dd) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260512.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260512.2) | [1.0.0-alpha.20260513.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260513.2) | [8f3ce8e](https://github.com/Azure/azure-sdk-for-net/commit/8f3ce8edf8e6026e459c2d262e7e0c9b3b612181) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260424.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260424.2) | [1.0.0-alpha.20260512.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260512.4) | [86e36e3](https://github.com/Azure/azure-sdk-for-net/commit/86e36e3fbc9512da615c17f793dfcb3306ec4049) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

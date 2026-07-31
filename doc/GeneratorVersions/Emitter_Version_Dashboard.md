# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-31 23:43:44 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260731.5)
  └─ @azure-typespec/http-client-csharp (alpha.20260731.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260731.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260731.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260731.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260731.5) | [1.0.0-alpha.20260731.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260731.5) | [14feb1d](https://github.com/microsoft/typespec/commit/14feb1d396d4114dc90ab39a9dcdbc8dbea9ff41) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260724.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260724.4) | [1.0.0-alpha.20260731.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260731.2) | [c2ef7c4](https://github.com/Azure/azure-sdk-for-net/commit/c2ef7c4c7c012ed55ddbf16ef868445a7a0fc712) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260723.2 | [1.0.0-alpha.20260731.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260731.1) | [5f8c877](https://github.com/Azure/azure-sdk-for-net/commit/5f8c8777e664e21ce706acd0c38eab9db261663f) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

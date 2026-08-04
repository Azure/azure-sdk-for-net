# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-03 16:46:27 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260803.6)
  └─ @azure-typespec/http-client-csharp (alpha.20260803.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260803.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260802.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260803.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260803.3) | 1.0.0-alpha.20260803.6 | [9f45579](https://github.com/microsoft/typespec/commit/9f45579ede44903dae6f43aa10dec3fd971fcff4) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260724.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260724.4) | [1.0.0-alpha.20260803.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260803.2) | [c2ef7c4](https://github.com/Azure/azure-sdk-for-net/commit/c2ef7c4c7c012ed55ddbf16ef868445a7a0fc712) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260724.4 | 1.0.0-alpha.20260803.1 | [7eea224](https://github.com/Azure/azure-sdk-for-net/commit/7eea224c82c2bd391235abb1a60c0101ecd009ca) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

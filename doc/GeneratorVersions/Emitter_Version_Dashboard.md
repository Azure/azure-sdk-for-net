# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-27 19:39:54 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260727.7)
  └─ @azure-typespec/http-client-csharp (alpha.20260727.1)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260727.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260727.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260727.7](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260727.7) | [1.0.0-alpha.20260727.7](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260727.7) | [5e85c23](https://github.com/microsoft/typespec/commit/5e85c237e0937f0745eb05dcd94ccee464dfa330) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260724.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260724.4) | 1.0.0-alpha.20260727.1 | [c2ef7c4](https://github.com/Azure/azure-sdk-for-net/commit/c2ef7c4c7c012ed55ddbf16ef868445a7a0fc712) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260720.6](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260720.6) | [1.0.0-alpha.20260727.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260727.2) | [0343ee1](https://github.com/Azure/azure-sdk-for-net/commit/0343ee14f1afa35fb37c4f9d558a498bb1239fa6) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

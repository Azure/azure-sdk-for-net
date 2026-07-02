# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-02 01:06:29 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260701.8)
  └─ @azure-typespec/http-client-csharp (alpha.20260701.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260701.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260701.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260701.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260701.8) | [1.0.0-alpha.20260701.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260701.8) | [3e10b83](https://github.com/microsoft/typespec/commit/3e10b8376f3a20dfcd46050c712d6bc64d537b2c) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260629.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260629.2) | [1.0.0-alpha.20260701.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260701.4) | [3abfb23](https://github.com/Azure/azure-sdk-for-net/commit/3abfb237026bbc18469089f996829bf3f3911cc9) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260630.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260630.2) | [1.0.0-alpha.20260701.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260701.2) | [26b0919](https://github.com/Azure/azure-sdk-for-net/commit/26b0919efd79467de030de5d0513fbf0f130e4fc) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

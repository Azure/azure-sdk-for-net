# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-01 03:42:26 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260630.5)
  └─ @azure-typespec/http-client-csharp (alpha.20260630.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260629.4)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260630.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260630.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260630.5) | [1.0.0-alpha.20260630.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260630.5) | [a293333](https://github.com/microsoft/typespec/commit/a293333dc4055bbeae4cbcfd1ab7c5b842f04147) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260629.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260629.2) | [1.0.0-alpha.20260630.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260630.2) | [3abfb23](https://github.com/Azure/azure-sdk-for-net/commit/3abfb237026bbc18469089f996829bf3f3911cc9) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260622.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260622.1) | [1.0.0-alpha.20260629.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260629.4) | [8260a4c](https://github.com/Azure/azure-sdk-for-net/commit/8260a4c5b7601303b6d2a86141ec025d7d5bf4bd) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

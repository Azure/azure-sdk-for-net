# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-06-29 21:29:50 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260629.9)
  └─ @azure-typespec/http-client-csharp (alpha.20260626.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260629.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260625.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260629.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260629.8) | [1.0.0-alpha.20260629.9](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260629.9) | [50e2766](https://github.com/microsoft/typespec/commit/50e27663c6ddd2cdeff8d02a53a88d6c9916e4a7) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260624.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260624.5) | [1.0.0-alpha.20260626.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260626.3) | [ced8c49](https://github.com/Azure/azure-sdk-for-net/commit/ced8c49bcd35a343688c19d46af0cffa491afb8f) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260622.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260622.1) | [1.0.0-alpha.20260629.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260629.2) | [8260a4c](https://github.com/Azure/azure-sdk-for-net/commit/8260a4c5b7601303b6d2a86141ec025d7d5bf4bd) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

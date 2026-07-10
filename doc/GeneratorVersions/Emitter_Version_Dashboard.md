# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-10 02:26:52 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260709.13)
  └─ @azure-typespec/http-client-csharp (alpha.20260709.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260709.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260708.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260709.10](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260709.10) | [1.0.0-alpha.20260709.13](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260709.13) | [348d6be](https://github.com/microsoft/typespec/commit/348d6be2e56bfd7df2740142b0c629faf2bc9a01) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260709.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260709.3) | [1.0.0-alpha.20260709.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260709.3) | [f78e71f](https://github.com/Azure/azure-sdk-for-net/commit/f78e71fbfb2d3100855e3f6daffbe7c080f62273) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260707.4 | [1.0.0-alpha.20260709.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260709.2) | [a4bc486](https://github.com/Azure/azure-sdk-for-net/commit/a4bc4861b25bda05408e30756e49a4785511f308) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

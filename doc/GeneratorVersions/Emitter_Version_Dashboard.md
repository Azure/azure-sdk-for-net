# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-06-25 02:59:12 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260624.10)
  └─ @azure-typespec/http-client-csharp (alpha.20260624.5)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260624.8)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260624.5)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260624.11 | [1.0.0-alpha.20260624.10](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260624.10) | unknown |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260623.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260623.2) | [1.0.0-alpha.20260624.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260624.5) | unknown |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260622.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260622.1) | [1.0.0-alpha.20260624.8](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260624.8) | unknown |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

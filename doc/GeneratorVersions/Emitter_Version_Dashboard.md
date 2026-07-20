# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-17 22:11:27 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260717.13)
  └─ @azure-typespec/http-client-csharp (alpha.20260717.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260716.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260714.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260717.13](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260717.13) | [1.0.0-alpha.20260717.13](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260717.13) | [50f7466](https://github.com/microsoft/typespec/commit/50f74660d8e08b3022b06bd8b2dfe2da21aed51c) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260713.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260713.2) | [1.0.0-alpha.20260717.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260717.3) | [f33315a](https://github.com/Azure/azure-sdk-for-net/commit/f33315a116de6d7fdca38faaab87584274fc51cc) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260707.4 | 1.0.0-alpha.20260716.2 | [a4bc486](https://github.com/Azure/azure-sdk-for-net/commit/a4bc4861b25bda05408e30756e49a4785511f308) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

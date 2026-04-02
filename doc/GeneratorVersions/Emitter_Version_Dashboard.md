# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-04-02 01:46:12 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260401.8)
  └─ @azure-typespec/http-client-csharp (alpha.20260401.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260331.3)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260327.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260401.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260401.8) | [1.0.0-alpha.20260401.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260401.8) | [978bb9f](https://github.com/microsoft/typespec/commit/978bb9ff39ca60566affa244542abc02027a2cad) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260320.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260320.2) | [1.0.0-alpha.20260401.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260401.2) | [1312b44](https://github.com/Azure/azure-sdk-for-net/commit/1312b44074cae7a101ad057106714ed614e08429) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260322.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260322.2) | [1.0.0-alpha.20260331.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260331.3) | [e413cb9](https://github.com/Azure/azure-sdk-for-net/commit/e413cb9dfdf6460c14915fe09126ca3b39f050e2) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

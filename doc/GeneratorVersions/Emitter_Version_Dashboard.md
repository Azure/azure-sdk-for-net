# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-03-23 01:09:51 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260320.2)
  └─ @azure-typespec/http-client-csharp (alpha.20260320.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260319.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260319.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260320.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260320.2) | [1.0.0-alpha.20260320.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260320.2) | [efe6d40](https://github.com/microsoft/typespec/commit/efe6d40ce13ff67fcb272b1d5ee468820d514f5e) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260320.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260320.2) | [1.0.0-alpha.20260320.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260320.2) | [1312b44](https://github.com/Azure/azure-sdk-for-net/commit/1312b44074cae7a101ad057106714ed614e08429) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260322.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260322.2) | [1.0.0-alpha.20260322.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260322.2) | [46c72fa](https://github.com/Azure/azure-sdk-for-net/commit/46c72fadd820d9d3e8422d9d963f51abb3800e87) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

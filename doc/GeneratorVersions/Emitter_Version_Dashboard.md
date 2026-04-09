# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-04-08 22:01:26 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260408.2)
  └─ @azure-typespec/http-client-csharp (alpha.20260407.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260408.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260408.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260408.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260408.2) | [1.0.0-alpha.20260408.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260408.2) | [e5c6b09](https://github.com/microsoft/typespec/commit/e5c6b093d3c0c6cc8a1b1848d05a1a7154271405) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260403.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260403.3) | [1.0.0-alpha.20260407.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260407.2) | [f88a96e](https://github.com/Azure/azure-sdk-for-net/commit/f88a96e6903dd527e94ca0e56b8c38662cfb992c) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260406.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260406.2) | [1.0.0-alpha.20260408.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260408.1) | [876c3f7](https://github.com/Azure/azure-sdk-for-net/commit/876c3f7a90ff8ccf206a5385d9fd8816ae08390c) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

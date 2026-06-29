# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-06-29 10:18:46 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260625.6)
  └─ @azure-typespec/http-client-csharp (alpha.20260626.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260626.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260625.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260625.6](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260625.6) | [1.0.0-alpha.20260625.6](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260625.6) | [ae88584](https://github.com/microsoft/typespec/commit/ae88584634bcb847f25801051067976fa57229d2) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260629.1 | [1.0.0-alpha.20260626.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260626.3) | [05e37dc](https://github.com/Azure/azure-sdk-for-net/commit/05e37dcba77da3ca04cecf711b131bae9136cd2d) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260622.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260622.1) | [1.0.0-alpha.20260626.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260626.2) | [8260a4c](https://github.com/Azure/azure-sdk-for-net/commit/8260a4c5b7601303b6d2a86141ec025d7d5bf4bd) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-03 17:51:15 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260703.2)
  └─ @azure-typespec/http-client-csharp (alpha.20260703.1)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260703.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260702.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260703.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260703.2) | [1.0.0-alpha.20260703.2](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260703.2) | [0e735d3](https://github.com/microsoft/typespec/commit/0e735d3eb13519641f0ba37500e6b6c86fb89d86) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260701.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260701.4) | 1.0.0-alpha.20260703.1 | [cf309ca](https://github.com/Azure/azure-sdk-for-net/commit/cf309ca16aeba3ba7a448c158ed6d4935ebb32cc) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260701.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260701.2) | 1.0.0-alpha.20260703.1 | [4e26997](https://github.com/Azure/azure-sdk-for-net/commit/4e269979f41b389cc33049951d1022991a732ff8) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

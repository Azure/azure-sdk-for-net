# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-05-26 22:05:49 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260526.4)
  └─ @azure-typespec/http-client-csharp (alpha.20260526.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260524.3)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260518.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260526.5 | [1.0.0-alpha.20260526.4](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260526.4) | [c8299a5](https://github.com/microsoft/typespec/commit/c8299a553e2d7bc3fac4453e136af4e202de1fee) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260516.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260516.2) | [1.0.0-alpha.20260526.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260526.2) | [d5a14ba](https://github.com/Azure/azure-sdk-for-net/commit/d5a14ba9570471813afef260054bbef54d03524d) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260512.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260512.4) | [1.0.0-alpha.20260524.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260524.3) | [2496a0c](https://github.com/Azure/azure-sdk-for-net/commit/2496a0c8b5e95fe44e944032a073d13c6a0d9ced) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

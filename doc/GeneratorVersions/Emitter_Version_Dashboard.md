# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-05-28 18:59:36 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260528.3)
  └─ @azure-typespec/http-client-csharp (alpha.20260528.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260527.5)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260518.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260528.4 | [1.0.0-alpha.20260528.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260528.3) | [3a90abd](https://github.com/microsoft/typespec/commit/3a90abdc3d4e6c94d321bdc11025764bea05e2da) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260516.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260516.2) | [1.0.0-alpha.20260528.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260528.2) | [d5a14ba](https://github.com/Azure/azure-sdk-for-net/commit/d5a14ba9570471813afef260054bbef54d03524d) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260512.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260512.4) | [1.0.0-alpha.20260527.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260527.5) | [2496a0c](https://github.com/Azure/azure-sdk-for-net/commit/2496a0c8b5e95fe44e944032a073d13c6a0d9ced) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

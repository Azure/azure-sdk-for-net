# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-19 08:56:52 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260818.17)
  └─ @azure-typespec/http-client-csharp (alpha.20260818.5)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260818.4)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260818.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260818.17](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260818.17) | [1.0.0-alpha.20260818.17](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260818.17) | [a849fcf](https://github.com/microsoft/typespec/commit/a849fcfc965b6dc0cb8dffcb32132e71655a6b4a) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260818.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260818.5) | [1.0.0-alpha.20260818.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260818.5) | [bd494a4](https://github.com/Azure/azure-sdk-for-net/commit/bd494a4011d982eb0db5c1e8cda6b5e679149a91) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260812.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260812.1) | [1.0.0-alpha.20260818.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260818.4) | [ad23c92](https://github.com/Azure/azure-sdk-for-net/commit/ad23c928f50a12ca01629266a2d8d4ad3798dcad) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

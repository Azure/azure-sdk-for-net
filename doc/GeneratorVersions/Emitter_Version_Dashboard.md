# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-05-06 22:57:12 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260506.3)
  └─ @azure-typespec/http-client-csharp (alpha.20260504.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260506.5)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260429.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260506.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260506.3) | [1.0.0-alpha.20260506.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260506.3) | [1d5f379](https://github.com/microsoft/typespec/commit/1d5f379b826fe98b33ba5e04e3b3a1b090c9549e) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260430.1 | [1.0.0-alpha.20260504.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260504.4) | [da4a0b5](https://github.com/Azure/azure-sdk-for-net/commit/da4a0b544629af7b913ba3b305796d03f7e09ac3) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260424.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260424.2) | [1.0.0-alpha.20260506.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260506.5) | [86e36e3](https://github.com/Azure/azure-sdk-for-net/commit/86e36e3fbc9512da615c17f793dfcb3306ec4049) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

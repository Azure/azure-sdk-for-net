# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-04-29 20:02:49 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260429.3)
  └─ @azure-typespec/http-client-csharp (alpha.20260428.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260429.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260429.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260429.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260429.3) | [1.0.0-alpha.20260429.3](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260429.3) | [29f9656](https://github.com/microsoft/typespec/commit/29f96569b31402bbf40be1ccf33eab561c12beac) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260415.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260415.3) | [1.0.0-alpha.20260428.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260428.2) | [652555d](https://github.com/Azure/azure-sdk-for-net/commit/652555d044a9636401bb54afc099b0601365fade) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260424.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260424.2) | [1.0.0-alpha.20260429.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260429.2) | [86e36e3](https://github.com/Azure/azure-sdk-for-net/commit/86e36e3fbc9512da615c17f793dfcb3306ec4049) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

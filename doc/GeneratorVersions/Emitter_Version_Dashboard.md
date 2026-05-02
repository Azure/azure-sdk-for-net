# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-05-02 01:36:01 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260501.5)
  └─ @azure-typespec/http-client-csharp (alpha.20260501.5)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260429.6)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260429.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260501.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260501.5) | [1.0.0-alpha.20260501.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260501.5) | [5ed19e0](https://github.com/microsoft/typespec/commit/5ed19e0d86f01fbdcb17092248529ba310229657) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260415.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260415.3) | [1.0.0-alpha.20260501.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260501.5) | [652555d](https://github.com/Azure/azure-sdk-for-net/commit/652555d044a9636401bb54afc099b0601365fade) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260424.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260424.2) | [1.0.0-alpha.20260429.6](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260429.6) | [86e36e3](https://github.com/Azure/azure-sdk-for-net/commit/86e36e3fbc9512da615c17f793dfcb3306ec4049) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

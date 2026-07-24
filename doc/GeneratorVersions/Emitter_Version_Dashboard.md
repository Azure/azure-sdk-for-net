# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-07-24 00:54:08 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260723.5)
  └─ @azure-typespec/http-client-csharp (alpha.20260723.2)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260723.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260722.2)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260723.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260723.5) | [1.0.0-alpha.20260723.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260723.5) | [4a6c443](https://github.com/microsoft/typespec/commit/4a6c4437b037f988bab722eb7d56c44f76d2d703) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260722.5](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260722.5) | [1.0.0-alpha.20260723.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260723.2) | [ec1920c](https://github.com/Azure/azure-sdk-for-net/commit/ec1920c00285a7161c719d8874321550dd1ab090) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260719.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260719.1) | [1.0.0-alpha.20260723.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260723.1) | [8bec971](https://github.com/Azure/azure-sdk-for-net/commit/8bec9717217b05aed52ff467f06fe5670acaf6e5) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

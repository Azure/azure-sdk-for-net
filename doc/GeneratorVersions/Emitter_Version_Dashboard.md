# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-06-10 22:19:46 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260610.5)
  └─ @azure-typespec/http-client-csharp (alpha.20260609.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260610.2)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260608.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260610.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260610.5) | [1.0.0-alpha.20260610.5](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260610.5) | [3cb9222](https://github.com/microsoft/typespec/commit/3cb92221f79db70b44534acd075407926d5ad087) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260609.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260609.4) | [1.0.0-alpha.20260609.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260609.4) | [452547f](https://github.com/Azure/azure-sdk-for-net/commit/452547fe8b672792697942ed3d271ecc4b186010) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260601.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260601.2) | [1.0.0-alpha.20260610.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260610.2) | [fe53ea6](https://github.com/Azure/azure-sdk-for-net/commit/fe53ea60912a2bee98da88441f42eaca872880df) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

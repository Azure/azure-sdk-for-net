# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-04-22 05:49:48 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260421.4)
  └─ @azure-typespec/http-client-csharp (alpha.20260420.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260421.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260410.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260420.6](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260420.6) | [1.0.0-alpha.20260421.4](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260421.4) | [565e025](https://github.com/microsoft/typespec/commit/565e025f7150929f1c3e3998ffad46ca55bd7092) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260415.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260415.3) | [1.0.0-alpha.20260420.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260420.3) | [652555d](https://github.com/Azure/azure-sdk-for-net/commit/652555d044a9636401bb54afc099b0601365fade) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260421.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260421.1) | [1.0.0-alpha.20260421.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260421.1) | [b5e931a](https://github.com/Azure/azure-sdk-for-net/commit/b5e931a2589ea09ec1edad377740f13d587e1f7b) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

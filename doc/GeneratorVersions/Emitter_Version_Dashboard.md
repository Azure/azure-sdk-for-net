# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-04-10 20:28:25 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260410.8)
  └─ @azure-typespec/http-client-csharp (alpha.20260409.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260410.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260410.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260410.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260410.8) | [1.0.0-alpha.20260410.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260410.8) | [471ca7e](https://github.com/microsoft/typespec/commit/471ca7ea193853c87838f75bcbe87a4c06648c38) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260408.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260408.3) | [1.0.0-alpha.20260409.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260409.3) | [ce470ec](https://github.com/Azure/azure-sdk-for-net/commit/ce470ec768a0ca38716159ec639b49e0756976ab) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260408.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260408.3) | [1.0.0-alpha.20260410.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260410.1) | [9c2425a](https://github.com/Azure/azure-sdk-for-net/commit/9c2425a3ba733f6a31ee7fe4209baa4db3322e76) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

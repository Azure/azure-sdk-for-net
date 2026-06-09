# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-06-09 00:17:19 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260608.8)
  └─ @azure-typespec/http-client-csharp (alpha.20260608.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260607.3)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260608.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260608.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260608.8) | [1.0.0-alpha.20260608.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260608.8) | [5774655](https://github.com/microsoft/typespec/commit/5774655e1eecfad776cfe62d9d41c7ac1f46e133) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260516.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260516.2) | [1.0.0-alpha.20260608.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260608.3) | [d5a14ba](https://github.com/Azure/azure-sdk-for-net/commit/d5a14ba9570471813afef260054bbef54d03524d) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260601.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260601.2) | [1.0.0-alpha.20260607.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260607.3) | [fe53ea6](https://github.com/Azure/azure-sdk-for-net/commit/fe53ea60912a2bee98da88441f42eaca872880df) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

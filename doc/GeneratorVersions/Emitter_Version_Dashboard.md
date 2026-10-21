# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-10-20 16:53:11 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20261019.5)
  └─ @azure-typespec/http-client-csharp (alpha.20261015.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20261019.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20261013.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20261019.5 | 1.0.0-alpha.20261019.5 | [517cf64](https://github.com/microsoft/typespec/commit/517cf6479f971a55585350eb1196c8b7d88262ab) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20261014.4 | 1.0.0-alpha.20261015.3 | [4bcff5f](https://github.com/Azure/azure-sdk-for-net/commit/4bcff5ffc3478e0252d0cce92bdf082b4cef7ec1) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20261012.2 | 1.0.0-alpha.20261019.1 | [b1535bd](https://github.com/Azure/azure-sdk-for-net/commit/b1535bd11142a55ea8632c640dd0a0da5d413c4c) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

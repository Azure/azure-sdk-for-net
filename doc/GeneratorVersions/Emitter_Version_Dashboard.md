# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-09-09 01:43:14 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260908.5)
  └─ @azure-typespec/http-client-csharp (alpha.20260903.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260907.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260908.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260908.6 | 1.0.0-alpha.20260908.5 | [cb580e5](https://github.com/microsoft/typespec/commit/cb580e5a222ed274a38a071223c7519f85871df6) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260828.4 | 1.0.0-alpha.20260903.4 | [85129b2](https://github.com/Azure/azure-sdk-for-net/commit/85129b2ffefca0599275439620a11740a3393879) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260907.1 | 1.0.0-alpha.20260907.1 | [3bf9924](https://github.com/Azure/azure-sdk-for-net/commit/3bf9924f124b4d430da03d119798ed3c4de0226f) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

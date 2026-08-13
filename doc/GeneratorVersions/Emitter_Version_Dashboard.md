# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-08-13 02:37:01 UTC.
> Run that script to refresh this file after dependency version changes.

## Latest Published Version Chain

```
@typespec/http-client-csharp (alpha.20260812.9)
  └─ @azure-typespec/http-client-csharp (alpha.20260812.4)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260812.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260811.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | 1.0.0-alpha.20260812.9 | 1.0.0-alpha.20260812.9 | [4b15488](https://github.com/microsoft/typespec/commit/4b1548899c8c42cda2b78970519337dd4f387d27) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | 1.0.0-alpha.20260810.7 | 1.0.0-alpha.20260812.4 | [5135043](https://github.com/Azure/azure-sdk-for-net/commit/5135043a21ec2d9026d9c95526bb6206e2e09348) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | 1.0.0-alpha.20260812.1 | 1.0.0-alpha.20260812.1 | [ad23c92](https://github.com/Azure/azure-sdk-for-net/commit/ad23c928f50a12ca01629266a2d8d4ad3798dcad) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

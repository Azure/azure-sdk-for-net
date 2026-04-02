# Emitter Version Dashboard

> **Auto-generated** by `Emitter_Version_Dashboard` on 2026-04-02 04:09:46 UTC.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

```
@typespec/http-client-csharp (alpha.20260401.8)
  └─ @azure-typespec/http-client-csharp (alpha.20260401.3)
       └─ @azure-typespec/http-client-csharp-mgmt (alpha.20260401.1)
            └─ @azure-typespec/http-client-csharp-provisioning (alpha.20260327.1)
```

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| `@azure-typespec/http-client-csharp` | `@typespec/http-client-csharp` | [1.0.0-alpha.20260401.1](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260401.1) | [1.0.0-alpha.20260401.8](https://www.npmjs.com/package/@typespec/http-client-csharp/v/1.0.0-alpha.20260401.8) | [0680ffb](https://github.com/microsoft/typespec/commit/0680ffbaa4f4bbbbc1b519e354724a9cf1a4d8c1) |
| `@azure-typespec/http-client-csharp-mgmt` | `@azure-typespec/http-client-csharp` | [1.0.0-alpha.20260331.4](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260331.4) | [1.0.0-alpha.20260401.3](https://www.npmjs.com/package/@azure-typespec/http-client-csharp/v/1.0.0-alpha.20260401.3) | [97c14b2](https://github.com/Azure/azure-sdk-for-net/commit/97c14b2679e311a9485d2a477b54813048c4d0d6) |
| `@azure-typespec/http-client-csharp-provisioning` | `@azure-typespec/http-client-csharp-mgmt` | [1.0.0-alpha.20260322.2](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260322.2) | [1.0.0-alpha.20260401.1](https://www.npmjs.com/package/@azure-typespec/http-client-csharp-mgmt/v/1.0.0-alpha.20260401.1) | [e413cb9](https://github.com/Azure/azure-sdk-for-net/commit/e413cb9dfdf6460c14915fe09126ca3b39f050e2) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on `@typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on `@azure-typespec/http-client-csharp` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on `@azure-typespec/http-client-csharp-mgmt` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |

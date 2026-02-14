---
name: bump-mgmt-base-version
description: Bump the http-client-csharp base dependency version in http-client-csharp-mgmt. Updates emitter (npm) and generator (NuGet) references, rebuilds, and regenerates test projects.
---

# Skill: bump-mgmt-base-version

Bump the base `http-client-csharp` dependency used by the management-plane generator (`http-client-csharp-mgmt`). This updates both the npm emitter dependency and the NuGet generator dependency, then rebuilds and regenerates test projects.

## When Invoked

Trigger phrases: "bump mgmt base version", "update http-client-csharp in mgmt", "bump generator version", "update mgmt dependency".

## Instructions

### 1. Determine the target version

Read the latest version of `@azure-typespec/http-client-csharp` from:

```
eng/azure-typespec-http-client-csharp-emitter-package.json
```

Look at the `dependencies["@azure-typespec/http-client-csharp"]` value. This is the **target version**.

### 2. Identify current versions

Check the current versions in these two files:

| File | Field | Purpose |
|------|-------|---------|
| `eng/packages/http-client-csharp-mgmt/package.json` | `dependencies["@azure-typespec/http-client-csharp"]` | Emitter npm dependency |
| `eng/Packages.Data.props` | `<AzureGeneratorVersion>` | Generator NuGet dependency (used by `Azure.Generator.Management.csproj` via `<PackageReference Include="Azure.Generator" />`) |

If both already match the target version, no update is needed — inform the user and stop.

### 3. Update version references

Update **both** files to the target version:

1. **`eng/packages/http-client-csharp-mgmt/package.json`**: Change the `@azure-typespec/http-client-csharp` version in `dependencies`.
2. **`eng/Packages.Data.props`**: Change the `<AzureGeneratorVersion>` value.

### 4. Run npm install

```shell
cd eng/packages/http-client-csharp-mgmt
npm install
```

This updates `package-lock.json` to resolve the new dependency version.

### 5. Build the emitter

```shell
cd eng/packages/http-client-csharp-mgmt
npm run build:emitter
```

If TypeScript compilation fails, examine the errors — they likely indicate breaking API changes in the base `@azure-typespec/http-client-csharp` package. Fix the emitter source code under `eng/packages/http-client-csharp-mgmt/emitter/` accordingly.

### 6. Lint and format the emitter

```shell
cd eng/packages/http-client-csharp-mgmt
npm run lint
npm run prettier
```

If lint or prettier checks fail, fix with:

```shell
npm run lint:fix
npm run prettier:fix
```

These checks are required to pass CI. Always run them after any emitter code changes.

### 7. Build the generator

```shell
cd eng/packages/http-client-csharp-mgmt
npm run build:generator
```

This runs `dotnet build ./generator`. The `Azure.Generator.Management` project references the `Azure.Generator` NuGet package, whose version is controlled by `AzureGeneratorVersion` in `Packages.Data.props`.

If C# compilation fails, examine the errors — they likely indicate breaking API changes in the `Azure.Generator` package. Fix the generator source code under `eng/packages/http-client-csharp-mgmt/generator/Azure.Generator.Management/` accordingly.

### 8. Regenerate test projects

```shell
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/Generate.ps1
```

This script:
- Rebuilds the emitter and generator (via `Refresh-Mgmt-Build`)
- Regenerates the `Mgmt-TypeSpec` test project under `generator/TestProjects/Local/Mgmt-TypeSpec/`
- Builds the regenerated test project to verify correctness

If regeneration produces file changes, they must be included in the commit.

### 9. Verify

- Run `git status` to see all modified files
- Ensure `package.json`, `package-lock.json`, `Packages.Data.props`, and any regenerated test project files are included
- All changes should be committed together

## Key Files Reference

| File | Role |
|------|------|
| `eng/azure-typespec-http-client-csharp-emitter-package.json` | Source of truth for latest base version |
| `eng/packages/http-client-csharp-mgmt/package.json` | Mgmt emitter npm dependencies |
| `eng/packages/http-client-csharp-mgmt/package-lock.json` | Resolved npm dependency tree |
| `eng/Packages.Data.props` | NuGet version properties (AzureGeneratorVersion) |
| `eng/packages/http-client-csharp-mgmt/generator/Azure.Generator.Management/src/Azure.Generator.Management.csproj` | Generator project referencing Azure.Generator |
| `eng/packages/http-client-csharp-mgmt/eng/scripts/Generate.ps1` | Test project regeneration script |
| `eng/packages/http-client-csharp-mgmt/eng/scripts/Generation.psm1` | Build and generation helper functions |

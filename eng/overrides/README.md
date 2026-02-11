# Overrides guardrails

This folder contains **allowlists** and documentation for guardrails that make “local overrides” visible and intentional (see issue [`#55310`](https://github.com/Azure/azure-sdk-for-net/issues/55310)).

## `VersionOverride` allowlist

- **Allowlist file**: `eng/overrides/versionoverride.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_version_overrides.py`
- **What is checked**: any `PackageReference` in `sdk/**/*.csproj` that uses `VersionOverride` (attribute or element), e.g.

```xml
<PackageReference Include="NUnit" VersionOverride="4.4.0" />
```

The PR pipeline fails if it finds a `VersionOverride` that is **not** present in the allowlist.

### Allowlist schema

The allowlist is a JSON array. Each entry approves a single override, identified by these fields:

- **`project`**: path to the `.csproj` (repo-relative, `/` separators)
- **`packageId`**: the `PackageReference` `Include`/`Update` value
- **`versionOverride`**: the override value (string; can be a version or a range)
- **`referenceKind`**: `"Include"` or `"Update"`
- **`condition`**: the effective MSBuild condition (string or `null`). This matches either the `PackageReference` `Condition`, or the parent `ItemGroup` `Condition`.

Each entry must also include:

- **`tracking`**: URL to an issue/PR tracking the need for the override
- **`justification`**: short explanation for reviewers

### How to update when the pipeline fails

If you intentionally add or change a `VersionOverride` and the pipeline fails:

1. Run locally:

```bash
python3 eng/scripts/overrides/check_version_overrides.py --repoRoot . --searchPath sdk --allowlist eng/overrides/versionoverride.allowlist.json
```

2. Add (or update) the corresponding entry in `eng/overrides/versionoverride.allowlist.json` with tracking + justification.

## `ExcludeFromProjectReferenceToConversion` allowlist

- **Allowlist file**: `eng/overrides/projectrefconversion-exclusions.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_projectrefconversion_exclusions.py`
- **What is checked**: any `ExcludeFromProjectReferenceToConversion` item in `sdk/**/*.csproj`, e.g.

```xml
<ExcludeFromProjectReferenceToConversion Include="Azure.Storage.Blobs" />
```

The PR pipeline fails if it finds an exclusion that is **not** present in the allowlist.

Run locally:

```bash
python3 eng/scripts/overrides/check_projectrefconversion_exclusions.py --repoRoot . --searchPath sdk --allowlist eng/overrides/projectrefconversion-exclusions.allowlist.json
```

## AOT opt-out allowlist

- **Allowlist file**: `eng/overrides/aot-optouts.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_aot_optouts.py`
- **What is checked**: `AotCompatOptOut` / `AotAnalyzersOptOut` set to `true` in MSBuild files under `sdk/` (e.g., `.csproj`, `Directory.Build.props`).

Run locally:

```bash
python3 eng/scripts/overrides/check_aot_optouts.py --repoRoot . --searchPath sdk --allowlist eng/overrides/aot-optouts.allowlist.json
```

## ApiCompatBaseline.txt allowlist

- **Allowlist file**: `eng/overrides/apicompat-baselines.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_apicompat_baselines.py`
- **What is checked**: presence of `ApiCompatBaseline.txt` files under `sdk/` (these act as baseline/suppression inputs for API compatibility checks).

Run locally:

```bash
python3 eng/scripts/overrides/check_apicompat_baselines.py --repoRoot . --searchPath sdk --allowlist eng/overrides/apicompat-baselines.allowlist.json
```

## GlobalSuppressions.cs allowlist

- **Allowlist file**: `eng/overrides/global-suppressions.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_global_suppressions.py`
- **What is checked**: presence of `GlobalSuppressions.cs` files under `sdk/`.

Run locally:

```bash
python3 eng/scripts/overrides/check_global_suppressions.py --repoRoot . --searchPath sdk --allowlist eng/overrides/global-suppressions.allowlist.json
```

## Directory.Build.props NoWarn(AZC) allowlist

- **Allowlist file**: `eng/overrides/nowarn-directory-overrides.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_nowarn_directory_overrides.py`
- **What is checked**: `AZC####` rule IDs present in `<NoWarn>...</NoWarn>` in `sdk/**/Directory.Build.props`.

Run locally:

```bash
python3 eng/scripts/overrides/check_nowarn_directory_overrides.py --repoRoot . --searchPath sdk --allowlist eng/overrides/nowarn-directory-overrides.allowlist.json
```

## Matrix overrides allowlist

- **Allowlist file**: `eng/overrides/matrix-overrides.allowlist.json`
- **Checker**: `eng/scripts/overrides/check_matrix_overrides.py`
- **What is checked**: pipeline matrix-related keys in YAML under `sdk/` (currently `MatrixConfigs`, `AdditionalMatrixConfigs`, `TestDependsOnDependency`).

Run locally:

```bash
python3 eng/scripts/overrides/check_matrix_overrides.py --repoRoot . --searchPath sdk --allowlist eng/overrides/matrix-overrides.allowlist.json
```


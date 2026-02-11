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


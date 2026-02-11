# FindVersionOverrides

This tool supports issue [`#55310`](https://github.com/Azure/azure-sdk-for-net/issues/55310) (“Local overrides are not visible to the SDK team”).

## What it does

Scans project files (e.g., `sdk/**/*.csproj`) and inventories any `PackageReference` that uses a **`VersionOverride`** attribute or element, for example:

```xml
<PackageReference Include="NUnit" VersionOverride="4.4.0" />
```

This is a form of **per-project override** that can bypass the centrally managed dependency versions (see `eng/Packages.Data.props`).

## Usage

From the repo root:

```bash
dotnet run --project eng/tools/FindVersionOverrides -- --repoRoot . --searchPath sdk
```

## PR guardrail (allowlist)

PR validation uses an allowlist to ensure **new** `VersionOverride` entries don’t get introduced without visibility and justification.

- **Allowlist**: `eng/overrides/versionoverride.allowlist.json`
- **Check script**: `eng/scripts/overrides/check_version_overrides.py`

Run the guardrail locally:

```bash
python3 eng/scripts/overrides/check_version_overrides.py --repoRoot . --searchPath sdk --allowlist eng/overrides/versionoverride.allowlist.json
```

If you need to introduce a new `VersionOverride`, add an allowlist entry with a tracking link and justification.

Write JSON output (useful for CI / diffing):

```bash
dotnet run --project eng/tools/FindVersionOverrides -- --repoRoot . --searchPath sdk --outputJson artifacts/versionoverride-inventory.json
```

Fail the process if any `VersionOverride` entries are found (useful for future guardrails):

```bash
dotnet run --project eng/tools/FindVersionOverrides -- --repoRoot . --searchPath sdk --failOnFindings
```

## Output

- Prints a stable, sorted table to stdout.
- Optionally writes JSON to `--outputJson` (path is relative to `--repoRoot` unless absolute).

## Related script

There is also a PowerShell implementation at:

- `eng/scripts/overrides/Find-VersionOverrides.ps1`

It provides similar inventory behavior for environments where PowerShell is available.


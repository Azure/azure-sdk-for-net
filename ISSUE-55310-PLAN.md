# Plan: #55310 — Make “local overrides” visible to EngSys/SDK team

Issue: `https://github.com/Azure/azure-sdk-for-net/issues/55310`

## Goal

Create **repo-wide visibility + guardrails** for “local overrides” (per-package/per-directory deviations from central engineering defaults) so the SDK/EngSys team can:

- See what exists today (inventory)
- Prevent accidental new overrides (PR checks)
- Require justification/ownership for intentional overrides

## Guiding principles

- **Start with inventory (read-only)**, then add enforcement once we trust the signal.
- Prefer **deterministic output** (stable ordering) so diffs are meaningful.
- Make checks **targeted**: fail PRs only for *new* overrides, not historical debt.
- Keep an **allowlist/justification file** in-repo for approved overrides (with links).

## Scope (first slice + follow-ups)

### Slice A (first, recommended): `VersionOverride` in `.csproj`

Why: concrete, easy to detect, and often highest-risk (dependency drift).

Deliverables:
- Script that scans repo for `PackageReference` entries using `VersionOverride`.
- Output a table: project path → package id → override version.
- Add CI step to run script and surface results.
- Add a “new override” guardrail: fail if a PR introduces a new `VersionOverride` unless it’s recorded in an allowlist file.

### Follow-up slices (same pattern)

- **AOT opt-outs**: `AotCompatOptOut`, `AotAnalyzersOptOut`
- **ApiCompat baselines**: `ApiCompatVersion`, `ApiCompatBaselineTargetFramework`, `ApiCompatBaseline.txt`
- **Analyzer suppressions**: `GlobalSuppressions.cs`, `NoWarn` additions
- **Pipeline matrix overrides**: `MatrixConfigs`, `ProjectListOverrideFile`, `OverrideFiles`
- **Project reference conversion exclusions**: `ExcludeFromProjectReferenceToConversion`

## Implementation plan (Slice A: VersionOverride)

### 1) Discovery: decide where the script lives

Options (pick the repo’s preferred EngSys location):
- `eng/scripts/` (PowerShell; consistent with other EngSys tooling)
- A small `dotnet` tool under `eng/` (if the repo prefers C# for parsing XML robustly)

### 2) Implement scanner

Requirements:
- Scan `sdk/**/*.csproj` (and optionally `common/` + `samples/` if desired)
- Parse project files as XML (avoid brittle regex where possible)
- Collect:
  - Project path
  - `PackageReference` `Include`/`Update`
  - `VersionOverride` value
- Output:
  - Console table (human readable)
  - Machine-readable file (JSON) for CI + diffing

### 3) Add allowlist/justification mechanism

Add a file at repo root (or `eng/`), e.g.:

- `eng/overrides/versionoverride.allowlist.json`

Each entry should include:
- Project path
- Package id
- Allowed override version (exact or semver range if needed)
- Owner/team (or label)
- Link to tracking issue/PR and rationale

### 4) Add PR guardrail

Behavior:
- On PR builds, compare detected overrides vs allowlist.
- **Fail only when**:
  - A new `VersionOverride` appears without allowlist entry, or
  - An existing allowed override changes version without updating allowlist.

### 5) Add CI wiring

Add a pipeline step that:
- Runs the scanner
- Publishes the JSON as an artifact (optional)
- Prints a short summary and errors with actionable messages

### 6) Add tests for the scanner (if applicable)

If implemented in C#:
- Unit tests for XML parsing edge cases (`Include` vs `Update`, conditions, etc.)

If implemented in PowerShell:
- Add a small set of fixture `.csproj` files and validate output.

## Rollout strategy

- **Phase 1 (report-only)**: land scanner + report output (no failures).
- **Phase 2 (warn)**: PR comment or log warnings for unallowlisted overrides.
- **Phase 3 (enforce)**: fail PRs for new/unjustified overrides.

## Definition of done (for Slice A)

- A contributor can run a single command locally to list all `VersionOverride`s.
- CI runs the same check on PRs.
- New overrides are blocked unless recorded with justification.
- Output is stable and easy to review in logs.

## Candidate sub-issues to attach under #55310

- “Add scanner + report for `VersionOverride` usage”
- “Add allowlist + PR guardrail for new `VersionOverride`s”
- “Inventory and guardrail AOT opt-outs”
- “Inventory and guardrail ApiCompat baseline overrides”
- “Inventory analyzer suppressions (`GlobalSuppressions.cs`, `NoWarn`)”
- “Inventory pipeline matrix overrides (`MatrixConfigs`, override files)”


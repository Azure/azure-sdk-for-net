---
name: refresh-arm-sdk-release
description: "**WORKFLOW SKILL** — Prepares Azure.ResourceManager SDK refresh pull requests in azure-sdk-for-net. WHEN: \"prepare sdk refresh\", \"refresh Azure.ResourceManager package\", \"update ARM SDK from autorest tag\", \"refresh changelog dependencies\". INVOKES: git and GitHub pull request tools for branch, commit, push, and PR creation. FOR SINGLE OPERATIONS: Use git or GitHub tools directly."
---

# Refresh ARM SDK Release Skill

## When to Use This Skill
Activate only when the user wants an Azure.ResourceManager package refresh PR driven by API-version/tag resolution and dependency/changelog refresh updates.

## Scope Boundaries
- Use this skill only for refresh-style updates (for example regenerated surface alignment, changelog maintenance, dependency version refresh, and refresh PR creation).
- Do not use this skill for broad or feature-driven package releases, release planning across multiple packages, or non-refresh release orchestration.

## Prerequisites
- Repository: azure-sdk-for-net
- Target package path is known, for example sdk/dns/Azure.ResourceManager.Dns
- Access to remote origin and GitHub PR creation
- Current date available in yyyy-mm-dd format

## Workflow

### Step 1: Create Branch
- Fetch latest origin/main.
- Create a new branch from origin/main.
- Use a branch name that identifies package and date.

### Step 2: Eligibility Check — Skip Conditions
Before doing any further work on a package, check the CHANGELOG.md and skip the package (do not refresh it) if **either** of the following is true:

1. **Already released**: The latest changelog entry does NOT contain `(Unreleased)` — it already has a release date (e.g., `## 1.2.0 (2026-04-17)`). This means a release was already prepared and no new `(Unreleased)` entry exists to stamp.
2. **Dependencies already up to date**: **Any** changelog entry (across all released versions, not just the latest) already contains upgrade lines for **both** the current `Azure.Core` and `Azure.ResourceManager` versions (resolved from `eng/centralpackagemanagement/Directory.Packages.props`). If these exact versions were already shipped in any prior release, adding them again provides no value, so skip.

When skipping a package, log it clearly as **SKIPPED** with the reason, and move on to the next package in the batch.

### Step 3: Determine API Version Source in Order
- Check metadata.json in the package root.
- If present, use apiVersions value.
- If metadata.json is missing, check src/autorest.md for an uncommented tag.
- If tag is missing there, use the require value in src/autorest.md to open the referenced readme.md and read tag under Basic Information.

### Step 4: Decide SDK Versioning Mode
- If API version source indicates preview, use beta flow.
- Otherwise use stable flow.

### Step 5: Update CHANGELOG.md
- Confirm the newest heading exists and has the latest package version.
- During release finalization, replace Unreleased with current date using yyyy-mm-dd.
- For stable flow only, increment patch version from latest stable release.
- Remove empty sections under the latest entry when present:
  - Features Added
  - Breaking Changes
  - Bugs Fixed
- Under Other Changes, add:
  - Upgraded dependent Azure.Core to 1.X.X.
  - Upgraded dependent Azure.ResourceManager to 1.X.X.
- Resolve these versions from eng/centralpackagemanagement/Directory.Packages.props.

### Step 6: Update Project Version for Stable Flow Only
- If stable flow, set Version in src/Azure.ResourceManager.XXX.csproj to the new stable version matching the changelog entry.
- If beta flow, keep beta versioning and do not apply a version bump.

### Step 6b: Update README for First Stable Release
- This applies only when the stable flow new version is `1.0.0` (i.e., no prior stable release exists in the CHANGELOG — only beta entries).
- Open `README.md` in the package root and find the `dotnet add package` installation command.
- If it contains `--prerelease`, remove that flag so the command installs the stable package.
- Example: `dotnet add package Azure.ResourceManager.XXX --prerelease` → `dotnet add package Azure.ResourceManager.XXX`

### Step 7: Commit, Push, and Create PR
- Commit with a refresh-focused message.
- Push branch to origin.
- Create PR with title format:
  - Prepare release for Azure.ResourceManager.XXX Version 1.x.x
- Include summary of API source decision, refresh changes, and versioning mode.

## Copyable Checklist

Refresh PR progress:
- [ ] Branch created from origin/main
- [ ] Eligibility checked — packages with no Unreleased entry or already-current deps skipped
- [ ] API version source resolved using required precedence
- [ ] Beta or stable mode decided
- [ ] Changelog latest entry updated
- [ ] Unreleased replaced with current date yyyy-mm-dd
- [ ] Dependency upgrade lines added using central package versions
- [ ] Csproj version updated if stable flow
- [ ] README --prerelease flag removed if first stable release (version 1.0.0)
- [ ] Commit and push completed
- [ ] PR created with required title format

# Selective local regeneration with packaged MPG

`RegenSdkPackaged.ps1` is a developer alternative to the **packaging and SDK-generation** portions of the MPG regeneration pipeline. It does not replace hosted tests, compliance checks, or required PR validation. Existing `RegenSdkLocal.ps1` remains unchanged and continues to run directly from a local generator build.

## Scope and prerequisites

Use PowerShell 7, Node.js 22, the repository's required .NET SDKs, and Git. `gh` is needed for a generator PR source or draft-PR creation. Building a PR executes its code: use a reviewed/trusted generator PR.

The default selection is the 21 TypeSpec-enabled SDKs from the [priority list](https://gist.github.com/live1206/26f6c34be35efe04d35e8377c0962a03). Resources is not included because it currently has no management TypeSpec entry point. Explicit `-Services` names must match SDK folder names exactly (case-insensitive); unknown names and wildcards fail. This local runner is intended for small SDK groups, using either the default priority selection or an explicit subset. Use CI for full-scope regeneration; the local runner has no all-services option.

```powershell
# Inspect the intended scope/actions without creating worktrees or publishing.
./eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkPackaged.ps1 -WhatIf

# Build committed HEAD; regenerate exactly two SDKs with two workers.
./eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkPackaged.ps1 `
  -Services Azure.ResourceManager.KeyVault,Azure.ResourceManager.Dns -Parallel 2

# Use a generator PR's pinned merge commit and the default priority scope.
./eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkPackaged.ps1 `
  -GeneratorPullRequest 12345 -Parallel 4
```

The script creates a detached worktree under a new sibling `mpg-local-runs/<run-id>/sdk` directory. Override the run directory with `-OutputRoot`; existing directories are never overwritten. Generator PRs must be open, target `main`, and have a merge ref matching their reported head. Without `-GeneratorPullRequest`, the source is committed HEAD of the caller checkout, not uncommitted generator edits. The caller's checkout is never reset or switched.

Local-only runs retain a `file:` tarball reference in their isolated emitter config/lock. They do **not** push a branch, publish packages, or create a PR.

## Reused CI components

1. `eng/scripts/typespec/Initialize-WorkingDirectory.ps1` installs locked dependencies, sets a unique prerelease version, and saves the package metadata.
2. `eng/scripts/typespec/Build-Emitter.ps1` builds and packs the emitter/generator, produces npm and NuGet artifacts plus overrides, and restores the emitter's tracked package metadata.
3. `tsp-client generate-config-files` consumes the saved metadata and either a local tarball override or CI's Azure DevOps tarball URL. It updates the same management emitter config and lock used by SDK generation.
4. Each selected SDK runs `dotnet msbuild /restore /t:GenerateCode` in parallel with its own log, preserving CI's restore-before-generation behavior. This is required for SDKs such as MySql that import `GenerateCode` from NuGet targets. Shared root/tsp-client npm installations run **once before** workers start. Workers set `SkipTspClientInstall=true`.

`eng/common/scripts/Update-GeneratedSdks.ps1` is not called concurrently: its .NET implementation writes the shared `artifacts/GeneratedSdks.proj` and reinstalls root npm dependencies. Running several copies in the same worktree would race. The local runner instead calls the same per-SDK `GenerateCode` target without those shared writes.

## Automatic slowest-first scheduling

Scheduling is always slowest first; there is no timing-file option. This applies equally to the default priority scope and explicit `-Services` subsets.

The runner starts with bundled measurements in `RegenSdkPackaged.timings.json` and overlays the latest successful per-service timings learned in this repository. History is stored under `<git-common-dir>/mpg-local-regen/service-timings.json`, shared across worktrees but never committed. Successful workers update history even when a sibling fails; failures never replace an earlier successful measurement. Updates use a lock and atomic file replacement; an unavailable cache produces a warning rather than failing SDK generation.

Only successful, finite, nonnegative measurements influence scheduling. Selected SDKs without a measurement follow the measured SDKs; a custom subset may include slow SDKs that have not been measured yet. History never adds packages to the selected scope. Bundled values are estimates from a validated local benchmark, not runtime guarantees; actual timings vary with source, machine, and contention.

Each worker records elapsed seconds plus UTC start/finish timestamps in `logs/results.json`. The package list in `run.json` records launch order. Original run results are retained separately from the learned cache. Compare the same source revision, service list, and worker count, and account for warm-cache effects. End-to-end timings include packaging/setup; worker-phase timings do not.

## Optional publication and draft PR

A reusable PR needs a package URL accessible to other machines, not an absolute local file path. With existing npm credentials for CI's Azure DevOps feed:

```powershell
./eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkPackaged.ps1 `
  -GeneratorPullRequest 12345 `
  -Services Azure.ResourceManager.KeyVault,Azure.ResourceManager.Dns `
  -Parallel 2 -PublishPackages -CreateDraftPullRequest
```

These are explicit opt-ins:

- `-PublishPackages` publishes the **npm** tarball only to the Azure DevOps feed used by CI, never npmjs.org. It uses existing credentials and does not create or copy tokens. NuGet artifacts are retained locally, not published; they are not needed by the packaged npm generator.
- `-CreateDraftPullRequest` requires `-PublishPackages`. All selected generation tasks must pass. Local package URLs, unrelated changed files, and an unexpected `origin` prevent commit/push.
- Branch/title follow CI's `validate-typespec-pr-<PR>-azure-typespec/http-client-csharp-mgmt` and `[Preview] Update azure-typespec/http-client-csharp-mgmt version to prerelease <version>` conventions. If the remote CI branch already exists, the local branch gets a `-local-<run-id>` suffix. Existing branches/PRs are never force-pushed or reused.
- As in CI, the generation checkout is based on the generator PR's merge ref; its source changes are therefore included in the resulting branch until that PR merges. Required PR checks still apply.

## Results, failures, cleanup

`run.json` records source revision, selected SDKs in scheduled order, automatic timing-cache location, version, publication mode, and results. `logs/results.json` and individual SDK logs remain available on failure. A failed SDK batch stops before commit, push, or PR creation. Publication, when requested, happens before generation and is not rolled back by a generation failure.

Worktrees/artifacts are retained for inspection. After reviewing results, remove a run's checkout with `git worktree remove <run-directory>/sdk`, then remove its remaining artifacts yourself. No broad cleanup runs automatically.

Focused regression tests:

```powershell
Import-Module Pester -RequiredVersion 5.3.3
Invoke-Pester ./eng/packages/http-client-csharp-mgmt/eng/scripts/tests/PackagedRegen.Tests.ps1 -Output Detailed
```

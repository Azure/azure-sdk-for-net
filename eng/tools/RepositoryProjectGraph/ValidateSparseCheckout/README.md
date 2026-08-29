# Sparse-checkout dynamic validation

This directory contains a validation-only harness for exercising each PR test artifact from the
same Git sparse-checkout closure that production CI computes. It is not imported by graph
generation, `Language-Settings.ps1`, or normal test jobs.

The primary goal is practical file-availability coverage:

1. generate PackageInfo, the canonical repository graph, and `checkout-graph.json` once from a
   clean full checkout at an exact commit;
2. expand the repository's real sparse platform matrix;
3. resolve every singleton PackageInfo artifact to a narrowed checkout;
4. materialize that checkout in a detached Git worktree; and
5. invoke the same `eng/service.proj` selection and test properties used by the auto-PR test job.

Every fallback, missing artifact seed, setup failure, timeout, or test failure is a failed case.
The unattended runner continues after failures and exits nonzero after writing complete evidence.
Interactive Linux runs can stop at the first failure so an agent can diagnose, fix, and resume.

## Validation boundary

The default contract models the root `net - pullrequest` unit-test workflow:

```text
SDKType=all
ServiceDirectory=*
IncludeSrc=false
IncludeSamples=false
IncludePerf=false
IncludeStress=false
IncludeIntegrationTests=false
RunApiCompat=false
InheritDocEnabled=false
EnableSourceLink=false
EnableOverrideExclusions=true
TestCategory!=Manually
TestCategory!=Live
```

Matrix-controlled fields are not hard-coded. `New-ValidationInputs.ps1` expands the repository's
matrix implementation and records the complete matrix parameter set, including
`AdditionalTestArguments`, target framework, build configuration, filters, coverage setting, and
custom environment flags. The default sparse matrix is:

| Host | TFM | References | Configuration |
|---|---|---|---|
| Linux | net8.0 | PackageRef | Debug |
| Linux | net9.0 | ProjectRef | Release |
| Linux | net10.0 | PackageRef | Debug |
| Windows | net462 | ProjectRef | Release |
| Windows | net8.0 | PackageRef | Debug |
| Windows | net9.0 | ProjectRef | Release |
| Windows | net10.0 | PackageRef | Debug |
| Windows | net10.0 coverage | PackageRef | Debug (public PR default) |

The harness restores shared recordings and conditionally installs Azurite for Storage artifacts.
The root auto-PR pipeline has no service-specific `TestSetupSteps`; therefore these runs do not
claim equivalence with every service or live-test pipeline.

## Files

- `Dockerfile` provisions Ubuntu 24.04, .NET 8/9/10 SDKs, PowerShell, Git, and Node 22.
- `Invoke-LinuxDocker.ps1` builds the image with Docker or Podman and starts or resumes validation
  in container-managed Linux storage.
- `Invoke-LinuxContainer.ps1` owns the clean Linux clone and calls preparation plus execution.
- `New-ValidationInputs.ps1` creates PackageInfo, the source graph, checkout projection, and case
  manifest once. Its manifest uses relative paths so the Linux-generated input directory can be
  copied unchanged to Windows.
- `Validation.Common.ps1` fingerprints executable harness files for safe cross-run reuse.
- `Invoke-SparseCheckoutValidation.ps1` reuses a detached sparse worktree to execute each case.
- `Install-WindowsPrerequisites.ps1` installs/checks the Windows SDK and targeting-pack baseline.
- `Invoke-WindowsValidation.ps1` prepares and runs the same fail-closed harness on Windows.
- `RESULTS.md` is the durable index of completed validation campaigns. Per-case logs and generated
  summaries remain under `artifacts/validation/RepositoryProjectGraph/sparse-checkout`.

## Linux

Run from PowerShell on a Docker or Podman host:

```pwsh
eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/Invoke-LinuxDocker.ps1 `
  -ContainerEngine podman `
  -FailureMode Stop
```

The wrapper builds `linux/amd64` by default, including on Apple Silicon, so the process reports the
same architecture and selects the same RID as hosted Linux CI. Emulation is useful for iteration
but is not equivalent to native x64 execution for performance or native-runtime failures. If x64
emulation is unavailable or unstable on an Apple Silicon host, pass
`-ContainerPlatform linux/arm64` for a native structural-validation campaign. An arm64 campaign
uses the same Linux MSBuild matrix properties, but its results are not authoritative for x64-only
runtime behavior. The harness copies `eng/nunit.runsettings` and changes only `TargetPlatform` to
`arm64`, keeping PowerShell, MSBuild, and VSTest native. Record a final authoritative Linux campaign
on a native x64 Docker host.

The wrapper mounts the source repository read-only, clones the requested commit into a named Docker
volume, and stores results on the host under:

```text
artifacts/validation/RepositoryProjectGraph/sparse-checkout/
```

Useful iteration controls:

```pwsh
# Inspect the expanded cases without creating a worktree.
.../Invoke-LinuxDocker.ps1 -ListOnly

# Run one artifact/matrix while diagnosing a failure.
.../Invoke-LinuxDocker.ps1 `
  -ArtifactFilter '^Azure\.Core$' `
  -MatrixFilter 'net100' `
  -FailureMode Stop

# Resume passed cases and continue collecting all failures.
.../Invoke-LinuxDocker.ps1 -Resume -FailureMode Continue
```

The named Docker volume preserves the clean clone, Git object store, NuGet cache, recording clone
cache, and sparse worktree between invocations. Results are keyed by source commit, checkout-graph
hash, artifact, matrix entry, harness version, and setup policy; incompatible results are not
reused. Reusable input files are also regenerated if any commit, host-scope, harness, or graph-hash
check fails.

## Windows

Copy the complete Linux-generated `inputs/` directory to the same default artifact path in a
Windows checkout of the manifest's exact source commit. Use the same validation harness revision;
the runner rejects mismatched harness and input hashes. Then, from an elevated PowerShell 7 prompt:

```pwsh
eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/Install-WindowsPrerequisites.ps1

eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/Invoke-WindowsValidation.ps1 `
  -Resume `
  -FailureMode Continue
```

Windows also uses a real detached Git sparse worktree. Symlinks and junctions are deliberately not
used because their targets could expose files from the full checkout and hide an incomplete map.
The runner invokes the prerequisite script in check-only mode and verifies the .NET Framework
4.6.2 targeting pack before validation starts.

## Evidence layout

```text
inputs/
  PackageInfo/
  source/repository-project-graph.reader.json
  checkout-graph.json
  cases.json
  project-coverage.json
  manifest.json

runs/<host>/
  cases/<case-key>/
    result.json
    sparse-paths.txt
    project-list.props
    command.txt
    test.log
    test.binlog
    test-results/
  results.jsonl
  summary.json
  summary.md
```

`summary.md` is generated for each run. After a campaign is reviewed, add its concise outcome and
evidence location to `RESULTS.md`; do not commit large logs or generated graph artifacts.

`project-coverage.json` independently inventories test projects from the source graph and lists
the PackageInfo artifacts whose directory roots own them. Unowned projects are explicit coverage
exceptions: they are not silently assigned to an unrelated artifact, and a campaign with any such
entry cannot be described as validation of every repository test project.

## Interpretation

A sparse-only failure is a production checkout bug when the same command succeeds from a clean
full checkout. Failures common to sparse and full checkouts are environment or test failures and
must remain separately classified. A passing singleton campaign proves broad path availability for
artifact unions, but does not cover macOS, live tests, service-specific setup, skipped runtime paths,
or arbitrary behavior triggered only by adding another artifact's files.

Before a production-readiness claim, combine this evidence with dependency-relation parity,
structural host/mode auditing, Windows results, macOS differential coverage, and stale/incomplete
graph fallback tests described in [`../VALIDATION.md`](../VALIDATION.md).

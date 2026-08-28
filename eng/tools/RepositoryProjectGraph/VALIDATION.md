# Repository project graph and sparse-checkout validation plan

This plan validates two production contracts:

1. `Language-Settings.ps1` selects exactly the same indirect packages through the
   repository graph as through the existing `ResolveReferences` implementation.
2. Every test artifact can restore, build, and test from its individual sparse-checkout
   closure. Because matrix batches are unions of artifact closures, validating each
   artifact proves path availability for every possible batch.

The plan separates three kinds of evidence:

- **Relation parity** compares the complete old and new dependency-selection outputs.
- **Evaluated structural auditing** proves that all declared MSBuild dependencies and
  inputs are contained in each artifact closure across supported build modes.
- **Dynamic artifact validation** runs the real restore/build/test workflow in an exact
  sparse checkout, catching custom targets and runtime file access outside the declared
  MSBuild model.

All three are needed before production rollout. A structural audit alone cannot observe
arbitrary file access in an `Exec`, custom task, or test. A dynamic run alone proves only
the host and matrix configurations that happened to run.

## Handoff instructions

The implementing agent should:

1. Start from a clean checkout of the exact branch commit being validated. Do not reuse
   graph JSON, PackageInfo, `bin`, or `obj` output from another commit.
2. Read [`README.md`](README.md), [`trade-off.md`](trade-off.md), and
   [`SPARSE_CHECKOUT.md`](SPARSE_CHECKOUT.md) before adding validation code.
3. Keep validation-only exact input data outside the production schema and intermediate
   record contract. Write it beneath `artifacts/validation/RepositoryProjectGraph`.
4. Put new graph-specific validation tasks, targets, and scripts under
   `eng/tools/RepositoryProjectGraph` or `eng/scripts`. Avoid changes to `eng/common` and
   production project targets unless the validation cannot be injected safely.
5. Run repository-wide graph evaluations sequentially. Do not start concurrent full
   `ProjectGraph` evaluations; peak memory is a first-order constraint.
6. Preserve every mismatch as machine-readable evidence. Do not resolve failures with
   hard-coded package or file exceptions. Any accepted exception must be a durable rule
   with a documented reason and a test.
7. Keep changes local and reviewable. Do not push, alter CI, or publish artifacts unless
   separately requested.

## Contracts and terminology

### Dependency-selection relation

Let `P` be the set of repository package identities that can be directly changed and
`D` the package roots that can be selected for dependent validation. Each implementation
defines a relation:

\[
R \subseteq P \times D
\]

For a changed package set `S`, both implementations select a union:

\[
Dependents(S)=\bigcup_{p\in S}Dependents(p)
\]

Therefore, proving `R_legacy = R_graph` proves identical indirect-package output for
every possible PR package set. It is unnecessary and wasteful to invoke the legacy
target once per package.

### Sparse-checkout artifact closure

The atomic validation unit is a PackageInfo artifact, not a project and not a generated
matrix batch. For artifact `a`:

- `Seeds(a)` contains every graph configuration below its `PackageInfo.DirectoryPath`.
- `Reach(a)` is the forward project/package closure of those seeds.
- `Checkout(a)` is the union of reached SDK checkout roots and unconditional paths.

For a matrix batch `B`, graph reachability distributes over seed unions:

\[
Reach\left(\bigcup_{a\in B}Seeds(a)\right)
=\bigcup_{a\in B}Reach(a)
\]

and the resolver emits:

\[
Checkout(B)=AlwaysIncluded\cup\bigcup_{a\in B}Checkout(a)
\]

If every artifact succeeds under `Checkout(a)`, every batch union has at least the files
required by each member artifact. Do not validate only the union of all artifacts: that
degenerates toward a full `sdk` checkout and can hide a missing per-artifact dependency.

### Supported modes

Validation must use the actual PR test matrix after service-specific filters, rather than
inventing unsupported combinations. At minimum, account for:

- every declared target framework;
- `Debug` and `Release`;
- `UseProjectReferenceToAzureClients=false` and `true` where enabled;
- Linux, Windows, and macOS host-conditioned evaluation; and
- Windows-only `net462` execution where present.

The production source graph currently evaluates `Debug` in normal package-reference
mode. The audit must prove that every other supported mode introduces no checkout root
outside that production closure. If it does, production graph policy must change; the
validator must not waive the difference.

## Required validation deliverables

Implement a resumable orchestrator, preferably
`eng/scripts/Validate-RepositoryProjectGraph.ps1`, with separately invocable phases:

```text
-DependencyRelation
-StructuralSparseCheckout
-DynamicSparseCheckout
-Summarize
```

Names may follow an existing repository convention, but the implementation must produce
the following evidence beneath `artifacts/validation/RepositoryProjectGraph/`:

```text
source/
  repository-project-graph.reader.json
  repository-project-graph.reader.json.records
  repository-project-graph.reader.json.packages.records

dependency-relation/
  legacy.tsv
  graph.tsv
  legacy-only.tsv
  graph-only.tsv
  provenance.json

structural-sparse-checkout/
  required-roots.jsonl
  artifact-closures.jsonl
  missing-roots.jsonl
  host-and-mode-differences.json

dynamic-sparse-checkout/
  results.jsonl
  failures/<artifact>/<mode>/...

validation-summary.json
validation-summary.md
```

Every output should record the source commit, operating system, architecture, .NET SDK,
configuration, reference mode, target framework, elapsed time, and peak working set where
applicable. A rerun may skip a result only when all of those inputs and the validation
tool version match.

## Phase 0: Focused prechecks

Run these before repository-wide work:

```pwsh
dotnet build eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj --no-restore

Invoke-Pester eng/scripts/tests/RepositoryProjectGraph.Tests.ps1
Invoke-Pester eng/scripts/tests/SparseCheckout.Tests.ps1
Invoke-Pester eng/scripts/tests/LanguageSettings.Tests.ps1
```

Require:

- zero build warnings and errors;
- every focused Pester test passes;
- `git diff --check` passes for the validation changes; and
- the worktree has no unrelated tracked changes that could affect project evaluation.

Add focused fixtures for every new collector or comparator before running the full
repository. Fixtures must cover case-insensitive package identity, multi-TFM projects,
duplicate records, unknown artifacts, and fail-closed output on incomplete data.

## Phase 1: Build and validate the canonical graph

### 1.1 Generate once from a clean full checkout

Generate a sparse-capable canonical graph at the standard path. Use the same project
selection properties as PR dependency analysis:

```pwsh
dotnet msbuild /m /nr:false /nologo /tl:off `
  /t:GenerateRepositoryProjectGraphWithProjectGraph eng/service.proj `
  /p:IncludeRepositoryProjectGraphInputCheckoutRoots=true `
  /p:IncludeSrc=false `
  /p:IncludeSamples=false `
  /p:IncludePerf=false `
  /p:IncludeStress=false `
  /p:RunApiCompat=false `
  /p:InheritDocEnabled=false `
  /p:BuildProjectReferences=false
```

Do not pass `SkipServiceProjectImports=true` for dependency-selection validation: graph
roots must represent the same candidate projects used by `Language-Settings.ps1`.

Verify the artifact directly:

- `schemaVersion` is the expected current schema;
- `sourceCommit` equals `git rev-parse HEAD`;
- `diagnostics.isComplete` is `true`;
- package-closure mode is `nuget-restore-graph`;
- unresolved package count is zero;
- configuration graph is exact, with no inferred destination configurations;
- every declared project and root has a node;
- every ProjectReference destination configuration exists;
- every shipping package identity is unique;
- checkout-root diagnostics are complete; and
- every dynamic root matches `/sdk/<service>/*`.

Report project, configuration, edge, root, checkout-root, NuGet root, record-byte, JSON-byte,
phase timing, and memory counts. Historical counts are sanity checks only; do not hard-code
them because repository topology changes.

### 1.2 Verify the intermediate contract

Inspect both record files and assert:

- every `Node`, `ProjectReference`, and `PackageReference` can be parsed by the shared
  record model;
- records contain no unsupported delimiter or newline;
- duplicate serialized records are absent;
- `ReferenceOutputAssembly=false` ProjectReferences remain in source records but do not
  contribute synthetic NuGet P2P metadata;
- every emitted ProjectReference has a concrete destination TFM;
- exact input records and generated `artifacts` checkout roots are absent; and
- `PackageClosureSummary` counts equal the detail records.

### 1.3 Verify graph query algebra

Load the canonical graph once and validate:

- every serialized configuration edge is indexed consistently in each query direction,
  with source and destination swapped for reverse traversal;
- reverse traversal does not combine paths across source TFMs;
- canonical forward traversal keeps package identities terminal and maps them to physical
  shipping projects only at the output boundary, avoiding cross-TFM source traversal; and
- unknown package/project inputs fail instead of returning an empty narrowed result.

## Phase 2: Exhaustive indirect-package relation parity

This is the authoritative acceptance test for the `Language-Settings.ps1` transition.

### 2.1 Produce the package identity universe

Use the production PackageInfo discovery path to generate all repository PackageInfo
objects. Do not infer the set only from directory names. Record for each package:

```text
Name | ArtifactName | normalized DirectoryPath | IncludedForValidation
```

Production PackageInfo discovery already emits shipping projects only. Do not add a
second, differently evaluated shipping-package filter in the validator.

The legacy implementation compares changed package names with `ReferencePath.Filename`,
while the graph uses package identities. The comparator must preserve that real behavior
and expose any package/assembly naming mismatch rather than normalizing it away.

### 2.2 Collect the complete legacy relation in one pass

Add a validation-only target or injected targets file that runs the existing
`ResolveReferences` path over the same candidate roots and TFMs as `ProjectDependsOn`.
For every client, non-generator candidate configuration, emit:

```text
ReferencePath.Filename | normalized PackageRootDirectory | project | targetFramework
```

After the single MSBuild traversal, intersect `ReferencePath.Filename` with the production
repository package-name universe and reduce records to sorted, unique relation pairs:

```text
repository package name<TAB>dependent package root
```

The collector must preserve the legacy filters:

- `IsClientLibrary=true`;
- `IsGeneratorLibrary!=true`;
- all inner target frameworks;
- the PR dependency-analysis project universe; and
- package-root-only output.

Do not invoke `ProjectDependsOn` once per package. `ResolveReferences` cost is independent
of how many repository filenames are intersected after evaluation, so one relation pass is
both stronger and cheaper.

### 2.3 Collect the complete graph relation

Read the canonical graph once. For every shipping repository package identity:

1. seed reverse traversal with `package:<identity>`;
2. traverse all direct and indirect predecessors without crossing TFM paths;
3. apply the same root, client-library, and generator filters as the production reverse
   query; and
4. emit the same normalized package-name/package-root pair.

This should share query primitives with production where practical, but the comparator
must not invoke a new PowerShell process or reparse JSON for every package.

### 2.4 Compare and classify

Require exact relation equality:

```text
legacy-only = empty
graph-only  = empty
```

For diagnosis, classify every graph pair by the first relevant provenance available in
the intermediate records:

1. direct ProjectReference path;
2. direct repository PackageReference; or
3. NuGet-derived `TransitivePackageReference`.

Enumerate NuGet-only repository identities from the current records; never hard-code a
snapshot list. The final legacy relation remains the behavior oracle for these difficult
paths because it includes `ResolvePackageAssets`, RAR, compile-asset filtering, and the
actual filename comparison used before this branch.

Any extra graph pair is a behavior change even if it would only run additional tests.
The stated transition goal is parity, so conservative over-selection must be reviewed and
resolved rather than silently accepted by this comparator.

### 2.5 Verify final Language-Settings output

Run a focused integration layer over the relation result to confirm that production
PackageInfo behavior remains unchanged:

- directly changed packages stay `IncludedForValidation=false`;
- relation-selected dependents become `IncludedForValidation=true`;
- already-direct packages are not duplicated as indirect;
- directory paths map to exactly one PackageInfo object;
- multiple changed packages produce the relation union; and
- the no-package fallback remains unchanged.

## Phase 3: Build the complete sparse-checkout projection

### 3.1 Generate production PackageInfo and projection

Generate PackageInfo for every shipping artifact through the production scripts. Use the
canonical graph to run `CreateSparseCheckoutGraphTask`, then validate:

- every PackageInfo `ArtifactName` has a non-empty seed set;
- every seed is a known graph configuration;
- every project under `PackageInfo.DirectoryPath` contributes all of its configurations;
- nested test projects whose package root differs from `DirectoryPath` are still seeded;
- every adjacency destination exists;
- repository package key casing is normalized consistently;
- every reached repository package identity expands to the shipping source configurations
  required by project-reference test mode;
- every path is either unconditional or `/sdk/<service>/*`; and
- the projection source commit equals the graph and checkout commit.

Resolve every artifact individually and store its sorted singleton closure. Add an
algebra test showing that resolving a comma-separated artifact batch equals the set union
of the corresponding singleton closures plus one copy of the unconditional paths.

### 3.2 Do not use a global-union smoke test as proof

Record the union of all singleton artifact roots for observability, but do not use it as
an acceptance test. If it approaches all SDK service roots, a successful test under that
checkout says nothing about whether one artifact omitted a dependency that another
artifact happened to supply.

## Phase 4: Exhaustive evaluated structural sparse audit

The audit must be independent of production checkout-root coarsening. It may reuse
MSBuild and `ProjectGraph`, but it must collect exact evaluated inputs into a separate
validation model before reducing them to service roots.

### 4.1 Evaluate actual supported modes

Evaluate the repository sequentially for every graph-shaping mode used by the generated
PR test matrix:

```text
Configuration = Debug | Release
UseProjectReferenceToAzureClients = false | true, where supported
TargetFramework = every concrete inner build
Host = current host, followed by host differential runs
EnableDefaultItems = true
```

Do not run synthetic NuGet restore for a variant when its direct package/P2P topology and
restore properties are byte-equivalent to the already resolved production topology. If a
variant differs, either resolve that variant or fail and require an explicit production
policy decision.

### 4.2 Collect independent required paths and identities

For every evaluated project configuration collect:

- project path and package root;
- ProjectReferences and concrete destination configurations;
- direct PackageReferences with evaluated versions and asset filters;
- `MSBuildAllProjects` imports;
- `Compile`, `None`, `Content`, `EmbeddedResource`, and `AdditionalFiles`;
- analyzers, editor/analyzer configuration files, Protobuf, and TypeScript items;
- application, page, resource, splash-screen, and native-reference items; and
- local `Reference` hint paths.

Keep exact normalized paths only in validation output. Running with normal default items
is intentional: it independently detects build logic whose dependencies change based on
SDK-default item presence, even though same-service default files are already covered by
the service checkout root.

### 4.3 Reduce required paths with fixed rules

Map each required path using only these rules:

```text
sdk/<service>/...   -> required dynamic root /sdk/<service>/*
common/...          -> covered by unconditional /common
eng/...             -> covered by unconditional /eng
.config/...         -> covered by unconditional /.config
repository root     -> covered by unconditional root-file patterns
artifacts/...       -> generated output, not a Git checkout input
outside repository  -> external input, not a Git checkout input
other repository path -> unsupported; fail closed
```

Do not add per-file or per-package exclusions to make the audit pass.

### 4.4 Audit every artifact

For every artifact and supported mode:

1. start with every evaluated project configuration below its PackageInfo directory;
2. traverse independent P2P and repository-package source relationships;
3. union required service roots from every reached project and exact input;
4. compare with the artifact's production singleton sparse closure; and
5. emit any missing root with the shortest dependency/input path that required it.

The acceptance relation is subset, not equality:

\[
RequiredRoots(artifact, mode)\subseteq ProductionSparseRoots(artifact)
\]

Extra production roots are safe sparse-checkout false positives. Missing required roots
are blockers.

### 4.5 Host differential

Run the evaluated collector on Ubuntu 24.04 x64 first, then on a Windows 2022 x64 host.
Compare project/TFM identities, P2P edges, direct package topology, and required roots.
Run macOS evaluation if its project graph differs from Linux or if repository conditions
explicitly select macOS.

The production graph must cover the union of roots required by every supported host. Host
differences cannot be dismissed merely because the current source graph is intended to be
OS-neutral.

## Phase 5: Dynamic per-artifact sparse validation

Dynamic validation is a one-time productionization burn-in and a targeted regression tool,
not a cheap per-commit unit test.

### 5.1 Primary host

Use a real Ubuntu 24.04 x64 host:

- 16 GiB RAM minimum; 32 GiB preferred;
- enough disk for the repository, isolated build outputs, logs, and NuGet cache;
- the repository-pinned .NET SDK, currently .NET 10.0.400;
- a case-sensitive filesystem; and
- no reuse of an arm64 test host through x64 emulation.

Linux gives the strongest primary sparse-path signal because it catches path-casing errors
that default Windows and macOS filesystems can hide and runs the modern net8/net9/net10
matrix.

### 5.2 Separate producer and validation checkouts

Use one clean full checkout to produce the canonical graph, PackageInfo, and
`TestCheckoutGraph`. Keep those artifacts outside a second checkout used for dynamic
tests. The validation checkout may share Git objects and the immutable NuGet global
package cache, but must not share repository `bin`, `obj`, or `artifacts` output.

Before each artifact:

1. reset the validation checkout to the exact source commit;
2. remove all generated and untracked repository output;
3. resolve that artifact's singleton paths with `Resolve-SparseCheckoutPaths.ps1`;
4. set exactly those non-cone sparse-checkout patterns;
5. verify the checked-out commit and resulting `.git/info/sparse-checkout`; and
6. create the project-list override through the same PackageInfo script used by CI.

Do not incrementally add artifact paths without first removing the previous artifact's
checkout. Residual source would invalidate the test.

### 5.3 Run the actual artifact matrix

For each artifact, derive the matrix entries that CI would really generate after service
filters. Run the CI-equivalent restore/build/test command for each supported Linux entry,
including:

- net8, net9, and net10 where targeted;
- Debug and Release where generated;
- package-reference and project-reference client modes where generated; and
- the normal exclusions for `Live` and `Manually` categorized tests.

The project-list override must include every project associated with the artifact, so one
artifact invocation validates all of its source and test projects. Record skipped target
frameworks distinctly from successful executions.

Each result record should contain:

```json
{
  "artifact": "Azure.Example",
  "sourceCommit": "...",
  "host": "linux-x64",
  "configuration": "Debug",
  "referenceMode": "project",
  "targetFramework": "net10.0",
  "checkoutPaths": ["/sdk/core/*", "/sdk/example/*"],
  "exitCode": 0,
  "elapsedSeconds": 0,
  "status": "passed"
}
```

Make execution resumable by keying completed results to all fields above plus the graph
and validator versions. Shard artifacts across hosts only after the producer artifacts are
identical and immutable.

### 5.4 Distinguish sparse failures from repository failures

When a sparse artifact run fails:

1. preserve logs, binlogs, sparse patterns, and missing-path diagnostics;
2. rerun the exact artifact and matrix entry in a clean full checkout;
3. classify it as `sparse-only` only when the full checkout passes;
4. treat every `sparse-only` failure as a blocker; and
5. fix the graph/input model, then rerun the artifact and structural audit.

Do not suppress a failure because another artifact or a global-union checkout would supply
the missing path.

### 5.5 Close host-specific gaps

After Linux burn-in:

- On Windows 2022 x64, run every artifact/mode identified by the structural host diff and
  every generated net462 entry.
- On macOS, run artifacts identified by a macOS structural difference. If there are no
  differences, run a small representative smoke set covering linked inputs, NuGet-derived
  repository packages, and project-reference conversion.

If the requirement changes from sparse-checkout correctness to complete cross-platform
test correctness, run the full hosted PR matrix; a single local host cannot prove Windows
custom-target or net462 runtime behavior.

## Phase 6: Failure and fallback validation

Validate fail-closed behavior independently of successful closures:

- missing graph artifact;
- unsupported graph or projection schema;
- incomplete source diagnostics;
- unresolved NuGet roots;
- stale source commit;
- tracked source changes after graph generation;
- missing or duplicate artifact metadata;
- artifact with no graph seeds;
- missing adjacency/path index;
- unknown edge kind; and
- non-SDK dynamic checkout path.

Every case must produce no narrowed paths and cause the test job to select the full-checkout
fallback. Verify the stable observability markers:

```text
REPOSITORY_PROJECT_GRAPH_RESULT=reused|generated
SPARSE_CHECKOUT_GRAPH_RESULT=available|fallback
SPARSE_CHECKOUT_RESULT=narrowed pathCount=<n>|full
```

## Phase 7: Performance and resource validation

Correctness runs must also capture operational viability:

- graph construction, canonicalization, record emission, NuGet closure, JSON build,
  projection, and singleton-query timings;
- cold and warm NuGet cache measurements;
- record and artifact sizes;
- process peak working set; and
- evidence of swapping or memory-pressure termination.

Use sequential Debug/Release and reference-mode audit evaluations. Stop rather than
continuing a run that is persistently swapping. Do not set a hard performance threshold
from historical measurements until the same commit and host have a recorded baseline.
Any regression should be reported by phase so correctness work does not hide a new
repository-wide evaluation bottleneck.

## Final acceptance criteria

The repository graph is ready to replace legacy package selection when all of the following
are true:

- focused build and Pester checks pass;
- canonical graph diagnostics are complete and package resolution has zero unresolved roots;
- the full legacy and graph dependency relations are exactly equal;
- final direct/indirect PackageInfo sets are equal for relation fixtures and full-repository
  comparison;
- every artifact has valid seeds and a singleton sparse closure;
- every supported evaluated mode's required roots are a subset of its production artifact
  closure;
- Linux dynamic validation has no sparse-only artifact failures;
- Windows differential and net462 validation has no sparse-only failures;
- macOS differential or representative smoke validation passes;
- all incomplete/stale/unsupported cases fall back to full checkout; and
- timing and memory evidence shows the workflow can run without sustained swapping.

The final report must state exactly which source commit, hosts, matrix modes, artifacts,
and target frameworks were validated. It must not use “all” when a platform or mode was
skipped.

## Recommended implementation and execution order

1. Add fixtures and the one-pass legacy relation collector.
2. Implement the in-memory graph relation exporter and exact comparator.
3. Run full relation parity and resolve every mismatch before sparse validation.
4. Add the validation-only evaluated input collector.
5. Generate all PackageInfo and singleton artifact closures.
6. Run the exhaustive evaluated structural audit on Linux.
7. Run the Linux dynamic artifact burn-in, resumably and in shards if needed.
8. Run the structural host differential and targeted Windows/macOS validation.
9. Re-run focused tests and the full relation/structural audits after every correctness fix.
10. Produce `validation-summary.json` and `validation-summary.md` with zero unexplained
    mismatches or sparse-only failures.

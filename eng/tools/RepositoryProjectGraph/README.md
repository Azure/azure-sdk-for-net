# Repository project graph

`RepositoryProjectGraph` builds one reusable, schema-versioned model of repository
project and package reachability. PR matrix generation uses the same canonical graph
for two directions:

- **Reverse reachability:** a changed repository package selects every direct or
  indirect dependent package that needs validation.
- **Forward reachability:** a selected test artifact expands to the projects,
  repository packages, and SDK service directories required by sparse checkout.

The graph models identities and reachability, not compiler files or authoritative
restore assets. It evaluates the repository once in `Debug`, preserves every declared
target framework as a distinct configuration, and fails closed when exact repository
reachability cannot be established. The root pull-request validation pipeline rejects stale,
incomplete, or unsupported sparse data rather than testing from its complete orchestration
checkout.

For detailed design alternatives and limitations, see [`trade-off.md`](trade-off.md).
For hosted sparse-checkout findings and validation, see
[`SPARSE_CHECKOUT.md`](SPARSE_CHECKOUT.md). For the complete production-validation
procedure, see [`VALIDATION.md`](VALIDATION.md).

## Terminology

A **configuration** is one evaluated `(project path, target framework)` pair. `Debug`
is the single build configuration, while `net8.0`, `net9.0`, and `net10.0` remain
separate graph configurations where declared.

A **checkout root** is a Git sparse-checkout pattern for an entire SDK service
directory required by a configuration:

```text
project path:  sdk/core/Azure.Core/src/Azure.Core.csproj
package root:  sdk/core/Azure.Core
checkout root: /sdk/core/*
```

Checkout roots are deliberately coarser than exact MSBuild inputs. A project under
`sdk/core` always contributes `/sdk/core/*`; an explicit linked input under
`sdk/identity` additionally contributes `/sdk/identity/*`. Dynamic roots are limited
to `/sdk/<service>/*`. Repository root files, `/eng`, `/.config`, and `/common` are
included unconditionally, while generated `/artifacts` paths are not Git inputs.

## Architecture

```text
MSBuild project paths
    │
    ▼
1. ProjectGraph expansion ─────────────── in-memory ProjectGraph
    │                                      │
    │ source records                       │ isolated child process
    ▼                                      │
2. Synthetic NuGet resolution ─────────── in-memory DependencyGraphSpec/lock targets
    │                                      │
    │ package-closure records              │ child exits and releases graph memory
    ▼                                      ▼
3. Canonical artifact builder ─────────── repository-project-graph.reader.json
    │                                      │
    ├─ reverse query ─▶ dependent PackageInfo files
    │
    └─ forward projection ───────────────▶ checkout-graph.json
                                              │
                                              ▼
                                        per-test-job BFS
                                              │
                                              ▼
                                        git sparse-checkout
```

The filesystem record boundary between phases 1, 2, and 3 is intentional. NuGet does
not consume the in-memory `ProjectGraph`; it reads the records emitted by phase 1.
Both C# phases run in an isolated MSBuild process, which exits before PowerShell
constructs the canonical JSON and releases the repository-wide evaluated graph.

### Validation-only MSBuildProjectReferenceOracle

[`Validate-RepositoryProjectGraph.ps1`](../../scripts/Validate-RepositoryProjectGraph.ps1)
and [`CollectMSBuildProjectReferenceOracle.targets`](CollectMSBuildProjectReferenceOracle.targets)
are validation artifacts, not production graph components. The collector injects the established
`ProjectDependsOn`/`ResolveReferences` behavior into a full-checkout validation run and calls that
independent baseline the **MSBuildProjectReferenceOracle**. The validator compares its complete
package-to-dependent-root relation with the repository graph and writes evidence only beneath
`artifacts/validation/RepositoryProjectGraph`. Neither file is imported by
`Language-Settings.ps1`, normal graph generation, or sparse-checkout projection.

## Phase 1: Project discovery and graph expansion

**Related components**

- [`service.proj`](../../service.proj) collects source, generator, shared, common,
  test, and integration projects and invokes the graph tasks.
- [`RepositoryProjectGraphTask`](RepositoryProjectGraphTask.cs) constructs the MSBuild
  `ProjectGraph`, validates configuration identity, and emits records.
- [`RepositoryProjectGraphRecord`](RepositoryProjectGraphRecord.cs) owns the typed,
  line-oriented handoff shared with NuGet resolution.
- [`RunIsolatedRepositoryProjectGraphTask`](RunIsolatedRepositoryProjectGraphTask.cs)
  owns the process and memory boundary.

**Input:** project paths as in-memory MSBuild `ITaskItem`s; project XML and imports on
the filesystem.

**Working output:** one in-memory `ProjectGraph` evaluated in `Debug`, with concrete
inner nodes for all declared TFMs.

**Boundary output:**
`artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json.records`.

The following conceptual records group fields by consumer for readability; field
order here is not the line-format serialization contract:

```csharp
// One evaluated project/TFM configuration.
record Node(
    // Configuration identity used by every later edge and query.
    string ProjectPath,
    string TargetFramework,

    // Repository identity used to map projects to package roots and shipping IDs.
    string PackageId,
    string PackageRoot,
    bool IsClientLibrary,
    bool IsGeneratorLibrary,
    bool IsShippingLibrary,

    // Restore-policy metadata consumed only while constructing the synthetic NuGet
    // PackageSpec. These fields are intentionally omitted from canonical graph JSON.
    bool CentralPackageTransitivePinningEnabled,
    string AssetTargetFallback,
    string PackageTargetFallback,
    string RuntimeIdentifierGraphPath,
    bool TreatWarningsAsErrors,
    string WarningsAsErrors,
    string NoWarn,
    string WarningsNotAsErrors);

record ProjectReference(
    // TFM-aware source and destination configuration identity.
    string ProjectPath,
    string TargetFramework,
    string ReferencedProjectPath,
    string ReferencedTargetFramework,

    // NuGet inclusion and asset-flow metadata. ReferenceOutputAssembly=false keeps
    // the source/input relationship but excludes the P2P edge from restore metadata.
    bool ReferenceOutputAssembly,
    string PrivateAssets,
    string IncludeAssets,
    string ExcludeAssets);

record PackageReference(
    // Direct dependency identity for one project configuration.
    string ProjectPath,
    string TargetFramework,
    string PackageId,
    string VersionSpec,

    // Asset-flow metadata needed by NuGet resolution, not by graph traversal itself.
    string PrivateAssets,
    string IncludeAssets,
    string ExcludeAssets);

record CheckoutRoot(
    // Associates one configuration with a service-level Git pattern. Multiple
    // records represent cross-service linked inputs without retaining exact files.
    string ProjectPath,
    string TargetFramework,
    string Path); // for example, /sdk/core/*
```

The file also contains `GraphGeneration`, `DeclaredProject`, and `Root` records used
for provenance and completeness checks. A representative line-oriented handoff is:

```text
GraphGeneration|Debug|True
Node|.../Azure.Core.csproj|net8.0|Azure.Core|.../sdk/core/Azure.Core|...
ProjectReference|.../Tests.csproj|net8.0|.../Azure.Core.csproj|true|...|net8.0
PackageReference|.../Tests.csproj|net8.0|NUnit|...|4.2.2
CheckoutRoot|.../Azure.Core.csproj|net8.0|/sdk/core/*
```

When input checkout roots are requested, the task evaluates imports, explicit source
and resource items, analyzers, analyzer configuration, Protobuf and TypeScript items,
and local `Reference` hint paths. Each relevant path is immediately reduced to an SDK
service checkout root. Exact files are never emitted.

## Phase 2: External NuGet package resolution

**Related components**

- [`ResolveExternalPackageClosureWithNuGetTask`](ResolveExternalPackageClosureWithNuGetTask.cs)
  reads source records, constructs the synthetic restore topology, and flattens
  repository-package reachability.
- [`RepositoryProjectGraphRecord`](RepositoryProjectGraphRecord.cs) parses the `Node`,
  `ProjectReference`, and `PackageReference` input records and formats closure output.
- [`service.proj`](../../service.proj) runs this task after graph expansion in the same
  isolated child process.

**Input:** the phase-1 record file on the filesystem—not the in-memory `ProjectGraph`.

**Working data:** an in-memory shared `DependencyGraphSpec`, multi-targeted
`PackageSpec`s, NuGet restore requests, and lock-file targets. NuGet's global package
and HTTP caches remain filesystem-backed.

**Boundary output:**
`artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json.packages.records`.

Only repository-relevant closure and completeness information crosses the boundary:

```text
# This project/TFM reaches a repository-owned package through NuGet.
TransitivePackageReference|.../Advisor.csproj|net10.0|Azure.Core

# A known unresolved root makes the canonical artifact incomplete.
UnresolvedPackageClosure|project|TFM|package|version|reason

# Counts, timing, resolution mode, and the explicit non-equivalence contract.
PackageClosureSummary|roots|resolved|derived|unresolved|seconds|
                      nuget-restore-graph|False|True|...
```

The task does not persist or claim authoritative `project.assets.json` output. The
artifact remains `restoreEquivalent=false`; missing package roots fail closed, while
indirect external-package resolution may conservatively over-select.

## Phase 3: Canonical artifact construction

**Related components**

- [`RepositoryProjectGraph.ps1`](../../scripts/RepositoryProjectGraph.ps1) reads both
  record files, validates completeness, builds schema 8, and implements forward and
  reverse queries.
- [`service.proj`](../../service.proj) invokes the PowerShell builder only after the
  isolated graph/NuGet process exits.

**Input:** both line-record files on the filesystem.

**Working data:** in-memory PowerShell dictionaries and sets used to deduplicate
records, merge direct and transitive package paths, and build diagnostics.

**Output:** the canonical filesystem artifact
`artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json`.

```csharp
record CanonicalGraph(
    // Schema/provenance gates prevent stale or incompatible reuse.
    int SchemaVersion,
    string SourceCommit,

    // Physical project metadata is stored once; TargetFrameworks enumerates its
    // concrete configurations without repeating package metadata on every edge.
    Node[] Nodes,

    // Edges remain project/TFM-aware so traversal cannot leak dependencies between
    // target frameworks. Package destinations use repository package identities.
    // Project references retain ReferenceOutputAssembly so reverse dependency selection
    // can match ReferencePath while forward sparse-checkout traversal keeps analyzer inputs.
    ConfigurationEdge[] ConfigurationEdges,

    // Configuration key -> one or more /sdk/<service>/* Git patterns.
    Dictionary<string, string[]> CheckoutRoots,

    // Entry-point and fail-closed consistency information.
    string[] Roots,
    Diagnostics Diagnostics);
```

Restore-only versions, warning properties, fallbacks, and asset filters have completed
their purpose and are not copied into canonical JSON. External package edges are also
removed after paths back to repository packages have been flattened.

## Phase 4: Direct and indirect PackageInfo generation

**Related components**

- [`Package-Properties.ps1`](../../common/scripts/Package-Properties.ps1) defines
  `PackageProps` and maps changed files to directly affected packages.
- [`Language-Settings.ps1`](../../scripts/Language-Settings.ps1) loads .NET package
  metadata, runs the reverse graph query, compares shadow-mode results, and marks
  dependent packages for validation.
- [`Save-Package-Properties.ps1`](../../common/scripts/Save-Package-Properties.ps1)
  writes one `<package>.json` file per selected package.
- [`save-package-properties.yml`](../../common/pipelines/templates/steps/save-package-properties.yml)
  connects package selection to PR matrix generation.
- [`Apply-WeightedBatching.ps1`](../../scripts/Apply-WeightedBatching.ps1) batches
  direct and indirect PackageInfo entries separately for test jobs.

**Input:** the PR diff, repository package metadata, and the canonical graph.

**Working data:** in-memory `PackageProps` objects. Direct changes begin with
`IncludedForValidation=false`; reverse-reachable dependents are marked `true`.

**Output:** PackageInfo JSON files in the matrix seed job's artifact staging directory.
An indirect PackageInfo is the same model as a direct one; only its selection reason
differs:

```csharp
record PackageInfo(
    // Matrix identity and sparse-projection lookup key.
    string ArtifactName,

    // Maps the artifact to every graph configuration below its package directory.
    string DirectoryPath,
    string ServiceDirectory,

    // false: directly changed; true: selected only for dependent validation.
    bool IncludedForValidation);
```

```json
{
  "ArtifactName": "Azure.Some.Dependent",
  "DirectoryPath": "sdk/example/Azure.Some.Dependent",
  "ServiceDirectory": "example",
  "IncludedForValidation": true
}
```

Weighted batching retains one representative PackageInfo file and changes its `ArtifactName` to a
comma-separated scheduling shard such as `Azure.Core,Azure.Identity,Azure.Storage.Blobs`.
Packages with different `CIMatrixConfigs` cannot share a test shard. The generated test job expands
`$(ProjectNames)` back into singleton cases; every original PackageInfo remains available from the
unbatched pipeline artifact.

## Phase 5: Sparse-checkout projection

**Related components**

- [`CreateSparseCheckoutGraphTask`](CreateSparseCheckoutGraphTask.cs) projects the
  canonical graph and PackageInfo files into a compact test-job index.
- [`pr-matrix-presteps.yml`](../../pipelines/templates/steps/pr-matrix-presteps.yml)
  reuses the canonical artifact when available, generates it once otherwise, and
  publishes `TestCheckoutGraph`.

**Input:** canonical graph JSON and PackageInfo JSON files on the filesystem.

**Working data:** typed C# graph models and indexes held in memory for the duration of
the projection.

**Output:** `checkout-graph.json` plus the resolver script, published as the
`TestCheckoutGraph` pipeline artifact.

```csharp
record SparseCheckoutProjection(
    // A test job may consume the projection only for this exact source commit.
    string SourceCommit,

    // ArtifactName -> starting project/TFM configurations.
    Dictionary<string, string[]> Artifacts,

    // Configuration or repository package key -> forward dependency keys.
    Dictionary<string, string[]> Adjacency,

    // Reached configuration -> /sdk/<service>/* patterns.
    Dictionary<string, string[]> Paths,

    // Root files and build/bootstrap directories required by every test job.
    string[] AlwaysIncludedPaths); // /*, !/*/, /eng, /.config, /common
```

Projection validates source commit, schema, `Debug` generation policy, input-root
coverage, NuGet closure completeness, artifact seeds, and SDK-only paths. Failure aborts the
fail-closed matrix seed rather than publishing a narrowed partial result.

## Phase 6: Per-job sparse checkout

**Related components**

- [`Resolve-SparseCheckoutPaths.ps1`](../../scripts/Resolve-SparseCheckoutPaths.ps1)
  performs the per-singleton forward traversal.
- [`New-PipelineValidationInputs.ps1`](ValidateSparseCheckout/New-PipelineValidationInputs.ps1)
  expands a generated job's scheduling shard into one case per artifact.
- [`Add-UnownedTestProjects.ps1`](ValidateSparseCheckout/Add-UnownedTestProjects.ps1)
  turns test projects outside all shipping PackageInfo roots into marked validation-only
  singleton artifacts, failing if any source-graph test project remains uncovered.
- [`Invoke-SparseCheckoutValidation.ps1`](ValidateSparseCheckout/Invoke-SparseCheckoutValidation.ps1)
  promotes every resolver fallback to an error and reuses a clean detached worktree across cases.
- [`ci.tests.yml`](../../pipelines/templates/jobs/ci.tests.yml) downloads
  `TestCheckoutGraph` and unbatched PackageInfo, invokes the singleton runner, and publishes
  per-case sparse-checkout evidence.
- [`sparse-checkout-validation.yml`](../../pipelines/templates/stages/sparse-checkout-validation.yml)
  runs each host matrix in its own stage and limits it to 20 jobs, keeping the complete Linux,
  Windows, and macOS campaign at 60 validation jobs or fewer.

**Input:** a comma-separated test batch containing shipping or validation-only test artifacts,
`checkout-graph.json`, and the expected source commit.

**Working data:** PowerShell hash tables plus a queue and visited set for breadth-first
search.

**Output:** a detached non-cone sparse worktree reused only after `git clean -ffdx`, plus
`sparse-paths.txt`, TRX, logs, binlogs, and JSON evidence for every singleton.

```text
ProjectNames
    -> split scheduling shard into singleton artifacts
    -> for each artifact:
         configuration seeds -> forward BFS through project/package adjacency
         -> reached configurations
         -> union /sdk/<service>/* checkout roots
         -> add unconditional root/eng/.config/common patterns
         -> git clean -ffdx
         -> git sparse-checkout set --no-cone --stdin
         -> setup, build, test, and retain case evidence
    -> report all case failures after the shard finishes
```

An unknown artifact, stale commit, incomplete graph, missing index, unsupported path,
or empty result fails that singleton. The runner continues with the other singleton artifacts in
the scheduling shard, then fails the job after writing a complete summary. Independent matrix jobs
and host stages also continue. Matrix generation may combine additional scheduling buckets to keep
each host stage at 20 jobs or fewer and the three-host campaign at 60 jobs or fewer, but it does not
remove an artifact or configuration. No test command runs from the complete orchestration checkout.

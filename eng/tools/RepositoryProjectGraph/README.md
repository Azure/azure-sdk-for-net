# Repository ProjectGraph dependency selection

This experiment compares two ways to select tests affected by changes to Azure SDK packages:

1. the current `ResolveReferences`-based implementation; and
2. a repository-wide, TFM-aware graph built with MSBuild's strongly typed `ProjectGraph` API.

The two approaches answer approximately the same CI question, but they start from different contracts. `ResolveReferences` computes the physical references needed to compile each project. The ProjectGraph reader computes project and package identity reachability and does not attempt to produce compiler inputs.

## Current `ResolveReferences` design

[`service.proj`](../../service.proj) invokes `ProjectDependsOn` on every candidate project. For a cross-targeting project, [`Directory.Build.Common.targets`](../../Directory.Build.Common.targets) dispatches `ProjectDependsOnInner` to every inner target framework. The inner target depends on `ResolveReferences`, reduces `@(ReferencePath)` to assembly filenames, and checks whether any filename matches a changed package name.

```text
service.proj candidate roots
    -> outer-to-inner TFM dispatch
    -> ProjectDependsOnInner
    -> ResolveReferences
       -> ResolveProjectReferences / GetTargetPath
       -> ResolvePackageAssets
       -> ResolveAssemblyReferences (RAR)
       -> other reference-resolution targets
    -> ReferencePath filenames
    -> changed-package intersection
```

### Benefits

- It reuses the normal SDK build pipeline instead of maintaining a separate dependency model.
- It observes the restored asset selection for the evaluated TFM, including NuGet's version resolution and compile-asset filtering.
- It handles project outputs, framework references, RIDs, assembly conflicts, and other build semantics needed by actual compiler reference resolution.
- It already unions matches from the repository's `net8.0`, `net9.0`, and `net10.0` inner builds.

### Costs and limitations for dependency selection

- The operation fans out across every candidate project and its TFMs. It cannot evaluate the repository once and answer all roots as one graph query.
- `ResolveProjectReferences` may negotiate target paths with referenced projects even when `BuildProjectReferences=false`.
- `ResolvePackageAssets` materializes compile, runtime, analyzer, native, content, and related assets from `project.assets.json`.
- RAR performs physical assembly probing, identity and conflict resolution, framework resolution, and dependency walking.
- The selection target discards almost all of that information and retains only `ReferencePath` filenames.
- Package identity is inferred from assembly filename. This is convenient for Azure SDK packages whose package and assembly names normally align, but it is not a general package-identity contract.
- The `dotnet build` command performs implicit restore unless `--no-restore` is supplied, making runtime sensitive to assets-file state, global-package cache state, and network access.

The implementation therefore asks the build system the broad question, “What exact files would this project compile against?”, when CI only needs to know, “Can this candidate reach one of these repository package identities?”

## ProjectGraph reader design

The experiment separates the calculation into three phases:

1. **Evaluate the source graph once.** `RepositoryProjectGraphTask` constructs one in-process MSBuild `ProjectGraph` over the repository projects. It emits canonical inner configurations for each declared TFM and records evaluated `ProjectReference`, `PackageReference`, package version, package identity, and project metadata.
2. **Complete package-only paths.** The default `ResolveExternalPackageClosureTask` follows external package dependencies that can lead back to a package produced by this repository. It reads package metadata from the NuGet global package folders first and then from configured feeds. An opt-in NuGet restore mode provides a more authoritative comparison, described below. Neither mode resolves physical compiler assemblies through RAR.
3. **Build and query one artifact.** [`RepositoryProjectGraph.ps1`](../../scripts/RepositoryProjectGraph.ps1) writes a schema-versioned graph with diagnostics. The graph supports reverse queries for affected-test selection and forward queries for project or input reachability.

```text
repository projects + declared TFMs
    -> one in-process MSBuild ProjectGraph
    -> evaluated project/package identity records
    -> cache-first external package metadata closure
    -> schema-versioned graph artifact + diagnostics
       -> reverse affected-test query
       -> forward project/input query
```

There is no MSBuild process spawned per inner project. `ProjectGraph` still performs real MSBuild evaluation, including imports, properties, conditions, central package versions, and TFM-specific items; it is not a lightweight XML parser.

### External package resolution modes

`RepositoryProjectGraphPackageResolutionMode` selects the external package phase:

- **`IsolatedMetadata` (default)** uses repository-owned, cache-first dependency metadata traversal. It is the performance baseline and resolves each root independently.
- **`NuGetRestore` (experimental)** builds one shared `DependencyGraphSpec` containing a multi-targeted `PackageSpec` for every evaluated project. It preserves every actual `PackageReference`, including repository package IDs, and each TFM-specific P2P edge as a `ProjectRestoreReference`. NuGet's `DependencyGraphSpecRequestProvider` and `RestoreCommand` resolve rooted projects with a shared provider cache and bounded project-level concurrency. The task reads each in-memory `LockFile` and emits only compile-capable external paths back to repository package identities.

The NuGet mode deliberately reuses the versions, asset filters, target-framework fallbacks, runtime graph paths, and P2P references already produced by MSBuild evaluation instead of recreating central package management. It rejects `CentralPackageTransitivePinningEnabled=true`, which would require additional central-package semantics. Solver inputs are not filtered by repository ownership: local package roots and dependencies contributed by referenced projects remain available to NuGet's aggregate direct-dependency wins, shared transitive version selection, and framework asset choice. Repository ownership is applied only when filtering resolved paths for the graph artifact.

The synthetic restore does not commit `project.assets.json`, dependency graph, or no-op cache files. It can reuse installed packages and HTTP metadata through NuGet's normal caches, but missing selected packages are still downloaded and extracted. Consequently it has no persisted no-op restore path yet.

The NuGet mode is still marked `restoreEquivalent=false` until broader lock-file comparison validates the remaining project restore properties and intentionally OS-neutral target set. The artifact exposes project context count, restore request count, selected package count, unresolved roots, and the non-equivalence flag in diagnostics.

Enable the comparison with:

```text
/p:RepositoryProjectGraphPackageResolutionMode=NuGetRestore
```

### Benefits

- The output contract is limited to identities and reachability, avoiding physical reference and assembly-conflict resolution.
- Each project configuration is represented in one graph construction rather than being orchestrated as a target over every candidate root.
- Project and package identities are explicit rather than reconstructed from output filenames.
- TFM-specific edges are preserved in the artifact and deliberately unioned by the current queries.
- One artifact can support both forward and reverse analysis.
- The schema and diagnostics make missing projects, duplicate package IDs, conflicting node metadata, and unresolved package metadata visible. Queries fail when the artifact is incomplete.
- External package metadata is deduplicated within the operation and can be served from the immutable global package cache.

### Costs and semantic differences

- `ProjectGraph` evaluation has a substantial fixed CPU and memory cost. It evaluates the repository graph even when a particular changed-package query touches only a small subset.
- The experiment adds repository-owned C#, PowerShell, a graph schema, diagnostics, tests, and NuGet protocol behavior that must be maintained as MSBuild, NuGet, and repository conventions evolve.
- External metadata resolution is sensitive to the package cache and network. A cold cache can erase part of the source-graph performance advantage.
- Package closure is explicitly marked `restoreEquivalent=false`. The default mode selects versions for isolated package paths; the NuGet mode preserves the complete evaluated package/P2P topology but has not yet reproduced and compared every normal restore property.
- Direct `PackageReference` compile asset filters are applied in both modes. The default metadata mode does not consistently preserve transitive dependency asset filters and records `transitiveDependencyAssetFiltersApplied=false`; the NuGet mode consumes the lock file and records it as `true`.
- The package-only phase does not reproduce all lock-file, RID-specific, conflict-resolution, source-mapping, or other restore behavior. These differences can produce false-positive or false-negative reachability if repository assumptions change.
- The graph deliberately models the union of declared TFMs and does not add an OS-specific query dimension. Host-dependent MSBuild conditions remain an assumption of the repository analysis.
- The task currently requires the repository's .NET 10 SDK and reached approximately 2.24 GiB peak process working set in a local full-graph measurement.

## Performance observed during the experiment

These results are end-to-end command timings, not isolated target timings:

| Implementation | CI time | Notes |
| --- | ---: | --- |
| Current `ResolveReferences` | 3:57 | Same experimental CI run; `dotnet build` includes implicit restore |
| ProjectGraph plus package closure | 1:29 | Same run; package cache had an exact-key miss |
| Target-dispatched repository source graph | 1:10 | Same run; does not include external package closure |
| ProjectGraph before package closure | 0:48 | Earlier CI run; not a same-run comparison |

On a local warm-cache run, the complete ProjectGraph command took approximately 1:04: graph construction took 38.4 seconds and package closure took 5.8 seconds. CI package closure added roughly 42 seconds compared with the earlier reader experiment, illustrating that package-cache state is a first-order variable.

The latest ProjectGraph implementation was still about 2 minutes 28 seconds, or 62%, faster than `ResolveReferences` in the same CI run. It was about 19 seconds slower than the simpler source graph because it pays for more faithful ProjectReference evaluation and external package closure.

The initial external-only NuGet experiment took 1:27.9 end to end. ProjectGraph construction took 47.5 seconds and NuGet resolved 2,906 project/TFM contexts, canonicalized to 440 unique contexts, in 20.2 seconds at context DOP 4. Peak process RSS was approximately 2.01 GiB. The run selected 19,735 package instances and produced the same 74 unique project/TFM/repository-package reachability edges as the default metadata resolver.

That run deliberately failed closed for 41 direct roots in five aggregate contexts. Three Batch test TFMs exposed a Newtonsoft.Json version conflict because a source project that supplies the winning direct dependency is outside the phase-one synthetic topology. Two Service Bus TFMs omitted the local `Microsoft.Extensions.Azure` package root, whose published dependencies make normal restore select `Microsoft.Extensions.Configuration.Binder` 10.0.3; the remaining external-only context instead tried to select uncached Binder 3.0.3, whose Azure Artifacts upstream download returned 401 in the local orb. These failures are evidence that both P2P topology and local package roots can influence the external package solve. A global-package cache would avoid that particular download but would not correct the semantic difference. An isolated-root fallback would hide these signals and is therefore not part of the spike.

After preserving all local package roots and P2P topology, full local commands took between 1:16.2 and 1:22.5 end to end. ProjectGraph construction took 42.9–46.7 seconds and NuGet resolved 973 multi-target project requests covering all 2,906 project/TFM contexts in 11.6–14.1 seconds at project DOP 4. Peak process RSS was approximately 2.24 GiB. All 15,966 external direct roots resolved, the artifact was complete, and the reverse query selected the same 465 project/package roots as the metadata implementation. Its 74 unique project/TFM/repository-package reachability edges exactly matched the default metadata resolver. The prior Batch and Service Bus failures disappeared; Binder 3.0.3 remained absent from the global cache, while normal assets select Binder 10.0.3 and Newtonsoft.Json 13.0.4. These runs had a warmer cache than the first external-only experiment and are not cold-cache comparisons.

An interleaved default-mode run took 1:13.6 end to end, including 45.6 seconds for ProjectGraph construction and 7.4 seconds for isolated metadata closure. The complete-topology NuGet mode therefore added approximately 4–7 seconds in the package phase across these warm local measurements; end-to-end variance was dominated by ProjectGraph construction. Both modes produced byte-identical 465-line query outputs, and all 79 transitive records matched through project, TFM, repository package, external root, and selected root version; only dependency-path formatting differed.

These measurements do not yet attribute the legacy time among restore, project evaluation, `ResolveProjectReferences`, `ResolvePackageAssets`, and RAR. A binlog from both an end-to-end run and a warm `--no-restore` run is needed before assigning percentages or proposing a targeted optimization to the native targets.

## Design trade-off summary

| Dimension | `ResolveReferences` | ProjectGraph reader |
| --- | --- | --- |
| Primary contract | Exact compiler reference files | Project/package identity reachability |
| Semantic authority | Build and restored assets | Evaluated MSBuild graph plus isolated metadata or shared-topology NuGet lock files |
| TFM handling | Dispatch target to every inner build, then union | Preserve TFM-specific edges, then union at query time |
| Project references | Resolve/obtain referenced output paths | Read evaluated graph edges |
| External packages | Consume NuGet's resolved assets | Traverse cache/feed metadata by default; optionally run NuGet over a shared package/P2P restore graph |
| Assembly resolution | Full RAR behavior | None |
| Restore equivalence | Yes, when assets are current | No; explicitly diagnosed |
| Work shape | Many project/TFM target invocations | One graph construction plus shared closure |
| Query reuse | Produces one selection result | Artifact supports forward and reverse queries |
| Failure behavior | Normal build/restore failures | Fails closed on incomplete graph or unresolved metadata |
| Resource profile | Higher elapsed time; established build caches | Lower elapsed time; high in-process memory and cold-cache sensitivity |
| Maintenance | Mostly SDK-owned | Repository owns graph and package-resolution semantics |

## Recommended boundary

The experiment supports using a specialized identity graph for CI dependency selection while retaining `ResolveReferences` for builds. Changing `ResolveReferences` itself to skip package assets, project output negotiation, or RAR would violate its physical-reference contract and could break downstream build targets.

If this capability is generalized upstream, the safer abstraction is a sibling target or API such as `ResolveDependencyIdentities`:

- accept or construct one evaluated `ProjectGraph`;
- expose TFM-aware project and package identities;
- optionally consume restore-produced package identities or a package metadata provider;
- answer graph reachability without producing `ReferencePath`; and
- preserve explicit diagnostics when its result is not restore-equivalent.

For this repository, productionization should retain oracle comparison against resolved references, measure warm and cold cache paths separately, and treat a change in TFM, package, or asset-filtering assumptions as a correctness change rather than only a performance optimization.

# Repository ProjectGraph dependency selection

Repository dependency selection uses a repository-wide, TFM-aware graph built with
MSBuild's strongly typed `ProjectGraph` API. During rollout, CI also evaluates the
existing `ResolveReferences` implementation and reports disagreements without
blocking the matrix.

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

The implementation separates the calculation into three phases:

1. **Evaluate the source graph once.** `RepositoryProjectGraphTask` constructs one in-process MSBuild `ProjectGraph` over the repository projects. It emits canonical inner configurations for each declared TFM and records evaluated `ProjectReference`, `PackageReference`, package version, package identity, and project metadata.
2. **Complete package-only paths.** CI passes every compile-capable direct package root, including packages produced by this repository, through NuGet's restore engine with the complete evaluated P2P topology. The resulting lock-file targets are flattened to project/TFM-to-repository-package reachability records. This phase does not resolve physical compiler assemblies through RAR.
3. **Build and query one artifact.** [`RepositoryProjectGraph.ps1`](../../scripts/RepositoryProjectGraph.ps1) writes a schema-versioned graph with diagnostics. Schema 7 contains repository-relevant `(project, TFM)` reachability edges, a compact configuration-to-SDK-checkout-root index, and the single Debug generation policy. Queries traverse each root configuration independently and union the resulting physical package roots only after reachability is complete.

```text
repository projects + declared TFMs
    -> one in-process MSBuild ProjectGraph
    -> evaluated project/package identity records
    -> complete-topology NuGet restore graph
    -> schema-v7 configuration graph + diagnostics
       -> per-configuration reachability
       -> union physical project/package roots
```

There is no MSBuild process spawned per inner project. `ProjectGraph` still performs real MSBuild evaluation, including imports, properties, conditions, central package versions, and TFM-specific items; it is not a lightweight XML parser. Repository graph evaluation sets `EnableDefaultItems=false`: every reached SDK project already contributes its service checkout root, so SDK-default items beneath that root add no sparse-checkout coverage. Explicit items, linked files, imports, analyzers, and hint paths remain evaluated and can contribute additional SDK service roots.

The graph always evaluates `Debug`, matching the established `ProjectDependsOn` dependency query, and preserves every declared target framework. This keeps one entry point per physical project while retaining TFM-specific dependencies and input-derived SDK roots. Dependency-only nodes created by additional global properties fail generation until a future schema preserves that identity. The artifact records its source commit, `Debug` generation policy, and whether input checkout roots were evaluated so consumers can safely reuse only a compatible result.

The artifact is a reachability model rather than a dump of restore or file inputs. It omits external-package edges after the NuGet phase has flattened any paths back to repository packages and merges direct and transitive repository-package reachability. Evaluated project files and explicit inputs are reduced immediately to `/sdk/<service>/*` roots; exact file records, generated `artifacts` paths, and paths already covered by the unconditional root/`eng`/`.config`/`common` cone are not emitted. This keeps the line-record handoff and schema-7 JSON proportional to graph structure rather than file count. Restore-only metadata remains in the isolated intermediate records and package-resolution diagnostics instead of being repeated on every JSON edge.

[`RepositoryProjectGraphRecord.cs`](RepositoryProjectGraphRecord.cs) owns the private line-record contract shared by the MSBuild graph and NuGet tasks. Its typed node, P2P, package, checkout-root, and derived-package records keep field ordering and validation out of task logic. The intermediate node and reference records contain only properties consumed by either NuGet resolution or the schema-7 artifact builder; NuGet path provenance is collapsed to one repository-package reachability record per project/TFM/package identity.

MSBuild outer-build references connect to each concrete destination inner build. The source graph preserves all of those destination configurations rather than applying a repository-owned nearest-framework reduction. This can conservatively over-select configurations, but it cannot discard an edge that MSBuild exposed. NuGet's synthetic P2P metadata remains path-based and deduplicates those records by referenced project, leaving compatibility selection to restore.

### External package resolution

The package phase builds one shared `DependencyGraphSpec` containing a multi-targeted
`PackageSpec` for every evaluated project. It preserves every actual
`PackageReference`, including repository package IDs, and each TFM-specific,
restore-contributing P2P edge as a `ProjectRestoreReference`. As in normal NuGet
restore, references with `ReferenceOutputAssembly=false` remain in the source graph
but are excluded from restore metadata. NuGet's `DependencyGraphSpecRequestProvider`
and `RestoreCommand` resolve rooted projects with a shared provider cache and bounded
project-level concurrency. The task reads each in-memory `LockFile`, follows local
and external package paths, and emits compile-capable paths back to repository package
identities.

The NuGet mode deliberately reuses the versions, asset filters, target-framework fallbacks, runtime graph paths, and P2P references already produced by MSBuild evaluation instead of recreating central package management. It rejects `CentralPackageTransitivePinningEnabled=true`, which would require additional central-package semantics. Solver inputs are not filtered by repository ownership: all compile-capable direct package roots and dependencies contributed by referenced projects remain available to NuGet's aggregate direct-dependency wins, shared transitive version selection, and framework asset choice. Traversal also continues through local packages, because a repository package can itself lead through packages back to another repository package. Repository ownership is applied only when filtering resolved paths for the graph artifact.

The synthetic restore does not commit `project.assets.json`, dependency graph, or no-op cache files. It can reuse installed packages and HTTP metadata through NuGet's normal caches, but missing selected packages are still downloaded and extracted. Consequently it has no persisted no-op restore path yet.

The NuGet mode is still marked `restoreEquivalent=false` until broader lock-file comparison validates the remaining project restore properties and intentionally OS-neutral target set. The artifact exposes project context count, restore request count, selected package count, unresolved roots, and the non-equivalence flag in diagnostics.

### Benefits

- The output contract is limited to identities and reachability, avoiding physical reference and assembly-conflict resolution.
- Each project configuration is represented in one graph construction rather than being orchestrated as a target over every candidate root.
- Project and package identities are explicit rather than reconstructed from output filenames.
- TFM-specific edges are preserved in the artifact. Queries traverse `(project, TFM)` configurations without combining paths from different TFMs, then deduplicate reached physical roots.
- One artifact can support both forward and reverse analysis.
- The schema and diagnostics make inferred or missing configuration edges, missing projects, duplicate package IDs, conflicting node metadata, and unresolved package metadata visible. NuGet-mode queries fail unless the configuration graph is exact and the artifact is complete.
- External package metadata is deduplicated within the operation and can be served from the immutable global package cache.

### Costs and semantic differences

- `ProjectGraph` evaluation has a substantial fixed CPU and memory cost. It evaluates the repository graph even when a particular changed-package query touches only a small subset.
- The implementation adds repository-owned C#, PowerShell, a graph schema, diagnostics, tests, and NuGet protocol behavior that must be maintained as MSBuild, NuGet, and repository conventions evolve.
- External metadata resolution is sensitive to the package cache and network. A cold cache can erase part of the source-graph performance advantage.
- Package closure is explicitly marked `restoreEquivalent=false`. The complete evaluated package/P2P topology has not yet reproduced and compared every normal restore property.
- Direct `PackageReference` compile asset filters are applied, and the NuGet lock-file traversal records `transitiveDependencyAssetFiltersApplied=true`.
- The package-only phase does not reproduce all lock-file, RID-specific, conflict-resolution, source-mapping, or other restore behavior. These differences can produce false-positive or false-negative reachability if repository assumptions change.
- The graph deliberately models the union of declared TFMs and does not add an OS-specific query dimension. Host-dependent MSBuild conditions remain an assumption of the repository analysis.
- Build logic that derives dependencies from the presence of SDK-default items is not represented while `EnableDefaultItems=false`. The repository currently has no such dependency logic; adding it requires either an explicit graph input/reference or removal of this optimization.
- The task currently requires the repository's .NET 10 SDK. Repository-wide Debug evaluation has used roughly 2–3 GiB without input-derived checkout roots; checkout-root-enabled measurements must be tracked separately. See [`SPARSE_CHECKOUT.md`](SPARSE_CHECKOUT.md) for the current CI validation scope.

## Performance

Graph evaluation has a substantial fixed memory cost. Current Debug checkout-root-enabled
sparse-checkout validation is recorded in [`SPARSE_CHECKOUT.md`](SPARSE_CHECKOUT.md).
Package-cache state remains a first-order runtime variable, so compare cold and warm
measurements separately.

## Design trade-off summary

| Dimension | `ResolveReferences` | ProjectGraph reader |
| --- | --- | --- |
| Primary contract | Exact compiler reference files | Project/package identity reachability |
| Semantic authority | Build and restored assets | Evaluated MSBuild graph plus shared-topology NuGet lock files |
| TFM handling | Dispatch target to every inner build, then union | Traverse explicit project/TFM configurations, then union physical roots |
| Project references | Resolve/obtain referenced output paths | Read evaluated graph edges |
| External packages | Consume NuGet's resolved assets | CI runs NuGet over the complete evaluated package/P2P topology |
| Assembly resolution | Full RAR behavior | None |
| Restore equivalence | Yes, when assets are current | No; explicitly diagnosed |
| Work shape | Many project/TFM target invocations | One graph construction plus shared closure |
| Query reuse | Produces one selection result | Artifact supports forward and reverse queries |
| Failure behavior | Normal build/restore failures | Fails closed on incomplete graph or unresolved metadata |
| Resource profile | Higher elapsed time; established build caches | Lower elapsed time; high in-process memory and cold-cache sensitivity |
| Maintenance | Mostly SDK-owned | Repository owns graph and package-resolution semantics |

## Recommended boundary

The specialized identity graph is used for CI dependency selection while
`ResolveReferences` remains part of normal builds. Changing `ResolveReferences` itself
to skip package assets, project output negotiation, or RAR would violate its
physical-reference contract and could break downstream build targets.

If this capability is generalized upstream, the safer abstraction is a sibling target or API such as `ResolveDependencyIdentities`:

- accept or construct one evaluated `ProjectGraph`;
- expose TFM-aware project and package identities;
- optionally consume restore-produced package identities or a package metadata provider;
- answer graph reachability without producing `ReferencePath`; and
- preserve explicit diagnostics when its result is not restore-equivalent.

For rollout, `Language-Settings.ps1` computes both implementations. The
`UseRepositorySourceGraph` pipeline parameter is enabled by default, making the
repository source graph authoritative. Set it to `false` to run the graph in shadow
mode while selecting the ResolveReferences result. A disagreement emits Azure DevOps
warning code `RepositorySourceGraphMismatch`, plus stable result and authority log
markers for later queries.

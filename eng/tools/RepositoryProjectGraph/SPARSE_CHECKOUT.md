# ProjectGraph-driven test sparse checkout

## Scope and data flow

This integration narrows only the PR test jobs emitted by
`generate_target_service_test_matrix`. Matrix selection, direct/indirect package
classification, batching, and each job's `ProjectNames` remain unchanged.

1. During package selection, `Language-Settings.ps1` constructs the reverse-dependency
   graph at the canonical service.proj path
   `artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json`.
   When checkout narrowing is enabled, it requests the `Debug`, input-enabled
   NuGet graph needed by both dependency analysis and sparse checkout.
2. The matrix seed reuses that artifact when its commit, generation policy, schema,
   and completeness diagnostics match. Passes that skip dependency analysis construct
   the same canonical graph once as a fallback.
3. `RepositoryProjectGraphTask` emits deduplicated checkout-root records alongside exact
   input records, and schema 6 groups them into a compact configuration index.
   `CreateSparseCheckoutGraphTask` then uses a typed `System.Text.Json` stream to skip the
   large exact `inputs` value and publishes artifact seeds, configuration/package adjacency,
   and checkout roots.
4. Each fanned-out test job runs `Resolve-SparseCheckoutPaths.ps1`. The resolver
   traverses only its comma-separated `ProjectNames` batch and extracts the path
   union before the existing sparse checkout step.
5. Missing, malformed, incomplete, dirty, or stale graph data returns no paths.
   The test job then uses the existing full-checkout fallback.

```text
package selection
    -> one canonical RepositoryProjectGraph

matrix seed (same full checkout)
    -> reuse canonical graph (or generate if absent)
    -> typed projection from compact graph indexes
    -> publish TestCheckoutGraph

test batch
    -> artifact seeds for ProjectNames
    -> forward BFS
    -> checkout path union
    -> sparse checkout
```

The previous implementations either rescanned every graph node and input for every
artifact, at a cost of `artifacts × (nodes + inputs)`, or allocated the complete
186,000-record input collection in PowerShell before regrouping it. The current design
coarsens each input as the canonical artifact is built, skips exact inputs during typed
projection, and makes each test job pay only for its reachable subgraph.

## Correctness boundary

This is conservative repository identity reachability, not proof of normal
restore/build equivalence. The source graph continues to report
`restoreEquivalent=false`.

- **Target frameworks:** schema 6 preserves source-TFM to destination-TFM edges.
  When MSBuild exposes an outer-build project reference, every concrete destination
  inner build is retained. Checkout may over-select incompatible destination TFMs,
  but it does not invent a nearest-framework policy that could omit source.
- **Build configuration:** the graph always evaluates `Debug`, matching the existing
  `ProjectDependsOn` query used to select dependent tests. PR test sparse checkout
  therefore adds no second build-configuration dimension to repository evaluation.
  Duplicate records are removed in the task before PowerShell builds the JSON artifact.
- **Test reference modes:** the source graph is evaluated in normal package-reference
  mode so the complete synthetic NuGet restore remains valid. The checkout projection
  follows each reached repository package into every configuration of its shipping
  source project. This conservative expansion supplies the recursive source closure
  required when a matrix job sets `UseProjectReferenceToAzureClients=true`, without
  constructing a second MSBuild graph.
- **Artifact seeds:** every project below an artifact's `PackageInfo.DirectoryPath` is
  a seed, along with projects that explicitly report that package root. Test projects
  commonly infer nested roots such as `tests`; using only exact package-root matches
  would omit test-only dependencies outside the artifact's SDK directory.
- **Repository packages:** direct and NuGet-derived repository package identity edges
  are retained. `ReferenceOutputAssembly=false` P2P edges remain in the source/input
  graph but are excluded from synthetic NuGet restore metadata.
- **Inputs:** captured inputs include imports, `Compile`, `None`, `Content`,
  `EmbeddedResource`, `AdditionalFiles`, local `Reference` hint paths, analyzers,
  analyzer config files, Protobuf, TypeScript, application/page/resource items,
  splash screens, and native references. Repository-relative inputs are conservatively
  coarsened while their exact records are emitted. Roots that contain only generated or
  otherwise untracked files simply match no files during Git sparse checkout.
- **Checkout roots:** selected or reached SDK projects become
  `/sdk/<service>/*`. Non-SDK linked inputs retain a narrower containing-directory
  root. Only repository root files, `/eng`, and `/.config` are unconditional; SDK
  services are selected by graph reachability rather than a hard-coded allowlist.
- **Provenance:** the source artifact records its Git commit and generation policy.
  Projection requires the same `Build.SourceVersion`, `Debug`, and evaluated
  inputs, verifies `HEAD`, and rejects tracked worktree changes. Every test job verifies
  the same commit before using the projected graph.
- **Identity:** schema 6 rejects dependency-only global-property nodes and
  fails rather than silently dropping an alternate MSBuild node that its path/TFM
  identity cannot represent.

The compact graph explicitly recognizes `ProjectReference` and `PackageReference`
configuration edges. A new edge kind, unknown artifact,
duplicate malformed artifact, missing index, unresolved package root, or non-NuGet
source graph causes a full-checkout fallback.

## Failure and observability behavior

Graph generation is an optimization and must not prevent matrix generation. The
seed job catches graph/projection failures and publishes an explicit incomplete
`checkout-graph.json`. Test jobs log:

- `SPARSE_CHECKOUT_GRAPH_RESULT=available|fallback` in the seed job;
- `REPOSITORY_PROJECT_GRAPH_RESULT=reused|generated` in the seed job;
- `SPARSE_CHECKOUT_RESULT=narrowed pathCount=<n>|full` in each test job; and
- graph/project/configuration/edge/input/artifact counts, projection bytes, phase times,
  peak working set,
  plus each query's artifact, reachable-node, and path counts.

The fallback is intentionally broad. A known-partial graph is never used to narrow
a checkout.

## Productionization findings and validation (2026-08-26)

The first hosted PR run failed in `generate_target_service_test_matrix` after one
hour. The source graph itself completed in 49.74 seconds at about 2.54 GiB working
set and emitted 532,685 raw input records. The old per-artifact map loop then ran
without output for roughly 46 minutes until cancellation. This established the map
algorithm—not ProjectGraph construction—as the immediate timeout.

The initial implementation also evaluated Release and attempted to collapse it into
the same path/TFM model. That doubled entry points, increased a complete local run to
about 6.2 GiB peak RSS, and diverged from the established dependency-selection query.
The configuration-list support and cross-configuration merge were removed. The
current graph evaluates one Debug entry point per physical project and still expands
every declared TFM; a fresh hosted input-enabled benchmark is required after this change.

An earlier representative four-artifact projection over the full graph completed in 33.26
seconds, used about 1.64 GiB peak RSS, and produced a 3,305,237-byte checkout graph.
Representative closures were:

- `Azure.Data.SchemaRegistry`: 42 reachable keys, 10 paths;
- `Azure.Provisioning.PostgreSql`: 43 reachable keys, 13 paths;
- `Microsoft.Azure.WebJobs.Extensions.EventHubs`: 57 reachable keys, 11 paths; and
- `Azure.Template`: 28 reachable keys, 8 paths.

The projected paths included linked `common` inputs and graph-derived `core`,
`identity`, `resourcemanager`, `tools`, and cross-service SDK roots without keeping
those services in the unconditional checkout cone.

Focused validation also showed:

- standard ProjectGraph `IsGraphBuild` behavior and explicit `IsGraphBuild=false`
  produced byte-identical source records and identical package closure records apart
  from elapsed-time diagnostics, so the nonstandard override was removed.
- evaluating the repository only with `UseProjectReferenceToAzureClients=true`
  made 24 synthetic restore roots fail on a Batch package-downgrade combination,
  confirming that one normal graph plus conservative checkout expansion is safer
  than replacing the source graph with project-reference mode.
- every one of the 27,089 ProjectReference records from that project-reference
  evaluation was audited against the normal-mode checkout projection. All 2,933
  source configurations reached the exact destination configuration and checkout
  root. The audit found and fixed one NuGet package-ID casing mismatch before the
  result reached zero missing edges.
- the task build and focused Pester suites cover configuration conflicts,
  dependency-only nodes, `ReferenceOutputAssembly=false`, all-inner destination
  edges, analyzer inputs, case-insensitive repository package expansion, transitive
  package edges, stale provenance, duplicate artifacts, and full-checkout fallback.
  The graph suite passed 14/14 and the sparse projection suite passed 5/5.
- a local sparse clone using the Schema Registry closure restored and built the full
  `UseProjectReferenceToAzureClients=true` source closure. Test execution then aborted
  because this arm64 host has no x64 .NET test host, not because a checkout input was
  missing.

The first broad hosted run of the pushed sparse integration passed the engineering
script CI, matrix generation, and the Windows, Linux, and macOS test jobs except for
one Linux net9 project-reference batch. That batch selected `System.ClientModel` but
omitted `common/Perf/Azure.Test.Perf`, a direct dependency of a nested perf test
project, and then failed to compile its `BenchmarkDotNet` usages. The artifact-seed
rule above fixes that concrete gap; the real repository graph now reaches all three
`Azure.Test.Perf` configurations from 23 `System.ClientModel` descendant seed
configurations. The correction has focused local coverage but has not yet had a
hosted rerun.

## Remaining limitations

- Custom targets can consume arbitrary files that are not represented by evaluated
  items or imports. Whole reached SDK services and the build/bootstrap cone cover
  current repository patterns, but a new cross-service custom input must be exposed
  as an evaluated item/import or sparse checkout must be disabled for it.
- The graph is the host-neutral union of declared compile TFMs. It does not model an
  OS or RID query dimension and must not be used to claim runtime-asset equivalence.
- The manually assembled NuGet spec is deliberately not authoritative static-restore
  output. Missing roots fail closed; indirect package closure may conservatively
  over-select.
- The Debug input-enabled graph still has a substantial fixed memory cost. Hosted
  validation should establish its current runtime and agent headroom before enabling
  this optimization outside the PR test path.
- The hosted matrix has exercised Windows, Linux, and macOS net8/net9/net10 plus
  Windows net462 legs, but the corrected artifact seeding still needs a rerun and
  explicit full-versus-sparse output comparisons across linked-input and
  cross-service representatives.

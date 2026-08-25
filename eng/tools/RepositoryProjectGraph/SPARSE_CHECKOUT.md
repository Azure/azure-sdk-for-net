# ProjectGraph-driven test sparse checkout

## Scope and data flow

This integration narrows only the PR test jobs emitted by `generate_target_service_test_matrix`. The normal matrix selection, direct/indirect package classification, batching, and `ProjectNames` values remain unchanged.

1. The matrix seed job saves the selected package metadata as before.
2. `GenerateRepositoryProjectGraphWithProjectGraph` evaluates every repository source/test project with MSBuild `ProjectGraph` for both `Debug` and `Release`, including every declared target framework. It records exact source-TFM to destination-TFM project edges, direct package edges, NuGet-resolved repository-package edges, and evaluated repository inputs.
3. `Create-SparseCheckoutMap.ps1` seeds each selected artifact with every graph project beneath its package directory, unions all of its build/TFM configurations, follows configuration edges, maps reached repository packages back to shipping projects, and collapses reached files to checkout roots.
4. The seed job publishes one map. Each generated test job resolves the union for its unchanged `ProjectNames` batch before the existing sparse-checkout step.
5. Missing artifacts or an unavailable map make that test job use the previous full-SDK checkout. An incomplete graph, unresolved repository-package closure, conflicting configuration data, or a non-NuGet graph fails map generation rather than omitting paths.

The graph captures `MSBuildAllProjects`, `Compile`, `None`, `Content`, `EmbeddedResource`, `AdditionalFiles`, and local `Reference` `HintPath` inputs. Root files and existing always-included directories are not repeated in artifact mappings.

## Correctness boundary

This is conservative repository identity reachability, **not** proof of normal restore/build equivalence. It uses official MSBuild `ProjectGraph` topology and NuGet's resolver, but the conversion to canonical project/TFM records and the synthetic restore graph remain repository-owned. The graph continues to report `restoreEquivalent=false`.

The sparse selector specifically addresses known risks as follows:

- **TFMs:** traversal starts from all evaluated TFMs and retains selected destination TFMs on P2P edges.
- **Build configurations:** Debug and Release are evaluated together. Their edges are unioned for checkout safety; conflicting restore properties or package versions fail closed.
- **Repository packages:** package IDs, not assembly filenames, drive NuGet-derived reachability. In NuGet mode package nodes are terminal during traversal and map to physical shipping projects only at output time.
- **Inputs:** tracked evaluated files and local hint paths can add SDK or non-SDK directories.
- **Matrix behavior:** matrix generation is unchanged; narrowing consumes its final `ProjectNames` values.

Remaining semantic gaps include RID/OS-specific dependencies, custom target inputs that are not represented by captured items/imports, configuration dimensions other than Debug/Release, full MSBuild global-property identity, `ReferenceOutputAssembly=false` treatment in the synthetic restore model, and lack of exhaustive parity with ordinary static-graph restore assets. CI should broaden or fall back on any completeness failure, never continue with a known-partial map.

## Local validation (2026-08-25)

Commands were run from the repository root in a Linux Amp orb with .NET SDK 10.0.400.

| Check | Command | Result |
|---|---|---|
| Task build | `dotnet build eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj --no-restore -v:minimal` | Passed, 0 warnings, 0 errors (8.42 s). |
| Graph/query regression tests | `pwsh -NoProfile -Command '$r = Invoke-Pester -PassThru -Output Detailed eng/scripts/tests/RepositoryProjectGraph.Tests.ps1; if ($r.FailedCount) { exit 1 }'` | Passed 13/13. Covers mixed TFMs, configuration-only edges, NuGet P2P/local-package contributions, HintPath inputs, and oracle queries. |
| Sparse map/resolver tests | `pwsh -NoProfile -Command '$r = Invoke-Pester -PassThru -Output Detailed eng/scripts/tests/SparseCheckout.Tests.ps1; if ($r.FailedCount) { exit 1 }'` | Passed 3/3. Covers TFM union, repository packages, cross-service inputs, batch union, and fail-closed behavior. |
| Full graph | `dotnet msbuild /m /nr:false /nologo /tl:off /t:GenerateRepositoryProjectGraphWithProjectGraph eng/service.proj /p:SkipServiceProjectImports=true /p:RepositoryProjectGraphConfigurations=Debug%3BRelease /p:RepositoryProjectGraphReaderPath=/tmp/sparse-e2e-final/graph.json /p:RepositoryProjectGraphReaderRecordsPath=/tmp/sparse-e2e-final/project.records /p:RepositoryProjectGraphPackageRecordsPath=/tmp/sparse-e2e-final/package.records /p:RepositoryProjectGraphNuGetRestoreDirectory=/tmp/sparse-e2e-final/nuget-restore /p:RepositoryProjectGraphPackageResolutionMode=NuGetRestore /p:IncludeRepositoryProjectGraphInputs=true` | Passed in 3:14.35, peak RSS 4,830,864 KB. Complete graph: 973 projects, 2,906 project/TFM configurations, 38,406 configuration edges, 166,094 inputs, 22,557/22,557 NuGet roots resolved, zero unresolved. |
| Representative map | `pwsh -NoProfile -File eng/scripts/Create-SparseCheckoutMap.ps1 -PackageInfoDirectory artifacts/tmp/sparse-e2e/package-info -RepoRoot . -GraphPath /tmp/sparse-e2e-final/graph.json -OutputPath /tmp/sparse-e2e-final/checkout-map.json` | Passed for `Azure.Data.SchemaRegistry` and `Azure.Template` in 41.92 s, peak RSS 1,398,496 KB. Schema Registry selected `core`, `eventhub`, `identity`, `schemaregistry`, `servicebus`, and `tools`. |
| Matrix behavior | `Create-PrJobMatrix.ps1` with the repository platform matrix, Schema Registry direct and Template indirect, Linux filters | Preserved 3 direct jobs (net8 Debug package refs, net9 Release project refs, net10 Debug package refs) and 1 indirect net9 Release job; each retained the expected `ProjectNames`. |
| Full vs sparse test | `dotnet test sdk/schemaregistry/Azure.Data.SchemaRegistry/tests/Azure.Data.SchemaRegistry.Tests.csproj --framework net10.0 --filter 'TestCategory!=Live'` in the full tree and a local sparse clone using the generated paths | Both passed: 86 passed, 76 skipped, 162 total. Full 20.74 s; sparse 30.66 s from a cold clone. |

The all-framework Schema Registry comparison was also attempted. Build/restore succeeded, net10 tests passed, but the orb lacks the net8/net9 runtimes, so those two test hosts aborted. The explicit net10 comparison above avoids presenting that environment limitation as a sparse-checkout failure.

## Concerns and follow-up

- **Performance:** evaluating Debug and Release together intentionally trades memory for conservative coverage. The full graph run and map deserialization are the main costs; measure on hosted CI agents before broadening beyond this PR test path.
- **Artifact size/cacheability:** key a reusable graph by commit, SDK, central package files, imports, and graph policy. The seed currently regenerates it.
- **CI observability:** retain `SPARSE_CHECKOUT_RESULT=full|narrowed`, graph diagnostics, selected paths, graph duration, and peak memory in logs. Add counters before enabling this outside PR tests.
- **Maintenance:** schema changes must update the map reader and tests together. Treat `isComplete`, NuGet resolution mode, and repository input capture as compatibility contracts.

## Readability streamlining investigation

Safe cleanup that should not change semantics:

- Move the shared configuration-key/BFS helpers from `RepositoryProjectGraph.ps1` and `Create-SparseCheckoutMap.ps1` into one small dot-sourced query module.
- Replace duplicated ProjectGraph task invocations in `service.proj` with one item/property expression for optional roots.
- Give the always-included path list one checked-in source of truth shared by map generation and fallback checkout.
- Split map parsing, closure calculation, and path projection into named functions; the current script deliberately keeps the initial integration in one file for reviewability.

Changes needing deeper validation:

- Preserve full MSBuild global-property identity in schema v4 instead of conservatively collapsing Debug/Release into project+TFM keys.
- Generate or cache a provenance-preserving reverse+forward batch result in one process to avoid repeatedly materializing the graph JSON.
- Replace synthetic NuGet inputs with authoritative static-graph restore DG specs/assets and correctly model `ReferenceOutputAssembly=false`.
- Narrow below `sdk/<service>` or remove always-included SDK services. Either can save more files but substantially increases missed-input risk.
- Evaluate configurations sequentially and merge records to lower peak memory; this changes task lifecycle and requires full graph, NuGet, and sparse-clone parity testing.

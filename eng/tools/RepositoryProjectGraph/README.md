# Repository project graph

`RepositoryProjectGraph` is repository build infrastructure used by our repository to understand project dependencies and reverse project dependencies. This is used in our CI pipelines to identify jobs that are required to run as part of a build or test fanout.

For example, `RepositoryProjectGraph` is used to understand:

- Indirect project dependencies. This directly influences test package selection in PR builds.
- Reverse project dependencies. This influences sparse checkout behavior in fanned out builds, to ensure we sparsely clone the repository to only include the `sdk` directories we need.

Both operations need project and package relationships, which is what this project graph provides.

Compared to native MSBuild evaluation (using `ResolveReferences`), the graph evaluates the repository once,
avoiding repeating compiler-reference evaluation, and more accurately trims NuGet restore operations
to the specific subset of packages that require NuGet package evaluation when obtaining indirect package
dependencies.

On our hosted CI, in August 2026, we measured that `RepositoryProjectGraph`  took **75.673 seconds**, compared with **284.429 seconds** for the
native `ProjectDependsOn`/`ResolveReferences` collector: a **3.76× speed-up** and 208.756 seconds
less elapsed time. `RepositoryProjectGraph` also has a much smaller memory footprint compiler-reference evaluation and releases graph memory. A local full-repository graph run peaked at only **~2GB** memory.

## Architecture

The implementation uses MSBuild's `ProjectGraph` API directly. Imports,
conditions, properties, central package versions, and target-framework-specific references are
therefore evaluated by MSBuild. Graph construction and NuGet package resolution run in a child
MSBuild process; canonical artifact construction and queries run after that process exits.

```text
┌──────────────────────────── isolated MSBuild process ────────────────────────────┐
│                                                                                 │
│  project paths + project files/imports                                          │
│                 │                                                               │
│                 ▼                                                               │
│  MSBuild ProjectGraph evaluation                                                │
│                 │                                                               │
│                 ▼                                                               │
│  repository-project-graph.reader.json.records      [filesystem boundary 1]      │
│                 │                                                               │
│                 ▼                                                               │
│  NuGet package resolution                                                       │
│                 │                                                               │
│                 ▼                                                               │
│  repository-project-graph.reader.json.packages.records [filesystem boundary 2] │
│                                                                                 │
└────────────────────────────── process exits ─────────────────────────────────────┘
                  │                                      │
                  └──────────────────┬───────────────────┘
                                     ▼
                  PowerShell artifact construction
                                     │
                                     ▼
                  repository-project-graph.reader.json    [canonical boundary]
                                     │
                         ┌───────────┴────────────┐
                         ▼                        ▼
              dependency-selection query   checkout projection
                         │                        │
                         ▼                        ▼
              project/package root lines   checkout-graph.json
```

The graph is generated in three phases:

1. **Evaluate project configurations.** [`RepositoryProjectGraphTask`](RepositoryProjectGraphTask.cs)
   receives project paths as MSBuild items, creates one `ProjectGraph`, expands declared target
   frameworks, and writes source-relationship records. A configuration is identified by project
   path and target framework.
2. **Resolve package paths.** [`ResolveExternalPackageClosureWithNuGetTask`](ResolveExternalPackageClosureWithNuGetTask.cs)
   reads the source records, uses NuGet to follow external-package paths back to repository-owned
   packages, and writes package-closure records. It does not write `project.assets.json` or claim
   restore equivalence.
3. **Construct the canonical graph.** After the child process exits,
   [`RepositoryProjectGraph.ps1`](../../scripts/RepositoryProjectGraph.ps1) reads both record files,
   validates completeness, and writes the schema-versioned JSON used by repository CI.

### Data boundaries

| Boundary | Producer | Format and location | Consumer |
| --- | --- | --- | --- |
| Project evaluation input | [`service.proj`](../../service.proj) | In-memory MSBuild items plus project files and imports | `RepositoryProjectGraphTask` |
| Source graph records | `RepositoryProjectGraphTask` | Typed line records in `artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json.records` | NuGet resolution and canonical artifact construction |
| Package closure records | `ResolveExternalPackageClosureWithNuGetTask` | Typed line records in `artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json.packages.records` | Canonical artifact construction |
| Canonical repository graph | `RepositoryProjectGraph.ps1` | Schema-versioned JSON in `artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json` | Dependency queries and checkout projection |
| Dependency-selection result | Reverse graph query | Line-oriented project or package-root paths at the caller-provided output path | `Language-Settings.ps1` and PackageInfo generation |
| Test checkout projection | [`CreateSparseCheckoutGraphTask`](CreateSparseCheckoutGraphTask.cs) | `checkout-graph.json` published as the `TestCheckoutGraph` pipeline artifact | Per-test-job path resolution |

[`RepositoryProjectGraphRecord`](RepositoryProjectGraphRecord.cs) owns the two intermediate line
formats. They are private handoff formats between graph generation, package resolution, and the
artifact builder. [`RunIsolatedRepositoryProjectGraphTask`](RunIsolatedRepositoryProjectGraphTask.cs)
owns the child-process boundary.

The canonical graph is the reusable repository-level boundary. It contains its schema version and
source commit; physical projects and package ownership; project and repository-package
relationships by target framework; graph roots and service-directory inputs; generation policy;
and completeness diagnostics. Consumers must validate schema, provenance, and completeness before
using it for a narrowed CI decision.

`ReferenceOutputAssembly=false` project references remain in the source graph because they can
contribute build inputs. They are excluded from package restore metadata and from dependency
selection where they do not contribute a compiler reference. Restore-only settings such as
versions, warning properties, framework fallbacks, and asset filters are used during package
resolution but are not copied into the canonical artifact. External package edges are removed
after paths back to repository-owned packages have been summarized.

## Design differences compared to native MSBuild evaluation

Native MSBuild reference evaluation and the Repository Project Graph are complementary tools.
Native `ResolveReferences` answers, “Which exact files should the compiler receive for this
build?” It performs package-asset selection, assembly probing, conflict resolution, framework
resolution, and other work needed for compilation.

The Repository Project Graph asks the narrower CI question, “Which project and package identities
are connected?” It intentionally skips physical assembly resolution and produces one reusable map
for relationship queries. Native MSBuild remains authoritative for restore and build; the graph is
a specialized index for deciding what CI should process.

| Design area | Native MSBuild evaluation | Repository Project Graph |
| --- | --- | --- |
| Main purpose | Produce the exact references needed to build a project | Describe project and package relationships for CI |
| Work performed | Evaluates each candidate project and target framework, then resolves references | Evaluates the repository once and builds one reusable graph |
| Result | Compiler-facing file paths such as `ReferencePath` | Project paths, package identities, and their relationships |
| Target frameworks | Runs the relevant native targets for each framework and combines the result | Keeps each declared framework as a separate graph configuration |
| Project references | Resolves or requests referenced project outputs | Reads evaluated project-reference edges directly |
| External packages | Uses restored assets selected for the build | Uses NuGet to preserve paths that lead back to repository packages |
| Assembly resolution | Full assembly probing and conflict resolution | Not performed |
| Restore authority | Authoritative when restore assets are current | Not restore-equivalent; normal restore still owns build correctness |
| Reuse | Produces the answer for the current invocation | Supports many queries about dependencies and projects affected by a change |
| Failure behavior | Reports normal build or restore failures | Fails closed when the graph or package data is incomplete |
| Performance profile | Repeats broad reference-resolution work across project/framework roots | Pays one repository-wide cost, then serves inexpensive queries |
| Resource profile | Can accumulate repeated evaluation and compiler-reference work | Has a substantial fixed graph cost, isolated to a process that exits after generation |
| Maintenance | Primarily owned by MSBuild and the .NET SDK | Repository owns the schema, package mapping, diagnostics, and tests |

This narrower contract creates deliberate trade-offs:

- The graph evaluates `Debug`, matching the repository's existing dependency-selection policy,
  while retaining every declared target framework.
- It models the host-neutral union of compile-time target frameworks. It does not claim operating
  system, runtime-identifier, or runtime-asset equivalence.
- Package closure is explicitly marked `restoreEquivalent=false`. The graph can identify a path
  through packages without replacing a normal restore or build.
- `EnableDefaultItems=false` avoids collecting every same-service source file because a reached SDK
  project already includes its service directory. Explicit items, linked files, imports, analyzers,
  and local reference paths remain evaluated.
- External package resolution depends on NuGet cache and network state. A cold cache can reduce the
  graph's time advantage.
- Repository-wide graph evaluation has a fixed memory cost of roughly 2–3 GiB and currently uses
  the repository's .NET 10 SDK.

## Correctness and the MSBuildProjectReferenceOracle

The graph has an independent validation baseline called the
**MSBuildProjectReferenceOracle**. It runs the established native
`ProjectDependsOn`/`ResolveReferences` path and records which repository packages are visible to
each candidate project. The oracle is deliberately separate from production graph generation: it
is a correctness and troubleshooting tool, not a graph dependency.

An exhaustive hosted validation compared the complete oracle result with a fresh repository
graph. The run covered 474 production package entries and produced exact equality:

| Validation result | Native oracle | Repository graph | Difference |
| --- | ---: | ---: | ---: |
| Relationships from packages to projects that depend on them | 2,820 | 2,820 | 0 |
| Relationships mapped to production package metadata | 2,755 | 2,755 | 0 |
| Intentionally unmapped nested or test roots | 65 | 65 | 0 |

The graph contained 993 projects, 2,966 target-framework configurations, and 22,749
configuration relationships. NuGet resolved all 20,052 package roots with zero unresolved roots.
The hosted run completed successfully and published the full comparison as the
[`RepositoryProjectGraphParity` artifact](https://dev.azure.com/azure-sdk/public/_build/results?buildId=6768099&view=artifacts&type=publishedArtifacts).

The oracle can remain useful after rollout:

- Run it when MSBuild, NuGet, the graph schema, or repository project conventions change.
- Compare `oracle-only` and `graph-only` records to locate the first relationship that drifted.
- Use raw project/framework evidence to distinguish evaluation differences from package-mapping
  differences.
- Run it temporarily in shadow mode when a production query looks unexpected, without placing the
  slower native path back in the normal CI workflow.

Validation support lives in
[`Validate-RepositoryProjectGraph.ps1`](../../scripts/Validate-RepositoryProjectGraph.ps1) and
[`CollectMSBuildProjectReferenceOracle.targets`](CollectMSBuildProjectReferenceOracle.targets).
Neither file is imported by normal graph generation or queries.

## How CI uses it

### Dependent package selection

The `generate_target_service_test_matrix` job calls
[`Language-Settings.ps1`](../../scripts/Language-Settings.ps1) to load production package metadata.
The script queries the canonical graph with the changed package identities and maps the resulting
project or package roots back to PackageInfo entries. Those entries are marked for dependent
validation before normal matrix batching. One graph query replaces native reference evaluation
across every candidate project and target framework.

### Test source selection

[`pr-matrix-presteps.yml`](../../pipelines/templates/steps/pr-matrix-presteps.yml) combines the
canonical graph with the generated PackageInfo files. `CreateSparseCheckoutGraphTask` maps each
artifact to its project configurations and writes `checkout-graph.json`. The `TestCheckoutGraph`
artifact is then downloaded by each job defined in
[`ci.tests.yml`](../../pipelines/templates/jobs/ci.tests.yml).

For each test artifact, [`Resolve-SparseCheckoutPaths.ps1`](../../scripts/Resolve-SparseCheckoutPaths.ps1):

1. starts from the artifact's project configurations;
2. follows project and repository-package dependencies;
3. maps reached projects and explicit cross-service inputs to SDK service directories; and
4. adds the repository build and bootstrap paths required by every test job.

An unknown artifact, stale source commit, incomplete graph, missing package root, unsupported
input, malformed index, or empty result returns no paths. The job then retains the full-checkout
fallback rather than using a known-partial source set.

## Generating and querying the graph

Generate the canonical artifact from the repository root:

```pwsh
dotnet msbuild /m /nr:false /nologo /tl:off `
  /t:GenerateRepositoryProjectGraphWithProjectGraph eng/service.proj
```

The standard output is:

```text
artifacts/obj/RepositoryProjectGraph/repository-project-graph.reader.json
```

Query packages and projects that depend on one or more repository packages:

```pwsh
dotnet msbuild /m /nr:false /nologo /tl:off `
  /t:QueryRepositoryProjectGraphReverseWithProjectGraph eng/service.proj `
  /p:TestDependsOnDependency="Azure.Core" `
  /p:TestDependsIncludePackageRootDirectoryOnly=true `
  /p:OutputProjectFilePath="artifacts/obj/RepositoryProjectGraph/dependent-projects.txt"
```

[`service.proj`](../../service.proj) defines the supported generation and query targets. Prefer
those targets or the production [`RepositoryProjectGraph.ps1`](../../scripts/RepositoryProjectGraph.ps1)
functions over reading the JSON with a new one-off parser.

## Failure behavior and limitations

- **Not a build replacement.** Native MSBuild and NuGet remain authoritative for compilation,
  restore assets, runtime assets, and assembly conflict resolution.
- **Incomplete means unusable.** Missing declared projects, unresolved repository package roots,
  conflicting project identities, stale provenance, or unsupported graph records fail closed.
- **Target-framework specific, not host specific.** The graph preserves framework differences but
  does not add an operating-system or runtime-identifier query dimension.
- **Conservative source selection.** Explicit linked inputs and cross-service references can add
  an entire SDK service directory. Extra source is acceptable; silently omitting required source
  is not.
- **Custom build logic must be visible.** A custom target that reads arbitrary files must expose
  them through evaluated items or imports to participate in graph-based source selection.
- **Package cache matters.** Missing external packages may be downloaded during graph generation,
  so cold-cache and network behavior can affect runtime.
- **Normal build behavior is unchanged.** The graph does not modify `ResolveReferences`, restore,
  or compilation targets.

## Implementation map

| Component | Responsibility |
| --- | --- |
| [`service.proj`](../../service.proj) | Defines repository projects and graph generation/query targets |
| [`RepositoryProjectGraphTask`](RepositoryProjectGraphTask.cs) | Builds and validates the MSBuild project graph |
| [`ResolveExternalPackageClosureWithNuGetTask`](ResolveExternalPackageClosureWithNuGetTask.cs) | Follows external package paths back to repository packages |
| [`RepositoryProjectGraphRecord`](RepositoryProjectGraphRecord.cs) | Owns the typed intermediate record format |
| [`RunIsolatedRepositoryProjectGraphTask`](RunIsolatedRepositoryProjectGraphTask.cs) | Runs graph work in a disposable child process |
| [`CreateSparseCheckoutGraphTask`](CreateSparseCheckoutGraphTask.cs) | Projects the canonical graph and PackageInfo into the per-test checkout index |
| [`RepositoryProjectGraph.ps1`](../../scripts/RepositoryProjectGraph.ps1) | Builds, validates, and queries the canonical artifact |
| [`Language-Settings.ps1`](../../scripts/Language-Settings.ps1) | Selects projects affected by a changed package for CI |
| [`Validate-RepositoryProjectGraph.ps1`](../../scripts/Validate-RepositoryProjectGraph.ps1) | Compares the graph with the independent native oracle |

## Development

Build the task project:

```pwsh
dotnet build eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj --no-restore
```

Run the focused test suites:

```pwsh
Invoke-Pester eng/scripts/tests/RepositoryProjectGraph.Tests.ps1
Invoke-Pester eng/scripts/tests/RepositoryProjectGraphDependencyRelation.Tests.ps1
Invoke-Pester eng/scripts/tests/LanguageSettings.Tests.ps1
Invoke-Pester eng/scripts/tests/SparseCheckout.Tests.ps1
```

Graph changes should preserve these invariants:

- every declared project and target framework has an unambiguous identity;
- every relationship points to a known configuration or repository package;
- diagnostics report a complete graph before any narrowed CI decision is allowed;
- package and project matching is case-insensitive where NuGet and Windows require it; and
- the native MSBuild oracle remains independent enough to detect graph drift.

# .NET SDK breaking change detection and mitigation

This catalog is the .NET input to `azsdk_package_detect_breaking_change` and the
shared `azsdk-common-sdk-breaking-change` workflow. It covers public APIs in
both data-plane and management-plane libraries. ARM-specific mitigations below
apply only to management-plane libraries.

## Detection contract

`eng/scripts/compatibility/Get-SdkChanges.ps1` compares current, already-built
assemblies with the latest stable (GA) NuGet package. The pinned
`ApiCompatVersion` is not proof that a version is the latest GA, and an absent
property is not proof that a package has never shipped.

The detector invokes the SDK-shipped
`Microsoft.DotNet.ApiCompat.Task.ValidateAssembliesTask` independently of
compilation and analyzer validation. It uses the repository's compatibility
rules, attribute exclusions, and approved centralized suppressions. It does
not generate suppressions or implement a second compatibility policy.
Baseline packages and dependencies are restored using the SDK repository's
`NuGet.Config`, including its approved Azure Artifacts feed.

Run the common entry point from an SDK or local spec workflow:

```text
azsdk package detect-breaking-change --package-path <package-directory> --tsp-config-path <tspconfig.yaml>
```

Use `--changes-only` for deterministic detection without AI classification.
Automation can call the configured script directly:

```powershell
.\eng\scripts\compatibility\Get-SdkChanges.ps1 `
    -PackagePath <absolute-package-directory> `
    -SdkRepoPath <absolute-sdk-repository> `
    -OutputJsonFile <report.json>
```

Generate and compile current artifacts separately when needed. Matching
portable or embedded PDBs are required to verify source checksums; build-input
timestamps supplement that check. The PowerShell host must run on a .NET
runtime compatible with the selected SDK's MSBuild diagnostic reader. For the
current .NET 10 SDK, use PowerShell 7.6 or newer; installing an SDK alone does
not upgrade PowerShell.

The detector evaluates all declared target frameworks unless `TargetFramework`
is set in the environment. `Configuration` must match the prepared artifacts:
SDK PR packaging uses `Release`, while local builds commonly use `Debug`.
For example, set `$env:Configuration = 'Release'` before detecting SDK PR
artifacts. A deliberate `$env:TargetFramework = 'netstandard2.0'` comparison
requires only that framework's artifacts, but is not full-package coverage;
the report records the omitted frameworks. Clear the override for a complete
multi-target comparison.

A normal build
or analyzer failure must be reported separately from compatibility results.
Missing or stale assemblies, unresolved references, invalid reports, and
failed baseline retrieval are detector errors, not evidence of compatibility.
Native unresolved-reference diagnostics remain errors even on SDK versions
that log them as informational messages instead of warnings.
If the package has no GA release, the report explicitly identifies the missing
baseline; that is not a successful compatibility comparison.

The common result preserves `changes` and `hasBreakingChange`. Optional
`details` retain `baselineVersion`, structured `apiChanges`, native
`diagnostics`, and `limitations`. Classified results also retain that original
evidence, including when AI classification fails.

### SDK PR reports

SDK PR build jobs collect native reports immediately after Release packaging,
even when that build failed. Collection clears inherited target-framework
overrides and records each selected package independently. Existing validation
steps remain in place; the final compatibility assertion fails on detected
breaks or detector errors, not merely on the extractor's exit code. No-GA
packages are reported as not applicable, never compatible.

The job publishes `sdk-api-changes_<job-name>` artifacts even after failure;
the existing publisher adds `-FailedAttempt<attempt>` for failed jobs. Each
artifact contains `summary.json` and per-project `result.json`, unchanged
`sdk-changes.json`, and process logs. Detector failures instead include
`error.json`; any incomplete raw output is named `failed-sdk-changes.json`
and must not be replayed as a successful comparison.

Use a successful collected `sdk-changes.json` with the common tool's
`--sdk-change-json-file-path` option to classify and select mitigations.
Retain its baseline, framework scope, and source revision when interpreting
the result; replay does not refresh the original comparison. Do not combine
that option with `--changes-only`, which requests fresh detection instead.

The existing Compliance job runs the native and CI Pester suites on SDK PRs.
To run the same suites locally from the repository root:

```powershell
Invoke-Pester -Path @(
    '.\eng\scripts\compatibility\tests',
    '.\eng\scripts\compatibility\ci-tests'
) -Output Normal
```

### Supplemental extraction: additions, not a second compatibility checker

ApiCompat's forward comparison is the authority for compatibility violations.
Because it primarily reports violations, the detector also compares the same
assemblies in reverse. Reverse `CP0001` and `CP0002` diagnostics supply added
types and members for the `### Features Added` section. They do **not** set
`hasBreakingChange`. Other reverse differences are not automatically additions
or new breaking changes.

A changed signature can appear as a removed overload and an added overload.
A renamed type or property can appear as a removal and an addition. Preserve
both entries and their signatures. Neither co-occurrence nor name similarity
proves a rename: confirm the mapping using the TypeSpec source, existing client
customizations, previous public contract, and affected call sites. Without
that evidence, leave the violations separate and require manual review.

ApiCompat cannot prove behavioral or wire compatibility. Serialization names,
resource paths, paging behavior, defaults, and other runtime changes still
require appropriate tests and owner judgment, even when the assemblies are
compatible.

## Classification and mitigation contract

Use the common categories: `emitter change`, `conversion-by design`,
`conversion-need resolve`, `spec change`, or `unknown`. A diagnostic identifies
the API violation, not its root cause. Only choose a more specific category
when the spec, emitter, and previous contract provide supporting evidence.
An expected conversion is not permission to suppress a violation.

Each classified .NET change includes a `mitigation` route:

| Route | Preconditions and entry point |
| --- | --- |
| `generator` | A documented deterministic generator pattern below matches and its preconditions are verified. Invoke the SDK's existing [mitigate-breaking-changes skill](../../.github/skills/mitigate-breaking-changes/SKILL.md), then regenerate using the existing generator and matching previous contract. |
| `client customization` | A verified client-layer change can preserve public and wire behavior. Use `azsdk_customized_code_update` with the selected change, local TypeSpec project, and approved edit scope. This is the current name of the tool previously called `azsdk_typespec_customized_code_update`. |
| `manual` | The mapping, semantics, generator support, or owner decision is missing. Explain what must be established; do not apply an automatic fix. |

Detection and classification are read-only. Present the changes and obtain the
user's selection before mitigation. Do not edit generated files, automatically
add suppressions, widen the permitted edit scope, or change a pinned spec
commit. For SDK-only repair, `editScope: CustomCode` cannot change `client.tsp`
or `tspconfig.yaml`; `SpecChangeRequired` is a handoff, not permission to retry
with broader scope.

After mitigation, regenerate and compile fresh artifacts as needed, rerun
the same detector, and separately run ordinary build, analyzer, and test
validation. Stop on unresolved or ambiguous changes rather than repeatedly
applying speculative fixes.

## Removed or renamed types

**SDK change pattern:** Forward `CP0001` identifies an absent type; reverse
`CP0001` may identify a new type. `CP0019` can indicate reduced visibility.

**Breaking:** Existing type references, constructors, parameters, and returned
models may no longer compile or load.

**Reason:** Possible spec removal, changed client naming/accessibility, or
emitter/conversion behavior. Confirm the canonical TypeSpec element before
claiming a rename; retain `unknown` when the mapping is not established.

**Resolution:** If the same service model and wire contract remain, restore
the previous C# name/accessibility through a verified client customization
(`@@clientName(..., "PreviousName", "csharp")` where appropriate). The management
skill also documents `CodeGenType` for SDK-side customization when needed;
its attribute argument is the original TypeSpec model name. Removed service
functionality or an unproven mapping cannot be repaired by renaming another
type. Route to `client customization` only with evidence; otherwise `manual`.

## Removed members and changed signatures

**SDK change pattern:** Forward `CP0002`, optionally paired with reverse
`CP0002` for a property, constructor, method, accessor, or overload.

**Breaking:** A callable signature or accessible member in the GA package is
missing. Parameter/return-type changes can generate multiple related entries.

**Reason:** Spec, naming, flattening, type conversion, or generator changes.
Check old and new signatures, synchronous/asynchronous variants, overloads,
requiredness, and custom code. Do not classify every removal/addition pair as
a rename.

**Resolution:** Use a verified naming customization only when the same API and
wire semantics remain. Do not use `alternateType` to conceal a real service
type change or introduce a lossy conversion. Check the deterministic
management overload patterns below before considering custom forwarding
members. Other signature changes require `manual` review.

## Changed parameter names

**SDK change pattern:** `CP0017` identifies a parameter name change; `CP0002`
may additionally identify changed overloads.

**Breaking:** Customer calls using named arguments no longer compile.

**Reason:** A client-name customization, emitter naming convention, or spec
parameter rename changed the C# name. A diagnostic alone does not distinguish
these causes.

**Resolution:** When the corresponding TypeSpec parameter and wire binding
are verified, use `azsdk_customized_code_update` to restore the previous
C# parameter name with a language-scoped client customization, for example
`@@clientName(Operations.create::parameters.resource, "content", "csharp")`.
Route to `client customization`; otherwise `manual`.

## Management conditional-header compatibility overloads

**SDK change pattern:** `CP0002` for an old public method with string ETag
headers, alongside a current method using `ETag`, `MatchConditions`, or
`RequestConditions`.

**Breaking:** Callers of the old conditional-header signature lose their
overload.

**Reason:** A management generator transition may change the SDK's
representation of unchanged HTTP conditional headers.

**Resolution:** Route to `generator` only when the existing
[BackCompatHelper](../../eng/packages/http-client-csharp-mgmt/generator/Azure.Generator.Management/src/Utilities/BackCompatHelper.cs)
can match the previous public method to a current method with the same name,
return type, remaining parameters, and supported conditional-header
transformation. Existing custom overloads and approved method removals must
not be duplicated or resurrected. Invoke `mitigate-breaking-changes` and
regenerate with the matching previous contract, rather than implementing a
second overload synthesizer. If the generator reports that it cannot
synthesize the overload, require `manual` review of a custom overload.

## Management model-factory compatibility overloads

**SDK change pattern:** `CP0002` for a previous model-factory overload after
model flattening, constructor reordering, or added model properties.

**Breaking:** Mocking and test code using the old factory signature no longer
compiles; a superficially compatible overload can also incorrectly discard
its input values.

**Reason:** Model shape changes can invalidate old factory signatures or
constructor argument positions.

**Resolution:** The existing
[ModelFactoryVisitor](../../eng/packages/http-client-csharp-mgmt/generator/Azure.Generator.Management/src/Visitors/ModelFactoryVisitor.cs)
and
[ModelFactoryBackwardCompatHelper](../../eng/packages/http-client-csharp-mgmt/generator/Azure.Generator.Management/src/Visitors/ModelFactoryBackwardCompatHelper.cs)
restore supported previous-contract methods and repair argument forwarding.
Use `generator` only after verifying that the old types and parameters still
map to the current model and that the removal was not approved. Invoke the
existing skill, regenerate, and check that old input values are preserved in
the resulting model. Unsupported/custom factory shapes require `manual`
review, not guessed default values.

## Enum types and values

**SDK change pattern:** `CP0010` for an enum representation/type change,
`CP0011` for a constant value change, or `CP0002` for removed members.
Extensible enums represented as structs may produce member diagnostics
instead of CLR enum diagnostics.

**Breaking:** Customer code loses a named value or observes a different value.

**Reason:** A spec value change, conversion, or naming change may be involved.
Compare serialized values as well as C# names.

**Resolution:** A verified name-only change retaining the same serialized
value can use `client customization`. Do not automatically remap numeric
values, seal an extensible enum, or claim that adding a differently valued
member repairs a removal. Other cases require `manual` review.

## Inheritance, virtual members, and resource hierarchy

**SDK change pattern:** `CP0007`, `CP0008`, `CP0009`, `CP0012`, or `CP0013`.

**Breaking:** Assignability, derivation, overriding, or dispatch changes for
existing consumers.

**Reason:** A client model, resource hierarchy, or generator change may have
altered the public inheritance contract.

**Resolution:** Default to `manual`. For ARM libraries, first verify resource
hierarchy parity and repair structural TypeSpec resource-shape issues before
considering SDK-side base-type customization. The existing management skill
requires explicit owner approval for legacy `hierarchyBuilding`; do not
automatically add it or use it for data-plane models.

## Interface, abstract, visibility, and generic changes

**SDK change pattern:** `CP0005`, `CP0006`, `CP0018`, `CP0019`, `CP0020`, or
`CP0021`.

**Breaking:** Existing implementers, derived types, generic instantiations,
or source references may stop working. In particular, adding an interface or
abstract member can be a forward compatibility violation even though the
member is an addition.

**Reason:** Public API design or generation constraints changed.

**Resolution:** `manual`. Verify the affected implementations and API design;
do not supply arbitrary implementations or weaken constraints just to pass
compatibility. Preserve forward diagnostics even when the same added member
also appears in reverse extraction.

## Public attributes, including management WirePathAttribute

**SDK change pattern:** `CP0014`, `CP0015`, or `CP0016` after applying the
repository's existing attribute exclusions.

**Breaking:** An attribute required by the compatibility policy was removed,
changed, or added.

**Reason:** The emitter configuration, generated metadata, or spec may have
changed. Attribute differences are not all interchangeable.

**Resolution:** For a verified management `WirePathAttribute` removal, the
existing skill documents `enable-wire-path-attribute: true` in the management
emitter options. Route that configuration change through
`azsdk_customized_code_update` as `client customization`, then regenerate.
Other attributes require pattern-specific evidence or `manual` review.
Never automatically baseline unrelated errors or disable attribute checks.

## Assembly identity, missing dependencies, and unknown diagnostics

**SDK change pattern:** `CP0003`, `CP0004`, assembly-loading errors, or a
diagnostic not covered by the catalog.

**Breaking:** An identity change can break assembly consumers. A missing
assembly/reference can instead mean that the detector did not complete.

**Reason:** Package identity, target-framework coverage, baseline retrieval,
reference resolution, or an unsupported compatibility case needs attention.

**Resolution:** Preserve the native diagnostic and route to `manual`. Repair
missing inputs or environment failures before declaring a comparison result.
Do not guess a source customization or convert an incomplete run into
`hasBreakingChange: false`.

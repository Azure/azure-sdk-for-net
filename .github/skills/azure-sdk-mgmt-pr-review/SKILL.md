---
name: azure-sdk-mgmt-pr-review
description: Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality.
---

# Azure .NET Mgmt SDK PR Review

Review Azure SDK for .NET management library pull requests against the official API review guidelines.

The review is split into three sequential phases: **Phase 1: Versioning Review** (gate), **Phase 2: API Review**, and **Phase 3: Breaking Change Detection**. Each phase must pass before proceeding to the next.

## Phase 1: Versioning Review

This phase checks version-related rules that are simple and rule-based. **Versioning violations are blocking** (the review must be submitted as "Request Changes"), but do **not** stop the review after Phase 1 — continue into Phase 2 so the author receives versioning *and* API/naming findings in a single round instead of discovering them one round at a time.

### Instructions

1. Check the `.csproj` file and CHANGELOG.md for the rules below.
2. Record an inline review comment for every versioning violation found (with file path and line number). These findings are blocking.
3. **Continue to Phase 2** and run the API review as well, then submit one combined review covering all phases. Only stop early before Phase 2 if a versioning problem makes the review scope impossible to determine reliably — for example, if `ApiCompatVersion` was removed *and* you cannot recover the prior stable baseline from the base `.csproj` or the latest released tag, so the new-vs-baseline API diff would be misleading. In that narrow case, submit "Request Changes" on the versioning findings and note that the API review was skipped because the baseline could not be determined.
4. If any versioning rule is violated, the final review must be submitted as **"Request Changes"** regardless of the Phase 2/3 outcome.

### Versioning Rules

- **No major version bump.** Management SDK packages follow a unified versioning strategy. No individual package is allowed to bump its major version unless a major version bump decision has been explicitly made by the .NET architects for all mgmt packages. If a PR bumps the major version (e.g., from `1.x` to `2.0.0`), flag as **Critical**: "You must not bump the major version without the .NET architects' explicit requirement."
- **Do not remove `ApiCompatVersion`.** If a PR removes the `ApiCompatVersion` property from the `.csproj` file, flag as **Critical**. This property enforces API compatibility checks against the last stable release and must not be deleted. Removing it would allow breaking changes to slip through undetected.
- **No newly added content in `ApiCompatBaseline.txt`.** If the PR adds new entries to the `ApiCompatBaseline.txt` file (which suppresses ApiCompat errors), flag as **Critical**. Suppressing API compatibility errors hides breaking changes from customers. The correct approach is to mitigate breaking changes through customization code, not to baseline them away.

## Phase 2: API Review

This phase reviews the API surface for naming conventions, type correctness, and adherence to design guidelines. It runs only after Phase 1 passes.

### Scope of Review

The review should focus **only on new or changed API surface** compared to the RP's latest released stable version. Types, properties, and methods that were already shipped in a prior stable release cannot be changed and should not be flagged.

To determine the review scope:
1. Find the RP's latest released stable version. Check the `ApiCompatVersion` property in the package's `.csproj` file. If the PR removed `ApiCompatVersion`, recover the prior value from the base-branch `.csproj` or the latest released package tag so the diff is still accurate. If `ApiCompatVersion` is genuinely not present (and never was), assume there is no prior stable version — the entire API surface is in scope for review and no breaking changes are possible.
2. If `ApiCompatVersion` is present, retrieve that version's API surface file from the corresponding git tag (tag format: `<PackageName>_<Version>`, e.g., `Azure.ResourceManager.Foo_1.0.0`). The API file is at `sdk/<service>/<PackageName>/api/<PackageName>.net10.0.cs` (or earlier TFM variants like `netstandard2.0.cs`).
3. Diff the released API surface against the PR's API surface file.
4. Only review types, properties, methods, and enums that appear in the diff (i.e., newly added or modified). Anything unchanged from the stable release is out of scope.

### Instructions

1. Determine review scope per the "Scope of Review" section above.
2. **Fetch existing review threads first** so the new review does not duplicate findings already raised by other reviewers (the same finding from two reviewers wastes the author's time and looks unprofessional):
   ```powershell
   # All inline review comments on the PR (across every reviewer):
   gh api --paginate "repos/{owner}/{repo}/pulls/{pull_number}/comments?per_page=100" `
       --jq '.[] | {path, line, user: .user.login, body}'
   # Top-level reviews (state, body):
   gh api --paginate "repos/{owner}/{repo}/pulls/{pull_number}/reviews?per_page=100" `
       --jq '.[] | {id, state, user: .user.login, body}'
   ```
   Build a quick map of `path:line -> existing comment summary` and, when posting your own comments, drop or merge any finding that overlaps with an existing thread. If you need to reinforce an existing thread, reply to it instead of opening a new one.
3. **Run the automated naming rule scanner** to find all deterministic naming violations:
   ```powershell
   pwsh .github/skills/azure-sdk-mgmt-pr-review/Check-MgmtNamingRules.ps1 -PackagePath <package-path>
   ```
   The script checks all rules in the "API Review Checklist" below and outputs violations with rule IDs, line numbers, and suggested fixes. Include every violation from the script output as an inline review comment, **after** filtering out anything already covered in step 2.
   If `ApiCompatVersion` is present (i.e., a prior stable version exists), pass the baseline API surface file to the script using `-BaselineApiFilePath` so it can deterministically filter out violations on unchanged API surface:
   ```powershell
   pwsh .github/skills/azure-sdk-mgmt-pr-review/Check-MgmtNamingRules.ps1 -ApiFilePath <current-api-file> -BaselineApiFilePath <baseline-api-file>
   ```
   When `-BaselineApiFilePath` is provided, the script automatically excludes violations on types/members that existed unchanged in the prior stable release.

   The scanner currently emits these rule families (see "API Review Checklist" for details):
   - `SUFFIX001`–`SUFFIX010` – forbidden type-name suffixes (Parameters, Request, Options, Response, Data, Definition, Operation, Collection, **Update**, …)
   - `RESINFIX001` – `Resource` infix in `*Data`/`*Collection` model names (with PrivateLinkResource exception)
   - `ACRONYM001` – curated acronyms in wrong casing (HTTP/TCP/SSL/TLS/…)
   - `ACRONYM002` – generic 3+ letter all-caps run inside a name (NNI, IPV, BFD, …)
   - `ARMCOMMON001` – type duplicates an Azure.ResourceManager/Azure.Core common type (`OperationStatusResult`, `ManagedServiceIdentity*`, `TagsUpdate`, `ErrorResponse`, …)
   - `BOOL001` / `DATETIME001` / `TTL001` – property naming

   **Contextual naming is intentionally NOT part of the scanner's rule checks.** Any rule we tried to make it flag automatically was either too noisy or too narrow, so the *judgment* is left to the reviewer (step 4). The scanner does, however, produce the deterministic **worklist** for that judgment (see step 4).
4. **Apply the contextual-naming check exhaustively** — this is the single biggest cause of repeated review rounds. In past PRs the reviewer flagged one or two badly-named types, the author fixed them and regenerated, and the *next* round surfaced yet another generically-named type that was present from the very first commit. The author then needs another round. To avoid this, you must evaluate **every** new public type in one pass, not a sample.

   **Step 4a — get the complete worklist (deterministic).** Run the scanner in inventory mode to list every public class/struct/enum, tagged NEW or EXISTING against the baseline:
   ```powershell
   pwsh .github/skills/azure-sdk-mgmt-pr-review/Check-MgmtNamingRules.ps1 -ApiFilePath <current-api-file> -BaselineApiFilePath <baseline-api-file> -ListNewTypes
   # If there is no prior stable version, omit -BaselineApiFilePath (every public type is NEW / in scope).
   ```
   This produces a bounded list (`NEW` entries) extracted directly from the API file, so you do not have to eyeball a 10k–20k-line `api/*.cs` and risk skipping types.

   **Step 4b — record a verdict for every `NEW` entry.** For each type ask: *"if a consumer saw this type name in IntelliSense without the namespace, would they know which Azure service/resource it belongs to?"* Assign exactly one verdict per type:
   - `OK` — name carries clear service/resource/domain context, or is a well-established term in this RP's domain.
   - `Flag` — name is generic/ambiguous **and** lacks RP/resource/domain context. Only flag when you are confident *and* you can propose a concrete better name. Post an inline comment for these.
   - `OK (low confidence)` — borderline; do **not** post a comment. Recording it keeps the pass honest without adding noise.

   The contextual-naming pass is **not complete** until every `NEW` inventory entry has a verdict. The count of verdicts must equal the count of `NEW` entries from step 4a.

   Apply the judgment to **type / enum / model names only** — do not apply the "service-context" test to individual enum *members* (e.g., do not demand that every enum value contain the RP name); enum members are handled by casing / numeric-version / common-name rules instead. Pay extra attention to:
   - Single- or two-token names (`BitRate`, `RouteType`, `BurstSize`, `DeviceRole`, `Action`, …)
   - Names that look like generic infrastructure concepts (`IdentitySelector`, `FeatureFlagProperties`, `LockConfigurationState`, `SynchronizationStatus`, …)
   - Anything that duplicates a common ARM/.NET concept (`TagsUpdate`, `OperationStatusResult`, `ManagedServiceIdentityPatch`)
   - Models named `*Properties` that aren't already prefixed with the resource name

   In the review summary, report coverage explicitly, e.g. `Contextual naming: evaluated N new public types, flagged M`. This makes it visible whether the pass was exhaustive.
5. Examine API surface files (api/*.cs) for public API, focusing on new/changed surface. Check for any additional issues not covered by the script (e.g., contextual judgment calls, domain-specific naming).
6. Check Generated models and resources in src/Generated/.
7. Review TypeSpec customizations (e.g., `client.tsp`, `tspconfig.yaml`).
8. For each issue found, record the exact file path, line number, and comment body to include as an inline review comment. **Always target the current TFM API file** (e.g., `*.net10.0.cs`) – earlier reviewers may have commented on a previous TFM mirror; do not blindly copy their line numbers.

### API Review Checklist

#### Naming - Avoid These Suffixes
| Suffix | Replace With | Exception |
|--------|--------------|-----------|
| Parameter(s) | Content/Patch | - |
| Request | Content | - |
| Options | Config | Unless ClientOptions |
| Response | Result | - |
| Update | Patch / Content | - |
| Data | - | Unless derives from ResourceData/TrackedResourceData |
| Definition | - | Unless removing it creates conflict with another resource |
| Operation | Data or Info | Unless derives from Operation<T> |
| Collection | Group/List | Unless domain-specific (e.g., MongoDBCollection) |

#### Do Not Redefine ARM Common Types
The following types are provided by `Azure.ResourceManager` / `Azure.Core` and **must not** be redefined on a service SDK's public surface. Reuse the framework type instead (or, if the wire model differs, rename the service-specific type with the RP prefix and document why a parallel type is needed):

| Common Type | Where it lives |
|-------------|----------------|
| `OperationStatusResult` | Use the `ArmOperation` / `ArmOperationStatus` pattern from Azure.ResourceManager |
| `ManagedServiceIdentity`, `ManagedServiceIdentityType` | `Azure.ResourceManager.Models` |
| `ManagedServiceIdentityPatch` | Use the framework patch pattern; do not surface as a separate type |
| `UserAssignedIdentity` | `Azure.ResourceManager.Models` |
| `SystemData` | Exposed via `ResourceData.SystemData`; never redefine |
| `TagsUpdate` / `TagsPatch` | Use the Tags update pattern provided by `Azure.ResourceManager` |
| `ErrorResponse`, `ErrorDetail` | Use `Azure.ResponseError` / framework error types |
| `TrackedResource` | Inherit `TrackedResourceData` instead |

#### Resource Naming
- Remove "Resource" suffix if remaining noun is still descriptive (e.g., VirtualMachine not VirtualMachineResource)
- Keep "Resource" if removing makes it non-descriptive (e.g., GenericResource stays)
- For models: append "Data" suffix if inherits ResourceData/TrackedResourceData, otherwise "Info"
- **No "Resource" in Data or Collection type names.**
  - **Data types:** Types used as the `Data` property of an `ArmResource` must not include "Resource" before the "Data" suffix — e.g., `VirtualMachineResourceData` is **not allowed**; use `VirtualMachineData` instead.
  - **Collection types:** `ArmCollection` types must not include "Resource" before "Collection" — e.g., `VirtualMachineResourceCollection` is **not allowed**; use `VirtualMachineCollection` instead.
  - **Exception – PrivateLinkResource:** `*PrivateLinkResourceData` and `*PrivateLinkResourceCollection` are allowed because "PrivateLinkResource" is the established ARM resource name.
  - **When to flag:** Flag all other violations unless the PR provides explicit justification for keeping the "Resource" infix.

#### Operation Body Parameters
- **PATCH operation body:** Must be named `[Model]Patch`
- **PUT/POST operation body:** Must be named `[Model]Content` or `[Model]Data`

#### Property Naming
- **Boolean properties:** Must start with verb prefix: `Is`, `Can`, `Has`, `Does`, `Should`, `Allow`, `Enable`, `Disable`, `Use`, `Support`
- **DateTimeOffset properties:** Should end with `On` or `At` (e.g., `CreatedOn`, `StartOn`, `ExpiresAt`)
- **Interval/Duration (integer):** Include units in name (e.g., `MonitoringIntervalInSeconds`)
- **TTL properties:** Rename to `TimeToLiveIn<Unit>`

#### Acronyms
- Use PascalCase (capitalize first letter only): `Aes`, `Tcp`, `Http`
- 2-letter acronyms: uppercase if standalone (`IO`), except `Id`, `Vm`
- Expand acronyms if not clearly explained in first page of search results with context

#### Contextual Naming for Types
- All types must have a name that includes sufficient context about what the type represents.
- Avoid generic or ambiguous names that could apply to many different services. The type name should make it clear which service or resource it belongs to.
- **Bad examples:** `PublicNetworkAccess`, `EncryptionStatus`, `PrivateEndpointConnection`, `Scope`, `GroupScope`, `Sensitivity`, `ManagedRuleSetException` — these names lack context; a reader cannot tell which service or resource they belong to without looking at the namespace.
- **Good examples:** `StorageAccountPublicNetworkAccess`, `CosmosDBEncryptionStatus`, `KeyVaultPrivateEndpointConnection`, `FrontDoorRuleScope`, `FrontDoorSensitivityType` — these names include the service or resource context.
- Short names built mostly from generic suffixes like `Scope`, `Exception`, or `Sensitivity` should usually be flagged unless they are already prefixed with the RP or resource name.
- Exception: If the type is scoped within a clearly named parent model or the namespace already provides unambiguous context (e.g., a property type used exclusively by one resource), a shorter name may be acceptable.

#### Naming Fix Recommendations

When flagging a naming issue, the recommended fix depends on whether the type is explicitly defined in the service's TypeSpec.

1. **Type is defined in the service's TypeSpec**: Recommend adding a `@@clientName` decorator in `client.tsp`.
   - Example: `@@clientName(PublicNetworkAccess, "DurableTaskPublicNetworkAccess", "csharp");`
2. **Type is NOT defined in the service's TypeSpec**: `@@clientName` cannot be used. Instead, recommend **SDK-side custom code** — create a customization file (e.g., `src/Customize/Models/<NewName>.cs`) using `[CodeGenType("OriginalGeneratedName")]` to rename the type.
   - Example: `[CodeGenType("OptionalPropertiesUpdateableProperties")]` on a class named `DurableTaskPrivateEndpointConnectionPatchProperties`.

To determine whether a type is defined in the service's TypeSpec, search all `.tsp` files under the spec folder for a `model`, `union`, or `enum` declaration with the same name.

#### Enums
- Use singular type name (not plural) unless bit flags
- Numeric version enums should use underscore: `Tls1_0`, `Ver5_6`

#### Type Formatting

The following table applies to the **generated C# API surface** (public types/properties in `api/*.cs`).

| Property Pattern | Expected Type |
|------------------|---------------|
| Ends with `Id`/`Guid` with UUID value | `Guid` |
| Ends with `Id` with ARM resource ID | `ResourceIdentifier` |
| Named `ResourceType` or ends with `Type` for resource types | `ResourceType` |
| Named `etag` | `ETag` |
| Contains `location`/`locations` | Consider `AzureLocation` |
| Contains `size` | Consider `int`/`long` instead of string |

For **TypeSpec**, UUID-valued properties should use the `uuid` scalar and map to `Guid` in the generated .NET SDK.

#### Duration/Interval Format
- ISO 8601 duration (P1DT2H59M59S): use `duration` scalar in TypeSpec
- ISO 8601 constant (2.2:59:59.5000000): use `@encode(DurationConstant)` in TypeSpec

#### CheckNameAvailability Operation
- Method: `Check[Resource/RP name]NameAvailability`
- Parameter/Response model: `[Resource/RP name]NameAvailabilityXXX`
- Unavailable reason enum: `[Resource/RP name]NameUnavailableReason`

#### Method Renaming in SDK Migration
- When a previously shipped method name changes during SDK migration, prefer to **rename the newly generated API back to the previously shipped name** rather than keeping both names.
- Do not keep both the old and new method names just because generation produced a different name. Carrying both methods forward unnecessarily expands the public API surface and creates confusion.
- Only replace the old name with a new one when the old name is clearly wrong and the rename is intentional. In that case, treat the old member as a backward compatibility shim and make sure the review explicitly calls out why the old name is a mistake.
- A common compatibility smell is custom code that adds the old API method name back, but its implementation only forwards to the newly renamed method. That pattern usually means the change is name-only, and the generated method should be renamed back to the previously shipped API name instead of keeping both.

#### Other API Rules
- PUT/PATCH optional body parameters should be changed to required
- Discriminator models should make base model `abstract`
- Remove all `ListOperations` methods (SDK exposes operations via public APIs)

## Phase 3: Breaking Change Detection

This phase runs after Phase 2. If `ApiCompatVersion` is present in the `.csproj` (i.e., a prior stable version exists), check for breaking changes by building the project. The `ApiCompat` tooling will report breaking changes as build errors automatically.

### Instructions

1. Build the project using `dotnet build` (or the appropriate build command for the package).
2. Inspect the build output for `ApiCompat` errors — these indicate breaking changes against the last stable version (removals, signature changes, etc.).
3. If the build succeeds with no `ApiCompat` errors, this phase passes.
4. If `ApiCompat` errors are found:
   - For each error, record an inline review comment listing the breaking change (what was removed or changed), targeting the relevant file and line.
   - Do **not** attempt to fix or mitigate the breaking changes yourself. Instead, list all detected breaking changes and ask the user to mitigate them. Mitigation options include customization code via partial classes and generator features (e.g., `rename-mapping`, custom properties, shim methods) to preserve backward compatibility. The `mitigate-breaking-changes` skill can be invoked to assist with this.
   - Submit the review as **"Request Changes"** with the list of breaking changes that need mitigation.

If `ApiCompatVersion` is not present in the `.csproj`, skip this phase — there is no prior stable version to compare against.

## Output Format

Submit a single **pull request review** with all findings as **inline comments** attached to the relevant file and line. Do not post findings as general PR comments.

### Agentic workflow mode

When this skill is run from a GitHub Agentic Workflow, all GitHub writes must go through the workflow's configured safe-output tools. Do **not** use direct `gh api` write calls, GitHub MCP write calls, or REST calls from the agent job.

Use the workflow-provided safe outputs instead:
- Emit one `create_pull_request_review_comment` output for each inline finding.
- Emit exactly one `submit_pull_request_review` output to submit the review.
- Use `REQUEST_CHANGES` for blocking issues, `COMMENT` for non-blocking/no findings. Do not use `APPROVE` — automated approvals are not permitted.

For `pull_request_target` workflows, treat PR contents as untrusted. Do not checkout the PR head or execute PR code. If Phase 3 requires build or ApiCompat results, rely on existing CI/check results and API diffs unless the workflow is running in a trusted context that explicitly allows executing PR code.

### How to submit the review

1. Collect all review findings across all phases. For each finding, record:
   - **file path** (relative to repo root)
   - **line number** (in the PR diff, use the last line of the relevant range)
   - **comment body** (the review feedback)
2. Submit **one** pull request review that includes all findings as inline review comments. Outside Agentic Workflow mode, use the `gh` CLI:
   ```
   gh api repos/{owner}/{repo}/pulls/{pull_number}/reviews \
     --method POST \
     --header "Accept: application/vnd.github+json" \
     --input - << 'EOF'
   {
     "event": "REQUEST_CHANGES",
     "body": "<overall summary>",
     "comments": [
       {
         "path": "<file>",
         "line": <line>,
         "side": "RIGHT",
         "body": "<comment>"
       }
     ]
   }
   EOF
   ```
   - Use `event: "REQUEST_CHANGES"` if any phase fails or there are blocking issues that must be resolved before merge.
   - Use `event: "COMMENT"` if all phases pass or there are only non-blocking/minor suggestions.
   - Do not use `event: "APPROVE"` — automated approvals are not permitted.

### Review content

1. Report Phase 1 (Versioning) result: pass or fail with details.
2. If Phase 1 fails, the overall review must be submitted as **"Request Changes"** — but still continue through Phase 2 (and Phase 3 where applicable) and include those findings in the same review, unless the versioning problem prevents determining the review scope (see Phase 1 instructions).
3. Include Phase 2 (API Review) results:
   - Summarize what passes review in the review body.
   - Each issue becomes an inline comment on the relevant file and line.
   - Include the contextual-naming coverage count (`evaluated N new public types, flagged M`).
4. If `ApiCompatVersion` exists, include Phase 3 (Breaking Change Detection) results:
   - Build the project and check for `ApiCompat` errors.
   - Each breaking change becomes an inline comment on the relevant file and line.
5. The review body should contain a final summary of all phases and the total number of inline comments added.

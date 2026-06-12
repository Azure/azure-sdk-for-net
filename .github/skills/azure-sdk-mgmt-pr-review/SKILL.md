---
name: azure-sdk-mgmt-pr-review
description: Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality.
---

# Azure .NET Mgmt SDK PR Review

Review Azure SDK for .NET management library PRs in three phases: **1. Versioning**, **2. API Review**, **3. Breaking Change Detection**. Run phases in order. Versioning failures are blocking, but continue into API review unless the baseline cannot be determined reliably.

## Phase 1: Versioning Review

Check the package `.csproj`, `CHANGELOG.md`, and compatibility files. Comment on every violation; any violation makes the final review `REQUEST_CHANGES`.

Rules:
- **No major version bump** unless .NET architects explicitly require a coordinated management-SDK major bump. Flag `1.x` -> `2.0.0` as Critical.
- **Do not remove `ApiCompatVersion`**. It enforces compatibility against the last stable release. If removed, recover the prior value from base branch or latest released tag for later phases.
- **No new `ApiCompatBaseline.txt` entries**. Do not suppress compatibility errors; mitigate with customization code or generator/spec fixes.

Continue to Phase 2 unless the versioning issue makes the API-review scope impossible to determine, e.g. `ApiCompatVersion` was removed and no prior stable baseline can be recovered. In that narrow case, request changes and say API review was skipped because the baseline is unknown.

## Phase 2: API Review

Review only new or changed public API relative to the latest stable release. Existing shipped API that is unchanged is out of scope.

### Scope

1. Read `ApiCompatVersion` from `.csproj`. If absent and never present, treat the whole API surface as new and skip breaking-change checks.
2. If present, fetch the released API file from tag `<PackageName>_<Version>`, e.g. `Azure.ResourceManager.Foo_1.0.0`, under `sdk/<service>/<PackageName>/api/<PackageName>.net10.0.cs` or older TFM variants.
3. Diff released API against the PR API file. Review only added/modified types, members, and enums.

### Workflow

1. Fetch existing PR comments and reviews first. Suppress duplicate inline and non-inline findings already raised by humans or earlier automation. Reinforce existing threads by replying instead of opening duplicates.
2. Run the trusted naming scanner:
   ```powershell
   pwsh .github/skills/azure-sdk-mgmt-pr-review/Check-MgmtNamingRules.ps1 -ApiFilePath <current-api-file> -BaselineApiFilePath <baseline-api-file>
   ```
   Omit `-BaselineApiFilePath` when there is no stable baseline. Use `-PackagePath` only for local/manual trusted reviews. In GitHub Agentic Workflow mode, run the scanner from the base branch against explicit API files fetched from PR/baseline; do not execute PR scripts.
3. Treat scanner API-file line numbers as symbol identifiers, not final comment targets. Resolve each finding to generated source, customization source, or TypeSpec customization files before commenting.
4. Run contextual naming exhaustively using inventory mode:
   ```powershell
   pwsh .github/skills/azure-sdk-mgmt-pr-review/Check-MgmtNamingRules.ps1 -ApiFilePath <current-api-file> -BaselineApiFilePath <baseline-api-file> -ListNewTypes
   ```
   Evaluate every `NEW` class/struct/enum. Verdicts: `OK`, `Flag`, or `OK (low confidence)`. The number of verdicts must equal the number of `NEW` entries. Report `Contextual naming: evaluated N new public types, flagged M`.
5. Review API files, `src/Generated/`, TypeSpec customizations (`client.tsp`, `main.tsp`, `tspconfig.yaml`), and SDK customizations for issues not covered by the scanner.

Scanner rule families include `SUFFIX001`-`SUFFIX010`, `RESINFIX001`, `RESNAME001`, `ACRONYM001`, `ACRONYM002`, `ARMCOMMON001`, `BOOL001`, `DATETIME001`, and `TTL001`. Contextual naming is intentionally manual; the scanner only provides the bounded worklist.

### Comment Targets

Use `api/*.cs` for analysis only. Do **not** target API listing files for inline comments; large API files can fail GitHub review-position resolution.

Resolve findings as follows:
- Generated models: `src/Generated/Models/<TypeName>.cs`.
- Resource/data types: `src/Generated/<TypeName>.cs`.
- Serialization findings: `src/Generated/**/<TypeName>.Serialization.cs`.
- Customized or compatibility-preserved symbols: the relevant `src/Customize/**`, `src/Customization*/**`, `src/Customized*/**`, or file containing `[CodeGenType]`, `[CodeGenSuppress]`, `[CodeGenMember]`, or the custom member.
- TypeSpec fixes: `client.tsp`, `main.tsp`, or `tspconfig.yaml` when in the PR diff.

Only emit inline comments for lines in the PR diff. If the correct source line is not in the diff, put the finding under `Non-inline findings` in the review body. For generated-source comments, request a TypeSpec/decorator/generator fix; never imply generated code should be hand-edited.

### API Checklist

Naming suffixes:

| Avoid suffix | Prefer | Exception |
|--------------|--------|-----------|
| `Parameter(s)` | `Content` / `Patch` | - |
| `Request` | `Content` | - |
| `Options` | `Config` | `ClientOptions` |
| `Response` | `Result` | - |
| `Update` | `Patch` / `Content` | - |
| `Data` | remove | Only if not `ResourceData` / `TrackedResourceData` |
| `Definition` | remove | Unless removal conflicts with another resource |
| `Operation` | `Data` / `Info` | `Operation<T>` |
| `Collection` | `Group` / `List` | Domain-specific names, e.g. `MongoDBCollection` |

ARM common types must not be redefined. Reuse framework types, or rename service-specific wire variants with RP context and document why they differ: `OperationStatusResult`, `ManagedServiceIdentity`, `ManagedServiceIdentityType`, `ManagedServiceIdentityPatch`, `UserAssignedIdentity`, `SystemData`, `TagsUpdate`, `TagsPatch`, `ErrorResponse`, `ErrorDetail`, `TrackedResource`.

Resource naming:
- Remove `Resource` suffix when the remaining noun is descriptive; keep it when removal makes the name generic, e.g. `GenericResource`.
- Resource data types use `Data` only when deriving from `ResourceData` / `TrackedResourceData`; otherwise prefer `Info`.
- Do not include `Resource` before `Data` or `Collection`: use `VirtualMachineData`, not `VirtualMachineResourceData`; use `VirtualMachineCollection`, not `VirtualMachineResourceCollection`.
- Exception: `*PrivateLinkResourceData` / `*PrivateLinkResourceCollection` are allowed because `PrivateLinkResource` is the ARM resource name.
- `RESNAME001`: after stripping `Resource`, `Data`, or `Collection`, a resource trio inheriting `ArmResource`, `ResourceData` / `TrackedResourceData`, or `ArmCollection` must still carry RP/domain context. Flag single generic nouns like `Drill`, `Goal`, `Recovery`, `Enrollment`; recommend renaming the whole trio together. `GenericResource` is the only built-in exception.

Operation/model/property rules:
- PATCH body: `[Model]Patch`.
- PUT/POST body: `[Model]Content` or `[Model]Data`.
- Boolean property prefix: `Is`, `Can`, `Has`, `Does`, `Should`, `Allow`, `Enable`, `Disable`, `Use`, `Support`.
- `DateTimeOffset` properties end with `On` or `At`.
- Integer interval/duration properties include units, e.g. `MonitoringIntervalInSeconds`.
- TTL properties use `TimeToLiveIn<Unit>`.
- Enums use singular names unless flags; numeric version members use underscore, e.g. `Tls1_0`, `Ver5_6`.
- CheckNameAvailability method: `Check[Resource/RP name]NameAvailability`; model/response: `[Resource/RP name]NameAvailabilityXXX`; unavailable reason enum: `[Resource/RP name]NameUnavailableReason`.
- PUT/PATCH optional body parameters should be required.
- Discriminator base models should be `abstract`.
- Remove `ListOperations` methods.

Acronyms:
- Use PascalCase for acronyms: `Aes`, `Tcp`, `Http`.
- 2-letter acronyms are uppercase if standalone, except `Id` and `Vm`.
- Expand acronyms that are not clearly explained in first-page search results with service context.

Contextual type naming:
- Type/enum/model names should be understandable in IntelliSense without relying only on namespace.
- Flag generic names such as `PublicNetworkAccess`, `EncryptionStatus`, `PrivateEndpointConnection`, `Scope`, `GroupScope`, `Sensitivity`, `ManagedRuleSetException` unless sufficiently scoped by RP/resource/domain context.
- Prefer names like `StorageAccountPublicNetworkAccess`, `CosmosDBEncryptionStatus`, `KeyVaultPrivateEndpointConnection`, `FrontDoorRuleScope`, `FrontDoorSensitivityType`.
- Do not apply the service-context test to enum members.
- Pay extra attention to short names, infrastructure concepts, ARM/.NET common-name duplicates, and unprefixed `*Properties` models.

Naming fix recommendation:
- If the symbol is defined in TypeSpec, recommend `@@clientName(..., "csharp")` in `client.tsp`, e.g. `@@clientName(PublicNetworkAccess, "DurableTaskPublicNetworkAccess", "csharp");`.
- If not defined in TypeSpec, recommend SDK customization such as `[CodeGenType("OriginalGeneratedName")]` on a renamed partial class.
- For migration PRs, compare against previous GA API first. If the generated name is a rename of shipped API, restore the shipped name rather than inventing a third stylistic name.

Type formatting:

| Property pattern | Expected type |
|------------------|---------------|
| UUID-valued `*Id` / `*Guid` | `Guid` |
| String `*Id` / `*ResourceId` holding ARM resource ID | `ResourceIdentifier` |
| `ResourceType` or `*Type` for resource types | `ResourceType` |
| `etag` | `ETag` |
| `location` / `locations` | Consider `AzureLocation` |
| `size` | Consider `int` / `long` instead of string |

Only flag `*Id` / `*ResourceId` for `Guid` or `ResourceIdentifier` when the generated C# type is `string`. Numeric, `Guid`, or other non-string IDs are intentional domain identifiers and should not be flagged. In TypeSpec, UUID-valued properties should use the `uuid` scalar.

Duration/interval TypeSpec format:
- ISO 8601 duration (`P1DT2H59M59S`): `duration` scalar.
- Constant duration (`2.2:59:59.5000000`): `@encode(DurationConstant)`.

SDK migration method renames:
- If a shipped method name changes, prefer renaming the generated API back to the shipped name.
- Do not keep old and new names just because generation changed the name.
- Keep a new name only when the old name is clearly wrong and the rename is intentional; then treat the old member as a compatibility shim and document why.
- A custom old-name method that only forwards to a new generated method usually means the generated method should be renamed back instead of exposing both.

## Phase 3: Breaking Change Detection

If `ApiCompatVersion` exists, check breaking changes after Phase 2. Locally, build the project and inspect ApiCompat errors. In untrusted `pull_request_target` workflows, do not build PR code; rely on CI/check results and API diffs unless the workflow explicitly runs in a trusted context.

For each ApiCompat error, list the removed/changed API and target the relevant source line when possible. Do not fix it during review; request mitigation through customization code, generator/spec features, or the `mitigate-breaking-changes` skill. Any unmitigated breaking change is blocking. If no `ApiCompatVersion` exists, skip this phase.

## Output Format

Submit one PR review. Prefer inline comments on commentable source files; put unattachable findings in `Non-inline findings`. Do not post findings as general PR comments. Never use `APPROVE`.

Agentic Workflow mode:
- Use only safe-output tools for GitHub writes.
- Emit one `create_pull_request_review_comment` per inline finding.
- Emit exactly one `submit_pull_request_review`.
- Use `REQUEST_CHANGES` for blocking findings; otherwise `COMMENT`.
- Treat PR contents as untrusted. Do not checkout/run PR code in `pull_request_target`.

Outside Agentic Workflow mode, use `gh api repos/{owner}/{repo}/pulls/{pull_number}/reviews` to submit one review with `comments`, `event`, and summary body.

Review body must include:
- Phase 1 result and any versioning failures.
- Phase 2 result, each inline/non-inline API issue, and contextual-naming coverage count.
- Phase 3 result when applicable.
- Final event based on the most severe finding: `REQUEST_CHANGES` for critical versioning issues, deterministic naming/API violations, breaking changes, or unmitigated manual/generated-code issues; `COMMENT` only for no findings or explicitly non-blocking suggestions.
- Total inline comment count.

---
name: azure-sdk-mgmt-pr-review
description: Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality.
---

# Azure .NET Mgmt SDK PR Review

Review Azure SDK for .NET management library pull requests against the official API review guidelines.

The review is split into three sequential phases: **Phase 1: Versioning Review** (gate), **Phase 2: API Review**, and **Phase 3: Breaking Change Detection**. Each phase must pass before proceeding to the next.

## Phase 1: Versioning Review

This phase checks version-related rules that are simple and rule-based. **If any violation is found in this phase, stop the review immediately, submit the review with "Request Changes", and do not proceed to Phase 2.**

### Instructions

1. Check the `.csproj` file and CHANGELOG.md for the rules below.
2. If all versioning rules pass, proceed to Phase 2.
3. If any rule is violated, add review comments on the violations, submit the review as **"Request Changes"** with a summary explaining the versioning violations, and **stop** — do not proceed to Phase 2.

### Versioning Rules

- **No major version bump.** Management SDK packages follow a unified versioning strategy. No individual package is allowed to bump its major version unless a major version bump decision has been explicitly made by the .NET architects for all mgmt packages. If a PR bumps the major version (e.g., from `1.x` to `2.0.0`), flag as **Critical**: "You must not bump the major version without the .NET architects' explicit requirement."
- **Do not remove `ApiCompatVersion`.** If a PR removes the `ApiCompatVersion` property from the `.csproj` file, flag as **Critical**. This property enforces API compatibility checks against the last stable release and must not be deleted. Removing it would allow breaking changes to slip through undetected.
- **No newly added content in `ApiCompatBaseline.txt`.** If the PR adds new entries to the `ApiCompatBaseline.txt` file (which suppresses ApiCompat errors), flag as **Critical**. Suppressing API compatibility errors hides breaking changes from customers. The correct approach is to mitigate breaking changes through customization code, not to baseline them away.

## Phase 2: API Review

This phase reviews the API surface for naming conventions, type correctness, and adherence to design guidelines. It runs only after Phase 1 passes.

### Scope of Review

The review should focus **only on new or changed API surface** compared to the RP's latest released stable version. Types, properties, and methods that were already shipped in a prior stable release cannot be changed and should not be flagged.

To determine the review scope:
1. Find the RP's latest released stable version. Check the `ApiCompatVersion` property in the package's `.csproj` file — since Phase 1 passed, this property is guaranteed to be present if it existed before. If `ApiCompatVersion` is not present, assume there is no prior stable version — the entire API surface is in scope for review and no breaking changes are possible.
2. If `ApiCompatVersion` is present, retrieve that version's API surface file from the corresponding git tag (tag format: `<PackageName>_<Version>`, e.g., `Azure.ResourceManager.Foo_1.0.0`). The API file is at `sdk/<service>/<PackageName>/api/<PackageName>.net10.0.cs` (or earlier TFM variants like `netstandard2.0.cs`).
3. Diff the released API surface against the PR's API surface file.
4. Only review types, properties, methods, and enums that appear in the diff (i.e., newly added or modified). Anything unchanged from the stable release is out of scope.

### Instructions

1. Determine review scope per the "Scope of Review" section above.
2. Examine API surface files (api/*.cs) for public API, focusing on new/changed surface.
3. Check Generated models and resources in src/Generated/.
4. Review TypeSpec customizations (e.g., `client.tsp`, `tspconfig.yaml`).
5. Add review comments directly to the PR using GitHub MCP tools.

### API Review Checklist

#### Naming - Avoid These Suffixes
| Suffix | Replace With | Exception |
|--------|--------------|-----------|
| Parameter(s) | Content/Patch | - |
| Request | Content | - |
| Options | Config | Unless ClientOptions |
| Response | Result | - |
| Data | - | Unless derives from ResourceData/TrackedResourceData |
| Definition | - | Unless removing it creates conflict with another resource |
| Operation | Data or Info | Unless derives from Operation<T> |
| Collection | Group/List | Unless domain-specific (e.g., MongoDBCollection) |

#### Resource Naming
- Remove "Resource" suffix if remaining noun is still descriptive (e.g., VirtualMachine not VirtualMachineResource)
- Keep "Resource" if removing makes it non-descriptive (e.g., GenericResource stays)
- For models: append "Data" suffix if inherits ResourceData/TrackedResourceData, otherwise "Info"

#### Operation Body Parameters
- **PATCH operation body:** Must be named `[Model]Patch`
- **PUT/POST operation body:** Must be named `[Model]Content` or `[Model]Data`

#### Property Naming
- **Boolean properties:** Must start with verb prefix: `Is`, `Can`, `Has`
- **DateTimeOffset properties:** Should end with `On` (e.g., `CreatedOn`, `StartOn`, `EndOn`)
- **Interval/Duration (integer):** Include units in name (e.g., `MonitoringIntervalInSeconds`)
- **TTL properties:** Rename to `TimeToLiveIn<Unit>`

#### Acronyms
- Use PascalCase (capitalize first letter only): `Aes`, `Tcp`, `Http`
- 2-letter acronyms: uppercase if standalone (`IO`), except `Id`, `Vm`
- Expand acronyms if not clearly explained in first page of search results with context

#### Contextual Naming for Types
- All types must have a name that includes sufficient context about what the type represents.
- Avoid generic or ambiguous names that could apply to many different services. The type name should make it clear which service or resource it belongs to.
- **Bad examples:** `PublicNetworkAccess`, `EncryptionStatus`, `PrivateEndpointConnection` — these names lack context; a reader cannot tell which service they belong to without looking at the namespace.
- **Good examples:** `StorageAccountPublicNetworkAccess`, `CosmosDBEncryptionStatus`, `KeyVaultPrivateEndpointConnection` — these names include the service or resource context.
- Exception: If the type is scoped within a clearly named parent model or the namespace already provides unambiguous context (e.g., a property type used exclusively by one resource), a shorter name may be acceptable.

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
   - For each error, add a review comment listing the breaking change (what was removed or changed).
   - Do **not** attempt to fix or mitigate the breaking changes yourself. Instead, list all detected breaking changes and ask the user to mitigate them. Mitigation options include customization code via partial classes and generator features (e.g., `rename-mapping`, custom properties, shim methods) to preserve backward compatibility. The `mitigate-breaking-changes` skill can be invoked to assist with this.
   - Submit the review as **"Request Changes"** with the list of breaking changes that need mitigation.

If `ApiCompatVersion` is not present in the `.csproj`, skip this phase — there is no prior stable version to compare against.

## Output Format

1. Report Phase 1 (Versioning) result: pass or fail with details
2. If Phase 1 fails, submit review as **"Request Changes"** and stop
3. If Phase 1 passes, report Phase 2 (API Review) results:
   - Summarize what passes review
   - For each issue found, add a review comment directly to the PR on the relevant file and line using GitHub MCP tools
4. If `ApiCompatVersion` exists, report Phase 3 (Breaking Change Detection) results:
   - Build the project and check for `ApiCompat` errors
   - If breaking changes are found, submit review as **"Request Changes"** and ask the user to mitigate them
5. Provide a final summary of all comments added

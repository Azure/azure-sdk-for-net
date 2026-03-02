---
name: azure-sdk-mgmt-pr-review
description: Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality.
---

# Azure .NET Mgmt SDK PR Review

Review Azure SDK for .NET management library pull requests against the official API review guidelines.

## Scope of Review

The review should focus **only on new or changed API surface** compared to the RP's latest released stable version. Types, properties, and methods that were already shipped in a prior stable release cannot be changed and should not be flagged.

To determine the review scope:
1. Find the RP's latest released stable version by checking the CHANGELOG.md for the most recent non-beta, non-Unreleased entry (e.g., `1.0.0`, `1.1.0`).
2. Retrieve that version's API surface file from the corresponding git tag (tag format: `<PackageName>_<Version>`, e.g., `Azure.ResourceManager.Foo_1.0.0`). The API file is at `sdk/<service>/<PackageName>/api/<PackageName>.net10.0.cs` (or earlier TFM variants like `netstandard2.0.cs`).
3. Diff the released API surface against the PR's API surface file.
4. Only review types, properties, methods, and enums that appear in the diff (i.e., newly added or modified). Anything unchanged from the stable release is out of scope.

If no prior stable version exists (i.e., this is the first GA or only betas have been released), then the entire API surface is in scope for review.

## Instructions

When asked to review an Azure SDK .NET management-plane library PR (packages `Azure.ResourceManager` and `Azure.ResourceManager.*`):

1. Fetch PR details and diff using GitHub MCP tools
2. Determine review scope per the "Scope of Review" section above
3. Examine API surface files (api/*.cs) for public API, focusing on new/changed surface
4. Check Generated models and resources in src/Generated/
5. Review TypeSpec customizations (e.g., `client.tsp`, `tspconfig.yaml`)
6. Add review comments directly to the PR using GitHub MCP tools

## Review Checklist

### Naming - Avoid These Suffixes
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

### Resource Naming
- Remove "Resource" suffix if remaining noun is still descriptive (e.g., VirtualMachine not VirtualMachineResource)
- Keep "Resource" if removing makes it non-descriptive (e.g., GenericResource stays)
- For models: append "Data" suffix if inherits ResourceData/TrackedResourceData, otherwise "Info"

### Operation Body Parameters
- **PATCH operation body:** Must be named `[Model]Patch`
- **PUT/POST operation body:** Must be named `[Model]Content` or `[Model]Data`

### Property Naming
- **Boolean properties:** Must start with verb prefix: `Is`, `Can`, `Has`
- **DateTimeOffset properties:** Should end with `On` (e.g., `CreatedOn`, `StartOn`, `EndOn`)
- **Interval/Duration (integer):** Include units in name (e.g., `MonitoringIntervalInSeconds`)
- **TTL properties:** Rename to `TimeToLiveIn<Unit>`

### Acronyms
- Use PascalCase (capitalize first letter only): `Aes`, `Tcp`, `Http`
- 2-letter acronyms: uppercase if standalone (`IO`), except `Id`, `Vm`
- Expand acronyms if not clearly explained in first page of search results with context

### Contextual Naming for Types
- All types must have a name that includes sufficient context about what the type represents.
- Avoid generic or ambiguous names that could apply to many different services. The type name should make it clear which service or resource it belongs to.
- **Bad examples:** `PublicNetworkAccess`, `EncryptionStatus`, `PrivateEndpointConnection` — these names lack context; a reader cannot tell which service they belong to without looking at the namespace.
- **Good examples:** `StorageAccountPublicNetworkAccess`, `CosmosDBEncryptionStatus`, `KeyVaultPrivateEndpointConnection` — these names include the service or resource context.
- Exception: If the type is scoped within a clearly named parent model or the namespace already provides unambiguous context (e.g., a property type used exclusively by one resource), a shorter name may be acceptable.

### Enums
- Use singular type name (not plural) unless bit flags
- Numeric version enums should use underscore: `Tls1_0`, `Ver5_6`

### Type Formatting

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

### Duration/Interval Format
- ISO 8601 duration (P1DT2H59M59S): use `duration` scalar in TypeSpec
- ISO 8601 constant (2.2:59:59.5000000): use `@encode(DurationConstant)` in TypeSpec

### CheckNameAvailability Operation
- Method: `Check[Resource/RP name]NameAvailability`
- Parameter/Response model: `[Resource/RP name]NameAvailabilityXXX`
- Unavailable reason enum: `[Resource/RP name]NameUnavailableReason`

### Versioning
- **Management SDK packages follow a unified versioning strategy.** No individual package is allowed to bump its major version unless a major version bump decision has been explicitly made by the .NET architects for all mgmt packages.
- If a PR bumps the major version (e.g., from `1.x` to `2.0.0`) due to breaking changes, flag this as a **Must Fix**: "You must not bump the major version without the .NET architects' explicit requirement. Even with breaking changes, mgmt packages must stay on the current major version unless a coordinated major bump is in progress."
- When the new API version introduces breaking changes (e.g., removed properties, renamed types), the SDK must **mitigate them at the API surface level** so there are no breaking changes to customers. Use customization code via partial classes and generator features (e.g., `rename-mapping`, custom properties, shim methods) to preserve backward compatibility. The goal is to avoid breaking changes entirely so a major version bump is not needed.

### Other API Rules
- PUT/PATCH optional body parameters should be changed to required
- Discriminator models should make base model `abstract`
- Remove all `ListOperations` methods (SDK exposes operations via public APIs)

## Output Format

1. Summarize what passes review
2. For each issue found, add a review comment directly to the PR on the relevant file and line using GitHub MCP tools
3. Provide a final summary of all comments added

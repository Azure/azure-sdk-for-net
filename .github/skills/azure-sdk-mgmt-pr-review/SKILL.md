---
name: azure-sdk-mgmt-pr-review
description: Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality.
---

# Azure .NET Mgmt SDK PR Review

Review Azure SDK for .NET management library pull requests against the official API review guidelines.

## Instructions

When asked to review an Azure SDK .NET management-plane library PR (packages `Azure.ResourceManager` and `Azure.ResourceManager.*`):

1. Fetch PR details and diff using GitHub MCP tools
2. Examine API surface files (api/*.cs) for public API
3. Check Generated models and resources in src/Generated/
4. Review TypeSpec customizations (e.g., `client.tsp`, `tspconfig.yaml`)
5. Add review comments directly to the PR using GitHub MCP tools

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

### Other API Rules
- PUT/PATCH optional body parameters should be changed to required
- Discriminator models should make base model `abstract`
- Remove all `ListOperations` methods (SDK exposes operations via public APIs)

## Output Format

1. Summarize what passes review
2. For each issue found, add a review comment directly to the PR on the relevant file and line using GitHub MCP tools
3. Provide a final summary of all comments added

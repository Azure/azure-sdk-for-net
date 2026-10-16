# Apply Naming Customizations

This is an edit workflow, not a prerequisite for guidance or review.

## Before Calling

Require authorization to edit and resolve all affected decisions from the [naming plan](naming-conventions.md#plan). Confirm the absolute TypeSpec project root, target declarations, language scope, intended SDK names, existing overrides, and release compatibility. Do not apply blocked, ambiguous, unsupported, or synthesized-target renames.

Prefer `azure-sdk-mcp:azsdk_customized_code_update` to apply SDK-only naming overrides when available. Supply:

| Argument               | Value                                                                                                       |
| ---------------------- | ----------------------------------------------------------------------------------------------------------- |
| `tspProjectPath`       | Absolute local project directory containing `tspconfig.yaml`                                                |
| `editScope`            | `SpecInputs` explicitly; never rely on the default `All`                                                    |
| `customizationRequest` | Exact TypeSpec targets, proposed names, language scopes, evidence/constraints and preservation requirements |

Omit `packagePath`; no SDK package or checkout is needed for this spec-only workflow. Explicitly state the SDK language in the request because no package is available to infer it. `SpecInputs` excludes SDK custom-code repair and skips the tool's SDK regeneration/build stage.

Example request text:

> For C# ARM, rename the unshipped SDK property for `WidgetProperties.enabled` to `IsEnabled` using `@@clientName(..., "csharp")`. Reuse the existing `client.tsp` and ensure the generation entrypoint loads it. Preserve the wire name `enabled`, all Java/Python overrides, routes and other declarations. Do not modify SDK code or dependencies.

When available, the tool owns decorator imports, placement, target resolution and customization edits; do not duplicate its mutation with file-edit or shell tools. For exact enum names, include the verified installed TCGC capability and required spelling; if unsupported, report the blocker rather than upgrading dependencies or writing unavailable syntax.

## Fallback When the Customization Tool Is Unavailable

If the tool is not exposed or its server cannot be reached before any mutation,
report that limitation and apply the approved naming plan directly:

1. Read the existing `client.tsp`, source targets and generation entrypoint.
   Reuse existing imports, namespace conventions and overrides. Confirm the
   installed TCGC supports the required decorator syntax.
2. Create or minimally update `client.tsp` with language-scoped augment
   decorators, for example
   `@@clientName(WidgetProperties.enabled, "IsEnabled", "csharp");`.
   Add the TCGC import and `using Azure.ClientGenerator.Core;` if needed.
   Update an existing override for the same target/scope rather than adding a
   conflicting duplicate. Preserve other-language overrides.
3. Ensure the project's generation entrypoint loads `client.tsp`, following its
   existing import structure without introducing an import cycle. Limit edits
   to naming overrides and their necessary imports/loading; do not rename
   source declarations, change types or wire contracts, upgrade dependencies,
   or edit SDK code.
4. Inspect the diff and perform the same validation below. Report that direct
   edits were used and distinguish applied names from verified generated names.

Missing project evidence or unsupported syntax remains a blocker, not permission
to guess. This fallback does not replace unavailable validation tooling.

## Results and Failures

- Inspect `Success`, error details, change summaries and remaining guidance. Do not claim all decisions were applied if the response is incomplete or reports manual intervention.
- If the tool is unavailable before mutation, use the fallback above. If an invoked customization fails or times out, report the unresolved customization; do not automatically fall back to direct edits, broaden scope to `All`/`CustomCode`, or create SDK-side rename shims.
- If a tool failure may have left partial edits, inspect the diff read-only and report them. Do not undo unrelated work or repeat mutations blindly.
- Read the resulting diff to verify planned names, scopes, customization loading and unchanged wire/other-language names. A tool success response or a valid `client.tsp` override is not evidence that generated SDK names were verified.

## Validation After Writes

The calling authoring workflow retains its normal TypeSpec validation. For a standalone naming fix, run `azure-sdk-mcp:azsdk_run_typespec_validation` and the project's normal TypeSpec compile command after either apply path. If the validation tool is unavailable, still run compilation when possible, but report the MCP check as not run and validation as incomplete. Do not substitute an SDK build or mark unrun checks as passed.

SDK generation is not required to consult or apply naming guidance. Without generation, report effective SDK names as unverified. Read-only review never runs this apply/validation sequence; it returns suggested changes and evidence gaps to the reviewer.

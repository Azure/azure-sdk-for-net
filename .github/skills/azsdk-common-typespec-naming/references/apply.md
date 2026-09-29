# Apply Naming Customizations

This is an edit workflow, not a prerequisite for guidance or review.

## Before Calling

Require authorization to edit and resolve all affected decisions from the [naming plan](naming-conventions.md#plan). Confirm the absolute TypeSpec project root, target declarations, language scope, intended SDK names, existing overrides, and release compatibility. Do not apply blocked, ambiguous, unsupported, or synthesized-target renames.

Use `azure-sdk-mcp:azsdk_customized_code_update` to apply SDK-only naming overrides. Supply:

| Argument               | Value                                                                                                       |
| ---------------------- | ----------------------------------------------------------------------------------------------------------- |
| `tspProjectPath`       | Absolute local project directory containing `tspconfig.yaml`                                                |
| `editScope`            | `SpecInputs` explicitly; never rely on the default `All`                                                    |
| `customizationRequest` | Exact TypeSpec targets, proposed names, language scopes, evidence/constraints and preservation requirements |

Omit `packagePath`; no SDK package or checkout is needed for this spec-only workflow. Explicitly state the SDK language in the request because no package is available to infer it. `SpecInputs` excludes SDK custom-code repair and skips the tool's SDK regeneration/build stage.

Example request text:

> For C# ARM, rename the unshipped SDK property for `WidgetProperties.enabled` to `IsEnabled` using `@@clientName(..., "csharp")`. Reuse the existing `client.tsp` and ensure the generation entrypoint loads it. Preserve the wire name `enabled`, all Java/Python overrides, routes and other declarations. Do not modify SDK code or dependencies.

The tool owns decorator imports, placement, target resolution and customization edits. Do not duplicate that implementation with file-edit or shell tools. For exact enum names, include the verified installed TCGC capability and required spelling; if unsupported, report the blocker rather than upgrading dependencies or writing unavailable syntax.

## Results and Failures

- Inspect `Success`, error details, change summaries and remaining guidance. Do not claim all decisions were applied if the response is incomplete or reports manual intervention.
- If the tool is unavailable, fails, or times out, report the unresolved customization. Do not fall back to direct edits, broaden scope to `All`/`CustomCode`, or create SDK-side rename shims.
- If a tool failure may have left partial edits, inspect the diff read-only and report them. Do not undo unrelated work or repeat mutations blindly.
- Read the successful diff to verify planned names, scopes, customization loading and unchanged wire/other-language names. A tool success response is not evidence that generated SDK names were verified.

## Validation After Writes

The calling authoring workflow retains its normal TypeSpec validation. For a standalone naming fix, run `azure-sdk-mcp:azsdk_run_typespec_validation` and the project's normal TypeSpec compile command after successful customization. Report missing tooling or failures; do not substitute an SDK build or mark unrun checks as passed.

SDK generation is not required to consult or apply naming guidance. Without generation, report effective SDK names as unverified. Read-only review never runs this apply/validation sequence; it returns suggested changes and evidence gaps to the reviewer.

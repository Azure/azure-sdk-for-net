# Apply Naming Customizations

This is an edit workflow, not a prerequisite for guidance or review.

## Before Editing

Require authorization to edit and resolve all affected decisions from the [naming plan](naming-conventions.md#plan). Confirm the absolute TypeSpec project root, target declarations, language scope, intended SDK names, existing overrides, and release compatibility. Do not apply blocked, ambiguous, unsupported, or synthesized-target renames.

Apply naming-only overrides directly with file-edit tools. Do not call
`azure-sdk-mcp:azsdk_customized_code_update`, even when available. No SDK package
or checkout is needed. Other SDK customization requests remain with their
existing workflows.

## Scoped Direct Edits

1. Read the complete existing `client.tsp`, source targets and generation
   entrypoint before editing. Reuse existing imports, namespace conventions and
   overrides. Confirm the installed TCGC supports the required decorator syntax.
   Preserve pre-existing content, including portions outside the edited range;
   do not replace the file from a truncated read.
2. Create or minimally update `client.tsp` with language-scoped augment
   decorators, for example
   `@@clientName(WidgetProperties.enabled, "IsEnabled", "csharp");`.
   Add the TCGC import and `using Azure.ClientGenerator.Core;` if needed.
   Update an existing override for the same target/scope rather than adding a
   conflicting duplicate. Preserve shipped names and other-language overrides.
3. Ensure the project's generation entrypoint loads `client.tsp`, following its
   existing import structure without introducing an import cycle. Limit edits
   to naming overrides and their necessary imports/loading; do not rename
   source declarations, change types or wire contracts, upgrade dependencies,
   or edit SDK code.
4. Inspect the full diff to verify planned targets, names, scopes, loading and
   preservation of every unrelated customization. Perform the validation below.
   Distinguish applied names from verified generated names.

Missing project evidence or unsupported syntax remains a blocker, not permission
to guess. For exact enum names, verify installed TCGC capability and spelling;
if unsupported, report the blocker rather than upgrading dependencies or
writing unavailable syntax.

## Results and Failures

- Report incomplete or failed edits explicitly. Inspect partial changes before
  retrying; do not undo unrelated work or repeat mutations blindly.
- A valid `client.tsp` override is evidence that a customization is applied,
  not evidence that generated SDK names were verified.
- Do not broaden a naming-only fix into SDK custom-code repair, generation,
  or SDK-side rename shims.

## Validation After Writes

The calling authoring workflow retains its normal TypeSpec validation. For a standalone naming fix, run `azure-sdk-mcp:azsdk_run_typespec_validation` and the project's normal TypeSpec compile command after edits. If the validation tool is unavailable, still run compilation when possible, but report the MCP check as not run and validation as incomplete. Do not substitute an SDK build or mark unrun checks as passed.

SDK generation is not required to consult or apply naming guidance. Without generation, report effective SDK names as unverified. Read-only review never runs this apply/validation sequence; it returns suggested changes and evidence gaps to the reviewer.

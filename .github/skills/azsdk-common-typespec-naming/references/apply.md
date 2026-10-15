# Apply Naming Customizations

This is an edit workflow, not a prerequisite for guidance or review.

## Before Editing

Require authorization to edit and resolve all affected decisions from the [naming plan](naming-conventions.md#plan). Confirm the absolute TypeSpec project root, target declarations, language scope, intended SDK names, existing overrides, and release compatibility. Do not apply blocked, ambiguous, unsupported, or synthesized-target renames.

Read the existing `client.tsp` and the project entrypoint before writing. Apply only when:

- the target resolves to a service-owned TypeSpec declaration;
- `client.tsp` is loaded by the active generation entrypoint;
- the requested decorator is supported by the installed TCGC version; and
- the edit can preserve wire names, other language scopes and unrelated overrides.

If any condition is not established, report the blocker instead of guessing or broadening the edit.

## Edit `client.tsp`

Make the smallest direct edit to `client.tsp`. Reuse the project's existing imports, namespace qualification and decorator placement. For example:

```typespec
@@clientName(WidgetProperties.enabled, "IsEnabled", "csharp");
```

Add the `@azure-tools/typespec-client-generator-core` import or `using Azure.ClientGenerator.Core;` only when the file needs it and the installed package provides it. Preserve existing decorators and ordering conventions. Do not edit `main.tsp`, service models, routes, SDK code, generated code, package manifests or dependencies to make a naming-only customization work.

For exact enum names, require verified installed TCGC capability and spelling. If unsupported, report the blocker rather than upgrading dependencies or writing unavailable syntax.

## Results and Failures

- Inspect the diff after writing. Verify planned targets, names and language scopes, customization loading, and unchanged wire/other-language names.
- If an edit fails or leaves a partial change, inspect and repair only the naming edit. Do not undo unrelated work or create SDK-side rename shims.
- A valid `client.tsp` override proves the customization is declared and compiles; it is not evidence that the generated SDK exposes the expected API name.

## Validation After Writes

The calling authoring workflow retains its normal validation sequence. For a standalone naming fix, run the project's normal TypeSpec compile command after editing, normally `npx --no-install tsp compile .` from the TypeSpec project root. Fix compile failures caused by the naming edit and rerun. Report missing tooling or unrelated failures; do not substitute an SDK build or mark an unrun compile as passed.

SDK generation is not required to consult or apply naming guidance. Without generation, report effective SDK names as unverified. Read-only review never runs this apply/validation sequence; it returns suggested changes and evidence gaps to the reviewer.

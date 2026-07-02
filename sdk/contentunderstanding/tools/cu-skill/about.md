# `cu-skill/` — library, not a skill

Pure-C# helpers used by the authoring skill scripts under
`.github/skills/cu-sdk-author-analyzer*/scripts/`.

The leading underscore marks this as a **library directory**, not a skill. It
is intentionally excluded from the Copilot skill picker.

Rules for code here:

- **No `Azure.*` SDK imports.** No network calls. No I/O beyond reading/parsing
  caller-provided JSON.
- **No new runtime dependencies.** `System.Text.Json` only.
- **Stable, small, well-tested.** Anything here is referenced by multiple skill
  scripts; breakage cascades.

Current modules:

- `SchemaValidator.cs` — validates analyzer schema JSON before any
  service call (catches `baseAnalyzerId` typos, missing `fieldSchema`,
  missing `contentCategories` analyzer routes, etc.).

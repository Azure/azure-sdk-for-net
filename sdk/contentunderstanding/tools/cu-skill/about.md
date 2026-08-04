# `cu-skill/` — CLI tool for the Copilot authoring skills

The `cu-skill` .NET CLI tool that backs the Copilot skills under
`Azure.AI.ContentUnderstanding/.github/skills/cu-sdk-author-analyzer*/`. It
exposes three subcommands: `extract-layout`, `create-and-test`, and
`create-and-test-router`.

This directory sits under `sdk/contentunderstanding/tools/` rather than the
package directory so it is not part of the shipping SDK and does not affect
`Azure.AI.ContentUnderstanding.sln` builds.

Rules for code here:

- **Pure modules must stay pure.** `SchemaValidator.cs` and any file matching
  `*.Helpers.cs` must not reference `Azure.*`, must not perform network calls,
  and must not do I/O beyond reading/parsing caller-provided JSON. These
  modules are linked (via `<Compile Link>`) into the package test project so
  they can be unit-tested without an SDK dependency.
- The command implementations (`ExtractLayoutCommand.cs`,
  `CreateAndTestCommand.cs`, `CreateAndTestRouterCommand.cs`) intentionally
  use the Azure SDK and call the service.
- **No new runtime dependencies** for the pure modules — `System.Text.Json`
  only.
- **Stable, small, well-tested.** Pure modules are referenced by multiple
  skill scripts and their tests; breakage cascades.

Current modules:

- `SchemaValidator.cs` — validates analyzer schema JSON before any
  service call (catches `baseAnalyzerId` typos, missing `fieldSchema`,
  missing `contentCategories` analyzer routes, etc.).
- `CreateAndTestCommand.Helpers.cs` and
  `CreateAndTestRouterCommand.Helpers.cs` — pure summary/wrapping helpers
  used by the command implementations and unit-tested independently.

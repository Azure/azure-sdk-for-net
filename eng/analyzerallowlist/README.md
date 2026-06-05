# Analyzer Allow-List

This directory contains per-package analyzer allow-list files that record SDK-team-**approved**
diagnostic suppressions for shipping client libraries. Every file in this directory represents an
explicit, reviewed approval with a justification.

> **Not "approved" yet?** If a project has existing `<NoWarn>` entries that have **not** been
> reviewed by the SDK team, the project should be listed in
> [`eng/NoWarnSkipValidation.txt`](../NoWarnSkipValidation.txt) — the temporary backlog — rather
> than getting a file here. See [Workflow](#workflow) below.

## File Naming

Files are named by `$(MSBuildProjectName)`:

```
eng/analyzerallowlist/<ProjectName>.txt
```

For example: `Azure.Storage.Blobs.txt`, `Azure.Identity.txt`

## File Format

```
# Comments start with #
# Blank lines are ignored

# Whole-assembly NoWarn entries — codes injected into $(NoWarn) at build time
nowarn:AZC0035
nowarn:CS1591

# Per-symbol entries — handled by AllowListDiagnosticSuppressor in Azure.SdkAnalyzers
nowarn:AZC0034 T:Azure.Foo.Bar                       # all sites inside type Foo.Bar
nowarn:AZC0007 M:Azure.Foo.Bar.#ctor(System.String)  # one specific member
nowarn:CS0618  N:Azure.Foo.Models                    # everything in namespace + descendants
```

### `nowarn:CODE`

A bare `nowarn:` line (no scope) approves the use of `CODE` for the entire project
**and applies it automatically** — the build system injects approved codes into
`$(NoWarn)` before compilation, so projects should **not** keep an equivalent entry
in the csproj's `<NoWarn>` property. The allow-list file is the single source of
truth: every listed code is both reviewed and active.

If a code appears in the csproj's `<NoWarn>` without being on this list (and not
in the central allow-list), the build fails with `AZSDK0002`.

### `nowarn:CODE Target` — per-symbol suppression

A scoped entry is written as `nowarn:CODE Target` where `CODE` and `Target` are
separated by **a single space character** (not a tab or any other whitespace).
The `Target` is a Roslyn DocumentationCommentId; the kind prefix tells the
analyzer what scope to apply:

| Prefix | Scope |
|--------|-------|
| `T:`   | The named type and everything declared inside it (including nested types) |
| `M:`   | The named method or constructor |
| `N:`   | The named namespace and every type / member declared inside it |
| `P:`   | The named property |
| `F:`   | The named field |
| `E:`   | The named event |

A leading `~` (e.g., `~T:Foo`) is tolerated for parity with the
`[SuppressMessage(Target = "~T:Foo")]` attribute form but is not required.

**Why use scoped entries?** A bare `nowarn:AZC0034` silences the diagnostic for
the entire assembly forever — including types that don't exist yet. A scoped
entry keeps the analyzer live for every site except the specific symbol the
SDK team has reviewed and approved.

**Limitation:** scoped suppression only works for diagnostics whose descriptor
declares `DiagnosticSeverity.Warning` (or lower). Diagnostics that ship as
`DiagnosticSeverity.Error` (e.g., `AZC0034` in `azure-sdk-tools`) are skipped
by Roslyn's `DiagnosticSuppressor` pipeline — for those, the underlying
analyzer needs to ship the descriptor as Warning instead, with `/warnaserror+`
elevating it back to Error globally.

## How It Works

1. `eng/AnalyzerAllowList.targets` reads the per-package `.txt` file at build time.
2. It extracts `nowarn:` lines into the `_ProjectAllowedNoWarn` MSBuild property and
   **appends them to `$(NoWarn)`** so the compiler honors the suppression without
   the project needing to duplicate the code in its csproj.
3. `eng/NoWarnValidation.targets` uses `_ProjectAllowedNoWarn` to validate that any
   codes the project itself declares in `<NoWarn>` are all approved. Any unapproved
   csproj-declared code fails the build with `AZSDK0002`.
4. Projects listed in `eng/NoWarnSkipValidation.txt` short-circuit the validator entirely
   (temporary backlog escape hatch).

## Workflow

### Adding an approved suppression

Use this only when the suppression is genuinely project-wide and the underlying warning
cannot be fixed or narrowed:

1. Create or edit `eng/analyzerallowlist/<YourProjectName>.txt`.
2. Add a `nowarn:CODE` line for the diagnostic you need to suppress. **Do not also add
   the code to `<NoWarn>` in the csproj** — the build injects it automatically.
3. **Include a comment immediately above each entry** explaining *why* the suppression is
   needed and why it can't be narrowed.
4. The PR adding the entry will be reviewed by the SDK team.

**Preferred alternatives:**

- Fix the underlying warning so the suppression can be removed.
- Use a scoped `#pragma warning disable CODE // justification` at the file or member level,
  then remove the `<NoWarn>` entry from the csproj.
- Use `[SuppressMessage]` with a `Justification` parameter for non-pragma-compatible scopes.

### Removing a project from the skip list

When picking a project out of `eng/NoWarnSkipValidation.txt`:

1. Delete the project's line from `eng/NoWarnSkipValidation.txt`.
2. Build the project. The validator will report each unapproved `<NoWarn>` code as an
   `AZSDK0002` error.
3. For each error, decide one of:
   - **Fix:** make the underlying warning go away and delete the code from `<NoWarn>`.
   - **Migrate:** convert to a scoped `#pragma warning disable` with a justification and
     remove from `<NoWarn>`.
   - **Approve:** add a `nowarn:CODE` entry to this directory's file for the project, with
     a justification comment, **and remove the code from the csproj `<NoWarn>`** — the
     allow-list entry both records the approval and applies the suppression.
4. Land in a per-project PR.

## Related

- `eng/NoWarnValidation.targets` — The validation target that enforces NoWarn policy
- `eng/AnalyzerAllowList.targets` — MSBuild logic that reads these files
- `eng/NoWarnSkipValidation.txt` — Temporary backlog of unverified projects
- [Issue #55312](https://github.com/Azure/azure-sdk-for-net/issues/55312) — NoWarn visibility
- [Issue #57586](https://github.com/Azure/azure-sdk-for-net/issues/57586) — Suppression validation


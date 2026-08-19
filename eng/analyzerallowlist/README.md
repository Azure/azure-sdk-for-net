# Analyzer Allow-List

This directory contains per-package analyzer allow-list files that record SDK-team-**approved**
diagnostic suppressions for shipping client libraries. Every file in this directory represents an
explicit, reviewed approval with a justification.

> **Inline suppression migration pending?** Projects whose existing pragmas and suppression
> attributes have not yet been migrated are temporarily listed in
> [`eng/CodeAnalysisSuppressionSkipValidation.txt`](../CodeAnalysisSuppressionSkipValidation.txt)
> — the temporary backlog that skips `AZC0041` enforcement. See [Workflow](#workflow) below.

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
nowarn:CS0618 N:Azure.Foo.Models                     # everything in namespace + descendants
nowarn:OPENAI001 SourceGenerated                     # only sites inside *.g.cs generator output
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

Scoped entries require a Roslyn `SuppressionDescriptor` for the diagnostic ID. The descriptors
exposed by `AllowListDiagnosticSuppressor.SupportedSuppressions` are built from
`ScopedSuppressionSupportedDiagnosticIds` in `AllowListDiagnosticSuppressor.cs`. If the diagnostic
you need is not yet in that set, add it there in the same PR and use a scoped entry. Missing
suppressor support is not a reason to use a project-wide `nowarn:CODE` entry.

### `nowarn:CODE SourceGenerated` — source-generator-output suppression

A scoped entry whose target is the keyword `SourceGenerated` (case-insensitive)
suppresses `CODE` only at sites inside **source-generator output** — files whose
path ends with `.g.cs`. These are emitted by a source generator at build time and
exist only in the compiler's view, so they cannot be edited or `#pragma`-annotated
at the source (e.g. the compile-time `ModelReaderWriterContext` partial that
references external experimental types).

This scope deliberately does **not** cover checked-in generated code under a
`Generated/` folder. That code is regenerable, so a diagnostic there should be
fixed at its source — correct per-symbol `[Experimental]` attribution or a tight
`#pragma` emitted by the code generator — rather than silenced by a blanket
suppression. Example:

```
# OPENAI001 refs the source generator emits into the compile-time
# ModelReaderWriterContext .g.cs (references to the external experimental
# OpenAI.OpenAIContext) that we cannot annotate at the source. Hand-written and
# checked-in generated code carry per-symbol [Experimental]/pragmas instead.
nowarn:OPENAI001 SourceGenerated
```

**Limitation:** scoped suppression (both symbol- and `SourceGenerated`-scoped)
only works for diagnostics whose descriptor declares `DiagnosticSeverity.Warning`
(or lower). Roslyn's `DiagnosticSuppressor` pipeline dispatches on the
descriptor's **default** severity, so a warning promoted to an error by
`/warnaserror` is still suppressible; a diagnostic whose descriptor ships as
`DiagnosticSeverity.Error` (e.g., `AZC0034` in `azure-sdk-tools`) is not. Note
that `[Experimental("…")]` diagnostics such as `OPENAI001` have a **Warning**
default severity (the attribute promotes them to errors), so they *can* be
scoped-suppressed — for a genuine `Error`-descriptor diagnostic, the underlying
analyzer must instead ship the descriptor as Warning with `/warnaserror+`
elevating it back to Error globally.


## How It Works

1. `eng/AnalyzerAllowList.targets` reads the per-package `.txt` file at build time.
2. It extracts `nowarn:` lines into the `_ProjectAllowedNoWarn` MSBuild property and
   **appends them to `$(NoWarn)`** so the compiler honors the suppression without
   the project needing to duplicate the code in its csproj.
3. `eng/NoWarnValidation.targets` uses `_ProjectAllowedNoWarn` to validate that any
   codes the project itself declares in `<NoWarn>` are all approved. Any unapproved
   csproj-declared code fails the build with `AZSDK0002`.

## Workflow

### Adding an approved suppression

If a suppression is genuine and cannot be fixed, prefer the narrowest suppression
that covers the approved exception:

1. Create or edit `eng/analyzerallowlist/<YourProjectName>.txt`.
2. Add a symbol-scoped `nowarn:CODE Target` entry for the diagnostic. If `CODE` is not yet in
   `AllowListDiagnosticSuppressor.ScopedSuppressionSupportedDiagnosticIds`, add it so
   `SupportedSuppressions` exposes the required descriptor.
3. **Include a comment immediately above each entry** explaining *why* the suppression is
   needed and why that target is the narrowest appropriate scope.
4. The PR adding the entry will be reviewed by the SDK team.

Use a bare `nowarn:CODE` entry only when the warning genuinely applies to the entire project or
cannot technically be scoped. **Do not also add the code to `<NoWarn>` in the csproj** — the build
injects approved project-wide entries automatically. Its justification must explain why a scoped
target is not appropriate.

**Order of preference:**

- Fix the underlying warning so the suppression can be removed.
- Add a symbol-scoped `nowarn:CODE Target` entry so analysis remains enabled everywhere else,
  extending `ScopedSuppressionSupportedDiagnosticIds` when necessary.
- Use a justified project-wide `nowarn:CODE` entry only as a last resort when the diagnostic is
  inherently project-wide or cannot be handled by Roslyn's suppression pipeline.

`AZC0041` rejects warning-disable pragmas and suppression attributes in handwritten source, except
`UnconditionalSuppressMessage` attributes for IL2xxx trimming and IL3xxx AOT diagnostics. These
attributes must remain in source because downstream trim/AOT tools read them from the shipped
assembly when customers publish their applications. Do not replace them with `nowarn:` entries,
which apply only while compiling the SDK.

### Removing a project from the code-analysis suppression skip list

Projects in `eng/CodeAnalysisSuppressionSkipValidation.txt` retain their existing local
suppressions while migration is pending. An entry temporarily prevents
`CodeAnalysisSuppressionAnalyzer` from registering its `AZC0041` analysis actions for that
project; it is not an approval and does not suppress any underlying diagnostic itself.

When picking a project from the backlog:

1. Delete the project's line from `eng/CodeAnalysisSuppressionSkipValidation.txt` locally to
   activate `AZC0041`.
2. Build every target framework for the project and inventory each reported pragma or suppression
   attribute, regardless of diagnostic ID. Bare `#pragma warning disable` directives require
   particular care: remove the directive and build to discover every warning it hid.
3. For each reported suppression, choose one of:
   - **Fix:** resolve the underlying warning and remove the local suppression.
   - **Preserve trim/AOT metadata:** for an IL2xxx or IL3xxx diagnostic, replace a pragma or
     `SuppressMessage` with `UnconditionalSuppressMessage`. Do not add a `nowarn:` entry; customer
     publish tools read the suppression from the shipped assembly.
   - **Approve narrowly:** add a justified symbol-scoped `nowarn:CODE Target` entry to the
     project's allow-list file and remove the local suppression. If the diagnostic is not yet in
     `ScopedSuppressionSupportedDiagnosticIds`, add it in the same PR.
   - **Approve project-wide:** only when a symbol scope is impractical, add a justified bare
     `nowarn:CODE` entry and remove the local suppression.
4. Do not edit generated code. `AZC0041` excludes generated source from analysis.
5. Account for linked shared source. Suppressions are governed by the consuming
   `$(MSBuildProjectName)`, so each shipping project compiling the source may need its own scoped
   approval.
6. Build every target framework again, run relevant tests, and permanently remove the project
   from the skip list in the same change.

Prefer one project or a small, logically connected package family per migration change. Keep the
skip list alphabetical and never add a new project merely to bypass a new `AZC0041` failure.
After the final project is migrated, delete the empty skip-list file. Shipping-library scope is
configured independently, so an absent skip-list file is treated as an empty backlog and leaves
`AZC0041` fully enforced.

## Related

- `eng/NoWarnValidation.targets` — The validation target that enforces NoWarn policy
- `eng/AnalyzerAllowList.targets` — MSBuild logic that reads these files
- `eng/CodeAnalysisSuppressionSkipValidation.txt` — Temporary backlog of projects with local
  suppression migration pending
- [Issue #55312](https://github.com/Azure/azure-sdk-for-net/issues/55312) — NoWarn visibility
- [Issue #57586](https://github.com/Azure/azure-sdk-for-net/issues/57586) — Suppression validation

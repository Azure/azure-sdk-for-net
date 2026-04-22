# Analyzer Allow-List

This directory contains per-package analyzer allow-list files that govern which
diagnostic suppressions are approved for each shipping client library.

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

# NoWarn entries — codes allowed in <NoWarn> in the .csproj
nowarn:AZC0035
nowarn:CS1591

# (Future) Inline suppression entries — codes allowed in #pragma / [SuppressMessage]
# AZC0002:M:Azure.Storage.Blobs.AppendBlobClient.AppendBlock
```

### `nowarn:CODE`

Each `nowarn:` line approves the use of `CODE` in the project's `<NoWarn>` property.
Codes not listed here (and not in the central allow-list) will cause a build error.

### `CODE:SYMBOL` (future)

These entries will be consumed by a Roslyn analyzer to approve inline suppressions
(`#pragma warning disable` and `[SuppressMessage]`). This format is not yet enforced.

## How It Works

1. `eng/AnalyzerAllowList.targets` reads the per-package `.txt` file at build time
2. It extracts `nowarn:` lines into the `_ProjectAllowedNoWarn` MSBuild property
3. `eng/NoWarnValidation.targets` uses `_ProjectAllowedNoWarn` to validate that
   the project's `<NoWarn>` codes are all approved

## Adding a New Entry

If your project needs to suppress a diagnostic via `<NoWarn>`:

1. Create or edit `eng/analyzerallowlist/<YourProjectName>.txt`
2. Add a `nowarn:CODE` line for the diagnostic you need to suppress
3. Include a comment explaining why the suppression is needed
4. The PR adding the entry will be reviewed by the SDK team

**Preferred alternative:** Instead of adding a `<NoWarn>` entry, use a scoped
`#pragma warning disable CODE` with a justification comment, or
`[SuppressMessage]` with a `Justification` parameter. These are more visible
in code review and have narrower scope.

## Related

- `eng/NoWarnValidation.targets` — The validation target that enforces NoWarn policy
- `eng/AnalyzerAllowList.targets` — MSBuild logic that reads these files
- [Issue #55312](https://github.com/Azure/azure-sdk-for-net/issues/55312) — NoWarn visibility
- [Issue #57586](https://github.com/Azure/azure-sdk-for-net/issues/57586) — Suppression validation

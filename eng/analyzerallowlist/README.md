# Analyzer Allow-List Files

This directory contains per-package allow-list files that govern which analyzer suppressions are approved for each shipping client library.

## File Format

Each file is named `<PackageName>.txt` (matching `$(MSBuildProjectName)`) and contains two types of entries:

```
# Comments start with #

# nowarn: entries — codes allowed in <NoWarn> in the .csproj (consumed by MSBuild)
nowarn:CS1591
nowarn:AZC0035

# CODE:SYMBOL entries — approved inline suppressions (consumed by the Roslyn analyzer)
AZC0002:M:Azure.Storage.Blobs.AppendBlobClient.AppendBlock
AZC0015:T:Azure.Storage.Blobs.Specialized.SpecializedBlobClientOptions
```

### Entry Types

| Format | Consumer | Purpose |
|--------|----------|---------|
| `nowarn:CODE` | MSBuild (`AnalyzerAllowList.targets`) | Approves CODE in `<NoWarn>` |
| `CODE:SYMBOL` | Roslyn analyzer (`SuppressionPolicyAnalyzer`) | Approves inline suppression of CODE on SYMBOL |

Each consumer ignores the other's lines — MSBuild skips `CODE:SYMBOL` lines, the analyzer skips `nowarn:` lines.

### Symbol Format

Symbols use the standard [C# documentation comment ID format](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#d42-id-string-format):

| Prefix | Meaning | Example |
|--------|---------|---------|
| `T:` | Type | `T:Azure.Storage.Blobs.Specialized.SpecializedBlobClientOptions` |
| `M:` | Method | `M:Azure.Storage.Blobs.AppendBlobClient.AppendBlock` |
| `P:` | Property | `P:Azure.Storage.Blobs.Models.BlobProperties.ContentType` |
| `F:` | Field | `F:Azure.Storage.Blobs.BlobContainerClient.LogsBlobContainerName` |
| `N:` | Namespace | `N:Azure.Storage.Blobs.Models` (for file-level suppressions) |

Method symbols omit parameter lists by default — `M:AppendBlobClient.AppendBlock` approves all overloads.

## How It Works

- **No file** for a package → no enforcement (the analyzer does nothing)
- **File with only `nowarn:` entries** → only NoWarn enforcement (Phase 1)
- **File with `CODE:SYMBOL` entries** → inline suppression enforcement via the Roslyn analyzer
- A diagnostic code is only enforced if it appears in at least one `CODE:SYMBOL` entry

## Adding or Modifying Entries

To approve a new suppression:

1. Add a `CODE:SYMBOL` entry to the package's `.txt` file (or create the file if it doesn't exist)
2. Include a comment explaining why the suppression is needed
3. Submit a PR — the allow-list change serves as the audit trail

## Migration Lifecycle

Files evolve as suppressions are cleaned up:

1. **Phase 1**: `nowarn:` entries only (MSBuild enforcement)
2. **Phase 2**: Mixed `nowarn:` and `CODE:SYMBOL` entries
3. **Phase 3**: `nowarn:` entries removed as they migrate to inline `#pragma` suppressions
4. **Steady state**: Only `CODE:SYMBOL` entries remain (or file is deleted if clean)

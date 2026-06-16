#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Post-emit step that lowers the visibility of types in src/Generated to internal.

.DESCRIPTION
  The TypeSpec C# emitter produces public types under src/Generated. Because the
  customer-facing surface for the Key Vault Secrets package is the hand-written
  SecretClient (and related models), every generated type must be hidden from the
  public API surface. This mirrors how Java uses `models-subpackage:
  implementation.models`, Python uses the `_generated` namespace, and Go keeps
  its low-level client unexported. Without this step the package would ship a
  second, public KeyVaultClient that competes with SecretClient.

  The script is idempotent and is invoked from a pre-Compile MSBuild target in
  Azure.Security.KeyVault.Secrets.csproj so re-running `tsp-client update`
  cannot accidentally re-expose generated symbols.
#>
[CmdletBinding()]
param(
    [string] $GeneratedRoot = (Join-Path $PSScriptRoot '..\src\Generated')
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path $GeneratedRoot)) {
    Write-Host "Internalize-Generated: '$GeneratedRoot' not found; skipping (nothing to do)."
    return
}

# Map of top-level (file-scoped) declarations to lower from public -> internal.
# Limited to the well-known declaration shapes the C# emitter produces. We
# intentionally do not run a blanket regex against every `public` token so
# generated *members* (e.g. public properties on the now-internal classes) keep
# their normal visibility, which is required for the hand-written wrapper code
# in the same assembly to consume them.
$patterns = @(
    # classes
    @{ Find = '^\s*public\s+partial\s+class\s+';        Replace = 'internal partial class ' },
    @{ Find = '^\s*public\s+static\s+partial\s+class\s+'; Replace = 'internal static partial class ' },
    @{ Find = '^\s*public\s+abstract\s+partial\s+class\s+'; Replace = 'internal abstract partial class ' },
    @{ Find = '^\s*public\s+sealed\s+partial\s+class\s+'; Replace = 'internal sealed partial class ' },
    # enums (top-level)
    @{ Find = '^\s*public\s+enum\s+';                    Replace = 'internal enum ' },
    # structs
    @{ Find = '^\s*public\s+partial\s+struct\s+';        Replace = 'internal partial struct ' },
    @{ Find = '^\s*public\s+readonly\s+partial\s+struct\s+'; Replace = 'internal readonly partial struct ' }
)

$files   = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter '*.cs' -File
$changed = 0
$visited = 0

foreach ($file in $files) {
    $visited++
    $original = [System.IO.File]::ReadAllText($file.FullName)
    $text     = $original

    foreach ($p in $patterns) {
        $text = [regex]::Replace($text, $p.Find, $p.Replace, 'Multiline')
    }

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $text)
        $changed++
        Write-Host "  internalized: $($file.FullName.Substring($GeneratedRoot.Length).TrimStart('\','/'))"
    }
}

Write-Host "Internalize-Generated: scanned $visited file(s), updated $changed."

# --------------------------------------------------------------------------
# Known emitter-bug workarounds.
# These are surgical, idempotent patches against specific lines in the
# generated client. Keep each patch narrowly scoped (search for an exact
# fragment) so it is a no-op once the upstream emitter is fixed.
# --------------------------------------------------------------------------

$kvClient = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter 'KeyVaultSecretsClient.cs' -File `
    | Where-Object { $_.FullName -notlike '*RestClient*' } `
    | Select-Object -First 1

if ($kvClient) {
    $text     = [System.IO.File]::ReadAllText($kvClient.FullName)
    $original = $text

    # Emitter swaps the positional argument order at the UpdateSecret call sites
    # vs. its own CreateUpdateSecretRequest(string, string, RequestContent, ...)
    # declaration. Reorder back to match the request builder.
    $text = $text -replace 'CreateUpdateSecretRequest\(secretName,\s*content,\s*secretVersion,\s*context\)',
                            'CreateUpdateSecretRequest(secretName, secretVersion, content, context)'

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($kvClient.FullName, $text)
        Write-Host '  patched: KeyVaultSecretsClient.cs (UpdateSecret arg order)'
    }
}

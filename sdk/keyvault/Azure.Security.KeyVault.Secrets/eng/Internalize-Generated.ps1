#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Post-emit patch for src/Generated.

.DESCRIPTION
  Type visibility (public -> internal) is now handled at the spec level via
  `@@access(KeyVault, Access.internal, "csharp")` in
  specification/keyvault/data-plane/Secrets/client.tsp (Azure/azure-rest-api-specs).

  This script applies a single residual workaround the emitter cannot yet
  express in the spec: a positional argument-order swap in the emitted
  UpdateSecret call sites. The bug is reported fixed in newer emitter
  builds; once the repo-wide emitter pin in
  eng/azure-typespec-http-client-csharp-emitter-package.json moves past
  alpha.20260613.3, this script can be deleted entirely.
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

$kvClient = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter 'KeyVaultSecretsClient.cs' -File `
    | Where-Object { $_.FullName -notlike '*RestClient*' } `
    | Select-Object -First 1

if ($kvClient) {
    $text     = [System.IO.File]::ReadAllText($kvClient.FullName)
    $original = $text

    # Emitter swaps the positional argument order at the UpdateSecret call sites
    # vs. its own CreateUpdateSecretRequest(string, string, RequestContent, ...)
    # declaration. Reorder back to match the request builder.
    #
    # SAFETY NET: the regex is intentionally narrow (matches the exact emitted
    # call shape). If the emitter renames a positional parameter or reflows the
    # call, this regex will silently no-op and the arg-order bug could resurface.
    # The UpdateSecret recorded playback test (SecretClientLiveTests.UpdateSecret
    # / UpdateEnabled / UpdateTags) is the actual safety net: a regression would
    # fail those tests because the wrong arg order produces a malformed PATCH URL.
    $text = $text -replace 'CreateUpdateSecretRequest\(secretName,\s*content,\s*secretVersion,\s*context\)',
                            'CreateUpdateSecretRequest(secretName, secretVersion, content, context)'

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($kvClient.FullName, $text)
        Write-Host '  patched: KeyVaultSecretsClient.cs (UpdateSecret arg order)'
    }
}

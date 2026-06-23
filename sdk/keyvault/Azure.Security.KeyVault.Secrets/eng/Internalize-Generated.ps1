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
  UpdateSecret call sites. The fix will be deleted as soon as the upstream
  @azure-typespec/http-client-csharp emitter ships the upstream fix.
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
        # Verify the replacement landed correctly before persisting.
        if ($text -notmatch 'CreateUpdateSecretRequest\(secretName,\s*secretVersion,\s*content,\s*context\)') {
            Write-Error "FATAL: UpdateSecret arg-order patch produced unexpected output in $($kvClient.FullName). " +
                        "The regex replacement ran but the expected fixed pattern is absent. " +
                        "Inspect the file manually before continuing."
            exit 1
        }
        [System.IO.File]::WriteAllText($kvClient.FullName, $text)
        Write-Host '  patched: KeyVaultSecretsClient.cs (UpdateSecret arg order)'
    }
    elseif ($text -notmatch 'CreateUpdateSecretRequest\(secretName,\s*secretVersion,\s*content,\s*context\)') {
        # Neither the bug pattern nor the fixed pattern was found — the emitter may have
        # changed the call shape in a way the regex does not recognize. Fail loudly so
        # the arg-order bug cannot silently ship.
        Write-Error "FATAL: Neither the bugged nor the fixed UpdateSecret call-site pattern was found in " +
                    "$($kvClient.FullName). The emitter may have changed the generated call shape. " +
                    "Verify UpdateSecret argument order manually and update this script."
        exit 1
    }
}

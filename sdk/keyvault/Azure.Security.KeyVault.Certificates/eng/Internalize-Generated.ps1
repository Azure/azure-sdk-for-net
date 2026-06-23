#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Post-emit patches for src/Generated.

.DESCRIPTION
  Type visibility (public -> internal) is now handled at the spec level via
  `@@access(KeyVault, Access.internal, "csharp")` in
  specification/keyvault/data-plane/Certificates/client.tsp (Azure/azure-rest-api-specs).

  This script applies the residual emitter-bug workarounds that cannot yet
  be expressed in the spec. Each is narrowly scoped and idempotent. They
  exist because the recorded HTTP cassettes the playback suite depends on
  were captured against the legacy hand-written KeyVaultPipeline, and the
  generated request shapes diverge in five specific places:

    1. UpdateCertificate (4-arg) call-site argument order.
    2. Trailing-slash bug for /certificates/{name}/{version} when version is null.
    3. /certificates/contacts URL missing trailing slash.
    4. /certificates/issuers (LIST) URL missing trailing slash.
    5. PurgeDeletedCertificate missing the Accept header.

  Each patch will be deleted as soon as the upstream
  @azure-typespec/http-client-csharp emitter is fixed.
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

# --- Patch 1: UpdateCertificate arg-order in protocol-method call sites -----

$kvClient = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter 'KeyVaultCertificatesClient.cs' -File `
    | Where-Object { $_.FullName -notlike '*RestClient*' } `
    | Select-Object -First 1

if ($kvClient) {
    $text     = [System.IO.File]::ReadAllText($kvClient.FullName)
    $original = $text

    # SAFETY NET: if the emitter renames a positional parameter or reflows the
    # call, this regex silently no-ops. The recorded
    # CertificateClientLiveTests.UpdateCertificate* / UpdateCertificateTags
    # playback tests are the actual guard - a regression produces a malformed
    # PATCH URL that fails those tests.
    $text = $text -replace 'CreateUpdateCertificateRequest\(certificateName,\s*content,\s*certificateVersion,\s*context\)',
                            'CreateUpdateCertificateRequest(certificateName, certificateVersion, content, context)'

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($kvClient.FullName, $text)
        Write-Host '  patched: KeyVaultCertificatesClient.cs (UpdateCertificate arg order)'
    }
}

# --- Patches 2-5: wire-shape fixups in the rest-client --------------------

$restClient = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter 'KeyVaultCertificatesClient.RestClient.cs' -File `
    | Select-Object -First 1

if ($restClient) {
    $text     = [System.IO.File]::ReadAllText($restClient.FullName)
    $original = $text

    # Patch 2: trailing-slash bug. The emitter unconditionally appends "/" after
    # the certificate name and only THEN gates the version segment behind a
    # null check, so with certificateVersion == null the wire path becomes
    # "/certificates/{name}/" instead of the legacy "/certificates/{name}".
    # Move the "/" inside the null check. Affects CreateGetCertificateRequest
    # and CreateUpdateCertificateRequest.
    $pattern = [regex] @"
(?ms)            uri\.AppendPath\(certificateName, true\);\r?\n            uri\.AppendPath\("/", false\);\r?\n            if \(certificateVersion != null\)\r?\n            \{\r?\n                uri\.AppendPath\(certificateVersion, true\);\r?\n            \}
"@
    $replacement = @"
            uri.AppendPath(certificateName, true);`r`n            if (certificateVersion != null)`r`n            {`r`n                uri.AppendPath("/", false);`r`n                uri.AppendPath(certificateVersion, true);`r`n            }
"@
    $text = $pattern.Replace($text, $replacement)
    # Buggy shape contains the line `uri.AppendPath("/", false);` BEFORE the
    # `if (certificateVersion != null)` block. If we still see that pair, the
    # patch failed to apply on freshly emitted code (it is silent on already-
    # patched re-runs).
    if ([regex]::IsMatch($text, '(?ms)uri\.AppendPath\(certificateName, true\);\r?\n            uri\.AppendPath\("/", false\);\r?\n            if \(certificateVersion != null\)')) {
        Write-Warning "Patch 2 (trailing-slash for null certificateVersion) failed to apply - emitter output shape changed. Verify CreateGetCertificateRequest / CreateUpdateCertificateRequest."
    }

    # Patch 3: contacts collection URL is missing the trailing slash. Recordings
    # ship with /certificates/contacts/. Only matches the bare collection form.
    $text = $text -replace '("\/certificates\/contacts)(", false\))', '$1/$2'
    # Buggy shape (no trailing slash) should be absent after patch.
    if ([regex]::IsMatch($text, '"\/certificates\/contacts", false\)')) {
        Write-Warning "Patch 3 (contacts trailing slash) failed to apply - verify /certificates/contacts URL shape."
    }

    # Patch 4: issuers LIST URL ("/certificates/issuers") is the only bare-collection
    # path that needs the trailing slash; the per-issuer routes already include it.
    $text = $text -replace 'AppendPath\("\/certificates\/issuers", false\)', 'AppendPath("/certificates/issuers/", false)'
    if ([regex]::IsMatch($text, 'AppendPath\("\/certificates\/issuers", false\)')) {
        Write-Warning "Patch 4 (issuers LIST trailing slash) failed to apply - verify /certificates/issuers URL shape."
    }

    # Patch 5: PurgeDeletedCertificate is the only DELETE in the generated
    # client that doesn't set Accept (because it returns 204 No Content -- the
    # only handler using PipelineMessageClassifier204). Recordings expect the
    # header. Anchor on the unique 204 classifier so we touch only this method.
    $purgeBlock     = "            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier204);`n            Request request = message.Request;`n            request.Uri = uri;`n            request.Method = RequestMethod.Delete;`n            return message;"
    $purgeBlockFix  = "            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier204);`n            Request request = message.Request;`n            request.Uri = uri;`n            request.Method = RequestMethod.Delete;`n            request.Headers.SetValue(`"Accept`", `"application/json`");`n            return message;"
    $text = $text.Replace($purgeBlock, $purgeBlockFix)
    if ($text.Contains($purgeBlock)) {
        Write-Warning "Patch 5 (PurgeDeletedCertificate Accept header) failed to apply - verify the 204-classifier block shape or line endings."
    }

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($restClient.FullName, $text)
        Write-Host '  patched: KeyVaultCertificatesClient.RestClient.cs (wire-shape fixups)'
    }
}

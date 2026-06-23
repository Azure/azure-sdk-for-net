#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Post-emit patches for src/Generated.

.DESCRIPTION
  Type visibility (public -> internal) is now handled at the spec level via
  `@@access(KeyVault, Access.internal, "csharp")` in
  specification/keyvault/data-plane/Certificates/client.tsp (Azure/azure-rest-api-specs).

  This script applies the residual emitter-bug workarounds that cannot yet
  be expressed in the spec. Each is narrowly scoped, idempotent, and tracked
  against the upstream emitter:

    Patch 1: UpdateCertificate (4-arg) call-site arg order.
             Tracking: Azure/azure-sdk-for-net#60160.

    Patches 2-5: wire-shape bugs (trailing slash on
                 /certificates/{name}/{version} when version is null;
                 /certificates/contacts and /certificates/issuers LIST URLs
                 missing trailing slash; PurgeDeletedCertificate missing
                 Accept header).
                 Tracking: Azure/azure-sdk-for-net#60162.

    Patch 6: remove the nullable op_Implicit(string) -> CertificatePolicyAction?
             that silently swallows null instead of throwing.
             Tracking: Azure/azure-sdk-for-net#60163.

  Once the upstream emitter fixes ship and we bump the library-local emitter
  pin, the corresponding patches (and eventually this whole script) can be
  deleted.
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
    # Uses a regex (with \r?\n) so the patch matches both LF and CRLF emitter
    # output, unlike literal-string Replace which is exact-match.
    $purgePattern = [regex] @"
(?ms)(HttpMessage message = Pipeline\.CreateMessage\(context, PipelineMessageClassifier204\);\r?\n            Request request = message\.Request;\r?\n            request\.Uri = uri;\r?\n            request\.Method = RequestMethod\.Delete;\r?\n)(            return message;)
"@
    $text = $purgePattern.Replace($text, '$1            request.Headers.SetValue("Accept", "application/json");' + "`r`n" + '$2')
    # If the post-patch text still contains the unpatched shape (Delete followed
    # directly by return, with no Accept header in between), the patch missed.
    if ([regex]::IsMatch($text, '(?ms)PipelineMessageClassifier204\);\r?\n            Request request = message\.Request;\r?\n            request\.Uri = uri;\r?\n            request\.Method = RequestMethod\.Delete;\r?\n            return message;')) {
        Write-Warning "Patch 5 (PurgeDeletedCertificate Accept header) failed to apply - verify the 204-classifier block shape."
    }

    # Patch 6: the generated `op_Implicit(string) -> CertificatePolicyAction?`
    # silently turns a null string into a null CertificatePolicyAction?. The
    # legacy non-nullable operator on the handwritten partial throws
    # ArgumentNullException, and customer code that assigns string-typed
    # nullable values relied on that throw. Remove the generated nullable
    # overload (and its preceding doc-comment block) so the handwritten throw
    # stays the only contract.
    $caPath = Join-Path $GeneratedRoot 'Models\CertificatePolicyAction.cs'
    if (Test-Path $caPath) {
        $caText     = [System.IO.File]::ReadAllText($caPath)
        $caOriginal = $caText
        $nullableOpPattern = [regex] @"
(?ms)\r?\n        /// <summary> Converts a string to a <see cref="CertificatePolicyAction"/>\. </summary>\r?\n        /// <param name="value"> The value\. </param>\r?\n        public static implicit operator CertificatePolicyAction\?\(string value\) => value == null \? null : new CertificatePolicyAction\(value\);\r?\n
"@
        $caText = $nullableOpPattern.Replace($caText, "`r`n")
        if ($caText -ne $caOriginal) {
            [System.IO.File]::WriteAllText($caPath, $caText)
            Write-Host '  patched: Models/CertificatePolicyAction.cs (remove nullable op_Implicit)'
        }
        elseif ($caText.Contains('public static implicit operator CertificatePolicyAction?(string value)')) {
            Write-Warning "Patch 6 (remove nullable CertificatePolicyAction operator) failed to apply - operator still present."
        }
    }

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($restClient.FullName, $text)
        Write-Host '  patched: KeyVaultCertificatesClient.RestClient.cs (wire-shape fixups)'
    }
}

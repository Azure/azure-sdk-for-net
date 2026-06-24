#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Post-emit step that lowers the visibility of types in src/Generated to internal.

.DESCRIPTION
  The TypeSpec C# emitter produces public types under src/Generated. Because the
  customer-facing surface for the Key Vault Certificates package is the hand-written
  CertificateClient (and related models), every generated type must be hidden from the
  public API surface. This mirrors how Java uses `models-subpackage:
  implementation.models`, Python uses the `_generated` namespace, and Go keeps
  its low-level client unexported. Without this step the package would ship a
  second, public KeyVaultCertificatesClient that competes with CertificateClient.

  The script is idempotent and is invoked from a pre-Compile MSBuild target in
  Azure.Security.KeyVault.Certificates.csproj so re-running `tsp-client update`
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

# Multi-TFM builds (net8.0 + net10.0 + netstandard2.0) run this target in
# parallel, one process per TFM. They all mutate the same files under
# $GeneratedRoot, which can race on Windows file locks. A named system Mutex
# serializes the work: the first process runs the rewrite, the others wait,
# observe the result is already idempotent, and exit cleanly.
$mutex = New-Object System.Threading.Mutex($false, 'Global\AzureSdkInternalizeGenerated.Certificates')
[void] $mutex.WaitOne()
try {

# Map of top-level (file-scoped) declarations to lower from public -> internal.
# Limited to the well-known declaration shapes the C# emitter produces. We
# intentionally do not run a blanket regex against every `public` token so
# generated *members* (e.g. public properties on the now-internal classes) keep
# their normal visibility, which is required for the hand-written wrapper code
# in the same assembly to consume them.
$patterns = @(
    # classes - capture the leading indent so we don't strip it
    @{ Find = '(?m)^(\s*)public(\s+partial\s+class\s+)';        Replace = '${1}internal${2}' },
    @{ Find = '(?m)^(\s*)public(\s+static\s+partial\s+class\s+)'; Replace = '${1}internal${2}' },
    @{ Find = '(?m)^(\s*)public(\s+abstract\s+partial\s+class\s+)'; Replace = '${1}internal${2}' },
    @{ Find = '(?m)^(\s*)public(\s+sealed\s+partial\s+class\s+)'; Replace = '${1}internal${2}' },
    # enums (top-level)
    @{ Find = '(?m)^(\s*)public(\s+enum\s+)';                    Replace = '${1}internal${2}' },
    # structs
    @{ Find = '(?m)^(\s*)public(\s+partial\s+struct\s+)';        Replace = '${1}internal${2}' },
    @{ Find = '(?m)^(\s*)public(\s+readonly\s+partial\s+struct\s+)'; Replace = '${1}internal${2}' }
)

# Files we intentionally keep `public partial` so they can merge with the
# hand-written public partials of the same type. The hand-written copies own
# the customer-facing surface; the generated copies add MRW serialization
# (IJsonModel<T> / IPersistableModel<T>) which is additive and matches how
# every other Azure SDK model type behaves.
$mergeFileNames = @(
    'PlatformManaged.cs',
    'PlatformManaged.Serialization.cs',
    'CertificatePolicyAction.cs'
)

$files   = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter '*.cs' -File
$changed = 0
$visited = 0

foreach ($file in $files) {
    $visited++
    if ($mergeFileNames -contains $file.Name) { continue }
    $original = [System.IO.File]::ReadAllText($file.FullName)
    $text     = $original

    foreach ($p in $patterns) {
        $text = [regex]::Replace($text, $p.Find, $p.Replace)
    }

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $text)
        $changed++
        Write-Host "  internalized: $($file.FullName.Substring($GeneratedRoot.Length).TrimStart('\','/'))"
    }
}

Write-Host "Internalize-Generated: scanned $visited file(s), updated $changed."

# --------------------------------------------------------------------------
# No type renames are needed. Two generated wire models (PlatformManaged,
# CertificatePolicyAction) share their names with hand-written public types
# in src/. We resolve the collision by keeping both as `public partial` and
# letting the C# compiler merge them: the hand-written partial owns the
# customer-facing members and the generated partial adds the MRW JSON
# round-trip + the nullable string implicit cast. See $mergeFileNames above.
# --------------------------------------------------------------------------

# --------------------------------------------------------------------------
# Known emitter-bug workarounds.
# These are surgical, idempotent patches against specific lines in the
# generated client. Keep each patch narrowly scoped (search for an exact
# fragment) so it is a no-op once the upstream emitter is fixed.
# --------------------------------------------------------------------------

$restClient = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter 'KeyVaultCertificatesClient.RestClient.cs' -File `
    | Select-Object -First 1

if ($restClient) {
    $text     = [System.IO.File]::ReadAllText($restClient.FullName)
    $original = $text

    # Trailing-slash bug: the emitter unconditionally appends "/" after the
    # certificate name and only THEN gates the version segment behind a null
    # check. With certificateVersion == null the wire path becomes
    # "/certificates/{name}/" (trailing slash) instead of the legacy
    # "/certificates/{name}". Recorded HTTP traffic across years of 4.x
    # shipped against the latter, so the recordings every customer playback
    # depends on need the legacy shape. Move the "/" inside the null check so
    # the request URL is byte-identical to the legacy KeyVaultPipeline path.
    # Applies to CreateGetCertificateRequest and CreateUpdateCertificateRequest.
    $pattern = [regex] @"
(?ms)            uri\.AppendPath\(certificateName, true\);\r?\n            uri\.AppendPath\("/", false\);\r?\n            if \(certificateVersion != null\)\r?\n            \{\r?\n                uri\.AppendPath\(certificateVersion, true\);\r?\n            \}
"@
    $replacement = @"
            uri.AppendPath(certificateName, true);`r`n            if (certificateVersion != null)`r`n            {`r`n                uri.AppendPath("/", false);`r`n                uri.AppendPath(certificateVersion, true);`r`n            }
"@
    $text = $pattern.Replace($text, $replacement)

    # Two more legacy-shape URLs the emitter forgot the trailing slash on:
    # the contacts collection (Get/Set/Delete) and the issuers list endpoint.
    # Recordings ship with the trailing slash, so add it back. We only target
    # the standalone collection URLs - the per-issuer routes (which use
    # "/certificates/issuers/" + issuerName) already have the slash.
    $text = $text -replace '("\/certificates\/contacts)(", false\))', '$1/$2'
    # The issuers LIST request is the only one that uses bare "/certificates/issuers";
    # every per-issuer route uses "/certificates/issuers/" + name so the trailing
    # slash is already there. Match the exact bare-collection form.
    $text = $text -replace 'AppendPath\("\/certificates\/issuers", false\)', 'AppendPath("/certificates/issuers/", false)'

    # PurgeDeletedCertificate is the only DELETE in the generated client that
    # doesn't set the Accept header (because the endpoint returns 204 No
    # Content -- it's the only handler using PipelineMessageClassifier204).
    # Every other generated DELETE does, and -- more importantly -- the
    # legacy KeyVaultPipeline did, so recordings expect it. Anchor on the
    # unique 204 classifier so we only touch this one method.
    $purgeBlock     = "            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier204);`n            Request request = message.Request;`n            request.Uri = uri;`n            request.Method = RequestMethod.Delete;`n            return message;"
    $purgeBlockFix  = "            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier204);`n            Request request = message.Request;`n            request.Uri = uri;`n            request.Method = RequestMethod.Delete;`n            request.Headers.SetValue(`"Accept`", `"application/json`");`n            return message;"
    $text = $text.Replace($purgeBlock, $purgeBlockFix)

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($restClient.FullName, $text)
        Write-Host '  patched: KeyVaultCertificatesClient.RestClient.cs (drop trailing slash for null version)'
    }
}

$kvClient = Get-ChildItem -Path $GeneratedRoot -Recurse -Filter 'KeyVaultCertificatesClient.cs' -File `
    | Where-Object { $_.FullName -notlike '*RestClient*' } `
    | Select-Object -First 1

if ($kvClient) {
    $text     = [System.IO.File]::ReadAllText($kvClient.FullName)
    $original = $text

    # Emitter swaps the positional argument order at the UpdateCertificate call sites
    # vs. its own CreateUpdateCertificateRequest(string, string, RequestContent, ...)
    # declaration. Reorder back to match the request builder.
    $text = $text -replace 'CreateUpdateCertificateRequest\(certificateName,\s*content,\s*certificateVersion,\s*context\)',
                            'CreateUpdateCertificateRequest(certificateName, certificateVersion, content, context)'

    # Open up state we need to assign from the customization partial class.
    # CertificateClient builds the HttpPipeline from the customer's CertificateClientOptions
    # (so AddPolicy, custom Retry, Diagnostics allow-lists, Transport, etc. are
    # all honored) and then plugs that pipeline + the matching endpoint /
    # apiVersion / diagnostics into the generated client. Without these tiny
    # visibility loosenings, the customization ctor would be unable to set the
    # auto-properties / readonly fields owned by the generated partial.
    $text = $text -replace 'public\s+virtual\s+HttpPipeline\s+Pipeline\s*\{\s*get;\s*\}',           'public virtual HttpPipeline Pipeline { get; internal set; }'
    $text = $text -replace 'internal\s+ClientDiagnostics\s+ClientDiagnostics\s*\{\s*get;\s*\}',     'internal ClientDiagnostics ClientDiagnostics { get; set; }'
    $text = $text -replace 'private\s+readonly\s+Uri\s+_endpoint;',                                  'internal Uri _endpoint;'
    $text = $text -replace 'private\s+readonly\s+string\s+_apiVersion;',                             'internal string _apiVersion;'

    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($kvClient.FullName, $text)
        Write-Host '  patched: KeyVaultCertificatesClient.cs (UpdateCertificate arg order + customization hooks)'
    }
}

}
finally { [void] $mutex.ReleaseMutex(); $mutex.Dispose() }


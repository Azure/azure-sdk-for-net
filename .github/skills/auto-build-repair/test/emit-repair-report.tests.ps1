#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Determinism guard for emit-repair-report.ps1 (the auto-build-repair PR summary emitter).

.DESCRIPTION
  Renders the comment for every terminal state and asserts the guarantees the
  audit/metrics design depends on:

    1. Every terminal state emits a comment containing exactly one telemetry object.
    2. The telemetry object validates against telemetry-schema.v1.json.
    3. The object is "sanitizer-invariant by construction": it contains only
       characters that gh-aw's add_comment sanitizer never rewrites (no @mention,
       no bare URL, no `#<ref>`, no template delimiters, no XML comment). This is
       what lets CloudMine parse it byte-for-byte out of the issues/comments stream.
    4. The collapsible <details>/<summary> structure is present (allow-listed GFM
       tags the sanitizer preserves).
    5. No stripped <!-- --> HTML comment is relied upon for identity.

  Pure static checks — no network and no gh-aw install required, so it runs anywhere
  (locally and in CI). The live byte-for-byte round-trip through the real sanitizer
  was validated separately against github/gh-aw's sanitize_content.cjs.

.NOTES
  Exit code 0 = all assertions passed; 1 = one or more failed.
#>
[CmdletBinding()]
param(
    [string]$EmitterPath = (Join-Path $PSScriptRoot '..' 'emit-repair-report.ps1'),
    [string]$SchemaPath  = (Join-Path $PSScriptRoot '..' 'telemetry-schema.v1.json')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$EmitterPath = (Resolve-Path $EmitterPath).Path
$SchemaPath  = (Resolve-Path $SchemaPath).Path
$schema      = Get-Content -Raw $SchemaPath

$failures = [System.Collections.Generic.List[string]]::new()
function Assert([bool]$cond, [string]$msg) {
    if ($cond) { Write-Host "  [PASS] $msg" } else { Write-Host "  [FAIL] $msg" -ForegroundColor Red; $script:failures.Add($msg) }
}

function Get-TelemetryObject([string]$body) {
    $m = [regex]::Match($body, '(?s)```json\s*\n(.*?)\n```')
    if ($m.Success) { return $m.Groups[1].Value } else { return $null }
}

# Characters/patterns the gh-aw sanitizer rewrites. The object must contain NONE of them.
function Test-SanitizerSafe([string]$obj) {
    $violations = @()
    if ($obj -match '(^|[^\w`])@[A-Za-z0-9]')        { $violations += '@mention' }
    if ($obj -match '(?i)[a-z][a-z0-9+.-]*://')        { $violations += 'url-scheme' }
    if ($obj -match '(^|[^\w`])#\w')                   { $violations += 'issue-ref (#n)' }
    if ($obj -match '\{\{|\$\{|<%=|\{#|\{%')           { $violations += 'template-delimiter' }
    if ($obj -match '<!--')                            { $violations += 'xml-comment' }
    return , $violations
}

$tmp = Join-Path ([System.IO.Path]::GetTempPath()) ("emit-tests-" + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $tmp | Out-Null

try {
    # ---- build fixtures for each terminal state --------------------------------
    $repairedDir = Join-Path $tmp 'repaired'; New-Item -ItemType Directory -Path $repairedDir | Out-Null
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = 'sdk/foo/Azure.Foo/src/Custom.cs'; description = 'fix'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $repairedDir 'result-1.json')

    $failedDir = Join-Path $tmp 'failed'; New-Item -ItemType Directory -Path $failedDir | Out-Null
    $nl = [char]10
    [ordered]@{ success = $false; buildResult = "Custom.cs(1,1): error CS0117: bad$nl@evil https://x.test fixes #9"; errorCode = 'maxIterations'; specChangeRequired = @('AZC0012: rename') } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $failedDir 'result-1.json')

    $cases = @(
        @{ name = 'repaired';              args = @('-ResultsDir', $repairedDir, '-PackagePath', 'sdk/foo/Azure.Foo', '-PreRepairSha', '') ; expect = 'repaired' }
        @{ name = 'failed';                args = @('-ResultsDir', $failedDir,   '-PackagePath', 'sdk/foo/Azure.Foo') ; expect = 'failed' }
        @{ name = 'ineligible';            args = @('-Eligible:$false') ; expect = 'ineligible' }
        @{ name = 'skipped_already_green'; args = @('-ForcedStatus', 'skipped_already_green', '-PackagePath', 'sdk/foo/Azure.Foo') ; expect = 'skipped_already_green' }
    )

    foreach ($c in $cases) {
        Write-Host "State: $($c.name)"
        $out = Join-Path $tmp "$($c.name).md"
        $argList = @('-NoProfile', '-File', $EmitterPath) + $c.args + @('-Pr', '123', '-HeadSha', 'abc1234', '-Repo', 'Azure/azure-sdk-for-net', '-OutFile', $out)
        & pwsh @argList | Out-Null
        Assert (Test-Path $out) "renders a comment file"
        $body = Get-Content -Raw $out

        $obj = Get-TelemetryObject $body
        Assert ($null -ne $obj) "contains exactly one telemetry json block"
        Assert ((([regex]::Matches($body, '```json')).Count) -eq 1) "exactly one ```json fence"

        if ($obj) {
            $valid = $false
            try { $valid = Test-Json -Json $obj -Schema $schema -ErrorAction Stop } catch { $valid = $false }
            Assert $valid "telemetry object validates against telemetry-schema.v1.json"

            $parsed = $obj | ConvertFrom-Json
            Assert ($parsed.status -eq $c.expect) "status == '$($c.expect)'"
            Assert ($parsed.schema_version -eq 'v1') "schema_version == v1"
            if ($c.expect -eq 'repaired') { Assert ($null -ne $parsed.repaired_at) "repaired_at set when repaired" }
            else { Assert ($null -eq $parsed.repaired_at) "repaired_at null when not repaired" }

            $v = Test-SanitizerSafe $obj
            Assert ($v.Count -eq 0) ("object is sanitizer-safe" + $(if ($v.Count) { " (violations: $($v -join ', '))" } else { '' }))
        }

        Assert ($body -notmatch '<!--') "no <!-- --> HTML comment (sanitizer strips it)"
        if ($c.expect -ne 'ineligible') {
            Assert ($body -match '<details><summary>Telemetry \(machine-readable\)</summary>') "telemetry <details> present"
        }
        Assert ($body -match '### SDK build repair') "visible heading present (identity)"
    }
}
finally {
    Remove-Item $tmp -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host ''
if ($failures.Count -gt 0) {
    Write-Host "FAILED: $($failures.Count) assertion(s)." -ForegroundColor Red
    exit 1
}
Write-Host 'All determinism assertions passed.' -ForegroundColor Green
exit 0

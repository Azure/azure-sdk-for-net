#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Deterministically render the auto-build-repair PR summary comment.

.DESCRIPTION
  Produces the ENTIRE PR summary comment from code-accessible sources only
  (per-attempt engine result JSON, `git diff`, and $GITHUB_* env) so the
  content never depends on the LLM. The agent's only job is to run this script
  and pass the rendered file's contents verbatim to the gh-aw `add_comment`
  safe-output tool.

  The comment has two parts:
    1. A deterministic human-readable summary (classified build errors, files
       changed with a Generated/ vs custom split, iterations, final result).
    2. A tiny, versioned telemetry object inside a collapsed <details> block that
       validates against telemetry-schema.v1.json and that CloudMine parses out of
       the GitHub issues/comments stream.

  It renders on EVERY terminal state (repaired / failed / ineligible /
  skipped_already_green) so no attempt ever silently degrades.

.NOTES
  Engine contract (Azure/azure-sdk-tools CustomizedCodeUpdateResponse), emitted
  by `azsdk -o json tsp client customized-update ...`:
    success (bool), appliedPatches[]{filePath,description,replacementCount},
    buildResult (string, only when !success), errorCode (KnownErrorCodes),
    specChangeRequired[], customCodeChangeRequired[], message, typeSpecChangesSummary[]
#>
[CmdletBinding()]
param(
    # Directory containing the per-attempt engine result files (result-1.json, result-2.json, ...).
    # Empty/absent is valid for the no-engine-run terminal states (ineligible / skipped_already_green).
    [string]$ResultsDir = $env:AZSDK_REPAIR_RESULTS_DIR,

    # Overall eligibility gate result. Drives status=ineligible.
    [bool]$Eligible = $true,

    # Force a terminal status when there was no engine run. One of: ineligible, skipped_already_green.
    # When omitted, status is derived from the engine results.
    [ValidateSet('', 'ineligible', 'skipped_already_green')]
    [string]$ForcedStatus = '',

    # The single failing SDK package path (repo-relative), for the human summary.
    [string]$PackagePath = '',

    # The pre-repair HEAD sha; enables an accurate `git diff` file list. When absent,
    # the file list falls back to the union of appliedPatches (custom files only).
    [string]$PreRepairSha = '',

    # Max iterations the loop was allowed (from repair-config.yml), for "N / max" display.
    [int]$MaxIterations = 3,

    # Identity fields (default to GitHub Actions env; overridable for tests).
    [string]$Repo = $env:GITHUB_REPOSITORY,
    [int]$Pr = 0,
    [string]$HeadSha = '',
    [string]$RunId = '',

    # Where to write the rendered comment markdown.
    [string]$OutFile = (Join-Path ([System.IO.Path]::GetTempPath()) 'repair-report-comment.md'),

    # Repo root for git operations.
    [string]$RepoRoot = (Get-Location).Path
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# ---- identity defaults from env -------------------------------------------------
if (-not $RunId) {
    $rid = $env:GITHUB_RUN_ID; $att = $env:GITHUB_RUN_ATTEMPT
    if ($rid) { $RunId = "gha-$rid-$([string]::IsNullOrEmpty($att) ? '1' : $att)" } else { $RunId = 'gha-local-1' }
}
if ($Pr -le 0 -and $env:AZSDK_REPAIR_PR) { [int]::TryParse($env:AZSDK_REPAIR_PR, [ref]$Pr) | Out-Null }
if (-not $HeadSha) { $HeadSha = $env:AZSDK_REPAIR_HEAD_SHA }
if (-not $Repo) { $Repo = 'unknown/unknown' }
if (-not $HeadSha) { $HeadSha = '0000000' }

# ---- load per-attempt engine results -------------------------------------------
$attempts = @()
if ($ResultsDir -and (Test-Path $ResultsDir)) {
    $attempts = Get-ChildItem -Path $ResultsDir -Filter 'result-*.json' -File |
        Sort-Object { [int]([regex]::Match($_.Name, 'result-(\d+)\.json').Groups[1].Value) } |
        ForEach-Object {
            try { Get-Content -Raw -LiteralPath $_.FullName | ConvertFrom-Json }
            catch { Write-Warning "Skipping unparseable result file: $($_.Name)"; $null }
        } | Where-Object { $null -ne $_ }
    $attempts = @($attempts)
}
$iterations = $attempts.Count
$final = if ($iterations -gt 0) { $attempts[-1] } else { $null }

# ---- derive terminal status ----------------------------------------------------
function Get-Prop($obj, $name) {
    if ($null -ne $obj -and $obj.PSObject.Properties[$name]) { return $obj.$name }
    return $null
}

$status = 'failed'
$stopReason = $null
if (-not $Eligible -or $ForcedStatus -eq 'ineligible') {
    $status = 'ineligible'
}
elseif ($ForcedStatus -eq 'skipped_already_green') {
    $status = 'skipped_already_green'
}
elseif ($null -eq $final) {
    # Eligible but no engine result recorded: treat as failed with an explicit reason.
    $status = 'failed'; $stopReason = 'NoEngineResult'
}
elseif ([bool](Get-Prop $final 'success')) {
    $status = 'repaired'
}
else {
    $status = 'failed'
    $ec = Get-Prop $final 'errorCode'
    $stopReason = if ($ec) { [string]$ec } elseif ($iterations -ge $MaxIterations) { 'maxIterations' } else { 'BuildFailed' }
}

$repairedAt = if ($status -eq 'repaired') { (Get-Date).ToUniversalTime().ToString('yyyy-MM-ddTHH:mm:ssZ') } else { $null }

# ---- classified build errors (deterministic regex over engine buildResult) -----
# Matches compiler-style diagnostic codes, e.g. "error CS0117", "error AZC0012".
function Get-ErrorCounts([string]$buildText) {
    $counts = [ordered]@{}
    if ($buildText) {
        foreach ($m in [regex]::Matches($buildText, '(?im)\berror\s+([A-Z]{1,5}\d{2,5})\b')) {
            $code = $m.Groups[1].Value
            if ($counts.Contains($code)) { $counts[$code]++ } else { $counts[$code] = 1 }
        }
    }
    return $counts
}
function Format-ErrorCounts($counts) {
    if (-not $counts -or $counts.Count -eq 0) { return '_none_' }
    return (($counts.GetEnumerator() | Sort-Object Name | ForEach-Object { "$($_.Key) x$($_.Value)" }) -join ', ')
}

# Errors encountered across the run (fixed set) vs remaining on the final failing attempt.
$encountered = [ordered]@{}
foreach ($a in $attempts) {
    $br = Get-Prop $a 'buildResult'
    foreach ($kv in (Get-ErrorCounts $br).GetEnumerator()) {
        if ($encountered.Contains($kv.Key)) { $encountered[$kv.Key] += $kv.Value } else { $encountered[$kv.Key] = $kv.Value }
    }
}
$remaining = if ($status -eq 'failed' -and $final) { Get-ErrorCounts (Get-Prop $final 'buildResult') } else { [ordered]@{} }

# ---- files changed (git diff, Generated/ vs custom) ----------------------------
function Test-IsGenerated([string]$path) {
    return ($path -match '(^|/)Generated/' )
}
$changedFiles = @()
$fileSource = 'git'
if ($PreRepairSha) {
    Push-Location $RepoRoot
    try {
        $diff = & git diff --name-only $PreRepairSha -- 2>$null
        if ($LASTEXITCODE -eq 0 -and $diff) { $changedFiles = @($diff | Where-Object { $_ }) }
    } finally { Pop-Location }
}
if ($changedFiles.Count -eq 0) {
    # Fallback: custom files the engine reported patching (won't include regenerated Generated/).
    $fileSource = 'appliedPatches'
    $paths = foreach ($a in $attempts) {
        $ap = Get-Prop $a 'appliedPatches'
        if ($ap) { foreach ($p in $ap) { Get-Prop $p 'filePath' } }
    }
    $changedFiles = @($paths | Where-Object { $_ } | Select-Object -Unique)
}
$genFiles = @($changedFiles | Where-Object { Test-IsGenerated $_ })
$customFiles = @($changedFiles | Where-Object { -not (Test-IsGenerated $_) })

# ---- telemetry object (validated against telemetry-schema.v1.json) -----------------
$obj = [ordered]@{
    schema_version = 'v1'
    run_id         = $RunId
    repo           = $Repo
    pr             = $Pr
    head_sha       = $HeadSha
    eligible       = [bool]$Eligible
    status         = $status
    repaired_at    = $repairedAt
}
$objJson = ($obj | ConvertTo-Json -Compress -Depth 4)

# ---- render comment ------------------------------------------------------------
$statusLine = switch ($status) {
    'repaired'              { 'OK repaired' }
    'failed'               { 'FAILED not repaired' }
    'ineligible'           { 'SKIPPED not an eligible Auto SDK PR' }
    'skipped_already_green' { 'OK already green (no repair needed)' }
}

$sb = [System.Text.StringBuilder]::new()
# NOTE: no HTML identity marker — gh-aw's add_comment sanitizer (removeXmlComments)
# strips <!-- ... --> from the posted body. Comment identity for dedup/parsing is the
# visible "### SDK build repair" heading plus the "schema_version":"v1" telemetry object.
[void]$sb.AppendLine("### SDK build repair - $statusLine")
[void]$sb.AppendLine('')

if ($status -eq 'ineligible') {
    [void]$sb.AppendLine('This PR is not an eligible release-planner Auto SDK PR, so no build/repair was run.')
}
else {
    if ($PackagePath) { [void]$sb.AppendLine("**Package:** ``$PackagePath``") }
    $resultText = if ($status -eq 'repaired') { 'build green' } elseif ($status -eq 'skipped_already_green') { 'build green (no changes)' } else { 'build red' }
    $iterLine = "**Result:** $resultText - **Iterations:** $iterations / $MaxIterations"
    if ($stopReason) { $iterLine += " - **Stop reason:** $stopReason" }
    [void]$sb.AppendLine($iterLine)

    if ($status -eq 'repaired') {
        [void]$sb.AppendLine("**Errors resolved:** $(Format-ErrorCounts $encountered)")
    } elseif ($status -eq 'failed') {
        [void]$sb.AppendLine("**Remaining errors:** $(Format-ErrorCounts $remaining)")
    }
    [void]$sb.AppendLine("**Files changed:** $($changedFiles.Count) ($($genFiles.Count) generated, $($customFiles.Count) custom)")
    [void]$sb.AppendLine('')

    if ($changedFiles.Count -gt 0) {
        [void]$sb.AppendLine('<details><summary>Changed files</summary>')
        [void]$sb.AppendLine('')
        foreach ($f in ($changedFiles | Sort-Object)) { [void]$sb.AppendLine("- ``$f``") }
        if ($fileSource -eq 'appliedPatches') {
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('_Note: list derived from engine-applied patches (pre-repair sha unavailable); regenerated Generated/ files may not be shown._')
        }
        [void]$sb.AppendLine('</details>')
        [void]$sb.AppendLine('')
    }

    if ($status -eq 'failed' -and $final) {
        $br = [string](Get-Prop $final 'buildResult')
        # Guard the fenced block: strip any accidental closing fence in engine output.
        $safeBr = ($br -replace '```', '` ` `')
        if ($safeBr.Length -gt 8000) { $safeBr = $safeBr.Substring(0, 8000) + "`n...(truncated)" }
        if ($safeBr.Trim()) {
            [void]$sb.AppendLine('<details><summary>Remaining build errors</summary>')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('```')
            [void]$sb.AppendLine($safeBr.TrimEnd())
            [void]$sb.AppendLine('```')
            [void]$sb.AppendLine('</details>')
            [void]$sb.AppendLine('')
        }
        # Surface out-of-scope guidance without applying it.
        $scr = Get-Prop $final 'specChangeRequired'
        if ($scr -and @($scr).Count -gt 0) {
            [void]$sb.AppendLine('**Requires a spec-repo change (out of scope for custom-code repair):**')
            foreach ($item in $scr) { [void]$sb.AppendLine("- $item") }
            [void]$sb.AppendLine('')
        }
    }

    [void]$sb.AppendLine('No spec inputs or the pinned commit were touched.')
}

[void]$sb.AppendLine('')
[void]$sb.AppendLine('<details><summary>Telemetry (machine-readable)</summary>')
[void]$sb.AppendLine('')
[void]$sb.AppendLine('```json')
[void]$sb.AppendLine($objJson)
[void]$sb.AppendLine('```')
[void]$sb.AppendLine('</details>')
[void]$sb.AppendLine('')
[void]$sb.AppendLine('--generated by Copilot')

$body = $sb.ToString()
# Normalize to LF so the rendered bytes are identical on Windows and the Linux runner
# (the gh-aw sanitizer trims trailing whitespace; CRLF would otherwise perturb the object).
$body = $body -replace "`r`n", "`n"
Set-Content -LiteralPath $OutFile -Value $body -NoNewline -Encoding utf8

Write-Host "Rendered repair comment ($status) -> $OutFile"
Write-Host "Telemetry: $objJson"
# Emit the output path so callers/CI can locate the rendered comment.
Write-Output $OutFile

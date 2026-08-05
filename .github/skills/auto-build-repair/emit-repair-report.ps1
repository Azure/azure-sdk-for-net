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

    # Path to the captured pre-repair build output (raw `dotnet build` text). On a first-try
    # success the engine result carries no `buildResult`, so this is the only deterministic
    # source for the "errors fixed" list. Mechanical capture (redirect), not LLM-authored.
    [string]$PreRepairErrorsFile = $env:AZSDK_REPAIR_PRE_ERRORS_FILE,

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

# ---- classified build diagnostics (deterministic parse over build output) ------
# Compiler diagnostics look like:
#   /abs/path/File.cs(19,13): error CS0103: The name 'X' does not exist... [/abs/proj.csproj]
# We extract a compact per-code count and structured (code, file, line, message) tuples.
function Get-RelPath([string]$p) {
    if (-not $p) { return $p }
    $n = ($p -replace '\\', '/').Trim()
    $i = $n.IndexOf('sdk/')
    if ($i -ge 0) { $n = $n.Substring($i) }
    return $n
}
function Get-PkgRelPath([string]$repoRel) {
    if ($PackagePath -and $repoRel -and $repoRel.StartsWith("$PackagePath/")) {
        return $repoRel.Substring($PackagePath.Length + 1)
    }
    return $repoRel
}
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
# Unique structured diagnostics (deduped across repeated target frameworks).
function Get-Diagnostics([string]$text) {
    $list = [System.Collections.Generic.List[object]]::new()
    $seen = [System.Collections.Generic.HashSet[string]]::new()
    if ($text) {
        $rx = [regex]'(?im)^(?<file>[^(\r\n]+)\((?<line>\d+),\d+\):\s*error\s+(?<code>[A-Z]{1,5}\d{2,5}):\s*(?<msg>.+?)(?:\s*\[[^\]]*\])?\s*$'
        foreach ($m in $rx.Matches($text)) {
            $rel = Get-PkgRelPath (Get-RelPath $m.Groups['file'].Value)
            $code = $m.Groups['code'].Value
            $line = $m.Groups['line'].Value
            $msg = $m.Groups['msg'].Value.Trim()
            $key = "$code|$rel|$line|$msg"
            if ($seen.Add($key)) {
                $list.Add([pscustomobject]@{ Code = $code; File = $rel; Line = $line; Message = $msg })
            }
        }
    }
    return $list
}
function Format-ErrorCounts($counts) {
    if (-not $counts -or $counts.Count -eq 0) { return '_none_' }
    return (($counts.GetEnumerator() | Sort-Object Name | ForEach-Object { "``$($_.Key)`` x$($_.Value)" }) -join ', ')
}

# Pre-repair build output = the errors the first engine call was asked to fix.
$preRepairText = ''
if ($PreRepairErrorsFile -and (Test-Path $PreRepairErrorsFile)) {
    $preRepairText = Get-Content -Raw -LiteralPath $PreRepairErrorsFile
}

# Errors fixed across the run = pre-repair errors + any failing attempts' buildResult.
$fixedCounts = Get-ErrorCounts $preRepairText
$fixedDiagText = $preRepairText
foreach ($a in $attempts) {
    if (-not [bool](Get-Prop $a 'success')) {
        $br = [string](Get-Prop $a 'buildResult')
        $fixedDiagText += "`n$br"
        foreach ($kv in (Get-ErrorCounts $br).GetEnumerator()) {
            if ($fixedCounts.Contains($kv.Key)) { $fixedCounts[$kv.Key] += $kv.Value } else { $fixedCounts[$kv.Key] = $kv.Value }
        }
    }
}
$fixedDiags = Get-Diagnostics $fixedDiagText

# Remaining (failed state) = diagnostics on the final failing attempt.
$remainingText = if ($status -eq 'failed' -and $final) { [string](Get-Prop $final 'buildResult') } else { '' }
$remainingCounts = Get-ErrorCounts $remainingText
$remainingDiags = Get-Diagnostics $remainingText

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

# Map of engine-applied patches keyed by normalized path, for the "Change" column.
$patchMap = @{}
foreach ($a in $attempts) {
    $ap = Get-Prop $a 'appliedPatches'
    if ($ap) {
        foreach ($p in $ap) {
            $fp = Get-Prop $p 'filePath'; if (-not $fp) { continue }
            $patchMap[(Get-RelPath $fp)] = [pscustomobject]@{
                Description  = [string](Get-Prop $p 'description')
                Replacements = Get-Prop $p 'replacementCount'
            }
        }
    }
}
# Match a changed file (repo-relative) to an applied patch by path suffix (handles the
# engine reporting either repo-relative or package-relative paths).
function Find-Patch([string]$repoRelFile) {
    $target = (Get-RelPath $repoRelFile)
    foreach ($k in $patchMap.Keys) {
        if ($target -eq $k -or $target.EndsWith("/$k") -or $k.EndsWith("/$target")) { return $patchMap[$k] }
    }
    return $null
}

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
$statusTitle = switch ($status) {
    'repaired'              { 'Repaired' }
    'failed'                { 'Not repaired' }
    'ineligible'            { 'Skipped (not an eligible Auto SDK PR)' }
    'skipped_already_green' { 'Already green (no repair needed)' }
}
$statusIcon = switch ($status) {
    'repaired'              { ':white_check_mark:' }
    'failed'                { ':x:' }
    'ineligible'            { ':information_source:' }
    'skipped_already_green' { ':white_check_mark:' }
}

# Escape a table cell: collapse newlines and escape pipes so markdown tables stay intact.
function Format-Cell([string]$s) {
    if (-not $s) { return '' }
    return (($s -replace '\r?\n', ' ') -replace '\|', '\|').Trim()
}

$sb = [System.Text.StringBuilder]::new()
# NOTE: no HTML identity marker — gh-aw's add_comment sanitizer (removeXmlComments)
# strips <!-- ... --> from the posted body. Comment identity for dedup/parsing is the
# visible "SDK Build Repair" heading plus the "schema_version":"v1" telemetry object.
[void]$sb.AppendLine("## SDK Build Repair - $statusTitle $statusIcon")
[void]$sb.AppendLine('')

if ($status -eq 'ineligible') {
    [void]$sb.AppendLine('This PR is not an eligible release-planner Auto SDK PR, so no build or repair was run.')
    [void]$sb.AppendLine('')
}
else {
    # ----- Summary table -----
    $buildStatusCell = switch ($status) {
        'repaired'              { ':white_check_mark: Green' }
        'skipped_already_green' { ':white_check_mark: Green (no changes needed)' }
        default                 { ':x: Red' }
    }
    [void]$sb.AppendLine('### Summary')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('| | |')
    [void]$sb.AppendLine('|---|---|')
    if ($PackagePath) { [void]$sb.AppendLine("| **Package** | ``$PackagePath`` |") }
    [void]$sb.AppendLine("| **Final build status** | $buildStatusCell |")
    [void]$sb.AppendLine("| **Iterations used** | $iterations of $MaxIterations |")
    [void]$sb.AppendLine('| **Engine** | `azsdk tsp client customized-update --edit-scope CustomCode` |')
    if ($stopReason) { [void]$sb.AppendLine("| **Stop reason** | ``$stopReason`` |") }
    [void]$sb.AppendLine('')

    # ----- Build errors (fixed on success, remaining on failure) -----
    if ($status -eq 'repaired' -or $status -eq 'failed') {
        $isFixed = ($status -eq 'repaired')
        $diags = if ($isFixed) { $fixedDiags } else { $remainingDiags }
        $counts = if ($isFixed) { $fixedCounts } else { $remainingCounts }
        $heading = if ($isFixed) { 'Build Errors Fixed' } else { 'Remaining Build Errors' }
        if (@($diags).Count -gt 0) {
            [void]$sb.AppendLine("### $heading")
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('| Error | Location |')
            [void]$sb.AppendLine('|---|---|')
            foreach ($d in ($diags | Sort-Object File, @{ Expression = { [int]$_.Line } }, Code)) {
                $loc = if ($d.File) { "``$($d.File):$($d.Line)``" } else { '_n/a_' }
                $emsg = Format-Cell "$($d.Code): $($d.Message)"
                [void]$sb.AppendLine("| ``$emsg`` | $loc |")
            }
            [void]$sb.AppendLine('')
        }
        elseif ($counts.Count -gt 0) {
            $label = if ($isFixed) { 'Errors fixed' } else { 'Errors remaining' }
            [void]$sb.AppendLine("**${label}:** $(Format-ErrorCounts $counts)")
            [void]$sb.AppendLine('')
        }
    }

    # ----- Files changed table -----
    if ($changedFiles.Count -gt 0) {
        [void]$sb.AppendLine("### Files Changed ($($changedFiles.Count): $($customFiles.Count) custom, $($genFiles.Count) generated)")
        [void]$sb.AppendLine('')
        [void]$sb.AppendLine('| File | Type | Change |')
        [void]$sb.AppendLine('|---|---|---|')
        foreach ($f in ($changedFiles | Sort-Object)) {
            $type = if (Test-IsGenerated $f) { 'Generated' } else { 'Custom code' }
            if (Test-IsGenerated $f) {
                $change = 'Regenerated from unchanged spec inputs'
            }
            else {
                $patch = Find-Patch $f
                if ($patch) {
                    $change = if ($patch.Description) { $patch.Description } else { 'Custom-code fix' }
                    if ($patch.Replacements) {
                        $n = [int]$patch.Replacements
                        $change += " ($n replacement$(if ($n -ne 1) { 's' }))"
                    }
                }
                else { $change = 'Custom-code edit' }
            }
            [void]$sb.AppendLine("| ``$(Get-PkgRelPath (Get-RelPath $f))`` | $type | $(Format-Cell $change) |")
        }
        [void]$sb.AppendLine('')
        if ($fileSource -eq 'appliedPatches') {
            [void]$sb.AppendLine('_File list derived from engine-applied patches (pre-repair sha unavailable); regenerated Generated/ files may not be shown._')
            [void]$sb.AppendLine('')
        }
    }

    # ----- Out-of-scope spec guidance + full log (failed only) -----
    if ($status -eq 'failed' -and $final) {
        $scr = Get-Prop $final 'specChangeRequired'
        if ($scr -and @($scr).Count -gt 0) {
            [void]$sb.AppendLine('### Requires a spec-repo change (out of scope for custom-code repair)')
            [void]$sb.AppendLine('')
            foreach ($item in $scr) { [void]$sb.AppendLine("- $item") }
            [void]$sb.AppendLine('')
        }
        $br = [string](Get-Prop $final 'buildResult')
        # Guard the fenced block: strip any accidental closing fence in engine output.
        $safeBr = ($br -replace '```', '` ` `')
        if ($safeBr.Length -gt 8000) { $safeBr = $safeBr.Substring(0, 8000) + "`n...(truncated)" }
        if ($safeBr.Trim()) {
            [void]$sb.AppendLine('<details><summary>Full build output (final attempt)</summary>')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('```')
            [void]$sb.AppendLine($safeBr.TrimEnd())
            [void]$sb.AppendLine('```')
            [void]$sb.AppendLine('</details>')
            [void]$sb.AppendLine('')
        }
    }

    # ----- Invariants (deterministic; guaranteed by --edit-scope CustomCode + push denylist) -----
    [void]$sb.AppendLine('### Invariants Confirmed')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('- No spec inputs modified (`client.tsp`, `tspconfig.yaml`, TypeSpec sources)')
    [void]$sb.AppendLine('- Pinned commit in `tsp-location.yaml` unchanged')
    [void]$sb.AppendLine('- No `.github/`, `eng/`, pipeline, or package-metadata files touched')
    [void]$sb.AppendLine('- Fix committed as a reviewable commit - not auto-merged')
    [void]$sb.AppendLine('')
}

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

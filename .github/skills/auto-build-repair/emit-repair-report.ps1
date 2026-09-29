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

    # Fallback pre-repair sha, used only when a successful repair is already committed at emit
    # time (so the working tree is clean vs HEAD). The primary file list comes from the
    # uncommitted working-tree diff against HEAD. When absent, the file list falls back to the
    # union of appliedPatches (custom files only).
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
# Only files whose name is exactly result-<n>.json are attempts; a stray file like
# result-final.json is ignored (and, defensively, the sort key never [int]-parses a
# non-numeric group, so an unexpected name can never throw and suppress the comment).
$attempts = @()
$finalFile = $null
if ($ResultsDir -and (Test-Path $ResultsDir)) {
    $attemptFiles = Get-ChildItem -Path $ResultsDir -Filter 'result-*.json' -File |
        Where-Object { $_.Name -match '^result-\d+\.json$' } |
        Sort-Object {
            $m = [regex]::Match($_.Name, '^result-(\d+)\.json$')
            if ($m.Success) { [int]$m.Groups[1].Value } else { [int]::MaxValue }
        }
    foreach ($f in $attemptFiles) {
        try { $parsed = Get-Content -Raw -LiteralPath $f.FullName | ConvertFrom-Json }
        catch { Write-Warning "Skipping unparseable result file: $($f.Name)"; continue }
        $attempts += $parsed
        $finalFile = $f   # last successfully-parsed attempt file (matches $attempts[-1])
    }
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

# repaired_at anchors the time-to-green / subsequent-correction metrics, so it must be
# stable across re-runs of the emitter. Use the write time of the successful engine result
# file (when the green result was recorded) rather than render-time Get-Date, which would
# drift on every re-emit. Fall back to now only if the file is somehow unavailable.
$repairedAt = $null
if ($status -eq 'repaired') {
    $repairedAt = if ($finalFile) { $finalFile.LastWriteTimeUtc.ToString('yyyy-MM-ddTHH:mm:ssZ') }
                  else { (Get-Date).ToUniversalTime().ToString('yyyy-MM-ddTHH:mm:ssZ') }
}

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
# Scope every diff to the failing package. The repair only edits custom code and regenerates
# Generated/ *within* $PackagePath, so scoping enforces the "nothing outside the failing
# package" invariant and keeps unrelated base-branch files out of the list. For a
# pull_request event the working tree is the PR *merge ref* (head + base), so an unscoped
# diff against the pre-repair PR-head sha would also list every file the base branch changed
# since the branch diverged (e.g. .github/, .mcp.json).
$pathArgs = if ($PackagePath) { @('--', $PackagePath) } else { @('--') }
Push-Location $RepoRoot
try {
    # Primary: uncommitted working-tree edits. At emit time the repair's custom-code edits and
    # regenerated Generated/ are still uncommitted. A later safe-output job commits them only
    # for a green repair; failed-run edits remain ephemeral. Diffing the working tree against
    # the checked-out HEAD yields exactly the repair's footprint, independent of $PreRepairSha.
    $wt = @()
    $diff = & git diff --name-only HEAD @pathArgs 2>$null
    if ($LASTEXITCODE -eq 0 -and $diff) { $wt = @($diff | Where-Object { $_ }) }
    # `git diff` never lists untracked (newly created) files, so a brand-new custom or
    # regenerated file would be missing from the audit list until it is `git add`-ed. Union in
    # the untracked set (same package scope) so the full repair footprint is always reported.
    $untracked = & git ls-files --others --exclude-standard @pathArgs 2>$null
    if ($LASTEXITCODE -eq 0 -and $untracked) { $wt += @($untracked | Where-Object { $_ }) }
    if ($wt.Count -gt 0) { $changedFiles = @($wt | Select-Object -Unique) }

    # Fallback: if the repair was already committed (working tree clean vs HEAD), diff the
    # pre-repair sha instead. Still scoped to $PackagePath so merge-ref base changes stay out.
    if ($changedFiles.Count -eq 0 -and $PreRepairSha) {
        $diff = & git diff --name-only $PreRepairSha @pathArgs 2>$null
        if ($LASTEXITCODE -eq 0 -and $diff) { $changedFiles = @($diff | Where-Object { $_ }) }
    }
} finally { Pop-Location }
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

# Per-iteration applied patches: attribute each custom-code edit to the engine call
# (result-<n>.json) that made it, so the Files Changed section can group by iteration.
# A file edited in more than one iteration appears under each iteration that touched it.
$iterationPatches = [System.Collections.Generic.List[object]]::new()
for ($i = 0; $i -lt $attempts.Count; $i++) {
    $ap = Get-Prop $attempts[$i] 'appliedPatches'
    $rows = [System.Collections.Generic.List[object]]::new()
    if ($ap) {
        foreach ($p in $ap) {
            $fp = Get-Prop $p 'filePath'; if (-not $fp) { continue }
            $rows.Add([pscustomobject]@{
                File         = (Get-RelPath $fp)
                Description  = [string](Get-Prop $p 'description')
                Replacements = Get-Prop $p 'replacementCount'
            })
        }
    }
    $iterationPatches.Add([pscustomobject]@{ Iteration = $i + 1; Rows = $rows })
}
# Set of custom files the engine reported patching (normalized), used to detect any
# diff-only custom changes not attributable to a specific attempt.
$patchedCustom = [System.Collections.Generic.HashSet[string]]::new()
foreach ($grp in $iterationPatches) { foreach ($r in $grp.Rows) { [void]$patchedCustom.Add($r.File) } }
# True when a changed file (repo-relative) matches an applied-patch path by suffix (the
# engine may report either repo-relative or package-relative paths).
function Test-PathCovered([string]$repoRelFile, $set) {
    $target = (Get-RelPath $repoRelFile)
    foreach ($k in $set) {
        if ($target -eq $k -or $target.EndsWith("/$k") -or $k.EndsWith("/$target")) { return $true }
    }
    return $false
}

# ---- telemetry object (validated against telemetry-schema.v1.json) -----------------
# eligible must never contradict status: status=ineligible is, by definition, the
# eligibility gate having failed, so force eligible=false there. This keeps the two
# consistent no matter which path set the status (the -Eligible:$false gate OR an
# explicit -ForcedStatus ineligible), protecting the downstream metric denominators.
$eligibleOut = if ($status -eq 'ineligible') { $false } else { [bool]$Eligible }
$obj = [ordered]@{
    schema_version = 'v1'
    run_id         = $RunId
    repo           = $Repo
    pr             = $Pr
    head_sha       = $HeadSha
    eligible       = $eligibleOut
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

    # ----- Files changed (grouped by iteration) -----
    # Custom-code edits are attributed to the exact engine iteration that made them (from
    # each result-<n>.json's appliedPatches). Regenerated Generated/ files are a cumulative
    # downstream effect and are not attributable to a single iteration, so they are listed
    # once. On success, all groups are part of one repair commit; on failure, none are committed.
    if ($changedFiles.Count -gt 0) {
        [void]$sb.AppendLine("### Files Changed ($($changedFiles.Count) distinct: $($customFiles.Count) custom, $($genFiles.Count) generated)")
        [void]$sb.AppendLine('')

        $anyIterRows = @($iterationPatches | Where-Object { $_.Rows.Count -gt 0 }).Count -gt 0
        if ($anyIterRows) {
            foreach ($grp in $iterationPatches) {
                if ($grp.Rows.Count -eq 0) { continue }
                [void]$sb.AppendLine("#### Iteration $($grp.Iteration)")
                [void]$sb.AppendLine('')
                [void]$sb.AppendLine('| File | Type | Change |')
                [void]$sb.AppendLine('|---|---|---|')
                foreach ($r in ($grp.Rows | Sort-Object File)) {
                    $change = if ($r.Description) { $r.Description } else { 'Custom-code edit' }
                    if ($r.Replacements) {
                        $n = [int]$r.Replacements
                        $change += " ($n replacement$(if ($n -ne 1) { 's' }))"
                    }
                    [void]$sb.AppendLine("| ``$(Get-PkgRelPath $r.File)`` | Custom code | $(Format-Cell $change) |")
                }
                [void]$sb.AppendLine('')
            }
        }

        # Custom files present in the diff but not reported by any attempt's appliedPatches.
        $otherCustom = @($customFiles | Where-Object { -not (Test-PathCovered $_ $patchedCustom) })
        if ($otherCustom.Count -gt 0) {
            [void]$sb.AppendLine('#### Other custom changes')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('| File | Type | Change |')
            [void]$sb.AppendLine('|---|---|---|')
            foreach ($f in ($otherCustom | Sort-Object)) {
                [void]$sb.AppendLine("| ``$(Get-PkgRelPath (Get-RelPath $f))`` | Custom code | Custom-code edit |")
            }
            [void]$sb.AppendLine('')
        }

        # Regenerated Generated/ files (cumulative; not attributable to a single iteration).
        if ($genFiles.Count -gt 0) {
            [void]$sb.AppendLine('#### Regenerated (cumulative)')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('| File | Type | Change |')
            [void]$sb.AppendLine('|---|---|---|')
            foreach ($f in ($genFiles | Sort-Object)) {
                [void]$sb.AppendLine("| ``$(Get-PkgRelPath (Get-RelPath $f))`` | Generated | Regenerated from unchanged spec inputs |")
            }
            [void]$sb.AppendLine('')
        }

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
    # Only a successful repair is eligible for the push safe output. Every failure leaves any
    # attempted changes uncommitted in the ephemeral agent workspace.
    $commitLine = switch ($status) {
        'repaired'              { '- Fix committed as a reviewable commit - not auto-merged' }
        'failed'                { '- Build remains red - repair changes were not committed' }
        'skipped_already_green' { '- No changes needed - nothing committed' }
        default                 { '- No fix applied - nothing committed' }
    }
    [void]$sb.AppendLine($commitLine)
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

#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Deterministically render the auto-build-repair PR summary comment.

.DESCRIPTION
  Produces the ENTIRE PR summary comment from code-accessible sources only
  (the final engine result JSON, `git diff`, and $GITHUB_* env) so the
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
    success (bool), attemptsUsed (int), appliedPatches[]{filePath,description,replacementCount},
    buildResult (string, only when !success), errorCode (KnownErrorCodes),
    operation_status, response_error, next_steps[], specChangeRequired[],
    customCodeChangeRequired[], message, typeSpecChangesSummary[].
  attemptsUsed counts completed proposals reaching host validation, including no-progress;
  it excludes baseline/classifier builds, Exit reminders, and individual tool calls.
  Missing/invalid counts remain unknown, never inferred from files or patch counts.
#>
[CmdletBinding()]
param(
    # Directory containing the single final engine response, result.json.
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

    # Maximum engine patch attempts (from repair-config.yml), for "N / max" display.
    [int]$MaxIterations = 3,

    # Path to the captured pre-repair build output (raw `dotnet build` text). On a first-try
    # success the engine result carries no `buildResult`, so this is the only deterministic
    # source for the "errors fixed" list. Mechanical capture (redirect), not LLM-authored.
    [string]$PreRepairErrorsFile = $env:AZSDK_REPAIR_PRE_ERRORS_FILE,

    # Captured CLI stderr/capability errors, including failures without a JSON response.
    [string]$EngineErrorsFile = '',

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

function Get-Prop($obj, $name) {
    if ($null -ne $obj -and $obj.PSObject.Properties[$name]) { return ,$obj.$name }
    return $null
}

# Never recover an older successful response when the final response is missing or bad.
$final = $null
$finalFile = $null
$resultIssue = 'NoEngineResult'
$iterations = $null
if ($ResultsDir -and (Test-Path -LiteralPath (Join-Path $ResultsDir 'result.json') -PathType Leaf)) {
    $finalFile = Get-Item -LiteralPath (Join-Path $ResultsDir 'result.json')
    try {
        $final = Get-Content -Raw -LiteralPath $finalFile.FullName | ConvertFrom-Json -NoEnumerate
        # The [pscustomobject] accelerator also matches wrapped JSON arrays.
        if ($null -eq $final -or $final.GetType() -ne [System.Management.Automation.PSCustomObject]) {
            throw 'Expected a single JSON object.'
        }
        $resultIssue = $null
    }
    catch { $final = $null; $resultIssue = 'MalformedEngineResult' }
}
if ($final) {
    $count = Get-Prop $final 'attemptsUsed'
    if (($count -is [int] -or $count -is [long]) -and $count -ge 0 -and $count -le $MaxIterations) {
        $iterations = $count
    }
    else { $resultIssue = 'InvalidAttemptsUsed' }
    if ((Get-Prop $final 'success') -isnot [bool]) { $resultIssue = 'InvalidEngineSuccess' }
}

# ---- derive terminal status ----------------------------------------------------
$status = 'failed'
$stopReason = $null
if (-not $Eligible -or $ForcedStatus -eq 'ineligible') {
    $status = 'ineligible'; $iterations = 0
}
elseif ($ForcedStatus -eq 'skipped_already_green' -and $null -eq $finalFile) {
    $status = 'skipped_already_green'; $iterations = 0
}
elseif ($resultIssue) {
    $stopReason = $resultIssue
}
elseif ((Get-Prop $final 'success') -eq $true -and
        -not (Get-Prop $final 'response_error') -and
        ((Get-Prop $final 'operation_status') -in @($null, 'Succeeded'))) {
    $status = 'repaired'
}
else {
    $ec = Get-Prop $final 'errorCode'
    $stopReason = if ($ec) { [string]$ec } elseif ($iterations -ge $MaxIterations) { 'maxIterations' } else { 'EngineFailed' }
}

# repaired_at anchors the time-to-green / subsequent-correction metrics, so it must be
# stable across re-runs of the emitter. Use the write time of the successful engine result
# file (when the green result was recorded) rather than render-time Get-Date, which would
# drift on every re-emit.
$repairedAt = $null
if ($status -eq 'repaired') {
    $repairedAt = $finalFile.LastWriteTimeUtc.ToString('yyyy-MM-ddTHH:mm:ssZ')
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

# The single final response does not expose diagnostics for individual attempts.
$fixedCounts = Get-ErrorCounts $preRepairText
$fixedDiags = Get-Diagnostics $preRepairText

# Remaining (failed state) = diagnostics on the final failing attempt.
$remainingText = if ($status -eq 'failed' -and $final) { [string](Get-Prop $final 'buildResult') } else { '' }
$remainingCounts = Get-ErrorCounts $remainingText
$remainingDiags = Get-Diagnostics $remainingText
$engineErrors = ''
if ($status -eq 'failed' -and $EngineErrorsFile -and (Test-Path -LiteralPath $EngineErrorsFile -PathType Leaf)) {
    $engineErrors = Get-Content -Raw -LiteralPath $EngineErrorsFile
}

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
    $paths = foreach ($p in (Get-Prop $final 'appliedPatches')) { Get-Prop $p 'filePath' }
    $changedFiles = @($paths | Where-Object { $_ } | Select-Object -Unique)
}
$genFiles = @($changedFiles | Where-Object { Test-IsGenerated $_ })
$customFiles = @($changedFiles | Where-Object { -not (Test-IsGenerated $_) })

# The legacy response reports cumulative patches, not per-attempt attribution.
$patchRows = [System.Collections.Generic.List[object]]::new()
foreach ($p in (Get-Prop $final 'appliedPatches')) {
    $fp = Get-Prop $p 'filePath'; if (-not $fp) { continue }
    $patchRows.Add([pscustomobject]@{
        File         = (Get-RelPath $fp)
        Description  = [string](Get-Prop $p 'description')
        Replacements = Get-Prop $p 'replacementCount'
    })
}
# Set of custom files the engine reported patching (normalized), used to detect
# diff-only custom changes absent from the cumulative response.
$patchedCustom = [System.Collections.Generic.HashSet[string]]::new()
foreach ($r in $patchRows) { [void]$patchedCustom.Add($r.File) }
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
    return (($s -replace '\r?\n', ' ') -replace '\|', '\|' -replace '`', '&#96;' -replace '<', '&lt;' -replace '>', '&gt;').Trim()
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
        default                 { ':x: Not confirmed green (see failure details)' }
    }
    [void]$sb.AppendLine('### Summary')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('| | |')
    [void]$sb.AppendLine('|---|---|')
    if ($PackagePath) { [void]$sb.AppendLine("| **Package** | ``$(Format-Cell $PackagePath)`` |") }
    [void]$sb.AppendLine("| **Final build status** | $buildStatusCell |")
    $iterationText = if ($null -ne $iterations) { "$iterations of $MaxIterations" } else { "Unknown of $MaxIterations (no valid attemptsUsed)" }
    [void]$sb.AppendLine("| **Iterations used** | $iterationText |")
    [void]$sb.AppendLine('| **Engine** | `azsdk tsp client customized-update --edit-scope CustomCode` |')
    if ($stopReason) { [void]$sb.AppendLine("| **Stop reason** | ``$(Format-Cell $stopReason)`` |") }
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('_Iterations count completed patch proposals reaching host validation, including no-progress proposals; baseline/classifier checks and tool calls are excluded._')
    if ($RunId -match '^gha-(\d+)-\d+$') {
        $server = if ($env:GITHUB_SERVER_URL) { $env:GITHUB_SERVER_URL.TrimEnd('/') } else { 'https://github.com' }
        [void]$sb.AppendLine("[Workflow logs]($server/$Repo/actions/runs/$($Matches[1]))")
    }
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
                $loc = if ($d.File) { "``$(Format-Cell "$($d.File):$($d.Line)")``" } else { '_n/a_' }
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

    # ----- Files changed (cumulative final response plus Git attribution) -----
    if ($changedFiles.Count -gt 0) {
        [void]$sb.AppendLine("### Files Changed ($($changedFiles.Count) distinct: $($customFiles.Count) custom, $($genFiles.Count) generated)")
        [void]$sb.AppendLine('')

        if ($patchRows.Count -gt 0) {
            [void]$sb.AppendLine('#### Engine-reported patches (cumulative; attempted on failure)')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('| File | Type | Change |')
            [void]$sb.AppendLine('|---|---|---|')
            foreach ($r in ($patchRows | Sort-Object File)) {
                $change = if ($r.Description) { $r.Description } else { 'Custom-code edit' }
                if ($r.Replacements -is [int] -or $r.Replacements -is [long]) {
                    $n = [int]$r.Replacements
                    $change += " ($n replacement$(if ($n -ne 1) { 's' }))"
                }
                [void]$sb.AppendLine("| ``$(Format-Cell (Get-PkgRelPath $r.File))`` | Custom code | $(Format-Cell $change) |")
            }
            [void]$sb.AppendLine('')
        }

        # Custom files present in the diff but not reported in appliedPatches.
        $otherCustom = @($customFiles | Where-Object { -not (Test-PathCovered $_ $patchedCustom) })
        if ($otherCustom.Count -gt 0) {
            [void]$sb.AppendLine('#### Other custom changes')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('| File | Type | Change |')
            [void]$sb.AppendLine('|---|---|---|')
            foreach ($f in ($otherCustom | Sort-Object)) {
                [void]$sb.AppendLine("| ``$(Format-Cell (Get-PkgRelPath (Get-RelPath $f)))`` | Custom code | Custom-code edit |")
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
                [void]$sb.AppendLine("| ``$(Format-Cell (Get-PkgRelPath (Get-RelPath $f)))`` | Generated | Generated-source change |")
            }
            [void]$sb.AppendLine('')
        }

        if ($fileSource -eq 'appliedPatches') {
            [void]$sb.AppendLine('_File list derived from engine-applied patches (pre-repair sha unavailable); regenerated Generated/ files may not be shown._')
            [void]$sb.AppendLine('')
        }
    }

    # ----- Failure cause, next action, and final diagnostics -----
    if ($status -eq 'failed') {
        [void]$sb.AppendLine('### Why repair stopped')
        [void]$sb.AppendLine('')
        $cause = switch ($resultIssue) {
            'NoEngineResult' { 'The engine did not produce result.json. Check CLI availability, capability checks, and captured process errors.' }
            'MalformedEngineResult' { 'The final result.json is unreadable or is not a single JSON object. No older result was used.' }
            'InvalidEngineSuccess' { 'The final response is missing a Boolean success value. It cannot confirm a green build.' }
            'InvalidAttemptsUsed' { 'The final response has no valid integer attemptsUsed within the configured bound. Check the engine version and response.' }
            default { 'The engine did not report a successful repair. Its final errors and guidance follow.' }
        }
        [void]$sb.AppendLine($cause)
        foreach ($field in @('response_error', 'message')) {
            $value = Get-Prop $final $field
            if ($value) { [void]$sb.AppendLine("- **${field}:** $(Format-Cell ([string]$value))") }
        }
        [void]$sb.AppendLine('')
        $scr = Get-Prop $final 'specChangeRequired'
        if ($scr -and @($scr).Count -gt 0) {
            [void]$sb.AppendLine('### Requires a spec-repo change (out of scope for custom-code repair)')
            [void]$sb.AppendLine('')
            foreach ($item in $scr) { [void]$sb.AppendLine("- $(Format-Cell ([string]$item))") }
            [void]$sb.AppendLine('')
        }
        [void]$sb.AppendLine('### Next action')
        [void]$sb.AppendLine('')
        $steps = Get-Prop $final 'next_steps'
        if ($steps) {
            foreach ($step in $steps) { [void]$sb.AppendLine("- $(Format-Cell ([string]$step))") }
        }
        elseif ($scr) { [void]$sb.AppendLine('Request a separate spec-repository change; do not edit pinned spec inputs in this repair.') }
        else { [void]$sb.AppendLine('Review the final diagnostics, attempted patches, and workflow logs. Resolve the reported cause before starting a new repair run; do not repeat the engine invocation in this run.') }
        [void]$sb.AppendLine('')
        $br = (@($remainingText, [string](Get-Prop $final 'response_error'), $engineErrors) | Where-Object { $_ }) -join "`n"
        # Guard the fenced block: strip any accidental closing fence in engine output.
        $safeBr = ($br -replace '```', '` ` `')
        if ($safeBr.Length -gt 8000) { $safeBr = $safeBr.Substring(0, 8000) + "`n...(truncated)" }
        if ($safeBr.Trim()) {
            [void]$sb.AppendLine('<details><summary>Final build/generation and engine error output</summary>')
            [void]$sb.AppendLine('')
            [void]$sb.AppendLine('```')
            [void]$sb.AppendLine($safeBr.TrimEnd())
            [void]$sb.AppendLine('```')
            [void]$sb.AppendLine('</details>')
            [void]$sb.AppendLine('')
        }
    }

    # The renderer describes the existing guardrails; it does not attest source or publication.
    [void]$sb.AppendLine('### Workflow Guardrails')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('- Spec inputs must remain unchanged (`client.tsp`, `tspconfig.yaml`, TypeSpec sources)')
    [void]$sb.AppendLine('- The pinned commit in `tsp-location.yaml` must remain unchanged')
    [void]$sb.AppendLine('- Changes to `.github/`, `eng/`, pipelines, or package metadata are disallowed')
    # Only a successful repair is eligible for the push safe output. Every failure leaves any
    # attempted changes uncommitted in the ephemeral agent workspace.
    $commitLine = switch ($status) {
        'repaired'              { '- Engine reports a green build; success-only publication is handled by the workflow, not confirmed by this report' }
        'failed'                { '- Repair failed - changes are not eligible for publication' }
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

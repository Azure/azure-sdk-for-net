#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Recover a missing terminal comment in the existing safe-output job.
.DESCRIPTION
  Reads only downloaded, secret-redacted evidence. Never invokes the engine or
  authorizes a push. Original agent output remains in the artifact for validation.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$AgentOutputFile,
    [Parameter(Mandatory)]
    [string]$ResultsDir,
    [Parameter(Mandatory)]
    [int]$Pr,
    [Parameter(Mandatory)]
    [string]$HeadSha,
    [string]$AgentOutcome = 'failure',
    [string]$Repo = $env:GITHUB_REPOSITORY,
    [string]$RepoRoot = $env:GITHUB_WORKSPACE
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$output = Get-Content -Raw -LiteralPath $AgentOutputFile | ConvertFrom-Json -NoEnumerate
if ($null -eq $output -or $output.GetType() -ne [System.Management.Automation.PSCustomObject] -or
    -not $output.PSObject.Properties['items'] -or $output.items -isnot [array] -or
    ($output.PSObject.Properties['errors'] -and $output.errors -isnot [array])) {
    throw 'Invalid agent output envelope; reporting cannot recover it safely.'
}
if (-not $output.PSObject.Properties['errors']) {
    $output | Add-Member -NotePropertyName errors -NotePropertyValue @()
}
$incomplete = @($output.items | Where-Object { $_.type -in @('report_incomplete', 'missing_tool', 'missing_data') })
$complete = $AgentOutcome -eq 'success' -and $output.errors.Count -eq 0 -and
    $incomplete.Count -eq 0 -and @($output.items | Where-Object { $_.type -eq 'add_comment' }).Count -gt 0
$pushRequested = @($output.items | Where-Object { $_.type -eq 'push_to_pull_request_branch' }).Count -gt 0
if ($complete -and -not $pushRequested) {
    exit 0
}

$identity = $null
$contextFile = Join-Path $ResultsDir 'context.json'
if (Test-Path -LiteralPath $contextFile -PathType Leaf) {
    $identity = Get-Content -Raw -LiteralPath $contextFile | ConvertFrom-Json -NoEnumerate
    if ($null -eq $identity -or $identity.GetType() -ne [System.Management.Automation.PSCustomObject] -or
        -not $identity.PSObject.Properties['PackagePath'] -or $identity.PackagePath -isnot [string] -or
        $identity.PackagePath -cnotmatch '\Asdk/[A-Za-z0-9][A-Za-z0-9_.-]*/[A-Za-z0-9][A-Za-z0-9_.-]*\z' -or
        -not $identity.PSObject.Properties['PreRepairSha'] -or $identity.PreRepairSha -isnot [string] -or
        $identity.PreRepairSha -cnotmatch '\A[0-9a-fA-F]{40}\z') {
        throw 'Invalid baseline report identity; expected a literal sdk/service/package path and full hexadecimal checkout SHA.'
    }
}

New-Item -ItemType Directory -Path $ResultsDir -Force | Out-Null
$config = Get-Content -Raw -LiteralPath (Join-Path $PSScriptRoot 'repair-config.yml')
$match = [regex]::Match($config, '(?m)^maxIterations:\s*(\d+)\s*(?:#.*)?$')
if (-not $match.Success -or [int]$match.Groups[1].Value -notin 1..10) {
    throw 'Invalid repair-config.yml maxIterations.'
}
$maxIterations = [int]$match.Groups[1].Value
$rawFiles = @('engine-stdout.txt', 'engine-stderr.txt', 'engine-exit-code.txt')
$hasProcessEvidence = @($rawFiles | Where-Object {
    Test-Path -LiteralPath (Join-Path $ResultsDir $_) -PathType Leaf
}).Count -gt 0
$captureExit = 1
if ($hasProcessEvidence) {
    & pwsh -NoProfile -File (Join-Path $PSScriptRoot 'capture-engine-result.ps1') `
        -ResultsDir $ResultsDir -MaxIterations $maxIterations
    $captureExit = $LASTEXITCODE
    if ($complete -and $pushRequested -and $captureExit -eq 0) { exit 0 }
}

$errorsFile = Join-Path $ResultsDir 'reporting-errors.txt'
$diagnostics = @("Agent outcome: $AgentOutcome. No complete terminal repair comment was produced.")
if ($incomplete.Count -gt 0) {
    $diagnostics += 'Original incomplete output:'
    $diagnostics += ($incomplete | ConvertTo-Json -Depth 20)
}
if ($output.errors.Count -gt 0) {
    $diagnostics += 'Original output ingestion errors:'
    $diagnostics += ($output.errors | ConvertTo-Json -Depth 20)
}
$engineErrors = Join-Path $ResultsDir 'engine-errors.txt'
if (Test-Path -LiteralPath $engineErrors -PathType Leaf) {
    $diagnostics += Get-Content -Raw -LiteralPath $engineErrors
}
$diagnostics | Set-Content -LiteralPath $errorsFile

$arguments = @{
    Repo = $Repo; Pr = $Pr; HeadSha = $HeadSha; RepoRoot = $RepoRoot
    ResultsDir = $ResultsDir
    PreRepairErrorsFile = Join-Path $ResultsDir 'pre-repair-errors.txt'
    EngineErrorsFile = $errorsFile
    OutFile = Join-Path $ResultsDir 'repair-comment.md'
    CommandArtifactDir = $ResultsDir
    CommandArtifactName = 'repair-report'
    MaxIterations = $maxIterations
}
if ($null -ne $identity) {
    $arguments.PackagePath = $identity.PackagePath
    $arguments.PreRepairSha = $identity.PreRepairSha
}

if ($hasProcessEvidence) {
    if ($captureExit -eq 0) {
        # An aborted agent must not turn a successful engine response into a
        # publication claim; keep its raw evidence, but report the incomplete run.
        $arguments.ResultsDir = ''
        Add-Content -LiteralPath $errorsFile -Value 'Engine succeeded, but terminal reporting did not complete. No push is authorized.'
    }
    elseif (Test-Path -LiteralPath $engineErrors -PathType Leaf) {
        Get-Content -Raw -LiteralPath $engineErrors | Add-Content -LiteralPath $errorsFile
    }
}
else {
    # Do not trust stale or agent-authored JSON in the absence of process evidence.
    $arguments.ResultsDir = ''
    $baseline = Join-Path $ResultsDir 'baseline-exit-code.txt'
    if ($AgentOutcome -eq 'success' -and $output.errors.Count -eq 0 -and
        (Test-Path -LiteralPath $baseline -PathType Leaf) -and
        (Get-Content -Raw -LiteralPath $baseline).Trim() -ceq '0' -and
        -not (Test-Path -LiteralPath (Join-Path $ResultsDir 'engine-command.txt'))) {
        $arguments.ForcedStatus = 'skipped_already_green'
    }
}

& (Join-Path $PSScriptRoot 'emit-repair-report.ps1') @arguments
$body = Get-Content -Raw -LiteralPath $arguments.OutFile
@{
    items = @(@{ type = 'add_comment'; body = $body })
    errors = @()
} | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $AgentOutputFile

# Optional Git evidence may be unavailable in the reporting checkout.
exit 0

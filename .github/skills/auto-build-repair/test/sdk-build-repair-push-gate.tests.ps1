#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Regression guards for the SDK Build Repair workflow's green-build push gate.

.DESCRIPTION
  Verifies that only a final structured engine result with success=true can request
  push-to-pull-request-branch, while every red-build terminal state reports without
  committing attempted changes.
#>
[CmdletBinding()]
param(
    [string]$WorkflowPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.md'),
    [string]$LockPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.lock.yml'),
    [string]$SkillPath = (Join-Path $PSScriptRoot '..' 'SKILL.md'),
    [string]$EmitterPath = (Join-Path $PSScriptRoot '..' 'emit-repair-report.ps1')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$workflow = Get-Content -Raw (Resolve-Path $WorkflowPath)
$lock = Get-Content -Raw (Resolve-Path $LockPath)
$skill = Get-Content -Raw (Resolve-Path $SkillPath)
$emitter = Get-Content -Raw (Resolve-Path $EmitterPath)

$failures = [System.Collections.Generic.List[string]]::new()
function Assert([bool]$condition, [string]$message) {
    if ($condition) {
        Write-Host "  [PASS] $message"
    }
    else {
        Write-Host "  [FAIL] $message" -ForegroundColor Red
        $script:failures.Add($message)
    }
}

function Get-WorkflowContent([string]$path) {
    $content = Get-Content -Raw $path
    $match = [regex]::Match(
        $content,
        '(?s)\A---\r?\n(?<frontmatter>.*?)\r?\n---(?:\r?\n|\z)(?<body>.*)\z')

    if (-not $match.Success) {
        throw "Could not isolate workflow frontmatter and body from '$path'."
    }

    return @{
        Frontmatter = $match.Groups['frontmatter'].Value
        Body = $match.Groups['body'].Value
    }
}

function Get-ImportedWorkflowBodies(
    [string]$frontmatter,
    [string]$baseDirectory,
    [System.Collections.Generic.HashSet[string]]$visited
) {
    $bodies = [System.Collections.Generic.List[string]]::new()
    $importsMatch = [regex]::Match(
        $frontmatter,
        '(?m)^imports:[^\r\n]*\r?\n(?<items>(?:^[ \t]+[^\r\n]*(?:\r?\n|\z))*)')

    foreach ($importMatch in [regex]::Matches(
        $importsMatch.Groups['items'].Value,
        '(?m)^\s*-\s*(?:uses:\s*|path:\s*)?["'']?(?<path>[^"''\s#]+)')) {
        $importPath = Join-Path $baseDirectory $importMatch.Groups['path'].Value
        $resolvedImportPath = (Resolve-Path $importPath).Path

        if (-not $visited.Add($resolvedImportPath)) {
            continue
        }

        $importedContent = Get-WorkflowContent $resolvedImportPath
        $bodies.Add($importedContent.Body)

        $nestedBodies = Get-ImportedWorkflowBodies `
            $importedContent.Frontmatter `
            (Split-Path -Parent $resolvedImportPath) `
            $visited
        foreach ($nestedBody in $nestedBodies) {
            $bodies.Add($nestedBody)
        }
    }

    return $bodies
}

function Get-Sha256Hash([string]$value) {
    $sha256 = [System.Security.Cryptography.SHA256]::Create()
    try {
        return ([System.BitConverter]::ToString(
            $sha256.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($value))
        ) -replace '-', '').ToLowerInvariant()
    }
    finally {
        $sha256.Dispose()
    }
}

function Get-WorkflowBodyHash([string]$path) {
    $resolvedPath = (Resolve-Path $path).Path
    $content = Get-WorkflowContent $resolvedPath
    $normalizedBody = (($content.Body -replace "`r`n", "`n").Trim())
    $importedBodies = Get-ImportedWorkflowBodies `
        $content.Frontmatter `
        (Split-Path -Parent $resolvedPath) `
        ([System.Collections.Generic.HashSet[string]]::new(
            [System.StringComparer]::Ordinal))
    [string[]]$normalizedImportedBodies = @(
        $importedBodies |
            ForEach-Object { (($_ -replace "`r`n", "`n").Trim()) }
    )
    [System.Array]::Sort($normalizedImportedBodies, [System.StringComparer]::Ordinal)
    $combinedBody = (@($normalizedBody) + $normalizedImportedBodies) -join "`n---`n"

    return Get-Sha256Hash $combinedBody
}

Write-Host 'Source workflow'
Assert ($workflow -match '(?ms)^\s+push-to-pull-request-branch:\r?\n\s+target: "triggering"') `
    'green repairs retain the PR-branch push safe output'
Assert ($workflow -match '(?s)\*\*Gate the push on a green build\.\*\*.*`result\.json`.*process succeeded and its `success` property is exactly `true`') `
    'push eligibility comes from the final structured engine result'
Assert ($workflow -match '(?s)Do not infer a green build from tool completion.*exhausted iterations') `
    'tool completion and partial progress cannot be mistaken for a green build'
Assert ($workflow -match '(?s)For every other terminal state.*missing/unparseable JSON.*\*\*do not invoke `push-to-pull-request-branch`\*\*') `
    'all red-build stop conditions explicitly suppress the push safe output'
Assert ($workflow -match 'attempted changes remain uncommitted in the ephemeral workspace') `
    'failed repair edits are explicitly ephemeral'

Write-Host 'Checked-in skill'
Assert ($skill -match 'Boolean `success: true`') `
    'skill permits commits only for a green final result'
Assert (($skill -match 'reaching the bound do not establish a green build') -and
        ($skill -match 'Failed changes stay\s+uncommitted')) `
    'iteration exhaustion cannot commit partial progress'
Assert ($skill -match 'failing final results never authorize a push') `
    'skill applies the no-commit rule to every failure reason'

Write-Host 'Failure report'
Assert ($emitter -match 'Repair failed - changes are not eligible for publication') `
    'failed report states that repair changes are ineligible for publication'
Assert ($emitter -notmatch 'Partial progress committed') `
    'failed report cannot claim a partial-progress commit'

Write-Host 'Stale contract guard'
$contract = $workflow + "`n" + $skill + "`n" + $emitter
Assert ($contract -notmatch '(?i)commit progress made so far|commit progress and report') `
    'old commit-on-failure instructions are absent'
Assert ($workflow -match '--max-attempts "<maxIterations from repair-config.yml>"') `
    'the existing configuration flows into the one engine invocation'
Assert ($skill -match 'maxAttempts: <configured maxIterations>') `
    'MCP receives the same configured attempt bound'
Assert ($workflow -match 'Never run an outer retry loop' -and $skill -match 'Invoke \*\*exactly once\*\*') `
    'workflow and skill leave all repair iterations inside the engine'
Assert ($workflow -match 'grep -Fq -- ''--max-attempts''') `
    'an older installed CLI fails the capability check'
Assert ($contract -notmatch 're-invoke \(idempotent\)|re-invocation cap|one per attempt|count of `result-<n>\.json` files') `
    'old outer-loop and result-file counting instructions are absent'

Write-Host 'Compiled workflow metadata'
$bodyHash = Get-WorkflowBodyHash $WorkflowPath
$workflowContent = Get-WorkflowContent (Resolve-Path $WorkflowPath).Path
$mainBodyHash = Get-Sha256Hash (($workflowContent.Body -replace "`r`n", "`n").Trim())
$metadataMatch = [regex]::Match($lock, '"body_hash":"(?<hash>[0-9a-f]{64})"')
Assert ($bodyHash -ne $mainBodyHash) `
    'imported workflow bodies participate in the compiled metadata hash'
Assert ($metadataMatch.Success -and $metadataMatch.Groups['hash'].Value -eq $bodyHash) `
    'compiled metadata hash matches the source and imported workflow bodies'
Assert ($lock -notmatch '(?i)commit progress made so far|commit progress and report|Partial progress committed') `
    'compiled workflow contains no stale commit-on-failure instruction'
Assert ($lock -match 'GH_AW_ACTION_FAILURE_ISSUE_EXPIRES_HOURS: "0"') `
    'disabled failure issues retain the repository-standard zero expiry'

if ($failures.Count -gt 0) {
    Write-Error "$($failures.Count) assertion(s) failed."
}

Write-Host 'All push-gate assertions passed.'

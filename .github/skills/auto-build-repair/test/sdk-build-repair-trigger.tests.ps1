#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Regression guards for the SDK Build Repair workflow triggers.

.DESCRIPTION
  Verifies that the automatic label path and the manual slash-command path remain
  independent. A labeled Auto SDK PR must not need /repair-build in its body,
  while a maintainer can still trigger repair from a PR comment.
#>
[CmdletBinding()]
param(
    [string]$WorkflowPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.md'),
    [string]$LockPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.lock.yml')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$WorkflowPath = (Resolve-Path $WorkflowPath).Path
$LockPath = (Resolve-Path $LockPath).Path
$workflow = Get-Content -Raw $WorkflowPath
$lock = Get-Content -Raw $LockPath

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

Write-Host 'Source workflow'
Assert ($workflow -match '(?ms)^\s+pull_request:\r?\n\s+types: \[labeled\]\r?\n\s+names: \[auto-sdk-build-fix\]') `
    'automatic path listens for the auto-sdk-build-fix label'
Assert ($workflow -match '(?ms)^\s+slash_command:\r?\n\s+name: repair-build\r?\n\s+events: \[pull_request_comment\]') `
    'manual path accepts /repair-build from PR comments'
Assert ($workflow -notmatch '(?m)^\s+events: \[[^\]]*\bpull_request\b[^\]]*\]') `
    'slash command does not inspect pull request bodies'
Assert ($workflow -match "vars\.SDK_BUILD_REPAIR_ENABLED == 'true'") `
    'master feature flag remains required'
Assert ($workflow -match "github\.event\.pull_request\.user\.login == 'azure-sdk-automation\[bot\]'") `
    'release automation bot remains eligible'
Assert ($workflow -match "startsWith\(github\.event\.pull_request\.head\.ref, 'sdkauto/'\)") `
    'automatic path remains restricted to sdkauto branches'

Write-Host 'Compiled workflow'
Assert ($lock -match '(?m)^  pull_request:\r?$') `
    'compiled workflow contains the pull request trigger'
Assert ($lock -match '(?m)^      - labeled\r?$') `
    'compiled workflow listens for labeled events'
Assert ($lock -match '(?m)^  issue_comment:\r?$') `
    'compiled workflow contains the issue comment trigger'
Assert ($lock -match '(?m)^      - created\r?$' -and $lock -match '(?m)^      - edited\r?$') `
    'compiled workflow listens for created and edited comments'
Assert ($lock -match "github\.event\.label\.name == 'auto-sdk-build-fix'") `
    'compiled gate requires the triggering repair label'
Assert ($lock -match "github\.event_name == 'issue_comment'.*startsWith\(github\.event\.comment\.body, '/repair-build") `
    'compiled comment path requires /repair-build'
Assert ($lock -match 'github\.event\.issue\.pull_request != null') `
    'compiled comment path excludes issue comments'
Assert ($lock -notmatch "github\.event_name == 'pull_request' && \(startsWith\(github\.event\.pull_request\.body, '/repair-build") `
    'compiled automatic path does not require /repair-build in the PR body'

if ($failures.Count -gt 0) {
    Write-Error "$($failures.Count) assertion(s) failed."
}

Write-Host "All trigger assertions passed."

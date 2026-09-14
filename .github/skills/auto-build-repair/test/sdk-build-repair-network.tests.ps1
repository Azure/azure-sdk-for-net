#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Regression guards for the SDK Build Repair workflow's nested Copilot network access.

.DESCRIPTION
  Checks the explicit source allowlist and the actual agent AWF network configuration.
  Engine API host metadata and the separate detection job cannot satisfy the agent's
  direct-egress requirement. Uses only PowerShell; no network or gh-aw install required.
#>
[CmdletBinding()]
param(
    [string]$WorkflowPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.md'),
    [string]$LockPath = (Join-Path $PSScriptRoot '..' '..' '..' 'workflows' 'sdk-build-repair.lock.yml')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$workflow = Get-Content -Raw (Resolve-Path $WorkflowPath)
$lock = Get-Content -Raw (Resolve-Path $LockPath)

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

$frontmatterMatch = [regex]::Match($workflow, '(?s)\A---\r?\n(?<frontmatter>.*?)\r?\n---(?:\r?\n|\z)')
if (-not $frontmatterMatch.Success) {
    throw 'Could not isolate the source workflow frontmatter.'
}
$frontmatter = $frontmatterMatch.Groups['frontmatter'].Value
$networkMatch = [regex]::Match(
    $frontmatter,
    '(?m)^network:\r?\n(?<config>(?:^[ \t]+[^\r\n]*(?:\r?\n|\z))*)')
$sourceDomains = @(
    [regex]::Matches($networkMatch.Groups['config'].Value, '(?m)^    - (?<domain>[^\s#]+)') |
        ForEach-Object { $_.Groups['domain'].Value }
)

Write-Host 'Source workflow'
foreach ($domain in @('defaults', 'dotnet', 'github', 'api.githubcopilot.com')) {
    Assert ($sourceDomains -ccontains $domain) "source explicitly allows $domain"
}
Assert ($sourceDomains.Count -eq 4) `
    'source allowlist adds only the nested Copilot API host, not a broader engine bundle or telemetry'
Assert ($frontmatter -match '(?m)^  AZSDK_COPILOT_CLI_PATH: /usr/local/bin/copilot\r?$') `
    'nested client uses the installed Copilot CLI'
Assert ($frontmatter -match '(?m)^  AZSDK_COPILOT_GITHUB_TOKEN: \$\{\{ github.token \}\}\r?$') `
    'nested client retains built-in token authentication'

# Scope to the agent job and its AWF config writer, not GH_AW_ENGINE_API_HOSTS
# or the detection job's independent allowlist.
$agentMatch = [regex]::Match(
    $lock,
    '(?ms)^  agent:\r?\n(?<job>.*?)(?=^  [a-zA-Z0-9_-]+:\r?$|\z)')
if (-not $agentMatch.Success) {
    throw 'Could not isolate the compiled agent job.'
}
$agent = $agentMatch.Groups['job'].Value
$configMatches = [regex]::Matches(
    $agent,
    '(?m)^ +printf ''%s\\n'' "(?<config>.+)" > "\$\{RUNNER_TEMP\}/gh-aw/awf-config\.json"\r?$')
if ($configMatches.Count -ne 1) {
    throw "Expected one agent AWF config writer; found $($configMatches.Count)."
}
$config = $configMatches[0].Groups['config'].Value.Replace('\"', '"')
$compiledNetworkMatch = [regex]::Match($config, '"network":(?<network>\{[^{}\r\n]*\})')
if (-not $compiledNetworkMatch.Success) {
    throw 'Could not isolate network JSON from the agent AWF config.'
}
$network = $compiledNetworkMatch.Groups['network'].Value | ConvertFrom-Json

Write-Host 'Compiled agent workflow'
Assert ($network.allowDomains -ccontains 'api.githubcopilot.com') `
    'agent AWF network.allowDomains permits direct nested Copilot requests'
foreach ($domain in @('api.nuget.org', 'github.com', 'raw.githubusercontent.com')) {
    Assert ($network.allowDomains -ccontains $domain) "agent AWF retains access to $domain"
}
Assert ($network.allowDomains -cnotcontains '*' -and $network.allowDomains -cnotcontains '*.githubcopilot.com') `
    'agent AWF does not allow unrestricted or wildcard Copilot egress'
Assert ($network.isolation -eq $true) 'agent AWF network isolation remains enabled'
Assert ($config -match '"apiProxy":\{"enabled":true,') `
    'outer agent retains managed API proxy inference'
Assert ($agent -match 'awf --config "\$\{RUNNER_TEMP\}/gh-aw/awf-config\.json"') `
    'agent execution consumes the inspected AWF configuration'
Assert ($agent -match '(?m)^      contents: read\r?$' -and $agent -match '(?m)^      pull-requests: read\r?$') `
    'agent retains read-only repository permissions'
Assert ($agent -match '(?m)^      copilot-requests: write\r?$') `
    'agent retains built-in Copilot request permission'

if ($failures.Count -gt 0) {
    Write-Error "$($failures.Count) assertion(s) failed."
}

Write-Host 'All network assertions passed.'

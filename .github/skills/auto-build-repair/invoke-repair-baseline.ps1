#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Capture the baseline package build and its identity for deterministic reporting.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackagePath,
    [Parameter(Mandatory)]
    [string]$ResultsDir,
    [string]$RepoRoot = $env:GITHUB_WORKSPACE
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$root = (Resolve-Path -LiteralPath $RepoRoot).Path
$package = (Resolve-Path -LiteralPath (Join-Path $root $PackagePath)).Path
$relative = [System.IO.Path]::GetRelativePath($root, $package).Replace('\', '/')
if ($relative -notmatch '^sdk/[^/]+/[^/]+$') {
    throw 'Expected a single repository SDK package directory.'
}
$projects = @(Get-ChildItem -LiteralPath (Join-Path $package 'src') -Filter '*.csproj')
if ($projects.Count -ne 1) { throw 'Expected one package source project.' }

New-Item -ItemType Directory -Path $ResultsDir -Force | Out-Null
if (@(Get-ChildItem -LiteralPath $ResultsDir -File).Count -ne 0) {
    throw 'Baseline results directory must be empty; do not reuse repair evidence.'
}
Push-Location $root
try {
    $sha = & git rev-parse HEAD
    if ($LASTEXITCODE -ne 0) { throw 'Cannot record the baseline checkout SHA.' }
    @{
        PackagePath = $relative
        PreRepairSha = $sha
    } | ConvertTo-Json | Set-Content -LiteralPath (Join-Path $ResultsDir 'context.json')

    $exitCode = 1
    $errorsFile = Join-Path $ResultsDir 'pre-repair-errors.txt'
    try {
        $expected = (Get-Content -Raw -LiteralPath (Join-Path $root 'global.json') | ConvertFrom-Json).sdk.version
        if (-not $env:DOTNET_ROOT) { throw 'The isolated DOTNET_ROOT is required.' }
        $env:PATH = "$env:DOTNET_ROOT$([System.IO.Path]::PathSeparator)$env:PATH"
        $dotnet = Join-Path $env:DOTNET_ROOT ($IsWindows ? 'dotnet.exe' : 'dotnet')
        $selected = & $dotnet --version
        if ($LASTEXITCODE -ne 0 -or "$selected".Trim() -cne $expected) {
            throw "Expected SDK $expected from global.json; selected '$selected'."
        }
        & $dotnet build $projects[0].FullName *> $errorsFile
        $exitCode = $LASTEXITCODE
    }
    catch {
        $_ | Out-String | Add-Content -LiteralPath $errorsFile
    }
    Set-Content -LiteralPath (Join-Path $ResultsDir 'baseline-exit-code.txt') -Value $exitCode
}
finally { Pop-Location }

exit $exitCode

#Requires -Version 7.0

<#
.SYNOPSIS
Installs or verifies the Windows prerequisites for sparse-checkout validation.

.DESCRIPTION
VALIDATION ONLY. Installs the exact .NET 10 SDK from global.json, current .NET 8/9 SDKs, Node 22,
Git when needed, Visual Studio Build Tools, and the .NET Framework 4.6.2 SDK/targeting pack. Run
elevated unless -CheckOnly is specified.
#>
[CmdletBinding()]
param(
    [string] $RepoRoot,
    [switch] $CheckOnly
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'
if (!$IsWindows) { throw 'Install-WindowsPrerequisites.ps1 must run on Windows.' }
if (!$RepoRoot) { $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot '../../../..') }
$RepoRoot = [System.IO.Path]::GetFullPath($RepoRoot)

$globalJson = Get-Content -Raw -LiteralPath (Join-Path $RepoRoot 'global.json') | ConvertFrom-Json
$dotnet10Version = [string]$globalJson.sdk.version
if (!$dotnet10Version) { throw 'global.json does not define sdk.version.' }

function Test-Command([string] $Name) {
    return $null -ne (Get-Command $Name -ErrorAction SilentlyContinue)
}

function Invoke-Checked([string] $FilePath, [string[]] $ArgumentList) {
    Write-Host "> $FilePath $($ArgumentList -join ' ')"
    & $FilePath @ArgumentList
    if ($LASTEXITCODE -ne 0) {
        throw "$FilePath failed with exit code $LASTEXITCODE."
    }
}

if (!$CheckOnly) {
    $identity = [Security.Principal.WindowsIdentity]::GetCurrent()
    $principal = [Security.Principal.WindowsPrincipal]::new($identity)
    if (!$principal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
        throw 'Run this prerequisite installer from an elevated PowerShell 7 prompt.'
    }
    if (!(Test-Command 'winget')) {
        throw 'winget is required to install Visual Studio Build Tools and Node 22.'
    }

    $dotnetInstall = Join-Path ([System.IO.Path]::GetTempPath()) 'dotnet-install.ps1'
    Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile $dotnetInstall
    $dotnetRoot = Join-Path $env:ProgramFiles 'dotnet'
    & $dotnetInstall -Version $dotnet10Version -InstallDir $dotnetRoot -Architecture x64 -NoPath
    & $dotnetInstall -Channel '9.0' -Quality GA -InstallDir $dotnetRoot -Architecture x64 -NoPath
    & $dotnetInstall -Channel '8.0' -Quality GA -InstallDir $dotnetRoot -Architecture x64 -NoPath

    Invoke-Checked 'winget' @(
        'install', '--id', 'OpenJS.NodeJS.LTS', '--exact',
        '--accept-package-agreements', '--accept-source-agreements', '--silent'
    )
    if (!(Test-Command 'git')) {
        Invoke-Checked 'winget' @(
            'install', '--id', 'Git.Git', '--exact',
            '--accept-package-agreements', '--accept-source-agreements', '--silent'
        )
    }
    Invoke-Checked 'winget' @(
        'install', '--id', 'Microsoft.VisualStudio.2022.BuildTools', '--exact',
        '--accept-package-agreements', '--accept-source-agreements', '--silent',
        '--override',
        '--wait --passive --norestart --add Microsoft.VisualStudio.Workload.ManagedDesktopBuildTools --add Microsoft.Net.Component.4.6.2.TargetingPack --add Microsoft.Net.Component.4.6.2.SDK --includeRecommended'
    )
    $env:PATH = "$dotnetRoot;$env:ProgramFiles\nodejs;$env:ProgramFiles\Git\cmd;$env:PATH"
}

if (!(Test-Command 'dotnet')) { throw 'dotnet is unavailable after prerequisite setup.' }
$sdks = @(& dotnet --list-sdks)
foreach ($required in @('8.', '9.', "$dotnet10Version [")) {
    if (!($sdks | Where-Object { $_.StartsWith($required, [StringComparison]::OrdinalIgnoreCase) })) {
        throw "Required .NET SDK '$required' is unavailable. Installed SDKs: $($sdks -join '; ')"
    }
}
if (!(Test-Command 'node') -or [int]((& node --version).TrimStart('v').Split('.')[0]) -lt 22) {
    throw 'Node.js 22 or newer is required for Azurite setup.'
}
if (!(Test-Command 'git')) { throw 'Git is required for sparse worktrees.' }

$net462ReferenceAssemblies = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2'
if (!(Test-Path -LiteralPath $net462ReferenceAssemblies)) {
    throw ".NET Framework 4.6.2 targeting pack is unavailable at '$net462ReferenceAssemblies'."
}

Write-Host 'Windows sparse-checkout validation prerequisites are available.'
Write-Host "  .NET SDKs: $($sdks -join '; ')"
Write-Host "  Node: $(& node --version)"
Write-Host "  Git: $(& git --version)"
Write-Host "  net462 references: $net462ReferenceAssemblies"

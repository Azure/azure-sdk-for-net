#Requires -Version 7.0

<#
.SYNOPSIS
Builds the Linux validation image and runs or resumes sparse-checkout validation.
#>
[CmdletBinding()]
param(
    [string] $RepoRoot,
    [string] $OutputRoot,
    [string] $ImageName = 'azsdk-sparse-checkout-validation:local',
    [string] $VolumeName = 'azsdk-sparse-checkout-validation',
    [ValidateSet('docker', 'podman')][string] $ContainerEngine,
    [ValidateSet('linux/amd64', 'linux/arm64')][string] $ContainerPlatform = 'linux/amd64',
    [string] $ArtifactFilter = '.*',
    [string] $MatrixFilter = '.*',
    [int] $MaxCases = 0,
    [ValidateSet('Stop', 'Continue')][string] $FailureMode = 'Stop',
    [switch] $Resume,
    [switch] $ListOnly,
    [switch] $SkipRecordings,
    [switch] $SkipAzurite,
    [switch] $SkipImageBuild
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

function Invoke-ContainerEngine([string[]] $ArgumentList) {
    Write-Host "> $ContainerEngine $($ArgumentList -join ' ')"
    & $ContainerEngine @ArgumentList
    if ($LASTEXITCODE -ne 0) {
        throw "$ContainerEngine $($ArgumentList -join ' ') failed with exit code $LASTEXITCODE."
    }
}

if (!$ContainerEngine) {
    if (Get-Command 'docker' -ErrorAction SilentlyContinue) {
        $ContainerEngine = 'docker'
    }
    elseif (Get-Command 'podman' -ErrorAction SilentlyContinue) {
        $ContainerEngine = 'podman'
    }
    else {
        throw 'Docker or Podman is required to run Linux sparse-checkout validation.'
    }
}

if (!$RepoRoot) {
    $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot '../../../..')
}
$RepoRoot = [System.IO.Path]::GetFullPath($RepoRoot)
if (!$OutputRoot) {
    $OutputRoot = Join-Path $RepoRoot 'artifacts/validation/RepositoryProjectGraph/sparse-checkout'
}
$OutputRoot = [System.IO.Path]::GetFullPath($OutputRoot)
New-Item -ItemType Directory -Path $OutputRoot -Force | Out-Null

$sourceCommit = (& git -C $RepoRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or !$sourceCommit) { throw "Unable to read HEAD under '$RepoRoot'." }

if (!$SkipImageBuild) {
    Invoke-ContainerEngine @(
        'build', '--platform', $ContainerPlatform,
        '--file', (Join-Path $PSScriptRoot 'Dockerfile'),
        '--tag', $ImageName,
        $PSScriptRoot
    )
}
& $ContainerEngine volume inspect $VolumeName *> $null
if ($LASTEXITCODE -ne 0) {
    Invoke-ContainerEngine @('volume', 'create', $VolumeName)
}

$containerArguments = [System.Collections.Generic.List[string]]::new()
@(
    'run', '--rm', '--platform', $ContainerPlatform,
    '--volume', "${RepoRoot}:/source:ro",
    '--volume', "${OutputRoot}:/results",
    '--volume', "${VolumeName}:/workspace",
    '--env', 'NUGET_PACKAGES=/workspace/nuget',
    $ImageName,
    'pwsh', '-NoProfile', '-NonInteractive', '-File',
    '/source/eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/Invoke-LinuxContainer.ps1',
    '-SourceRepository', '/source',
    '-WorkspaceRoot', '/workspace',
    '-OutputRoot', '/results',
    '-SourceCommit', $sourceCommit,
    '-ExpectedArchitecture', $(if ($ContainerPlatform -eq 'linux/amd64') { 'X64' } else { 'Arm64' }),
    '-ArtifactFilter', $ArtifactFilter,
    '-MatrixFilter', $MatrixFilter,
    '-MaxCases', [string]$MaxCases,
    '-FailureMode', $FailureMode
) | ForEach-Object { $containerArguments.Add([string]$_) }
if ($Resume) { $containerArguments.Add('-Resume') }
if ($ListOnly) { $containerArguments.Add('-ListOnly') }
if ($SkipRecordings) { $containerArguments.Add('-SkipRecordings') }
if ($SkipAzurite) { $containerArguments.Add('-SkipAzurite') }

Invoke-ContainerEngine $containerArguments.ToArray()

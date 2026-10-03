#Requires -Version 7.0

<#
.SYNOPSIS
Owns the clean Docker-volume clone used by Linux sparse-checkout validation.

.DESCRIPTION
VALIDATION ONLY. Invoke-LinuxDocker.ps1 calls this script inside the pinned container. The source
mount is read-only; all Git state, caches, sparse files, and generated output use dedicated mounts.
#>
[CmdletBinding()]
param(
    [string] $SourceRepository = '/source',
    [string] $WorkspaceRoot = '/workspace',
    [string] $OutputRoot = '/results',
    [Parameter(Mandatory = $true)][string] $SourceCommit,
    [ValidateSet('X64', 'Arm64')][string] $ExpectedArchitecture = 'X64',
    [string] $ArtifactFilter = '.*',
    [string] $MatrixFilter = '.*',
    [int] $MaxCases = 0,
    [ValidateSet('Stop', 'Continue')][string] $FailureMode = 'Stop',
    [switch] $Resume,
    [switch] $ListOnly,
    [switch] $SkipRecordings,
    [switch] $SkipAzurite
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'
if (!$IsLinux) { throw 'Invoke-LinuxContainer.ps1 must run on Linux.' }
$actualArchitecture = [string][System.Runtime.InteropServices.RuntimeInformation]::OSArchitecture
if ($actualArchitecture -ne $ExpectedArchitecture) {
    throw "Linux validation expected architecture '$ExpectedArchitecture' but is running as '$actualArchitecture'."
}

# Fail before graph generation when a reused or locally modified image lacks the CI SDK baseline.
$globalJson = Get-Content -Raw -LiteralPath (Join-Path $SourceRepository 'global.json') | ConvertFrom-Json
$dotnet10Version = [string]$globalJson.sdk.version
$sdks = @(& dotnet --list-sdks)
foreach ($required in @('8.', '9.', "$dotnet10Version [")) {
    if (!($sdks | Where-Object { $_.StartsWith($required, [StringComparison]::OrdinalIgnoreCase) })) {
        throw "Required .NET SDK '$required' is unavailable. Installed SDKs: $($sdks -join '; ')"
    }
}
if ([int]((& node --version).TrimStart('v').Split('.')[0]) -lt 22) {
    throw 'Node.js 22 or newer is required for Azurite setup.'
}

function Invoke-CheckedGit([string[]] $ArgumentList, [string] $Repository) {
    Write-Host "> git -C $Repository $($ArgumentList -join ' ')"
    & git -C $Repository @ArgumentList
    if ($LASTEXITCODE -ne 0) {
        throw "git $($ArgumentList -join ' ') failed with exit code $LASTEXITCODE."
    }
}

# Docker mounts retain host ownership. Trust only the explicit read-only source mount used to seed
# the validation clone; all subsequent Git operations run against container-owned storage.
& git config --global --add safe.directory $SourceRepository
if ($LASTEXITCODE -ne 0) { throw "Unable to mark source repository '$SourceRepository' as safe." }

$repository = Join-Path $WorkspaceRoot 'repository'
if (!(Test-Path -LiteralPath (Join-Path $repository '.git'))) {
    if (Test-Path -LiteralPath $repository) {
        throw "Workspace repository path exists but is not a Git clone: $repository"
    }
    New-Item -ItemType Directory -Path $WorkspaceRoot -Force | Out-Null
    & git clone --no-hardlinks --no-checkout $SourceRepository $repository
    if ($LASTEXITCODE -ne 0) { throw 'Unable to create the clean Linux validation clone.' }
}

Invoke-CheckedGit @('fetch', '--force', $SourceRepository, $SourceCommit) $repository
Invoke-CheckedGit @('checkout', '--detach', '--force', $SourceCommit) $repository
Invoke-CheckedGit @('clean', '-ffdx') $repository

$inputRoot = Join-Path $OutputRoot 'inputs'
$prepareArguments = @{
    RepoRoot = $repository
    OutputRoot = $inputRoot
    # Generate Windows cases from the same Linux graph/map because production fans that artifact
    # out to all hosts. Invoke-WindowsValidation.ps1 consumes these inputs later.
    TargetHost = 'All'
}
if ($Resume) { $prepareArguments.ReuseInputs = $true }
& (Join-Path $SourceRepository 'eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/New-ValidationInputs.ps1') @prepareArguments | Out-Null

$runArguments = @{
    RepoRoot = $repository
    InputRoot = $inputRoot
    ResultsRoot = (Join-Path $OutputRoot 'runs/linux')
    TargetHost = 'Linux'
    WorktreeRoot = (Join-Path $WorkspaceRoot 'sparse-worktree-linux')
    NuGetPackages = (Join-Path $WorkspaceRoot 'nuget')
    CacheRoot = (Join-Path $WorkspaceRoot 'cache')
    ArtifactFilter = $ArtifactFilter
    MatrixFilter = $MatrixFilter
    MaxCases = $MaxCases
    FailureMode = $FailureMode
}
if ($Resume) { $runArguments.Resume = $true }
if ($ListOnly) { $runArguments.ListOnly = $true }
if ($SkipRecordings) { $runArguments.SkipRecordings = $true }
if ($SkipAzurite) { $runArguments.SkipAzurite = $true }
if ($ExpectedArchitecture -eq 'Arm64') { $runArguments.TestTargetArchitecture = 'arm64' }
& (Join-Path $SourceRepository 'eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/Invoke-SparseCheckoutValidation.ps1') @runArguments

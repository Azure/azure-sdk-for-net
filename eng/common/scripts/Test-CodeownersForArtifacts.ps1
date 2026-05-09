<#
.SYNOPSIS
Validates CODEOWNERS coverage for package directories described by package-info JSON files.

.DESCRIPTION
Reads package-info JSON files from a directory and runs `azsdk config codeowners check-package`
for each eligible package directory. Packages can be excluded by package-info artifact details or SDK type.

When a PR diff file is supplied, the script applies PR-aware behavior:
- packages with no direct file changes under their package directory are skipped,
- packages whose directory is brand new on the target branch are skipped,
- packages with direct changes under an existing directory are validated regardless of release status.

Without a PR diff file, the script validates packages that are intended to release.

.PARAMETER AzsdkPath
Path to the `azsdk` CLI executable used to run CODEOWNERS validation.

.PARAMETER PackageInfoDirectory
Directory containing package-info JSON files, typically produced by `Save-Package-Properties.ps1`
or downloaded from a pipeline artifact such as `PackageInfo`.

.PARAMETER SdkTypes
Array of SDK types that should be validated. Package-info entries whose `SdkType` is not in this
list are skipped.

.PARAMETER Repo
Repository name passed through to the AZSDK CLI for CODEOWNERS cache lookup.

.PARAMETER PrDiffFile
Optional path to a `diff.json` file produced by `Generate-PR-Diff.ps1`. When supplied, the script
switches to PR-aware validation behavior and only blocks on direct changes to existing package
directories. If omitted, PR-aware validation is disabled.

.PARAMETER TargetCommittish
Git committish used to inspect existing files for a package directory when `PrDiffFile` is
supplied. Default: the PR target branch from Azure Pipelines, normalized to `origin/<branch>`.

.EXAMPLE
pwsh -File eng/common/scripts/Test-CodeownersForArtifacts.ps1 `
  -AzsdkPath "$(AZSDK)" `
  -PackageInfoDirectory "$(Build.ArtifactStagingDirectory)/PackageInfo" `
  -SdkTypes @('client', 'compat', 'data', 'functions', 'datamovement') `
  -Repo 'Azure/azure-sdk-for-net'

.EXAMPLE
pwsh -File eng/common/scripts/Test-CodeownersForArtifacts.ps1 `
  -AzsdkPath "$(AZSDK)" `
  -PackageInfoDirectory "$(Build.ArtifactStagingDirectory)/PackageInfo" `
  -SdkTypes @('client', 'compat', 'data', 'functions', 'datamovement') `
  -Repo 'Azure/azure-sdk-for-net' `
  -PrDiffFile "$(Build.ArtifactStagingDirectory)/CodeownersPrDiff/diff.json" `
  -TargetCommittish 'origin/main'
#>
[CmdletBinding()]
param(
    [string] $AzsdkPath,
    [string] $PackageInfoDirectory,
    [array] $SdkTypes,
    [string] $Repo,
    [string] $PrDiffFile,
    [string] $TargetCommittish = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/")
)

. "$PSScriptRoot/common.ps1"

Set-StrictMode -Version 3
$ErrorActionPreference = 'Stop'

function getNormalizedRelativePath([string] $Path) {
    if (!$Path) {
        return ""
    }

    $normalized = $Path.Replace("\", "/")
    while ($normalized.StartsWith("./")) {
        $normalized = $normalized.Substring(2)
    }

    return $normalized.TrimStart('/').TrimEnd('/')
}

function getChangedFilesForDirectory([PSCustomObject] $PrDiff, [string] $DirectoryPath) {
    $normalizedDirectoryPath = getNormalizedRelativePath $DirectoryPath
    $changedPaths = @($PrDiff.ChangedFiles) + @($PrDiff.DeletedFiles)
    $matchingFiles = @()

    foreach ($changedPath in $changedPaths) {
        if (!$changedPath) {
            continue
        }

        $normalizedChangedPath = getNormalizedRelativePath $changedPath
        if ($normalizedChangedPath -eq $normalizedDirectoryPath -or $normalizedChangedPath.StartsWith("$normalizedDirectoryPath/")) {
            $matchingFiles += $normalizedChangedPath
        }
    }

    return ,@($matchingFiles)
}

function getExistingFiles([string] $DirectoryPath, [string] $TargetCommittish) {
    if (!$targetCommittish -or $targetCommittish -eq "origin/") {
        LogError "TargetCommittish must be set for PR-aware CODEOWNERS verification."
        exit 1
    }

    $normalizedDirectoryPath = getNormalizedRelativePath $DirectoryPath
    $targetFiles = Invoke-LoggedCommand "git ls-tree -r --name-only `"$targetCommittish`" -- `"$normalizedDirectoryPath`"" -DoNotExitOnFailedExitCode
    if ($LASTEXITCODE) {
        LogError "Failed to inspect target branch contents for directory '$normalizedDirectoryPath' at '$targetCommittish'."
        exit 1
    }

    return ,@($targetFiles | Where-Object { $_ })
}

function shouldSkipCodeownersInPrContext([PSCustomObject] $PackageProperties, [PSCustomObject] $PrDiff, [string] $TargetCommittish) {
    $directoryPath = getNormalizedRelativePath $PackageProperties.DirectoryPath
    if (!$directoryPath) {
        LogError "Package '$($PackageProperties.Name)' is missing a DirectoryPath property."
        exit 1
    }

    $changedFiles = getChangedFilesForDirectory -PrDiff $PrDiff -DirectoryPath $directoryPath
    if (@($changedFiles).Count -eq 0) {
        Write-Host "  PR context: skipping CODEOWNERS for '$directoryPath' because the PR does not directly change files under that package directory."
        return $true
    }

    $targetFiles = getExistingFiles -DirectoryPath $directoryPath -TargetCommittish $TargetCommittish
    if (@($targetFiles).Count -gt 0) {
        Write-Host "  PR context: not skipping CODEOWNERS for '$directoryPath' because the target branch already contains files under that directory."
        return $false
    }

    Write-Host "  PR context: skipping CODEOWNERS for '$directoryPath' because the PR only introduces files in a brand-new directory."
    foreach ($changedFile in $changedFiles) {
        Write-Host "    $changedFile"
    }
    return $true
}

$failedPackages = @()
$prDiff = $null
$isPrCheck = $false

if ($PrDiffFile) {
    if (!(Test-Path $PrDiffFile)) {
        LogError "PR diff file '$PrDiffFile' does not exist."
        exit 1
    }

    Write-Host "Loading PR diff from '$PrDiffFile'"
    $prDiff = Get-Content -Raw -Path $PrDiffFile | ConvertFrom-Json
    $isPrCheck = $true
}

Write-Host "SDK types to validate: $($SdkTypes -join ', ')"

foreach ($pkgPropertiesFile in Get-ChildItem -Path $PackageInfoDirectory -Filter '*.json' -File) {
    $pkgProperties = Get-Content -Raw -Path $pkgPropertiesFile | ConvertFrom-Json
    $artifactDetails = $pkgProperties.ArtifactDetails

    if ($artifactDetails -and $artifactDetails.PSObject.Properties['skipCodeownersVerification'] -and $artifactDetails.skipCodeownersVerification) {
        Write-Host "Skipping package: $($pkgProperties.Name) $($pkgProperties.DirectoryPath) because package info marks it to skip CODEOWNERS verification."
        continue
    }
    if ($SdkTypes -notcontains $pkgProperties.SdkType) {
        Write-Host "Skipping package: $($pkgProperties.Name) $($pkgProperties.DirectoryPath) because its SdkType '$($pkgProperties.SdkType)' is not in the list of SdkTypes to validate."
        continue
    }

    Write-Host "Validating codeowners for package: $($pkgProperties.Name) $($pkgProperties.DirectoryPath)"

    if (!$isPrCheck -and !$pkgProperties.ReleaseStatus) {
        LogError "Package $($pkgProperties.Name) at $($pkgProperties.DirectoryPath) is missing a ReleaseStatus property."
        $failedPackages += $pkgProperties.DirectoryPath
        continue
    }

    if ($prDiff -and (shouldSkipCodeownersInPrContext -PackageProperties $pkgProperties -PrDiff $prDiff -TargetCommittish $TargetCommittish)) {
        continue
    }

    if ($isPrCheck -or $pkgProperties.ReleaseStatus -ne "Unreleased") {
        $output = & $AzsdkPath config codeowners check-package `
            --directory-path $pkgProperties.DirectoryPath `
            --repo $Repo `
            --output json 2>&1

        if ($LASTEXITCODE) {
            LogError "Codeowners validation failed for package: $($pkgProperties.DirectoryPath)"
            $output | Write-Host
            $failedPackages += $pkgProperties.DirectoryPath
        } else {
            Write-Host "  Codeowners validation succeeded for package: $($pkgProperties.DirectoryPath)"
        }
    } else {
        Write-Host "  Skipping CODEOWNERS validation, package is not intended to release."
    }
}

if ($failedPackages.Count -gt 0) {
    Write-Host ""
    Write-Host "Failed Packages:"
    foreach ($directoryPath in $failedPackages) {
        LogError "  - $directoryPath does not have sufficient code owners coverage"
    }
    LogError "Codeowners validation failed for one or more packages. See http://aka.ms/azsdk/codeowners for instructions to fix the issue."
    exit 1
}
exit 0

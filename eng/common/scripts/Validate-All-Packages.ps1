[CmdletBinding()]
Param (
  [Parameter(Mandatory=$False)]
  [array]$ArtifactList,
  [Parameter(Mandatory=$True)]
  [string]$ArtifactPath,
  [Parameter(Mandatory=$True)]
  [string]$RepoRoot,
  [Parameter(Mandatory=$True)]
  [string]$APIKey,
  [string]$ConfigFileDir,
  [string]$BuildDefinition,
  [string]$PipelineUrl,
  [string]$APIViewUri  = "https://apiview.dev/AutoReview/GetReviewStatus",
  [bool] $IsReleaseBuild = $false,
  [Parameter(Mandatory=$False)]
  [array] $PackageInfoFiles
)

# Validate-All-Packages.ps1 folds in the code that was originally in Validate-Package.ps1
# since Validate-Package.ps1 was only called from Validate-All-Packages.ps1. This replaces
# script calls with function calls and also allows calling CheckAzLoginAndDevOpsExtensionInstall
# and CheckDevOpsAccess once for all of the PackageInfo files being processed instead of once
# per artifact in Validate-Package.ps1 and then again in Update-DevOps-Release-WorkItem.ps1

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers\ApiView-Helpers.ps1)
. (Join-Path $PSScriptRoot Helpers\DevOps-WorkItem-Helpers.ps1)

# Function to validate change log
function ValidateChangeLog($changeLogPath, $versionString, $validationStatus)
{
    try
    {
        $ChangeLogStatus = [PSCustomObject]@{
            IsValid = $false
            Message = ""
        }
        $changeLogFullPath = Join-Path $RepoRoot $changeLogPath
        Write-Host "Path to change log: [$changeLogFullPath]"
        if (Test-Path $changeLogFullPath)
        {
            Confirm-ChangeLogEntry -ChangeLogLocation $changeLogFullPath -VersionString $versionString -ForRelease $true -ChangeLogStatus $ChangeLogStatus -SuppressErrors $true
            $validationStatus.Status = if ($ChangeLogStatus.IsValid) { "Success" } else { "Failed" }
            $validationStatus.Message = $ChangeLogStatus.Message
        }
        else {
            $validationStatus.Status = "Failed"
            $validationStatus.Message = "Change log is not found in [$changeLogPath]. Change log file must be present in package root directory."
        }
    }
    catch
    {
        Write-Host "Current directory: $(Get-Location)"
        $validationStatus.Status = "Failed"
        $validationStatus.Message = $_.Exception.Message
    }
}

# Function to verify API review status
function VerifyAPIReview($packageName, $packageVersion, $language)
{
    $APIReviewValidation = [PSCustomObject]@{
        Name = "API Review Approval"
        Status = "Pending"
        Message = ""
    }
    $PackageNameValidation = [PSCustomObject]@{
        Name = "Package Name Approval"
        Status = "Pending"
        Message = ""
    }

    try
    {
        $apiStatus = [PSCustomObject]@{
            IsApproved = $false
            Details = ""
        }
        $packageNameStatus = [PSCustomObject]@{
            IsApproved = $false
            Details = ""
        }
        Write-Host "Checking API review status for package $packageName with version $packageVersion. language [$language]."
        Check-ApiReviewStatus $packageName $packageVersion $language $APIViewUri $APIKey $apiStatus $packageNameStatus

        Write-Host "API review approval details: $($apiStatus.Details)"
        Write-Host "Package name approval details: $($packageNameStatus.Details)"
        #API review approval status
        $APIReviewValidation.Message = $apiStatus.Details
        $APIReviewValidation.Status = if ($apiStatus.IsApproved) { "Approved" } else { "Pending" }

        # Package name approval status
        $PackageNameValidation.Status = if ($packageNameStatus.IsApproved) { "Approved" } else { "Pending" }
        $PackageNameValidation.Message = $packageNameStatus.Details
    }
    catch
    {
        Write-Warning "Failed to get API review status. Error: $_"
        $PackageNameValidation.Status = "Failed"
        $PackageNameValidation.Message = $_.Exception.Message
        $APIReviewValidation.Status = "Failed"
        $APIReviewValidation.Message = $_.Exception.Message
    }

    return [PSCustomObject]@{
        ApiviewApproval = $APIReviewValidation
        PackageNameApproval = $PackageNameValidation
    }
}


function IsVersionShipped($packageName, $packageVersion)
{
    # This function will decide if a package version is already shipped or not
    Write-Host "Checking if a version is already shipped for package $packageName with version $packageVersion."
    $parsedNewVersion = [AzureEngSemanticVersion]::new($packageVersion)
    $versionMajorMinor = "" + $parsedNewVersion.Major + "." + $parsedNewVersion.Minor
    $workItem = FindPackageWorkItem -lang $LanguageDisplayName -packageName $packageName -version $versionMajorMinor -includeClosed $true -outputCommand $false
    if ($workItem)
    {
        # Check if the package version is already shipped
        $shippedVersionSet = ParseVersionSetFromMDField $workItem.fields["Custom.ShippedPackages"]
        if ($shippedVersionSet.ContainsKey($packageVersion)) {
            return $true
        }
    }
    else {
        Write-Host "No work item found for package [$packageName]. Creating new work item for package."
    }
    return $false
}

function CreateUpdatePackageWorkItem($pkgInfo)
{
    # This function will create or update package work item in Azure DevOps
    $versionString = $pkgInfo.Version
    $packageName = $pkgInfo.Name
    $plannedDate = $pkgInfo.ReleaseStatus
    $setReleaseState = $true
    if (!$plannedDate -or $plannedDate -eq "Unreleased")
    {
        $setReleaseState = $false
        $plannedDate = "unknown"
    }

    # Create or update package work item
    $result = Update-DevOpsReleaseWorkItem -language $LanguageDisplayName `
        -packageName $packageName `
        -version $versionString `
        -plannedDate $plannedDate `
        -packageRepoPath $pkgInfo.serviceDirectory `
        -packageType $pkgInfo.SDKType `
        -packageNewLibrary $pkgInfo.IsNewSDK `
        -serviceName "unknown" `
        -packageDisplayName "unknown" `
        -inRelease $IsReleaseBuild

    if (-not $result)
    {
        Write-Host "Update of the Devops Release WorkItem failed."
    }
    return [bool]$result
}

function ProcessPackage($packageInfo)
{
    # Read package property file and identify all packages to process
    # $packageInfo.Name is the package name published to package managers, e.g. @azure/azure-template
    # $packageInfo.ArtifactName is the name can be used in path and file names, e.g. azure-template  
    Write-Host "Processing artifact: $($packageInfo.ArtifactName)"
    Write-Host "Is Release Build: $IsReleaseBuild"
    $pkgName = $packageInfo.Name
    $changeLogPath = $packageInfo.ChangeLogPath
    $versionString = $packageInfo.Version
    Write-Host "Checking if we need to create or update work item for package $pkgName with version $versionString."
    $isShipped = IsVersionShipped $pkgName $versionString
    if ($isShipped) {
        Write-Host "Package work item already exists for version [$versionString] that is marked as shipped. Skipping the update of package work item."
        return
    }

    Write-Host "Validating package $pkgName with version $versionString."

    # Change log validation
    $changeLogStatus = [PSCustomObject]@{
        Name = "Change Log Validation"
        Status = "Success"
        Message = ""
    }
    ValidateChangeLog $changeLogPath $versionString $changeLogStatus

    # API review and package name validation
    $fullPackageName = $pkgName

    # If there's a groupId that means this is Java and pkgName = GroupId+ArtifactName
    # but the VerifyAPIReview requires GroupId:ArtifactName
    Write-Host "Package name before checking groupId: $fullPackageName"
    if ($packageInfo.PSObject.Members.Name -contains "Group") {
        $groupId = $packageInfo.Group
        if ($groupId){
            $fullPackageName = "${groupId}:$($packageInfo.ArtifactName)"
        }
    }

    Write-Host "Checking API review status for package $fullPackageName"
    $apireviewDetails = VerifyAPIReview $fullPackageName $packageInfo.Version $Language

    $pkgValidationDetails= [PSCustomObject]@{
        Name = $pkgName
        Version = $packageInfo.Version
        ChangeLogValidation = $changeLogStatus
        APIReviewValidation = $apireviewDetails.ApiviewApproval
        PackageNameValidation = $apireviewDetails.PackageNameApproval
    }

    $output = ConvertTo-Json $pkgValidationDetails
    Write-Host "Output: $($output)"

    # Create json token file in artifact path
    $tokenFile = Join-Path $ArtifactPath "$($packageInfo.ArtifactName)-Validation.json"
    $output | Out-File -FilePath $tokenFile -Encoding utf8

    # Create DevOps work item
    $updatedWi = CreateUpdatePackageWorkItem $packageInfo

    # Update validation status in package work item
    if ($updatedWi) {
        Write-Host "Updating validation status in package work item."
        $updatedWi = UpdateValidationStatus $pkgValidationDetails $BuildDefinition $PipelineUrl
    }

    # Fail the build if any validation is not successful for a release build
    Write-Host "Change log status:" $changeLogStatus.Status
    Write-Host "API Review status:" $apireviewDetails.ApiviewApproval.Status
    Write-Host "Package Name status:" $apireviewDetails.PackageNameApproval.Status

    if ($IsReleaseBuild)
    {
        if (!$updatedWi -or $changeLogStatus.Status -ne "Success" -or $apireviewDetails.ApiviewApproval.Status -ne "Approved" -or $apireviewDetails.PackageNameApproval.Status -ne "Approved") {
            Write-Error "At least one of the Validations above failed for package $pkgName with version $versionString."
            exit 1
        }
    }
}

CheckAzLoginAndDevOpsExtensionInstall

CheckDevOpsAccess

Write-Host "Artifact path: $($ArtifactPath)"
Write-Host "Artifact List: $($ArtifactList -join ', ')"
Write-Host "Package Info Files: $($PackageInfoFiles -join ', ')"
Write-Host "IsReleaseBuild: $IsReleaseBuild"

# Check if package config file is present. This file has package version, SDK type etc info.
if (-not $ConfigFileDir) {
    $ConfigFileDir = Join-Path -Path $ArtifactPath "PackageInfo"
}

Write-Host "Config file path: $($ConfigFileDir)"
# Initialize working variable
$ProcessedPackageInfoFiles = @()

if ($ArtifactList -and $ArtifactList.Count -gt 0)
{
    # Multiple artifacts mode (existing usage)
    Write-Host "Using ArtifactList parameter with $($ArtifactList.Count) artifacts"
    foreach ($artifact in $ArtifactList)
    {
        $pkgPropPath = Join-Path -Path $ConfigFileDir "$($artifact.name).json"
        if (Test-Path $pkgPropPath) {
            $ProcessedPackageInfoFiles += $pkgPropPath
        }
        else {
            Write-Warning "Package property file path $pkgPropPath is invalid."
        }
    }
}
elseif ($PackageInfoFiles -and $PackageInfoFiles.Count -gt 0)
{
    # Direct PackageInfoFiles (new method)
    Write-Host "Using PackageInfoFiles parameter with $($PackageInfoFiles.Count) files"
    $ProcessedPackageInfoFiles = $PackageInfoFiles
}

# Validate that we have package info files to process
if (-not $ProcessedPackageInfoFiles -or $ProcessedPackageInfoFiles.Count -eq 0) {
    Write-Error "No package info files found after processing parameters."
    exit 1
}

Write-Host "Processed Package Info Files: $($ProcessedPackageInfoFiles -join ', ')"

# Process all packages using the processed PackageInfoFiles array
foreach ($packageInfoFile in $ProcessedPackageInfoFiles)
{
    $packageInfo = Get-Content $packageInfoFile | ConvertFrom-Json
    ProcessPackage -packageInfo $packageInfo
}

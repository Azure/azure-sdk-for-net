#This script is responsible for release preparedness check that's run as part of build pipeline.

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)]  
  [string] $PackageName,
  [Parameter(Mandatory = $true)] 
  [string] $ArtifactPath,
  [Parameter(Mandatory=$True)]
  [string] $RepoRoot,
  [Parameter(Mandatory=$True)]
  [string] $APIKey,  
  [Parameter(Mandatory=$True)]
  [string] $ConfigFileDir,
  [string] $BuildDefinition,
  [string] $PipelineUrl,
  [string] $APIViewUri,
  [string] $Devops_pat = $env:DEVOPS_PAT
)
Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)
. ${PSScriptRoot}\Helpers\ApiView-Helpers.ps1
. ${PSScriptRoot}\Helpers\DevOps-WorkItem-Helpers.ps1

if (!$Devops_pat) {
  az account show *> $null
  if (!$?) {
    Write-Host 'Running az login...'
    az login *> $null
  }
}
else {
  # Login using PAT
  LoginToAzureDevops $Devops_pat
}

az extension show -n azure-devops *> $null
if (!$?){
  az extension add --name azure-devops
} else {
  # Force update the extension to the latest version if it was already installed
  # this is needed to ensure we have the authentication issue fixed from earlier versions
  az extension update -n azure-devops *> $null
}

CheckDevOpsAccess

# Function to validate change log
function ValidateChangeLog($changeLogPath, $versionString)
{
    $validationStatus = [PSCustomObject]@{
        Name = "Change Log Validation"
        Status = "Success"
        Message = ""
    }

    try
    {
        $changeLogFullPath = Join-Path $RepoRoot $changeLogPath
        Write-Host "Path to change log: [$changeLogFullPath]"        
        if (Test-Path $changeLogFullPath)
        {
            $errOutput = $( $validChangeLog = & Confirm-ChangeLogEntry -ChangeLogLocation $changeLogFullPath -VersionString $versionString -ForRelease $true ) 2>&1
            if (!$validChangeLog) {
                $validationStatus.Status = "Failed"
                $validationStatus.Message = $errOutput
            }
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
    return $validationStatus
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
        Write-Host "Checking API review status for package $packageName with version $packageVersion. language [$language]." 
        $apireviewStatus =  Check-ApiReviewStatus -PackageName $packageName -Language $language -packageVersion $packageVersion -url $APIViewUri -apiKey $APIKey
        Write-Host "API Review status: $apireviewStatus"

        #API review approval status
        if ($apireviewStatus -eq '200')
        {
            $APIReviewValidation.Status = "Approved"
            $APIReviewValidation.Message = "API review is in approved status."
        }
        else
        {
            $APIReviewValidation.Status = "Pending"
            $APIReviewValidation.Message = "API Review is not approved for package $($packageName). Release pipeline will fail if API review is not approved for a stable version release.You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
        }

        # Package name approval status
        if ($apireviewStatus -eq '200' -or $apireviewStatus -eq '201')
        {
            $PackageNameValidation.Status = "Approved"
            $PackageNameValidation.Message = "Package name is in approved status."
        }
        elseif ($apireviewStatus -eq '202')
        {
            $PackageNameValidation.Status = "Pending"
            $PackageNameValidation.Message = "Package name [$($packageName)] is not yet approved by an SDK API approver. Package name must be approved to release a beta version if $($packageName) was never released a stable version. You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on package name Approval."
        }
        else
        {
            $PackageNameValidation.Status = "Failed"
            $PackageNameValidation.Message = "Package name approval status is not available for package $($packageName)."
        }
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
    &$EngCommonScriptsDir/Update-DevOps-Release-WorkItem.ps1 `
        -language $LanguageDisplayName `
        -packageName $packageName `
        -version $versionString `
        -plannedDate $plannedDate `
        -packageRepoPath $pkgInfo.serviceDirectory `
        -packageType $pkgInfo.SDKType `
        -packageNewLibrary $pkgInfo.IsNewSDK `
        -serviceName "unknown" `
        -packageDisplayName "unknown" `
        -inRelease $setReleaseState `
        -devops_pat $Devops_pat
    
    if ($LASTEXITCODE -ne 0)
    {
        Write-Host "Update of the Devops Release WorkItem failed."
        return $false
    }
    return $true
}

function UpdateValidationStatus($pkgvalidationDetails)
{
    $pkgName = $pkgValidationDetails.Name
    $versionString = $pkgValidationDetails.Version

    $parsedNewVersion = [AzureEngSemanticVersion]::new($versionString)
    $versionMajorMinor = "" + $parsedNewVersion.Major + "." + $parsedNewVersion.Minor
    $workItem = FindPackageWorkItem -lang $LanguageDisplayName -packageName $pkgName -version $versionMajorMinor -includeClosed $true -outputCommand $false

    if (!$workItem)
    {
        Write-Host"No work item found for package [$pkgName]."
        return $false
    }

    $changeLogStatus = $pkgValidationDetails.ChangeLogValidation.Status
    $changeLogDetails  = $pkgValidationDetails.ChangeLogValidation.Message
    $apiReviewStatus = $pkgValidationDetails.APIReviewValidation.Status
    $apiReviewDetails = $pkgValidationDetails.APIReviewValidation.Message
    $packageNameStatus = $pkgValidationDetails.PackageNameValidation.Status
    $packageNameDetails = $pkgValidationDetails.PackageNameValidation.Message

    $fields = @()
    $fields += "`"PackageVersion=${versionString}`""
    $fields += "`"ChangeLogStatus=${changeLogStatus}`""
    $fields += "`"ChangeLogValidationDetails=${changeLogDetails}`""
    $fields += "`"APIReviewStatus=${apiReviewStatus}`""
    $fields += "`"APIReviewStatusDetails=${apiReviewDetails}`""
    $fields += "`"PackageNameApprovalStatus=${packageNameStatus}`""
    $fields += "`"PackageNameApprovalDetails=${packageNameDetails}`""
    if ($BuildDefinition) {
        $fields += "`"PipelineDefinition=$BuildDefinition`""
    }
    if ($PipelineUrl) {
        $fields += "`"LatestPipelineRun=$PipelineUrl`""
    }

    $workItem = UpdateWorkItem -id $workItem.id -fields $fields
    Write-Host "[$($workItem.id)]$LanguageDisplayName - $pkgName($versionMajorMinor) - Updated"
    return $true
}

# Read package property file and identify all packages to process
Write-Host "Processing package: $PackageName"
$packagePropertyFile = Join-Path $ConfigFileDir "$PackageName.json"
$pkgInfo = Get-Content $packagePropertyFile | ConvertFrom-Json

$changeLogPath = $pkgInfo.ChangeLogPath
$versionString = $pkgInfo.Version
Write-Host "Checking if we need to create or update work item for package $packageName with version $versionString."
$isShipped = IsVersionShipped $packageName $versionString
if ($isShipped) {
    Write-Host "Package work item already exists for version [$versionString] that is marked as shipped. Skipping the update of package work item."
    exit 1
}

Write-Host "Validating package $packageName with version $versionString."

# Change log validation
$changelogStatus = ValidateChangeLog $changeLogPath $versionString

# API review and package name validation
$apireviewDetails = VerifyAPIReview $PackageName $pkgInfo.Version $LanguageDisplayName

$pkgValidationDetails= [PSCustomObject]@{
    Name = $PackageName
    Version = $pkgInfo.Version
    ChangeLogValidation = $changelogStatus
    APIReviewValidation = $apireviewDetails.ApiviewApproval
    PackageNameValidation = $apireviewDetails.PackageNameApproval
}

$output = ConvertTo-Json $pkgValidationDetails
Write-Host "Output: $($output)"

# Create json token file in artifact path
$tokenFile = Join-Path $ArtifactPath "$PackageName-Validation.json"
$output | Out-File -FilePath $tokenFile -Encoding utf8

# Create DevOps work item
$updatedWi = CreateUpdatePackageWorkItem $pkgInfo

# Update validation status in package work item
if ($updatedWi) {
    Write-Host "Updating validation status in package work item."
    $updatedWi = UpdateValidationStatus $pkgValidationDetails        
}
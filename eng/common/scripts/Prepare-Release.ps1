#Requires -Version 6.0

<#
.SYNOPSIS
This script will do the necessary book keeping work needed to release a package.

.DESCRIPTION
This script will do a number of things when ran:

- It will read the current version from the project and will have you confirm if that is the version you want to ship
- It will take the package metadata and version and update the DevOps release tracking items with that information.
  - If there is existing release work item it will update it and if not it will create one.
- It will validate that the changelog has a entry for the package version that you want to release as well as a timestamp.

For more information see https://aka.ms/azsdk/mark-release-status.

.PARAMETER PackageName
The full package name of the package you want to prepare for release. (i.e Azure.Core, azure-core, @azure/core-https)

.PARAMETER ServiceDirectory
Optional: Provide a service directory to scope the search of the entire repo to speed-up the project search. This should be the directory
name under the 'sdk' folder (i.e for the core package which lives under 'sdk\core' the value to pass would be 'core').

.PARAMETER ReleaseDate
Optional: Provide a specific date for when you plan to release the package. Should be the date (MM/dd/yyyy) that the given package is going to ship.
If one isn't provided, then it will compute the next ship date or today's date if past the ship date for the month as the planned date.

.PARAMETER ReleaseTrackingOnly
Optional: If this switch is passed then the script will only update the release work items and not update the versions in the local repo or validate the changelog.

.EXAMPLE
PS> ./eng/common/scripts/Prepare-Release.ps1 <PackageName>

The most common usage is to call the script passing the package name. Once the script is finished then you will have modified project and change log files.
You should make any additional changes to the change log to capture the changes and then submit the PR for the final changes before you do a release.

.EXAMPLE
PS> ./eng/common/scripts/Prepare-Release.ps1 <PackageName> -ReleaseTrackingOnly

If you aren't ready to do the final versioning changes yet but you want to update release tracking information for shiproom pass in the -ReleaseTrackingOnly.
option. This should not modify or validate anything in the repo but will update the DevOps release tracking items. Once you are ready for the verioning changes
as well then come back and run the full script again without the -ReleaseTrackingOnly option and give it the same version information you did the first time.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string]$PackageName,
  [string]$ServiceDirectory,
  [string]$ReleaseDate, # Pass Date in the form MM/dd/yyyy"
  [switch]$ReleaseTrackingOnly = $false
)
Set-StrictMode -Version 3

. ${PSScriptRoot}\common.ps1
. ${PSScriptRoot}\Helpers\ApiView-Helpers.ps1

function Get-ReleaseDay($baseDate)
{
  # Find first friday
  while ($baseDate.DayOfWeek -ne 5)
  {
    $baseDate = $baseDate.AddDays(1)
  }

  # Go to Tuesday
  $baseDate = $baseDate.AddDays(4)

  return $baseDate;
}

$ErrorPreference = 'Stop'

$packageProperties = $null
$packageProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory

if (!$packageProperties)
{
  Write-Error "Could not find a package with name [ $packageName ], please verify the package name matches the exact name."
  exit 1
}

Write-Host "Package Name [ $($packageProperties.Name) ]"
Write-Host "Source directory [ $($packageProperties.ServiceDirectory) ]"

if (!$ReleaseDate)
{
  $currentDate = Get-Date
  $thisMonthReleaseDate = Get-ReleaseDay((Get-Date -Day 1));
  $nextMonthReleaseDate = Get-ReleaseDay((Get-Date -Day 1).AddMonths(1));

  if ($thisMonthReleaseDate -ge $currentDate)
  {
    # On track for this month release
    $ParsedReleaseDate = $thisMonthReleaseDate
  }
  elseif ($currentDate.Day -lt 15)
  {
    # Catching up to this month release
    $ParsedReleaseDate = $currentDate
  }
  else
  {
    # Next month release
    $ParsedReleaseDate = $nextMonthReleaseDate
  }
}
else
{
  $ParsedReleaseDate = [datetime]$ReleaseDate
}

$releaseDateString = $ParsedReleaseDate.ToString("MM/dd/yyyy")
$month = $ParsedReleaseDate.ToString("MMMM")

Write-Host "Assuming release is in $month with release date $releaseDateString" -ForegroundColor Green
if (Test-Path "Function:GetExistingPackageVersions")
{
    $releasedVersions = GetExistingPackageVersions -PackageName $packageProperties.Name -GroupId $packageProperties.Group
    if ($null -ne $releasedVersions -and $releasedVersions.Count -gt 0)
    {
      $latestReleasedVersion = $releasedVersions[$releasedVersions.Count - 1]
      Write-Host "Latest released version: ${latestReleasedVersion}" -ForegroundColor Green
    }
}

$currentProjectVersion = $packageProperties.Version
$newVersion = Read-Host -Prompt "Input the new version, or press Enter to use use current project version '$currentProjectVersion'"

if (!$newVersion)
{
  $newVersion = $currentProjectVersion;
}

$newVersionParsed = [AzureEngSemanticVersion]::ParseVersionString($newVersion)
if ($null -eq $newVersionParsed)
{
  Write-Error "Invalid version $newVersion. Version must follow standard SemVer rules, see https://aka.ms/azsdk/engsys/packageversioning"
  exit 1
}

&$EngCommonScriptsDir/Update-DevOps-Release-WorkItem.ps1 `
  -language $LanguageDisplayName `
  -packageName $packageProperties.Name `
  -version $newVersion `
  -plannedDate $releaseDateString `
  -packageRepoPath $packageProperties.serviceDirectory `
  -packageType $packageProperties.SDKType `
  -packageNewLibrary $packageProperties.IsNewSDK

if ($LASTEXITCODE -ne 0) {
  Write-Error "Updating of the Devops Release WorkItem failed."
  exit 1
}

# Check API status if version is GA
if (!$newVersionParsed.IsPrerelease)
{
  try
  {
    az account show *> $null
    if (!$?) {
      Write-Host 'Running az login...'
      az login *> $null
    }
    $url = az keyvault secret show --name "APIURL" --vault-name "AzureSDKPrepRelease-KV" --query "value" --output "tsv"
    $apiKey = az keyvault secret show --name "APIKEY" --vault-name "AzureSDKPrepRelease-KV" --query "value" --output "tsv"
    Check-ApiReviewStatus -PackageName $packageProperties.Name -packageVersion $newVersion -Language $LanguageDisplayName -url $url -apiKey $apiKey
  }
  catch
  {
    Write-Warning "Failed to get APIView URL and API Key from Keyvault AzureSDKPrepRelease-KV. Please check and ensure you have access to this Keyvault as reader."
  }
}

if ($releaseTrackingOnly)
{
  Write-Host
  Write-Host "Script is running in release tracking only mode so only updating the release tracker and not updating versions locally."
  Write-Host "You will need to run this script again once you are ready to update the versions to ensure the projects and changelogs contain the correct version."

  exit 0
}

if (Test-Path "Function:SetPackageVersion")
{
  $replaceLatestEntryTitle = $true
  $latestVersion = Get-LatestReleaseDateFromChangeLog -ChangeLogLocation $packageProperties.ChangeLogPath
  if ($latestVersion)
  {
    $promptMessage = "The latest entry in the CHANGELOG.md already has a release date. Do you want to replace the latest entry title? Please enter (y or n)."
    while (($readInput = Read-Host -Prompt $promptMessage) -notmatch '^[yn]$'){ }
    $replaceLatestEntryTitle = ($readInput -eq "y")
  }
  SetPackageVersion -PackageName $packageProperties.Name -Version $newVersion `
    -ServiceDirectory $packageProperties.ServiceDirectory -ReleaseDate $releaseDateString `
    -PackageProperties $packageProperties -ReplaceLatestEntryTitle $replaceLatestEntryTitle
}
else
{
  LogError "The function 'SetPackageVersion' was not found.`
    Make sure it is present in eng/scripts/Language-Settings.ps1.`
    See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
  exit 1
}

$changelogIsValid = Confirm-ChangeLogEntry -ChangeLogLocation $packageProperties.ChangeLogPath -VersionString $newVersion -ForRelease $true -SantizeEntry

if (!$changelogIsValid)
{
  Write-Warning "The changelog [$($packageProperties.ChangeLogPath)] is not valid for release. Please make sure it is valid before queuing release build."
}

git diff -s --exit-code $packageProperties.DirectoryPath
if ($LASTEXITCODE -ne 0)
{
  git status
  Write-Host "Some changes were made to the repo source" -ForegroundColor Green
  Write-Host "Submit a pull request with the necessary changes to the repo, including any final changelog entry updates." -ForegroundColor Green
}

#Requires -Version 6.0

[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)]
    [string]$PackageName,
    [string]$ServiceDirectory,
    [string]$ReleaseDate, # Pass Date in the form MM/dd/yyyy"
    [string]$BuildType # For Java
)

. ${PSScriptRoot}\common.ps1

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

$packageProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $serviceDirectory

Write-Host "Source directory [ $serviceDirectory ]"

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
    $ParsedReleaseDate = ([datetime]$ReleaseDate, 'MM/dd/yyyy', [Globalization.CultureInfo]::InvariantCulture)
}

$releaseDateString = $ParsedReleaseDate.ToString("MM/dd/yyyy")
$month = $ParsedReleaseDate.ToString("MMMM")

Write-Host
Write-Host "Assuming release is in $month with release date $releaseDateString" -ForegroundColor Green

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

if (Test-Path "Function:SetPackageVersion")
{
    SetPackageVersion -PackageName $packageProperties.Name -Version $newVersion -ServiceDirectory $serviceDirectory -ReleaseDate $releaseDateString `
    -BuildType $BuildType -GroupId $packageProperties.Group
}
else
{
    LogError "The function 'SetPackageVersion' was not found.`
    Make sure it is present in eng/scripts/Language-Settings.ps1.`
    See https://github.com/Azure/azure-sdk-tools/blob/master/doc/common/common_engsys.md#code-structure"
    exit 1
}

&$EngCommonScriptsDir/Update-DevOps-Release-WorkItem.ps1 `
-language $LanguageDisplayName `
-packageName $packageProperties.Name `
-version $newVersion `
-plannedDate $releaseDateString `
-packageRepoPath $packageProperties.serviceDirectory

git diff -s --exit-code $packageProperties.DirectoryPath
if ($LASTEXITCODE -ne 0)
{
    git status
    Write-Host "Some changes were made to the repo source" -ForegroundColor Green
    Write-Host "Submit a pull request with the necessary changes to the repo" -ForegroundColor Green
}
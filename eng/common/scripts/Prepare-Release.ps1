#Requires -Version 6.0

[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)]
    [string]$packageName,
    [string]$serviceDirectoryName,
    [string]$ReleaseDate,
    [string]$BuildType # For Java
)

. ${PSScriptRoot}\common.ps1

function Get-LevenshteinDistance {
    <#
        .SYNOPSIS
            Get the Levenshtein distance between two strings.
        .DESCRIPTION
            The Levenshtein Distance is a way of quantifying how dissimilar two strings (e.g., words) are to one another by counting the minimum number of operations required to transform one string into the other.
        .EXAMPLE
            Get-LevenshteinDistance 'kitten' 'sitting'
        .LINK
            http://en.wikibooks.org/wiki/Algorithm_Implementation/Strings/Levenshtein_distance#C.23
            http://en.wikipedia.org/wiki/Edit_distance
            https://communary.wordpress.com/
            https://github.com/gravejester/Communary.PASM
        .NOTES
            Author: Ã˜yvind Kallstad
            Date: 07.11.2014
            Version: 1.0
    #>
    [CmdletBinding()]
    param(
        [Parameter(Position = 0)]
        [string]$String1,

        [Parameter(Position = 1)]
        [string]$String2,

        # Makes matches case-sensitive. By default, matches are not case-sensitive.
        [Parameter()]
        [switch] $CaseSensitive,

        # A normalized output will fall in the range 0 (perfect match) to 1 (no match).
        [Parameter()]
        [switch] $NormalizeOutput
    )

    if (-not($CaseSensitive)) {
        $String1 = $String1.ToLowerInvariant()
        $String2 = $String2.ToLowerInvariant()
    }

    $d = New-Object 'Int[,]' ($String1.Length + 1), ($String2.Length + 1)
    for ($i = 0; $i -le $d.GetUpperBound(0); $i++) {
        $d[$i,0] = $i
    }

    for ($i = 0; $i -le $d.GetUpperBound(1); $i++) {
        $d[0,$i] = $i
    }

    for ($i = 1; $i -le $d.GetUpperBound(0); $i++) {
        for ($j = 1; $j -le $d.GetUpperBound(1); $j++) {
            $cost = [Convert]::ToInt32((-not($String1[$i-1] -ceq $String2[$j-1])))
            $min1 = $d[($i-1),$j] + 1
            $min2 = $d[$i,($j-1)] + 1
            $min3 = $d[($i-1),($j-1)] + $cost
            $d[$i,$j] = [Math]::Min([Math]::Min($min1,$min2),$min3)
        }
    }

    $distance = ($d[$d.GetUpperBound(0),$d.GetUpperBound(1)])

    if ($NormalizeOutput) {
        return (1 - ($distance) / ([Math]::Max($String1.Length,$String2.Length)))
    }

    else {
        return $distance
    }
}

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
$repoRoot = Resolve-Path "$PSScriptRoot/../..";
$commonParameter = @("--organization", "https://dev.azure.com/azure-sdk", "-o", "json", "--only-show-errors")

if (!(Get-Command az)) {
  throw 'You must have the Azure CLI installed: https://aka.ms/azure-cli'
}

az extension show -n azure-devops > $null

if (!$?){
  throw 'You must have the azure-devops extension run `az extension add --name azure-devops`'
}

$packageProperties = Get-PkgProperties -PackageName $packageName -ServiceDirectory $serviceDirectoryName

Write-Host "Source directory $serviceDirectoryName"

if ($GetExistingPackageVersions -and (Test-Path "Function:$GetExistingPackageVersions"))
{
    $existing = &$GetExistingPackageVersions -PackageName $packageProperties.Name -GroupId $packageProperties.Group
    if ($null -eq $existing) { $existing = @() }
}
else
{
    LogError "The function '$GetExistingPackageVersions' was not found."
}

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
    $ParsedReleaseDate = [datetime]::ParseExact($ReleaseDate, 'yyyy-MM-dd', [Globalization.CultureInfo]::InvariantCulture)
}

$releaseDateString = $ParsedReleaseDate.ToString("yyyy-MM-dd")
$month = $ParsedReleaseDate.ToString("MMMM")

Write-Host
Write-Host "Assuming release is in $month with release date $releaseDateString" -ForegroundColor Green

$isNew = "True";
$libraryType = "Beta";
$latestVersion = $null;
foreach ($existingVersion in $existing)
{
    $isNew = "False"
    $parsedVersion = [AzureEngSemanticVersion]::new($existingVersion)
    if (!$parsedVersion.IsPrerelease)
    {
        $libraryType = "GA"
    }

    $latestVersion = $existingVersion;
}

$currentProjectVersion = $packageProperties.Version

if ($latestVersion)
{
    Write-Host
    Write-Host "Latest released version $latestVersion, library type $libraryType" -ForegroundColor Green
}
else
{
    Write-Host
    Write-Host "No released version, library type $libraryType" -ForegroundColor Green
}

$newVersion = Read-Host -Prompt "Input the new version, NA if you are not releasing, or press Enter to use use current project version '$currentProjectVersion'"
$releasing = $true

if (!$newVersion)
{
    $newVersion = $currentProjectVersion;
}

if ($newVersion -eq "NA")
{
    $releasing = $false
}

if ($releasing)
{
    if ($latestVersion)
    {
        $releaseType = "None";
        $parsedNewVersion = [AzureEngSemanticVersion]::new($newVersion)
        if ($parsedNewVersion.Major -ne $parsedVersion.Major)
        {
            $releaseType = "Major"
        }
        elseif ($parsedNewVersion.Minor -ne $parsedVersion.Minor)
        {
            $releaseType = "Minor"
        }
        elseif ($parsedNewVersion.Patch -ne $parsedVersion.Patch)
        {
            $releaseType = "Patch"
        }
        elseif ($parsedNewVersion.IsPrerelease)
        {
            $releaseType = "Patch"
        }
    }
    else
    {
        $releaseType = "Major";
    }

    Write-Host
    Write-Host "Detected released type $releaseType" -ForegroundColor Green

    Write-Host
    Write-Host "Updating versions to $newVersion with date $releaseDateString" -ForegroundColor Green

    SetPackageVersion -PackageName $package -Version $newVersion -ServiceName $serviceDirectory -ReleaseDate $releaseDateString `
    -BuildType $BuildType $GroupName $packageProperties.Group

    $fields = @{
        "Permalink usetag"="https://github.com/Azure/azure-sdk-for-net/sdk/$serviceDirectory/$package/README.md"
        "Package Registry Permalink"="https://nuget.org/packages/$package/$newVersion"
        "Library Type"=$libraryType
        "Release Type"=$releaseType
        "Version Number"=$newVersion
        "Planned Release Date"=$releaseDateString
        "New Library Only"=$isNew
    }
    $state = "Active"
}
else
{
    $fields = @{}
    $state = "Not In Release"
}

$workItems = az boards query @commonParameter --project Release --wiql "SELECT [ID], [State], [Iteration Path], [Title] FROM WorkItems WHERE [State] <> 'Closed' AND [Iteration Path] under 'Release\2020\$month' AND [Title] contains '.NET'" | ConvertFrom-Json;

Write-Host
Write-Host "The following work items exist:"
foreach ($item in $workItems)
{
    $id = $item.fields."System.ID";
    $title = $item.fields."System.Title";
    $path = $item.fields."System.IterationPath";
    Write-Host "$id - $path - $title"
}

# Sort using fuzzy match
$workItems = $workItems | Sort-Object -property @{Expression = { Get-LevenshteinDistance $_.fields."System.Title" $package -NormalizeOutput }}
$mostProbable = $workItems | Select-Object -Last 1

$issueId = Read-Host -Prompt "Input the work item ID or press Enter to use '$($mostProbable.fields."System.ID") - $($mostProbable.fields."System.Title")' (fuzzy matched based on title)"

if (!$issueId)
{
    $issueId = $mostProbable.fields."System.ID"
}

Write-Host
Write-Host "Going to set the following fields:" -ForegroundColor Green
Write-Host "    State = $state"

foreach ($field in $fields.Keys)
{
    Write-Host "    $field = $($fields[$field])"
}

$decision = $Host.UI.PromptForChoice("Updating work item https://dev.azure.com/azure-sdk/Release/_workitems/edit/$issueId", 'Are you sure you want to proceed?', @('&Yes'; '&No'), 0)

if ($decision -eq 0)
{
    az boards work-item update @commonParameter --id $issueId --state $state > $null
    foreach ($field in $fields.Keys)
    {
        az boards work-item update @commonParameter --id $issueId -f "$field=$($fields[$field])" > $null
    }
}

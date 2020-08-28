param($package)

$repoRoot = Resolve-Path "$PSScriptRoot/../..";

$serviceDirectory = (Get-ChildItem "$repoRoot/sdk" -Directory -Recurse -Depth 2 -Filter $package).Parent.Name

Write-Host "Source directory $serviceDirectory"

$existing = Invoke-WebRequest "https://api.nuget.org/v3-flatcontainer/$($package.ToLower())/index.json" | ConvertFrom-Json;

. ${repoRoot}\eng\common\scripts\SemVer.ps1

$libraryType = "preview";
$latestVersion = "unknown";
foreach ($existingVersion in $existing.versions)
{
    $parsedVersion = [AzureEngSemanticVersion]::new($existingVersion)
    if (!$packageOldSemVer.IsPrerelease)
    {
        $libraryType = "GA"
    }
    $latestVersion = $existingVersion;
}

$latestVersion = $existing.versions[$existing.versions.Count - 1];

Write-Host "Latest released version $latestVersion, library type $libraryType"

$newVersion = Read-Host -Prompt 'Input the new version' 

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
    $releaseType = "Bugfix"
}
elseif ($parsedNewVersion.IsPrerelease)
{
    $releaseType = "Bugfix"
}

Write-Host "Detected released type $releaseType"

& "$repoRoot\eng\scripts\Update-PkgVersion.ps1" -ServiceDirectory $serviceDirectory -PackageName $package -NewVersionString $newVersion

$date = Get-Date
$month = $date.ToString("MMMM")
if ($date.Day -gt 15)
{
    $month = $date.AddMonths(1).ToString("MMMM")
}

Write-Host "Assuming release is in $month"

$commonParameter = @("--organization", "https://dev.azure.com/azure-sdk", "-o", "json", "--only-show-errors")

$workItems = az boards query @commonParameter --project Release --wiql "SELECT [ID], [State], [Iteration Path], [Title] FROM WorkItems WHERE [State] <> 'Closed' AND [Iteration Path] under 'Release\2020\$month' AND [Title] contains '.NET'" | ConvertFrom-Json;

$matchedWorkItems = @();

Write-Host "The following issues exist:"
foreach ($item in $workItems)
{
    $id = $item.fields."System.ID";
    $title = $item.fields."System.Title";
    $path = $item.fields."System.IterationPath";
    Write-Host "$id - $path - $title" 
}

$issueId = Read-Host -Prompt 'Input the issue ID'

$fields = @{
    "Permalink usetag"="https://github.com/Azure/azure-sdk-for-net/sdk/$serviceDirectory/$package/README.md";
    "Package Registry Permalink"="https://nuget.org/packages/$package/$newVersion";
    "Library Type"=$libraryType;
    "Release Type"=$releaseType;
    "Version Number"=$newVersion;
}

Write-Host "Going to set the following fields:"

foreach ($field in $fields.Keys)
{
    Write-Host "    $field $($fields[$field])"
}

$decision = $Host.UI.PromptForChoice('Updating work item', 'Are you sure you want to proceed?', @('&Yes'; '&No'), 0)

if ($decision -eq 0)
{
    foreach ($field in $fields.Keys)
    {
        az boards work-item update @commonParameter --id $issueId -f "$field=$($fields[$field])" > $null
    }

    Write-Host "Updated https://dev.azure.com/azure-sdk/Release/_workitems/edit/$issueId"
}
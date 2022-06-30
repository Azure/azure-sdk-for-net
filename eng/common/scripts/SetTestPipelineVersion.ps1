# Sets a valid version for a package using the buildID

param (
  [Parameter(mandatory = $true)]
  $BuildID,
  [Parameter(mandatory = $true)]
  $PackageName,
  [Parameter(mandatory = $true)]
  $ServiceDirectory
)

. (Join-Path $PSScriptRoot common.ps1)

Write-Host "PackageName: $PackageName"
Write-Host "ServiceDirectory: $ServiceDirectory"
Write-Host "BuildID: $BuildID"

$newVersion = [AzureEngSemanticVersion]::new("1.0.0")
$latestTags = git tag -l "${PackageName}_*"

Write-Host "Get Latest Tag : git tag -l ${PackageName}_*"
$semVars = @()

if ($latestTags -and ($latestTags.Length -gt 0))
{
  foreach ($tags in $latestTags)
  {
    $semVars += $tags.Replace("${PackageName}_", "")
  }

  $semVarsSorted = [AzureEngSemanticVersion]::SortVersionStrings($semVars)
  Write-Host "Last Published Version $($semVarsSorted[0])"
  $newVersion = [AzureEngSemanticVersion]::new($semVarsSorted[0])
}

$newVersion.PrereleaseLabel = $newVersion.DefaultPrereleaseLabel
$newVersion.PrereleaseNumber = $BuildID
$newVersion.IsPrerelease = $True

Write-Host "Version to publish [ $($newVersion.ToString()) ]"

SetPackageVersion -PackageName $PackageName `
  -Version $newVersion.ToString() `
  -ServiceDirectory $ServiceDirectory
# Sets a valid version for a package using the buildID

param (
  [Parameter(mandatory = $true)]
  $BuildID,
  [Parameter(mandatory = $true)]
  $PackagName,
  [Parameter(mandatory = $true)]
  $ServiceDirectory
)

. common.ps1

$latestTags = git tag -l "${PackageName}_*"
$semVars = @()

Foreach ($tags in $latestTags)
{
  $semVars += $tags.Replace("${PackageName}_", "")
}

$semVarsSorted = [AzureEngSemanticVersion]::SortVersionStrings($semVars)
LogDebug "Last Published Version $($semVarsSorted[0])"

$newVersion = [AzureEngSemanticVersion]::new($semVarsSorted[0])
$newVersion.PrereleaseLabel = $newVersion.DefaultPrereleaseLabel
$newVersion.PrereleaseNumber = $BuildID

LogDebug "Version to publish [ $($newVersion.ToString()) ]"

SetPackageVersion -PackageName $PackagName `
  -Version $newVersion `
  -ServiceDirectory $ServiceDirectory `

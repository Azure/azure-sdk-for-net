# Sets a valid version for a package using the buildID

param (
  [Parameter(mandatory = $true)]
  [string]$BuildID,
  [Parameter(mandatory = $true)]
  [string]$PackageNames,
  [Parameter(mandatory = $true)]
  [string]$ServiceDirectory
)

. (Join-Path $PSScriptRoot common.ps1)

Write-Host "PackageNames: $PackageNames"
Write-Host "ServiceDirectory: $ServiceDirectory"
Write-Host "BuildID: $BuildID"

$packageNamesArray = @()

if ([String]::IsNullOrWhiteSpace($PackageNames)) {
  LogError "PackageNames cannot be empty."
  exit 1
} else {
  $packageNamesArray = $PackageNames.Split(',')
}

foreach ($packageName in $packageNamesArray) {
  Write-Host "Processing $packageName"
  $newVersion = [AzureEngSemanticVersion]::new("1.0.0")
  $latestTags = git tag -l "${packageName}_*"

  Write-Host "Get Latest Tag : git tag -l ${packageName}_*"
  $semVars = @()

  if ($latestTags -and ($latestTags.Length -gt 0))
  {
    foreach ($tags in $latestTags)
    {
      $semVars += $tags.Replace("${packageName}_", "")
    }

    $semVarsSorted = [AzureEngSemanticVersion]::SortVersionStrings($semVars)
    Write-Host "Last Published Version $($semVarsSorted[0])"
    $newVersion = [AzureEngSemanticVersion]::new($semVarsSorted[0])
  }

  $newVersion.PrereleaseLabel = $newVersion.DefaultPrereleaseLabel
  $newVersion.PrereleaseNumber = $BuildID
  $newVersion.IsPrerelease = $True

  Write-Host "Version to publish [ $($newVersion.ToString()) ]"

  SetPackageVersion -PackageName $packageName `
    -Version $newVersion.ToString() `
    -ServiceDirectory $ServiceDirectory
}
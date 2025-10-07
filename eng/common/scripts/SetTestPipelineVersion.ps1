# Sets a valid version for a package using the buildID

param (
  [Parameter(mandatory = $true)]
  [string]$BuildID,
  [Parameter(mandatory = $false)]
  [string]$PackageNames = "",
  [Parameter(mandatory = $true)]
  [string]$ServiceDirectory,
  [Parameter(mandatory = $false)]
  [string]$TagSeparator = "_",
  [Parameter(mandatory = $false)]
  [string]$ArtifactsJson = ""
)

. (Join-Path $PSScriptRoot common.ps1)

Write-Host "PackageNames: $PackageNames"
Write-Host "ServiceDirectory: $ServiceDirectory"
Write-Host "BuildID: $BuildID"
Write-Host "ArtifactsJson: $ArtifactsJson"

$packageNamesArray = @()

# If ArtifactsJson is provided, extract package names from it
if (![String]::IsNullOrWhiteSpace($ArtifactsJson)) {
  Write-Host "Using ArtifactsJson to determine package names"
  try {
    $artifacts = $ArtifactsJson | ConvertFrom-Json
    $packageNamesArray = $artifacts | ForEach-Object { $_.name }
    Write-Host "Extracted package names from ArtifactsJson: $($packageNamesArray -join ', ')"
  }
  catch {
    LogError "Failed to parse ArtifactsJson: $($_.Exception.Message)"
    exit 1
  }
}
elseif (![String]::IsNullOrWhiteSpace($PackageNames)) {
  $packageNamesArray = $PackageNames.Split(',')
}
else {
  LogError "Either PackageNames or ArtifactsJson must be provided."
  exit 1
}

# Process packages with appropriate groupId
if (![String]::IsNullOrWhiteSpace($ArtifactsJson)) {
  # When using ArtifactsJson, process each artifact with its specific groupId
  try {
    $artifacts = $ArtifactsJson | ConvertFrom-Json
    foreach ($artifact in $artifacts) {
      $packageName = $artifact.name
      $groupId = $artifact.groupId

      Write-Host "Processing $packageName with groupId $groupId"
      $newVersion = [AzureEngSemanticVersion]::new("1.0.0")
      # Use groupId+artifactName format for tag prefix (e.g., "com.azure.v2+azure-sdk-template_")
      $prefix = "$groupId+$packageName$TagSeparator"
      Write-Host "Get Latest Tag : git tag -l $prefix*"
      $latestTags = git tag -l "$prefix*"

      $semVars = @()

      if ($latestTags -and ($latestTags.Length -gt 0)) {
        foreach ($tag in $latestTags) {
          $semVars += $tag.Substring($prefix.Length)
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
        -ServiceDirectory $ServiceDirectory `
        -GroupId $groupId
    }
  }
  catch {
    LogError "Failed to process ArtifactsJson: $($_.Exception.Message)"
    exit 1
  }
} else {
  # Fallback to original logic when using PackageNames string
  foreach ($packageName in $packageNamesArray) {
    Write-Host "Processing $packageName"
    $newVersion = [AzureEngSemanticVersion]::new("1.0.0")
    # For legacy PackageNames, assume com.azure groupId for backward compatibility
    $prefix = "com.azure+$packageName$TagSeparator"
    Write-Host "Get Latest Tag : git tag -l $prefix*"
    $latestTags = git tag -l "$prefix*"

    $semVars = @()

    if ($latestTags -and ($latestTags.Length -gt 0)) {
      foreach ($tag in $latestTags) {
        $semVars += $tag.Substring($prefix.Length)
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
}

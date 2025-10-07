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
$artifacts = $null

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

if ($artifacts) {
  # When using ArtifactsJson, process each artifact with its name and groupId (if applicable)
  try {
    foreach ($artifact in $artifacts) {
      $packageName = $artifact.name      
      $newVersion = [AzureEngSemanticVersion]::new("1.0.0")
      $prefix = "$packageName$TagSeparator"

      if ($Language -eq "java") {
        $groupId = $artifact.groupId
        Write-Host "Processing $packageName with groupId $groupId"
        if ([String]::IsNullOrWhiteSpace($groupId)) {
          LogError "GroupId is missing for package $packageName."
          exit 1
        }
        # Use groupId+artifactName format for tag prefix (e.g., "com.azure.v2+azure-sdk-template_")
        $prefix = "$groupId+$packageName$TagSeparator"
      }

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

      if ($Language -ne "java") {
        SetPackageVersion -PackageName $packageName `
          -Version $newVersion.ToString() `
          -ServiceDirectory $ServiceDirectory
      } else {
        SetPackageVersion -PackageName $packageName `
          -Version $newVersion.ToString() `
          -ServiceDirectory $ServiceDirectory `
          -GroupId $groupId
      }
    }
  }
  catch {
    LogError "Failed to process ArtifactsJson: $ArtifactsJson, exception: $($_.Exception.Message)"
    exit 1
  }
} else {
  # Fallback to original logic when using PackageNames string
  foreach ($packageName in $packageNamesArray) {
    Write-Host "Processing $packageName"
    $newVersion = [AzureEngSemanticVersion]::new("1.0.0")
    $prefix = "$packageName$TagSeparator"
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

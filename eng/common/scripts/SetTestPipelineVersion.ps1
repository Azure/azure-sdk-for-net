# Sets a valid version for a package using the buildID

param (
  [Parameter(mandatory = $true)]
  [string]$BuildID,
  [Parameter(mandatory = $false)]
  [string]$PackageNames = "",
  [Parameter(mandatory = $false)]
  [string]$ServiceDirectory,
  [Parameter(mandatory = $false)]
  [string]$TagSeparator = "_",
  [Parameter(mandatory = $false)]
  [object[]]$Artifacts = @()
)

. (Join-Path $PSScriptRoot common.ps1)

# Ensure Artifacts is always an array
$Artifacts = @($Artifacts)

Write-Host "PackageNames: $PackageNames"
Write-Host "ServiceDirectory: $ServiceDirectory"
Write-Host "BuildID: $BuildID"
Write-Host "Artifacts count: $($Artifacts.Count)"

if ($Artifacts -and $Artifacts.Count -gt 0) {
  # When using Artifacts, process each artifact with its name and groupId (if applicable)
  try {
    foreach ($artifact in $Artifacts) {
      # Validate required properties
      if (-not (Get-Member -InputObject $artifact -Name 'name' -MemberType Properties)) {
        LogError "Artifact is missing required 'name' property."
        exit 1
      }
      
      $packageName = $artifact.name
      if ([String]::IsNullOrWhiteSpace($packageName)) {
        LogError "Artifact 'name' property is null or empty."
        exit 1
      }

      # Check for ServiceDirectory property      
      if (Get-Member -InputObject $artifact -Name 'ServiceDirectory' -MemberType Properties) {
        if (![String]::IsNullOrWhiteSpace($artifact.ServiceDirectory)) {
          $artifactServiceDirectory = $artifact.ServiceDirectory
        }
      }

      if ([String]::IsNullOrWhiteSpace($artifactServiceDirectory)) {
        $artifactServiceDirectory = $ServiceDirectory
      }
      
      # Validate ServiceDirectory is available
      if ([String]::IsNullOrWhiteSpace($artifactServiceDirectory)) {
        LogError "ServiceDirectory is required but not provided for artifact '$packageName'. Provide it via script parameter or artifact property."
        exit 1
      }

      $newVersion = [AzureEngSemanticVersion]::new("1.0.0")
      $prefix = "$packageName$TagSeparator"

      if ($Language -eq "java") {
        # Check for groupId property
        if (-not (Get-Member -InputObject $artifact -Name 'groupId' -MemberType Properties)) {
          LogError "Artifact '$packageName' is missing required 'groupId' property for Java language."
          exit 1
        }
        
        $groupId = $artifact.groupId
        if ([String]::IsNullOrWhiteSpace($groupId)) {
          LogError "GroupId is missing for package $packageName."
          exit 1
        }
        
        Write-Host "Processing $packageName with groupId $groupId"
        # Use groupId+artifactName format for tag prefix (e.g., "com.azure.v2+azure-sdk-template_")
        $prefix = "$groupId+$packageName$TagSeparator"
      }
      else {
        Write-Host "Processing $packageName"
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
          -ServiceDirectory $artifactServiceDirectory
      } else {
        SetPackageVersion -PackageName $packageName `
          -Version $newVersion.ToString() `
          -ServiceDirectory $artifactServiceDirectory `
          -GroupId $groupId
      }
    }
  }
  catch {
    LogError "Failed to process Artifacts: exception: $($_.Exception.Message)"
    exit 1
  }
} elseif (![String]::IsNullOrWhiteSpace($PackageNames)) {
  # Fallback to original logic when using PackageNames string
  if ([String]::IsNullOrWhiteSpace($ServiceDirectory)) {
    LogError "ServiceDirectory is required when using PackageNames."
    exit 1
  }
  $packageNamesArray = $PackageNames.Split(',')
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
} else {
  LogError "Either PackageNames or Artifacts must be provided."
  exit 1
}

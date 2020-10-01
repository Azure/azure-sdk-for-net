<#
.DESCRIPTION
Parses a semver version string into its components and supports operations around it that we use for versioning our packages.

See https://azure.github.io/azure-sdk/policies_releases.html#package-versioning

Example: 1.2.3-beta.4
Components: Major.Minor.Patch-PrereleaseLabel.PrereleaseNumber

Note: A builtin Powershell version of SemVer exists in 'System.Management.Automation'. At this time, it does not parsing of PrereleaseNumber. It's name is also type accelerated to 'SemVer'.
#>

class AzureEngSemanticVersion {
  [int] $Major
  [int] $Minor
  [int] $Patch
  [string] $PrereleaseLabelSeparator
  [string] $PrereleaseLabel
  [string] $PrereleaseNumberSeparator
  [int] $PrereleaseNumber
  [bool] $IsPrerelease
  [string] $RawVersion
  [bool] $IsSemVerFormat
  [string] $DefaultPrereleaseLabel
  # Regex inspired but simplified from https://semver.org/#is-there-a-suggested-regular-expression-regex-to-check-a-semver-string
  static [string] $SEMVER_REGEX = "(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:(?<presep>-?)(?<prelabel>[a-zA-Z-]*)(?<prenumsep>\.?)(?<prenumber>0|[1-9]\d*))?"

  static [AzureEngSemanticVersion] ParseVersionString([string] $versionString)
  {
    $version = [AzureEngSemanticVersion]::new($versionString)

    if (!$version.IsSemVerFormat) {
      return $null
    }
    return $version
  }

  static [AzureEngSemanticVersion] ParsePythonVersionString([string] $versionString)
  {
    $version = [AzureEngSemanticVersion]::ParseVersionString($versionString)

    if (!$version) {
      return $null
    }

    $version.SetupPythonConventions()
    return $version
  }
  
  AzureEngSemanticVersion([string] $versionString)
  {
    if ($versionString -match "^$([AzureEngSemanticVersion]::SEMVER_REGEX)$")
    {
      $this.IsSemVerFormat = $true
      $this.RawVersion = $versionString
      $this.Major = [int]$matches.Major
      $this.Minor = [int]$matches.Minor
      $this.Patch = [int]$matches.Patch

      $this.SetupDefaultConventions()

      if ($null -eq $matches['prelabel']) 
      {
        # artifically provide these values for non-prereleases to enable easy sorting of them later than prereleases.
        $this.PrereleaseLabel = "zzz"
        $this.PrereleaseNumber = 999
        $this.IsPrerelease = $false
      }
      else
      {
        $this.PrereleaseLabel = $matches["prelabel"]
        $this.PrereleaseLabelSeparator = $matches["presep"]
        $this.PrereleaseNumber = [int]$matches["prenumber"]
        $this.PrereleaseNumberSeparator = $matches["prenumsep"]
        $this.IsPrerelease = $true
      }
    }
    else
    {
      $this.RawVersion = $versionString
      $this.IsSemVerFormat = $false
    }
  }

  # If a prerelease label exists, it must be 'beta', and similar semantics used in our release guidelines
  # See https://azure.github.io/azure-sdk/policies_releases.html#package-versioning
  [bool] HasValidPrereleaseLabel()
  {
    if ($this.IsPrerelease -eq $true) {
      if ($this.PrereleaseLabel -ne $this.DefaultPrereleaseLabel) {
        Write-Host "Unexpected pre-release identifier '$($this.PrereleaseLabel)', should be '$($this.DefaultPrereleaseLabel)'"
        return $false;
      }
      if ($this.PrereleaseNumber -lt 1)
      {
        Write-Host "Unexpected pre-release version '$($this.PrereleaseNumber)', should be >= '1'"
        return $false;
      }
    }
    return $true;
  }

  [string] ToString()
  {
    $versionString = "{0}.{1}.{2}" -F $this.Major, $this.Minor, $this.Patch

    if ($this.IsPrerelease)
    {
      $versionString += $this.PrereleaseLabelSeparator + $this.PrereleaseLabel + $this.PrereleaseNumberSeparator + $this.PrereleaseNumber
    }
    return $versionString;
  }

  [void] IncrementAndSetToPrerelease() {
    if ($this.IsPrerelease -eq $false)
    {
      $this.PrereleaseLabel = $this.DefaultPrereleaseLabel
      $this.PrereleaseNumber = 1
      $this.Minor++
      $this.Patch = 0
      $this.IsPrerelease = $true
    }
    else
    {
      $this.PrereleaseNumber++
    }
  }

  [void] SetupPythonConventions() 
  {
    # Python uses no separators and "b" for beta so this sets up the the object to work with those conventions
    $this.PrereleaseLabelSeparator = $this.PrereleaseNumberSeparator = ""
    $this.DefaultPrereleaseLabel = "b"
  }

  [void] SetupDefaultConventions() 
  {
    # Use the default common conventions
    $this.PrereleaseLabelSeparator = "-"
    $this.PrereleaseNumberSeparator = "."
    $this.DefaultPrereleaseLabel = "beta"
  }

  static [string[]] SortVersionStrings([string[]] $versionStrings)
  {
    $versions = $versionStrings | ForEach-Object { [AzureEngSemanticVersion]::ParseVersionString($_) }
    $sortedVersions = [AzureEngSemanticVersion]::SortVersions($versions)
    return ($sortedVersions | ForEach-Object { $_.ToString() })
  }

  static [AzureEngSemanticVersion[]] SortVersions([AzureEngSemanticVersion[]] $versions)
  {
    return ($versions | Sort-Object -Property Major, Minor, Patch, PrereleaseLabel, PrereleaseNumber -Descending)
  }

  static [void] QuickTests()
  {
    $versions = @(
      "1.0.1", 
      "2.0.0", 
      "2.0.0-alpha.20200920", 
      "2.0.0-beta.2", 
      "1.0.10", 
      "2.0.0-beta.1", 
      "2.0.0-beta.10", 
      "1.0.0", 
      "1.0.0b2",
      "1.0.2")

    $expectedSort = @(
      "2.0.0",
      "2.0.0-beta.10",
      "2.0.0-beta.2",
      "2.0.0-beta.1",
      "2.0.0-alpha.20200920",
      "1.0.10",
      "1.0.2",
      "1.0.1",
      "1.0.0",
      "1.0.0b2")

    $sort = [AzureEngSemanticVersion]::SortVersionStrings($versions)

    for ($i = 0; $i -lt $expectedSort.Count; $i++)
    {
      if ($sort[$i] -ne $expectedSort[$i]) { 
        Write-Host "Error: Incorrect sort:"
        Write-Host "Expected: "
        Write-Host $expectedSort
        Write-Host "Actual:"
        Write-Host $sort
        break
      }
    }

    $devVerString = "1.2.3-alpha.20200828.1"
    $devVerNew = [AzureEngSemanticVersion]::new($devVerString)
    if (!$devVerNew -or $devVerNew.IsSemVerFormat -ne $false) {
      Write-Host "Error: Didn't expect daily dev version to match our semver regex because of the extra .r"
    }
    $devVerparse = [AzureEngSemanticVersion]::ParseVersionString($devVerString)
    if ($devVerparse) {
      Write-Host "Error: Didn't expect daily dev version to parse because of the extra .r"
    }

    $gaVerString = "1.2.3"
    $gaVer = [AzureEngSemanticVersion]::ParseVersionString($gaVerString)
    if ($gaVer.Major -ne 1 -or $gaVer.Minor -ne 2 -or $gaVer.Patch -ne 3) {
      Write-Host "Error: Didn't correctly parse ga version string $gaVerString"
    }
    if ($gaVerString -ne $gaVer.ToString()) {
      Write-Host "Error: Ga string did not correctly round trip with ToString"
    }
    $gaVer.IncrementAndSetToPrerelease()
    if ("1.3.0-beta.1" -ne $gaVer.ToString()) {
      Write-Host "Error: Ga string did not correctly increment"
    }

    $betaVerString = "1.2.3-beta.4"
    $betaVer = [AzureEngSemanticVersion]::ParseVersionString($betaVerString)
    if ($betaVer.Major -ne 1 -or $betaVer.Minor -ne 2 -or $betaVer.Patch -ne 3 -or $betaVer.PrereleaseLabel -ne "beta" -or $betaVer.PrereleaseNumber -ne 4) {
      Write-Host "Error: Didn't correctly parse beta version string $betaVerString"
    }
    if ($betaVerString -ne $betaVer.ToString()) {
      Write-Host "Error: beta string did not correctly round trip with ToString"
    }
    $betaVer.IncrementAndSetToPrerelease()
    if ("1.2.3-beta.5" -ne $betaVer.ToString()) {
      Write-Host "Error: Beta string did not correctly increment"
    }

    $pythonBetaVerString = "1.2.3b4"
    $pbetaVer = [AzureEngSemanticVersion]::ParsePythonVersionString($pythonBetaVerString)
    if ($pbetaVer.Major -ne 1 -or $pbetaVer.Minor -ne 2 -or $pbetaVer.Patch -ne 3 -or $pbetaVer.PrereleaseLabel -ne "b" -or $pbetaVer.PrereleaseNumber -ne 4) {
      Write-Host "Error: Didn't correctly parse python beta string $pythonBetaVerString"
    }
    if ($pythonBetaVerString -ne $pbetaVer.ToString()) {
      Write-Host "Error: python beta string did not correctly round trip with ToString"
    }
    $pbetaVer.IncrementAndSetToPrerelease()
    if ("1.2.3b5" -ne $pbetaVer.ToString()) {
      Write-Host "Error: Python beta string did not correctly increment"
    }

    Write-Host "QuickTests done"
  }
}

param(
    [string]$ArtifactsPath
)
. (Join-Path $PSScriptRoot ../../common/scripts/common.ps1)
$ErrorActionPreference = 'Continue'

$NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v2"
$allPackages = Get-AllPkgProperties
$trackTwoPackages = $allPackages.Where({ $_.IsNewSdk })

$azureCorePkgInfo = $trackTwoPackages.Where({ $_.Name -eq "Azure.Core"})
$azureCoreVer = [AzureEngSemanticVersion]::ParseVersionString($azureCorePkgInfo.Version)
$azureCoreVer.IsPreRelease = $false
$azureCoreVerBase = $azureCoreVer.ToString()

$azureCoreMinDate = (Get-Date).addMonths(-1).ToString("yyyyMM")

$azureCorePkg = Find-Package -Name 'Azure.Core' `
  -Source $NugetSource `
  -AllowPrereleaseVersions `
  -MinimumVersion "$azureCoreVerBase-alpha.$azureCoreMinDate" `
  -MaximumVersion "$azureCoreVerBase-alphab" `
  -Force

Write-Host "Azure.Core Version: $($azureCorePkg.Version)"
# azureCoreVerExtension follows the format of -alpha.<yyyymmdd>.1
$azureCoreVerExtension = $azureCorePkg.Version.Replace($azureCoreVerBase, "")
$azureCoreVerDateStr = $azureCoreVerExtension.split(".")[1]
$azureCoreVerDate = [DateTime]::ParseExact($azureCoreVerDateStr, "yyyyMMdd", $null)
# Parsing Azure.Core's latest version and make the min version for other packages one month prior to that.
# This will exclude stale packages that aren't being updated regularly
$pkgMinVer = $azureCoreVerDate.addMonths(-1).ToString("yyyyMMdd")

$SmokeTestPackageInfo = @()
if ($ArtifactsPath) {
  $ArtifactPkgInfoJson = Get-ChildItem "$ArtifactsPath/PackageInfo/*.json"
  foreach ($pkgInfo in $ArtifactPkgInfoJson) {
    $SmokeTestPackageInfo += ConvertFrom-Json (Get-Content $pkgInfo -Raw)
  }
} else {
  foreach ($pkg in $trackTwoPackages) {
    $pkgVersion = [AzureEngSemanticVersion]::ParseVersionString($pkg.Version)
    $pkgVersion.IsPreRelease = $false
    $pkgVersionBase = $pkgVersion.ToString()

    $pkgInfo = Find-Package -Name $pkg.Name `
      -Source $NugetSource `
      -AllowPrereleaseVersions `
      -MinimumVersion "$pkgVersionBase-alpha.$pkgMinVer" `
      -MaximumVersion "$pkgVersionBase$azureCoreVerExtension" `
      -Force

    if ($pkgInfo) {
      Write-Host "Found $($pkgInfo.Name) $($pkgInfo.Version)"
      $pkg.DevVersion = $pkgInfo.Version
      $SmokeTestPackageInfo += $pkg
    }
    else {
      Write-Warning "Cannot find alpha version of package $($pkg.Name) after $pkgMinver and before $azureCoreVerDateStr"
      Write-Warning "This may be due to the package being stale or unpublished"
      $latestPkg = Find-Package -Name $pkg.Name `
        -Source $NugetSource `
        -AllowPrereleaseVersions `
        -Force

      if ($latestPkg) {
        Write-Host "Found latest version $($latestPkg.Name) $($latestPkg.Version)"
        $pkg.DevVersion = $latestPkg.Version
        $SmokeTestPackageInfo += $pkg
      }
      else
      {
        Write-Warning "Did not find any matching package $($pkg.Name)"
        Write-Warning "This error may be due to package not being published"
      }
    }
  }
}
Write-Host "Smoke Test Package Info:"
foreach ($pkgInfo in $SmokeTestPackageInfo) {
  Write-Host $pkgInfo
}
return $SmokeTestPackageInfo

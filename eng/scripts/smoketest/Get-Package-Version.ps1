. (Join-Path $PSScriptRoot ../../common/scripts/common.ps1)
$ErrorActionPreference = 'Continue'

$NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v2"
$allPackages = Get-AllPkgProperties
$trackTwoPackages = $allPackages.Where({ $_.IsNewSdk })

$azureCorePkgInfo = $trackTwoPackages.Where({ $_.Name -eq "Azure.Core"})
$azureCoreVer = [AzureEngSemanticVersion]::ParseVersionString($azureCorePkgInfo.Version)
$azureCoreVer.IsPreRelease = $false
$azureCoreVerBase = $azureCoreVer.ToString()

$azureCorePkg = Find-Package -Name 'Azure.Core' `
  -Source $NugetSource `
  -AllowPrereleaseVersions `
  -MinimumVersion "$azureCoreVerBase-alpha.202106" `
  -MaximumVersion "$azureCoreVerBase-alphab" `
  -Force

Write-Host "Azure.Core Version: $($azureCorePkg.Version)"
$azureCoreVerExtension = $azureCorePkg.Version.Replace($azureCoreVerBase, "")
$azureCoreVerDateStr = $azureCoreVerExtension.split(".")[1]
$azureCoreVerDate = [DateTime]::ParseExact($azureCoreVerDateStr, "yyyyMMdd", $null)
$pkgMinVer = $azureCoreVerDate.addMonths(-1).ToString("yyyyMMdd")

$SmokeTestPackageVersions = @{}
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
    $SmokeTestPackageVersions[$pkgInfo.Name] = $pkgInfo.Version
  }
  else {
    Write-Host "Cannot find alpha version of package $($pkg.Name) after $pkgMinver and before $azureCoreVerDateStr"
    Write-Host "This may be due to the package being stale or unpublished"
    $latestPkg = Find-Package -Name $pkg.Name `
      -Source $NugetSource `
      -AllowPrereleaseVersions `
      -Force

    if ($latestPkg) {
      Write-Host "Found latest version $($latestPkg.Name) $($latestPkg.Version)"
      $SmokeTestPackageVersions[$latestPkg.Name] = $latestPkg.Version
    }
    else
    {
      Write-Host "Did not find any matching package $($pkg.Name)"
      Write-Host "This error may be due to package not being published"
    }
  }
}

return $SmokeTestPackageVersions

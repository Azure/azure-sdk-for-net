. (Join-Path $PSScriptRoot ../../common/scripts/common.ps1)
$ErrorActionPreference = 'Continue'

function Get-SmokeTestPkgProperties
{
    Param
    (
        [string]$ArtifactsPath
    )
    if ($ArtifactsPath)
    {
        Write-Host $ArtifactsPath
        $SmokeTestPackageInfo = @()
        $ArtifactPkgInfoJson = Get-ChildItem "$ArtifactsPath/PackageInfo/*.json"
        foreach ($pkgInfo in $ArtifactPkgInfoJson) {
            $SmokeTestPackageInfo += ConvertFrom-Json (Get-Content $pkgInfo -Raw)
        }
        return $SmokeTestPackageInfo
    }

    $NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v2"
    $allPackages = Get-AllPkgProperties
    $excludePackages = @{
        "Azure.AI.Personalizer" = 'Unable to load DLL rl.net.native.dll https://msazure.visualstudio.com/One/_workitems/edit/14284280';
    }
    $newPackages = $allPackages.Where({ $_.IsNewSdk -and !$excludePackages.ContainsKey($_.Name) })

    $azureCorePkgInfo = $newPackages.Where({ $_.Name -eq "Azure.Core"})
    $azureCoreVer = [AzureEngSemanticVersion]::ParseVersionString($azureCorePkgInfo.Version)
    $azureCoreVer.PrereleaseLabel = ""
    $azureCoreVerBase = $azureCoreVer.ToString()

    # Pick a version of core that is at least one day old but no older then one month old
    # Using at least one day old to ensure all the packages had a chance to build for that day
    $azureCoreMinDate = (Get-Date).addMonths(-1).ToString("yyyyMMdd")
    $azureCoreMaxDate = (Get-Date).AddDays(-1).ToString("yyyyMMdd")

    $azureCorePkg = Find-Package -Name 'Azure.Core' `
        -Source $NugetSource `
        -AllowPrereleaseVersions `
        -MinimumVersion "$azureCoreVerBase-alpha.$azureCoreMinDate" `
        -MaximumVersion "$azureCoreVerBase-alpha.$azureCoreMaxDate.99" `
        -Force
    Write-Host "$azureCoreVerBase-alpha.$azureCoreMinDate"
    Write-Host "$azureCoreVerBase-alpha.$azureCoreMaxDate.99"
    Write-Host "Azure.Core Version: $($azureCorePkg.Version)"
    # azureCoreVerExtension follows the format of -alpha.<yyyymmdd>.1
    $azureCoreVerExtension = $azureCorePkg.Version.Replace($azureCoreVerBase, "")
    $azureCoreVerDateStr = $azureCoreVerExtension.split(".")[1]

    $SmokeTestPackageInfo = @()

    foreach ($pkg in $newPackages) {
        $pkgVersion = [AzureEngSemanticVersion]::ParseVersionString($pkg.Version)
        $pkgVersion.PrereleaseLabel = ""
        $pkgVersionBase = $pkgVersion.ToString()

        $pkgVersionAlpha = "$pkgVersionBase-alpha.$azureCoreVerDateStr"
        $pkgInfo = Find-Package -Name $pkg.Name `
            -Source $NugetSource `
            -AllowPrereleaseVersions `
            -MinimumVersion "$pkgVersionAlpha.1" `
            -MaximumVersion "$pkgVersionAlpha.99" `
            -ErrorAction SilentlyContinue

        if ($pkgInfo) {
            Write-Debug "Found $($pkgInfo.Name) $($pkgInfo.Version)"
            $pkg.DevVersion = $pkgInfo.Version
            $SmokeTestPackageInfo += $pkg
        }
        else {
            Write-Debug "Skipping package $($pkg.Name) because could not find a version $pkgVersionAlpha"
        }
    }
    return $SmokeTestPackageInfo
}

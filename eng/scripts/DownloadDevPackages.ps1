param (
    [Parameter(Mandatory=$True)]
    [string] $WorkingDirectory,
    [Parameter(Mandatory=$True)]
    [string] $NupkgFilesDestination,
    # Install-Package requires a v2 nuget feed.
    [string] $NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v2",
    [string] $FeedId="azure-sdk-for-net"
)

. (Join-Path $PSScriptRoot ".." common scripts common.ps1)

$allPackages = Get-AllPkgProperties
$trackTwoPackages = $allPackages.Where({ $_.IsNewSdk })

Write-Host "Number of track two packages $($trackTwoPackages.Count)"

Push-Location $WorkingDirectory
$nugetPackagesPath = Join-Path $WorkingDirectory nugetPackages
New-Item -Path $WorkingDirectory -Type "directory" -Name "nugetPackages"


foreach ($package in $trackTwoPackages)
{
  $packageVersion = [AzureEngSemanticVersion]::ParseVersionString($package.Version)
  $packageVersion.IsPreRelease = $false # Clear prerelease so ToString strips it prerelease label.
  $packageVersionBase = $packageVersion.ToString()

  # To workaround some older invalid packages (i.e. Iot->IoT renamed packages) start the alpha version range to start at 6/21
  $installedPackage = Install-Package -Name $package.Name `
    -Source $NugetSource `
    -AllowPrereleaseVersions `
    -MinimumVersion "$packageVersionBase-alpha.202106" `
    -MaximumVersion "$packageVersionBase-alphab" `
    -Destination $nugetPackagesPath `
    -Force `
    -SkipDependencies `
    -ErrorAction Ignore

  if ($installedPackage)
  {
    Write-Host "Installed $($installedPackage.Name) $($installedPackage.Version)"
  }
  else 
  {
    # Install the latest available version if no alpha version is found
    $latestInstalledPackage  = Install-Package -Name $package.Name `
      -Source $NugetSource `
      -AllowPrereleaseVersions `
      -Destination $nugetPackagesPath `
      -Force `
      -SkipDependencies `
      -ErrorAction Ignore

    if ($latestInstalledPackage)
    {
      Write-Host "Installed latest version $($latestInstalledPackage.Name) $($latestInstalledPackage.Version)"
    }
    else
    {
      Write-Host "Did not find any matching package $($package.Name)"
    }
  }
}

$nupkgDirPath = Join-Path $WorkingDirectory $NupkgFilesDestination
New-Item -Path $WorkingDirectory -Type "directory" -Name $NupkgFilesDestination

Get-ChildItem -Path $nugetPackagesPath -Include *.nupkg -Recurse | Copy-Item -Destination $nupkgDirPath
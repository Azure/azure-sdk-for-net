param (
    [Parameter(Mandatory=$True)]
    [string] $WorkingDirectory,
    [Parameter(Mandatory=$True)]
    [string] $NupkgFilesDestination,
    [string] $NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json"
)

. (Join-Path $PSScriptRoot ".." common scripts common.ps1)

$allPackages = Get-AllPkgProperties
$trackTwoPackages = $allPackages.Where({ $_.IsNewSdk })

Push-Location $WorkingDirectory
$nugetPackagesPath = Join-Path $WorkingDirectory nugetPackages
New-Item -Path $WorkingDirectory -Type "directory" -Name "nugetPackages"

$packagesInFeed = Find-Package -Source $NugetSource -AllVersion -AllowPrereleaseVersions

foreach ($package in $trackTwoPackages)
{
  $allVersionsInFeed = $packagesInFeed.Where({ ($_.Name -eq $package.Name) })
  $alphaVersionsInFeed = $allVersionsInFeed.Where({ ($_.Version -like "*-alpha.*") })

  # Use the latest alpha version where it is available
  if ($alphaVersionsInFeed.Count -gt 0)
  {
    $alphaVersionsSorted = [AzureEngSemanticVersion]::SortVersionStrings($alphaVersionsInFeed.Version)
    $latestDevVersion = $alphaVersionsSorted[0]
  }
  else
  {
    $allVersionsSorted = [AzureEngSemanticVersion]::SortVersionStrings($allVersionsInFeed.Version)
    $latestDevVersion = $allVersionsSorted[0]
  }

  nuget install $package.Name `
    -Version $latestDevVersion `
    -OutputDirectory $nugetPackagesPath `
    -Prerelease `
    -Source $NugetSource `
    -DependencyVersion Ignore `
    -DirectDownload `
    -NoCache `
}

$nupkgDirPath = Join-Path $WorkingDirectory $NupkgFilesDestination
New-Item -Path $WorkingDirectory -Type "directory" -Name $NupkgFilesDestination

Get-ChildItem -Path $nugetPackagesPath -Include *.nupkg -Recurse | Copy-Item -Destination $nupkgDirPath
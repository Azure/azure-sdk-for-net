param (
    [Parameter(Mandatory=$True)]
    [string] $WorkingDirectory,
    [Parameter(Mandatory=$True)]
    [string] $AllNupkgFilesDestination,
    [Parameter(Mandatory=$True)]
    [string] $AzureSDKNupkgFilesDestination,
    [string] $NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json",
    [string] $FallBackSource = "https://api.nuget.org/v3/index.json"
)

. (Join-Path $PSScriptRoot ".." common scripts common.ps1)

$allPackages = Get-AllPkgProperties
$trackTwoPackages = $allPackages.Where({ $_.IsNewSdk })

Push-Location $WorkingDirectory
$nugetPackagesPath = Join-Path $WorkingDirectory nugetPackages
New-Item -Path $WorkingDirectory -Type "directory" -Name "nugetPackages"

foreach ($package in $trackTwoPackages)
{
  nuget install $package.Name `
  -OutputDirectory $nugetPackagesPath `
  -Prerelease `
  -Source $NugetSource `
  -FallBackSource $FallBackSource `
  -DirectDownload `
  -ExcludeVersion `
  -NoCache `
}

$allNupkgDirPath = Join-Path $WorkingDirectory $AllNupkgFilesDestination
New-Item -Path $WorkingDirectory -Type "directory" -Name $AllNupkgFilesDestination

$azureSdkNupkgDirPath = Join-Path $WorkingDirectory $AzureSDKNupkgFilesDestination
New-Item -Path $WorkingDirectory -Type "directory" -Name $AzureSDKNupkgFilesDestination

$allDownloadedNupkgFiles = Get-ChildItem -Path $nugetPackagesPath -Include *.nupkg -Recurse
foreach ($file in $allDownloadedNupkgFiles)
{
  Copy-Item -Path $file.FullName -Destination $allNupkgDirPath
  if ($trackTwoPackages.Name -contains $file.BaseName)
  {
    Copy-Item -Path $file.FullName -Destination $azureSdkNupkgDirPath
  }
}
param (
    [Parameter(Mandatory=$True)]
    [string] $WorkingDirectory,
    [Parameter(Mandatory=$True)]
    [string] $NupkgDestination,
    [string] $NugetSource="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json",
    [string] $FallBackSource = "https://api.nuget.org/v3/index.json"
)

. (Join-Path $PSScriptRoot ".." common scripts common.ps1)

$allPackages = Get-AllPkgProperties
$trackTwoPackages = $allPackages.Where{ $_.IsNewSdk }

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
  -DependencyVersion Ignore `
  -DirectDownload `
  -NoCache `
}

$nupkgFilesPath = Join-Path $WorkingDirectory $NupkgDestination
New-Item -Path $WorkingDirectory -Type "directory" -Name $NupkgDestination

Get-ChildItem -Path $nugetPackagesPath -Include *.nupkg -Recurse | Copy-Item -Destination $nupkgFilesPath
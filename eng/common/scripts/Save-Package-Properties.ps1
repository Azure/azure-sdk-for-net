<#
.SYNOPSIS
Saves package properties from source into JSON files

.DESCRIPTION
Saves package properties in source of a given service directory to JSON files.
JSON files are named in the form <package name>.json or <artifact name>.json if
an artifact name property is available in the package properties.

Can optionally add a dev version property which can be used logic for daily
builds.

In cases of collisions where track 2 packages (IsNewSdk = true) have the same
filename as track 1 packages (e.g. same artifact name or package name), the
track 2 package properties will be written.

.PARAMETER serviceDirectory
Service directory in which to search for packages.

.PARAMETER prDiff
A file path leading to a file generated from Generate-PR-Diff.json. This parameter takes precedence over serviceDirectory, do not provide both.

.PARAMETER outDirectory
Output location (generally a package artifact directory in DevOps) for JSON
files

.PARAMETER addDevVersion
Reads the version out of the source and adds a DevVersion property to the
package properties JSON file. If the package properties JSON file already
exists, read the Version property from the existing package properties JSON file
and set that as the Version property for the new output. This has the effect of
"adding" a DevVersion property to the file which could be different from the
Verison property in that file.
#>

[CmdletBinding()]
Param (
  [string] $serviceDirectory,
  [Parameter(Mandatory = $True)]
  [string] $outDirectory,
  [string] $prDiff,
  [switch] $addDevVersion
)

. (Join-Path $PSScriptRoot common.ps1)

function SetOutput($outputPath, $incomingPackageSpec)
{

  # If there is an exsiting package info json file read that and set that as output object which gets properties updated here.
  if (Test-Path $outputPath)
  {
    Write-Host "Found existing package info json."
    $outputObject = ConvertFrom-Json (Get-Content $outputPath -Raw)
  }
  else
  {
    $outputObject = $incomingPackageSpec
  }


  if ($addDevVersion)
  {
    # Use the "Version" property which was provided by the incoming package spec
    # as the DevVersion. This may be overridden later.
    $outputObject.DevVersion = $incomingPackageSpec.Version
  }

  # Set file paths to relative paths
  $outputObject.DirectoryPath = GetRelativePath $outputObject.DirectoryPath
  $outputObject.ReadMePath = GetRelativePath $outputObject.ReadMePath
  $outputObject.ChangeLogPath = GetRelativePath $outputObject.ChangeLogPath

  Set-Content `
    -Path $outputPath `
    -Value (ConvertTo-Json -InputObject $outputObject -Depth 100)
}

function GetRelativePath($path)
{
  # If the path is empty return an empty string
  if (!$path)
  {
    return ''
  }

  # If the path is already relative return the path. Calling `GetRelativePath`
  # on a relative path converts the relative path to an absolute path based on
  # the current working directory which can result in unexpected outputs.
  if (![IO.Path]::IsPathRooted($path))
  {
    return $path
  }

  $relativeTo = Resolve-Path $PSScriptRoot/../../../
  # Replace "\" with "/" so the path is valid across other platforms and tools
  $relativePath = [IO.Path]::GetRelativePath($relativeTo, $path) -replace "\\", '/'
  return $relativePath
}

$exportedPaths = @{}

$allPackageProperties = @()

if ($prDiff)
{
  Write-Host "Getting package properties for PR diff file: $prDiff"
  $allPackageProperties = Get-PrPkgProperties $prDiff

  if (!$allPackageProperties)
  {
    Write-Host "No packages found matching PR diff file $prDiff"
    Write-Host "Setting NoPackagesChanged variable to true"
    Write-Host "##vso[task.setvariable variable=NoPackagesChanged]true"
    exit 0
  }
}
else
{
  Write-Host "Getting package properties for service directory: $serviceDirectory"
  $allPackageProperties = Get-AllPkgProperties $serviceDirectory

  if (!$allPackageProperties)
  {
    Write-Error "Package properties are not available for service directory $serviceDirectory"
    exit 1
  }
}

if (-not (Test-Path -Path $outDirectory))
{
  New-Item -ItemType Directory -Force -Path $outDirectory | Out-Null
}

foreach ($pkg in $allPackageProperties)
{
  if ($pkg.Name)
  {
    Write-Host ""
    Write-Host "Package Name: $($pkg.Name)"
    Write-Host "Package Version: $($pkg.Version)"
    Write-Host "Package SDK Type: $($pkg.SdkType)"
    Write-Host "Artifact Name: $($pkg.ArtifactName)"
    if (-not [System.String]::IsNullOrEmpty($pkg.Group)) {
      Write-Host "GroupId: $($pkg.Group)"
    }
    Write-Host "Release date: $($pkg.ReleaseStatus)"
    $configFilePrefix = $pkg.Name

    # Any languages (like JS) which need to override the the packageInfo file name to be something
    # other than the name just need to declare this function in their Language-Settings.ps1 return
    # the desired string from there.
    if (Test-Path "Function:Get-PackageInfoNameOverride") {
      $configFilePrefix = Get-PackageInfoNameOverride $pkg
    }

    $outputPath = Join-Path -Path $outDirectory "$configFilePrefix.json"
    Write-Host "Output path of json file: $outputPath"

    $outDir = Split-Path $outputPath -parent
    if (-not (Test-Path -path $outDir))
    {
      Write-Host "Creating directory $($outDir) for json property file"
      New-Item -ItemType Directory -Path $outDir | Out-Null
    }

    # If package properties for a track 2 (IsNewSdk = true) package has
    # already been written, skip writing to that same path.
    if ($exportedPaths.ContainsKey($outputPath) -and $exportedPaths[$outputPath].IsNewSdk -eq $true)
    {
      Write-Host "Track 2 package info with file name $($outputPath) already exported. Skipping export."
      continue
    }

    $exportedPaths[$outputPath] = $pkg
    SetOutput $outputPath $pkg
  }
}

$fileNames = (Get-ChildItem -Path $outDirectory).Name
Write-Host "`nFiles written to $outDirectory`:"
Write-Host "  $($fileNames -join "`n  ")"

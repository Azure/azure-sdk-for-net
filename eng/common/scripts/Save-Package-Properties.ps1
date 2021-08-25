<#
.SYNOPSIS
Saves package properties from source into JSON files

.DESCRIPTION
Saves package properties in source of a given service directory to JSON files.
JSON files are named in the form <package name>.json or <artifact name>.json if
an artifact name property is available in the package properties.

Can optionally add a dev version property which can be used logic for daily 
builds.

.PARAMETER serviceDirectory
Service directory in which to search for packages

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
  [Parameter(Mandatory=$True)]
  [string] $serviceDirectory,
  [Parameter(Mandatory=$True)]
  [string] $outDirectory,
  [switch] $addDevVersion
)

. (Join-Path $PSScriptRoot common.ps1)

function SetOutput($outputPath, $incomingPackageSpec) { 
  $outputObject = $incomingPackageSpec

  if ($addDevVersion) {
    # Use the "Version" property which was provided by the incoming package spec
    # as the DevVersion. This may be overridden later.
    $outputObject.DevVersion = $incomingPackageSpec.Version

    # If there is an exsiting package info json file read that and set the 
    # Version property from that JSON file.
    if (Test-Path $outputPath) { 
      $originalObject = ConvertFrom-Json (Get-Content $outputPath -Raw)
      $outputObject.Version = $originalObject.Version
    }
  }

  # Set file paths to relative paths
  $outputObject.DirectoryPath = GetRelativePath $outputObject.DirectoryPath
  $outputObject.ReadMePath = GetRelativePath $outputObject.ReadMePath
  $outputObject.ChangeLogPath = GetRelativePath $outputObject.ChangeLogPath

  Set-Content `
    -Path $outputPath `
    -Value (ConvertTo-Json -InputObject $outputObject -Depth 100)
}

function GetRelativePath($path) {
  # If the path is empty return an empty string
  if (!$path) {
    return ''
  }
  $relativeTo = Resolve-Path $PSScriptRoot/../../../
  # Replace "\" with "/" so the path is valid across other platforms and tools
  $relativePath = [IO.Path]::GetRelativePath($relativeTo, $path) -replace "\\", '/'
  return $relativePath
}

$allPackageProperties = Get-AllPkgProperties $serviceDirectory
if ($allPackageProperties)
{
    if (-not (Test-Path -Path $outDirectory))
    {
      New-Item -ItemType Directory -Force -Path $outDirectory
    }
    foreach($pkg in $allPackageProperties)
    {
        if ($pkg.IsNewSdk)
        {
            Write-Host "Package Name: $($pkg.Name)"
            Write-Host "Package Version: $($pkg.Version)"
            Write-Host "Package SDK Type: $($pkg.SdkType)"
            Write-Host "Artifact Name: $($pkg.ArtifactName)"
            Write-Host "Release date: $($pkg.ReleaseStatus)"
            $configFilePrefix = $pkg.Name
            if ($pkg.ArtifactName)
            {
              $configFilePrefix = $pkg.ArtifactName
            }
            $outputPath = Join-Path -Path $outDirectory "$configFilePrefix.json"
            SetOutput $outputPath $pkg
        }
    }

    Get-ChildItem -Path $outDirectory
}
else
{
    Write-Error "Package properties are not available for service directory $($serviceDirectory)"
    exit 1
}

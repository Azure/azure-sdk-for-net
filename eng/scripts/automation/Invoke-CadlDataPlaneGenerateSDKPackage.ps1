#Requires -Version 7.0
<#
.SYNOPSIS
script for creating a getting started project in a branch of `azure-sdk-for-net` repo.

.PARAMETER service
The Azure client service directory name. ie. purview. It is the same as the name of the directory in the specification folder of the azure-rest-api-specs repo that contains the REST API definition file.

.PARAMETER namespace
The SDK package namespace. This value will also provide the name for the shipped package, and should be of the form `Azure.<group>.<service>`.

.PARAMETER sdkPath
The address of the root directory of sdk repo. e.g. `/home/azure-sdk-for-net`

.PARAMETER cadlRelativeFolder
The relative path of the cadl project folder in spec repo. e.g. `specification/cognitiveservices/AnomalyDetector`

 .PARAMETER specRoot
The file system path of the spec repo. e.g. `/home/azure-rest-api-specs`

 .PARAMETER repo
The `<owner>/<repo>` of the spec repo. e.g. `Azure/azure-rest-api-specs`

.PARAMETER commit
The commit of the github hash, e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90

.PARAMETER additionalSubDirectories
The relative paths of the additional directories needed by the cadl project, such as share library folder, separated by semicolon if there is more than one folder.

.EXAMPLE
Run script with default parameters.

Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service <servicename> -namespace Azure.<group>.<service> -sdkPath <sdkrepoRootPath> -cadlRelativeFolder <relativeCadlProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]

e.g.

Use git url

Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service anomalydetector -namespace Azure.AI.AnomalyDetector -sdkPath /home/azure-sdk-for-net -cadlRelativeFolder specification/cognitiveservices/AnomalyDetector -commit ac8e06a2ed0fc1c54663c98f12c8a073f8026b90 -repo Azure/azure-rest-api-specs

or
Use local Cadl project

Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service anomalydetector -namespace Azure.AI.AnomalyDetector -sdkPath /home/azure-sdk-for-net -cadlRelativeFolder specification/cognitiveservices/AnomalyDetector -specRoot /home/azure-rest-api-specs

#>
param (
  [string]$service,
  [string]$namespace,
  [string]$sdkPath,
  [string]$cadlRelativeFolder,
  [string]$specRoot = "",
  [string]$repo="",
  [string]$commit="",
  [string]$additionalSubDirectories="" #additional directories needed, separated by semicolon if more than one
)
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)
$sdkPath = Resolve-Path $sdkPath
# Generate dataplane library
$outputJsonFile = "newpackageoutput.json"
New-CADLPackageFolder `
  -service $service `
  -namespace $namespace `
  -sdkPath $sdkPath `
  -relatedCadlProjectFolder $cadlRelativeFolder `
  -specRoot $specRoot `
  -commit $commit `
  -repo $repo `
  -additionalSubDirectories $additionalSubDirectories `
  -outputJsonFile $outputJsonFile

if ( $LASTEXITCODE ) {
  Write-Error "Failed to create sdk project folder. exit code: $LASTEXITCODE"
  exit $LASTEXITCODE
}
$outputJson = Get-Content $outputJsonFile | Out-String | ConvertFrom-Json
$projectFolder = $outputJson.projectFolder
$projectFolder = $projectFolder -replace "\\", "/"

Write-Host "projectFolder:$projectFolder"
Remove-Item $outputJsonFile
# Generate Code
$srcPath = Join-Path $projectFolder 'src'
dotnet build /t:GenerateCode $srcPath
if ($LASTEXITCODE) {
  Write-Error "Failed to generate sdk."
  exit $LASTEXITCODE
}
# Build
dotnet build $projectFolder
if ($LASTEXITCODE) {
  Write-Error "Failed to build sdk. exit code: $LASTEXITCODE"
  exit $LASTEXITCODE
}
# Generate APIs
$repoRoot = (Join-Path $PSScriptRoot .. .. ..)
Push-Location $repoRoot
pwsh eng/scripts/Export-API.ps1 $service
Pop-Location
exit 0
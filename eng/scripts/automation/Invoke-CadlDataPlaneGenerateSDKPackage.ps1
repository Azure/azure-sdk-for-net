#Requires -Version 7.0
<#
.SYNOPSIS
script for creating a getting started project in a branch of `azure-sdk-for-net` repo.

.PARAMETER sdkFolder
The address of the sdk folder in azure-sdk-for-net repo. e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector

.PARAMETER cadlSpecDirectory
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

Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -sdkFolder <sdk-folder-path> -cadlSpecDirectory <relativeCadlProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]

e.g.

Use git url

Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -sdkFolder /home/azure-sdk-for-net/Azure.AI.AnomalyDetector -sdkFolder /home/azure-sdk-for-net/Azure.AI.AnomalyDetector -cadlSpecDirectory specification/cognitiveservices/AnomalyDetector -commit ac8e06a2ed0fc1c54663c98f12c8a073f8026b90 -repo Azure/azure-rest-api-specs

or
Use local Cadl project

Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service anomalydetector -namespace Azure.AI.AnomalyDetector -sdkPath /home/azure-sdk-for-net -cadlRelativeFolder specification/cognitiveservices/AnomalyDetector -specRoot /home/azure-rest-api-specs

#>
param (
  [string]$sdkFolder,
  [string]$cadlSpecDirectory,
  [string]$specRoot = "",
  [string]$repo = "Azure/azure-rest-api-specs",
  [string]$commit = "",
  [string]$additionalSubDirectories="", #additional directories needed, separated by semicolon if more than one
  [switch]$help
)
if ($help) {
  Write-Host("Usage:
Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -sdkFolder <sdk-folder-path> -cadlSpecDirectory <relativeCadlProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]

Options:
-sdkFolder [Required] take the address of the sdk folder in azure-sdk-for-net repo. e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector
-cadlSpecDirectory [Required] takes the relative path of the cadl project folder in spec repo. e.g. specification/cognitiveservices/AnomalyDetector
-additionalSubDirectories [Optional] takes the relative paths of the additional directories needed by the cadl project
-commit takes the git commit hash  (e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90)
-repo [Optional] takes the `<owner>/<repo>` of the REST API specification repository. (e.g. Azure/azure-rest-api-specs). The default is Azure/azure-rest-api-specs
-specRoot takes the file system path of the spec repo. e.g. /home/azure-rest-api-specs

hint: You need to provide the cadl project path either (`-commit`, `-repo`) pair to refer to an URL path of the cadl project or `-specRoot` to refer to local file system path. If you provide both, `-specRoot` will be ignored.
"
)
  exit 0;
}

# validate input parameter
if (!$sdkFolder -or !$cadlSpecDirectory) {
  Throw "One of required parameters (sdkFolder, cadlSpecDirectory) is missing. Please use -help to see the usage."
}

if ((!$commit) -And !$specRoot) {
  Throw "The cadl project path is not provided. You need to provide either (-commit, -repo) pair to refer to URL path or -specRoot to refer to local file system path."
}
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)

# $sdkFolder = Resolve-Path $sdkFolder
$sdkFolder = $sdkFolder -replace "\\", "/"
$sdkFolder = $sdkFolder.TrimEnd('/')
# Generate dataplane library
$outputJsonFile = "newpackageoutput.json"
if ( $sdkFolder -match "(?<sdkPath>.*)/sdk/(?<serviceDirectory>.*)/(?<namespace>.*)" ) {
  $sdkPath = Resolve-Path $matches["sdkPath"]
  $service = $matches["serviceDirectory"]
  $namespace = $matches["namespace"]
}
New-CADLPackageFolder `
  -service $service `
  -namespace $namespace `
  -sdkPath $sdkPath `
  -relatedCadlProjectFolder $cadlSpecDirectory `
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
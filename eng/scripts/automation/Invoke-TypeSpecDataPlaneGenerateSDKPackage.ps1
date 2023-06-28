#Requires -Version 7.0
<#
.SYNOPSIS
script for creating a getting started project in a branch of `azure-sdk-for-net` repo.

.PARAMETER sdkFolder
The address of the sdk folder in azure-sdk-for-net repo. e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector

.PARAMETER typespecSpecDirectory
The relative path of the typespec project folder in spec repo. e.g. `specification/cognitiveservices/AnomalyDetector`

 .PARAMETER repo
The `<owner>/<repo>` of the spec repo. e.g. `Azure/azure-rest-api-specs`

.PARAMETER commit
The commit of the github hash, e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90

.PARAMETER additionalSubDirectories
The relative paths of the additional directories needed by the typespec project, such as share library folder, separated by semicolon if there is more than one folder.

.EXAMPLE
Run script with default parameters.

Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1 -sdkFolder <sdk-folder-path> -typespecSpecDirectory <relativeTypeSpecProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]

e.g.

Use git url

Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1 -sdkFolder /home/azure-sdk-for-net/Azure.AI.AnomalyDetector -sdkFolder /home/azure-sdk-for-net/Azure.AI.AnomalyDetector -typespecSpecDirectory specification/cognitiveservices/AnomalyDetector -commit ac8e06a2ed0fc1c54663c98f12c8a073f8026b90 -repo Azure/azure-rest-api-specs

#>
param (
  [string]$sdkFolder,
  [string]$typespecSpecDirectory,
  [string]$repo = "Azure/azure-rest-api-specs",
  [string]$commit = "",
  [string]$additionalSubDirectories="", #additional directories needed, separated by semicolon if more than one
  [switch]$help
)
if ($help) {
  Write-Host("Usage:
Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1 -sdkFolder <sdk-folder-path> -typespecSpecDirectory <relativeTypeSpecProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]

Options:
-sdkFolder [Required] take the address of the sdk folder in azure-sdk-for-net repo. e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector
-typespecSpecDirectory [Required] takes the relative path of the typespec project folder in spec repo. e.g. specification/cognitiveservices/AnomalyDetector
-additionalSubDirectories [Optional] takes the relative paths of the additional directories needed by the typespec project
-commit takes the git commit hash  (e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90)
-repo [Optional] takes the `<owner>/<repo>` of the REST API specification repository. (e.g. Azure/azure-rest-api-specs). The default is Azure/azure-rest-api-specs
"
)
  exit 0;
}

# validate input parameter
if (!$sdkFolder -or !$typespecSpecDirectory) {
  Throw "One of required parameters (sdkFolder, typespecSpecDirectory) is missing. Please use -help to see the usage."
}

if (!$commit) {
  Throw "The typespec project path is not provided. You need to provide (-commit, -repo) pair to refer to URL path."
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
New-TypeSpecPackageFolder `
  -service $service `
  -namespace $namespace `
  -sdkPath $sdkPath `
  -relatedTypeSpecProjectFolder $typespecSpecDirectory `
  -commit $commit `
  -repo $repo `
  -additionalSubDirectories $additionalSubDirectories `
  -outputJsonFile $outputJsonFile

if ( $LASTEXITCODE ) {
  Write-Error "Failed to create sdk project folder. exit code: $LASTEXITCODE"
  exit $LASTEXITCODE
}
Remove-Item $outputJsonFile
exit 0
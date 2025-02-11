#Requires -Version 7.0
<#
.SYNOPSIS
script for creating a getting started project in a branch of `azure-sdk-for-net` repo for SDKs generated from swagger.

.PARAMETER service
The Azure client service directory name. ie. purview. It equals to the name of the directory in the specification folder of the azure-rest-api-specs repo that contains the REST API definition file.

.PARAMETER namespace
The SDK package namespace. This value will also provide the name for the shipped package, and should be of the form `Azure.<group>.<service>`.

.PARAMETER sdkPath
The address of the root directory of sdk repo. e.g. /home/azure-sdk-for-net

.PARAMETER inputfiles
The address of the Open API spec files,  separated by semicolon if there is more than one file.
The Open API spec file can be local file, or the web address of the file in the `azure-rest-api-specs` repo.
When pointing to a local file, make sure to use **absolute path**, i.e. /home/swagger/compute.json.
When pointing to a file in the `azure-rest-api-specs` repo, make sure to include the commit id in the URI, i.e. `https://github.com/Azure/azure-rest-api-specs/blob/73a0fa453a93bdbe8885f87b9e4e9fef4f0452d0/specification/webpubsub/data-plane/WebPubSub/stable/2021-10-01/webpubsub.json`. This ensures that you can choose the time to upgrade to new swagger file versions.

 .PARAMETER readme
The address of the readme configuration file. The configuration can be local file, e.g. ./swagger/readme.md or the web address of the file in the `azure-rest-api-specs` repo, i.e. `https://github.com/Azure/azure-rest-api-specs/blob/23dc68e5b20a0e49dd3443a4ab177d9f2fcc4c2b/specification/deviceupdate/data-plane/readme.md`
You need to provide one of `-inputfiles` and `-readme` parameters. If you provide both, `-inputfiles` will be ignored.

.PARAMETER securityScope
The authentication scope to use if your library supports **Token Credential** authentication.

.PARAMETER securityHeaderName
The key to use if your library supports **Azure Key Credential** authentication.

.EXAMPLE
Run script with default parameters.

Invoke-AutorestDataPlaneGenerateSDKPackage.ps1 -service <servicename> -namespace Azure.<group>.<service> -sdkPath <sdkrepoRootPath> [-inputfiles <inputfilelink>] [-readme <readmeFilelink>] [-securityScope <securityScope>] [-securityHeaderName <securityHeaderName>]

e.g.
Invoke-AutorestDataPlaneGenerateSDKPackage.ps1 -service webpubsub -namespace Azure.Messaging.WebPubSub -sdkPath /home/azure-sdk-for-net -inputfiles https://github.com/Azure/azure-rest-api-specs/blob/73a0fa453a93bdbe8885f87b9e4e9fef4f0452d0/specification/webpubsub/data-plane/WebPubSub/stable/2021-10-01/webpubsub.json -securityScope https://sample/.default

#>
param (
  [string]$service,
  [string]$namespace,
  [string]$sdkPath,
  [string]$inputfiles="", #input files, separated by semicolon if more than one
  [string]$readme = "",
  [string]$securityScope="",
  [string]$securityHeaderName="",
  [string]$AUTOREST_CONFIG_FILE = "autorest.md"
)
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)
$sdkPath = Resolve-Path $sdkPath
# Generate dataplane library
$outputJsonFile = "newpackageoutput.json"
Update-DataPlanePackageFolder -service $service -namespace $namespace -sdkPath $sdkPath -inputfiles $inputfiles -readme $readme -securityScope $securityScope -securityHeaderName $securityHeaderName -AUTOREST_CONFIG_FILE $AUTOREST_CONFIG_FILE -outputJsonFile $outputJsonFile
if ( $? -ne $True) {
  Write-Error "Failed to create sdk project folder. exit code: $?"
  exit 1
}
$outputJson = Get-Content $outputJsonFile | Out-String | ConvertFrom-Json
$projectFolder = $outputJson.projectFolder
$projectFolder = $projectFolder -replace "\\", "/"

Write-Host "projectFolder:$projectFolder"
Remove-Item $outputJsonFile
# Generate Code
$srcPath = Join-Path $projectFolder 'src'
dotnet build /t:GenerateCode $srcPath
if ( !$? ) {
  Write-Error "Failed to generate sdk."
  exit 1
}
# Build
dotnet build $projectFolder
if ( !$? ) {
  Write-Error "Failed to build sdk. exit code: $?"
  exit 1
}
# Generate APIs
$repoRoot = (Join-Path $PSScriptRoot .. .. ..)
Push-Location $repoRoot
pwsh eng/scripts/Export-API.ps1 $service
Pop-Location
exit 0
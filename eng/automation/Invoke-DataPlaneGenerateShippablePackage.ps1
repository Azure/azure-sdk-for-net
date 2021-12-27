#Requires -Version 7.0
param (
  [string]$resourceProvider = "deviceupdate",
  [string]$ServiceGrouop = "IoT2",
  [string]$packageName = "DeviceUpdate",
  [string]$sdkPath = "D:/project/azure-sdk-for-net",
  [string]$inputfile = "https://github.com/dpokluda/azure-rest-api-specs/blob/be397aa65510bd4e8f87da539af2b0025f6f44ca/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/preview/2020-09-01/deviceupdate.json",
  [string]$securityScope = "https://api.adu.microsoft.com/.default ",
  [string]$AUTOREST_CONFIG_FILE = "autorest.md"
)
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)

# Generate dataplane library
$projectFolder = New-DataPlanePackageFolder -resourceProvider $resourceProvider -ServiceGrouop $ServiceGrouop -packageName $packageName -sdkPath $sdkPath -inputfile $inputfile -securityScope $securityScope -AUTOREST_CONFIG_FILE $AUTOREST_CONFIG_FILE
Invoke-Generate -sdkfolder $projectFolder[-1]
# Generate APIs
$repoRoot = (Join-Path $PSScriptRoot .. ..)
Set-Location $repoRoot
eng\scripts\Export-API.ps1 $resourceProvider
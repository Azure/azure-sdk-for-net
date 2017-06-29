param([string] $specs = "..\..\..\azure-rest-api-specs")

Import-Module "./lib.psm1"

$location = Get-Location

Set-Location $specs
$commit = git rev-parse HEAD
Set-Location $location

$sdkinfo = Read-SdkInfoList -project "*" -sdkInfo '.\sdkinfo.json' -commit $commit

$sdkInfo | ConvertTo-Json | Out-File ".\sdkinfo.lock.json" -Encoding "UTF8"
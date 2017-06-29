param(
    [string] $project = '*',
    [string] $specs = "..\..\..\azure-rest-api-specs",
    [string] $sdkInfo = 'sdkinfo.lock.json')

Import-Module "./lib.psm1"

$infoList = Read-SdkInfoList -project $project -sdkInfo $sdkInfo

$infoList | ForEach-Object { Generate-Sdk -specs $specs -info $_ }

$testProjectList = Get-DotNetTestList $infoList

$testProjectList | ForEach-Object { Build-Project -project $_ }

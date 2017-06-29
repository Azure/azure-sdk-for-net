param(
    [string] $project = '*',
    [string] $specs = "..\..\..\azure-rest-api-specs",
    [string] $sdkInfo = 'sdkinfo.lock.json')

Import-Module "./lib.psm1"

$infoList = Read-SdkInfoList -project $project -sdkInfo $sdkInfo

$testProjectList = Get-DotNetTestList $infoList | Get-Unique

$testProjectList | ForEach-Object {
    "Testing $_"
    dotnet test -l trx $_
    if (-Not $?)
    {
        Write-Error "test errors"
        exit $LASTEXITCODE
    }    
}

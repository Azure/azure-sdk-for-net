param([string] $project = '*')

Import-Module "./lib.psm1"

$infoList = Read-SdkInfoList -project $project -sdkInfo 'sdkinfo.lock.json'

$testProjectList = Get-DotNetTestList $infoList

$testProjectList | ForEach-Object {
    "Testing $_"
    dotnet test -l trx $_
    if (-Not $?)
    {
        Write-Error "test errors"
        exit $LASTEXITCODE
    }
}

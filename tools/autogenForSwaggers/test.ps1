param([string] $project = '*', [string] $sdkDir = "..\..")

Import-Module "./lib.psm1"

$sdkInfoLock = Get-SdkInfoLockPath -sdkDir $sdkDir

$infoList = Read-SdkInfoList -project $project -sdkInfo $sdkInfoLock

$testProjectList = Get-DotNetTestList -sdkDir $sdkDir -infoList $infoList

$testProjectList | ForEach-Object {
    "Testing $_"
    dotnet test -l trx $_
    if (-Not $?)
    {
        Write-Error "test errors"
        exit $LASTEXITCODE
    }
}

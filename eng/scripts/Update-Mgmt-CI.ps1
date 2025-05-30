. (Join-Path $PSScriptRoot automation GenerateAndBuildLib.ps1)

$packagesPath = "$PSScriptRoot/../../sdk"

#add path for each mgmt library into Azure.ResourceManager
RegisterMgmtSDKToMgmtCoreClient -packagesPath $packagesPath


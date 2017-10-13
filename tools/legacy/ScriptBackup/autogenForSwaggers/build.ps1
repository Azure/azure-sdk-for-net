param(
    [string] $project = '*',
    [string] $specs = "https://github.com/Azure/azure-rest-api-specs",
    [string] $sdkDir = "..\..",
    [string] $jsonRpc)

Import-Module "./lib.psm1"

$jsonRpcBool = if ($jsonRpc) { $true } else { $false }

GenerateAndBuild -project $project -specs $specs -sdkDir $sdkDir -jsonRpc $jsonRpcBool
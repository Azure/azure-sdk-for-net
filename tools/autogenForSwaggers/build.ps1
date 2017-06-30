param(
    [string] $project = '*',
    [string] $specs = "https://github.com/Azure/azure-rest-api-specs",
    [string] $sdkDir = "..\..",
    [bool] $jsonRpc)

Import-Module "./lib.psm1"

GenerateAndBuild -project $project -specs $specs -sdkDir $sdkDir -jsonRpc $jsonRpc
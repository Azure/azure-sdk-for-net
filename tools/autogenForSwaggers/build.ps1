param(
    [string] $project = '*',
    [string] $specs = "https://github.com/Azure/azure-rest-api-specs",
    [string] $sdkDir = "..\..")

Import-Module "./lib.psm1"

GenerateAndBuild -project $project -specs $specs -sdkDir $sdkDir

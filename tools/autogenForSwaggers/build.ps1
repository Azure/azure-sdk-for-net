param(
    [string] $project = '*',
    [string] $specs = "https://github.com/Azure/azure-rest-api-specs")

Import-Module "./lib.psm1"

GenerateAndBuild -project $project -specs $specs

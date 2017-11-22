param([string] $specs = "https://github.com/Azure/azure-rest-api-specs", [string] $sdkDir = "..\..\")

Import-Module "./lib.psm1"

UpdateSdkInfo -specs $specs -sdkDir $sdkDir
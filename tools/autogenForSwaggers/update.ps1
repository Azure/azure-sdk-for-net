param([string] $specs = "https://github.com/Azure/azure-rest-api-specs", [string] $sdkDir = "..\..\")

Import-Module "./lib.psm1"

$location = Get-Location

$commit = if (Is-Url -specs $specs) {
    $line = git ls-remote $specs master
    $line.Split("`t")[0]
} else {
    Set-Location $specs
    git rev-parse HEAD
    Set-Location $location
}

$sdkinfo = Read-SdkInfoList -project "*" -sdkInfo (Get-SdkInfoPath $sdkDir) -commit $commit

$sdkInfo | ConvertTo-Json | Out-File (Get-SdkInfoLockPath $sdkDir) -Encoding "UTF8"
#Requires -Version 7.0
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
$swaggerDir = $swaggerDir -replace "\\", "/"
$readmeFile = $inputJson.relatedReadmeMdFile
$readmeFile = $readmeFile -replace "\\", "/"
$commitid = $inputJson.headSha
$repoHttpsUrl = $inputJson.repoHttpsUrl
$serviceType = $inputJson.serviceType
$autorestConfig = $inputJson.autorestConfig

Write-Host "swaggerDir:$swaggerDir, readmeFile:$readmeFile"

# $service, $serviceType = Get-ResourceProviderFromReadme $readmeFile
$sdkPath =  (Join-Path $PSScriptRoot .. .. ..)
$sdkPath = Resolve-Path $sdkPath
$sdkPath = $sdkPath -replace "\\", "/"

$readme = ""
if ($commitid -ne "") {
  if ($repoHttpsUrl -ne "") {
    $readme = "$repoHttpsUrl/blob/$commitid/$readmeFile"
  } else {
    $readme = "https://github.com/$org/azure-rest-api-specs/blob/$commitid/$readmeFile"
  }
} else {
  $readme = (Join-Path $swaggerDir $readmeFile)
}
# $generatedSDKPackages = @()
$generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'
# $generatedSDKPackages = New-Object 'System.Collections.ArrayList[System.Object]'
Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfig" -generatedSDKPackages $generatedSDKPackages
$outputJson = [PSCustomObject]@{
  packages = $generatedSDKPackages
}
$outputJson
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
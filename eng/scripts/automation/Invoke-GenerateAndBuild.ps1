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

$autorestConfig = $inputJson.autorestConfig

$autorestConfigYaml = ""
if ($autorestConfig -ne "") {
    $autorestConfig | Set-Content "config.md"
    $autorestConfigYaml = Get-Content -Path .\config.md
    $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
    if ( $range.count -gt 1) {
        $startNum = $range[0];
        $lines = $range[1] - $range[0] - 1
        $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
    }
    Install-Module -Name powershell-yaml -Force -Verbose -Scope CurrentUser
    Import-Module powershell-yaml
    $yml = ConvertFrom-YAML $autorestConfigYaml
    $requires = $yml["require"]
    if ($requires.Count -gt 0) {
        $readmeFile = $requires[0]
    }
}

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

$generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'
Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfigYaml" -generatedSDKPackages $generatedSDKPackages
$outputJson = [PSCustomObject]@{
  packages = $generatedSDKPackages
}
$outputJson
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
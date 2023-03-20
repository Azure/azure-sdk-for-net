#Requires -Version 7.0
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
if($swaggerDir) {
  $swaggerDir = Resolve-Path $swaggerDir
}
$swaggerDir = $swaggerDir -replace "\\", "/"
$readmeFile = $inputJson.relatedReadmeMdFile
$readmeFile = $readmeFile -replace "\\", "/"
$commitid = $inputJson.headSha
$repoHttpsUrl = $inputJson.repoHttpsUrl
$serviceType = $inputJson.serviceType
$downloadUrlPrefix = $inputJson.installInstructionInput.downloadUrlPrefix
$autorestConfig = $inputJson.autorestConfig

$autorestConfig = $inputJson.autorestConfig
$relatedCadlProjectFolder = $inputJson.relatedCadlProjectFolder

$autorestConfigYaml = ""
if ($autorestConfig) {
    $autorestConfig | Set-Content "config.md"
    $autorestConfigYaml = Get-Content -Path .\config.md
    $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
    if ( $range.count -gt 1) {
        $startNum = $range[0];
        $lines = $range[1] - $range[0] - 1
        $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
    }
    Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
    $yml = ConvertFrom-YAML $autorestConfigYaml
    $requires = $yml["require"]
    if ($requires.Count -gt 0) {
        $readmeFile = $requires[0]
    }
}

$generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'

# $service, $serviceType = Get-ResourceProviderFromReadme $readmeFile
$sdkPath =  (Join-Path $PSScriptRoot .. .. ..)
$sdkPath = Resolve-Path $sdkPath
$sdkPath = $sdkPath -replace "\\", "/"

if ($readmeFile) {
  Write-Host "swaggerDir:$swaggerDir, readmeFile:$readmeFile"

  $readme = ""
  if ($commitid -ne "") {
    if ((-Not $readmeFile.Contains("specification")) -And $swaggerDir.Contains("specification"))
    {
      $readmeFile = "specification/$readmeFile"
    }
    if ($repoHttpsUrl -ne "") {
      $readme = "$repoHttpsUrl/blob/$commitid/$readmeFile"
    } else {
      $readme = "https://github.com/$org/azure-rest-api-specs/blob/$commitid/$readmeFile"
    }
  } else {
    $readme = (Join-Path $swaggerDir $readmeFile)
  }
  Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfigYaml" -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
}

if ($relatedCadlProjectFolder) {
  $typespecFolder = Resolve-Path (Join-Path $swaggerDir $relatedCadlProjectFolder)
  $newPackageOutput = "newPackageOutput.json"

  $tspConfigYaml = Get-Content -Path (Join-Path "$typespecFolder" "tspconfig.yaml") -Raw

  Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
  $yml = ConvertFrom-YAML $tspConfigYaml
  $service = ""
  $namespace = ""
  if ($yml) {
      if ($yml["parameters"] -And $yml["parameters"]["service-directory-name"]) {
          $service = $yml["parameters"]["service-directory-name"]["default"];
      }
      if ($yml["options"] -And $yml["options"]["@azure-tools/typespec-csharp"] -And $yml["options"]["@azure-tools/typespec-csharp"]["namespace"]) {
          $namespace = $yml["options"]["@azure-tools/typespec-csharp"]["namespace"]
      }
  }
  if (!$service || !$namespace) {
      throw "Not provide service name or namespace."
  }
  $projectFolder = (Join-Path $sdkPath "sdk" $service $namespace)
  $specRoot = $swaggerDir
  if ((-Not $relatedCadlProjectFolder.Contains("specification")) -And $swaggerDir.Contains("specification"))
  {
    $relatedCadlProjectFolder = "specification/$relatedCadlProjectFolder"
    $specRoot = Split-Path $specRoot
  }
  New-TypeSpecPackageFolder `
      -service $service `
      -namespace $namespace `
      -sdkPath $sdkPath `
      -relatedTypeSpecProjectFolder $relatedCadlProjectFolder `
      -specRoot $specRoot `
      -outputJsonFile $newpackageoutput
  $newPackageOutputJson = Get-Content $newPackageOutput -Raw | ConvertFrom-Json
  $relativeSdkPath = $newPackageOutputJson.path
  GeneratePackage `
      -projectFolder $projectFolder `
      -sdkRootPath $sdkPath `
      -path $relativeSdkPath `
      -downloadUrlPrefix $downloadUrlPrefix `
      -serviceType "data-plane" `
      -generatedSDKPackages $generatedSDKPackages
}
$outputJson = [PSCustomObject]@{
  packages = $generatedSDKPackages
}
$outputJson
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
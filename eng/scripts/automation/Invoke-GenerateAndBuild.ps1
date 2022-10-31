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

if ($readmeFile) {
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
  Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfigYaml" -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
}

if ($relatedCadlProjectFolder) {
  $caldFolder = (Join-Path $swaggerDir $relatedCadlProjectFolder) -replace "\\", "/"
  $newPackageOutput = "newPackageOutput.json"

  Push-Location $caldFolder
  $cadlProjectYaml = Get-Content -Path "$caldFolder/cadl-project.yaml" -Raw

  Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
  $yml = ConvertFrom-YAML $cadlProjectYaml
  $sdkFolder = $yml["emitters"]["@azure-tools/cadl-csharp"]["sdk-folder"]
  $projectFolder = (Join-Path $sdkPath $sdkFolder)
  $projectFolder = $projectFolder -replace "\\", "/"
  if ($projectFolder) {
      $directories = $projectFolder.Split("/");
      $count = $directories.Count
      $projectFolder = $directories[0 .. ($count-2)] -join "/"
      $service = $directories[-3];
      $namespace = $directories[-2];
  }
  New-CADLPackageFolder -service $service -namespace $namespace -sdkPath $sdkPath -cadlInput $caldFolder/main.cadl -outputJsonFile $newpackageoutput
  $newPackageOutputJson = Get-Content $newPackageOutput | Out-String | ConvertFrom-Json
  $relativeSdkPath = $newPackageOutputJson.path
  # node $swaggerDir/node_modules/@cadl-lang/compiler/cmd/cadl.js compile --emit @azure-tools/cadl-csharp --output-path $sdkPath .\main.cadl

  # node $swaggerDir/node_modules/@cadl-lang/compiler/cmd/cadl.js compile --output-path $sdkPath --emit @azure-tools/cadl-csharp ./main.cadl
  npm install
  npx cadl compile --output-path $sdkPath --emit @azure-tools/cadl-csharp .
  if ( !$?) {
      Throw "Failed to generate sdk for cadl. exit code: $?"
  }
  GeneratePackage -projectFolder $projectFolder -sdkRootPath $sdkPath -path $relativeSdkPath -downloadUrlPrefix "$downloadUrlPrefix" -skipGenerate -generatedSDKPackages $generatedSDKPackages
  Pop-Location
}
$outputJson = [PSCustomObject]@{
  packages = $generatedSDKPackages
}
$outputJson
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
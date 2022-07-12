#Requires -Version 7.0
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

. (Join-Path $PSScriptRoot automation GenerateAndBuildLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
$swaggerDir = Resolve-Path $swaggerDir
$swaggerDir = $swaggerDir -replace "\\", "/"
[string[]] $inputFilePaths = $inputJson.changedFiles;
$readmeFiles = $inputJson.relatedReadmeMdFiles
$commitid = $inputJson.headSha
$repoHttpsUrl = $inputJson.repoHttpsUrl
$downloadUrlPrefix = $inputJson.installInstructionInput.downloadUrlPrefix
[string] $autorestConfig = $inputJson.autorestConfig

$autorestConfigYaml = ""
if ( $null -ne $autorestConfig -and $autorestConfig -ne "") {
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
        $readmeFiles = $requires
    }
}

$generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'

$sdkPath =  (Join-Path $PSScriptRoot .. ..)
$sdkPath = Resolve-Path $sdkPath
$sdkPath = $sdkPath -replace "\\", "/"
for ($i = 0; $i -le $readmeFiles.Count - 1; $i++) {
    $readmeFile = $readmeFiles[$i] -replace "\\", "/"
    $readme = ""
    if ( $swaggerDir) {
        $readme = (Join-Path $swaggerDir $readmeFile)
    } elseif ( $commitid) {
        if ($repoHttpsUrl) {
            $readme = "$repoHttpsUrl/blob/$commitid/$readmeFile"
        } else {
            $readme = "https://github.com/$org/azure-rest-api-specs/blob/$commitid/$readmeFile"
        }
    } else {
        throw "No readme File path provided."
    }

    if ($autorestConfigYaml) {
        $readmeFiles[$i] = $readme
        $autorestConfigYaml = ConvertTo-YAML $yml
    }
    Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfigYaml" -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
}

#update services without readme.md
[System.Collections.ArrayList] $serviceWithReadme = @()
foreach( $readme in $readmeFiles) {
    $service, $serviceType = Get-ResourceProviderFromReadme $readme
    $serviceWithReadme.Add($service)
}
[System.Collections.ArrayList] $inputFileToGen = @()
foreach( $file in $inputFilePaths) {
    $file -match "specification/(?<specName>.*)/data-plane|resource-manager"
    if (!$serviceWithReadme.Contains($matches["specName"])) {
        $inputFileToGen.Add($file)
    }
}

if ($inputFileToGen) {
    UpdateExistingSDKByInputFiles -inputFilePaths $inputFileToGen -sdkRootPath $sdkPath -headSha $commitid -repoHttpsUrl $repoHttpsUrl -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
}

$outputJson = [PSCustomObject]@{
    packages = $generatedSDKPackages
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
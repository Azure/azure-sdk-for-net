#Requires -Version 7.0
<#
.SYNOPSIS
script for azure-sdk-for-net CI check in Unified Pipeline

.DESCRIPTION
Automatically generate and verify the SDK for both management-plane and data-plane.
Unified pipeline will run this script.

.PARAMETER inputJsonFile
Path to the input json file to contain all the input paramters.

.PARAMETER outputJsonFile
Path to the script output json file.

.EXAMPLE
Run script with default parameters.

Invoke-GenerateAndBuildV2.ps1 -inputJsonFile <inputJsonFile> -outputJsonFile <outputJsonFile>

please refer to eng/scripts/automation/unified-pipeline-test.md for more test scenaros and the sample inputJson and outputJson.

#>
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

. (Join-Path $PSScriptRoot ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
. (Join-Path $PSScriptRoot automation GenerateAndBuildLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
if($swaggerDir) {
    $swaggerDir = Resolve-Path $swaggerDir
}
$swaggerDir = $swaggerDir -replace "\\", "/"
[string[]] $inputFilePaths = $inputJson.changedFiles;
$readmeFiles = $inputJson.relatedReadmeMdFiles
$commitid = $inputJson.headSha
$repoHttpsUrl = $inputJson.repoHttpsUrl
$downloadUrlPrefix = $inputJson.installInstructionInput.downloadUrlPrefix
$autorestConfig = $inputJson.autorestConfig
$relatedTypeSpecProjectFolder = $inputJson.relatedTypeSpecProjectFolder

$autorestConfigYaml = ""
if ($autorestConfig) {
    $autorestConfig | Set-Content "config.md"
    $autorestConfigYaml = Get-Content -Path ./config.md
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
$serviceWithReadme = @()
foreach( $readme in $readmeFiles) {
    $service, $serviceType = Get-ResourceProviderFromReadme $readme
    $serviceWithReadme += @($service)
}
$inputFileToGen = @()
foreach( $file in $inputFilePaths) {
    if ( $file -match "specification/(?<specName>.*)/data-plane|resource-manager" ) {
        if (!$serviceWithReadme.Contains($matches["specName"])) {
            $inputFileToGen += @($file)
        }
    }

}

if ($inputFileToGen) {
    UpdateExistingSDKByInputFiles -inputFilePaths $inputFileToGen -sdkRootPath $sdkPath -headSha $commitid -repoHttpsUrl $repoHttpsUrl -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
}

# generate sdk from typespec file
if ($relatedTypeSpecProjectFolder) {
    foreach ($typespecRelativeFolder in $relatedTypeSpecProjectFolder) {
        $typespecFolder = Resolve-Path (Join-Path $swaggerDir $typespecRelativeFolder)
        $processScript = Resolve-Path (Join-Path $sdkPath "eng/common/scripts" "TypeSpec-Project-Process.ps1")
        $sdkProjectFolders = Get-ChildItem -Path (Join-Path $sdkPath "sdk") -Depth 1 -Directory | Select-Object -ExpandProperty FullName

        # Invoke Process script. SkipSyncAndGenerate only when it's not a new SDK project
        $sdkProjectFolder = & $processScript $typespecFolder $commitid $repoHttpsUrl -SkipSyncAndGenerate
        if ($LASTEXITCODE) {
          # If Process script call fails, then return with failure to CI and don't need to call GeneratePackage
          $generatedSDKPackages.Add(@{
            result = "failed";
            path=@("");
          })
        } else {
            $relativeSdkPath = Resolve-Path $sdkProjectFolder -Relative
            if ($sdkProjectFolders -contains $sdkProjectFolder) {
              # Existed SDK project case, needs to generate code
              GeneratePackage `
              -projectFolder $sdkProjectFolder `
              -sdkRootPath $sdkPath `
              -path $relativeSdkPath `
              -downloadUrlPrefix $downloadUrlPrefix `
              -serviceType "data-plane" `
              -generatedSDKPackages $generatedSDKPackages `
              -specRepoRoot $swaggerDir
            } else {
              # New SDK project case, code is already generated by emitter. So, skip code generation
              GeneratePackage `
              -projectFolder $sdkProjectFolder `
              -sdkRootPath $sdkPath `
              -path $relativeSdkPath `
              -downloadUrlPrefix $downloadUrlPrefix `
              -serviceType "data-plane" `
              -skipGenerate `
              -generatedSDKPackages $generatedSDKPackages `
              -specRepoRoot $swaggerDir
            }
        }
    }
}
$outputJson = [PSCustomObject]@{
    packages = $generatedSDKPackages
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile

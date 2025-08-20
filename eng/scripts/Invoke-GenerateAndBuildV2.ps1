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
        throw "[ERROR] Neither 'specFolder' nor 'headSha' is provided for `$readmeFile`. Please report this issue through https://aka.ms/azsdk/support/specreview-channel and include this pull request."
    }

    if ($autorestConfigYaml) {
        $readmeFiles[$i] = $readme
        $autorestConfigYaml = ConvertTo-YAML $yml
    }
    Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfigYaml" -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
    $generatedSDKPackages[$generatedSDKPackages.Count - 1]['readmeMd'] = @($readmeFile)
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

$exitCode = 0
# generate sdk from typespec file
if ($relatedTypeSpecProjectFolder) {
    foreach ($typespecRelativeFolder in $relatedTypeSpecProjectFolder) {
        $typespecFolder = Resolve-Path (Join-Path $swaggerDir $typespecRelativeFolder)
        $tspConfigFile = Resolve-Path (Join-Path $typespecFolder "tspconfig.yaml")
        $sdkProjectFolder = GetSDKProjectFolder -typespecConfigurationFile $tspConfigFile -sdkRepoRoot $sdkPath
        $sdkAutorestConfigFile = Join-path $sdkProjectFolder "src" "autorest.md"
        if (Test-Path -Path $sdkAutorestConfigFile) {
            Write-Host "remove $sdkAutorestConfigFile for sdk from typespec."
            Remove-Item -Path $sdkAutorestConfigFile
        }
        $serviceType = "data-plane"
        $packageName = Split-Path $sdkProjectFolder -Leaf
        if ($packageName.StartsWith("Azure.ResourceManager.")) {
            $serviceType = "resource-manager"
        }
        $repo = $repoHttpsUrl -replace "https://github.com/", ""
        Write-host "Start to call tsp-client to generate package:$packageName"
        $tspclientCommand = "npx --package=@azure-tools/typespec-client-generator-cli --yes tsp-client init --update-if-exists --tsp-config $tspConfigFile --repo $repo --commit $commitid"
        if ($swaggerDir) {
            $tspclientCommand += " --local-spec-repo $typespecFolder"
        }
        Write-Host $tspclientCommand
        Invoke-Expression $tspclientCommand
        if ($LASTEXITCODE) {
          # If Process script call fails, then return with failure to CI and don't need to call GeneratePackage
          Write-Host "[ERROR] Failed to generate typespec project:$typespecFolder. Exit code: $LASTEXITCODE. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
          $generatedSDKPackages.Add(@{
            result = "failed";
            path=@("");
          })
          $exitCode = $LASTEXITCODE
        } else {
            $relativeSdkPath = Resolve-Path $sdkProjectFolder -Relative
            GeneratePackage `
            -projectFolder $sdkProjectFolder `
            -sdkRootPath $sdkPath `
            -path $relativeSdkPath `
            -downloadUrlPrefix $downloadUrlPrefix `
            -serviceType $serviceType `
            -skipGenerate `
            -generatedSDKPackages $generatedSDKPackages `
            -specRepoRoot $swaggerDir
        }
        $generatedSDKPackages[$generatedSDKPackages.Count - 1]['typespecProject'] = @($typespecRelativeFolder)
    }
}
$outputJson = [PSCustomObject]@{
    packages = $generatedSDKPackages
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
exit $exitCode

#Requires -Version 7.0
<#
.How-To-Run
You can run the test by pester.

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./GenerateAndBuildLib-functions.tests.ps1`

#>
. (Join-Path $PSScriptRoot ".." ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)

Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

BeforeAll {
    . $PSScriptRoot/../GenerateAndBuildLib.ps1
}

Describe "update autorest.md" -Tag "UnitTest" {
    BeforeAll {
        copy-item -Path $PSScriptRoot/autorest.test.md -Destination $PSScriptRoot/autorest.md
    }

    it("set multiple input-file") {
        $inputfiles = "https://github.com/Azure/azure-rest-api-specs/blob/b2bddfe2e59b5b14e559e0433b6e6d057bcff95d/specification/purview/data-plane/Azure.Analytics.Purview.Account/preview/2019-11-01-preview/account.json;https://github.com/Azure/azure-rest-api-specs/blob/1424fc4a1f82af852a626c6ab6d1d296b5fe4df1/specification/purview/data-plane/Azure.Analytics.Purview.MetadataPolicies/preview/2021-07-01/purviewMetadataPolicy.json"

        $inputfile = ""
        $fileArray = $inputfiles.Split(";")
        if (($inputfiles -ne "") -And ($fileArray.Length -gt 0)) {
            for ($i = 0; $i -lt $fileArray.Count ; $i++) {
                $inputfile = $inputfile + [Environment]::NewLine + "- " + $fileArray[$i]
            }
        }
        CreateOrUpdateAutorestConfigFile -autorestFilePath $PSScriptRoot/autorest.md -namespace "Azure.Purview.Account" -inputfile "$inputfile"

        $autorestConfigYaml = Get-Content -Path $PSScriptRoot/autorest.md
        $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
        }

        $yml = ConvertFrom-YAML $autorestConfigYaml
        $inputfile_new = $yml["input-file"]

        $inputfile_new.Count | Should -Be 2
        $inputstr = $inputfile_new -join ";"
        $inputstr | Should -Be $inputfiles
    }

    it("set require and replace input-file") {
        $readme = "https://github.com/Azure/azure-rest-api-specs/specification/purview/data-plane/readme.md"

        CreateOrUpdateAutorestConfigFile -autorestFilePath $PSScriptRoot/autorest.md -namespace "Azure.Purview.Account" -readme "$readme"

        $autorestConfigYaml = Get-Content -Path $PSScriptRoot/autorest.md
        $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
        }

        $yml = ConvertFrom-YAML $autorestConfigYaml
        
        $inputfile_new = $yml["input-file"]
        $inputfile_new.Count | Should -Be 0

        $require = $yml["require"]
        $require | Should -Be $readme
    }

    it("combine autorest config") {
        $readme = "https://github.com/Azure/azure-rest-api-specs/specification/purview/data-plane/readme.md"
        $autorestConfigYamlInput = Get-Content -Path $PSScriptRoot/config.md
        $range = ($autorestConfigYamlInput | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYamlInput = ($autorestConfigYamlInput | Select -Skip $startNum | Select -First $lines) |Out-String
        }
        CreateOrUpdateAutorestConfigFile -autorestFilePath $PSScriptRoot/autorest.md -namespace "Azure.Purview.Account" -readme "$readme" -autorestConfigYaml "$autorestConfigYamlInput"

        $autorestConfigYaml = Get-Content -Path $PSScriptRoot/autorest.md
        $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
        if ( $range.count -gt 1) {
            $startNum = $range[0];
            $lines = $range[1] - $range[0] - 1
            $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
        }
        
        $yml = ConvertFrom-YAML $autorestConfigYaml
        
        $title = $yml["title"]
        $title | Should -Be "AzurePurviewAdministration"

        $require = $yml["require"]
        $require | Should -Be $readme
    }
}

# Open an issue to track the disabled tests here: https://github.com/Azure/azure-sdk-for-net/issues/33487
Describe "Generate and Build SDK" -Tag "Unit" {
    BeforeAll {
        $sdkRootPath =  (Join-Path $PSScriptRoot .. .. .. ..)
        $sdkRootPath = Resolve-Path $sdkRootPath
    }
    
    it("generate sdk by readme.md") {
        $readme = "https://github.com/Azure/azure-rest-api-specs/blob/5ee062ac3cc2df298ff47bdfc7792d257fd85bb8/specification/deviceupdate/data-plane/readme.md"

        $generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'
        $downloadUrlPrefix = "https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2/"
        Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkRootPath -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages

        $generatedSDKPackages.Count | Should -Be 1
        $generatedSDKPackages[0].packageName | Should -Be "Azure.IoT.DeviceUpdate"
    }
}
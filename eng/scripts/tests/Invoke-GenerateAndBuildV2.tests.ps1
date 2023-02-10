#Requires -Version 7.0
<#
.How-To-Run
You can run the test by pester.
And make sure you have the azure-rest-api-specs cloned local at the same directory of azure-sdk-for-net repo.

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Invoke-GenerateAndBuildV2.tests.ps1`

#>
. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)

Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Generate And Build SDK" -Tag "pipeline" {
    BeforeAll {
        # . $PSScriptRoot/../Invoke-GenerateAndBuildV2.ps1
        # clean
        $sdkRootPath =  (Join-Path $PSScriptRoot .. .. ..)
        $sdkRootPath = Resolve-Path $sdkRootPath
        $sdkFolder = (Join-Path $sdkRootPath "sdk" "deviceupdate" "Azure.IoT.DeviceUpdate")
        if (Test-Path $sdkFolder) {
            Remove-Item $sdkFolder -Recurse
        }
        $artifactFolder = (Join-Path $sdkRootPath "artifacts" "packages" "Debug" "Azure.IoT.DeviceUpdate")
        if (Test-Path $artifactFolder) {
            Remove-Item $artifactFolder -Recurse
        }
        
        Push-Location $sdkRootPath
    }

    It "scenaro 1: first onboard" {
        & $PSScriptRoot/../Invoke-GenerateAndBuildV2.ps1 -inputJsonFile $PSScriptRoot/firstOnboardInput.json -outputJsonFile $PSScriptRoot/firstOnboardOutput.json
        $outputJson = Get-Content $PSScriptRoot/firstOnboardOutput.json | Out-String | ConvertFrom-Json

        $outputJson.packages.Count | Should -Be 1
        $outputJson.packages[0].packageName | Should -Be "Azure.IoT.DeviceUpdate"
        $outputJson.packages[0].result | Should -Be "succeeded"
        Remove-Item $PSScriptRoot/firstOnboardOutput.json
    }

    It "scenaro 2: update existing SDK without autorest config" {
        & $PSScriptRoot/../Invoke-GenerateAndBuildV2.ps1 -inputJsonFile $PSScriptRoot/updateExistingInput.json -outputJsonFile $PSScriptRoot/updateExistingOutput.json
        $outputJson = Get-Content $PSScriptRoot/updateExistingOutput.json | Out-String | ConvertFrom-Json

        $outputJson.packages.Count | Should -Be 1
        $outputJson.packages[0].packageName | Should -Be "Azure.IoT.DeviceUpdate"
        $outputJson.packages[0].result | Should -Be "succeeded"
    }

    It "scenaro 2: update existing SDK with autorest config" {
        & $PSScriptRoot/../Invoke-GenerateAndBuildV2.ps1 -inputJsonFile $PSScriptRoot/updateExistingWithConfigInput.json -outputJsonFile $PSScriptRoot/updateExistingWithConfigOutput.json
        $outputJson = Get-Content $PSScriptRoot/updateExistingWithConfigOutput.json | Out-String | ConvertFrom-Json

        $outputJson.packages.Count | Should -Be 1
        $outputJson.packages[0].packageName | Should -Be "Azure.IoT.DeviceUpdate"
        $outputJson.packages[0].result | Should -Be "succeeded"

        $autorestConfigFile = (Join-Path $PSScriptRoot .. .. .. "sdk" "deviceupdate" "Azure.IoT.DeviceUpdate" "src" "autorest.md")
        $autorestConfig = Get-Content $autorestConfigFile -Raw
        $autorestConfig -match "title: AzureDeviceUpdate" | Should -Be True
    }
    AfterAll {
        Pop-Location
    }
}
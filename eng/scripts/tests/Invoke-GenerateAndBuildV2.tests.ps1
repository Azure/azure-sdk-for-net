#Requires -Version 7.0
. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)

Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Generate And Build SDK" -Tag "pipeline" {
    BeforeAll {
        # . $PSScriptRoot/../Invoke-GenerateAndBuildV2.ps1
        # clean
        $sdkRootPath =  (Join-Path $PSScriptRoot .. .. ..)
        $sdkFolder = (Join-Path $sdkRootPath "sdk" "deviceupdate" "Azure.IoT.DeviceUpdate")
        if (Test-Path $sdkFolder) {
            Remove-Item $sdkFolder -Recurse
        }
        $artifactFolder = (Join-Path $sdkRootPath "artifacts" "packages" "Debug" "Azure.IoT.DeviceUpdate")
        if (Test-Path $artifactFolder) {
            Remove-Item $artifactFolder -Recurse
        }
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
}
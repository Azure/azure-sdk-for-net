#Requires -Version 7.0
<#
.How-To-Run
Invoke-Pester -Output Detailed $PSScriptRoot/Azure-Spector-Helper.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
    $scriptsDirectory = Join-Path $PSScriptRoot ".." ".." "packages" "http-client-csharp" "eng" "scripts"
    $spectorModule = Import-Module (Join-Path $scriptsDirectory "Spector-Helper.psm1") -DisableNameChecking -Force -PassThru
    $generationModule = Import-Module (Join-Path $scriptsDirectory "Generation.psm1") -DisableNameChecking -Force -PassThru

    function New-SpectorSpec {
        param(
            [string]$Root,
            [string[]]$Segments,
            [switch]$ClientSpec,
            [switch]$ClientOnly
        )

        $directory = Join-Path $Root "specs"
        foreach ($segment in $Segments) {
            $directory = Join-Path $directory $segment
        }
        New-Item -Path $directory -ItemType Directory -Force | Out-Null
        if (-not $ClientOnly) {
            Set-Content (Join-Path $directory "main.tsp") "// Test fixture."
        }
        if ($ClientSpec -or $ClientOnly) {
            Set-Content (Join-Path $directory "client.tsp") "// Test fixture."
        }
        return $directory
    }
}

AfterAll {
    Remove-Module $spectorModule, $generationModule
}

Describe "Azure data-plane Spector discovery" -Tag "UnitTest" {
    BeforeEach {
        $fixtureRoot = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $standardSpecsDirectory = Join-Path $fixtureRoot "http-specs"
        $azureSpecsDirectory = Join-Path $fixtureRoot "azure-http-specs"
        New-Item -Path (Join-Path $standardSpecsDirectory "specs"), (Join-Path $azureSpecsDirectory "specs") -ItemType Directory -Force | Out-Null

        Mock Get-Specs-Directory -ModuleName Spector-Helper { $standardSpecsDirectory }
        Mock Get-Azure-Specs-Directory -ModuleName Spector-Helper { $azureSpecsDirectory }
    }

    It "excludes the management scenario <Scenario>" -TestCases @(
        @{ Scenario = "common-properties" }
        @{ Scenario = "non-resource" }
        @{ Scenario = "operation-templates" }
        @{ Scenario = "resources" }
        @{ Scenario = "large-header" }
        @{ Scenario = "method-subscription-id" }
        @{ Scenario = "multi-service" }
        @{ Scenario = "multi-service-shared-models" }
        @{ Scenario = "multi-service-older-versions" }
        @{ Scenario = "management-group" }
        @{ Scenario = "service-group" }
    ) {
        param($Scenario)

        New-SpectorSpec $azureSpecsDirectory @("azure", "resource-manager", $Scenario) | Out-Null

        @(Get-Sorted-Specs) | Should -BeNullOrEmpty
    }

    It "excludes service-group even when client.tsp is present" {
        New-SpectorSpec $azureSpecsDirectory @("azure", "resource-manager", "service-group") -ClientSpec | Out-Null

        @(Get-Sorted-Specs) | Should -BeNullOrEmpty
    }

    It "preserves neighboring Azure and standard data-plane scenarios and client.tsp preference" {
        New-SpectorSpec $azureSpecsDirectory @("azure", "resource-manager", "service-group") -ClientSpec | Out-Null
        $azureCore = New-SpectorSpec $azureSpecsDirectory @("azure", "core", "basic")
        $clientGenerator = New-SpectorSpec $azureSpecsDirectory @("azure", "client-generator-core", "access") -ClientSpec
        $standard = New-SpectorSpec $standardSpecsDirectory @("type", "array")

        @(Get-Sorted-Specs) | Should -Be @(
            (Join-Path $clientGenerator "client.tsp")
            (Join-Path $azureCore "main.tsp")
            (Join-Path $standard "main.tsp")
        )
    }

    It "does not broaden the exclusion to similarly named scenarios" {
        $similarName = New-SpectorSpec $azureSpecsDirectory @("azure", "resource-manager", "service-group-extra")
        $otherCategory = New-SpectorSpec $azureSpecsDirectory @("azure", "core", "service-group")

        @(Get-Sorted-Specs) | Should -Be @(
            (Join-Path $otherCategory "main.tsp")
            (Join-Path $similarName "main.tsp")
        )
    }

    It "still excludes existing unsupported data-plane scenarios" {
        New-SpectorSpec $standardSpecsDirectory @("response", "status-code-range") | Out-Null
        New-SpectorSpec $azureSpecsDirectory @("azure", "client-generator-core", "alternate-type") | Out-Null

        @(Get-Sorted-Specs) | Should -BeNullOrEmpty
    }

    It "does not discover directories containing only client.tsp" {
        New-SpectorSpec $azureSpecsDirectory @("azure", "core", "basic") -ClientOnly | Out-Null

        @(Get-Sorted-Specs) | Should -BeNullOrEmpty
    }

    It "does not select service-group with the explicit filter <Filter>" -TestCases @(
        @{ Filter = "http/azure/resource-manager/service-group" }
        @{ Filter = "http\azure\resource-manager\service-group" }
    ) {
        param($Filter)

        New-SpectorSpec $azureSpecsDirectory @("azure", "resource-manager", "service-group") | Out-Null
        New-SpectorSpec $azureSpecsDirectory @("azure", "core", "basic") | Out-Null

        @(Get-Sorted-Specs | Where-Object { Compare-Paths (Get-SubPath $_) $Filter }) | Should -BeNullOrEmpty
    }

    It "still selects a data-plane scenario with the filter <Filter>" -TestCases @(
        @{ Filter = "http/azure/core/basic" }
        @{ Filter = "http\azure\core\basic" }
    ) {
        param($Filter)

        New-SpectorSpec $azureSpecsDirectory @("azure", "resource-manager", "service-group") | Out-Null
        $azureCore = New-SpectorSpec $azureSpecsDirectory @("azure", "core", "basic")

        @(Get-Sorted-Specs | Where-Object { Compare-Paths (Get-SubPath $_) $Filter }) | Should -Be @(
            (Join-Path $azureCore "main.tsp")
        )
    }
}

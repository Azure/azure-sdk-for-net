#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
    $dashboardScript = Join-Path $PSScriptRoot ".." ".." ".." "doc" "GeneratorVersions" "Emitter_Version_Dashboard.ps1"

    function New-VersionFixture(
        [string]$Name,
        [string]$ApprovedVersion,
        [string]$EmitterVersion,
        [string]$GeneratorVersion
    ) {
        $repoRoot = Join-Path $TestDrive $Name
        $azureEmitterDirectory = Join-Path $repoRoot "eng" "packages" "http-client-csharp"
        $managementEmitterDirectory = Join-Path $repoRoot "eng" "packages" "http-client-csharp-mgmt"
        $provisioningEmitterDirectory = Join-Path $repoRoot "eng" "packages" "http-client-csharp-provisioning"
        $centralPackageDirectory = Join-Path $repoRoot "eng" "centralpackagemanagement"

        New-Item -ItemType Directory -Force $azureEmitterDirectory | Out-Null
        New-Item -ItemType Directory -Force $managementEmitterDirectory | Out-Null
        New-Item -ItemType Directory -Force $provisioningEmitterDirectory | Out-Null
        New-Item -ItemType Directory -Force $centralPackageDirectory | Out-Null

        @{
            version = "1.0.0"
            dependencies = @{ "@typespec/http-client-csharp" = "1.0.0-alpha.1" }
        } | ConvertTo-Json -Depth 3 | Set-Content (Join-Path $azureEmitterDirectory "package.json")

        @{
            version = "1.0.0"
            dependencies = @{ "@azure-typespec/http-client-csharp" = $EmitterVersion }
        } | ConvertTo-Json -Depth 3 | Set-Content (Join-Path $managementEmitterDirectory "package.json")

        @{
            version = "1.0.0"
            dependencies = @{ "@azure-typespec/http-client-csharp-mgmt" = "1.0.0-alpha.1" }
        } | ConvertTo-Json -Depth 3 | Set-Content (Join-Path $provisioningEmitterDirectory "package.json")

        @{
            main = "dist/src/index.js"
            dependencies = @{ "@azure-typespec/http-client-csharp" = $ApprovedVersion }
        } | ConvertTo-Json -Depth 3 | Set-Content (Join-Path $repoRoot "eng" "azure-typespec-http-client-csharp-emitter-package.json")

        @"
<Project>
  <PropertyGroup>
    <AzureGeneratorVersion>$GeneratorVersion</AzureGeneratorVersion>
  </PropertyGroup>
</Project>
"@ | Set-Content (Join-Path $centralPackageDirectory "Directory.Generation.Packages.props")

        return $repoRoot
    }
}

Describe "Emitter version dashboard validation" {
    It "accepts emitter and generator versions equal to the approved version" {
        $version = "1.0.0-alpha.20260819.3"
        $repoRoot = New-VersionFixture "equal" $version $version $version

        { & $dashboardScript -RepoRoot $repoRoot -ValidateOnly } | Should -Not -Throw
    }

    It "accepts emitter and generator versions older than the approved version" {
        $approved = "1.0.0-alpha.20260819.3"
        $older = "1.0.0-alpha.20260818.1"
        $repoRoot = New-VersionFixture "older" $approved $older $older

        { & $dashboardScript -RepoRoot $repoRoot -ValidateOnly } | Should -Not -Throw
    }

    It "rejects a management emitter dependency newer than the approved version" {
        $approved = "1.0.0-alpha.20260819.3"
        $newer = "1.0.0-alpha.20260824.2"
        $repoRoot = New-VersionFixture "newer-emitter" $approved $newer $approved

        { & $dashboardScript -RepoRoot $repoRoot -ValidateOnly } |
            Should -Throw "*Management emitter dependency version '$newer' is newer*"
    }

    It "rejects an Azure.Generator dependency newer than the approved version" {
        $approved = "1.0.0-alpha.20260819.3"
        $newer = "1.0.0-alpha.20260824.2"
        $repoRoot = New-VersionFixture "newer-generator" $approved $approved $newer

        { & $dashboardScript -RepoRoot $repoRoot -ValidateOnly } |
            Should -Throw "*Azure.Generator dependency version '$newer' is newer*"
    }
}

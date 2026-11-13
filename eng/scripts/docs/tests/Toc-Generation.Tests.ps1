<#
```
Invoke-Pester -Output Detailed $PSScriptRoot\Toc-Generation.Tests.ps1
```
#>

Import-Module Pester

$nugetAvailable = Get-Command nuget -ErrorAction SilentlyContinue

BeforeAll {
    . $PSScriptRoot/../Docs-ToC.ps1
    . $PSScriptRoot/logging.ps1
}

AfterAll {
    $tempLocation = (Join-Path ([System.IO.Path]::GetTempPath()) "extractNupkg")
    Remove-Item "$tempLocation/*" -Recurse -Force -ErrorAction Ignore
    Remove-Item "$PSScriptRoot/outputs" -Recurse -Force -ErrorAction Ignore
}
# Test plan:
# 1. Tests on Fetch-NamespacesFromNupkg from nuget source. 
# 2. Tests on Fetch-NamespacesFromNupkg from public feeds. 
# 3. Tests on Get-Toc-Children for latest
# 4. Tests on Get-Toc-Children for preview
Describe "Fetch-NamespacesFromNupkg-Nuget" -Tag "UnitTest" -Skip:(!$nugetAvailable) {
    # Passed cases
    It "Fetch namespaces from package downloads from nuget" -TestCases @(
        @{ package = "Azure.Core"; version="1.24.0"; expectNamespaces = @('Azure', 'Azure.Core', 'Azure.Core.Cryptography', 'Azure.Core.Diagnostics', 'Azure.Core.Extensions', 'Azure.Core.GeoJson', 'Azure.Core.Pipeline', 'Azure.Core.Serialization', 'Azure.Messaging') }
        @{ package = "Azure.Template"; version="1.0.3-beta.20201112"; expectNamespaces = @('Azure.Template', 'Azure.Template.Models') }
        @{ package = "Azure.Search.Documents"; version="11.5.0-beta.2"; expectNamespaces = @('Azure.Search.Documents', 'Azure.Search.Documents.Indexes', 'Azure.Search.Documents.Indexes.Models', 'Azure.Search.Documents.Models', 'Microsoft.Extensions.Azure') }
        @{ package = "Azure.Core"; version="1.26.0-alpha.20221102.2"; expectNamespaces = @('Azure', 'Azure.Core', 'Azure.Core.Cryptography', 'Azure.Core.Diagnostics', 'Azure.Core.Extensions', 'Azure.Core.GeoJson', 'Azure.Core.Pipeline', 'Azure.Core.Serialization', 'Azure.Messaging') }
    ) {
        $namespaces = Fetch-NamespacesFromNupkg -package $package -version $version
        $namespaces | Should -Be $expectNamespaces
    }
    # Failed cases
    It "The package does not exist in Nuget" -TestCases @(
        @{ package = "Azure.Core.NotExist"; version="1.24.0" }
        @{ package = "Azure.Core"; version="1.24.0.notexist" }
    ) {
        $namespaces = Fetch-NamespacesFromNupkg -package $package -version $version
        $namespaces | Should -BeNullOrEmpty
    }
}

Describe "Fetch-NamespacesFromNupkg-PublicFeeds" -Tag "UnitTest" -Skip:(!$nugetAvailable) {
    BeforeAll {
        Set-Variable -Name 'PackageSourceOverride' -Value "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json" -ErrorAction 'Ignore'
    }
    # passed cases
    It "Fetch namespaces from package downloads from public feeds" -TestCases @(
        @{ package = "Azure.AI.FormRecognizer"; version="4.1.0-alpha.20221101.1"; expectNamespaces = @('Azure.AI.FormRecognizer', 'Azure.AI.FormRecognizer.DocumentAnalysis', 'Azure.AI.FormRecognizer.Models', 'Azure.AI.FormRecognizer.Training', 'Microsoft.Extensions.Azure') }
        @{ package = "Azure.AI.TextAnalytics"; version="5.3.0-alpha.20221102.2"; expectNamespaces = @('Azure.AI.TextAnalytics', 'Microsoft.Extensions.Azure') }
        @{ package = "Azure.ResourceManager.Advisor"; version="1.0.0-alpha.20221102.1"; expectNamespaces = @('Azure.ResourceManager.Advisor', 'Azure.ResourceManager.Advisor.Models') }
        @{ package = "Azure.Core"; version="1.25.0";expectNamespaces = @('Azure', 'Azure.Core', 'Azure.Core.Cryptography', 'Azure.Core.Diagnostics', 'Azure.Core.Extensions', 'Azure.Core.GeoJson', 'Azure.Core.Pipeline', 'Azure.Core.Serialization', 'Azure.Messaging') }
    ) {
        $namespaces = Fetch-NamespacesFromNupkg -package $package -version $version
        $namespaces | Should -Be $expectNamespaces
    }
    # Failed cases
    It "The package does not exist in Nuget" -TestCases @(
        @{ package = "Azure.Core.NotExist1"; version="1.24.0" }
        @{ package = "Azure.Core"; version="1.24.0.notexist1" }
    ) {
        $namespaces = Fetch-NamespacesFromNupkg -package $package -version $version
        $namespaces | Should -BeNullOrEmpty
    }
    AfterEach {
        Set-Variable -Name 'PackageSourceOverride' -Value "" -ErrorAction 'Ignore'
    }
}

Describe "Get-Toc-Children" -Tag "UnitTest" {
    It "Get toc children from package json" -TestCases @(
        @{ 
            package = "Azure.Security.KeyVault.Secrets";
            expectNamespaces = @('Azure.Security.KeyVault.Secrets', 'Microsoft.Extensions.Azure') 
        }
    ) {
        $namespaces = Get-Toc-Children `
            -package $package `
            -docRepoLocation "$PSScriptRoot/inputs"
        $namespaces | Should -Be $expectNamespaces
    }

    It "Combines ToC children from each moniker" { 
        $namespaces = Get-Toc-Children `
            -package 'Azure.Security.KeyVault.Certificates' `
            -docRepoLocation "$PSScriptRoot/inputs"

        $namespaces | Should -be @(
            'Azure.Security.KeyVault.Certificates',
            'Microsoft.Extensions.Azure'
            'Some.New.Namespace'
        )
    }
}

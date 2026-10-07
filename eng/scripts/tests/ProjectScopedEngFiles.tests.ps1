#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.
For more information about Pester, see: https://pester.dev/docs/quick-start

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./ProjectScopedEngFiles.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
    . (Join-Path $PSScriptRoot ".." "ProjectScopedEngFiles.ps1")

    function New-Pkg([string]$Name) {
        return [PSCustomObject]@{
            Name                  = $Name
            ArtifactName          = $Name
            IncludedForValidation = $false
        }
    }

    function New-Diff {
        param([string[]]$Changed = @(), [string[]]$Deleted = @())
        return [PSCustomObject]@{
            ChangedFiles = $Changed
            DeletedFiles = $Deleted
        }
    }
}

Describe "Get-ProjectNamesFromEngFileChanges" -Tag "UnitTest" {
    It "maps an apicompatbaselines file to its project name" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @("eng/apicompatbaselines/Azure.Identity.txt")
        $names | Should -Be @("Azure.Identity")
    }

    It "maps an analyzerallowlist (NoWarn) file to its project name" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @("eng/analyzerallowlist/Azure.Core.txt")
        $names | Should -Be @("Azure.Core")
    }

    It "maps a centralpackagemanagement override to its project name" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @("eng/centralpackagemanagement/overrides/Azure.ResourceManager.Network.Packages.props")
        $names | Should -Be @("Azure.ResourceManager.Network")
    }

    It "handles backslash-separated paths" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @("eng\apicompatbaselines\Azure.Identity.txt")
        $names | Should -Be @("Azure.Identity")
    }

    It "ignores files that are not in a project-scoped eng folder" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @(
            "eng/scripts/Update-PkgVersion.ps1",
            "sdk/core/Azure.Core/src/Azure.Core.csproj",
            "eng/apicompatbaselines/README.md"
        )
        $names | Should -BeNullOrEmpty
    }

    It "ignores nested files below the project-scoped folder" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @("eng/apicompatbaselines/subdir/Azure.Identity.txt")
        $names | Should -BeNullOrEmpty
    }

    It "de-duplicates repeated project names" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @(
            "eng/apicompatbaselines/Azure.Identity.txt",
            "eng/analyzerallowlist/Azure.Identity.txt"
        )
        @($names) | Should -Be @("Azure.Identity")
    }

    It "returns nothing for empty input" {
        $names = Get-ProjectNamesFromEngFileChanges -ChangedFiles @()
        $names | Should -BeNullOrEmpty
    }
}

Describe "Get-PackagesFromEngFileChanges" -Tag "UnitTest" {
    It "returns the package matching a changed baseline file" {
        $all = @((New-Pkg "Azure.Identity"), (New-Pkg "Azure.Core"))
        $diff = New-Diff -Changed @("eng/apicompatbaselines/Azure.Identity.txt")

        $result = Get-PackagesFromEngFileChanges -DiffObj $diff -AllPkgProps $all

        @($result).Count | Should -Be 1
        $result[0].Name | Should -Be "Azure.Identity"
    }

    It "includes packages referenced only in DeletedFiles (baseline removal)" {
        $all = @((New-Pkg "Azure.Identity"), (New-Pkg "Azure.Core"))
        $diff = New-Diff -Deleted @("eng/apicompatbaselines/Azure.Identity.txt")

        $result = Get-PackagesFromEngFileChanges -DiffObj $diff -AllPkgProps $all

        @($result).Count | Should -Be 1
        $result[0].Name | Should -Be "Azure.Identity"
    }

    It "returns every affected package from a mixed change/delete set" {
        $all = @(
            (New-Pkg "Azure.Identity"),
            (New-Pkg "Azure.Core"),
            (New-Pkg "Azure.ResourceManager.Network")
        )
        $diff = New-Diff `
            -Changed @("eng/analyzerallowlist/Azure.Core.txt", "eng/centralpackagemanagement/overrides/Azure.ResourceManager.Network.Packages.props") `
            -Deleted @("eng/apicompatbaselines/Azure.Identity.txt")

        $result = Get-PackagesFromEngFileChanges -DiffObj $diff -AllPkgProps $all

        ($result.Name | Sort-Object) | Should -Be @("Azure.Core", "Azure.Identity", "Azure.ResourceManager.Network")
    }

    It "returns nothing when the file base name matches no known package" {
        $all = @((New-Pkg "Azure.Core"))
        $diff = New-Diff -Deleted @("eng/apicompatbaselines/ApiCompatVersionOptOut.txt")

        $result = Get-PackagesFromEngFileChanges -DiffObj $diff -AllPkgProps $all

        $result | Should -BeNullOrEmpty
    }

    It "matches on ArtifactName when it differs from Name" {
        $pkg = [PSCustomObject]@{ Name = "internal-name"; ArtifactName = "Azure.Special"; IncludedForValidation = $false }
        $diff = New-Diff -Changed @("eng/apicompatbaselines/Azure.Special.txt")

        $result = Get-PackagesFromEngFileChanges -DiffObj $diff -AllPkgProps @($pkg)

        @($result).Count | Should -Be 1
        $result[0].ArtifactName | Should -Be "Azure.Special"
    }
}

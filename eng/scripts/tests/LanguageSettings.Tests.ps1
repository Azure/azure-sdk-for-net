#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Language settings repository dependency selection" -Tag "UnitTest" {
    BeforeAll {
        . (Join-Path $PSScriptRoot ".." "Language-Settings.ps1")
        function Invoke-LoggedMsbuildCommand { param($Command) }
    }

    BeforeEach {
        $global:RepoRoot = $TestDrive
        $changedPackage = [pscustomobject]@{
            Name = "Azure.Changed"
            IncludedForValidation = $false
            DirectoryPath = Join-Path $TestDrive "sdk/changed/Azure.Changed"
        }
        $sourceGraphPackage = [pscustomobject]@{
            Name = "Azure.SourceGraphDependent"
            IncludedForValidation = $false
            DirectoryPath = Join-Path $TestDrive "sdk/source/Azure.SourceGraphDependent"
        }
        $resolvedReferencePackage = [pscustomobject]@{
            Name = "Azure.ResolvedReferenceDependent"
            IncludedForValidation = $false
            DirectoryPath = Join-Path $TestDrive "sdk/resolved/Azure.ResolvedReferenceDependent"
        }
        $allPackages = @($changedPackage, $sourceGraphPackage, $resolvedReferencePackage)

        Mock Get-PackagesFromEngFileChanges { @() }
        Mock Write-Host {}
        Mock Invoke-LoggedMsbuildCommand {
            param($Command)
            if ($Command -like "*repository-source-graph.txt*") {
                $sourceGraphPackage.DirectoryPath | Set-Content (Join-Path $TestDrive "_dependencylist.repository-source-graph.txt")
            } else {
                $resolvedReferencePackage.DirectoryPath | Set-Content (Join-Path $TestDrive "_dependencylist.txt")
            }
        }
    }

    AfterEach {
        Remove-Variable RepoRoot -Scope Global -ErrorAction SilentlyContinue
    }

    It "uses only the repository source graph when it succeeds" {
        $result = @(Get-dotnet-AdditionalValidationPackagesFromPackageSet $changedPackage ([pscustomobject]@{}) $allPackages)

        $result.Name | Should -Be @("Azure.SourceGraphDependent")
        Should -Invoke Invoke-LoggedMsbuildCommand -Times 1 -Exactly
        Should -Invoke Write-Host -Times 1 -Exactly -ParameterFilter {
            $Object -eq "REPOSITORY_DEPENDENCY_AUTHORITY=repository-source-graph selectedRootCount=1"
        }
    }

    It "falls back to ResolveReferences when repository graph evaluation fails" {
        Mock Invoke-LoggedMsbuildCommand {
            param($Command)
            if ($Command -like "*repository-source-graph.txt*") {
                throw "source graph failed"
            }
            $resolvedReferencePackage.DirectoryPath | Set-Content (Join-Path $TestDrive "_dependencylist.txt")
        }

        $result = @(Get-dotnet-AdditionalValidationPackagesFromPackageSet $changedPackage ([pscustomobject]@{}) $allPackages)

        $result.Name | Should -Be @("Azure.ResolvedReferenceDependent")
        Should -Invoke Invoke-LoggedMsbuildCommand -Times 2 -Exactly
        Should -Invoke Write-Host -Times 1 -Exactly -ParameterFilter {
            $Object -match '^##vso\[task\.logissue type=warning;code=RepositorySourceGraphFallback\]'
        }
        Should -Invoke Write-Host -Times 1 -Exactly -ParameterFilter {
            $Object -eq "REPOSITORY_DEPENDENCY_AUTHORITY=resolve-references-fallback selectedRootCount=1"
        }
    }
}

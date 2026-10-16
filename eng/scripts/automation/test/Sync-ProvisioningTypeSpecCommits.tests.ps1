#Requires -Version 7.0

<#
.SYNOPSIS
    Unit tests for provisioning TypeSpec commit synchronization.

.How-To-Run
    Invoke-Pester -Output Detailed $PSScriptRoot/Sync-ProvisioningTypeSpecCommits.tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
    . (Join-Path $PSScriptRoot ".." "Sync-ProvisioningTypeSpecCommits.ps1")
}

Describe "Get-TypeSpecLocationValue" -Tag "UnitTest" {
    It "reads quoted and unquoted values" {
        $content = @"
directory: specification/example/resource-manager/Microsoft.Example/Example
commit: "0123456789012345678901234567890123456789"
repo: Azure/azure-rest-api-specs
"@

        Get-TypeSpecLocationValue -Content $content -Name "directory" |
            Should -Be "specification/example/resource-manager/Microsoft.Example/Example"
        Get-TypeSpecLocationValue -Content $content -Name "commit" |
            Should -Be "0123456789012345678901234567890123456789"
    }
}

Describe "Get-ApiVersionDifferences" -Tag "UnitTest" {
    It "reports changed and missing API versions" {
        $provisioning = @{
            "Microsoft.Example" = "2024-01-01"
            "Microsoft.Missing" = "2024-02-01"
        }
        $management = @{
            "Microsoft.Example" = "2024-03-01"
            "Microsoft.Added" = "2024-04-01"
        }

        $differences = @(Get-ApiVersionDifferences `
            -ProvisioningApiVersions $provisioning `
            -ManagementApiVersions $management)

        $differences | Should -HaveCount 3
        ($differences | Where-Object Provider -eq "Microsoft.Example").ProvisioningApiVersion |
            Should -Be "2024-01-01"
        ($differences | Where-Object Provider -eq "Microsoft.Example").ManagementApiVersion |
            Should -Be "2024-03-01"
        ($differences | Where-Object Provider -eq "Microsoft.Added").ProvisioningApiVersion |
            Should -BeNullOrEmpty
    }
}

Describe "Get-ProvisioningTypeSpecSynchronizationPlan" -Tag "UnitTest" {
    It "maps package names and plans only commit updates when API versions match" {
        $projects = @(
            [pscustomobject]@{
                Kind = "Provisioning"
                LibraryName = "Azure.Provisioning.Example"
                ServiceDirectory = "example"
                TspLocationPath = "provisioning/tsp-location.yaml"
                MetadataPath = "provisioning/metadata.json"
                Commit = "1111111111111111111111111111111111111111"
                ApiVersions = @{ "Microsoft.Example" = "2024-01-01" }
            }
            [pscustomobject]@{
                Kind = "Management"
                LibraryName = "Azure.ResourceManager.Example"
                ServiceDirectory = "example"
                TspLocationPath = "management/tsp-location.yaml"
                MetadataPath = "management/metadata.json"
                Commit = "2222222222222222222222222222222222222222"
                ApiVersions = @{ "Microsoft.Example" = "2024-01-01" }
            }
        )

        $plan = Get-ProvisioningTypeSpecSynchronizationPlan -TypeSpecProjects $projects

        $plan.Errors | Should -BeNullOrEmpty
        $plan.Mismatches | Should -BeNullOrEmpty
        $plan.Updates | Should -HaveCount 1
        $plan.Updates[0].TargetCommit | Should -Be "2222222222222222222222222222222222222222"
    }

    It "blocks all updates when API versions differ" {
        $projects = @(
            [pscustomobject]@{
                Kind = "Provisioning"
                LibraryName = "Azure.Provisioning.Example"
                ServiceDirectory = "example"
                TspLocationPath = "provisioning/tsp-location.yaml"
                MetadataPath = "provisioning/metadata.json"
                Commit = "1111111111111111111111111111111111111111"
                ApiVersions = @{ "Microsoft.Example" = "2024-01-01" }
            }
            [pscustomobject]@{
                Kind = "Management"
                LibraryName = "Azure.ResourceManager.Example"
                ServiceDirectory = "example"
                TspLocationPath = "management/tsp-location.yaml"
                MetadataPath = "management/metadata.json"
                Commit = "2222222222222222222222222222222222222222"
                ApiVersions = @{ "Microsoft.Example" = "2024-03-01" }
            }
        )

        $plan = Get-ProvisioningTypeSpecSynchronizationPlan -TypeSpecProjects $projects

        $plan.Mismatches | Should -HaveCount 1
        $plan.Updates | Should -BeNullOrEmpty
        $plan.Mismatches[0].ManagementApiVersion | Should -Be "2024-03-01"
        $plan.Mismatches[0].ProvisioningApiVersion | Should -Be "2024-01-01"
    }
}

Describe "Update-TypeSpecLocationCommitContent" -Tag "UnitTest" {
    It "changes only the commit value" {
        $oldCommit = "1111111111111111111111111111111111111111"
        $newCommit = "2222222222222222222222222222222222222222"
        $content = @"
directory: specification/example/resource-manager/Microsoft.Example/Example
commit: "$oldCommit"
repo: Azure/azure-rest-api-specs
additionalDirectories: []
"@

        $updated = Update-TypeSpecLocationCommitContent -Content $content -Commit $newCommit

        $updated | Should -Be @"
directory: specification/example/resource-manager/Microsoft.Example/Example
commit: "$newCommit"
repo: Azure/azure-rest-api-specs
additionalDirectories: []
"@
    }
}

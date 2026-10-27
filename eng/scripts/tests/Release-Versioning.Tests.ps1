#Requires -Version 7.0
<#
Invoke-Pester -Output Detailed $PSScriptRoot/Release-Versioning.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

BeforeAll {
    $repoRoot = Join-Path $PSScriptRoot ".." ".." ".."
    $pipeline = Get-Content (Join-Path $repoRoot "eng/pipelines/templates/steps/build.yml") -Raw | ConvertFrom-Yaml
    $step = @($pipeline.steps | Where-Object displayName -EQ "Setup .NET specific versioning properties")
    $step.Count | Should -Be 1
    $versioningScript = $step[0].pwsh

    function Invoke-VersioningStep(
        [string]$Reason = "IndividualCI",
        [string]$Branch = "refs/heads/main",
        [string]$Project = "internal",
        [string]$Repository = "Azure/azure-sdk-for-net",
        [string]$SetDevVersion = "false",
        [string]$SkipRelease = ""
    ) {
        $macros = @{
            '$(Build.Reason)' = $Reason
            '$(Build.SourceBranch)' = $Branch
            '$(System.TeamProject)' = $Project
            '$(Build.Repository.Name)' = $Repository
            '$(SetDevVersion)' = $SetDevVersion
            '$(Skip.Release)' = $SkipRelease
            '$(SkipDevBuildNumber)' = "true"
            '$(OfficialBuildId)' = "20261022.1"
        }
        $script = $versioningScript
        foreach ($macro in $macros.GetEnumerator()) {
            $script = $script.Replace($macro.Key, $macro.Value)
        }
        @(& ([scriptblock]::Create($script)) 6>&1 | ForEach-Object { "$_" })
    }
}

Describe ".NET release package version selection" -Tag "UnitTest" {
    It "packs the intended release version for internal main post-merge CI (SetDevVersion='<Dev>')" -ForEach @(
        @{ Dev = "false" }
        @{ Dev = "" }
    ) {
        $output = Invoke-VersioningStep -SetDevVersion $Dev
        $output | Should -Contain "##vso[task.setvariable variable=VersioningProperties]/p:OfficialBuildId=20261022.1 /p:SkipDevBuildNumber=true"
    }

    It "preserves manual release packaging for <Name>" -ForEach @(
        @{ Name = "release branches"; Arguments = @{ Branch = "refs/heads/release/test" } }
        @{ Name = "public builds"; Arguments = @{ Project = "public" } }
        @{ Name = "PR repository builds"; Arguments = @{ Repository = "Azure/azure-sdk-for-net-pr" } }
        @{ Name = "release-disabled builds"; Arguments = @{ SkipRelease = "true" } }
    ) {
        $output = Invoke-VersioningStep -Reason Manual @Arguments
        $output | Should -Contain "##vso[task.setvariable variable=VersioningProperties]/p:OfficialBuildId=20261022.1 /p:SkipDevBuildNumber=true"
    }

    It "preserves dev packaging for <Name>" -ForEach @(
        @{ Name = "explicit dev CI"; Arguments = @{ SetDevVersion = "true" } }
        @{ Name = "explicit dev manual build"; Arguments = @{ Reason = "Manual"; SetDevVersion = "true" } }
        @{ Name = "scheduled build"; Arguments = @{ Reason = "Schedule" } }
        @{ Name = "pull request"; Arguments = @{ Reason = "PullRequest" } }
        @{ Name = "batched CI"; Arguments = @{ Reason = "BatchedCI" } }
        @{ Name = "resource trigger"; Arguments = @{ Reason = "ResourceTrigger" } }
        @{ Name = "public CI"; Arguments = @{ Project = "public" } }
        @{ Name = "feature-branch CI"; Arguments = @{ Branch = "refs/heads/feature/test" } }
        @{ Name = "release-branch CI"; Arguments = @{ Branch = "refs/heads/release/test" } }
        @{ Name = "PR repository CI"; Arguments = @{ Repository = "Azure/azure-sdk-for-net-pr" } }
        @{ Name = "release-disabled CI"; Arguments = @{ SkipRelease = "true" } }
    ) {
        $output = Invoke-VersioningStep @Arguments
        $output | Should -Contain "##vso[task.setvariable variable=VersioningProperties]/p:OfficialBuildId=20261022.1 /p:SkipDevBuildNumber=false"
    }

    It "logs the effective setting rather than the earlier metadata setting" {
        $output = Invoke-VersioningStep -Reason PullRequest
        $output | Should -Contain "SkipDevBuildNumber: [false]"
        $output | Should -Not -Contain "SkipDevBuildNumber: [true]"
    }
}

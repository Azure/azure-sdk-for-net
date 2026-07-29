#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
  $global:RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")).Path
  $global:EngDir = Join-Path $global:RepoRoot "eng"
  . (Join-Path $PSScriptRoot ".." "Language-Settings.ps1")
}

Describe "Get-DependentPackageRootsFromGraph" -Tag "UnitTest" {
  It "returns unique package roots whose resolved references contain a dependency" {
    $graph = Join-Path $TestDrive "graph.txt"
    @(
      "sdk/a/A|Azure.Core,System.Memory",
      "sdk/a/A|Azure.Core,System.Text.Json",
      "sdk/b/B|Azure.Identity,System.Memory",
      "sdk/c/C|System.Memory"
    ) | Set-Content $graph

    $result = @(Get-DependentPackageRootsFromGraph `
      -DependencyGraphPath $graph `
      -DependencyNames @("azure.core", "Azure.Identity"))

    $result | Should -Be @(
      (Join-Path $global:RepoRoot "sdk/a/A"),
      (Join-Path $global:RepoRoot "sdk/b/B")
    )
  }

  It "fails instead of silently omitting dependencies from a malformed graph" {
    $graph = Join-Path $TestDrive "malformed-graph.txt"
    "malformed" | Set-Content $graph

    {
      Get-DependentPackageRootsFromGraph -DependencyGraphPath $graph -DependencyNames @("Azure.Core")
    } | Should -Throw "*Malformed test dependency graph entry*"
  }
}

Describe "Get-dotnet-AdditionalValidationPackagesFromPackageSet" -Tag "UnitTest" {
  BeforeAll {
    # Provided by eng/common at runtime; declared here so it can be mocked.
    function Invoke-LoggedMsbuildCommand { param([string] $command) }
  }

  BeforeEach {
    $global:PreviousGraphPath = $env:AZURESDK_TEST_DEPENDENCY_GRAPH_PATH
    $global:PreviousLocation = (Get-Location).ProviderPath
  }

  AfterEach {
    $env:AZURESDK_TEST_DEPENDENCY_GRAPH_PATH = $global:PreviousGraphPath
    Set-Location $global:PreviousLocation
  }

  It "regenerates the graph when the cache path is a bare file name" {
    # Split-Path -Parent returns an empty string for a bare file name, which New-Item
    # cannot bind. That would abort matrix generation rather than fall back to
    # regenerating the graph, so the path is normalized before it is split.
    Set-Location $TestDrive
    $env:AZURESDK_TEST_DEPENDENCY_GRAPH_PATH = "graph.txt"

    Mock Invoke-LoggedMsbuildCommand -MockWith {
      "sdk/a/A|Azure.Core" | Set-Content (Join-Path $TestDrive "graph.txt")
    }

    $changed = [pscustomobject]@{
      Name = "Azure.Core"; DirectoryPath = (Join-Path $global:RepoRoot "sdk/core/Azure.Core")
      IncludedForValidation = $false; ArtifactName = "Azure.Core"
    }
    $dependent = [pscustomobject]@{
      Name = "A"; DirectoryPath = (Join-Path $global:RepoRoot "sdk/a/A")
      IncludedForValidation = $false; ArtifactName = "A"
    }

    $result = @(Get-dotnet-AdditionalValidationPackagesFromPackageSet `
      -LocatedPackages @($changed) `
      -diffObj @{ ChangedFiles = @() } `
      -AllPkgProps @($changed, $dependent))

    Should -Invoke Invoke-LoggedMsbuildCommand -Times 1
    $result.Name | Should -Contain "A"
    # The checksum is written next to the normalized path, not the bare name.
    Test-Path (Join-Path $TestDrive "graph.txt.sha256") | Should -BeTrue
  }

  It "regenerates the graph when the checksum sidecar is empty" {
    # A run cancelled or timed out part way through writing the sidecar leaves a zero
    # length file. Get-Content -Raw yields $null for it, and $null.Trim() is a
    # terminating error, so this must be read defensively.
    $graph = Join-Path $TestDrive "empty-sidecar-graph.txt"
    "sdk/a/A|Azure.Identity" | Set-Content $graph
    New-Item -ItemType File -Path "$graph.sha256" -Force | Out-Null
    $env:AZURESDK_TEST_DEPENDENCY_GRAPH_PATH = $graph

    Mock Invoke-LoggedMsbuildCommand -MockWith { "sdk/a/A|Azure.Core" | Set-Content $graph }

    $changed = [pscustomobject]@{
      Name = "Azure.Core"; DirectoryPath = (Join-Path $global:RepoRoot "sdk/core/Azure.Core")
      IncludedForValidation = $false; ArtifactName = "Azure.Core"
    }
    $dependent = [pscustomobject]@{
      Name = "A"; DirectoryPath = (Join-Path $global:RepoRoot "sdk/a/A")
      IncludedForValidation = $false; ArtifactName = "A"
    }

    $result = @(Get-dotnet-AdditionalValidationPackagesFromPackageSet `
      -LocatedPackages @($changed) `
      -diffObj @{ ChangedFiles = @() } `
      -AllPkgProps @($changed, $dependent))

    Should -Invoke Invoke-LoggedMsbuildCommand -Times 1
    $result.Name | Should -Contain "A"
  }

  It "falls back to the per-package query when the graph cannot be produced" {
    # The cache key only changes when a project file changes, so a poisoned or
    # unwritable cache entry would otherwise fail every rerun of the same PR
    # identically. This must degrade to the pre-cache behavior, never block a PR.
    $graph = Join-Path $TestDrive "unwritable-graph.txt"
    $env:AZURESDK_TEST_DEPENDENCY_GRAPH_PATH = $graph

    Mock Invoke-LoggedMsbuildCommand -MockWith {
      if ($command -match "ProjectDependsOn") {
        $outputPath = ([regex]::Match($command, 'OutputProjectFilePath="([^"]+)"')).Groups[1].Value
        (Join-Path $global:RepoRoot "sdk/a/A") | Set-Content $outputPath
      }
    }

    $changed = [pscustomobject]@{
      Name = "Azure.Core"; DirectoryPath = (Join-Path $global:RepoRoot "sdk/core/Azure.Core")
      IncludedForValidation = $false; ArtifactName = "Azure.Core"
    }
    $dependent = [pscustomobject]@{
      Name = "A"; DirectoryPath = (Join-Path $global:RepoRoot "sdk/a/A")
      IncludedForValidation = $false; ArtifactName = "A"
    }

    $result = @(Get-dotnet-AdditionalValidationPackagesFromPackageSet `
      -LocatedPackages @($changed) `
      -diffObj @{ ChangedFiles = @() } `
      -AllPkgProps @($changed, $dependent))

    # Once to attempt the graph, once for the legacy query it fell back to.
    Should -Invoke Invoke-LoggedMsbuildCommand -Times 2
    $result.Name | Should -Contain "A"
  }
}

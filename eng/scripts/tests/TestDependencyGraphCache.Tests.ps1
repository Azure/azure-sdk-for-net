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
}

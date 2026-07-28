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

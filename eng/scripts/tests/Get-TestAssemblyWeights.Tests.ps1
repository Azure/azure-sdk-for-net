#Requires -Version 7.0
<#
.How-To-Run
Invoke-Pester -Output Detailed $PSScriptRoot/Get-TestAssemblyWeights.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
  $scriptPath = Join-Path $PSScriptRoot ".." "Get-TestAssemblyWeights.ps1"
  $tokens = $null
  $parseErrors = $null
  $scriptAst = [System.Management.Automation.Language.Parser]::ParseFile(
    $scriptPath,
    [ref]$tokens,
    [ref]$parseErrors
  )
  if ($parseErrors.Count -gt 0) {
    throw ($parseErrors | Out-String)
  }

  $functions = $scriptAst.FindAll({
    param($node)
    $node -is [System.Management.Automation.Language.FunctionDefinitionAst]
  }, $true)
  foreach ($function in $functions) {
    Invoke-Expression $function.Extent.Text
  }
}

Describe "Get-TestAssemblyWeights" {
  BeforeEach {
    $testRoot = Join-Path $TestDrive "repo"
    $packageInfoFolder = Join-Path $TestDrive "PackageInfo"
    New-Item -Path $testRoot -ItemType Directory -Force | Out-Null
    New-Item -Path $packageInfoFolder -ItemType Directory -Force | Out-Null
  }

  It "maps only PackageInfo packages to normalized test assemblies" {
    $packagePath = Join-Path $testRoot "sdk/sample/Azure.Sample"
    New-Item -Path (Join-Path $packagePath "tests/subdir") -ItemType Directory -Force | Out-Null
    Set-Content (Join-Path $packagePath "tests/Azure.Sample.Tests.csproj") "<Project />"
    Set-Content (Join-Path $packagePath "tests/subdir/Azure.Sample.More.Tests.csproj") "<Project />"
    @{
      ArtifactName = "Azure.Sample"
      DirectoryPath = "sdk/sample/Azure.Sample"
    } | ConvertTo-Json | Set-Content (Join-Path $packageInfoFolder "Azure.Sample.json")

    $result = Get-TargetAssemblyMap -RepoRoot $testRoot -PackageInfoFolder $packageInfoFolder

    @($result.PackageAssemblies["Azure.Sample"]) | Should -Be @(
      "azure.sample.more.tests.dll",
      "azure.sample.tests.dll"
    )
    $result.AssemblyToPackage["azure.sample.tests.dll"] | Should -Be "Azure.Sample"
  }

  It "preserves packages without tests for a nonzero fallback weight" {
    $packagePath = Join-Path $testRoot "sdk/sample/Azure.Empty"
    New-Item -Path $packagePath -ItemType Directory -Force | Out-Null
    @{
      ArtifactName = "Azure.Empty"
      DirectoryPath = "sdk/sample/Azure.Empty"
    } | ConvertTo-Json | Set-Content (Join-Path $packageInfoFolder "Azure.Empty.json")

    $result = Get-TargetAssemblyMap -RepoRoot $testRoot -PackageInfoFolder $packageInfoFolder
    $weights = Get-ResolvedPackageWeights `
      -PackageAssemblies $result.PackageAssemblies `
      -Durations @{} `
      -DefaultWeight 1

    @($result.PackageAssemblies["Azure.Empty"]).Count | Should -Be 0
    $weights.PackageWeights["Azure.Empty"] | Should -Be 1
  }

  It "rejects duplicate test assembly names across packages" {
    foreach ($name in @("Azure.One", "Azure.Two")) {
      $packagePath = Join-Path $testRoot "sdk/sample/$name"
      New-Item -Path (Join-Path $packagePath "tests") -ItemType Directory -Force | Out-Null
      Set-Content (Join-Path $packagePath "tests/Shared.Tests.csproj") "<Project />"
      @{
        ArtifactName = $name
        DirectoryPath = "sdk/sample/$name"
      } | ConvertTo-Json | Set-Content (Join-Path $packageInfoFolder "$name.json")
    }

    {
      Get-TargetAssemblyMap -RepoRoot $testRoot -PackageInfoFolder $packageInfoFolder
    } | Should -Throw "*mapped to both*"
  }

  It "creates scoped query batches with the requested time window" {
    $queries = @(New-TestResultsQueries `
      -Assemblies @("c.dll", "a.dll", "b.dll") `
      -StartTime ([datetime]"2026-07-01T00:00:00Z") `
      -EndTime ([datetime]"2026-07-02T00:00:00Z") `
      -OrgUrl "https://analytics.example" `
      -ProjectId "project" `
      -PipelineId 7327 `
      -BatchSize 2)

    $queries.Count | Should -Be 2
    $queries[0].Assemblies | Should -Be @("a.dll", "b.dll")
    $queries[0].Url | Should -Match "CompletedDate gt 2026-07-01T00:00:00Z"
    $queries[0].Url | Should -Match "Pipeline/PipelineId eq 7327"
    $queries[0].Url | Should -Not -Match "c.dll"
    $queries[1].Url | Should -Match "c.dll"
  }

  It "accepts retry settings when invoking Analytics queries" {
    $parameters = (Get-Command Invoke-TestResultsQueries).Parameters

    $parameters.Keys | Should -Contain "MaxRetryAttempts"
    $parameters.Keys | Should -Contain "RetryBaseDelaySeconds"
  }

  It "requires one observation for a low assembly count" {
    $durations = @{
      "assembly-1.dll" = [System.Collections.Generic.List[int]]@(10)
    }

    {
      Assert-MinimumDataCoverage `
        -Assemblies @(1..5 | ForEach-Object { "assembly-$_.dll" }) `
        -Durations $durations `
        -MinimumCoveragePercent 10
    } | Should -Not -Throw
  }

  It "rejects catastrophically sparse runtime history" {
    $durations = @{}
    1..9 | ForEach-Object {
      $durations["assembly-$_.dll"] = [System.Collections.Generic.List[int]]@(10)
    }

    {
      Assert-MinimumDataCoverage `
        -Assemblies @(1..100 | ForEach-Object { "assembly-$_.dll" }) `
        -Durations $durations `
        -MinimumCoveragePercent 10
    } | Should -Throw "*covers 9 of 100*below the required 10*"
  }

  It "does not require history when packages have no candidate assemblies" {
    {
      Assert-MinimumDataCoverage `
        -Assemblies @() `
        -Durations @{} `
        -MinimumCoveragePercent 10
    } | Should -Not -Throw
  }

  It "averages observed runtimes and assigns fallback per unknown assembly" {
    $durations = @{}
    Add-TestResultDurations -Rows @(
      [PSCustomObject]@{
        Test = [PSCustomObject]@{ ContainerName = "Azure.Sample.Tests.dll" }
        S = "2026-07-01T00:00:00Z"
        E = "2026-07-01T00:01:00Z"
      },
      [PSCustomObject]@{
        Test = [PSCustomObject]@{ ContainerName = "azure.sample.tests.dll" }
        S = "2026-07-02T00:00:00Z"
        E = "2026-07-02T00:02:00Z"
      }
    ) -Durations $durations

    $packageAssemblies = [ordered]@{
      "Azure.Sample" = @("azure.sample.tests.dll", "azure.sample.unknown.tests.dll")
    }
    $weights = Get-ResolvedPackageWeights `
      -PackageAssemblies $packageAssemblies `
      -Durations $durations `
      -DefaultWeight 1

    $weights.AssemblyWeights["azure.sample.tests.dll"] | Should -Be 90
    $weights.AssemblyWeights["azure.sample.unknown.tests.dll"] | Should -Be 1
    $weights.PackageWeights["Azure.Sample"] | Should -Be 91
  }
}

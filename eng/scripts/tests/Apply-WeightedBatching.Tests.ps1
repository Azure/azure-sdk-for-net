#Requires -Version 7.0
<#
.How-To-Run
Invoke-Pester -Output Detailed $PSScriptRoot/Apply-WeightedBatching.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Apply-WeightedBatching" {
  BeforeEach {
    $packageInfoFolder = Join-Path $TestDrive "PackageInfo"
    $weightsFile = Join-Path $TestDrive "weights.json"
    if (Test-Path $packageInfoFolder) {
      Remove-Item $packageInfoFolder -Recurse -Force
    }
    if (Test-Path $weightsFile) {
      Remove-Item $weightsFile -Force
    }
    New-Item -Path $packageInfoFolder -ItemType Directory -Force | Out-Null
  }

  It "keeps every direct and indirect package exactly once" {
    $packages = @(
      @{ Name = "Direct.A"; Weight = 8; Indirect = $false },
      @{ Name = "Direct.B"; Weight = 7; Indirect = $false },
      @{ Name = "Direct.C"; Weight = 5; Indirect = $false },
      @{ Name = "Direct.D"; Weight = 4; Indirect = $false },
      @{ Name = "Indirect.A"; Weight = 9; Indirect = $true },
      @{ Name = "Indirect.B"; Weight = 6; Indirect = $true },
      @{ Name = "Indirect.C"; Weight = 5; Indirect = $true }
    )

    $weights = [ordered]@{}
    foreach ($package in $packages) {
      @{
        ArtifactName = $package.Name
        IncludedForValidation = $package.Indirect
      } | ConvertTo-Json | Set-Content (Join-Path $packageInfoFolder "$($package.Name).json")
      $weights[$package.Name] = $package.Weight
    }
    $weights | ConvertTo-Json | Set-Content $weightsFile

    & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
      -PackageInfoFolder $packageInfoFolder `
      -WeightsFile $weightsFile `
      -Target 12 `
      -IndirectTarget 20

    $remaining = @(Get-ChildItem $packageInfoFolder -Filter "*.json")
    $remaining.Count | Should -Be 3

    $resolvedNames = @(
      $remaining |
        ForEach-Object { (Get-Content $_.FullName | ConvertFrom-Json).ArtifactName -split "," } |
        Sort-Object
    )
    $resolvedNames | Should -Be @($packages.Name | Sort-Object)

    foreach ($file in $remaining) {
      $packageInfo = Get-Content $file.FullName | ConvertFrom-Json
      $names = @($packageInfo.ArtifactName -split ",")
      @($names | Where-Object { $_ -like "Direct.*" }).Count |
        Should -BeIn @(0, $names.Count)
    }
  }

  It "uses a positive fallback for missing and zero weights" {
    foreach ($name in @("Package.A", "Package.B")) {
      @{
        ArtifactName = $name
        IncludedForValidation = $false
      } | ConvertTo-Json | Set-Content (Join-Path $packageInfoFolder "$name.json")
    }
    @{ "Package.A" = 0 } | ConvertTo-Json | Set-Content $weightsFile

    {
      & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
        -PackageInfoFolder $packageInfoFolder `
        -WeightsFile $weightsFile `
        -Target 1 `
        -DefaultWeight 1
    } | Should -Not -Throw

    @(Get-ChildItem $packageInfoFolder -Filter "*.json").Count | Should -Be 2
  }

  It "does not consolidate packages with different CI matrix configurations when requested" {
    $packages = @(
      @{ Name = "Package.Default"; Configs = $null },
      @{ Name = "Package.Custom"; Configs = @(@{ Name = 'custom'; Path = 'custom-matrix.json'; Selection = 'all' }) }
    )
    $weights = [ordered]@{}
    foreach ($package in $packages) {
      @{
        ArtifactName = $package.Name
        IncludedForValidation = $false
        CIParameters = @{ CIMatrixConfigs = $package.Configs }
      } | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $packageInfoFolder "$($package.Name).json")
      $weights[$package.Name] = 1
    }
    $weights | ConvertTo-Json | Set-Content $weightsFile

    & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
      -PackageInfoFolder $packageInfoFolder `
      -WeightsFile $weightsFile `
      -Target 100 `
      -PreserveCIMatrixConfigs

    $remaining = @(Get-ChildItem $packageInfoFolder -Filter "*.json")
    $remaining.Count | Should -Be 2
    @($remaining | ForEach-Object {
      (Get-Content -Raw $_.FullName | ConvertFrom-Json).ArtifactName
    } | Sort-Object) | Should -Be @('Package.Custom', 'Package.Default')
  }
}

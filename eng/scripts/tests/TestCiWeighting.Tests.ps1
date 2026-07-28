#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
  $script:RepoRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
  $global:RepoRoot = $script:RepoRoot.Path
  $global:EngDir = Join-Path $global:RepoRoot "eng"
  . (Join-Path $PSScriptRoot ".." "Language-Settings.ps1")

  function Write-PackageInfo {
    param(
      [string]$Folder,
      [string]$Name,
      [string]$DirectoryPath,
      [bool]$Indirect = $false,
      [string[]]$MatrixNames = @()
    )

    $ciParameters = if ($MatrixNames.Count -gt 0) {
      @{ CIMatrixConfigs = @($MatrixNames | ForEach-Object {
        @{ Name = $_; Path = "$_.json"; Selection = "sparse" }
      }) }
    }
    else {
      @{}
    }

    @{
      Name = $Name
      ArtifactName = $Name
      DirectoryPath = $DirectoryPath
      IncludedForValidation = $Indirect
      CIParameters = $ciParameters
    } | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $Folder "$Name.json")
  }
}

Describe "Get-PackageTestWeights" -Tag "UnitTest" {
  It "combines source LOC, test LOC, test markers, and test project count" {
    $root = Join-Path $TestDrive "repo"
    $package = Join-Path $root "sdk/service/Package.One"
    $info = Join-Path $TestDrive "info"
    New-Item -ItemType Directory -Force "$package/src", "$package/tests", $info | Out-Null

    [IO.File]::WriteAllText((Join-Path $package "src/Source.cs"), "one`ntwo")
    [IO.File]::WriteAllText(
      (Join-Path $package "tests/Tests.cs"),
      "[Test]`n[TestCase(1)]`n[Theory]`n[InlineData(1)]")
    [IO.File]::WriteAllText((Join-Path $package "tests/Package.One.Tests.csproj"), "<Project />")
    Write-PackageInfo -Folder $info -Name "Package.One" -DirectoryPath "sdk/service/Package.One"

    $output = Join-Path $TestDrive "weights.json"
    & (Join-Path $PSScriptRoot ".." "Get-PackageTestWeights.ps1") `
      -PackageInfoFolder $info -RepoRoot $root -OutputFile $output

    $weights = Get-Content $output -Raw | ConvertFrom-Json
    # 2 source lines + 1*200 source file + 4*3 test lines + 4*100 markers
    # + 1*20000 project + 50000 fixed.
    $weights."Package.One" | Should -Be 70614
  }
}

Describe "Apply-WeightedBatching PackagesPerBatch" -Tag "UnitTest" {
  It "preserves the count-derived job count without package loss or duplication" {
    $info = Join-Path $TestDrive "batch-info"
    New-Item -ItemType Directory -Force $info | Out-Null
    $weights = [ordered]@{}

    1..21 | ForEach-Object {
      $name = "Package.$_"
      Write-PackageInfo -Folder $info -Name $name -DirectoryPath "sdk/service/$name"
      $weights[$name] = if ($_ -le 3) { 1000 - $_ } else { $_ }
    }

    $weightsFile = Join-Path $TestDrive "batch-weights.json"
    $weights | ConvertTo-Json | Set-Content $weightsFile
    & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
      -PackageInfoFolder $info -WeightsFile $weightsFile -PackagesPerBatch 10

    $files = @(Get-ChildItem $info -Filter "*.json")
    $names = @($files | ForEach-Object {
      (Get-Content $_.FullName -Raw | ConvertFrom-Json).ArtifactName -split ","
    })

    $files.Count | Should -Be 3
    $names.Count | Should -Be 21
    @($names | Sort-Object -Unique).Count | Should -Be 21
  }

  It "does not combine packages with different matrix configurations" {
    $info = Join-Path $TestDrive "matrix-info"
    New-Item -ItemType Directory -Force $info | Out-Null
    $weights = [ordered]@{}

    1..6 | ForEach-Object {
      $name = "A.$_"
      Write-PackageInfo -Folder $info -Name $name -DirectoryPath "sdk/a/$name" -MatrixNames "A"
      $weights[$name] = $_
    }
    1..6 | ForEach-Object {
      $name = "B.$_"
      Write-PackageInfo -Folder $info -Name $name -DirectoryPath "sdk/b/$name" -MatrixNames "B"
      $weights[$name] = $_
    }

    $weightsFile = Join-Path $TestDrive "matrix-weights.json"
    $weights | ConvertTo-Json | Set-Content $weightsFile
    & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
      -PackageInfoFolder $info -WeightsFile $weightsFile -PackagesPerBatch 10

    $files = @(Get-ChildItem $info -Filter "*.json")
    $files.Count | Should -Be 2
    foreach ($file in $files) {
      $names = (Get-Content $file.FullName -Raw | ConvertFrom-Json).ArtifactName -split ","
      @($names | ForEach-Object { $_.Substring(0, 1) } | Sort-Object -Unique).Count | Should -Be 1
    }
  }

  It "preserves overlapping individual matrix memberships" {
    $info = Join-Path $TestDrive "overlap-info"
    New-Item -ItemType Directory -Force $info | Out-Null
    Write-PackageInfo -Folder $info -Name "Both" -DirectoryPath "sdk/both" -MatrixNames "A", "B"
    Write-PackageInfo -Folder $info -Name "OnlyA" -DirectoryPath "sdk/a" -MatrixNames "A"
    Write-PackageInfo -Folder $info -Name "OnlyB" -DirectoryPath "sdk/b" -MatrixNames "B"

    $weightsFile = Join-Path $TestDrive "overlap-weights.json"
    @{ Both = 3; OnlyA = 2; OnlyB = 1 } | ConvertTo-Json | Set-Content $weightsFile
    & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
      -PackageInfoFolder $info -WeightsFile $weightsFile -PackagesPerBatch 10

    $batches = @(Get-ChildItem $info -Filter "*.json" | ForEach-Object {
      Get-Content $_.FullName -Raw | ConvertFrom-Json
    })
    $batches.Count | Should -Be 2

    $a = $batches | Where-Object { $_.CIParameters.CIMatrixConfigs.Name -eq "A" }
    $b = $batches | Where-Object { $_.CIParameters.CIMatrixConfigs.Name -eq "B" }
    @($a.ArtifactName -split ",") | Should -Contain "Both"
    @($a.ArtifactName -split ",") | Should -Contain "OnlyA"
    @($b.ArtifactName -split ",") | Should -Contain "Both"
    @($b.ArtifactName -split ",") | Should -Contain "OnlyB"
  }

  It "batches inherited defaults together with explicit matrix memberships" {
    $info = Join-Path $TestDrive "default-overlap-info"
    New-Item -ItemType Directory -Force $info | Out-Null
    1..9 | ForEach-Object {
      Write-PackageInfo -Folder $info -Name "Default$_" -DirectoryPath "sdk/default/$_"
    }
    Write-PackageInfo -Folder $info -Name "ExplicitA" -DirectoryPath "sdk/a" -MatrixNames "A"

    $weightsFile = Join-Path $TestDrive "default-overlap-weights.json"
    $weights = [ordered]@{ ExplicitA = 10 }
    1..9 | ForEach-Object { $weights["Default$_"] = $_ }
    $weights | ConvertTo-Json | Set-Content $weightsFile

    $defaultsFile = Join-Path $TestDrive "defaults.json"
    @(
      @{ Name = "A"; Path = "A.json"; Selection = "sparse" },
      @{ Name = "B"; Path = "B.json"; Selection = "sparse" }
    ) | ConvertTo-Json | Set-Content $defaultsFile

    & (Join-Path $PSScriptRoot ".." "Apply-WeightedBatching.ps1") `
      -PackageInfoFolder $info `
      -WeightsFile $weightsFile `
      -PackagesPerBatch 10 `
      -DefaultMatrixConfigsFile $defaultsFile

    $batches = @(Get-ChildItem $info -Filter "*.json" | ForEach-Object {
      Get-Content $_.FullName -Raw | ConvertFrom-Json
    })
    $batches.Count | Should -Be 2

    $a = $batches | Where-Object { $_.CIParameters.CIMatrixConfigs.Name -eq "A" }
    $b = $batches | Where-Object { $_.CIParameters.CIMatrixConfigs.Name -eq "B" }
    @($a.ArtifactName -split ",").Count | Should -Be 10
    @($a.ArtifactName -split ",") | Should -Contain "ExplicitA"
    @($b.ArtifactName -split ",").Count | Should -Be 9
    @($b.ArtifactName -split ",") | Should -Not -Contain "ExplicitA"
  }
}

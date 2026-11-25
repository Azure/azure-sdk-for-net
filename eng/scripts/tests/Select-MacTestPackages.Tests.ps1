#Requires -Version 7.0
<#
.How-To-Run
Invoke-Pester -Output Detailed $PSScriptRoot/Select-MacTestPackages.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "Select-MacTestPackages" -Tag UnitTest {
  BeforeEach {
    $inputFolder = Join-Path $TestDrive "input"
    $outputFolder = Join-Path $TestDrive "output"
    $weightsFile = Join-Path $TestDrive "weights.json"
    Remove-Item $inputFolder, $outputFolder, $weightsFile -Recurse -Force -ErrorAction SilentlyContinue
    New-Item $inputFolder -ItemType Directory -Force | Out-Null
    $scriptPath = Join-Path $PSScriptRoot ".." "Select-MacTestPackages.ps1"
    $savedEnvironment = @{}
    foreach ($name in @('LINUXPOOL', 'WINDOWSPOOL', 'MACPOOL', 'LINUXVMIMAGE', 'WINDOWSVMIMAGE', 'MACVMIMAGE')) {
      $savedEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
    }
  }

  AfterEach {
    foreach ($name in $savedEnvironment.Keys) {
      [Environment]::SetEnvironmentVariable($name, $savedEnvironment[$name])
    }
  }

  It "selects one weighted third without changing the original packages" {
    $weights = @{}
    foreach ($name in @('A', 'B', 'C', 'D', 'E', 'F')) {
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{} } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
      $weights[$name] = 100
    }
    @{ ArtifactName = 'Indirect'; IncludedForValidation = $true; CIParameters = @{} } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder 'Indirect.json')
    $weights | ConvertTo-Json | Set-Content $weightsFile

    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -SelectionSeed 0

    $selected = @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse |
      ForEach-Object { (Get-Content $_.FullName -Raw | ConvertFrom-Json).ArtifactName -split ',' })
    $selected.Count | Should -Be 2
    @($selected | Select-Object -Unique).Count | Should -Be 2
    $selected | Should -Not -Contain 'Indirect'
    @(Get-ChildItem $inputFolder -Filter '*.json').Count | Should -Be 7
  }

  It "rotates deterministically and uses count-based selection when weights are missing" {
    foreach ($name in @('A', 'B', 'C', 'D', 'E', 'F')) {
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{} } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    $groups = @(foreach ($seed in 0..2) {
      $folder = "$outputFolder-$seed"
      Remove-Item $folder -Recurse -Force -ErrorAction SilentlyContinue
      & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $folder -WeightsFile $weightsFile -SelectionSeed $seed
      ,@(Get-ChildItem $folder -Filter '*.json' -Recurse |
        ForEach-Object { (Get-Content $_.FullName -Raw | ConvertFrom-Json).ArtifactName })
    })
    foreach ($group in $groups) { $group.Count | Should -Be 2 }
    @($groups | ForEach-Object { $_ } | Select-Object -Unique).Count | Should -Be 6
  }

  It "keeps packages that carry non-batched matrix configurations" {
    foreach ($name in @('A', 'B', 'C')) {
      $configs = if ($name -eq 'C') { @(@{ Name = 'Custom'; PRBatching = $false }) } else { @() }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = $configs } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -SelectionSeed 0
    $selected = @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse |
      ForEach-Object { (Get-Content $_.FullName -Raw | ConvertFrom-Json).ArtifactName })
    $selected | Should -Contain 'A'
    $selected | Should -Contain 'C'
  }

  It "does not merge matrix configurations that differ only by case" {
    foreach ($name in @('A', 'B', 'C', 'D', 'E', 'F')) {
      $configName = if ($name -eq 'D') { 'custom' } else { 'Custom' }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = @(@{ Name = $configName }) } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    @{ A = 100; B = 100; C = 100; D = 100; E = 100; F = 100 } | ConvertTo-Json | Set-Content $weightsFile
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -Target 1000
    @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse).Count | Should -Be 2
  }

  It "preserves inherited non-batched matrix configurations" {
    $defaultMatrixFile = Join-Path $TestDrive 'defaults.json'
    $defaultConfig = @{ Name = 'Default'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse'; PRBatching = $false }
    $customConfig = @{ Name = 'Custom'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }
    ConvertTo-Json -InputObject @($defaultConfig) -Depth 10 | Set-Content $defaultMatrixFile
    foreach ($name in @('A', 'B', 'C')) {
      $configs = if ($name -eq 'C') { $null } else { @($customConfig) }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = $configs } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    $env:LINUXPOOL = 'azsdk-pool'; $env:WINDOWSPOOL = 'azsdk-pool'; $env:MACPOOL = 'Azure Pipelines'
    $env:LINUXVMIMAGE = 'ubuntu-24.04'; $env:WINDOWSVMIMAGE = 'windows-2022'; $env:MACVMIMAGE = 'macos-latest'
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -DefaultMatrixFile $defaultMatrixFile
    $selected = @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse |
      ForEach-Object { (Get-Content $_.FullName -Raw | ConvertFrom-Json).ArtifactName })
    $selected | Should -Contain 'C'
    $matrixScript = Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'job-matrix' 'Create-PrJobMatrix.ps1'
    $matrix = & $matrixScript -PackagePropertiesFolder $outputFolder -PRMatrixFile $defaultMatrixFile `
      -PRMatrixSetting ProjectNames -DisplayNameFilter '.*' -Filters @('Pool=.*MacPool$') `
      -PackagesPerPRJob 1 -CI:$false | ConvertFrom-Json -AsHashtable
    @($matrix.Values | Where-Object { -not $_.ContainsKey('ProjectNames') }).Count | Should -Be 3
  }

  It "selects an eligible package when another package has no macOS matrix" {
    $defaultConfig = @{ Name = 'Default'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }
    $windowsConfig = @{ Name = 'Windows'; Path = 'eng/pipelines/templates/stages/build-matrix.json'; Selection = 'sparse' }
    $defaultMatrixFile = Join-Path $TestDrive 'defaults.json'
    ConvertTo-Json -InputObject @($defaultConfig) -Depth 10 | Set-Content $defaultMatrixFile
    foreach ($name in @('A', 'B', 'C')) {
      $configs = if ($name -eq 'A') { @($windowsConfig) } else { $null }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = $configs } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    $env:LINUXPOOL = 'azsdk-pool'; $env:WINDOWSPOOL = 'azsdk-pool'; $env:MACPOOL = 'Azure Pipelines'
    $env:LINUXVMIMAGE = 'ubuntu-24.04'; $env:WINDOWSVMIMAGE = 'windows-2022'; $env:MACVMIMAGE = 'macos-latest'
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -DefaultMatrixFile $defaultMatrixFile -SelectionSeed 0
    $matrixScript = Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'job-matrix' 'Create-PrJobMatrix.ps1'
    $matrix = & $matrixScript -PackagePropertiesFolder $outputFolder -PRMatrixFile $defaultMatrixFile `
      -PRMatrixSetting ProjectNames -DisplayNameFilter '.*' -Filters @('Pool=.*MacPool$') `
      -PackagesPerPRJob 1 -CI:$false | ConvertFrom-Json -AsHashtable
    $matrix.Count | Should -Be 3
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'A' }).Count | Should -Be 0
  }

  It "honors matrix filters when determining macOS eligibility" {
    $defaultConfig = @{ Name = 'Default'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }
    $defaultMatrixFile = Join-Path $TestDrive 'defaults.json'
    ConvertTo-Json -InputObject @($defaultConfig) -Depth 10 | Set-Content $defaultMatrixFile
    @{ ArtifactName = 'A'; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = $null } } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder 'A.json')
    $env:LINUXPOOL = 'azsdk-pool'; $env:WINDOWSPOOL = 'azsdk-pool'; $env:MACPOOL = 'Azure Pipelines'
    $env:LINUXVMIMAGE = 'ubuntu-24.04'; $env:WINDOWSVMIMAGE = 'windows-2022'; $env:MACVMIMAGE = 'macos-latest'
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile `
      -DefaultMatrixFile $defaultMatrixFile -MatrixFilters @('TestTargetFramework=^net7.0$')
    @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse).Count | Should -Be 0
  }

  It "keeps distinct matrix configurations and every macOS framework for selected packages" {
    $defaultConfig = @{ Name = 'Default'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse'; GenerateVMJobs = $true }
    $customConfig = @{ Name = 'Custom'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse'; GenerateVMJobs = $true }
    $weights = @{}
    foreach ($name in @('A', 'B', 'C', 'D', 'E', 'F')) {
      $config = if ($name -eq 'D') { $customConfig } else { $defaultConfig }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = @($config) } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
      $weights[$name] = 100
    }
    $weights | ConvertTo-Json | Set-Content $weightsFile
    $matrixFile = Join-Path $TestDrive 'matrix.json'
    ConvertTo-Json -InputObject @($defaultConfig) -Depth 10 | Set-Content $matrixFile
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -SelectionSeed 0 -Target 1000
    @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse).Count | Should -Be 2

    $env:LINUXPOOL = 'azsdk-pool'; $env:WINDOWSPOOL = 'azsdk-pool'; $env:MACPOOL = 'Azure Pipelines'
    $env:LINUXVMIMAGE = 'ubuntu-24.04'; $env:WINDOWSVMIMAGE = 'windows-2022'; $env:MACVMIMAGE = 'macos-latest'
    $matrixScript = Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'job-matrix' 'Create-PrJobMatrix.ps1'
    $matrix = & $matrixScript -PackagePropertiesFolder $outputFolder -PRMatrixFile $matrixFile `
      -PRMatrixSetting ProjectNames -DisplayNameFilter '.*' -Filters @('Pool=.*MacPool$') `
      -PackagesPerPRJob 1 -CI:$false | ConvertFrom-Json -AsHashtable
    foreach ($name in @('A', 'D')) {
      $legs = @($matrix.Values | Where-Object { $_.ProjectNames -eq $name })
      $legs.Count | Should -Be 3
      @($legs.TestTargetFramework | Sort-Object) | Should -Be @('net10.0', 'net8.0', 'net9.0')
    }
    @($matrix.Values | Where-Object { $_.ProjectNames -notin @('A', 'D') }).Count | Should -Be 0
  }

  It "leaves Linux and Windows direct and Linux indirect matrix assignments unchanged" {
    $config = @{ Name = 'Default'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse'; GenerateVMJobs = $true }
    foreach ($name in @('A', 'B', 'C', 'D', 'E', 'F', 'Indirect')) {
      @{ ArtifactName = $name; IncludedForValidation = ($name -eq 'Indirect'); CIParameters = @{ CIMatrixConfigs = $null } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    $matrixFile = Join-Path $TestDrive 'matrix.json'
    ConvertTo-Json -InputObject @($config) -Depth 10 | Set-Content $matrixFile
    $env:LINUXPOOL = 'azsdk-pool'; $env:WINDOWSPOOL = 'azsdk-pool'; $env:MACPOOL = 'Azure Pipelines'
    $env:LINUXVMIMAGE = 'ubuntu-24.04'; $env:WINDOWSVMIMAGE = 'windows-2022'; $env:MACVMIMAGE = 'macos-latest'
    $matrixScript = Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'job-matrix' 'Create-PrJobMatrix.ps1'
    $baseline = @{}
    foreach ($pool in @('Linux', 'Windows')) {
      $baseline[$pool] = & $matrixScript -PackagePropertiesFolder $inputFolder -PRMatrixFile $matrixFile `
        -PRMatrixSetting ProjectNames -DisplayNameFilter '.*' -Filters @("Pool=.*${pool}Pool$") `
        -IndirectFilters @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$') -PackagesPerPRJob 1 -CI:$false
    }
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -SelectionSeed 0
    foreach ($pool in @('Linux', 'Windows')) {
      $after = & $matrixScript -PackagePropertiesFolder $inputFolder -PRMatrixFile $matrixFile `
        -PRMatrixSetting ProjectNames -DisplayNameFilter '.*' -Filters @("Pool=.*${pool}Pool$") `
        -IndirectFilters @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$') -PackagesPerPRJob 1 -CI:$false
      $after | Should -Be $baseline[$pool]
    }
    $linux = $baseline.Linux | ConvertFrom-Json -AsHashtable
    @($linux.Values | Where-Object { $_.ProjectNames -eq 'Indirect' }).Count | Should -Be 1
    $windows = $baseline.Windows | ConvertFrom-Json -AsHashtable
    @($windows.Values | Where-Object { $_.ProjectNames -eq 'Indirect' }).Count | Should -Be 0
  }

  It "falls back to counts for malformed weights and supports an empty direct set" {
    @{ ArtifactName = 'Indirect'; IncludedForValidation = $true; CIParameters = @{} } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder 'indirect.json')
    'not json' | Set-Content $weightsFile
    { & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile } | Should -Not -Throw
    @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse).Count | Should -Be 0
  }

  It "handles a dominant weight without dropping the remaining groups" {
    $weights = @{ A = 1000; B = 10; C = 10; D = 10 }
    foreach ($name in $weights.Keys) {
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{} } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder "$name.json")
    }
    $weights | ConvertTo-Json | Set-Content $weightsFile
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -SelectionSeed 0
    $names = @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse |
      ForEach-Object { (Get-Content $_.FullName -Raw | ConvertFrom-Json).ArtifactName -split ',' })
    $names | Should -Be @('A')
  }

  It "uses count-based selection when weights are unavailable and keeps a single direct package" {
    @{ ArtifactName = 'A'; IncludedForValidation = $false; CIParameters = @{} } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $inputFolder 'A.json')
    & $scriptPath -PackageInfoFolder $inputFolder -OutputFolder $outputFolder -WeightsFile $weightsFile -SelectionSeed 2
    $files = @(Get-ChildItem $outputFolder -Filter '*.json' -Recurse)
    $files.Count | Should -Be 1
    (Get-Content $files[0].FullName -Raw | ConvertFrom-Json).ArtifactName | Should -Be 'A'
  }
}

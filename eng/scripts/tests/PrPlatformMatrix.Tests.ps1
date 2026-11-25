#Requires -Version 7.0

BeforeAll {
  $script:root = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
  $script:basePath = 'eng/pipelines/templates/stages/platform-matrix.json'
  $script:prPath = 'eng/pipelines/templates/stages/pr-platform-matrix.json'
  $script:prGenerator = Join-Path $script:root 'eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1'
  $script:oldEnvironment = @{}
  foreach ($name in @('WINDOWSPOOL', 'WINDOWSVMIMAGE', 'LINUXPOOL', 'LINUXVMIMAGE', 'MACPOOL', 'MACVMIMAGE')) {
    $script:oldEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
  }
  $env:WINDOWSPOOL = 'WindowsPool'
  $env:WINDOWSVMIMAGE = 'windows-2022'
  $env:LINUXPOOL = 'LinuxPool'
  $env:LINUXVMIMAGE = 'ubuntu-24.04'
  $env:MACPOOL = 'MacPool'
  $env:MACVMIMAGE = 'macOS'
}

AfterAll {
  foreach ($name in $script:oldEnvironment.Keys) {
    [Environment]::SetEnvironmentVariable($name, $script:oldEnvironment[$name])
  }
}

Describe 'Public PR platform matrix' -Tag 'UnitTest' {
  It 'replaces the duplicate Windows test with coverage in each PR batch' {
    $folder = Join-Path $TestDrive 'packages'
    New-Item -ItemType Directory -Path $folder -Force | Out-Null
    foreach ($name in @('A', 'B', 'C')) {
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = @() } } | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $folder "$name.json")
    }
    $baseConfig = Join-Path $TestDrive 'base.json'
    $prConfig = Join-Path $TestDrive 'pr.json'
    @(@{ Name = 'test'; Path = $script:basePath; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $baseConfig
    @(@{ Name = 'test'; Path = $script:prPath; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $prConfig
    $arguments = @{ PackagePropertiesFolder = $folder; PRMatrixSetting = 'ProjectNames'; PackagesPerPRJob = 2; CI = $false }
    Push-Location $script:root
    try {
      $base = & $script:prGenerator @arguments -PRMatrixFile $baseConfig | ConvertFrom-Json -AsHashtable
      $actual = & $script:prGenerator @arguments -PRMatrixFile $prConfig | ConvertFrom-Json -AsHashtable
    }
    finally { Pop-Location }

    @($base.Keys | Where-Object { $_ -like 'Windows2022_NET100_PackageRef_Debug*' }).Count | Should -Be 2
    @($actual.Keys | Where-Object { $_ -like 'Windows2022_NET100_PackageRef_Debug*' }).Count | Should -Be 0
    $coverageKeys = @($actual.Keys | Where-Object { $_ -like 'Windows2022_NET100_Coverage_Record_PackageRef*' })
    $coverageKeys.Count | Should -Be 2
    foreach ($key in $coverageKeys) {
      $ordinaryKey = $key.Replace('Coverage_Record_PackageRef', 'PackageRef_Debug')
      $base[$ordinaryKey].ProjectNames | Should -Be $base[$key].ProjectNames
      $actual[$key].CollectCoverage | Should -BeTrue
    }
    $actual.Count | Should -Be ($base.Count - 2)
    foreach ($key in $actual.Keys) {
      ($actual[$key] | ConvertTo-Json -Compress) | Should -Be ($base[$key] | ConvertTo-Json -Compress)
    }
  }
}

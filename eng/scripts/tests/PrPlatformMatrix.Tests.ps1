#Requires -Version 7.0

BeforeAll {
  $script:root = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
  $script:basePath = 'eng/pipelines/templates/stages/platform-matrix.json'
  $script:prPath = 'eng/pipelines/templates/stages/pr-platform-matrix.json'
  $script:generator = Join-Path $script:root 'eng/common/scripts/job-matrix/Create-JobMatrix.ps1'
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
  BeforeEach { Push-Location $script:root }
  AfterEach { Pop-Location }

  It 'replaces the duplicate in the sparse matrix without changing other legs' {
    $base = & $script:generator -ConfigPath $script:basePath -Selection sparse -CI:$false | ConvertFrom-Json -AsHashtable
    $actual = & $script:generator -ConfigPath $script:prPath -Selection sparse -CI:$false | ConvertFrom-Json -AsHashtable
    $base.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeTrue
    $actual.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeFalse
    $actual['Windows2022_NET100_Coverage_Record_PackageRef'].CollectCoverage | Should -BeTrue
    $actual.Count | Should -Be ($base.Count - 1)
    foreach ($key in $actual.Keys) {
      ($actual[$key] | ConvertTo-Json -Compress) | Should -Be ($base[$key] | ConvertTo-Json -Compress)
    }
  }

  It 'keeps other Windows configurations in the full matrix' {
    $base = & $script:generator -ConfigPath $script:basePath -Selection all -CI:$false | ConvertFrom-Json -AsHashtable
    $actual = & $script:generator -ConfigPath $script:prPath -Selection all -CI:$false | ConvertFrom-Json -AsHashtable
    $actual.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeFalse
    $actual.ContainsKey('Windows2022_NET100_PackageRef_Release') | Should -BeTrue
    $actual.ContainsKey('Windows2022_NET100_ProjectRef_Debug') | Should -BeTrue
    $actual['Windows2022_NET100_Coverage_Record_PackageRef'].CollectCoverage | Should -BeTrue
    $actual.Count | Should -Be ($base.Count - 1)
    foreach ($key in $actual.Keys) {
      ($actual[$key] | ConvertTo-Json -Compress) | Should -Be ($base[$key] | ConvertTo-Json -Compress)
    }
  }

  It 'excludes the ordinary leg even if a name filter selects only that leg' {
    $actual = & $script:generator -ConfigPath $script:prPath -Selection sparse -DisplayNameFilter '^Windows2022_NET100_PackageRef_Debug$' -CI:$false | ConvertFrom-Json -AsHashtable
    $actual.Count | Should -Be 0
  }

  It 'preserves the coverage project lists in each direct PR batch' {
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
    $base = & $script:prGenerator @arguments -PRMatrixFile $baseConfig | ConvertFrom-Json -AsHashtable
    $actual = & $script:prGenerator @arguments -PRMatrixFile $prConfig | ConvertFrom-Json -AsHashtable
    @($base.Keys | Where-Object { $_ -like 'Windows2022_NET100_PackageRef_Debug*' }).Count | Should -Be 2
    @($actual.Keys | Where-Object { $_ -like 'Windows2022_NET100_PackageRef_Debug*' }).Count | Should -Be 0
    $coverageKeys = @($actual.Keys | Where-Object { $_ -like 'Windows2022_NET100_Coverage_Record_PackageRef*' })
    $coverageKeys.Count | Should -Be 2
    foreach ($key in $coverageKeys) {
      $actual[$key].ProjectNames | Should -Be $base[$key].ProjectNames
    }
    $actual.Count | Should -Be ($base.Count - 2)
    foreach ($key in $actual.Keys) {
      ($actual[$key] | ConvertTo-Json -Compress) | Should -Be ($base[$key] | ConvertTo-Json -Compress)
    }
  }

  It 'leaves explicit per-package matrix configurations unchanged' {
    $folder = Join-Path $TestDrive 'custom'
    New-Item -ItemType Directory -Path $folder -Force | Out-Null
    $customConfig = @{ Name = 'custom'; Path = $script:basePath; Selection = 'sparse' }
    @{ ArtifactName = 'Custom'; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = @($customConfig) } } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $folder 'Custom.json')
    $baseConfig = Join-Path $TestDrive 'base-custom.json'
    $prConfig = Join-Path $TestDrive 'pr-custom.json'
    @(@{ Name = 'test'; Path = $script:basePath; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $baseConfig
    @(@{ Name = 'test'; Path = $script:prPath; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $prConfig
    $arguments = @{ PackagePropertiesFolder = $folder; PRMatrixSetting = 'ProjectNames'; CI = $false }
    $base = & $script:prGenerator @arguments -PRMatrixFile $baseConfig | ConvertFrom-Json -AsHashtable
    $actual = & $script:prGenerator @arguments -PRMatrixFile $prConfig | ConvertFrom-Json -AsHashtable
    ($actual | ConvertTo-Json -Depth 100 -Compress) | Should -Be ($base | ConvertTo-Json -Depth 100 -Compress)
  }

  It 'leaves Linux indirect PR batches unchanged' {
    $folder = Join-Path $TestDrive 'indirect'
    New-Item -ItemType Directory -Path $folder -Force | Out-Null
    foreach ($name in @('A', 'B', 'C')) {
      @{ ArtifactName = $name; IncludedForValidation = $true; CIParameters = @{ CIMatrixConfigs = @() } } | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $folder "$name.json")
    }
    $baseConfig = Join-Path $TestDrive 'base-indirect.json'
    $prConfig = Join-Path $TestDrive 'pr-indirect.json'
    @(@{ Name = 'test'; Path = $script:basePath; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $baseConfig
    @(@{ Name = 'test'; Path = $script:prPath; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $prConfig
    $arguments = @{
      PackagePropertiesFolder = $folder; PRMatrixSetting = 'ProjectNames'; PackagesPerPRJob = 2; CI = $false
      IndirectFilters = @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$')
    }
    $base = & $script:prGenerator @arguments -PRMatrixFile $baseConfig | ConvertFrom-Json -AsHashtable
    $actual = & $script:prGenerator @arguments -PRMatrixFile $prConfig | ConvertFrom-Json -AsHashtable
    ($actual | ConvertTo-Json -Depth 100 -Compress) | Should -Be ($base | ConvertTo-Json -Depth 100 -Compress)
  }
}

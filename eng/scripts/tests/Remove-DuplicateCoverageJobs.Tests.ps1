#Requires -Version 7.0

BeforeAll {
  $script:root = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
  $script:filter = Join-Path $script:root 'eng/scripts/Remove-DuplicateCoverageJobs.ps1'
  $script:matrixSetter = Join-Path $script:root 'eng/scripts/Set-DeduplicatedTestMatrix.ps1'
  function ApplyFilter([string] $json) {
    $message = @(& $script:matrixSetter -MatrixJson $json 6>&1)[-1].ToString()
    $message | Should -Match '^##vso\[task.setvariable variable=matrix;isOutput=true\]'
    return ($message -replace '^##vso\[task.setvariable variable=matrix;isOutput=true\]', '' | ConvertFrom-Json -AsHashtable)
  }
  $script:matrixConfig = Join-Path $script:root 'eng/pipelines/templates/stages/platform-matrix.json'
  $script:generator = Join-Path $script:root 'eng/common/scripts/job-matrix/Create-JobMatrix.ps1'
  $script:prGenerator = Join-Path $script:root 'eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1'
  $script:oldEnvironment = @{}
  foreach ($name in @('BUILDCONFIGURATION', 'WINDOWSPOOL', 'WINDOWSVMIMAGE', 'LINUXPOOL', 'LINUXVMIMAGE', 'MACPOOL', 'MACVMIMAGE')) {
    $script:oldEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
  }
  $env:BUILDCONFIGURATION = 'Debug'
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

Describe 'Remove duplicate Windows coverage jobs' -Tag 'UnitTest' {
  It 'replaces the duplicate in the real sparse matrix, without changing other legs' {
    $base = (& $script:generator -ConfigPath $script:matrixConfig -Selection sparse -CI:$false | ConvertFrom-Json -AsHashtable)
    $actual = ApplyFilter (& $script:generator -ConfigPath $script:matrixConfig -Selection sparse -CI:$false)
    $base.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeTrue
    $actual.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeFalse
    $actual['Windows2022_NET100_Coverage_Record_PackageRef'].CollectCoverage | Should -BeTrue
    $actual.Count | Should -Be ($base.Count - 1)
    foreach ($key in $actual.Keys) {
      ($actual[$key] | ConvertTo-Json -Compress) | Should -Be ($base[$key] | ConvertTo-Json -Compress)
    }
  }

  It 'keeps the normal leg if coverage is filtered out or uses a different default configuration' {
    $filtered = ApplyFilter (& $script:generator -ConfigPath $script:matrixConfig -Selection sparse -DisplayNameFilter '^(?!.*Coverage).*' -CI:$false)
    $filtered.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeTrue
    $env:BUILDCONFIGURATION = 'Release'
    try {
      $different = ApplyFilter (& $script:generator -ConfigPath $script:matrixConfig -Selection sparse -CI:$false)
      $different.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeTrue
    }
    finally { $env:BUILDCONFIGURATION = 'Debug' }
  }

  It 'removes only the equivalent configuration in a full matrix' {
    $base = (& $script:generator -ConfigPath $script:matrixConfig -Selection all -CI:$false | ConvertFrom-Json -AsHashtable)
    $actual = ApplyFilter (& $script:generator -ConfigPath $script:matrixConfig -Selection all -CI:$false)
    $actual.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeFalse
    $actual.ContainsKey('Windows2022_NET100_PackageRef_Release') | Should -BeTrue
    $actual.ContainsKey('Windows2022_NET100_ProjectRef_Debug') | Should -BeTrue
    $actual.Count | Should -Be ($base.Count - 1)

    $env:BUILDCONFIGURATION = 'Release'
    try {
      $release = ApplyFilter (& $script:generator -ConfigPath $script:matrixConfig -Selection all -CI:$false)
      $release.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeTrue
      $release.ContainsKey('Windows2022_NET100_PackageRef_Release') | Should -BeFalse
    }
    finally { $env:BUILDCONFIGURATION = 'Debug' }
  }

  It 'retains both jobs if the default configuration is unknown' {
    $env:BUILDCONFIGURATION = ''
    try {
      $actual = ApplyFilter (& $script:generator -ConfigPath $script:matrixConfig -Selection sparse -CI:$false)
      $actual.ContainsKey('Windows2022_NET100_PackageRef_Debug') | Should -BeTrue
      $actual.ContainsKey('Windows2022_NET100_Coverage_Record_PackageRef') | Should -BeTrue
    }
    finally { $env:BUILDCONFIGURATION = 'Debug' }
  }

  It 'keeps normal jobs with a different project list or other parameters' {
    $ordinary = @{ name = 'Windows2022_NET100_PackageRef_Debug'; parameters = [ordered]@{ TestTargetFramework = 'net10.0'; BuildConfiguration = 'Debug'; ProjectNames = 'A'; Extra = 'one' } }
    $coverage = @{ name = 'Windows2022_NET100_Coverage_Record_PackageRef'; parameters = [ordered]@{ TestTargetFramework = 'net10.0'; CollectCoverage = $true; SupportsRecording = $true; ProjectNames = 'B'; Extra = 'one' } }
    @(& $script:filter -Matrix @($ordinary, $coverage)).Count | Should -Be 2
    $coverage.parameters.ProjectNames = 'A'
    $coverage.parameters.Extra = 'two'
    @(& $script:filter -Matrix @($ordinary, $coverage)).Count | Should -Be 2
    $coverage.parameters.Extra = 'one'
    @(& $script:filter -Matrix @($ordinary, $coverage)).Count | Should -Be 1
  }

  It 'preserves a normal job if a matching coverage job belongs to another batch' {
    $ordinary = @{ name = 'Windows2022_NET100_PackageRef_Debug_ib1'; parameters = [ordered]@{ BuildConfiguration = 'Debug'; ProjectNames = 'A' } }
    $coverage = @{ name = 'Windows2022_NET100_Coverage_Record_PackageRef_ib2'; parameters = [ordered]@{ CollectCoverage = $true; SupportsRecording = $true; ProjectNames = 'B' } }
    @(& $script:filter -Matrix @($ordinary, $coverage)).Count | Should -Be 2
  }

  It 'does not rely on a coverage job hidden by an earlier duplicate job name' {
    $ordinary = @{ name = 'Windows2022_NET100_PackageRef_Debug'; parameters = [ordered]@{ BuildConfiguration = 'Debug'; ProjectNames = 'A' } }
    $first = @{ name = 'Windows2022_NET100_Coverage_Record_PackageRef'; parameters = [ordered]@{ CollectCoverage = $true; ProjectNames = 'B' } }
    $hidden = @{ name = $first.name; parameters = [ordered]@{ CollectCoverage = $true; ProjectNames = 'A' } }
    @(& $script:filter -Matrix @($ordinary, $first, $hidden)).Count | Should -Be 3
  }

  It 'preserves direct package batches in the real PR matrix' {
    $folder = Join-Path $TestDrive 'packages'
    New-Item -ItemType Directory -Path $folder -Force | Out-Null
    foreach ($name in @('A', 'B', 'C')) {
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = @() } } | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $folder "$name.json")
    }
    $config = Join-Path $TestDrive 'matrix.json'
    @(@{ Name = 'test'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }) | ConvertTo-Json -AsArray | Set-Content $config
    $base = (& $script:prGenerator -PackagePropertiesFolder $folder -PRMatrixFile $config -PRMatrixSetting ProjectNames -PackagesPerPRJob 2 -CI:$false | ConvertFrom-Json -AsHashtable)
    $actual = ApplyFilter (& $script:prGenerator -PackagePropertiesFolder $folder -PRMatrixFile $config -PRMatrixSetting ProjectNames -PackagesPerPRJob 2 -CI:$false)
    @($base.Keys | Where-Object { $_ -like 'Windows2022_NET100_PackageRef_Debug*' }).Count | Should -Be 2
    @($actual.Keys | Where-Object { $_ -like 'Windows2022_NET100_PackageRef_Debug*' }).Count | Should -Be 0
    $coverageKeys = @($actual.Keys | Where-Object { $_ -like 'Windows2022_NET100_Coverage_Record_PackageRef*' })
    $coverageKeys.Count | Should -Be 2
    foreach ($key in $coverageKeys) {
      $actual[$key].ProjectNames | Should -Be $base[$key].ProjectNames
    }
    $actual.Count | Should -Be ($base.Count - 2)
  }
}

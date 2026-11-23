# Requires Pester and PowerShell 7.

BeforeAll {
  $repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
  $matrixScript = Join-Path $repoRoot 'eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1'
  $matrixPath = if ($env:PR_MATRIX_TEST_PATH) { $env:PR_MATRIX_TEST_PATH } else { 'eng/pipelines/templates/stages/pr-platform-matrix.json' }
  $originalLocation = Get-Location
  Set-Location $repoRoot

  $oldEnvironment = @{}
  @{
    LINUXPOOL = 'azsdk-pool'; LINUXVMIMAGE = 'ubuntu-24.04'
    WINDOWSPOOL = 'azsdk-pool'; WINDOWSVMIMAGE = 'windows-2022'
    MACPOOL = 'Azure Pipelines'; MACVMIMAGE = 'macos-latest'
  }.GetEnumerator() | ForEach-Object {
    $oldEnvironment[$_.Key] = [Environment]::GetEnvironmentVariable($_.Key)
    [Environment]::SetEnvironmentVariable($_.Key, $_.Value)
  }

  function Get-PRMatrix([string] $pool, [string] $configPath = $matrixPath, [string] $customPath = '', [int] $directCount = 1, [switch] $mixedWeighted, [switch] $overlapWeighted) {
    $packageFolder = Join-Path $TestDrive 'packages'
    if (Test-Path $packageFolder) { Remove-Item $packageFolder -Recurse -Force }
    New-Item -ItemType Directory -Path $packageFolder -Force | Out-Null
    $customConfig = if ($customPath) { @(@{ Name = 'Custom'; Path = $customPath; Selection = 'sparse'; GenerateVMJobs = $true }) } else { @() }
    for ($i = 1; $i -le $directCount; $i++) {
      $name = if ($i -eq 1) { 'Sample.Direct' } else { "Sample.Direct$i" }
      $config = if ($mixedWeighted -and $i -eq 2) { @(@{ Name = 'Custom'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse'; GenerateVMJobs = $true }) } else { $customConfig }
      if ($overlapWeighted -and $i -eq 2) {
        $config = @($config) + @(@{ Name = 'Generator_Net10_Only'; Path = 'sdk/tools/platform-generator-matrix.json'; Selection = 'sparse'; GenerateVMJobs = $true })
      }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = $config } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $packageFolder "direct$i.json")
    }
    @{ ArtifactName = 'Sample.Indirect'; IncludedForValidation = $true; CIParameters = @{ CIMatrixConfigs = @() } } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $packageFolder 'indirect.json')
    @{ ArtifactName = 'Sample.Indirect2'; IncludedForValidation = $true; CIParameters = @{ CIMatrixConfigs = @() } } |
      ConvertTo-Json -Depth 10 | Set-Content (Join-Path $packageFolder 'indirect2.json')
    if ($mixedWeighted -or $overlapWeighted) {
      $weightsFile = Join-Path $TestDrive 'weights.json'
      @{ 'Sample.Direct' = 2; 'Sample.Direct2' = 1; 'Sample.Indirect' = 1; 'Sample.Indirect2' = 1 } |
        ConvertTo-Json | Set-Content $weightsFile
      & (Join-Path $repoRoot 'eng/scripts/Apply-WeightedBatching.ps1') `
        -PackageInfoFolder $packageFolder -WeightsFile $weightsFile -Target 240 -GroupByMatrixConfig
    }
    $configFile = Join-Path $TestDrive 'matrix-config.json'
    @(@{ Name = 'NET_ci_test_base'; Path = $configPath; Selection = 'sparse'; GenerateVMJobs = $true }) |
      ConvertTo-Json -Depth 10 -AsArray | Set-Content $configFile
    $output = & $matrixScript -PackagePropertiesFolder $packageFolder -PRMatrixFile $configFile `
      -PRMatrixSetting ProjectNames -DisplayNameFilter '.*' `
      -Filters @('container=^$', 'SupportedClouds=^$|public', "Pool=.*${pool}Pool$") `
      -IndirectFilters @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$', 'PRDirectOnly=^$') `
      -PackagesPerPRJob 1 -CI
    $serialized = $output | Where-Object { $_ -is [string] -and $_.StartsWith('##vso[task.setVariable') } | Select-Object -Last 1
    if (!$serialized) { throw 'Matrix output was not generated.' }
    return ($serialized.Substring($serialized.IndexOf(']') + 1) | ConvertFrom-Json -AsHashtable)
  }
}

AfterAll {
  Set-Location $originalLocation
  foreach ($name in $oldEnvironment.Keys) {
    [Environment]::SetEnvironmentVariable($name, $oldEnvironment[$name])
  }
}

Describe 'PR test platform matrix' -Tag 'UnitTest' {
  It 'selects the PR matrix only for pull request runs' {
    $pipeline = Get-Content (Join-Path $repoRoot 'eng/pipelines/pullrequest.yml') -Raw
    $pipeline | Should -Match '(?s)\$\{\{ if eq\(variables\[''Build.Reason''\], ''PullRequest''\) \}\}:\s*MatrixConfigs:.*?Path: eng/pipelines/templates/stages/pr-platform-matrix\.json'
  }

  It 'retains only the .NET 10 macOS job for direct packages and no macOS indirect job' {
    $matrix = Get-PRMatrix 'Mac'
    @($matrix.Keys).Count | Should -Be 1
    $job = $matrix['MacOS_NET100_ProjectRef_Release']
    $job.TestTargetFramework | Should -Be 'net10.0'
    $job.ProjectNames | Should -Be 'Sample.Direct'
  }

  It 'enables matrix-aware grouping for runtime-weighted PR tests' {
    $presteps = Get-Content (Join-Path $repoRoot 'eng/pipelines/templates/steps/pr-matrix-presteps.yml') -Raw
    $presteps | Should -Match '(?s)Apply-WeightedBatching\.ps1\s*`.*?-Target 240\s*`\s*-GroupByMatrixConfig'
  }

  It 'keeps one macOS leg when the base matrix adds another framework' {
    . (Join-Path $repoRoot 'eng/common/scripts/job-matrix/job-matrix-functions.ps1')
    $base = Get-Content (Join-Path $repoRoot 'eng/pipelines/templates/stages/platform-matrix.json') -Raw | ConvertFrom-Json
    $base.matrix.Agent | Add-Member -NotePropertyName 'MacOS_SYNTHETIC' -NotePropertyValue ([pscustomobject]@{
      OSVmImage = 'env:MACVMIMAGE'; Pool = 'env:MACPOOL'; TestTargetFramework = 'net99.0'
    })
    $basePath = Join-Path $TestDrive 'future-platform-matrix.json'
    $base | ConvertTo-Json -Depth 100 | Set-Content $basePath
    $prConfig = Get-Content (Join-Path $repoRoot $matrixPath) -Raw | ConvertFrom-Json
    $prConfig.matrix.'$IMPORT' = $basePath
    $config = GetMatrixConfigFromJson ($prConfig | ConvertTo-Json -Depth 100)
    $matrix = @(GenerateMatrix -config $config -selectFromMatrixType 'sparse' -filters @('Pool=.*MacPool$'))
    $matrix.Count | Should -Be 1
    $matrix[0].parameters.TestTargetFramework | Should -Be 'net10.0'
  }

  It 'runs one macOS job for each direct batch' {
    $matrix = Get-PRMatrix 'Mac' -directCount 2
    @($matrix.Keys).Count | Should -Be 2
    @($matrix.Values.ProjectNames | Sort-Object) | Should -Be @('Sample.Direct', 'Sample.Direct2')
    @($matrix.Values | Where-Object { $_.TestTargetFramework -ne 'net10.0' }).Count | Should -Be 0
  }

  It 'preserves an explicitly configured package matrix' {
    $base = Get-PRMatrix 'Mac' 'eng/pipelines/templates/stages/platform-matrix.json'
    $matrix = Get-PRMatrix 'Mac' -customPath 'eng/pipelines/templates/stages/platform-matrix.json'
    @($matrix.Keys | Sort-Object) | Should -Be @($base.Keys | Sort-Object)
    @($matrix.Values | Where-Object { $_.ProjectNames -ne 'Sample.Direct' }).Count | Should -Be 0
  }

  It 'preserves default and custom matrices when runtime weighting batches packages' {
    $base = Get-PRMatrix 'Mac' 'eng/pipelines/templates/stages/platform-matrix.json'
    $matrix = Get-PRMatrix 'Mac' -directCount 2 -mixedWeighted
    @($matrix.Keys).Count | Should -Be (1 + $base.Count)
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct' }).Count | Should -Be 1
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct2' }).Count | Should -Be $base.Count
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct2' } | ForEach-Object { $_.TestTargetFramework } | Sort-Object) |
      Should -Be @($base.Values.TestTargetFramework | Sort-Object)
  }

  It 'preserves overlapping matrix configurations through weighted batching' {
    $base = Get-PRMatrix 'Mac' 'eng/pipelines/templates/stages/platform-matrix.json'
    $matrix = Get-PRMatrix 'Mac' -directCount 2 -customPath 'eng/pipelines/templates/stages/platform-matrix.json' -overlapWeighted
    @($matrix.Keys).Count | Should -Be (2 * $base.Count + 1)
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct' }).Count | Should -Be $base.Count
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct2' }).Count | Should -Be ($base.Count + 1)
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct2' -and $_.TestTargetFramework -eq 'net10.0' -and $_.BuildConfiguration -eq 'Debug' }).Count | Should -Be 1
  }

  It 'still batches packages that share the default matrix' {
    $base = Get-PRMatrix 'Mac' 'eng/pipelines/templates/stages/platform-matrix.json'
    $matrix = Get-PRMatrix 'Mac' -directCount 4 -mixedWeighted
    @($matrix.Keys).Count | Should -Be (1 + $base.Count)
    $defaultJob = @($matrix.Values | Where-Object { $_.ProjectNames -like '*Sample.Direct3*' })
    $defaultJob.Count | Should -Be 1
    @($defaultJob[0].ProjectNames -split ',' | Sort-Object) | Should -Be @('Sample.Direct', 'Sample.Direct3', 'Sample.Direct4')
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Sample.Direct2' }).Count | Should -Be $base.Count
  }

  It 'keeps matrix configurations with case-sensitive paths in separate weighted buckets' {
    $packageFolder = Join-Path $TestDrive 'case-packages'
    New-Item -ItemType Directory -Path $packageFolder -Force | Out-Null
    foreach ($name in @('A', 'B')) {
      $path = if ($name -eq 'A') { 'matrix.json' } else { 'MATRIX.json' }
      @{ ArtifactName = $name; IncludedForValidation = $false; CIParameters = @{ CIMatrixConfigs = @(@{ Path = $path }) } } |
        ConvertTo-Json -Depth 10 | Set-Content (Join-Path $packageFolder "$name.json")
    }
    $weightsFile = Join-Path $TestDrive 'case-weights.json'
    @{ A = 2; B = 1 } | ConvertTo-Json | Set-Content $weightsFile
    & (Join-Path $repoRoot 'eng/scripts/Apply-WeightedBatching.ps1') `
      -PackageInfoFolder $packageFolder -WeightsFile $weightsFile -Target 240 -GroupByMatrixConfig
    @(Get-ChildItem $packageFolder -Filter '*.json').Count | Should -Be 2
  }

  It 'retains the dropped reference and configuration combinations on Linux' {
    $matrix = Get-PRMatrix 'Linux'
    $matrix['Ubuntu2404_NET80_ProjectRef_Release'].ProjectNames | Should -Be 'Sample.Direct'
    $matrix['Ubuntu2404_NET90_PackageRef_Debug'].ProjectNames | Should -Be 'Sample.Direct'
    $matrix['Ubuntu2404_NET80_PackageRef_Debug'].ProjectNames | Should -Be 'Sample.Direct'
    $matrix['Ubuntu2404_NET90_ProjectRef_Release'].ProjectNames | Should -Be 'Sample.Direct'
    $matrix['Ubuntu2404_NET100_PackageRef_Debug'].ProjectNames | Should -Be 'Sample.Direct'
    $indirectJobs = @($matrix.Values | Where-Object { $_.ProjectNames -like 'Sample.Indirect*' })
    $indirectJobs.Count | Should -Be 2
    $base = Get-PRMatrix 'Linux' 'eng/pipelines/templates/stages/platform-matrix.json'
    $baseIndirectJobs = @($base.Values | Where-Object { $_.ProjectNames -like 'Sample.Indirect*' })
    @($indirectJobs.TestTargetFramework | Sort-Object) | Should -Be @($baseIndirectJobs.TestTargetFramework | Sort-Object)
  }

  It 'applies the direct-only filter to indirect packages in the PR pipeline' {
    $ciTemplate = Get-Content (Join-Path $repoRoot 'eng/pipelines/templates/jobs/ci.yml') -Raw
    $ciTemplate | Should -Match '(?s)PRMatrixIndirectFilters:.*?PRDirectOnly=\^\$'
  }

  It 'leaves the Windows matrix intact' {
    $base = Get-PRMatrix 'Windows' 'eng/pipelines/templates/stages/platform-matrix.json'
    $matrix = Get-PRMatrix 'Windows'
    @($matrix.Keys | Sort-Object) | Should -Be @($base.Keys | Sort-Object)
    $matrix['Windows2022_NET100_Coverage_Record_PackageRef'].CollectCoverage | Should -BeTrue
  }

  It 'leaves the original matrix available for scheduled jobs' {
    $matrix = Get-PRMatrix 'Mac' 'eng/pipelines/templates/stages/platform-matrix.json'
    @($matrix.Keys).Count | Should -BeGreaterThan 1
    @($matrix.Values | Where-Object { $_.TestTargetFramework -eq 'net10.0' }).Count | Should -Be 1
  }
}

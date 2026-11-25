BeforeAll {
  $script:selector = Join-Path $PSScriptRoot '..' 'Select-PrTestPackages.ps1'
  $script:repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
  $script:originalEnvironment = @{}
  foreach ($name in @('LINUXPOOL', 'LINUXVMIMAGE', 'WINDOWSPOOL', 'WINDOWSVMIMAGE', 'MACPOOL', 'MACVMIMAGE')) {
    $script:originalEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
  }
  . (Join-Path $script:repoRoot 'eng/common/scripts/Helpers/PSModule-Helpers.ps1')
  Install-ModuleIfNotInstalled 'powershell-yaml' '0.4.1' | Import-Module
  $matrixTemplate = Get-Content (Join-Path $script:repoRoot 'eng/pipelines/templates/jobs/pr-test-matrix.yml') -Raw | ConvertFrom-Yaml
  $conditionalFilter = $matrixTemplate.jobs[0].parameters.MatrixFilters[1]
  $script:serviceFilter = @($conditionalFilter.Values)[0][0]
  $script:serviceConfig = @{ Name = 'NET_ci_service_projectref'; Path = 'eng/pipelines/templates/stages/pr-service-projectref-matrix.json'; Selection = 'sparse'; GenerateVMJobs = $true }
  $script:defaultConfigs = @(@{ Name = 'test'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }) | ConvertTo-Json -AsArray

  function Invoke-PackageSelection($folder, $scope) {
    & $script:selector -PackageInfoFolder $folder -Scope $scope -DefaultMatrixConfigs $script:defaultConfigs
  }

  function New-PackageInfo($folder, $name, $path, $indirect = $false) {
    @{
      ArtifactName = $name
      DirectoryPath = $path
      IncludedForValidation = $indirect
      CIParameters = @{ CIMatrixConfigs = @() }
    } | ConvertTo-Json -Depth 10 | Set-Content (Join-Path $folder "$name.json")
  }

  function Get-TestMatrix($folder, $configPath, $filters, $indirectFilters = @()) {
    $result = & (Join-Path $script:repoRoot 'eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1') `
      -PackagePropertiesFolder $folder -PRMatrixFile $configPath -PRMatrixSetting ProjectNames `
      -Filters $filters -IndirectFilters $indirectFilters -PackagesPerPRJob 10 -CI:$false
    return ($result | ConvertFrom-Json -AsHashtable)
  }
}

AfterAll {
  foreach ($name in $script:originalEnvironment.Keys) {
    [Environment]::SetEnvironmentVariable($name, $script:originalEnvironment[$name])
  }
}

Describe 'PR test package selection' -Tag 'UnitTest' {
  BeforeEach {
    $folder = Join-Path $TestDrive 'PackageInfo'
    Remove-Item $folder -Recurse -Force -ErrorAction SilentlyContinue
    New-Item -ItemType Directory -Force $folder | Out-Null
    New-PackageInfo $folder 'System.ClientModel' 'sdk/core/System.ClientModel'
    New-PackageInfo $folder 'Azure.Storage.Blobs' 'sdk/storage/Azure.Storage.Blobs'
    New-PackageInfo $folder 'Indirect.Service' 'sdk/storage/Indirect.Service' $true
    New-PackageInfo $folder 'Unknown' 'eng/packages/unknown'
  }

  It 'retains core and unclassified packages in the full matrix' {
    Invoke-PackageSelection $folder 'core'
    @(Get-ChildItem $folder -Filter '*.json' | ForEach-Object BaseName | Sort-Object) | Should -Be @('System.ClientModel', 'Unknown')
  }

  It 'retains direct and indirect service packages in the reduced matrix' {
    Invoke-PackageSelection $folder 'service'
    @(Get-ChildItem $folder -Filter '*.json' | ForEach-Object BaseName | Sort-Object) | Should -Be @('Azure.Storage.Blobs', 'Indirect.Service')
  }

  It 'supports Windows separators and leading relative paths' {
    New-PackageInfo $folder 'Other.Core' '.\sdk\core\Other.Core'
    New-PackageInfo $folder 'Other.Service' 'sdk\other\Other.Service'
    Invoke-PackageSelection $folder 'service'
    Test-Path (Join-Path $folder 'Other.Core.json') | Should -BeFalse
    Test-Path (Join-Path $folder 'Other.Service.json') | Should -BeTrue
  }

  It 'fails rather than silently dropping packages when metadata is invalid' {
    Set-Content (Join-Path $folder 'broken.json') '{invalid'
    { Invoke-PackageSelection $folder 'service' } | Should -Throw
    @(Get-ChildItem $folder -Filter '*.json').Count | Should -Be 5
  }

  It 'leaves an empty scope as an empty matrix' {
    Invoke-PackageSelection $folder 'service'
    Invoke-PackageSelection $folder 'core'
    $config = Join-Path $TestDrive 'empty-matrix.json'
    @(@{ Name = 'test'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'all' }) |
      ConvertTo-Json -AsArray | Set-Content $config
    (Get-TestMatrix $folder $config @()).Count | Should -Be 0
  }

  It 'parses matrix output when the CI environment is present' {
    $existed = Test-Path Env:SYSTEM_TEAMPROJECTID
    $previous = [Environment]::GetEnvironmentVariable('SYSTEM_TEAMPROJECTID')
    try {
      $env:SYSTEM_TEAMPROJECTID = 'test-project'
      $env:LINUXPOOL = 'LinuxPool'; $env:LINUXVMIMAGE = 'linux'
      $env:WINDOWSPOOL = 'WindowsPool'; $env:WINDOWSVMIMAGE = 'windows'
      $env:MACPOOL = 'MacPool'; $env:MACVMIMAGE = 'mac'
      $empty = Join-Path $TestDrive 'empty-ci'
      New-Item -ItemType Directory -Force $empty | Out-Null
      $config = Join-Path $TestDrive 'ci-config.json'
      Set-Content $config $script:defaultConfigs
      (Get-TestMatrix $empty $config @()).Count | Should -Be 0
      $matrix = & (Join-Path $script:repoRoot 'eng/common/scripts/job-matrix/Create-JobMatrix.ps1') `
        -ConfigPath (Join-Path $script:repoRoot 'eng/pipelines/templates/stages/platform-matrix.json') `
        -Selection sparse -Filters @('Pool=LinuxPool') -CI:$false | ConvertFrom-Json -AsHashtable
      $matrix.Count | Should -BeGreaterThan 0
    }
    finally {
      if ($existed) { [Environment]::SetEnvironmentVariable('SYSTEM_TEAMPROJECTID', $previous) }
      else { Remove-Item Env:SYSTEM_TEAMPROJECTID -ErrorAction SilentlyContinue }
    }
  }

  It 'retains sparse indirect service project-reference coverage' {
    $env:LINUXPOOL = 'LinuxPool'; $env:LINUXVMIMAGE = 'linux'
    $env:WINDOWSPOOL = 'WindowsPool'; $env:WINDOWSVMIMAGE = 'windows'
    $env:MACPOOL = 'MacPool'; $env:MACVMIMAGE = 'mac'
    Invoke-PackageSelection $folder 'service'
    $config = Join-Path $TestDrive 'sparse-matrix.json'
    @(@{ Name = 'test'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }) |
      ConvertTo-Json -AsArray | Set-Content $config
    $matrix = Get-TestMatrix $folder $config @('Pool=LinuxPool', $script:serviceFilter) @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$')
    $indirect = @($matrix.Values | Where-Object { $_.ProjectNames -match 'Indirect.Service' })
    $indirect.Count | Should -BeGreaterThan 0
    @($indirect | Where-Object TestTargetFramework -EQ 'net9.0').Count | Should -Be 0
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Azure.Storage.Blobs' -and $_.AdditionalTestArguments -match 'true' }).Count | Should -BeGreaterThan 0
    $packageOnly = Get-TestMatrix $folder $config @('Pool=LinuxPool', $script:serviceFilter, 'AdditionalTestArguments=.*false')
    @($packageOnly.Values | Where-Object { $_.AdditionalTestArguments -match 'true' }).Count | Should -Be 0
  }

  It 'does not add the indirect fallback to a direct custom matrix' {
    $path = Join-Path $folder 'Azure.Storage.Blobs.json'
    $package = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
    $package.CIParameters.CIMatrixConfigs = @(@{ Name = 'custom'; Path = 'custom.json'; Selection = 'sparse' })
    $package | ConvertTo-Json -Depth 10 | Set-Content $path
    Invoke-PackageSelection $folder 'service'
    @((Get-Content $path -Raw | ConvertFrom-Json).CIParameters.CIMatrixConfigs).Count | Should -Be 1
  }

  It 'does not add a direct project-reference fallback when the service excludes it' {
    foreach ($item in @(
      @{ Name = 'Azure.AI.OpenAI'; Directory = 'sdk/openai/Azure.AI.OpenAI'; Ci = '/sdk/openai/ci.yml' },
      @{ Name = 'Azure.AI.Projects'; Directory = 'sdk/ai/Azure.AI.Projects'; Ci = '/sdk/ai/ci.projects.yml' }
    )) {
      New-PackageInfo $folder $item.Name $item.Directory
      $path = Join-Path $folder "$($item.Name).json"
      $package = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
      $package.ArtifactDetails = @{ triggeringPaths = @($item.Ci) }
      $package | ConvertTo-Json -Depth 10 | Set-Content $path
    }
    Invoke-PackageSelection $folder 'service'
    foreach ($name in @('Azure.AI.OpenAI', 'Azure.AI.Projects')) {
      $configs = @((Get-Content (Join-Path $folder "$name.json") -Raw | ConvertFrom-Json).CIParameters.CIMatrixConfigs)
      @($configs | Where-Object Path -EQ $script:serviceConfig.Path).Count | Should -Be 0
    }
  }

  It 'retains the project-reference fallback for packages with custom matrices' {
    $env:LINUXPOOL = 'LinuxPool'; $env:LINUXVMIMAGE = 'linux'
    $env:WINDOWSPOOL = 'WindowsPool'; $env:WINDOWSVMIMAGE = 'windows'
    $env:MACPOOL = 'MacPool'; $env:MACVMIMAGE = 'mac'
    $path = Join-Path $folder 'Indirect.Service.json'
    $package = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
    $package.CIParameters.CIMatrixConfigs = @(@{ Name = 'custom'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' })
    $package | ConvertTo-Json -Depth 10 | Set-Content $path
    Invoke-PackageSelection $folder 'service'
    Invoke-PackageSelection $folder 'service'
    $configs = (Get-Content $path -Raw | ConvertFrom-Json).CIParameters.CIMatrixConfigs
    @($configs | Where-Object Path -EQ $script:serviceConfig.Path).Count | Should -Be 1
    @($configs | Where-Object Name -EQ 'custom').Count | Should -Be 1
    $config = Join-Path $TestDrive 'custom-matrix.json'
    @(@{ Name = 'test'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' }) |
      ConvertTo-Json -AsArray | Set-Content $config
    $matrix = Get-TestMatrix $folder $config @('Pool=LinuxPool', $script:serviceFilter) @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$')
    @($matrix.Values | Where-Object { $_.ProjectNames -match 'Indirect.Service' }).Count | Should -BeGreaterThan 0
  }

  It 'preserves default and custom service matrices through weighted generation' {
    $env:LINUXPOOL = 'LinuxPool'; $env:LINUXVMIMAGE = 'linux'
    $env:WINDOWSPOOL = 'WindowsPool'; $env:WINDOWSVMIMAGE = 'windows'
    $env:MACPOOL = 'MacPool'; $env:MACVMIMAGE = 'mac'
    New-PackageInfo $folder 'Custom.Service' 'sdk/other/Custom.Service'
    $path = Join-Path $folder 'Custom.Service.json'
    $package = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
    $package.CIParameters.CIMatrixConfigs = @(@{ Name = 'custom'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'sparse' })
    $package | ConvertTo-Json -Depth 10 | Set-Content $path
    Invoke-PackageSelection $folder 'service'
    $weights = Join-Path $TestDrive 'custom-weights.json'
    @{ 'Azure.Storage.Blobs' = 120; 'Custom.Service' = 100; 'Indirect.Service' = 1 } | ConvertTo-Json | Set-Content $weights
    & (Join-Path $script:repoRoot 'eng/scripts/Apply-WeightedBatching.ps1') `
      -PackageInfoFolder $folder -WeightsFile $weights -Target 240 -GroupByMatrixConfigs
    $config = Join-Path $TestDrive 'weighted-config.json'
    Set-Content $config $script:defaultConfigs
    $matrix = Get-TestMatrix $folder $config @('Pool=LinuxPool', $script:serviceFilter) @('AdditionalTestArguments=.*true', 'Pool=.*LinuxPool$')
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Custom.Service' }).Count | Should -BeGreaterThan 0
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Azure.Storage.Blobs' }).Count | Should -BeGreaterThan 0
    @($matrix.Values | Where-Object { $_.ProjectNames -eq 'Indirect.Service' }).Count | Should -BeGreaterThan 0
  }

  It 'retains every dependency test group after excluding net9 agents' {
    $env:LINUXPOOL = 'LinuxPool'; $env:LINUXVMIMAGE = 'linux'
    $env:WINDOWSPOOL = 'WindowsPool'; $env:WINDOWSVMIMAGE = 'windows'
    $env:MACPOOL = 'MacPool'; $env:MACVMIMAGE = 'mac'
    . (Join-Path $script:repoRoot 'eng/scripts/splittestdependencies/generate-dependency-functions.ps1')
    $matrixPath = Join-Path $TestDrive 'dependency-matrix.json'
    $output = Join-Path $TestDrive 'dependency-output'
    Copy-Item (Join-Path $script:repoRoot 'eng/pipelines/templates/stages/platform-matrix.json') $matrixPath
    $projects = @(0..9 | ForEach-Object { "ProjectListOverrideFile_Project_$_.props" })
    Write-Project-Files-To-Matrix $projects $matrixPath $output 'ProjectListOverrideFile'
    & (Join-Path $script:repoRoot 'eng/scripts/Remove-Net9FromTestMatrix.ps1') -MatrixPath $matrixPath
    $matrix = & (Join-Path $script:repoRoot 'eng/common/scripts/job-matrix/Create-JobMatrix.ps1') `
      -ConfigPath $matrixPath -Selection sparse -Filters @($script:serviceFilter) -CI:$false | ConvertFrom-Json -AsHashtable
    $selected = @($matrix.Values | ForEach-Object ProjectListOverrideFile | Sort-Object -Unique)
    $selected.Count | Should -Be 10
    @($matrix.Values | Where-Object TestTargetFramework -EQ 'net9.0').Count | Should -Be 0
  }

  It 'keeps the dependency-test filter limited to named non-core PRs' {
    $ci = Get-Content (Join-Path $script:repoRoot 'eng/pipelines/templates/jobs/ci.yml') -Raw | ConvertFrom-Yaml
    $dependencyJob = @($ci.jobs | Where-Object { $_.ContainsKey('${{ if ne(parameters.TestDependsOnDependency, ''not-specified'') }}') })[0]
    $generator = @($dependencyJob.Values)[0][0]
    $condition = @($generator.parameters.MatrixFilters[1].Keys)[0]
    $condition | Should -Match "Build.Reason.*PullRequest"
    $condition | Should -Match "ServiceDirectory.*core"
    @($generator.parameters.MatrixFilters[1].Values)[0][0] | Should -Be $script:serviceFilter
  }

  It 'generates core net9 jobs but no service net9 jobs after weighted batching' {
    $env:LINUXPOOL = 'LinuxPool'
    $env:LINUXVMIMAGE = 'linux'
    $env:WINDOWSPOOL = 'WindowsPool'
    $env:WINDOWSVMIMAGE = 'windows'
    $env:MACPOOL = 'MacPool'
    $env:MACVMIMAGE = 'mac'
    $config = Join-Path $TestDrive 'matrix.json'
    @(@{ Name = 'test'; Path = 'eng/pipelines/templates/stages/platform-matrix.json'; Selection = 'all' }) |
      ConvertTo-Json -AsArray | Set-Content $config
    $weights = Join-Path $TestDrive 'weights.json'
    @{ 'System.ClientModel' = 1; 'Azure.Storage.Blobs' = 1; 'Indirect.Service' = 1; 'Unknown' = 1 } |
      ConvertTo-Json | Set-Content $weights

    $core = Join-Path $TestDrive 'core'
    $service = Join-Path $TestDrive 'service'
    Copy-Item $folder $core -Recurse
    Copy-Item $folder $service -Recurse
    foreach ($scope in @('core', 'service')) {
      $scopeFolder = Join-Path $TestDrive $scope
      Invoke-PackageSelection $scopeFolder $scope
      & (Join-Path $script:repoRoot 'eng/scripts/Apply-WeightedBatching.ps1') `
        -PackageInfoFolder $scopeFolder -WeightsFile $weights -Target 240 -GroupByMatrixConfigs
    }

    $coreMatrix = Get-TestMatrix $core $config @('Pool=LinuxPool')
    $serviceMatrix = Get-TestMatrix $service $config @('Pool=LinuxPool', $script:serviceFilter)
    $coreNet9 = @($coreMatrix.Values | Where-Object TestTargetFramework -EQ 'net9.0')
    $coreNet9.Count | Should -BeGreaterThan 0
    @($coreNet9 | Where-Object { $_.ProjectNames -notmatch 'System.ClientModel' }).Count | Should -Be 0
    @($serviceMatrix.Values | Where-Object TestTargetFramework -EQ 'net9.0').Count | Should -Be 0
    @($serviceMatrix.Values | Where-Object TestTargetFramework -EQ 'net8.0').Count | Should -BeGreaterThan 0
    @($serviceMatrix.Values | Where-Object TestTargetFramework -EQ 'net10.0').Count | Should -BeGreaterThan 0
    @($serviceMatrix.Values | Where-Object { $_.ProjectNames -match 'System.ClientModel' }).Count | Should -Be 0
    @($serviceMatrix.Values | Where-Object { $_.ProjectNames -match 'Indirect.Service' }).Count | Should -BeGreaterThan 0
  }
}

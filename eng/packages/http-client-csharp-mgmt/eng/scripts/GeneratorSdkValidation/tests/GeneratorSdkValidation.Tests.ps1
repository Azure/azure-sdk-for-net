#Requires -Version 7.0
# Invoke-Pester ./eng/packages/http-client-csharp-mgmt/eng/scripts/GeneratorSdkValidation/tests/GeneratorSdkValidation.Tests.ps1
BeforeAll {
    $script:runner = Join-Path $PSScriptRoot '../ValidateGeneratorSdkChanges.ps1'
    Import-Module (Join-Path $PSScriptRoot '../GeneratorSdkValidation.psm1') -Force -DisableNameChecking
    function New-SdkFixture([string]$Name, [string]$Emitter = 'azure-typespec-http-client-csharp-mgmt-emitter-package') {
        $path = Join-Path $TestDrive "repo/sdk/test/$Name"
        New-Item (Join-Path $path src) -ItemType Directory -Force | Out-Null
        "emitterPackageJsonPath: eng/$Emitter.json" | Set-Content (Join-Path $path tsp-location.yaml)
        return Get-Item $path
    }
}

Describe 'Purpose-based file naming' {
    It 'groups the validation-focused entry point and companion files together' {
        Split-Path (Split-Path $runner -Parent) -Leaf | Should -BeExactly 'GeneratorSdkValidation'
        foreach ($path in @('ValidateGeneratorSdkChanges.ps1', 'GeneratorSdkValidation.psm1',
            'ValidateGeneratorSdkChanges.md', 'ValidateGeneratorSdkChanges.timings.json',
            'tests/GeneratorSdkValidation.Tests.ps1')) {
            Test-Path (Join-Path $PSScriptRoot "../$path") | Should -BeTrue
        }
    }
}

Describe 'CI-equivalent packaged MPG identity' {
    It 'uses the CI PR branch and manual preview title' {
        $id = Get-GeneratorSdkValidationIdentity '@azure-typespec/http-client-csharp-mgmt' '1.0.0-beta.1' 12345 '20261022.123'
        $id.Version | Should -BeExactly '1.0.0-alpha.20261022.123'
        $id.Branch | Should -BeExactly 'validate-typespec-pr-12345-azure-typespec/http-client-csharp-mgmt'
        $id.Title | Should -BeExactly '[Preview] Update azure-typespec/http-client-csharp-mgmt version to prerelease 1.0.0-alpha.20261022.123'
    }
    It 'uses the CI build-number naming convention without a PR' {
        (Get-GeneratorSdkValidationIdentity '@azure-typespec/http-client-csharp-mgmt' '1.0.0' 0 '20261022.123').Branch |
            Should -BeExactly 'validate-typespec-20261022.123-azure-typespec/http-client-csharp-mgmt'
    }
}

Describe 'Selective generator SDK validation' {
    BeforeAll {
        $null = New-SdkFixture 'Azure.ResourceManager.One'
        $null = New-SdkFixture 'Azure.ResourceManager.Two'
        $null = New-SdkFixture 'Azure.Provisioning.Other' 'provisioning-emitter-package'
        $script:fixtureRoot = Join-Path $TestDrive repo
    }
    It 'selects exact case-insensitive names without duplicates' {
        $selected = @(Get-GeneratorSdkValidationServices $fixtureRoot @('azure.resourcemanager.one', 'Azure.ResourceManager.One'))
        $selected.Count | Should -Be 1
        $selected[0].Name | Should -BeExactly 'Azure.ResourceManager.One'
    }
    It 'rejects typos and wildcards instead of broadening the scope' {
        { Get-GeneratorSdkValidationServices $fixtureRoot @('Azure.ResourceManager.Missing') } | Should -Throw '*No management TypeSpec SDK matched*'
        { Get-GeneratorSdkValidationServices $fixtureRoot @('Azure.ResourceManager.*') } | Should -Throw '*No management TypeSpec SDK matched*'
    }
    It 'never treats an empty selection as all services' {
        { Get-GeneratorSdkValidationServices $fixtureRoot @() } | Should -Throw '*Specify exact SDK folder names*'
        { Get-GeneratorSdkValidationServices $fixtureRoot @('') } | Should -Throw '*Specify exact SDK folder names*'
    }
    It 'rejects all-services requests in the selection helper too' {
        { Get-GeneratorSdkValidationServices $fixtureRoot -AllServices } | Should -Throw '*parameter*AllServices*'
        { Get-GeneratorSdkValidationServices $fixtureRoot -Services Azure.ResourceManager.One -AllServices } |
            Should -Throw '*parameter*AllServices*'
    }
    It 'defaults to the 21 eligible priority packages, never all services' {
        $tokens = $null
        $errors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile($runner, [ref]$tokens, [ref]$errors)
        $defaultServices = ($ast.ParamBlock.Parameters | Where-Object { $_.Name.VariablePath.UserPath -eq 'Services' }).DefaultValue.SafeGetValue()
        $defaultServices.Count | Should -Be 21
        $defaultServices | Should -Contain 'Azure.ResourceManager.Network'
        $defaultServices | Should -Not -Contain 'Azure.ResourceManager.Resources'
        @($defaultServices | Where-Object { $_ -notlike 'Azure.ResourceManager.*' }).Count | Should -Be 0
    }
    It 'keeps WhatIf free of worktree and publication side effects' {
        $output = Join-Path $TestDrive 'must-not-exist'
        & $runner -Services Azure.ResourceManager.One -OutputRoot $output -WhatIf
        Test-Path $output | Should -BeFalse
    }
    It 'rejects unsupported scope and nonportable PR requests before side effects' {
        { & $runner -Services Azure.ResourceManager.One -AllServices -WhatIf } | Should -Throw '*parameter*AllServices*'
        { & $runner -CreateDraftPullRequest -WhatIf } | Should -Throw '*requires -PublishPackages*'
    }
}

Describe 'Local selective-only scope' {
    It 'does not expose an all-services option on the public runner' {
        (Get-Command $runner).Parameters.Keys | Should -Not -Contain 'AllServices'
    }
    It 'rejects all-services invocation before creating an output directory' {
        $output = Join-Path $TestDrive 'all-services-must-not-exist'
        { & $runner -AllServices -OutputRoot $output -WhatIf } | Should -Throw '*parameter*AllServices*'
        Test-Path $output | Should -BeFalse
    }
}

Describe 'Publication safety and checked commands' {
    It 'rejects local tarball paths in either emitter file' {
        $config = Join-Path $TestDrive emitter.json
        '{"dependencies":{"@azure-typespec/http-client-csharp-mgmt":"file:/tmp/generator.tgz"}}' | Set-Content $config
        { Assert-GeneratorSdkValidationPortableConfig @($config) } | Should -Throw '*machine-local*'
        '{"resolved":"http://localhost:8000/generator.tgz"}' | Set-Content $config
        { Assert-GeneratorSdkValidationPortableConfig @($config) } | Should -Throw '*machine-local*'
    }
    It 'accepts a portable internal-feed config' {
        $config = Join-Path $TestDrive emitter-portable.json
        '{"resolved":"https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js/npm/registry/package.tgz"}' | Set-Content $config
        { Assert-GeneratorSdkValidationPortableConfig @($config) } | Should -Not -Throw
    }
    It 'propagates native failures and restores the caller location' {
        $location = (Get-Location).Path
        { Invoke-GeneratorSdkValidationCommand pwsh @('-NoProfile', '-Command', 'exit 7') $TestDrive } | Should -Throw '*exited with code 7*'
        (Get-Location).Path | Should -BeExactly $location
    }
}

Describe 'Measured slowest-first scheduling' {
    It 'ranks successful measurements first without changing selected packages' {
        $history = Join-Path $TestDrive timings.json
        @(
            @{ Package = 'Slow'; Success = $true; Seconds = 700 },
            @{ Package = 'Fast'; Success = $true; Seconds = 20 },
            @{ Package = 'Failed'; Success = $false; Seconds = 900 },
            @{ Package = 'Unselected'; Success = $true; Seconds = 2000 }
        ) | ConvertTo-Json | Set-Content $history
        $packages = @('Fast', 'Unknown', 'Slow', 'Failed') | ForEach-Object { [pscustomobject]@{ Name = $_ } }
        $scheduled = @(Get-GeneratorSdkValidationSchedule -Packages $packages -HistoryPath $history)
        ($scheduled.Name -join ',') | Should -BeExactly 'Slow,Fast,Failed,Unknown'
        $scheduled.Count | Should -Be $packages.Count
        $scheduled.Name | Should -Not -Contain 'Unselected'
    }
    It 'preserves the original order when no selected SDK has a measurement' {
        $packages = @('Second', 'First') | ForEach-Object { [pscustomobject]@{ Name = $_ } }
        (@(Get-GeneratorSdkValidationSchedule -Packages $packages).Name -join ',') | Should -BeExactly 'Second,First'
    }
    It 'rejects invalid successful timing measurements' {
        $history = Join-Path $TestDrive invalid-timings.json
        @(@{ Package = 'Slow'; Success = $true; Seconds = -1 }) | ConvertTo-Json -AsArray | Set-Content $history
        { Get-GeneratorSdkValidationSchedule -Packages @([pscustomobject]@{ Name = 'Slow' }) -HistoryPath $history } |
            Should -Throw '*finite nonnegative*'
    }
}

Describe 'Automatic timing history' {
    It 'does not expose a timing-file option on the public runner' {
        (Get-Command $runner).Parameters.Keys | Should -Not -Contain 'TimingFile'
    }
    It 'starts known slow services first without caller-supplied history' {
        $packages = @('Azure.ResourceManager.Dns', 'Azure.ResourceManager.Network', 'Azure.ResourceManager.Compute') |
            ForEach-Object { [pscustomobject]@{ Name = $_ } }
        (@(Get-GeneratorSdkValidationSchedule -Packages $packages).Name -join ',') |
            Should -BeExactly 'Azure.ResourceManager.Network,Azure.ResourceManager.Compute,Azure.ResourceManager.Dns'
    }
    It 'learns successful measurements without discarding other or previously successful timings' {
        $cache = Join-Path $TestDrive cache/timings.json
        Update-GeneratorSdkValidationHistory -HistoryPath $cache -Results @(
            [pscustomobject]@{ Package = 'One'; Success = $true; Seconds = 100 },
            [pscustomobject]@{ Package = 'Two'; Success = $true; Seconds = 200 }
        )
        Update-GeneratorSdkValidationHistory -HistoryPath $cache -Results @(
            [pscustomobject]@{ Package = 'One'; Success = $false; Seconds = 1 },
            [pscustomobject]@{ Package = 'New'; Success = $true; Seconds = 300 }
        )
        $saved = @(Get-Content $cache -Raw | ConvertFrom-Json)
        $saved.Count | Should -Be 3
        ($saved | Where-Object Package -eq 'One').Seconds | Should -Be 100
        $packages = @('One', 'Two', 'New') | ForEach-Object { [pscustomobject]@{ Name = $_ } }
        (@(Get-GeneratorSdkValidationSchedule -Packages $packages -HistoryPath $cache).Name -join ',') |
            Should -BeExactly 'New,Two,One'
    }
    It 'saves successful siblings even if another worker fails' {
        $one = New-SdkFixture 'Azure.ResourceManager.HistorySuccess'
        $two = New-SdkFixture 'Azure.ResourceManager.HistoryFailure'
        '<Project><Target Name="Restore" /><Target Name="GenerateCode" /></Project>' |
            Set-Content (Join-Path $one.FullName "src/$($one.Name).csproj")
        '<Project><Target Name="Restore" /><Target Name="GenerateCode"><Error Text="Expected history fixture failure" /></Target></Project>' |
            Set-Content (Join-Path $two.FullName "src/$($two.Name).csproj")
        $cache = Join-Path $TestDrive partial-cache/timings.json
        { Invoke-GeneratorSdkValidationParallel -Packages @($one, $two) -Parallel 2 -LogDirectory (Join-Path $TestDrive partial-logs) -HistoryPath $cache } |
            Should -Throw '*No commit, push, or PR was attempted*'
        $saved = @(Get-Content $cache -Raw | ConvertFrom-Json)
        $saved.Count | Should -Be 1
        $saved[0].Package | Should -BeExactly $one.Name
    }
}

Describe 'Parallel GenerateCode workers' {
    It 'uses distinct SDK outputs and per-package logs' {
        $one = New-SdkFixture 'Azure.ResourceManager.ParallelOne'
        $two = New-SdkFixture 'Azure.ResourceManager.ParallelTwo'
        foreach ($package in @($one, $two)) {
            '<Project><Target Name="Restore" /><Target Name="GenerateCode"><Error Condition="''$(SkipTspClientInstall)'' != ''true''" Text="Shared install not disabled" /><WriteLinesToFile File="$(MSBuildProjectDirectory)/../generated.txt" Lines="generated" /></Target></Project>' |
                Set-Content (Join-Path $package.FullName "src/$($package.Name).csproj")
        }
        $logs = Join-Path $TestDrive success-logs
        $results = @(Invoke-GeneratorSdkValidationParallel @($one, $two) 2 $logs)
        $results.Count | Should -Be 2
        @($results | Where-Object { -not $_.Success }).Count | Should -Be 0
        foreach ($result in $results) {
            [DateTimeOffset]::Parse($result.FinishedUtc) | Should -BeGreaterOrEqual ([DateTimeOffset]::Parse($result.StartedUtc))
            $result.Seconds | Should -BeGreaterOrEqual 0
        }
        foreach ($package in @($one, $two)) {
            Test-Path (Join-Path $package.FullName generated.txt) | Should -BeTrue
            Test-Path (Join-Path $logs "$($package.Name).log") | Should -BeTrue
        }
    }
    It 'restores package-provided GenerateCode targets in a fresh checkout' {
        $package = New-SdkFixture 'Azure.ResourceManager.RequiresRestore'
        $source = Join-Path $package.FullName src
        @'
<Project>
  <Import Project="$(MSBuildProjectDirectory)/restored.targets" Condition="Exists('$(MSBuildProjectDirectory)/restored.targets')" />
  <Target Name="Restore">
    <Copy SourceFiles="$(MSBuildProjectDirectory)/generate.fixture.targets" DestinationFiles="$(MSBuildProjectDirectory)/restored.targets" />
  </Target>
</Project>
'@ | Set-Content (Join-Path $source "$($package.Name).csproj")
        '<Project><Target Name="GenerateCode"><WriteLinesToFile File="$(MSBuildProjectDirectory)/../generated.txt" Lines="generated after restore" /></Target></Project>' |
            Set-Content (Join-Path $source generate.fixture.targets)
        Test-Path (Join-Path $source restored.targets) | Should -BeFalse
        $results = @(Invoke-GeneratorSdkValidationParallel @($package) 1 (Join-Path $TestDrive restore-logs))
        $results.Count | Should -Be 1
        $results[0].Success | Should -BeTrue
        Get-Content (Join-Path $package.FullName generated.txt) -Raw | Should -Match 'generated after restore'
    }
    It 'records failures and prevents success from a partially failed batch' {
        $package = New-SdkFixture 'Azure.ResourceManager.Failing'
        '<Project><Target Name="Restore" /><Target Name="GenerateCode"><Error Text="Intentional fixture failure" /></Target></Project>' |
            Set-Content (Join-Path $package.FullName "src/$($package.Name).csproj")
        $logs = Join-Path $TestDrive failure-logs
        { Invoke-GeneratorSdkValidationParallel @($package) 2 $logs } | Should -Throw '*No commit, push, or PR was attempted*'
        $results = @(Get-Content (Join-Path $logs results.json) -Raw | ConvertFrom-Json)
        $results.Count | Should -Be 1
        $results[0].Success | Should -BeFalse
        Get-Content $results[0].Log -Raw | Should -Match 'Intentional fixture failure'
    }
}

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
    function Get-RunnerAssignment([string]$Name, [string]$Until) {
        $tokens = $null
        $errors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile($runner, [ref]$tokens, [ref]$errors)
        $assignments = @($ast.EndBlock.Statements | Where-Object {
            $_ -is [System.Management.Automation.Language.AssignmentStatementAst] -and
            $_.Left -is [System.Management.Automation.Language.VariableExpressionAst]
        })
        $first = $assignments | Where-Object { $_.Left.VariablePath.UserPath -eq $Name } | Select-Object -First 1
        if (-not $first) { throw "Runner assignment not found: $Name" }
        $end = $first.Extent.EndOffset
        if ($Until) {
            $last = $assignments | Where-Object { $_.Left.VariablePath.UserPath -eq $Until } | Select-Object -First 1
            if (-not $last) { throw "Runner assignment not found: $Until" }
            $end = $last.Extent.StartOffset
        }
        [scriptblock]::Create($ast.Extent.Text.Substring($first.Extent.StartOffset, $end - $first.Extent.StartOffset))
    }
    function Get-RunnerPushCommand {
        $tokens = $null
        $errors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile($runner, [ref]$tokens, [ref]$errors)
        $statement = $ast.EndBlock.Statements | Where-Object { $_.Extent.Text.Contains("git @('push'") }
        if (@($statement).Count -ne 1) { throw 'Expected one runner push command.' }
        [scriptblock]::Create($statement.Extent.Text)
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

Describe 'Caller-independent filesystem paths' {
    It 'resolves relative output paths against PowerShell location, not process CWD' {
        $caller = Join-Path $TestDrive caller
        New-Item $caller -ItemType Directory | Out-Null
        $processDirectory = [Environment]::CurrentDirectory
        Push-Location $caller
        try {
            [Environment]::CurrentDirectory = $TestDrive
            $OutputRoot = 'relative-run'
            . (Get-RunnerAssignment OutputRoot)
            $OutputRoot | Should -BeExactly (Join-Path $caller relative-run)
        }
        finally { Pop-Location; [Environment]::CurrentDirectory = $processDirectory }
    }
    It 'resolves a filesystem PSDrive output path to its native path' {
        $OutputRoot = 'TestDrive:/relative-run'
        . (Get-RunnerAssignment OutputRoot)
        $OutputRoot | Should -BeExactly (Join-Path $TestDrive relative-run)
    }
}

Describe 'Validated push destinations and retry branches' {
    BeforeEach {
        $script:pushUrls = @('https://github.com/Azure/azure-sdk-for-net.git')
        $script:localRefs = @()
        $script:remoteBranches = @()
        $script:warningRemaining = 0
        Mock Invoke-GeneratorSdkValidationCommand {
            param($File, $Arguments, $WorkingDirectory)
            if ($File -ne 'git') { throw "Unexpected fixture command: $File" }
            switch ($Arguments[0]) {
                'remote' {
                    if ($Arguments -contains '--push') { return $script:pushUrls }
                    return 'https://github.com/Azure/azure-sdk-for-net.git'
                }
                'for-each-ref' { return $script:localRefs }
                'ls-remote' {
                    if ($script:warningRemaining -gt 0) {
                        $script:warningRemaining--
                        'warning: fixture transport notice'
                    }
                    if ($Arguments[-1] -in $script:remoteBranches) { return "0123456789`trefs/heads/$($Arguments[-1])" }
                }
                'switch' { }
                'push' { }
                default { throw "Unexpected fixture git arguments: $Arguments" }
            }
        }
        $identity = [pscustomobject]@{ Branch = 'validate-fixture' }
        $runId = 'fixture-run'
        $worktree = $TestDrive
        $prepare = Get-RunnerAssignment remote paths
    }
    It 'rejects an unexpected pushurl even when the fetch URL is allowed' {
        $script:pushUrls = @('https://github.com/example/unexpected.git')
        { & $prepare } | Should -Throw '*unexpected*'
        Should -Invoke Invoke-GeneratorSdkValidationCommand -Times 0 -Exactly -ParameterFilter { $Arguments[0] -in @('switch', 'push') }
    }
    It 'checks every effective push destination' {
        $script:pushUrls += 'https://github.com/example/unexpected.git'
        { & $prepare } | Should -Throw '*unexpected*'
    }
    It 'uses the validated URL for remote collision checks and the actual push' {
        . $prepare
        & (Get-RunnerPushCommand)
        Should -Invoke Invoke-GeneratorSdkValidationCommand -Times 1 -Exactly -ParameterFilter {
            $Arguments[0] -eq 'ls-remote' -and $Arguments[2] -eq 'https://github.com/Azure/azure-sdk-for-net.git'
        }
        Should -Invoke Invoke-GeneratorSdkValidationCommand -Times 1 -Exactly -ParameterFilter {
            $Arguments[0] -eq 'push' -and $Arguments[2] -eq 'https://github.com/Azure/azure-sdk-for-net.git'
        }
    }
    It 'does not mistake native warnings for remote branch refs' {
        $script:warningRemaining = 1
        . $prepare
        $branch | Should -BeExactly 'validate-fixture'
        Should -Invoke Invoke-GeneratorSdkValidationCommand -Times 1 -Exactly -ParameterFilter { $Arguments[0] -eq 'ls-remote' }
    }
    It 'avoids remote branches, including a colliding retry suffix' {
        $script:remoteBranches = @('validate-fixture', 'validate-fixture-local-fixture-run')
        . $prepare
        $branch | Should -BeExactly 'validate-fixture-local-fixture-run-2'
    }
    It 'avoids retained local branches, including a colliding retry suffix' {
        $script:localRefs = @('refs/heads/validate-fixture', 'refs/heads/validate-fixture-local-fixture-run')
        . $prepare
        $branch | Should -BeExactly 'validate-fixture-local-fixture-run-2'
        Should -Invoke Invoke-GeneratorSdkValidationCommand -Times 1 -Exactly -ParameterFilter {
            $Arguments[0] -eq 'switch' -and $Arguments[2] -eq 'validate-fixture-local-fixture-run-2'
        }
    }
}

Describe 'Publication safety and checked commands' {
    It 'overrides a conflicting user scope registry when publishing' {
        $worktree = Join-Path $TestDrive registry-worktree
        New-Item $worktree -ItemType Directory | Out-Null
        '{"name":"registry-fixture","private":true}' | Set-Content (Join-Path $worktree package.json)
        $userConfig = Join-Path $TestDrive user.npmrc
        '@azure-typespec:registry=https://conflicting-registry.invalid/' | Set-Content $userConfig
        $globalConfig = Join-Path $TestDrive global.npmrc
        '' | Set-Content $globalConfig
        . (Get-RunnerAssignment registry)
        $archives = @([pscustomobject]@{ FullName = (Join-Path $TestDrive 'not-published.tgz') })
        $tokens = $null
        $errors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile($runner, [ref]$tokens, [ref]$errors)
        $publish = @($ast.FindAll({
            param($node)
            $node -is [System.Management.Automation.Language.CommandAst] -and
                $node.Extent.Text.StartsWith("Invoke-GeneratorSdkValidationCommand npm @('publish'")
        }, $true))
        $publish.Count | Should -Be 1
        Mock Invoke-GeneratorSdkValidationCommand {
            param($File, $Arguments, $WorkingDirectory)
            $File | Should -BeExactly 'npm'
            $Arguments[0] | Should -BeExactly 'publish'
            # Query npm's effective scoped registry with the runner's actual CLI
            # options, without publishing a package or accessing the network.
            $options = @($Arguments | Select-Object -Skip 2)
            Push-Location $WorkingDirectory
            try {
                $effectiveRegistry = & $File config get '@azure-typespec:registry' @options `
                    --userconfig $userConfig --globalconfig $globalConfig
                $LASTEXITCODE | Should -Be 0
                $effectiveRegistry | Should -BeExactly $registry
            }
            finally { Pop-Location }
        }
        . ([scriptblock]::Create($publish[0].Extent.Text))
        Should -Invoke Invoke-GeneratorSdkValidationCommand -Times 1 -Exactly
    }
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
    It 'still rejects invalid bundled timing measurements' {
        $history = Join-Path $TestDrive invalid-timings.json
        @(@{ Package = 'Slow'; Success = $true; Seconds = -1 }) | ConvertTo-Json -AsArray | Set-Content $history
        # Learned history now recovers, but the same invalid measurement must
        # remain an error under the strict bundled-data policy.
        InModuleScope GeneratorSdkValidation -Parameters @{ History = $history } {
            param($History)
            { Read-GeneratorSdkValidationTimings -Path $History -Strict } | Should -Throw '*finite nonnegative*'
        }
    }
}

Describe 'Recoverable learned timing history' {
    It 'repairs <Kind> cache data without blocking scheduling or new measurements' -TestCases @(
        @{ Kind = 'malformed JSON'; Content = '{' },
        @{ Kind = 'invalid schema'; Content = '[{"Package":"Azure.ResourceManager.Network","Success":true}]' },
        @{ Kind = 'nonnumeric seconds'; Content = '[{"Package":"Azure.ResourceManager.Network","Success":true,"Seconds":"invalid"}]' },
        @{ Kind = 'negative seconds'; Content = '[{"Package":"Azure.ResourceManager.Network","Success":true,"Seconds":-1}]' }
    ) {
        param($Content)
        $cache = Join-Path $TestDrive damaged-cache.json
        $Content | Set-Content $cache
        $packages = @('Azure.ResourceManager.Dns', 'Azure.ResourceManager.Network') |
            ForEach-Object { [pscustomobject]@{ Name = $_ } }
        (@(Get-GeneratorSdkValidationSchedule -Packages $packages -HistoryPath $cache).Name -join ',') |
            Should -BeExactly 'Azure.ResourceManager.Network,Azure.ResourceManager.Dns'
        Update-GeneratorSdkValidationHistory -HistoryPath $cache -Results @(
            [pscustomobject]@{ Package = 'Azure.ResourceManager.Dns'; Success = $true; Seconds = 1200 }
        )
        $saved = @(Get-Content $cache -Raw | ConvertFrom-Json)
        $saved.Count | Should -Be 1
        $saved[0].Package | Should -BeExactly 'Azure.ResourceManager.Dns'
        (@(Get-GeneratorSdkValidationSchedule -Packages $packages -HistoryPath $cache).Name -join ',') |
            Should -BeExactly 'Azure.ResourceManager.Dns,Azure.ResourceManager.Network'
    }
    It 'keeps valid cached measurements when a sibling entry is malformed' {
        $cache = Join-Path $TestDrive mixed-cache.json
        '[{"Package":"Slow","Success":true,"Seconds":300},{"Package":"Broken","Success":true}]' | Set-Content $cache
        $packages = @('Fast', 'Slow') | ForEach-Object { [pscustomobject]@{ Name = $_ } }
        (@(Get-GeneratorSdkValidationSchedule -Packages $packages -HistoryPath $cache).Name -join ',') | Should -BeExactly 'Slow,Fast'
        Update-GeneratorSdkValidationHistory -HistoryPath $cache -Results @(
            [pscustomobject]@{ Package = 'Fast'; Success = $true; Seconds = 100 }
        )
        $saved = @(Get-Content $cache -Raw | ConvertFrom-Json)
        ($saved.Package -join ',') | Should -BeExactly 'Fast,Slow'
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
    It 'uses the SDK directory even when the caller has an incompatible global.json' {
        $package = New-SdkFixture 'Azure.ResourceManager.CallerIndependent'
        '<Project><Target Name="Restore" /><Target Name="GenerateCode" /></Project>' |
            Set-Content (Join-Path $package.FullName "src/$($package.Name).csproj")
        $caller = Join-Path $TestDrive unrelated-checkout
        New-Item $caller -ItemType Directory | Out-Null
        '{"sdk":{"version":"99.0.100","rollForward":"disable"}}' | Set-Content (Join-Path $caller global.json)
        Push-Location $caller
        try {
            $results = @(Invoke-GeneratorSdkValidationParallel @($package) 1 (Join-Path $TestDrive caller-logs))
            $results[0].Success | Should -BeTrue
            (Get-Location).Path | Should -BeExactly $caller
        }
        finally { Pop-Location }
    }
    It 'keeps relative logs rooted at the caller while workers change directory' {
        $package = New-SdkFixture 'Azure.ResourceManager.RelativeLogs'
        '<Project><Target Name="Restore" /><Target Name="GenerateCode" /></Project>' |
            Set-Content (Join-Path $package.FullName "src/$($package.Name).csproj")
        Push-Location $TestDrive
        try {
            $results = @(Invoke-GeneratorSdkValidationParallel @($package) 1 'relative-logs')
            $results[0].Log | Should -BeExactly (Join-Path $TestDrive "relative-logs/$($package.Name).log")
            Test-Path $results[0].Log | Should -BeTrue
            (Get-Location).Path | Should -BeExactly $TestDrive
        }
        finally { Pop-Location }
    }
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

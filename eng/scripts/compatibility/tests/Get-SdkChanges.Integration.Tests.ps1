#Requires -Version 7.0

BeforeAll {
    Set-StrictMode -Version 3
    . (Join-Path $PSScriptRoot '..' 'Get-SdkChanges.Helpers.ps1')
    $repo = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
    $fixtureRoot = Join-Path $TestDrive 'native-fixture'
    [void][System.IO.Directory]::CreateDirectory($fixtureRoot)
    Copy-Item -LiteralPath (Join-Path $repo 'global.json') -Destination (Join-Path $fixtureRoot 'global.json')
    [void][System.IO.Directory]::CreateDirectory((Join-Path $fixtureRoot 'eng'))
    Copy-Item -LiteralPath (Join-Path $repo 'eng' 'ApiListing.exclude-attributes.txt') -Destination (Join-Path $fixtureRoot 'eng')
    $emptyFeed = Join-Path $fixtureRoot 'empty-feed'
    [void][System.IO.Directory]::CreateDirectory($emptyFeed)
    $localFeed = Join-Path $fixtureRoot 'local-feed'
    [void][System.IO.Directory]::CreateDirectory($localFeed)
    [System.IO.File]::WriteAllText((Join-Path $fixtureRoot 'NuGet.Config'),
        "<configuration><packageSources><clear /><add key=`"fixtures`" value=`"$([System.Security.SecurityElement]::Escape($localFeed))`" /></packageSources></configuration>")
    $fixtures = @{}
    foreach ($variant in @('Before', 'After', 'Additions', 'SourceGenerator', 'Embedded', 'Mapped', 'Standard', 'Framework', 'Release')) {
        $root = Join-Path $fixtureRoot $variant
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'fixtures') -Destination $root -Recurse
        $project = Join-Path $root 'src' 'Azure.ResourceManager.CompatibilityFixture.csproj'
        $debugType = if ($variant -eq 'Embedded') { '<DebugType>embedded</DebugType>' } else { '' }
        $pathMap = if ($variant -eq 'Mapped') { "<PathMap>$([System.Security.SecurityElement]::Escape("$fixtureRoot\=/_/"))</PathMap>" } else { '' }
        $standardProperties = if ($variant -eq 'Standard') {
            '<TargetFrameworks>netstandard2.0</TargetFrameworks><LangVersion>latest</LangVersion><ApiCompatBaselineTargetFramework>netstandard2.0</ApiCompatBaselineTargetFramework><PackageId>Azure.Data.CompatibilityFixture</PackageId><IsMgmtLibrary>false</IsMgmtLibrary><IsClientLibrary>true</IsClientLibrary>'
        } elseif ($variant -eq 'Framework') {
            '<TargetFrameworks>net462</TargetFrameworks><LangVersion>latest</LangVersion><ApiCompatBaselineTargetFramework>net462</ApiCompatBaselineTargetFramework><PackageId>Azure.Data.FrameworkFixture</PackageId><IsMgmtLibrary>false</IsMgmtLibrary><IsClientLibrary>true</IsClientLibrary>'
        } else { '' }
        $extraArguments = if ($variant -eq 'Standard') {
            @('-p:TargetFrameworks=netstandard2.0', '-p:LangVersion=latest', '-p:PackageVersion=1.0.1')
        } elseif ($variant -eq 'Framework') {
            @('-p:TargetFrameworks=net462', '-p:LangVersion=latest', '-p:PackageVersion=1.0.2')
        } else { @() }
        $configuration = if ($variant -eq 'Release') { 'Release' } else { 'Debug' }
        [System.IO.File]::WriteAllText((Join-Path $root 'src' 'Fixture.props'),
            "<Project><PropertyGroup><FixtureVariant>$variant</FixtureVariant>$debugType$pathMap$standardProperties</PropertyGroup></Project>")
        $restored = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments (@(
            'restore', $project, '--source', $emptyFeed, '--verbosity', 'quiet'
        ) + $extraArguments)
        if ($variant -in @('Standard', 'Framework') -and $restored.ExitCode -ne 0 -and
            "$($restored.StdOut)`n$($restored.StdErr)" -match 'error NU1101:') {
            # A cold cache needs the fixture's reference packages before offline comparisons.
            $prepared = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments (@(
                'restore', $project, '--configfile', (Join-Path $repo 'NuGet.Config'), '--verbosity', 'quiet'
            ) + $extraArguments)
            if ($prepared.ExitCode -ne 0) { throw "Fixture dependency preparation failed.`n$($prepared.StdOut)`n$($prepared.StdErr)" }
            $restored = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments (@(
                'restore', $project, '--source', $emptyFeed, '--verbosity', 'quiet'
            ) + $extraArguments)
        }
        if ($restored.ExitCode -ne 0) { throw "Offline fixture restore failed.`n$($restored.StdOut)`n$($restored.StdErr)" }
        $built = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments (@(
            'build', $project, '--no-restore', '--configuration', $configuration,
            '--verbosity', 'quiet', '-p:UseSharedCompilation=false', '-tl:off'
        ) + $extraArguments)
        if ($built.ExitCode -ne 0) { throw "Fixture setup compilation failed.`n$($built.StdOut)`n$($built.StdErr)" }
        if ($variant -in @('Before', 'Standard', 'Framework')) {
            foreach ($packProject in @((Join-Path $root 'dependency' 'Dependency.csproj'), $project)) {
                $packed = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments (@(
                    'pack', $packProject, '--no-build', '--no-restore', '--configuration', 'Debug',
                    '--output', $localFeed, '--verbosity', 'quiet', '-p:PackageVersion=1.0.0'
                ) + $extraArguments)
                if ($packed.ExitCode -ne 0) { throw "Fixture package creation failed.`n$($packed.StdOut)`n$($packed.StdErr)" }
            }
        }
        [System.IO.File]::WriteAllText((Join-Path $root 'src' 'do-not-build'), '')
        [System.IO.File]::WriteAllText((Join-Path $root 'dependency' 'do-not-build'), '')
        $work = Join-Path $root 'extraction'
        [void][System.IO.Directory]::CreateDirectory($work)
        $framework = if ($variant -eq 'Standard') { 'netstandard2.0' } elseif ($variant -eq 'Framework') { 'net462' } else { 'net8.0' }
        $evaluation = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $fixtureRoot -WorkDirectory $work `
            -TargetFramework $framework -Configuration $configuration
        if ($variant -in @('Standard', 'Framework')) {
            $assets = Read-SdkChangeJson $evaluation.Properties.ProjectAssetsFile
            foreach ($key in $assets.libraries.Keys) {
                $library = $assets.libraries[$key]
                if ($library.type -ne 'package') { continue }
                $archiveName = ($key.Replace('/', '.') + '.nupkg').ToLowerInvariant()
                $archives = @($assets.packageFolders.Keys | ForEach-Object {
                    Join-Path $_ $library.path $archiveName
                } | Where-Object { Test-Path -LiteralPath $_ -PathType Leaf })
                if ($archives.Count -eq 0) { throw "The offline fixture needs the already-restored NuGet archive for $key." }
                Copy-Item -LiteralPath $archives[0] -Destination $localFeed -Force
            }
        }
        $assembly = Assert-SdkChangeCurrentAssembly $evaluation
        $references = @(Get-SdkChangeCurrentReferences -Evaluation $evaluation -SdkRepoPath $fixtureRoot -WorkDirectory (Join-Path $work 'references'))
        Assert-SdkChangeReferences -Assembly $assembly -References $references
        $fixtures[$variant] = @{
            Root = $root; Project = $project; Evaluation = $evaluation; Assembly = $assembly; References = $references
        }
    }
    $rules = Get-SdkChangeRules -Evaluation $fixtures.After.Evaluation -SdkRepoPath $repo
    $forward = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly $fixtures.After.Assembly `
        -LeftReferences $fixtures.Before.References -RightReferences $fixtures.After.References `
        -Evaluation $fixtures.After.Evaluation -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'forward')
    $reverse = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.After.Assembly -RightAssembly $fixtures.Before.Assembly `
        -LeftReferences $fixtures.After.References -RightReferences $fixtures.Before.References `
        -Evaluation $fixtures.After.Evaluation -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'reverse')
}

Describe 'Real offline SDK ApiCompat task' -Tag 'IntegrationTest' {
    It 'captures exact native member/type removal events and keeps additions separate' {
        $result = ConvertFrom-SdkChangeApiCompat -Log $forward -TargetFramework 'net8.0'
        $forward.ExitCode | Should -Be 1
        $forward.Completed | Should -BeTrue
        @($result.Changes | Where-Object { $_.diagnosticId -eq 'CP0002' -and $_.symbol -eq 'void CompatibilityFixture.Widget.Removed()' }).Count | Should -Be 1
        @($result.Changes | Where-Object { $_.diagnosticId -eq 'CP0001' -and $_.symbol -eq 'CompatibilityFixture.RemovedType' }).Count | Should -Be 1
        @($result.Changes | Where-Object { $_.symbol -match 'AddedType' }).Count | Should -Be 0
        $added = ConvertFrom-SdkChangeApiCompat -Log $reverse -TargetFramework 'net8.0' -Reverse
        @($added.Changes | Where-Object { $_.diagnosticId -eq 'CP0001' -and $_.symbol -eq 'CompatibilityFixture.AddedType' }).Count | Should -Be 1
        @($added.Changes | Where-Object { $_.isBreaking }).Count | Should -Be 0
    }

    It 'captures parameter names, attributes, interface requirements, enum and signature changes from the native engine' {
        $ids = @($forward.Diagnostics.Code | Sort-Object -Unique)
        foreach ($id in @('CP0002', 'CP0006', 'CP0010', 'CP0011', 'CP0012', 'CP0015', 'CP0017')) {
            $ids | Should -Contain $id
        }
        $descriptions = $forward.Diagnostics.Message -join "`n"
        $descriptions | Should -Match 'Signature'
        $descriptions | Should -Match 'oldName'
        $descriptions | Should -Match 'Marker'
    }

    It 'identifies the affected symbol in native <Code> diagnostics' -TestCases @(
        @{ Code = 'CP0017'; Symbol = 'CompatibilityFixture.Widget.Parameter(string)' },
        @{ Code = 'CP0015'; Symbol = 'CompatibilityFixture.Widget.AttributeChange()' },
        @{ Code = 'CP0011'; Symbol = 'ValueOnly.Default' }
    ) {
        param($Code, $Symbol)
        $changes = (ConvertFrom-SdkChangeApiCompat -Log $forward -TargetFramework 'net8.0').Changes
        $change = @($changes | Where-Object { $_.diagnosticId -eq $Code -and ($Code -ne 'CP0011' -or $_.description -match "'ValueOnly'") })[0]
        $change.symbol | Should -Be $Symbol -Because $change.description
    }

    It 'does not collapse separate enum changes when native messages omit their namespaces' {
        $changes = (ConvertFrom-SdkChangeApiCompat -Log $forward -TargetFramework 'net8.0').Changes
        @($changes | Where-Object { $_.diagnosticId -eq 'CP0011' -and $_.symbol -eq 'Ambiguous.Value' }).Count | Should -Be 2
    }

    It 'never executes compilation or analyzers in either standalone comparison' {
        foreach ($log in @($forward, $reverse)) {
            $log.Targets | Should -Contain 'CompareSdkAssemblies'
            foreach ($target in @('Build', 'Compile', 'CoreCompile', 'RunAnalyzers', 'RunCodeAnalysis')) {
                $log.Targets | Should -Not -Contain $target
            }
        }
        $referenceLog = Read-SdkChangeBuildLog (Join-Path $fixtures.After.Root 'extraction' 'references' 'references.binlog')
        foreach ($target in @('Build', 'Compile', 'CoreCompile', 'RunAnalyzers', 'RunCodeAnalysis', 'PoisonBuildAndAnalyzers')) {
            $referenceLog.Targets | Should -Not -Contain $target
        }
    }

    It 'rejects an omitted external dependency instead of treating it as compatible' {
        $withoutDependency = @($fixtures.After.References | Where-Object { [System.IO.Path]::GetFileName($_) -ne 'Dependency.dll' })
        { Assert-SdkChangeReferences -Assembly $fixtures.After.Assembly -References $withoutDependency } |
            Should -Throw "*Missing assembly reference 'Dependency'*"
    }

    It 'uses native diagnostics to reject a missing API-reachable transitive dependency' {
        (Get-SdkChangeAssemblyInfo $fixtures.Before.Assembly).References | Should -Not -Contain 'System.Data.Common'
        $isolated = Join-Path $fixtureRoot 'incomplete-references'
        [void][System.IO.Directory]::CreateDirectory($isolated)
        $incomplete = @($fixtures.Before.References | Where-Object {
            [System.IO.Path]::GetFileName($_) -ne 'System.Data.Common.dll'
        } | ForEach-Object {
            $copy = Join-Path $isolated ([System.IO.Path]::GetFileName($_))
            Copy-Item -LiteralPath $_ -Destination $copy
            $copy
        })
        { Assert-SdkChangeReferences -Assembly $fixtures.Before.Assembly -References $incomplete } | Should -Not -Throw
        $log = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly $fixtures.Before.Assembly `
            -LeftReferences $fixtures.Before.References -RightReferences $incomplete `
            -Evaluation $fixtures.Before.Evaluation -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'missing-transitive')
        @($log.Diagnostics | Where-Object { $_.Code -eq 'CP1002' -and $_.Message -match 'System.Data.Common' }).Count | Should -BeGreaterThan 0
        { ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0' } | Should -Throw '*CP1002*'
    }

    It 'captures a real missing-assembly MSBuild error and fails extraction' {
        $log = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly (Join-Path $fixtureRoot 'missing.dll') `
            -LeftReferences $fixtures.Before.References -RightReferences $fixtures.After.References -Evaluation $fixtures.After.Evaluation `
            -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'missing-assembly')
        $log.ExitCode | Should -Be 1
        { ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0' } | Should -Throw
    }

    It 'reports a genuinely clean comparison' {
        $log = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly $fixtures.Before.Assembly `
            -LeftReferences $fixtures.Before.References -RightReferences $fixtures.Before.References `
            -Evaluation $fixtures.Before.Evaluation -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'clean')
        $log.ExitCode | Should -Be 0
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0'
        $result.Changes.Count | Should -Be 0
    }

    It 'reports additions without breaks from a real two-direction comparison' {
        $forwardAdded = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly $fixtures.Additions.Assembly `
            -LeftReferences $fixtures.Before.References -RightReferences $fixtures.Additions.References `
            -Evaluation $fixtures.Additions.Evaluation -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'additions-forward')
        $reverseAdded = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Additions.Assembly -RightAssembly $fixtures.Before.Assembly `
            -LeftReferences $fixtures.Additions.References -RightReferences $fixtures.Before.References `
            -Evaluation $fixtures.Additions.Evaluation -Rules $rules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'additions-reverse')
        $changes = (ConvertFrom-SdkChangeApiCompat -Log $forwardAdded -TargetFramework 'net8.0').Changes +
            (ConvertFrom-SdkChangeApiCompat -Log $reverseAdded -TargetFramework 'net8.0' -Reverse).Changes
        $report = New-SdkChangeReport -BaselineVersion '1.0.0' -Changes $changes -Diagnostics @() -Limitations @()
        $report.hasBreakingChange | Should -BeFalse
        $report.details.apiChanges.symbol | Should -Contain 'CompatibilityFixture.AddedType'
    }

    It 'honors central suppression paths after assembly identity transformations without modifying the file' {
        $suppressionPath = Join-Path $fixtureRoot 'suppression.xml'
        [System.IO.File]::WriteAllText($suppressionPath, @'
<Suppressions>
  <Suppression>
    <DiagnosticId>CP0002</DiagnosticId>
    <Target>M:CompatibilityFixture.Widget.Removed</Target>
    <Left>lib/net8.0/Azure.ResourceManager.CompatibilityFixture.dll</Left>
    <Right>lib/net8.0/Azure.ResourceManager.CompatibilityFixture.dll</Right>
  </Suppression>
</Suppressions>
'@)
        $hash = (Get-FileHash -LiteralPath $suppressionPath).Hash
        $suppressedRules = @{ Properties = $rules.Properties; Excludes = $rules.Excludes; Suppressions = @($suppressionPath) }
        $log = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly $fixtures.After.Assembly `
            -LeftReferences $fixtures.Before.References -RightReferences $fixtures.After.References `
            -Evaluation $fixtures.After.Evaluation -Rules $suppressedRules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'suppressed')
        $changes = (ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0').Changes
        @($changes | Where-Object { $_.symbol -eq 'void CompatibilityFixture.Widget.Removed()' }).Count | Should -Be 0
        (Get-FileHash -LiteralPath $suppressionPath).Hash | Should -Be $hash
    }

    It 'honors multiple NoWarn codes using the native task, without suppressing other changes' {
        $properties = @{} + $rules.Properties
        $properties.NoWarn = 'CP0015;CP0017'
        $noWarnRules = @{ Properties = $properties; Excludes = $rules.Excludes; Suppressions = @() }
        $log = Invoke-SdkChangeApiCompat -LeftAssembly $fixtures.Before.Assembly -RightAssembly $fixtures.After.Assembly `
            -LeftReferences $fixtures.Before.References -RightReferences $fixtures.After.References `
            -Evaluation $fixtures.After.Evaluation -Rules $noWarnRules -SdkRepoPath $repo -WorkDirectory (Join-Path $fixtureRoot 'no-warn')
        $changes = (ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0').Changes
        $changes.diagnosticId | Should -Not -Contain 'CP0015'
        $changes.diagnosticId | Should -Not -Contain 'CP0017'
        $changes.diagnosticId | Should -Contain 'CP0002'
    }

    It 'emits the complete JSON for all current TFMs without invoking poisoned source targets' {
        Mock Get-SdkChangeLatestGaVersion { '1.0.0' }
        Mock Get-SdkChangeBaseline { @{ Assembly = $fixtures.Before.Assembly; References = $fixtures.Before.References } }
        $output = Join-Path $fixtureRoot 'report.json'
        Invoke-SdkChangeExtraction -PackagePath (Split-Path $fixtures.After.Project -Parent) -SdkRepoPath $fixtureRoot -OutputJsonFile $output
        $report = Read-SdkChangeJson $output
        $report.hasBreakingChange | Should -BeTrue
        @($report.details.apiChanges.targetFramework | Sort-Object -Unique) | Should -Be @('net10.0', 'net8.0')
        $report.details.diagnostics | Should -Contain 'Current artifact scope: Configuration=Debug; TargetFrameworks=net10.0, net8.0.'
        $report.details.limitations -join ' ' | Should -Not -Match 'not a full multi-target package comparison'
        Should -Invoke Get-SdkChangeBaseline -Times 1 -Exactly -ParameterFilter { $TargetFramework -eq 'net8.0' }
    }

    It 'restores an exact baseline and its dependency graph from an offline NuGet feed without compiling' {
        $work = Join-Path $fixtureRoot 'restored-baseline'
        $baseline = Get-SdkChangeBaseline -PackageId 'Azure.ResourceManager.CompatibilityFixture' -Version '1.0.0' `
            -TargetFramework 'net8.0' -TargetFileName 'Azure.ResourceManager.CompatibilityFixture.dll' -SdkRepoPath $fixtureRoot -WorkDirectory $work
        Assert-SdkChangeReferences -Assembly $baseline.Assembly -References $baseline.References
        $baseline.Assembly | Should -BeLike '*azure.resourcemanager.compatibilityfixture*1.0.0*lib*net8.0*'
        @($baseline.References | ForEach-Object { [System.IO.Path]::GetFileName($_) }) | Should -Contain 'Dependency.dll'
        (Read-SdkChangeBuildLog (Join-Path $work 'references.binlog')).Targets | Should -Not -Contain 'CoreCompile'
    }

    It 'extracts a data-plane netstandard2.0 package end to end with a real restored baseline' {
        Mock Get-SdkChangeLatestGaVersion { '1.0.1' }
        $output = Join-Path $fixtureRoot 'standard-report.json'
        Invoke-SdkChangeExtraction -PackagePath (Split-Path $fixtures.Standard.Project -Parent) -SdkRepoPath $fixtureRoot -OutputJsonFile $output
        $report = Read-SdkChangeJson $output
        $report.hasBreakingChange | Should -BeFalse
        $report.details.apiChanges.Count | Should -Be 0
        $report.details.baselineVersion | Should -Be '1.0.1'
        Should -Invoke Get-SdkChangeLatestGaVersion -Times 1 -Exactly -ParameterFilter {
            $PackageId -eq 'Azure.Data.CompatibilityFixture'
        }
    }

    It 'preserves NuGet-provided classic framework targeting paths and resolves transitive framework assemblies' {
        $entry = $fixtures.Framework
        $entry.Evaluation.Properties.TargetFrameworkRootPath | Should -Match 'microsoft.netframework.referenceassemblies'
        @($entry.References | ForEach-Object { [System.IO.Path]::GetFileName($_) }) | Should -Contain 'System.Configuration.dll'
        Assert-SdkChangeReferences -Assembly $entry.Assembly -References $entry.References
    }

    It 'extracts a classic .NET Framework package with a real offline baseline and complete framework references' {
        Mock Get-SdkChangeLatestGaVersion { '1.0.2' }
        $output = Join-Path $fixtureRoot 'framework-report.json'
        Invoke-SdkChangeExtraction -PackagePath (Split-Path $fixtures.Framework.Project -Parent) -SdkRepoPath $fixtureRoot -OutputJsonFile $output
        $report = Read-SdkChangeJson $output
        $report.hasBreakingChange | Should -BeFalse
        $report.details.baselineVersion | Should -Be '1.0.2'
        $report.details.apiChanges.Count | Should -Be 0
        $report.details.diagnostics | Should -Contain 'Current artifact scope: Configuration=Debug; TargetFrameworks=net462.'
    }

    It 'supports SDK PR Release artifacts through the same named-parameter contract and inherited Configuration' {
        Mock Get-SdkChangeLatestGaVersion { '1.0.0' }
        Mock Get-SdkChangeBaseline { @{ Assembly = $fixtures.Before.Assembly; References = $fixtures.Before.References } }
        $previousConfiguration = $env:Configuration
        $output = Join-Path $fixtureRoot 'release-report.json'
        try {
            $env:Configuration = $null
            $defaultEvaluation = Get-SdkChangeEvaluation -Project $fixtures.Release.Project -SdkRepoPath $fixtureRoot `
                -WorkDirectory (Join-Path $fixtures.Release.Root 'extraction') -TargetFramework 'net8.0'
            { Assert-SdkChangeCurrentAssembly $defaultEvaluation } | Should -Throw '*Current assembly is missing*'

            $env:Configuration = 'Release'
            Invoke-SdkChangeExtraction -PackagePath (Split-Path $fixtures.Release.Project -Parent) `
                -SdkRepoPath $fixtureRoot -OutputJsonFile $output
            $report = Read-SdkChangeJson $output
            $report.hasBreakingChange | Should -BeFalse
            $report.details.baselineVersion | Should -Be '1.0.0'
            $report.details.apiChanges.Count | Should -Be 0
        }
        finally {
            $env:Configuration = $previousConfiguration
        }
    }

    It 'explicitly scopes a common-script smoke when TargetFramework is inherited from the caller' {
        Mock Get-SdkChangeLatestGaVersion { '1.0.0' }
        Mock Get-SdkChangeBaseline { @{ Assembly = $fixtures.Before.Assembly; References = $fixtures.Before.References } }
        $previousFramework = $env:TargetFramework
        $output = Join-Path $fixtureRoot 'single-framework-report.json'
        try {
            $env:TargetFramework = 'net8.0'
            Invoke-SdkChangeExtraction -PackagePath (Split-Path $fixtures.Before.Project -Parent) `
                -SdkRepoPath $fixtureRoot -OutputJsonFile $output
            $report = Read-SdkChangeJson $output
            $report.hasBreakingChange | Should -BeFalse
            $report.details.diagnostics | Should -Contain 'Current artifact scope: Configuration=Debug; TargetFrameworks=net8.0.'
            $report.details.limitations -join ' ' | Should -Match 'declared frameworks not evaluated: net10.0'
            $report.details.limitations -join ' ' | Should -Match 'not a full multi-target package comparison'
        }
        finally {
            $env:TargetFramework = $previousFramework
        }
    }

    It 'validates a real embedded PDB and does not require an external PDB file' {
        $entry = $fixtures.Embedded
        Test-Path -LiteralPath ([System.IO.Path]::ChangeExtension($entry.Assembly, '.pdb')) | Should -BeFalse
        Assert-SdkChangeCurrentAssembly $entry.Evaluation | Should -Be $entry.Assembly
    }

    It 'validates source-generator output from the existing PDB without rerunning the generator' {
        $entry = $fixtures.SourceGenerator
        Assert-SdkChangeCurrentAssembly $entry.Evaluation | Should -Be $entry.Assembly
        @(Get-SdkChangeCompilationDocuments -Assembly $entry.Assembly -Evaluation $entry.Evaluation).Name -join "`n" |
            Should -Match 'JsonSourceGenerator'
    }

    It 'validates a real deterministic path-mapped PDB using sources in this checkout' {
        $entry = $fixtures.Mapped
        @(Get-SdkChangeCompilationDocuments -Assembly $entry.Assembly -Evaluation $entry.Evaluation).Name -join "`n" |
            Should -Match '/_/Mapped/src/'
        Assert-SdkChangeCurrentAssembly $entry.Evaluation | Should -Be $entry.Assembly
    }

    It 'uses the PDB compilation source count rather than treating #line documents as deleted inputs' {
        $entry = $fixtures.Before
        @(Get-SdkChangeCompilationDocuments -Assembly $entry.Assembly -Evaluation $entry.Evaluation).Name -join "`n" |
            Should -Not -Match 'Logical.cs'
        Assert-SdkChangeCurrentAssembly $entry.Evaluation | Should -Be $entry.Assembly
    }

    It 'detects a backdated change in a real enum-only source file' {
        $entry = $fixtures.After
        $source = Get-Item -LiteralPath (Join-Path $entry.Root 'src' 'EnumOnly.cs')
        $original = [System.IO.File]::ReadAllBytes($source.FullName)
        $time = $source.LastWriteTimeUtc
        try {
            [System.IO.File]::WriteAllText($source.FullName, 'namespace CompatibilityFixture; public enum UnchangedEnum { Changed }')
            $source.LastWriteTimeUtc = $time
            { Assert-SdkChangeCurrentAssembly $entry.Evaluation } | Should -Throw '*compiled checksum*'
        }
        finally {
            [System.IO.File]::WriteAllBytes($source.FullName, $original)
            $source.LastWriteTimeUtc = $time
        }
    }

    It 'detects a deleted enum-only source that evaluation no longer includes' {
        $entry = $fixtures.After
        $evaluation = @{} + $entry.Evaluation
        $evaluation.Items = @{} + $entry.Evaluation.Items
        $evaluation.Items.Compile = @($evaluation.Items.Compile | Where-Object { $_.FullPath -notlike '*EnumOnly.cs' })
        { Assert-SdkChangeCurrentAssembly $evaluation } | Should -Throw '*not an evaluated Compile input*'
    }

    It 'rejects an external PDB from a different compilation' {
        $entry = $fixtures.After
        $pdb = [System.IO.Path]::ChangeExtension($entry.Assembly, '.pdb')
        $original = [System.IO.File]::ReadAllBytes($pdb)
        try {
            Copy-Item -LiteralPath ([System.IO.Path]::ChangeExtension($fixtures.Before.Assembly, '.pdb')) -Destination $pdb -Force
            { Assert-SdkChangeCurrentAssembly $entry.Evaluation } | Should -Throw '*PDB does not match*'
        }
        finally {
            [System.IO.File]::WriteAllBytes($pdb, $original)
        }
    }

    It 'exits nonzero through the named-parameter entry point for stale artifacts and removes stale output' {
        $source = Get-Item -LiteralPath (Join-Path $fixtures.After.Root 'src' 'After.cs')
        $timestamp = $source.LastWriteTimeUtc
        $output = Join-Path $fixtureRoot 'stale-report.json'
        [System.IO.File]::WriteAllText($output, '{"hasBreakingChange":false}')
        try {
            $source.LastWriteTimeUtc = [datetime]::UtcNow.AddMinutes(1)
            $messages = & pwsh -NoProfile -File (Join-Path $PSScriptRoot '..' 'Get-SdkChanges.ps1') `
                -PackagePath (Split-Path $fixtures.After.Project -Parent) -SdkRepoPath $fixtureRoot -OutputJsonFile $output 2>&1
            $LASTEXITCODE | Should -Not -Be 0
            $messages -join "`n" | Should -Match 'Current assembly is stale'
            Test-Path -LiteralPath $output | Should -BeFalse
        }
        finally {
            $source.LastWriteTimeUtc = $timestamp
        }
    }
}

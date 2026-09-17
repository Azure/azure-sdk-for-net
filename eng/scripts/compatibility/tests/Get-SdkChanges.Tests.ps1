#Requires -Version 7.0

BeforeAll {
    Set-StrictMode -Version 3
    . (Join-Path $PSScriptRoot '..' 'Get-SdkChanges.Helpers.ps1')
    $repo = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
    $nativeProject = Join-Path $PSScriptRoot '..' 'ApiCompat.proj'
    $sdkPath = (& dotnet msbuild $nativeProject -nologo -getProperty:MSBuildToolsPath -tl:off).Trim()
    if ($LASTEXITCODE -ne 0) { throw 'Could not evaluate the installed .NET SDK.' }
    Initialize-SdkChangeNativeLibraries $sdkPath

    function New-TestLog {
        param([object[]]$Diagnostics = @(), [int]$ExitCode = 0)
        return @{
            Diagnostics = $Diagnostics
            ExitCode = $ExitCode
            Finished = $true
            Completed = $true
            Succeeded = $ExitCode -eq 0
            ProcessOutput = ''
        }
    }

    function New-TestDiagnostic {
        param([string]$Code, [string]$Message = "Member 'Example.Client.Removed()' exists on the left but not on the right")
        if (!$PSBoundParameters.ContainsKey('Message')) {
            switch ($Code) {
                'CP0003' { $Message = "lib/net8.0/Example.dll assembly version '1.0.0.0' should be equal to or higher than lib/net8.0/Example.dll version '2.0.0.0'." }
                'CP0011' { $Message = "Value of field 'Default' in enum 'ValueOnly' changed from '1' to '2'." }
                'CP0014' { $Message = "Cannot remove attribute 'Example.Attribute' from 'Example.Client.Removed()'." }
                'CP0015' { $Message = "Cannot change arguments of attribute 'Example.Attribute' on 'Example.Client.Removed()'." }
                'CP0016' { $Message = "Cannot add attribute 'Example.Attribute' to 'Example.Client.Removed()'." }
            }
        }
        return @{ Code = $Code; Message = $Message; IsError = $true; EventKey = [guid]::NewGuid().ToString('N') }
    }

    function New-TestEvaluation {
        param([string]$Root, [string]$Framework = 'net8.0', [string]$PackageId = 'Azure.ResourceManager.Example')
        $project = Join-Path $Root 'src' "$PackageId.csproj"
        $assembly = Join-Path $Root 'obj' $Framework "$PackageId.dll"
        return @{
            Properties = @{
                MSBuildProjectFullPath = $project
                MSBuildProjectName = $PackageId
                MSBuildAllProjects = $project
                AssemblyName = $PackageId
                PackageId = $PackageId
                TargetFramework = $Framework
                TargetFrameworks = $Framework
                TargetFrameworkMoniker = '.NETCoreApp,Version=v8.0'
                TargetPath = Join-Path $Root 'bin' $Framework "$PackageId.dll"
                TargetFileName = "$PackageId.dll"
                ProjectAssetsFile = Join-Path $Root 'obj' 'project.assets.json'
                IntermediateOutputPath = Join-Path $Root 'obj' $Framework
                PdbFile = ''
                Configuration = 'Debug'
                ApiCompatBaselineTargetFramework = 'net8.0'
                ApiCompatVersion = ''
                RoslynAssembliesPath = Join-Path $sdkPath 'Roslyn' 'bincore'
                ApiCompatRespectInternals = ''
                ApiCompatStrictMode = ''
                ApiCompatEnableRuleAttributesMustMatch = ''
                ApiCompatEnableRuleCannotChangeParameterName = ''
                ApiCompatPermitUnnecessarySuppressions = ''
                NoWarn = ''
                RuntimeIdentifier = ''
                NuGetPackageRoot = ''
                CompileUsingReferenceAssemblies = ''
                TargetFrameworkRootPath = ''
                TargetFrameworkFallbackSearchPaths = ''
                FrameworkPathOverride = ''
                BypassFrameworkInstallChecks = ''
            }
            Items = @{
                IntermediateAssembly = @(@{ FullPath = $assembly })
                Compile = @(@{ FullPath = Join-Path $Root 'src' 'Client.cs' })
                AdditionalFiles = @()
                EmbeddedResource = @()
                Reference = @()
                FrameworkReference = @()
                ApiCompatSuppressionFile = @()
                ApiCompatExcludeAttributesFile = @()
            }
            ImportedProjects = @()
            RepositoryPath = $Root
        }
    }
}

Describe 'Latest stable NuGet baseline' -Tag 'UnitTest' {
    It 'uses the actual public registry and orders stable NuGet versions numerically' {
        Mock Invoke-RestMethod { [pscustomobject]@{ versions = @('1.9.0', '2.0.0-beta.9', '1.10.0', '1.10.0+metadata', '1.2.0') } }
        Get-SdkChangeLatestGaVersion 'Azure.Example' | Should -Be '1.10.0'
        Should -Invoke Invoke-RestMethod -Times 1 -Exactly -ParameterFilter {
            $Uri -eq 'https://api.nuget.org/v3-flatcontainer/azure.example/index.json'
        }
    }

    It 'does not treat stable 0.x versions as previews' {
        Mock Invoke-RestMethod { [pscustomobject]@{ versions = @('0.2.0', '0.3.0-preview.1') } }
        Get-SdkChangeLatestGaVersion 'Azure.Example' | Should -Be '0.2.0'
    }

    It 'accepts NuGet legacy four-part stable versions' {
        Mock Invoke-RestMethod { [pscustomobject]@{ versions = @('1.2.3', '1.2.3.4') } }
        Get-SdkChangeLatestGaVersion 'Azure.Example' | Should -Be '1.2.3.4'
    }

    It 'returns no baseline for <Name>' -TestCases @(
        @{ Name = 'preview-only releases'; Versions = @('1.0.0-beta.1', '2.0.0-rc.1') },
        @{ Name = 'an empty version index'; Versions = @() }
    ) {
        param($Versions)
        Mock Invoke-RestMethod { [pscustomobject]@{ versions = $Versions } }
        Get-SdkChangeLatestGaVersion 'Azure.Example' | Should -BeNullOrEmpty
    }

    It 'only treats an HTTP 404 as an absent package' {
        Mock Invoke-RestMethod {
            throw [Microsoft.PowerShell.Commands.HttpResponseException]::new(
                'Not Found', [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::NotFound))
        }
        Get-SdkChangeLatestGaVersion 'Azure.Example' | Should -BeNullOrEmpty
    }

    It 'propagates HTTP <Status> rather than reporting first release' -TestCases @(
        @{ Status = 401 }, @{ Status = 403 }, @{ Status = 429 }, @{ Status = 500 }
    ) {
        param($Status)
        Mock Invoke-RestMethod {
            throw [Microsoft.PowerShell.Commands.HttpResponseException]::new(
                'Request failed', [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]$Status))
        }
        { Get-SdkChangeLatestGaVersion 'Azure.Example' } | Should -Throw '*Request failed*'
    }

    It 'propagates a connection failure' {
        Mock Invoke-RestMethod { throw [System.Net.Http.HttpRequestException]::new('Network unavailable') }
        { Get-SdkChangeLatestGaVersion 'Azure.Example' } | Should -Throw '*Network unavailable*'
    }

    It 'rejects malformed version indexes' -TestCases @(
        @{ Response = [pscustomobject]@{ other = @() } },
        @{ Response = [pscustomobject]@{ versions = '1.0.0' } },
        @{ Response = [pscustomobject]@{ versions = @('1.0.0', 'not-a-version') } },
        @{ Response = [pscustomobject]@{ versions = @(1) } },
        @{ Response = $null }
    ) {
        param($Response)
        Mock Invoke-RestMethod { $Response }
        { Get-SdkChangeLatestGaVersion 'Azure.Example' } | Should -Throw
    }
}

Describe 'Baseline restore configuration' -Tag 'UnitTest' {
    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        [void][System.IO.Directory]::CreateDirectory($root)
        $config = Join-Path $root 'NuGet.Config'
        [System.IO.File]::WriteAllText($config, '<configuration><packageSources><clear /></packageSources></configuration>')
        Mock Invoke-SdkChangeProcess { @{ ExitCode = 0; StdOut = ''; StdErr = '' } }
        Mock Read-SdkChangeBuildLog { @{ Finished = $true; Succeeded = $true; Diagnostics = @() } }
        Mock Read-SdkChangeJson {
            @{
                Items = @{ ReferencePathWithRefAssemblies = @(@{ FullPath = 'reference.dll' }) }
                Properties = @{ ProjectAssetsFile = 'project.assets.json'; TargetFrameworkDirectory = '' }
            }
        }
    }

    It 'uses the SDK repository feed configuration rather than adding a public download feed' {
        $result = Invoke-SdkChangeReferenceResolution -SdkRepoPath $root -WorkDirectory (Join-Path $root 'work') `
            -TargetFramework 'net8.0' -Properties @{} -Items @{} -Restore
        $result.References | Should -Be @('reference.dll')
        Should -Invoke Invoke-SdkChangeProcess -Times 1 -Exactly -ParameterFilter {
            $Arguments -contains '-target:Restore' -and
            $Arguments -contains "-property:RestoreConfigFile=$config" -and
            @($Arguments | Where-Object { $_ -like '*RestoreSources=*' }).Count -eq 0
        }
    }

    It 'rejects a missing repository configuration instead of using implicit feeds' {
        Remove-Item -LiteralPath $config
        {
            Invoke-SdkChangeReferenceResolution -SdkRepoPath $root -WorkDirectory (Join-Path $root 'work') `
                -TargetFramework 'net8.0' -Properties @{} -Items @{} -Restore
        } | Should -Throw '*repository NuGet configuration is missing*'
        Should -Invoke Invoke-SdkChangeProcess -Times 0 -Exactly
    }

    It 'does not resolve references after a failed configured-feed restore' {
        Mock Invoke-SdkChangeProcess { @{ ExitCode = 1; StdOut = 'NU1301: Feed unavailable'; StdErr = '' } }
        {
            Invoke-SdkChangeReferenceResolution -SdkRepoPath $root -WorkDirectory (Join-Path $root 'work') `
                -TargetFramework 'net8.0' -Properties @{} -Items @{} -Restore
        } | Should -Throw '*Feed unavailable*'
        Should -Invoke Invoke-SdkChangeProcess -Times 0 -Exactly -ParameterFilter {
            $Arguments -contains '-target:ResolveSdkChangeReferences'
        }
    }

    It 'adds framework dependencies and facades without replacing the compiler-selected reference' {
        $framework = Join-Path $root 'framework'
        $facades = Join-Path $framework 'Facades'
        [void][System.IO.Directory]::CreateDirectory($facades)
        foreach ($name in @('System.dll', 'System.Configuration.dll', 'System.xml', 'Native.dll')) {
            [System.IO.File]::WriteAllText((Join-Path $framework $name), '')
        }
        Mock Get-SdkChangeAssemblyInfo {
            if ([System.IO.Path]::GetFileName($Path) -eq 'Native.dll') { return $null }
            return @{ Name = [System.IO.Path]::GetFileNameWithoutExtension($Path) }
        } -ParameterFilter { $IgnoreNonAssembly }
        [System.IO.File]::WriteAllText((Join-Path $facades 'System.Runtime.dll'), '')
        $selected = Join-Path $root 'System.dll'
        Mock Read-SdkChangeJson {
            @{
                Items = @{ ReferencePathWithRefAssemblies = @(@{ FullPath = $selected }) }
                Properties = @{ ProjectAssetsFile = 'project.assets.json'; TargetFrameworkDirectory = "$framework;;$facades;" }
            }
        }
        $result = Invoke-SdkChangeReferenceResolution -SdkRepoPath $root -WorkDirectory (Join-Path $root 'work') `
            -TargetFramework 'net462' -Properties @{} -Items @{}
        $result.References.Count | Should -Be 3
        $result.References | Should -Contain $selected
        $result.References | Should -Contain (Join-Path $framework 'System.Configuration.dll')
        $result.References | Should -Contain (Join-Path $facades 'System.Runtime.dll')
        $result.References | Should -Not -Contain (Join-Path $framework 'System.dll')
    }

    It 'fails explicitly if an evaluated framework directory is unavailable' {
        Mock Read-SdkChangeJson {
            @{
                Items = @{ ReferencePathWithRefAssemblies = @(@{ FullPath = 'reference.dll' }) }
                Properties = @{ ProjectAssetsFile = 'project.assets.json'; TargetFrameworkDirectory = (Join-Path $root 'missing') }
            }
        }
        {
            Invoke-SdkChangeReferenceResolution -SdkRepoPath $root -WorkDirectory (Join-Path $root 'work') `
                -TargetFramework 'net462' -Properties @{} -Items @{}
        } | Should -Throw '*framework reference directory is missing*'
    }
}

Describe 'Assembly reference preflight' -Tag 'UnitTest' {
    It 'does not require private implementation dependencies from reference-assembly packs' {
        $assembly = Join-Path $TestDrive 'Current.dll'
        $reference = Join-Path $TestDrive 'Framework.dll'
        [System.IO.File]::WriteAllText($assembly, '')
        [System.IO.File]::WriteAllText($reference, '')
        Mock Get-SdkChangeAssemblyInfo {
            if ($Path -eq $assembly) { return @{ Name = 'Current'; References = @('Framework') } }
            return @{ Name = 'Framework'; References = @('Private.Implementation') }
        }
        { Assert-SdkChangeReferences -Assembly $assembly -References @($reference) } | Should -Not -Throw
    }
}

Describe 'Structured native ApiCompat classification' -Tag 'UnitTest' {
    It 'reports a clean comparison with no changes' {
        $result = ConvertFrom-SdkChangeApiCompat -Log (New-TestLog) -TargetFramework 'net8.0'
        $result.Changes.Count | Should -Be 0
        $result.Diagnostics.Count | Should -Be 0
    }

    It 'classifies forward <Code> as <Kind>' -TestCases @(
        @{ Code = 'CP0001'; Kind = 'removed' }, @{ Code = 'CP0002'; Kind = 'removed' },
        @{ Code = 'CP0003'; Kind = 'changed' }, @{ Code = 'CP0005'; Kind = 'changed' },
        @{ Code = 'CP0006'; Kind = 'changed' }, @{ Code = 'CP0007'; Kind = 'changed' },
        @{ Code = 'CP0008'; Kind = 'changed' }, @{ Code = 'CP0009'; Kind = 'changed' },
        @{ Code = 'CP0010'; Kind = 'changed' }, @{ Code = 'CP0011'; Kind = 'changed' },
        @{ Code = 'CP0012'; Kind = 'changed' }, @{ Code = 'CP0013'; Kind = 'changed' },
        @{ Code = 'CP0014'; Kind = 'changed' }, @{ Code = 'CP0015'; Kind = 'changed' },
        @{ Code = 'CP0016'; Kind = 'changed' }, @{ Code = 'CP0017'; Kind = 'changed' },
        @{ Code = 'CP0018'; Kind = 'changed' }, @{ Code = 'CP0019'; Kind = 'changed' },
        @{ Code = 'CP0020'; Kind = 'changed' }, @{ Code = 'CP0021'; Kind = 'changed' }
    ) {
        param($Code, $Kind)
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic $Code)) -ExitCode 1
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'netstandard2.0'
        $result.Changes.Count | Should -Be 1
        $result.Changes[0].kind | Should -Be $Kind
        $expectedSymbol = if ($Code -eq 'CP0011') { 'ValueOnly.Default' } elseif ($Code -eq 'CP0003') { 'lib/net8.0/Example.dll' } else { 'Example.Client.Removed()' }
        $result.Changes[0].symbol | Should -Be $expectedSymbol
        $result.Changes[0].isBreaking | Should -BeTrue
        $result.Changes[0].diagnosticId | Should -Be $Code
        $result.Changes[0].targetFramework | Should -Be 'netstandard2.0'
    }

    It 'deduplicates repeated events without collapsing distinct diagnostics for the same symbol' {
        $one = New-TestDiagnostic 'CP0015'
        $two = New-TestDiagnostic 'CP0017'
        $log = New-TestLog -Diagnostics @($one, $one, $two, $two) -ExitCode 1
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0'
        $result.Changes.Count | Should -Be 2
        $result.Diagnostics.Count | Should -Be 2
    }

    It 'preserves distinct native events whose unqualified enum messages are identical' {
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0011'), (New-TestDiagnostic 'CP0011')) -ExitCode 1
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0'
        $result.Changes.Count | Should -Be 2
        $result.Limitations -join ' ' | Should -Match 'unqualified enum/field'
    }

    It 'retains only type/member existence differences from the reverse comparison' {
        $log = New-TestLog -Diagnostics @(
            (New-TestDiagnostic 'CP0001'), (New-TestDiagnostic 'CP0002'),
            (New-TestDiagnostic 'CP0006'), (New-TestDiagnostic 'CP0015')
        ) -ExitCode 1
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0' -Reverse
        $result.Changes.Count | Should -Be 2
        @($result.Changes | Where-Object { $_.isBreaking }).Count | Should -Be 0
        @($result.Changes | Where-Object { $_.kind -ne 'added' }).Count | Should -Be 0
        $result.Diagnostics.Count | Should -Be 4
        $result.Limitations.Count | Should -Be 2
    }

    It 'fails closed on unknown, missing-assembly, dependency, and noncompatibility diagnostic <Code>' -TestCases @(
        @{ Code = 'CP0004' }, @{ Code = 'CP1002' }, @{ Code = 'CP9999' },
        @{ Code = 'MSB4018' }, @{ Code = 'MSB3245' }, @{ Code = 'NU1101' }, @{ Code = '' }
    ) {
        param($Code)
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic $Code)) -ExitCode 1
        { ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0' } | Should -Throw '*fatal*'
    }

    It 'does not mistake an unidentifiable symbol for a known symbol' {
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0017' 'A diagnostic without a quoted symbol')) -ExitCode 1
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0'
        $result.Changes[0].symbol | Should -Be ''
        $result.Limitations[0] | Should -Match 'symbol.*could not be extracted'
    }

    It 'does not mistake an unknown assembly identity diagnostic value for an API symbol' {
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0003' "Unsupported identity difference: version '1.0.0.0'.")) -ExitCode 1
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0'
        $result.Changes[0].symbol | Should -Be ''
        $result.Limitations[0] | Should -Match 'symbol.*could not be extracted'
    }

    It 'rejects partial output even when it includes valid compatibility violations' -TestCases @(
        @{ ExitCode = 137; Finished = $true; Completed = $true },
        @{ ExitCode = 1; Finished = $false; Completed = $true },
        @{ ExitCode = 1; Finished = $true; Completed = $false }
    ) {
        param($ExitCode, $Finished, $Completed)
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0002')) -ExitCode $ExitCode
        $log.Finished = $Finished
        $log.Completed = $Completed
        { ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0' } | Should -Throw '*did not complete*'
    }

    It 'rejects an unsuccessful tool without compatibility errors' {
        { ConvertFrom-SdkChangeApiCompat -Log (New-TestLog -ExitCode 1) -TargetFramework 'net8.0' } |
            Should -Throw '*without a recognized compatibility diagnostic*'
    }

    It 'preserves the exact native header but does not count a header alone as a compatibility violation' {
        $header = "API compatibility errors between 'lib/net8.0/Example.dll' (left) and 'lib/net8.0/Example.dll' (right):"
        $log = New-TestLog -Diagnostics @((New-TestDiagnostic '' $header), (New-TestDiagnostic 'CP0002')) -ExitCode 1
        $log.CompatibilityHeader = $header
        $result = ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0'
        $result.Changes.Count | Should -Be 1
        $result.Diagnostics.Count | Should -Be 2
        $log.Diagnostics = @((New-TestDiagnostic '' $header))
        { ConvertFrom-SdkChangeApiCompat -Log $log -TargetFramework 'net8.0' } |
            Should -Throw '*without a recognized compatibility diagnostic*'
    }
}

Describe 'Common SDK change JSON contract' -Tag 'UnitTest' {
    It 'emits only the common top-level fields and additive details, with real booleans and arrays' {
        $result = New-SdkChangeReport -BaselineVersion '1.2.3' -Changes @() -Diagnostics @() -Limitations @()
        $json = $result | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashtable
        @($json.Keys) | Should -Be @('changes', 'hasBreakingChange', 'details')
        @($json.details.Keys) | Should -Be @('baselineVersion', 'apiChanges', 'diagnostics', 'limitations')
        $json.hasBreakingChange | Should -BeOfType [bool]
        $json.hasBreakingChange | Should -BeFalse
        $json.details.baselineVersion | Should -Be '1.2.3'
        ($json.details.apiChanges -is [array]) | Should -BeTrue
        $json.changes | Should -Be "### Breaking Changes`nNone.`n`n### Features Added`nNone."
    }

    It 'does not OR reverse failures into hasBreakingChange' {
        $reverse = ConvertFrom-SdkChangeApiCompat -Log (New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0001')) -ExitCode 1) `
            -TargetFramework 'net8.0' -Reverse
        $result = New-SdkChangeReport -BaselineVersion '1.2.3' -Changes $reverse.Changes -Diagnostics $reverse.Diagnostics -Limitations $reverse.Limitations
        $result.hasBreakingChange | Should -BeFalse
        $result.changes | Should -Match '### Features Added\n- \[CP0001\]'
    }

    It 'keeps a possible rename or changed signature as independent removal and addition evidence' {
        $forward = ConvertFrom-SdkChangeApiCompat -Log (New-TestLog -Diagnostics @(
            (New-TestDiagnostic 'CP0002' "Member 'Client.OldName()' does not exist on the right")
        ) -ExitCode 1) -TargetFramework 'net8.0'
        $reverse = ConvertFrom-SdkChangeApiCompat -Log (New-TestLog -Diagnostics @(
            (New-TestDiagnostic 'CP0002' "Member 'Client.NewName()' does not exist on the right")
        ) -ExitCode 1) -TargetFramework 'net8.0' -Reverse
        $result = New-SdkChangeReport -BaselineVersion '1.0.0' -Changes ($forward.Changes + $reverse.Changes) -Diagnostics @() -Limitations @()
        @($result.details.apiChanges.kind) | Should -Be @('removed', 'added')
        $result.hasBreakingChange | Should -BeTrue
        $result.details.limitations -join ' ' | Should -Match 'Correlating changed signatures or renames requires review'
    }

    It 'marks the absence of a GA baseline as not applicable, not a successful clean comparison' {
        $result = New-SdkChangeReport -BaselineVersion $null -Changes @() -Diagnostics @() -Limitations @('No GA baseline exists.')
        $result.details.baselineVersion | Should -BeNullOrEmpty
        ($result | ConvertTo-Json -Depth 10) | Should -Match '"baselineVersion": null'
        $result.changes | Should -Match 'no comparison was performed'
    }
}

Describe 'Current artifact and configuration validation' -Tag 'UnitTest' {
    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $evaluation = New-TestEvaluation $root
        $paths = @(
            $evaluation.Properties.MSBuildProjectFullPath,
            $evaluation.Properties.ProjectAssetsFile,
            $evaluation.Items.Compile[0].FullPath,
            $evaluation.Items.IntermediateAssembly[0].FullPath
        )
        foreach ($path in $paths) {
            [void][System.IO.Directory]::CreateDirectory((Split-Path $path -Parent))
            [System.IO.File]::WriteAllText($path, 'fixture')
            (Get-Item -LiteralPath $path).LastWriteTimeUtc = [datetime]::UtcNow.AddMinutes(-10)
        }
        $assembly = $evaluation.Items.IntermediateAssembly[0].FullPath
        (Get-Item -LiteralPath $assembly).LastWriteTimeUtc = [datetime]::UtcNow.AddMinutes(-5)
        Mock Get-SdkChangeAssemblyInfo {
            @{ Name = $evaluation.Properties.AssemblyName; TargetFramework = $evaluation.Properties.TargetFrameworkMoniker; References = @() }
        }
        Mock Assert-SdkChangeCompilationSources {}
    }

    It 'uses the evaluated intermediate assembly rather than a guessed package or bin path' {
        Assert-SdkChangeCurrentAssembly $evaluation | Should -Be $assembly
    }

    It 'rejects a missing current artifact' {
        Remove-Item -LiteralPath $assembly
        { Assert-SdkChangeCurrentAssembly $evaluation } | Should -Throw '*Current assembly is missing*'
    }

    It 'rejects a newer <InputKind>' -TestCases @(
        @{ InputKind = 'source' }, @{ InputKind = 'project' }, @{ InputKind = 'assets' }, @{ InputKind = 'import' }, @{ InputKind = 'resource' }
    ) {
        param($InputKind)
        $path = switch ($InputKind) {
            'source' { $evaluation.Items.Compile[0].FullPath }
            'project' { $evaluation.Properties.MSBuildProjectFullPath }
            'assets' { $evaluation.Properties.ProjectAssetsFile }
            'import' {
                $path = Join-Path $root 'Imported.props'
                [System.IO.File]::WriteAllText($path, '<Project />')
                $evaluation.ImportedProjects = @($path)
                $path
            }
            'resource' {
                $path = Join-Path $root 'Resource.resx'
                [System.IO.File]::WriteAllText($path, 'resource')
                $evaluation.Items.EmbeddedResource = @(@{ FullPath = $path })
                $path
            }
        }
        (Get-Item -LiteralPath $path).LastWriteTimeUtc = [datetime]::UtcNow
        { Assert-SdkChangeCurrentAssembly $evaluation } | Should -Throw '*Current assembly is stale*'
    }

    It 'rejects a missing source or restore input' {
        Remove-Item -LiteralPath $evaluation.Properties.ProjectAssetsFile
        { Assert-SdkChangeCurrentAssembly $evaluation } | Should -Throw '*build input is missing*'
    }

    It 'rejects an assembly built for the wrong target framework' {
        Mock Get-SdkChangeAssemblyInfo { @{ Name = $evaluation.Properties.AssemblyName; TargetFramework = '.NETCoreApp,Version=v10.0' } }
        { Assert-SdkChangeCurrentAssembly $evaluation } | Should -Throw '*identity/target framework does not match*'
    }

    It 'rejects a misidentified assembly' {
        Mock Get-SdkChangeAssemblyInfo { @{ Name = 'Wrong.Assembly'; TargetFramework = $evaluation.Properties.TargetFrameworkMoniker } }
        { Assert-SdkChangeCurrentAssembly $evaluation } | Should -Throw '*identity/target framework does not match*'
    }

    It 'requires the package to be inside the supplied repository' {
        $other = Join-Path $TestDrive 'other'
        [void][System.IO.Directory]::CreateDirectory($other)
        { Get-SdkChangeProject -PackagePath $root -SdkRepoPath $other } | Should -Throw '*inside SdkRepoPath*'
    }

    It 'accepts package, src, and project paths' {
        foreach ($path in @($root, (Join-Path $root 'src'), $evaluation.Properties.MSBuildProjectFullPath)) {
            Get-SdkChangeProject -PackagePath $path -SdkRepoPath $root | Should -Be $evaluation.Properties.MSBuildProjectFullPath
        }
    }

    It 'rejects ambiguous source projects' {
        [System.IO.File]::WriteAllText((Join-Path $root 'src' 'Another.csproj'), '<Project />')
        { Get-SdkChangeProject -PackagePath $root -SdkRepoPath $root } | Should -Throw '*exactly one*'
    }

    It 'preserves central suppressions and default rules even without ApiCompatVersion' {
        $excludes = Join-Path $root 'eng' 'ApiListing.exclude-attributes.txt'
        $suppression = Join-Path $root 'eng' 'apicompatbaselines' "$($evaluation.Properties.MSBuildProjectName).xml"
        [void][System.IO.Directory]::CreateDirectory((Split-Path $suppression -Parent))
        [System.IO.File]::WriteAllText($excludes, 'T:System.ObsoleteAttribute')
        [System.IO.File]::WriteAllText($suppression, '<Suppressions />')
        $hash = (Get-FileHash -LiteralPath $suppression).Hash
        $rules = Get-SdkChangeRules -Evaluation $evaluation -SdkRepoPath $root
        $rules.Properties.ApiCompatEnableRuleAttributesMustMatch | Should -BeTrue
        $rules.Properties.ApiCompatEnableRuleCannotChangeParameterName | Should -BeTrue
        $rules.Properties.ApiCompatPermitUnnecessarySuppressions | Should -BeTrue
        $rules.Suppressions | Should -Be @($suppression)
        $rules.Excludes | Should -Be @($excludes)
        (Get-FileHash -LiteralPath $suppression).Hash | Should -Be $hash
    }

    It 'preserves configured strictness, internals, rule disabling, and NoWarn' {
        $excludes = Join-Path $root 'exclude.txt'
        [System.IO.File]::WriteAllText($excludes, '')
        $evaluation.Items.ApiCompatExcludeAttributesFile = @(@{ FullPath = $excludes })
        $evaluation.Properties.ApiCompatRespectInternals = 'true'
        $evaluation.Properties.ApiCompatStrictMode = 'true'
        $evaluation.Properties.ApiCompatEnableRuleAttributesMustMatch = 'false'
        $evaluation.Properties.ApiCompatEnableRuleCannotChangeParameterName = 'false'
        $evaluation.Properties.NoWarn = 'CP0015;CP0017'
        $rules = Get-SdkChangeRules -Evaluation $evaluation -SdkRepoPath $root
        $rules.Properties.ApiCompatRespectInternals | Should -BeTrue
        $rules.Properties.ApiCompatStrictMode | Should -BeTrue
        $rules.Properties.ApiCompatEnableRuleAttributesMustMatch | Should -BeFalse
        $rules.Properties.ApiCompatEnableRuleCannotChangeParameterName | Should -BeFalse
        $rules.Properties.NoWarn | Should -Be 'CP0015;CP0017'
    }
}

Describe 'Extraction orchestration and failure behavior' -Tag 'UnitTest' {
    BeforeEach {
        $evaluation = New-TestEvaluation -Root $TestDrive
        $output = Join-Path $TestDrive 'result.json'
        Mock Get-SdkChangeProject { $evaluation.Properties.MSBuildProjectFullPath }
        Mock Get-SdkChangeEvaluation { $evaluation }
        Mock Assert-SdkChangeCurrentAssembly { $evaluation.Items.IntermediateAssembly[0].FullPath }
        Mock Get-FileHash { @{ Hash = 'fixture-assembly-hash' } }
        Mock Get-SdkChangeLatestGaVersion { '9.1.0' }
        Mock Get-SdkChangeBaseline { @{ Assembly = 'baseline.dll'; References = @('baseline-reference.dll') } }
        Mock Get-SdkChangeCurrentReferences { @('current-reference.dll') }
        Mock Assert-SdkChangeReferences {}
        Mock Get-SdkChangeRules { @{ Properties = @{}; Excludes = @(); Suppressions = @() } }
        Mock Invoke-SdkChangeApiCompat { New-TestLog }
    }

    It 'queries the latest GA independently of stale or missing ApiCompatVersion: <OldVersion>' -TestCases @(
        @{ OldVersion = '' }, @{ OldVersion = '1.0.0' }, @{ OldVersion = '100.0.0-beta.1' }
    ) {
        param($OldVersion)
        $evaluation.Properties.ApiCompatVersion = $OldVersion
        Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output
        (Read-SdkChangeJson $output).details.baselineVersion | Should -Be '9.1.0'
        Should -Invoke Get-SdkChangeBaseline -Times 1 -Exactly -ParameterFilter { $Version -eq '9.1.0' }
    }

    It 'supports both planes and evaluated baseline frameworks: <PackageId>, <Framework>' -TestCases @(
        @{ PackageId = 'Azure.ResourceManager.Example'; Framework = 'netstandard2.0' },
        @{ PackageId = 'Azure.Storage.Example'; Framework = 'netstandard2.0' },
        @{ PackageId = 'Azure.Data.Example'; Framework = 'net8.0' }
    ) {
        param($PackageId, $Framework)
        $evaluation = New-TestEvaluation -Root $TestDrive -PackageId $PackageId -Framework $Framework
        $evaluation.Properties.ApiCompatBaselineTargetFramework = $Framework
        Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output
        Should -Invoke Get-SdkChangeBaseline -Times 1 -Exactly -ParameterFilter {
            $TargetFramework -eq $Framework -and $PackageId -eq $evaluation.Properties.PackageId
        }
    }

    It 'writes a successful report for compatibility violations' {
        Mock Invoke-SdkChangeApiCompat {
            if ($LeftAssembly -eq 'baseline.dll') {
                New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0002')) -ExitCode 1
            }
            else { New-TestLog }
        }
        Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output
        (Read-SdkChangeJson $output).hasBreakingChange | Should -BeTrue
    }

    It 'does not resolve a baseline or run ApiCompat when no GA exists' {
        Mock Get-SdkChangeLatestGaVersion { $null }
        Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output
        $report = Read-SdkChangeJson $output
        $report.details.baselineVersion | Should -BeNullOrEmpty
        $report.details.limitations -join ' ' | Should -Match 'no comparison was performed'
        Should -Invoke Get-SdkChangeBaseline -Times 0 -Exactly
        Should -Invoke Invoke-SdkChangeApiCompat -Times 0 -Exactly
    }

    It 'records a narrowed framework scope without adding raw contract fields' {
        $evaluation.Properties.TargetFrameworks = 'net8.0;net10.0'
        Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output
        $report = Read-SdkChangeJson $output
        $report.details.diagnostics | Should -Contain 'Current artifact scope: Configuration=Debug; TargetFrameworks=net8.0.'
        $report.details.limitations -join ' ' | Should -Match 'declared frameworks not evaluated: net10.0'
        $report.details.limitations -join ' ' | Should -Match 'not a full multi-target package comparison'
        @($report.details.Keys) | Should -Be @('baselineVersion', 'apiChanges', 'diagnostics', 'limitations')
    }

    It 'removes stale output on a registry failure' {
        [System.IO.File]::WriteAllText($output, '{"hasBreakingChange":false}')
        Mock Get-SdkChangeLatestGaVersion { throw 'Registry unavailable' }
        { Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output } |
            Should -Throw '*Registry unavailable*'
        Test-Path -LiteralPath $output | Should -BeFalse
    }

    It 'removes stale output on a missing artifact, even for a first release' {
        [System.IO.File]::WriteAllText($output, '{"hasBreakingChange":false}')
        Mock Assert-SdkChangeCurrentAssembly { throw 'Current assembly is missing' }
        Mock Get-SdkChangeLatestGaVersion { $null }
        { Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output } |
            Should -Throw '*Current assembly is missing*'
        Test-Path -LiteralPath $output | Should -BeFalse
        Should -Invoke Get-SdkChangeLatestGaVersion -Times 0 -Exactly
    }

    It 'leaves no success-shaped output on a partial native process failure' {
        [System.IO.File]::WriteAllText($output, '{"hasBreakingChange":false}')
        Mock Invoke-SdkChangeApiCompat {
            $log = New-TestLog -Diagnostics @((New-TestDiagnostic 'CP0002')) -ExitCode 1
            $log.Completed = $false
            $log
        }
        { Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output } |
            Should -Throw '*did not complete*'
        Test-Path -LiteralPath $output | Should -BeFalse
    }

    It 'fails before comparison when a dependency cannot be loaded' {
        [System.IO.File]::WriteAllText($output, '{"hasBreakingChange":false}')
        Mock Assert-SdkChangeReferences { throw "Missing assembly reference 'Dependency'." }
        { Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output } |
            Should -Throw '*Missing assembly reference*'
        Test-Path -LiteralPath $output | Should -BeFalse
        Should -Invoke Invoke-SdkChangeApiCompat -Times 0 -Exactly
    }

    It 'does not publish a report if a concurrent build replaces the current assembly' {
        $script:hashCalls = 0
        Mock Get-FileHash {
            $script:hashCalls++
            @{ Hash = "assembly-$script:hashCalls" }
        }
        { Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile $output } |
            Should -Throw '*assembly changed during extraction*'
        Test-Path -LiteralPath $output | Should -BeFalse
    }

    It 'requires an absolute output path' {
        { Invoke-SdkChangeExtraction -PackagePath $TestDrive -SdkRepoPath $TestDrive -OutputJsonFile 'result.json' } |
            Should -Throw '*must be absolute*'
    }
}

Describe 'Portable PDB compilation freshness' -Tag 'UnitTest' {
    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $evaluation = New-TestEvaluation $root
        $source = $evaluation.Items.Compile[0].FullPath
        [void][System.IO.Directory]::CreateDirectory((Split-Path $source -Parent))
        [System.IO.File]::WriteAllText($source, 'public class Client {}')
        $documents = @(@{ Name = $source; Algorithm = 'SHA256'; Hash = (Get-FileHash -LiteralPath $source).Hash })
        Mock Get-SdkChangeCompilationDocuments { $documents }
    }

    It 'accepts matching physical source checksums' {
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Not -Throw
    }

    It 'maps deterministic PDB paths to this checkout rather than reading a different checkout' {
        $documents[0].Name = '/_/src/Client.cs'
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Not -Throw
    }

    It 'ignores compiler-generated documents under the evaluated intermediate path' {
        $documents += @{ Name = Join-Path $evaluation.Properties.IntermediateOutputPath 'Generator' 'Generated.cs'; Algorithm = ''; Hash = '' }
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Not -Throw
    }

    It 'rejects changed source even if its timestamp was preserved' {
        $time = (Get-Item -LiteralPath $source).LastWriteTimeUtc
        [System.IO.File]::WriteAllText($source, 'public class RenamedClient {}')
        (Get-Item -LiteralPath $source).LastWriteTimeUtc = $time
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Throw '*compiled checksum*'
    }

    It 'rejects a deleted source that is no longer included by evaluation' {
        $evaluation.Items.Compile = @()
        Remove-Item -LiteralPath $source
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Throw '*not an evaluated Compile input*'
    }

    It 'rejects an added compile input that is absent from the PDB' {
        $newFile = Join-Path $root 'src' 'Added.cs'
        [System.IO.File]::WriteAllText($newFile, 'public class Added {}')
        $evaluation.Items.Compile += @{ FullPath = $newFile }
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Throw '*does not contain the evaluated Compile input*'
    }

    It 'fails explicitly on an unsupported source checksum' {
        $documents[0].Algorithm = ''
        { Assert-SdkChangeCompilationSources -Assembly 'unused.dll' -Evaluation $evaluation } | Should -Throw '*no supported source checksum*'
    }
}

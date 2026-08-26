#Requires -Version 7.0

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

Describe 'ProjectGraph sparse checkout projection' -Tag 'UnitTest' {
    BeforeAll {
        $script:CreateGraphPath = Join-Path $PSScriptRoot '..' 'Create-SparseCheckoutGraph.ps1'
        $script:ResolvePathsPath = Join-Path $PSScriptRoot '..' 'Resolve-SparseCheckoutPaths.ps1'
    }

    BeforeEach {
        $repo = Join-Path $TestDrive 'repo'
        $packageInfo = Join-Path $TestDrive 'PackageInfo'
        $graphPath = Join-Path $TestDrive 'graph.json'
        $checkoutGraphPath = Join-Path $TestDrive 'checkout-graph.json'
        New-Item -ItemType Directory -Path $repo, $packageInfo -Force | Out-Null
        & git -C $repo init --quiet

        foreach ($path in @(
            'sdk/alpha/A/tests/A.Tests.csproj',
            'sdk/beta/B/src/B.csproj',
            'sdk/gamma/C/src/C.csproj',
            'sdk/delta/D/src/D.csproj',
            'sdk/epsilon/E/src/E.csproj',
            'sdk/shared/Shared/Shared.cs')) {
            $fullPath = Join-Path $repo $path
            New-Item -ItemType Directory -Path (Split-Path $fullPath -Parent) -Force | Out-Null
            Set-Content -LiteralPath $fullPath -Value 'tracked'
        }
        & git -C $repo add .
        & git -C $repo -c user.name=Test -c user.email=test@example.com commit --quiet -m fixture
        $sourceCommit = (& git -C $repo rev-parse HEAD).Trim()

        @{
            ArtifactName = 'Azure.A'
            DirectoryPath = 'sdk/alpha/A'
        } | ConvertTo-Json | Set-Content (Join-Path $packageInfo 'Azure.A.json')

        [ordered]@{
            schemaVersion = 3
            repositoryRoot = $repo.Replace('\', '/')
            sourceCommit = $sourceCommit
            nodes = @(
                @{ projectPath = 'sdk/alpha/A/tests/A.Tests.csproj'; packageRoot = 'sdk/alpha/A'; targetFrameworks = @('net8.0', 'net9.0'); packageId = 'Azure.A.Tests'; isShippingLibrary = $false }
                @{ projectPath = 'sdk/beta/B/src/B.csproj'; packageRoot = 'sdk/beta/B'; targetFrameworks = @('net8.0'); packageId = 'Azure.B'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/gamma/C/src/C.csproj'; packageRoot = 'sdk/gamma/C'; targetFrameworks = @('net9.0'); packageId = 'Azure.C'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/delta/D/src/D.csproj'; packageRoot = 'sdk/delta/D'; targetFrameworks = @('net8.0'); packageId = 'Azure.D'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/epsilon/E/src/E.csproj'; packageRoot = 'sdk/epsilon/E'; targetFrameworks = @('net8.0'); packageId = 'Azure.E'; isShippingLibrary = $true }
            )
            configurationEdges = @(
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'sdk/beta/B/src/B.csproj'; toTargetFramework = 'net8.0' }
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net9.0'; to = 'sdk/gamma/C/src/C.csproj'; toTargetFramework = 'net9.0' }
                @{ kind = 'PackageReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'Azure.D'; toTargetFramework = '' }
                # NuGet identities are case-insensitive; serialized projection keys are not.
                @{ kind = 'TransitivePackageReference'; fromProject = 'sdk/delta/D/src/D.csproj'; fromTargetFramework = 'net8.0'; to = 'azure.e'; toTargetFramework = '' }
            )
            inputs = @(
                @{ projectPath = 'sdk/alpha/A/tests/A.Tests.csproj'; targetFrameworks = @('net8.0'); kind = 'Compile'; path = 'sdk/shared/Shared/Shared.cs' }
            )
            diagnostics = @{
                isComplete = $true
                generation = @{
                    configurations = @('Debug', 'Release')
                    includesInputs = $true
                }
                packageClosure = @{ resolutionMode = 'nuget-restore-graph' }
            }
        } | ConvertTo-Json -Depth 20 | Set-Content $graphPath
    }

    It 'extracts only the requested artifact closure from the shared graph' {
        & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
            -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit

        $checkoutGraph = Get-Content $checkoutGraphPath -Raw | ConvertFrom-Json
        $checkoutGraph.schemaVersion | Should -Be 1
        $checkoutGraph.sourceCommit | Should -Be $sourceCommit
        @($checkoutGraph.artifacts.'Azure.A').Count | Should -Be 2
        @($checkoutGraph.alwaysIncludedPaths) | Should -Be @('/*', '!/*/', '/eng', '/.config')

        $paths = @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A' `
            -ExpectedSourceCommit $sourceCommit)
        @($paths | Where-Object { $_ -match '^/sdk/(alpha|beta|delta|epsilon|gamma|shared)/' }) | Should -Be @(
            '/sdk/alpha/*',
            '/sdk/beta/*',
            '/sdk/delta/*',
            '/sdk/epsilon/*',
            '/sdk/gamma/*',
            '/sdk/shared/*')
    }

    It 'rejects incomplete and non-NuGet source graphs instead of narrowing' {
        $graph = Get-Content $graphPath -Raw | ConvertFrom-Json
        $graph.diagnostics.isComplete = $false
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath

        { & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
                -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit } | Should -Throw '*graph is incomplete*'

        $graph.diagnostics.isComplete = $true
        $graph.diagnostics.packageClosure.resolutionMode = 'unsupported-resolution-mode'
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
                -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit } | Should -Throw '*requires the NuGet restore graph*'

        $graph.diagnostics.packageClosure.resolutionMode = 'nuget-restore-graph'
        $graph.diagnostics.generation.includesInputs = $false
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
                -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit } | Should -Throw '*requires a Debug+Release*'
    }

    It 'rejects graph provenance when tracked source differs from the recorded commit' {
        $graph = Get-Content $graphPath -Raw | ConvertFrom-Json
        $graph.sourceCommit = 'stale'
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
                -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit } | Should -Throw '*does not match requested sparse-checkout provenance*'

        $graph.sourceCommit = $sourceCommit
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        Set-Content -LiteralPath (Join-Path $repo 'sdk/alpha/A/tests/A.Tests.csproj') -Value 'modified'

        { & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
                -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit } | Should -Throw '*has tracked changes*'
    }

    It 'unions duplicate artifact seeds instead of silently retaining the first directory' {
        @{
            ArtifactName = 'Azure.A'
            DirectoryPath = 'sdk/beta/B'
        } | ConvertTo-Json | Set-Content (Join-Path $packageInfo 'Azure.A.duplicate.json')

        & $script:CreateGraphPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath `
            -OutputPath $checkoutGraphPath -SourceCommit $sourceCommit

        $checkoutGraph = Get-Content $checkoutGraphPath -Raw | ConvertFrom-Json
        @($checkoutGraph.artifacts.'Azure.A').Count | Should -Be 3
    }

    It 'unions artifact batches and falls back on missing or stale graph data' {
        [ordered]@{
            schemaVersion = 1
            sourceCommit = $sourceCommit
            isComplete = $true
            failureReason = ''
            alwaysIncludedPaths = @('/*', '!/*/', '/eng')
            artifacts = @{
                'Azure.A' = @('configuration:A|net8.0')
                'Azure.B' = @('configuration:B|net8.0')
            }
            adjacency = @{
                'configuration:A|net8.0' = @('configuration:Shared|net8.0')
                'configuration:B|net8.0' = @('configuration:Shared|net8.0')
            }
            paths = @{
                'configuration:A|net8.0' = @('/sdk/alpha/*')
                'configuration:B|net8.0' = @('/sdk/beta/*')
                'configuration:Shared|net8.0' = @('/sdk/shared/*')
            }
        } | ConvertTo-Json -Depth 10 | Set-Content $checkoutGraphPath

        @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A,Azure.B' `
            -ExpectedSourceCommit $sourceCommit) | Should -Be @(
                '/*', '!/*/', '/eng', '/sdk/alpha/*', '/sdk/beta/*', '/sdk/shared/*')
        @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A,Missing' `
            -ExpectedSourceCommit $sourceCommit) | Should -BeNullOrEmpty
        @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A' `
            -ExpectedSourceCommit 'stale') | Should -BeNullOrEmpty
    }
}

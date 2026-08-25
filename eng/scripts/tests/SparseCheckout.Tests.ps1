#Requires -Version 7.0

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

Describe 'ProjectGraph sparse checkout mapping' -Tag 'UnitTest' {
    BeforeAll {
        $script:CreateMapPath = Join-Path $PSScriptRoot '..' 'Create-SparseCheckoutMap.ps1'
        $script:ResolvePathsPath = Join-Path $PSScriptRoot '..' 'Resolve-SparseCheckoutPaths.ps1'
    }

    BeforeEach {
        $repo = Join-Path $TestDrive 'repo'
        $packageInfo = Join-Path $TestDrive 'PackageInfo'
        $graphPath = Join-Path $TestDrive 'graph.json'
        $mapPath = Join-Path $TestDrive 'checkout-map.json'
        New-Item -ItemType Directory -Path $repo, $packageInfo -Force | Out-Null
        & git -C $repo init --quiet

        foreach ($path in @(
            'sdk/alpha/A/tests/A.Tests.csproj',
            'sdk/beta/B/src/B.csproj',
            'sdk/gamma/C/src/C.csproj',
            'sdk/delta/D/src/D.csproj',
            'sdk/shared/Shared/Shared.cs')) {
            $fullPath = Join-Path $repo $path
            New-Item -ItemType Directory -Path (Split-Path $fullPath -Parent) -Force | Out-Null
            Set-Content -LiteralPath $fullPath -Value 'tracked'
        }
        & git -C $repo add .

        @{
            ArtifactName = 'Azure.A'
            DirectoryPath = 'sdk/alpha/A'
        } | ConvertTo-Json | Set-Content (Join-Path $packageInfo 'Azure.A.json')

        [ordered]@{
            schemaVersion = 3
            repositoryRoot = $repo.Replace('\', '/')
            nodes = @(
                @{ projectPath = 'sdk/alpha/A/tests/A.Tests.csproj'; targetFrameworks = @('net8.0', 'net9.0'); packageId = 'Azure.A.Tests'; isShippingLibrary = $false }
                @{ projectPath = 'sdk/beta/B/src/B.csproj'; targetFrameworks = @('net8.0'); packageId = 'Azure.B'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/gamma/C/src/C.csproj'; targetFrameworks = @('net9.0'); packageId = 'Azure.C'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/delta/D/src/D.csproj'; targetFrameworks = @('net8.0'); packageId = 'Azure.D'; isShippingLibrary = $true }
            )
            configurationEdges = @(
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'sdk/beta/B/src/B.csproj'; toTargetFramework = 'net8.0' }
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net9.0'; to = 'sdk/gamma/C/src/C.csproj'; toTargetFramework = 'net9.0' }
                @{ kind = 'PackageReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'Azure.D'; toTargetFramework = '' }
            )
            inputs = @(
                @{ projectPath = 'sdk/alpha/A/tests/A.Tests.csproj'; targetFrameworks = @('net8.0'); kind = 'Compile'; path = 'sdk/shared/Shared/Shared.cs' }
            )
            diagnostics = @{
                isComplete = $true
                packageClosure = @{ resolutionMode = 'nuget-restore-graph' }
            }
        } | ConvertTo-Json -Depth 20 | Set-Content $graphPath
    }

    It 'unions TFM-specific project, repository-package, and input paths' {
        & $script:CreateMapPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath -OutputPath $mapPath

        $map = Get-Content $mapPath -Raw | ConvertFrom-Json
        @($map.'Azure.A') | Should -Be @(
            '/sdk/alpha/*',
            '/sdk/beta/*',
            '/sdk/delta/*',
            '/sdk/gamma/*',
            '/sdk/shared/*')
    }

    It 'rejects incomplete and non-NuGet graphs instead of narrowing' {
        $graph = Get-Content $graphPath -Raw | ConvertFrom-Json
        $graph.diagnostics.isComplete = $false
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath

        { & $script:CreateMapPath -PackageInfoDirectory $packageInfo -RepoRoot $repo -GraphPath $graphPath -OutputPath $mapPath } |
            Should -Throw '*graph is incomplete*'
    }

    It 'unions artifact paths and falls back when any artifact is unmapped' {
        @{
            '$alwaysIncludedPaths' = @('/*', '!/*/', '/eng')
            'Azure.A' = @('/sdk/alpha/*', '/sdk/beta/*')
            'Azure.B' = @('/sdk/beta/*', '/sdk/gamma/*')
        } | ConvertTo-Json | Set-Content $mapPath

        @(& $script:ResolvePathsPath -MapPath $mapPath -ArtifactNames 'Azure.A,Azure.B') |
            Should -Be @('/*', '!/*/', '/eng', '/sdk/alpha/*', '/sdk/beta/*', '/sdk/gamma/*')
        @(& $script:ResolvePathsPath -MapPath $mapPath -ArtifactNames 'Azure.A,Missing') | Should -BeNullOrEmpty
    }
}

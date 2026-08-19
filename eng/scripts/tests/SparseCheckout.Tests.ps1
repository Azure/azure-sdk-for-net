#Requires -Version 7.0
<#
.SYNOPSIS
Tests the MSBuild project graph and sparse-checkout manifest targets.

.How-To-Run
    Invoke-Pester -Output Detailed $PSScriptRoot/SparseCheckout.Tests.ps1
#>

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

BeforeAll {
    $script:TargetsPath = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' 'SparseCheckout.targets')).Path
    $script:CreateMapPath = (Resolve-Path (Join-Path $PSScriptRoot '..' 'Create-SparseCheckoutMap.ps1')).Path

    function New-GraphProject {
        param(
            [string] $Path,
            [string[]] $References = @(),
            [string[]] $CompileItems = @()
        )

        $directory = Split-Path -Parent $Path
        $null = New-Item -ItemType Directory -Path $directory -Force
        $referenceLines = @($References | ForEach-Object { "    <ProjectReference Include=`"$_`" />" })
        $compileLines = @($CompileItems | ForEach-Object { "    <Compile Include=`"$_`" />" })
        @(
            '<Project>'
            '  <ItemGroup>'
            $referenceLines
            $compileLines
            '  </ItemGroup>'
            "  <Import Project=`"$script:TargetsPath`" />"
            '</Project>'
        ) | Set-Content -LiteralPath $Path
    }

    function Invoke-Manifest {
        param(
            [string] $Project,
            [string] $RepoRoot,
            [string] $Manifest
        )

        $output = & dotnet msbuild $Project /t:GenerateSparseCheckoutManifest `
            "/p:RepoRoot=$RepoRoot" "/p:SparseCheckoutManifestPath=$Manifest" 2>&1
        return [pscustomobject]@{
            ExitCode = $LASTEXITCODE
            Output = ($output -join [Environment]::NewLine)
        }
    }

    function Invoke-Graph {
        param(
            [string] $Project,
            [string] $RepoRoot,
            [string] $Graph
        )

        $output = & dotnet msbuild $Project /t:GenerateSparseCheckoutGraph /m `
            "/p:RepoRoot=$RepoRoot" "/p:SparseCheckoutGraphPath=$Graph" 2>&1
        return [pscustomobject]@{
            ExitCode = $LASTEXITCODE
            Output = ($output -join [Environment]::NewLine)
        }
    }

    function New-PackageInfo {
        param(
            [string] $Directory,
            [string] $ArtifactName,
            [string] $DirectoryPath
        )

        $null = New-Item -ItemType Directory -Path $Directory -Force
        [ordered]@{
            ArtifactName = $ArtifactName
            DirectoryPath = $DirectoryPath
        } | ConvertTo-Json | Set-Content -LiteralPath (Join-Path $Directory "$ArtifactName.json")
    }
}

Describe 'GenerateSparseCheckoutManifest' -Tag 'UnitTest' {
    It 'emits sorted service roots for entry projects and transitive references' {
        $repo = Join-Path $TestDrive 'repo'
        $root = Join-Path $repo 'root.proj'
        $alpha = Join-Path $repo 'sdk/alpha/Alpha/src/Alpha.csproj'
        $beta = Join-Path $repo 'sdk/beta/Beta/src/Beta.csproj'
        $manifest = Join-Path $TestDrive 'manifest.txt'

        New-GraphProject -Path $beta
        New-GraphProject -Path $alpha -References @($beta)
        New-GraphProject -Path $root -References @($alpha)

        $result = Invoke-Manifest -Project $root -RepoRoot $repo -Manifest $manifest

        $result.ExitCode | Should -Be 0 -Because $result.Output
        @(Get-Content -LiteralPath $manifest) | Should -Be @('sdk/alpha', 'sdk/beta')
        $result.Output | Should -Match '2 projects'
    }

    It 'rejects graph projects outside the repository root' {
        $repo = Join-Path $TestDrive 'repo-with-external'
        $external = Join-Path $TestDrive 'external/External.csproj'
        $root = Join-Path $repo 'root.proj'
        $manifest = Join-Path $TestDrive 'external-manifest.txt'

        New-GraphProject -Path $external
        New-GraphProject -Path $root -References @($external)

        $result = Invoke-Manifest -Project $root -RepoRoot $repo -Manifest $manifest

        $result.ExitCode | Should -Not -Be 0
        $result.Output | Should -Match 'outside repository root'
        $manifest | Should -Not -Exist
    }

    It 'includes service roots reached through evaluated compile inputs' {
        $repo = Join-Path $TestDrive 'repo-with-shared-source'
        $root = Join-Path $repo 'root.proj'
        $alpha = Join-Path $repo 'sdk/alpha/Alpha/src/Alpha.csproj'
        $shared = Join-Path $repo 'sdk/beta/Beta/src/Shared.cs'
        $manifest = Join-Path $TestDrive 'shared-source-manifest.txt'

        $null = New-Item -ItemType Directory -Path (Split-Path -Parent $shared) -Force
        Set-Content -LiteralPath $shared -Value '// shared'
        New-GraphProject -Path $alpha -CompileItems @('../../../beta/Beta/src/Shared.cs')
        New-GraphProject -Path $root -References @($alpha)

        $result = Invoke-Manifest -Project $root -RepoRoot $repo -Manifest $manifest

        $result.ExitCode | Should -Be 0 -Because $result.Output
        @(Get-Content -LiteralPath $manifest) | Should -Be @('sdk/alpha', 'sdk/beta')
    }

    It 'ignores repository-root evaluated inputs that are already covered by the base checkout' {
        $repo = Join-Path $TestDrive 'repo-with-root-input'
        $root = Join-Path $repo 'root.proj'
        $alpha = Join-Path $repo 'sdk/alpha/Alpha/src/Alpha.csproj'
        $rootInput = Join-Path $repo 'global.json'
        $manifest = Join-Path $TestDrive 'root-input-manifest.txt'

        $null = New-Item -ItemType Directory -Path $repo -Force
        Set-Content -LiteralPath $rootInput -Value '{}'
        New-GraphProject -Path $alpha -CompileItems @('../../../../global.json')
        New-GraphProject -Path $root -References @($alpha)

        $result = Invoke-Manifest -Project $root -RepoRoot $repo -Manifest $manifest

        $result.ExitCode | Should -Be 0 -Because $result.Output
        @(Get-Content -LiteralPath $manifest) | Should -Be @('sdk/alpha')
    }

    It 'rejects an empty entry project selection' {
        $repo = Join-Path $TestDrive 'empty-repo'
        $root = Join-Path $repo 'root.proj'
        $manifest = Join-Path $TestDrive 'empty-manifest.txt'

        New-GraphProject -Path $root

        $result = Invoke-Manifest -Project $root -RepoRoot $repo -Manifest $manifest

        $result.ExitCode | Should -Not -Be 0
        $result.Output | Should -Match 'No entry projects were selected'
        $manifest | Should -Not -Exist
    }
}

Describe 'GenerateSparseCheckoutGraph' -Tag 'UnitTest' {
    It 'emits nodes, edges, and inputs once for a shared transitive graph' {
        $repo = Join-Path $TestDrive 'graph-repo'
        $root = Join-Path $repo 'root.proj'
        $alpha = Join-Path $repo 'sdk/alpha/Alpha/src/Alpha.csproj'
        $beta = Join-Path $repo 'sdk/beta/Beta/src/Beta.csproj'
        $gamma = Join-Path $repo 'sdk/gamma/Gamma/src/Gamma.csproj'
        $shared = Join-Path $repo 'sdk/shared/Shared/Shared.cs'
        $graph = Join-Path $TestDrive 'graph.txt'

        $null = New-Item -ItemType Directory -Path (Split-Path -Parent $shared) -Force
        Set-Content -LiteralPath $shared -Value '// shared'
        New-GraphProject -Path $beta
        New-GraphProject -Path $alpha -References @($beta) -CompileItems @('../../../shared/Shared/Shared.cs')
        New-GraphProject -Path $gamma -References @($beta)
        New-GraphProject -Path $root -References @($alpha, $gamma)

        $result = Invoke-Graph -Project $root -RepoRoot $repo -Graph $graph

        $result.ExitCode | Should -Be 0 -Because $result.Output
        $records = @(Get-Content -LiteralPath $graph)
        @($records | Where-Object { $_ -eq "Project|$beta" }).Count | Should -Be 1
        $records | Should -Contain "Reference|$alpha|$beta"
        $records | Should -Contain "Reference|$gamma|$beta"
        $records | Should -Contain "Input|$alpha|$shared"
        $result.Output | Should -Match '3 projects'
    }
}

Describe 'Create-SparseCheckoutMap' -Tag 'UnitTest' {
    It 'evaluates one graph and calculates distinct artifact closures' {
        $repo = Join-Path $TestDrive 'map-repo'
        $packageInfo = Join-Path $TestDrive 'PackageInfo'
        $repoTargets = Join-Path $repo 'eng/SparseCheckout.targets'
        $alpha = Join-Path $repo 'sdk/alpha/Alpha/src/Alpha.csproj'
        $beta = Join-Path $repo 'sdk/beta/Beta/src/Beta.csproj'
        $shared = Join-Path $repo 'sdk/gamma/Gamma/src/Shared.cs'
        $mapPath = Join-Path $TestDrive 'checkout-map.json'

        $null = New-Item -ItemType Directory -Path (Split-Path -Parent $repoTargets) -Force
        Copy-Item -LiteralPath $script:TargetsPath -Destination $repoTargets
        $null = New-Item -ItemType Directory -Path (Split-Path -Parent $shared) -Force
        Set-Content -LiteralPath $shared -Value '// shared'
        New-GraphProject -Path $beta
        New-GraphProject -Path $alpha -References @($beta) -CompileItems @('../../../gamma/Gamma/src/Shared.cs')
        New-PackageInfo -Directory $packageInfo -ArtifactName 'Alpha' -DirectoryPath 'sdk/alpha/Alpha'
        New-PackageInfo -Directory $packageInfo -ArtifactName 'Beta' -DirectoryPath 'sdk/beta/Beta'

        $output = & $script:CreateMapPath `
            -PackageInfoDirectory $packageInfo `
            -RepoRoot $repo `
            -OutputPath $mapPath 2>&1

        $LASTEXITCODE | Should -Be 0 -Because ($output -join [Environment]::NewLine)
        $map = Get-Content -LiteralPath $mapPath -Raw | ConvertFrom-Json
        @($map.Alpha) | Should -Be @('/sdk/alpha/*', '/sdk/beta/*', '/sdk/gamma/*')
        @($map.Beta) | Should -Be @('/sdk/beta/*')
        ($output -join [Environment]::NewLine) | Should -Match 'Sparse-checkout graph: 2 projects'
    }
}

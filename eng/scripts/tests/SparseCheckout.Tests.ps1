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

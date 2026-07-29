#Requires -Version 7.0
<#
.SYNOPSIS
    Unit tests for Get-TestCheckoutPaths.ps1.

.DESCRIPTION
    Builds small synthetic repository layouts and verifies that the checkout map
    follows the same rules the build uses to convert PackageReference entries into
    ProjectReference entries, that shared sources reached through '..' are accounted
    for, and that anything unexpected falls back to a full checkout instead of
    narrowing on incomplete data.

.How-To-Run
    Run these tests (Pester is installed automatically via PSModule-Helpers):
        Invoke-Pester -Output Detailed $PSScriptRoot/TestCheckoutPaths.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
    $script:ScriptPath = Join-Path $PSScriptRoot ".." "Get-TestCheckoutPaths.ps1"

    function New-Project {
        param(
            [string] $Path,
            [string[]] $ProjectReferences = @(),
            [string[]] $PackageReferences = @(),
            [string[]] $CompileIncludes = @()
        )

        $directory = Split-Path -Parent $Path
        if (-not (Test-Path $directory)) {
            $null = New-Item -ItemType Directory -Path $directory -Force
        }

        $items = @()
        foreach ($reference in $ProjectReferences) {
            $items += "    <ProjectReference Include=`"$reference`" />"
        }
        foreach ($reference in $PackageReferences) {
            $items += "    <PackageReference Include=`"$reference`" />"
        }
        foreach ($include in $CompileIncludes) {
            $items += "    <Compile Include=`"$include`" />"
        }

        @(
            '<Project Sdk="Microsoft.NET.Sdk">'
            '  <ItemGroup>'
            $items
            '  </ItemGroup>'
            '</Project>'
        ) | Set-Content -LiteralPath $Path
    }

    function New-TestRepo {
        $root = Join-Path ([System.IO.Path]::GetTempPath()) ([System.Guid]::NewGuid().ToString('n'))
        $null = New-Item -ItemType Directory -Path $root -Force

        # A package whose tests reach a second service through a PackageReference,
        # which is exactly what the build converts into a ProjectReference.
        New-Project -Path (Join-Path $root 'sdk/alpha/Contoso.Alpha/src/Contoso.Alpha.csproj')
        New-Project -Path (Join-Path $root 'sdk/alpha/Contoso.Alpha/tests/Contoso.Alpha.Tests.csproj') `
            -ProjectReferences @('..\src\Contoso.Alpha.csproj') `
            -PackageReferences @('Contoso.Beta')

        # The second service, which in turn reaches a third one.
        New-Project -Path (Join-Path $root 'sdk/beta/Contoso.Beta/src/Contoso.Beta.csproj') `
            -PackageReferences @('Contoso.Gamma')
        New-Project -Path (Join-Path $root 'sdk/gamma/Contoso.Gamma/src/Contoso.Gamma.csproj')

        # An unrelated service that must never be pulled in.
        New-Project -Path (Join-Path $root 'sdk/omega/Contoso.Omega/src/Contoso.Omega.csproj')

        # A package that links shared sources from another service via '..'.
        New-Project -Path (Join-Path $root 'sdk/delta/Contoso.Delta/src/Contoso.Delta.csproj')
        New-Project -Path (Join-Path $root 'sdk/delta/Contoso.Delta/tests/Contoso.Delta.Tests.csproj') `
            -ProjectReferences @('..\src\Contoso.Delta.csproj') `
            -CompileIncludes @('..\..\..\shared\Contoso.Shared\Helpers\*.cs')
        $null = New-Item -ItemType Directory -Path (Join-Path $root 'sdk/shared/Contoso.Shared/Helpers') -Force

        return $root
    }

    function Get-Map {
        param([string] $Root)

        $mapPath = Join-Path $Root 'checkout-map.json'
        & $script:ScriptPath -BuildMap -RepoRoot $Root -OutputPath $mapPath | Out-Null
        return $mapPath
    }

    function Get-Services {
        param([string[]] $Paths)

        return @($Paths | Where-Object { $_ -like '/sdk/*' } | ForEach-Object { $_ -replace '^/sdk/', '' -replace '/\*$', '' })
    }
}

Describe 'Get-TestCheckoutPaths' {
    BeforeAll {
        $script:Root = New-TestRepo
        $script:MapPath = Get-Map -Root $script:Root
    }

    AfterAll {
        Remove-Item -LiteralPath $script:Root -Recurse -Force -ErrorAction SilentlyContinue
    }

    Context 'building the map' {
        It 'creates an entry for every src project' {
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            $map.PSObject.Properties.Name | Sort-Object | Should -Be @(
                '$alwaysIncludedPaths',
                'Contoso.Alpha', 'Contoso.Beta', 'Contoso.Delta', 'Contoso.Gamma', 'Contoso.Omega')
        }

        It 'records the always-included paths in the map so consumers never duplicate the list' {
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            $always = @($map.'$alwaysIncludedPaths')
            $always | Should -Contain '/*'
            $always | Should -Contain '/eng'
            $always | Should -Contain '/common'
            foreach ($service in @('core', 'common', 'identity', 'resourcemanager', 'template', 'tools')) {
                $always | Should -Contain "/sdk/$service/*"
            }
        }

        It 'the resolver inlined into ci.tests.yml does not keep its own copy of the list' {
            # A second hardcoded copy of the always-included services in the pipeline
            # caused a build break once already: sdk/tools was added here but not there,
            # the injected Azure.SdkAnalyzers ProjectReference silently degraded to an
            # MSB9008 warning, and the build failed later with AAIP001 errors.
            $pipeline = Get-Content -LiteralPath (
                Join-Path $PSScriptRoot '..' '..' 'pipelines' 'templates' 'jobs' 'ci.tests.yml') -Raw
            $pipeline | Should -Match '\$alwaysIncludedPaths'
            $pipeline | Should -Not -Match "'resourcemanager'"
        }

        It 'follows PackageReference entries transitively, because the build converts them to project references' {
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Alpha') | Sort-Object | Should -Be @('alpha', 'beta', 'gamma')
        }

        It 'includes services reached only through linked shared sources' {
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Delta') | Should -Contain 'shared'
        }
    }

    Context 'resolving checkout paths' {
        It 'emits the base patterns the sparse checkout step relies on' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha'
            $paths[0..3] | Should -Be @('/*', '!/*/', '/eng', '/.config')
        }

        It 'includes every non-sdk top level directory' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha'
            foreach ($expected in @('/common', '/doc', '/samples', '/.github')) {
                $paths | Should -Contain $expected
            }
        }

        It 'includes the closure of the requested package' {
            $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha')
            foreach ($expected in @('alpha', 'beta', 'gamma')) {
                $services | Should -Contain $expected
            }
        }

        It 'excludes services the package does not reach' {
            $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha')
            $services | Should -Not -Contain 'omega'
        }

        It 'always includes the services projects reach without naming them' {
            $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Omega')
            foreach ($expected in @('core', 'common', 'identity', 'resourcemanager', 'template', 'tools')) {
                $services | Should -Contain $expected
            }
        }

        It 'always includes sdk/tools so the injected analyzer ProjectReferences resolve' {
            # eng/Directory.Build.Common.targets injects ProjectReferences to
            # $(RepoRoot)/sdk/tools/Azure.SdkAnalyzers[.CodeFixes] into every project.
            # A missing analyzer project is only an MSB9008 warning, so the failure
            # surfaces much later as unsuppressed analyzer errors. Regression guard.
            foreach ($artifact in @('Contoso.Alpha', 'Contoso.Omega', 'Contoso.Alpha,Contoso.Omega')) {
                $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames $artifact)
                $services | Should -Contain 'tools'
            }
        }

        It 'unions the closures of every package in the batch' {
            $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha,Contoso.Omega')
            foreach ($expected in @('alpha', 'beta', 'gamma', 'omega')) {
                $services | Should -Contain $expected
            }
        }

        It 'tolerates whitespace around package names' {
            $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames ' Contoso.Alpha , Contoso.Omega ')
            $services | Should -Contain 'omega'
        }

        It 'never emits duplicate paths' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha,Contoso.Alpha'
            ($paths | Select-Object -Unique).Count | Should -Be $paths.Count
        }
    }

    Context 'falling back to a full checkout' {
        It 'falls back when a package is missing from the map' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Unknown' -WarningAction SilentlyContinue
            $paths | Should -BeNullOrEmpty
        }

        It 'falls back when any package in the batch is missing from the map' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha,Contoso.Unknown' -WarningAction SilentlyContinue
            $paths | Should -BeNullOrEmpty
        }

        It 'falls back when the map file does not exist' {
            $paths = & $script:ScriptPath -MapPath (Join-Path $script:Root 'missing.json') -ArtifactNames 'Contoso.Alpha' -WarningAction SilentlyContinue
            $paths | Should -BeNullOrEmpty
        }

        It 'falls back when no package names are supplied' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames '' -WarningAction SilentlyContinue
            $paths | Should -BeNullOrEmpty
        }
    }
}

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
            [string[]] $CompileIncludes = @(),
            [string[]] $Imports = @()
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

        $importLines = @()
        foreach ($import in $Imports) {
            $importLines += "  <Import Project=`"$import`" />"
        }

        @(
            '<Project Sdk="Microsoft.NET.Sdk">'
            $importLines
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

        # A package that reaches another service through $(MSBuildThisFileDirectory),
        # which the resolver expands because it is always the project's own directory.
        New-Project -Path (Join-Path $root 'sdk/sigma/Contoso.Sigma/src/Contoso.Sigma.csproj')
        New-Project -Path (Join-Path $root 'sdk/sigma/Contoso.Sigma/tests/Contoso.Sigma.Tests.csproj') `
            -ProjectReferences @(
                '..\src\Contoso.Sigma.csproj',
                '$(MSBuildThisFileDirectory)..\..\..\kappa\Contoso.Kappa\src\Contoso.Kappa.csproj')
        New-Project -Path (Join-Path $root 'sdk/kappa/Contoso.Kappa/src/Contoso.Kappa.csproj')

        # A package that reaches another project through an MSBuild property the
        # resolver cannot expand. Its closure is untrustworthy, so it must be recorded
        # as unmappable and fall back to a full checkout.
        New-Project -Path (Join-Path $root 'sdk/zeta/Contoso.Zeta/src/Contoso.Zeta.csproj')
        New-Project -Path (Join-Path $root 'sdk/zeta/Contoso.Zeta/tests/Contoso.Zeta.Tests.csproj') `
            -ProjectReferences @('..\src\Contoso.Zeta.csproj', '$(SomeUnknownProperty)')

        # A package that links shared sources from another service via '..'.
        New-Project -Path (Join-Path $root 'sdk/delta/Contoso.Delta/src/Contoso.Delta.csproj')
        New-Project -Path (Join-Path $root 'sdk/delta/Contoso.Delta/tests/Contoso.Delta.Tests.csproj') `
            -ProjectReferences @('..\src\Contoso.Delta.csproj') `
            -CompileIncludes @('..\..\..\shared\Contoso.Shared\Helpers\*.cs')
        $null = New-Item -ItemType Directory -Path (Join-Path $root 'sdk/shared/Contoso.Shared/Helpers') -Force

        # A package that reaches another service through <Import Project="...">. A missing
        # import is a hard MSBuild error, so it has to participate in the closure.
        New-Project -Path (Join-Path $root 'sdk/iota/Contoso.Iota/src/Contoso.Iota.csproj') `
            -Imports @('..\..\..\imported\Contoso.Imported\build\Common.props')
        $null = New-Item -ItemType Directory -Path (Join-Path $root 'sdk/imported/Contoso.Imported/build') -Force

        # Properties that cannot move a path into another service must not force a
        # fallback: the project's own build output.
        New-Project -Path (Join-Path $root 'sdk/theta/Contoso.Theta/src/Contoso.Theta.csproj') `
            -CompileIncludes @('$(OutputPath)netstandard2.0\$(AssemblyName).dll')

        # A property whose name merely *ends* in an exempt token is a different property
        # and must still force a fallback. This is what anchoring the pattern buys.
        New-Project -Path (Join-Path $root 'sdk/psi/Contoso.Psi/src/Contoso.Psi.csproj') `
            -CompileIncludes @('$(AzureCoreOutputPath)netstandard2.0\Contoso.Psi.dll')

        # An MSBuild function call is not exempt. It would be safe in principle, but the
        # script never evaluates its arguments, so it is treated as unmappable: a
        # needlessly full checkout is correct, just slow.
        New-Project -Path (Join-Path $root 'sdk/chi/Contoso.Chi/src/Contoso.Chi.csproj') `
            -Imports @('$([MSBuild]::GetDirectoryNameOfFileAbove(.., Directory.Build.props))\Directory.Build.props')

        # An unknown property in a linked-source include is as untrustworthy as one in a
        # ProjectReference, so it must also make the package unmappable.
        New-Project -Path (Join-Path $root 'sdk/lambda/Contoso.Lambda/src/Contoso.Lambda.csproj') `
            -CompileIncludes @('$(SomeOtherUnknownProperty)Shared\*.cs')

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
                'Contoso.Alpha', 'Contoso.Beta',
                'Contoso.Chi', 'Contoso.Delta', 'Contoso.Gamma', 'Contoso.Iota',
                'Contoso.Kappa', 'Contoso.Lambda', 'Contoso.Omega', 'Contoso.Psi',
                'Contoso.Sigma', 'Contoso.Theta', 'Contoso.Zeta')
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

        It 'ci.tests.yml calls this script instead of reimplementing the resolver' {
            # A second copy of the resolution logic in the pipeline caused a build break
            # once already: sdk/tools was added to this script but not to the pipeline
            # copy, the injected Azure.SdkAnalyzers ProjectReference silently degraded to
            # an MSB9008 warning, and the build failed later with AAIP001 errors. The
            # pipeline must therefore invoke the published script, not restate its rules.
            $pipeline = Get-Content -LiteralPath (
                Join-Path $PSScriptRoot '..' '..' 'pipelines' 'templates' 'jobs' 'ci.tests.yml') -Raw
            $pipeline | Should -Match 'Get-TestCheckoutPaths\.ps1'
            $pipeline | Should -Match '-MapPath'
            $pipeline | Should -Not -Match '\$alwaysIncludedPaths'
            $pipeline | Should -Not -Match "'resourcemanager'"
        }

        It 'ci.tests.yml defaults TestSparseCheckoutPaths to a full checkout' {
            # The resolver overwrites this, but a run where it never executes must still
            # leave sparse-checkout.yml a parseable JSON array rather than an undefined
            # macro, which its ConvertFrom-Json would fail on.
            $pipeline = Get-Content -LiteralPath (
                Join-Path $PSScriptRoot '..' '..' 'pipelines' 'templates' 'jobs' 'ci.tests.yml') -Raw
            $pipeline | Should -Match 'TestSparseCheckoutPaths:\s*.\["/\*"'
        }

        It 'pr-matrix-presteps.yml publishes the resolver next to the map' {
            # The test job has no working tree when it resolves its paths, so the script
            # has to travel inside the artifact alongside checkout-map.json.
            $presteps = Get-Content -LiteralPath (
                Join-Path $PSScriptRoot '..' '..' 'pipelines' 'templates' 'steps' 'pr-matrix-presteps.yml') -Raw
            $presteps | Should -Match 'Copy-Item[\s\S]*Get-TestCheckoutPaths\.ps1'
        }

        It 'follows PackageReference entries transitively, because the build converts them to project references' {
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Alpha') | Sort-Object | Should -Be @('alpha', 'beta', 'gamma')
        }

        It 'follows an Import element across service directories' {
            # A cross-service import that is missing from the working tree is a hard
            # MSBuild error, not a warning like an unresolved analyzer reference.
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Iota') | Should -Contain 'imported'
        }

        It 'does not fall back for properties that cannot leave the project directory' {
            # $(OutputPath) resolves to the project's own bin directory. Treating it as
            # unresolvable would make most of the repository unmappable, because the
            # analyzer project injected into every package uses it.
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Theta') | Should -Not -BeNullOrEmpty
        }

        It 'still falls back for a property whose name merely ends in an exempt token' {
            # $(AzureCoreOutputPath) is not $(OutputPath). An unanchored pattern would
            # exempt it and silently narrow the checkout, so this guards the anchoring.
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Psi') | Should -BeNullOrEmpty
        }

        It 'falls back for an MSBuild function call it cannot evaluate' {
            # Exempting a function whose arguments are never evaluated is the widest part
            # of the blast radius, and no .csproj in the repo needs it. Staying
            # conservative here costs a full checkout only for projects that use one.
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Chi') | Should -BeNullOrEmpty
        }

        It 'treats an unknown property in a linked-source include as unmappable' {
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Lambda') | Should -BeNullOrEmpty
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

        It 'expands $(MSBuildThisFileDirectory) so cross-service references are followed' {
            $services = Get-Services -Paths (& $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Sigma')
            $services | Should -Contain 'sigma'
            $services | Should -Contain 'kappa'
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

        It 'falls back when a package references projects through an unexpandable property' {
            # The closure cannot be trusted, so the map records an empty entry and the
            # resolver must widen to a full checkout rather than narrow on bad data.
            $map = Get-Content -LiteralPath $script:MapPath -Raw | ConvertFrom-Json
            @($map.'Contoso.Zeta') | Should -HaveCount 0
            & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Zeta' -WarningAction SilentlyContinue |
                Should -BeNullOrEmpty
        }

        It 'falls back when one package in the batch is unmappable even if others are fine' {
            & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames 'Contoso.Alpha,Contoso.Zeta' -WarningAction SilentlyContinue |
                Should -BeNullOrEmpty
        }

        It 'falls back when the map file does not exist' {
            $paths = & $script:ScriptPath -MapPath (Join-Path $script:Root 'missing.json') -ArtifactNames 'Contoso.Alpha' -WarningAction SilentlyContinue
            $paths | Should -BeNullOrEmpty
        }

        It 'falls back when the map file is empty' {
            $empty = Join-Path $TestDrive 'empty-map.json'
            Set-Content -LiteralPath $empty -Value '' -NoNewline
            & $script:ScriptPath -MapPath $empty -ArtifactNames 'Contoso.Alpha' -WarningAction SilentlyContinue |
                Should -BeNullOrEmpty
        }

        It 'falls back when the map file is truncated rather than throwing' {
            $truncated = Join-Path $TestDrive 'truncated-map.json'
            Set-Content -LiteralPath $truncated -Value '{"Contoso.Alpha":["alpha","bet' -NoNewline
            & $script:ScriptPath -MapPath $truncated -ArtifactNames 'Contoso.Alpha' -WarningAction SilentlyContinue |
                Should -BeNullOrEmpty
        }

        It 'falls back when no package names are supplied' {
            $paths = & $script:ScriptPath -MapPath $script:MapPath -ArtifactNames '' -WarningAction SilentlyContinue
            $paths | Should -BeNullOrEmpty
        }
    }
}

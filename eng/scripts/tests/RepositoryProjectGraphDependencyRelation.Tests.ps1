#Requires -Version 7.0

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

Describe 'Repository project graph dependency-relation validation' -Tag 'UnitTest' {
    BeforeAll {
        . (Join-Path $PSScriptRoot '..' 'Validate-RepositoryProjectGraph.ps1')
        $script:RepositoryRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')

        function New-TestPackage([string] $Name, [string] $DirectoryPath) {
            return [pscustomobject]@{
                Name = $Name
                ArtifactName = $Name
                DirectoryPath = $DirectoryPath
                IncludedForValidation = $false
            }
        }

        function New-TestNode(
            [string] $ProjectPath,
            [string] $PackageId,
            [string] $PackageRoot,
            [bool] $IsShipping,
            [bool] $IsClient = $true,
            [bool] $IsGenerator = $false,
            [string[]] $TargetFrameworks = @('net8.0')) {
            return [pscustomobject]@{
                projectPath = $ProjectPath
                packageId = $PackageId
                packageRoot = $PackageRoot
                isClientLibrary = $IsClient
                isGeneratorLibrary = $IsGenerator
                isShippingLibrary = $IsShipping
                targetFrameworks = $TargetFrameworks
            }
        }

        function New-TestGraph([string] $Root) {
            $packageBRoot = Join-Path $Root 'sdk/example/Azure.B'
            $dependentRoot = Join-Path $Root 'sdk/example/Azure.Dependent'
            return [pscustomobject]@{
                schemaVersion = 1
                repositoryRoot = $Root
                nodes = @(
                    (New-TestNode 'sdk/example/Azure.B/src/Azure.B.csproj' 'Azure.B' 'sdk/example/Azure.B' $true `
                        -TargetFrameworks @('net8.0', 'net9.0'))
                    (New-TestNode 'sdk/example/Azure.Dependent/tests/Azure.Dependent.Tests.csproj' `
                        'Azure.Dependent.Tests' 'sdk/example/Azure.Dependent' $false `
                        -TargetFrameworks @('net8.0', 'net9.0'))
                    (New-TestNode 'sdk/example/Generator/tests/Generator.Tests.csproj' `
                        'Generator.Tests' 'sdk/example/Generator' $false -IsGenerator $true)
                )
                configurationEdges = @(
                    [pscustomobject]@{
                        kind = 'PackageReference'
                        fromProject = 'sdk/example/Azure.Dependent/tests/Azure.Dependent.Tests.csproj'
                        fromTargetFramework = 'net9.0'
                        to = 'Azure.B'
                    }
                    [pscustomobject]@{
                        kind = 'PackageReference'
                        fromProject = 'sdk/example/Generator/tests/Generator.Tests.csproj'
                        fromTargetFramework = 'net8.0'
                        to = 'Azure.B'
                    }
                )
                roots = @(
                    'sdk/example/Azure.Dependent/tests/Azure.Dependent.Tests.csproj'
                    'sdk/example/Generator/tests/Generator.Tests.csproj'
                )
                diagnostics = [pscustomobject]@{ isComplete = $true }
            }
        }
    }

    It 'collects all inner TFMs once and returns ReferencePath.Filename records' {
        $fixtureRoot = Join-Path $TestDrive 'collector'
        $projectPath = Join-Path $fixtureRoot 'Collector.csproj'
        $packageRoot = Join-Path $fixtureRoot 'package'
        $recordsPath = Join-Path $fixtureRoot 'records.txt'
        $dependencyPath = Join-Path $fixtureRoot 'Azure.CaseSensitive.dll'
        $collectorTargetsPath = Join-Path $script:RepositoryRoot `
            'eng/tools/RepositoryProjectGraph/CollectMSBuildProjectReferenceOracle.targets'
        $targetsPath = Join-Path $fixtureRoot 'fixture.targets'
        New-Item -ItemType Directory -Path $fixtureRoot, $packageRoot -Force | Out-Null

        # Override ResolveReferences in the fixture-only import so this target integration test is
        # deterministic and does not contact package feeds. Production imports only the collector.
        @"
<Project>
  <Import Project="$collectorTargetsPath" />
  <Target Name="ResolveReferences">
    <ItemGroup>
      <ReferencePath Include="$dependencyPath" />
      <ReferencePath Include="$dependencyPath" />
    </ItemGroup>
  </Target>
</Project>
"@ | Set-Content -LiteralPath $targetsPath

        @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net8.0;net9.0</TargetFrameworks>
    <IsClientLibrary>true</IsClientLibrary>
    <IsGeneratorLibrary>false</IsGeneratorLibrary>
    <PackageRootDirectory>$packageRoot</PackageRootDirectory>
  </PropertyGroup>
  <Target Name="WriteFixtureRecords" AfterTargets="CollectMSBuildProjectReferenceOracle">
    <WriteLinesToFile File="$recordsPath"
                      Lines="@(MSBuildProjectReferenceOracleRecord)"
                      Overwrite="true" />
  </Target>
</Project>
"@ | Set-Content -LiteralPath $projectPath

        & dotnet msbuild $projectPath -nologo -verbosity:quiet -target:CollectMSBuildProjectReferenceOracle `
            "-property:CustomAfterMicrosoftCommonTargets=$targetsPath" `
            "-property:CustomAfterMicrosoftCommonCrossTargetingTargets=$targetsPath"
        $LASTEXITCODE | Should -Be 0

        $fixtureRecords = @(Get-Content -LiteralPath $recordsPath | Where-Object {
            $_ -like 'Azure.CaseSensitive|*'
        })
        $fixtureRecords.Count | Should -Be 2
        @($fixtureRecords | ForEach-Object { $_.Split('|')[3] } | Sort-Object) |
            Should -Be @('net8.0', 'net9.0')
        @($fixtureRecords | ForEach-Object { $_.Split('|')[0] } | Sort-Object -Unique) |
            Should -Be @('Azure.CaseSensitive')
    }

    It 'normalizes multi-TFM oracle records and intersects package identity case-insensitively' {
        $root = Join-Path $TestDrive 'oracle-repo'
        $recordsPath = Join-Path $TestDrive 'oracle.records'
        $packageRoot = Join-Path $root 'sdk/example/Azure.Dependent'
        $project = Join-Path $packageRoot 'tests/Azure.Dependent.Tests.csproj'
        New-Item -ItemType Directory -Path (Split-Path $project -Parent) -Force | Out-Null
        @(
            "azure.b|$packageRoot|$project|net8.0"
            "Azure.B|$packageRoot/|$project|net9.0"
            "Azure.B|$packageRoot|$project|net9.0"
            "External.Package|$packageRoot|$project|net9.0"
        ) | Set-Content -LiteralPath $recordsPath
        $packages = @((New-TestPackage 'Azure.B' (Join-Path $root 'sdk/example/Azure.B')))

        $result = Convert-MSBuildProjectReferenceOracleRecordsToRelation $recordsPath $packages $root

        $result.Relation | Should -Be @("Azure.B`t$packageRoot")
        $result.RawRecordCount | Should -Be 3
        $result.ConfigurationCount | Should -Be 2
        $result.TargetFrameworks | Should -Be @('net8.0', 'net9.0')
    }

    It 'exports the complete graph relation with production root and generator filters' {
        $root = Join-Path $TestDrive 'graph-repo'
        $graph = New-TestGraph $root
        $package = New-TestPackage 'azure.b' (Join-Path $root 'sdk/example/Azure.B')

        $result = Get-GraphDependencyRelation $graph @($package)

        $result.Relation | Should -Be @("azure.b`t$(Join-Path $root 'sdk/example/Azure.Dependent')")
        $result.Relation | Should -Not -Match 'Generator'
    }

    It 'compares sorted unique relations exactly' {
        $comparison = Compare-DependencyRelations `
            @("Azure.A`t/root/a", "azure.a`t/root/a", "Azure.B`t/root/b") `
            @("AZURE.A`t/root/a", "Azure.C`t/root/c")

        $comparison.MSBuildProjectReferenceOracleOnly | Should -Be @("Azure.B`t/root/b")
        $comparison.GraphOnly | Should -Be @("Azure.C`t/root/c")
    }

    It 'fails closed for incomplete graphs, unknown PackageInfo, and duplicate directory mappings' {
        $root = Join-Path $TestDrive 'fail-closed'
        $graph = New-TestGraph $root
        $graph.diagnostics.isComplete = $false
        { Get-GraphDependencyRelation $graph @((New-TestPackage 'Azure.B' '/b')) } |
            Should -Throw '*incomplete*'

        $graph.diagnostics.isComplete = $true
        { Get-GraphDependencyRelation $graph @((New-TestPackage 'Azure.Unknown' '/unknown')) } |
            Should -Throw '*no shipping project*'

        $duplicatePackages = @(
            (New-TestPackage 'Azure.A' '/same')
            (New-TestPackage 'Azure.B' '/same')
        )
        { Convert-RelationToPackageInfoRelation @() $duplicatePackages } |
            Should -Throw '*does not map to exactly one*'
    }

    It 'maps roots with final Language-Settings direct, indirect, union, and empty-input semantics' {
        $packages = @(
            (New-TestPackage 'Azure.A' '/packages/a')
            (New-TestPackage 'Azure.B' '/packages/b')
            (New-TestPackage 'Azure.C' '/packages/c')
        )
        $relation = @(
            "Azure.A`t/packages/a"
            "Azure.A`t/packages/b"
            "Azure.B`t/packages/c"
        )

        $forA = @(Get-IndirectPackageInfoSelection $relation $packages @('Azure.A'))
        $forA.Name | Should -Be @('Azure.B')
        $forA.IncludedForValidation | Should -BeTrue

        $forUnion = @(Get-IndirectPackageInfoSelection $relation $packages @('Azure.A', 'Azure.B'))
        $forUnion.Name | Should -Be @('Azure.C')
        @(Get-IndirectPackageInfoSelection $relation $packages @()).Count | Should -Be 0
    }

    It 'classifies mismatch provenance and dynamically enumerates NuGet-only identities' {
        $root = Join-Path $TestDrive 'classification'
        $recordsPath = Join-Path $TestDrive 'classification.records'
        $packageRecordsPath = Join-Path $TestDrive 'classification.packages.records'
        $rootP2P = Join-Path $root 'sdk/example/P2P'
        $rootDirect = Join-Path $root 'sdk/example/Direct'
        $rootTransitive = Join-Path $root 'sdk/example/Transitive'
        $graph = [pscustomobject]@{
            schemaVersion = 1
            repositoryRoot = $root
            nodes = @(
                (New-TestNode 'sdk/example/B/src/B.csproj' 'Azure.B' 'sdk/example/B' $true)
                (New-TestNode 'sdk/example/C/src/C.csproj' 'Azure.C' 'sdk/example/C' $true)
                (New-TestNode 'sdk/example/D/src/D.csproj' 'Azure.D' 'sdk/example/D' $true)
                (New-TestNode 'sdk/example/P2P/tests/P2P.Tests.csproj' 'P2P.Tests' 'sdk/example/P2P' $false)
                (New-TestNode 'sdk/example/Direct/tests/Direct.Tests.csproj' 'Direct.Tests' 'sdk/example/Direct' $false)
                (New-TestNode 'sdk/example/Transitive/tests/Transitive.Tests.csproj' 'Transitive.Tests' 'sdk/example/Transitive' $false)
            )
            configurationEdges = @(
                [pscustomobject]@{ kind = 'ProjectReference'; fromProject = 'sdk/example/P2P/tests/P2P.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'sdk/example/B/src/B.csproj'; toTargetFramework = 'net8.0'; referenceOutputAssembly = $true }
                [pscustomobject]@{ kind = 'PackageReference'; fromProject = 'sdk/example/Direct/tests/Direct.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'Azure.C' }
                [pscustomobject]@{ kind = 'PackageReference'; fromProject = 'sdk/example/Transitive/tests/Transitive.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'Azure.D' }
            )
            roots = @(
                'sdk/example/P2P/tests/P2P.Tests.csproj'
                'sdk/example/Direct/tests/Direct.Tests.csproj'
                'sdk/example/Transitive/tests/Transitive.Tests.csproj'
            )
            diagnostics = [pscustomobject]@{ isComplete = $true }
        }
        New-Item -ItemType Directory -Path $root -Force | Out-Null
        "PackageReference|$(Join-Path $root 'sdk/example/Direct/tests/Direct.Tests.csproj')|net8.0|Azure.C||||1.0.0" |
            Set-Content -LiteralPath $recordsPath
        "TransitivePackageReference|$(Join-Path $root 'sdk/example/Transitive/tests/Transitive.Tests.csproj')|net8.0|Azure.D" |
            Set-Content -LiteralPath $packageRecordsPath
        $model = New-DependencyGraphModel $graph
        $provenance = Read-DependencyProvenance $recordsPath $packageRecordsPath $model

        Get-MismatchClassification "Azure.B`t$rootP2P" $model $provenance |
            Should -Be 'direct-p2p'
        Get-MismatchClassification "Azure.C`t$rootDirect" $model $provenance |
            Should -Be 'direct-repository-package-reference'
        Get-MismatchClassification "Azure.D`t$rootTransitive" $model $provenance |
            Should -Be 'nuget-derived-transitive-package-reference'
        $provenance.NuGetOnlyIdentities | Should -Be @('Azure.D')
    }

    It 'keeps non-assembly P2P edges in forward traversal but excludes them from reverse selection' {
        $root = Join-Path $TestDrive 'non-assembly'
        $dependentRoot = Join-Path $root 'sdk/example/Dependent'
        $graph = [pscustomobject]@{
            schemaVersion = 1
            repositoryRoot = $root
            nodes = @(
                (New-TestNode 'sdk/example/Analyzer/src/Analyzer.csproj' 'Azure.Analyzer' 'sdk/example/Analyzer' $true)
                (New-TestNode 'sdk/example/Dependent/src/Dependent.csproj' 'Azure.Dependent' 'sdk/example/Dependent' $true)
            )
            configurationEdges = @(
                [pscustomobject]@{
                    kind = 'ProjectReference'
                    fromProject = 'sdk/example/Dependent/src/Dependent.csproj'
                    fromTargetFramework = 'net8.0'
                    to = 'sdk/example/Analyzer/src/Analyzer.csproj'
                    toTargetFramework = 'net8.0'
                    referenceOutputAssembly = $false
                }
            )
            roots = @('sdk/example/Dependent/src/Dependent.csproj')
            diagnostics = [pscustomobject]@{ isComplete = $true }
        }

        $result = Get-GraphDependencyRelation $graph @(
            (New-TestPackage 'Azure.Analyzer' (Join-Path $root 'sdk/example/Analyzer'))
            (New-TestPackage 'Azure.Dependent' $dependentRoot)
        )
        $source = Get-ConfigurationKey 'sdk/example/Dependent/src/Dependent.csproj' 'net8.0'
        $analyzer = Get-ConfigurationKey 'sdk/example/Analyzer/src/Analyzer.csproj' 'net8.0'

        $result.Relation | Should -Not -Contain "Azure.Analyzer`t$dependentRoot"
        $result.Model.Forward[$source] | Should -Contain $analyzer
        $result.Model.Reverse.ContainsKey($analyzer) | Should -BeFalse
    }
}

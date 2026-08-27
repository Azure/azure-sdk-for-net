#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe "RepositoryProjectGraph" -Tag "UnitTest" {
    BeforeAll {
        $scriptPath = Join-Path $PSScriptRoot ".." "RepositoryProjectGraph.ps1"
        $repoRoot = Join-Path $TestDrive "repo"
        $recordsPath = Join-Path $TestDrive "graph.records"
        $graphPath = Join-Path $TestDrive "graph.json"
        $testProject = Join-Path $repoRoot "sdk/example/A/tests/A.Tests.csproj"
        $projectA = Join-Path $repoRoot "sdk/example/A/src/A.csproj"
        $projectB = Join-Path $repoRoot "sdk/example/B/src/B.csproj"
        $inputA = Join-Path $repoRoot "sdk/shared/A.cs"
        $packageA = Split-Path (Split-Path $projectA -Parent) -Parent
        $packageB = Split-Path (Split-Path $projectB -Parent) -Parent
        $testPackage = Split-Path (Split-Path $testProject -Parent) -Parent

        New-Item -ItemType Directory -Path $repoRoot -Force | Out-Null
        & git -C $repoRoot init --quiet
        & git -C $repoRoot -c user.name=Test -c user.email=test@example.com commit --quiet --allow-empty -m fixture
        $sourceCommit = (& git -C $repoRoot rev-parse HEAD).Trim()
        @(
            "Node|$projectA|net8.0|Azure.A|$packageA|true||true"
            "Node|$projectA|net9.0|Azure.A|$packageA|true||true"
            "CheckoutRoot|$projectA|net8.0|/sdk/example/*"
            "CheckoutRoot|$projectA|net9.0|/sdk/example/*"
            "PackageReference|$projectA|net9.0|Azure.B|||"
            "Input|$projectA|net8.0|$inputA"
            "CheckoutRoot|$projectA|net8.0|/sdk/shared/*"
            "Node|$projectB|net8.0|Azure.B|$packageB|true||true"
            "CheckoutRoot|$projectB|net8.0|/sdk/example/*"
            "Node|$testProject|net8.0|Azure.A.Tests|$testPackage|true||"
            "Node|$testProject|net9.0|Azure.A.Tests|$testPackage|true||"
            "CheckoutRoot|$testProject|net8.0|/sdk/example/*"
            "CheckoutRoot|$testProject|net9.0|/sdk/example/*"
            "ProjectReference|$testProject|net8.0|$projectA|||||net8.0"
            "ProjectReference|$testProject|net9.0|$projectA|||||net9.0"
            "PackageReference|$testProject|net9.0|Azure.External|||"
            "DeclaredProject|$projectA"
            "DeclaredProject|$projectB"
            "DeclaredProject|$testProject"
            "Root|$testProject"
        ) | Set-Content $recordsPath

        & $scriptPath -Operation Build -GraphPath $graphPath -RecordsPath $recordsPath -RepoRoot $repoRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
    }

    It "builds a versioned artifact that unions evaluated target frameworks" {
        $graph = Get-Content -Raw $graphPath | ConvertFrom-Json -Depth 100
        $graph.schemaVersion | Should -Be 6
        $graph.sourceCommit | Should -Be $sourceCommit
        $graph.diagnostics.isComplete | Should -BeTrue
        $graph.diagnostics.configurationCount | Should -Be 5
        $graph.diagnostics.configurationGraph.isExact | Should -BeTrue
        $node = $graph.nodes | Where-Object packageId -eq "Azure.A" | Select-Object -First 1
        $node.targetFrameworks | Should -Be @("net8.0", "net9.0")
        $node.PSObject.Properties.Name | Should -Be @(
            "projectPath", "packageId", "packageRoot", "isClientLibrary", "isGeneratorLibrary", "isShippingLibrary", "targetFrameworks")
        $graph.PSObject.Properties.Name | Should -Not -Contain "edges"
        $edge = $graph.configurationEdges | Where-Object {
            $_.kind -eq "PackageReference" -and $_.fromProject -like "*/A/src/A.csproj"
        }
        $edge.to | Should -Be "Azure.B"
        $edge.fromTargetFramework | Should -Be "net9.0"
        $edge.PSObject.Properties.Name | Should -Be @("kind", "fromProject", "fromTargetFramework", "to")
        $configurationEdge = $graph.configurationEdges | Where-Object {
            $_.kind -eq "ProjectReference" -and $_.fromProject -like "*/A.Tests.csproj" -and $_.fromTargetFramework -eq "net9.0"
        }
        $configurationEdge.toTargetFramework | Should -Be "net9.0"
        $graph.diagnostics.unmappedRepositoryPackageReferences | Should -Contain "Azure.External"
        $graph.diagnostics.hasUnresolvedExternalPackageClosure | Should -BeTrue
        $graph.inputs[0].path | Should -Be "sdk/shared/A.cs"
        @($graph.checkoutRoots.'configuration:sdk/example/A/src/A.csproj|net8.0') |
            Should -Be @('/sdk/example/*', '/sdk/shared/*')
        $graph.diagnostics.checkoutRoots.isComplete | Should -BeTrue
    }

    It "adds resolved external package closure edges and diagnostics" {
        $packageRecordsPath = Join-Path $TestDrive "package-closure.records"
        $closureGraphPath = Join-Path $TestDrive "closure.json"
        @(
            "TransitivePackageReference|$testProject|net9.0|Azure.B"
            "PackageClosureSummary|1|1|1|0|0.125|nuget-restore-graph|false|true|1|1|2"
        ) | Set-Content $packageRecordsPath

        & $scriptPath -Operation Build -GraphPath $closureGraphPath -RecordsPath $recordsPath -PackageRecordsPath $packageRecordsPath -RepoRoot $repoRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
        $graph = Get-Content -Raw $closureGraphPath | ConvertFrom-Json -Depth 100
        $edge = $graph.configurationEdges | Where-Object {
            $_.kind -eq "PackageReference" -and $_.fromProject -like "*/A.Tests.csproj" -and $_.to -eq "Azure.B"
        }
        $edge.to | Should -Be "Azure.B"
        $edge.fromTargetFramework | Should -Be "net9.0"
        $graph.diagnostics.isComplete | Should -BeTrue
        $graph.diagnostics.packageClosure.resolutionMode | Should -Be "nuget-restore-graph"
        $graph.diagnostics.packageClosure.restoreEquivalent | Should -BeFalse
        $graph.diagnostics.packageClosure.transitiveDependencyAssetFiltersApplied | Should -BeTrue
        $graph.diagnostics.hasUnresolvedExternalPackageClosure | Should -BeFalse
    }

    It "fails closed when the package closure summary contradicts its detail records" {
        $packageRecordsPath = Join-Path $TestDrive "inconsistent-package-closure.records"
        $closureGraphPath = Join-Path $TestDrive "inconsistent-closure.json"
        "PackageClosureSummary|1|0|0|1|0.125|nuget-restore-graph|false|true|1|1|0" | Set-Content $packageRecordsPath

        & $scriptPath -Operation Build -GraphPath $closureGraphPath -RecordsPath $recordsPath -PackageRecordsPath $packageRecordsPath -RepoRoot $repoRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
        $graph = Get-Content -Raw $closureGraphPath | ConvertFrom-Json -Depth 100
        $graph.diagnostics.packageClosureSummaryConsistent | Should -BeFalse
        $graph.diagnostics.isComplete | Should -BeFalse
        $graph.diagnostics.hasUnresolvedExternalPackageClosure | Should -BeTrue
    }

    It "uses package identity rather than assembly name in the reverse query" {
        $outputPath = Join-Path $TestDrive "reverse.txt"
        & $scriptPath -Operation Reverse -GraphPath $graphPath -Dependencies "Azure.B" -OutputPath $outputPath
        if ($LASTEXITCODE) { throw "Reverse query failed with exit code $LASTEXITCODE" }
        Get-Content $outputPath | Should -Be '$(RepoRoot)sdk/example/A/tests/A.Tests.csproj'
    }

    It "unions root configurations without combining dependency paths from different TFMs" {
        $configurationRecordsPath = Join-Path $TestDrive "configuration.records"
        $configurationPackageRecordsPath = Join-Path $TestDrive "configuration.packages.records"
        $configurationGraphPath = Join-Path $TestDrive "configuration.json"
        $configurationOutputPath = Join-Path $TestDrive "configuration-output.txt"
        @(
            "Node|$projectA|net8.0|Azure.A|$packageA|true||true"
            "Node|$projectA|net9.0|Azure.A|$packageA|true||true"
            "PackageReference|$projectA|net9.0|Azure.B||||1.0.0"
            "Node|$projectB|net8.0|Azure.B|$packageB|true||true"
            "Node|$testProject|net8.0|Azure.A.Tests|$testPackage|true||"
            "Node|$testProject|net9.0|Azure.A.Tests|$testPackage|true||"
            "ProjectReference|$testProject|net8.0|$projectA|||||net8.0"
            "DeclaredProject|$projectA"
            "DeclaredProject|$projectB"
            "DeclaredProject|$testProject"
            "Root|$testProject"
        ) | Set-Content $configurationRecordsPath
        "PackageClosureSummary|1|1|0|0|0.001|nuget-restore-graph|false|true|1|1|1" |
            Set-Content $configurationPackageRecordsPath

        & $scriptPath -Operation Build -GraphPath $configurationGraphPath -RecordsPath $configurationRecordsPath -PackageRecordsPath $configurationPackageRecordsPath -RepoRoot $repoRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
        & $scriptPath -Operation Reverse -GraphPath $configurationGraphPath -Dependencies "Azure.B" -OutputPath $configurationOutputPath
        if ($LASTEXITCODE) { throw "Reverse query failed with exit code $LASTEXITCODE" }
        @(Get-Content $configurationOutputPath).Count | Should -Be 0

        & $scriptPath -Operation Reverse -GraphPath $configurationGraphPath -Dependencies "Azure.A" -OutputPath $configurationOutputPath
        if ($LASTEXITCODE) { throw "Reverse query failed with exit code $LASTEXITCODE" }
        Get-Content $configurationOutputPath | Should -Be '$(RepoRoot)sdk/example/A/tests/A.Tests.csproj'
    }

    It "returns the transitive project and optional input closure in the forward query" {
        $outputPath = Join-Path $TestDrive "forward.txt"
        & $scriptPath -Operation Forward -GraphPath $graphPath -RootProjects "sdk/example/A/tests/A.Tests.csproj" -ForwardOutputKind All -OutputPath $outputPath
        if ($LASTEXITCODE) { throw "Forward query failed with exit code $LASTEXITCODE" }
        $result = Get-Content $outputPath
        $result | Should -Contain "Project|sdk/example/A/src/A.csproj"
        $result | Should -Contain "Project|sdk/example/B/src/B.csproj"
        $result | Should -Contain "Input|sdk/shared/A.cs"
    }

    It "marks missing repository project references in diagnostics" {
        $missingRecordsPath = Join-Path $TestDrive "missing.records"
        $missingGraphPath = Join-Path $TestDrive "missing.json"
        @(
            "Node|$testProject|net8.0|Azure.A.Tests|$testPackage|true||"
            "ProjectReference|$testProject|net8.0|$(Join-Path $repoRoot 'sdk/example/Missing/src/Missing.csproj')|"
            "Root|$testProject"
        ) | Set-Content $missingRecordsPath

        & $scriptPath -Operation Build -GraphPath $missingGraphPath -RecordsPath $missingRecordsPath -RepoRoot $repoRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
        $graph = Get-Content -Raw $missingGraphPath | ConvertFrom-Json -Depth 100
        $graph.diagnostics.isComplete | Should -BeFalse
        $graph.diagnostics.missingProjectReferences.Count | Should -Be 1
    }

    It "fails closed for unknown package and project query inputs" {
        $outputPath = Join-Path $TestDrive "unknown.txt"
        { & $scriptPath -Operation Reverse -GraphPath $graphPath -Dependencies "Azure.Unknown" -OutputPath $outputPath } |
            Should -Throw "*no shipping project*Azure.Unknown*"
        { & $scriptPath -Operation Forward -GraphPath $graphPath -RootProjects "sdk/example/Unknown.csproj" -OutputPath $outputPath } |
            Should -Throw "*does not contain*Unknown.csproj*"
    }

    It "rejects unsupported graph schemas" {
        $unsupportedPath = Join-Path $TestDrive "unsupported.json"
        $graph = Get-Content -Raw $graphPath | ConvertFrom-Json -Depth 100
        $graph.schemaVersion = 5
        $graph | ConvertTo-Json -Depth 100 | Set-Content $unsupportedPath
        $outputPath = Join-Path $TestDrive "unsupported.txt"
        { & $scriptPath -Operation Reverse -GraphPath $unsupportedPath -Dependencies "Azure.A" -OutputPath $outputPath } |
            Should -Throw "*schema version '5'*"
    }

    It "diagnoses unevaluated declarations and cross-TFM identity conflicts" {
        $conflictRecordsPath = Join-Path $TestDrive "conflict.records"
        $conflictGraphPath = Join-Path $TestDrive "conflict.json"
        @(
            "Node|$projectA|net8.0|Azure.A|$packageA|true||true"
            "Node|$projectA|net9.0|Azure.Renamed|$packageA|true||true"
            "DeclaredProject|$projectA"
            "DeclaredProject|$projectB"
        ) | Set-Content $conflictRecordsPath

        & $scriptPath -Operation Build -GraphPath $conflictGraphPath -RecordsPath $conflictRecordsPath -RepoRoot $repoRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
        $graph = Get-Content -Raw $conflictGraphPath | ConvertFrom-Json -Depth 100
        $graph.diagnostics.isComplete | Should -BeFalse
        $graph.diagnostics.missingDeclaredProjects | Should -Be @("sdk/example/B/src/B.csproj")
        $graph.diagnostics.nodeMetadataConflicts[0].fields | Should -Contain "packageId"
    }

    It "uses a NuGet restore graph with local package and P2P contributions" {
        $fixtureRoot = Join-Path $TestDrive "nuget-closure-fixture"
        $feedPath = Join-Path $fixtureRoot "feed"
        $packagesPath = Join-Path $fixtureRoot "packages"
        $restorePath = Join-Path $fixtureRoot "restore"
        $closureRecordsPath = Join-Path $fixtureRoot "closure.records"
        $closureGraphPath = Join-Path $fixtureRoot "closure.json"
        $inputRecordsPath = Join-Path $fixtureRoot "input.records"
        $nugetConfigPath = Join-Path $fixtureRoot "NuGet.Config"
        $driverPath = Join-Path $fixtureRoot "driver.proj"
        New-Item -ItemType Directory -Path $feedPath -Force | Out-Null

        function New-LocalPackage([string] $id, [string] $version, [string] $dependencies) {
            $packageDirectory = Join-Path $fixtureRoot "package-$id-$version"
            New-Item -ItemType Directory -Path (Join-Path $packageDirectory "lib/net8.0") -Force | Out-Null
            "compile asset" | Set-Content (Join-Path $packageDirectory "lib/net8.0/$id.dll")
            @"
<?xml version="1.0"?>
<package>
  <metadata>
    <id>$id</id>
    <version>$version</version>
    <authors>test</authors>
    <description>Repository project graph test package.</description>
    $dependencies
  </metadata>
</package>
"@ | Set-Content (Join-Path $packageDirectory "$id.nuspec")
            [System.IO.Compression.ZipFile]::CreateFromDirectory(
                $packageDirectory,
                (Join-Path $feedPath "$id.$version.nupkg"))
        }

        New-LocalPackage "Azure.B" "1.0.0" ""
        New-LocalPackage "Azure.D" "1.0.0" ""
        New-LocalPackage "Shared.Dependency" "1.0.0" ""
        New-LocalPackage "Shared.Dependency" "2.0.0" '<dependencies><group targetFramework="net8.0"><dependency id="Azure.B" version="[1.0.0]" /></group></dependencies>'
        New-LocalPackage "Other.Dependency" "1.0.0" ""
        New-LocalPackage "Other.Dependency" "2.0.0" '<dependencies><group targetFramework="net8.0"><dependency id="Azure.D" version="[1.0.0]" /></group></dependencies>'
        New-LocalPackage "Local.Contributor" "1.0.0" '<dependencies><group targetFramework="net8.0"><dependency id="Other.Dependency" version="[2.0.0, 3.0.0)" /></group></dependencies>'
        New-LocalPackage "External.A" "1.0.0" '<dependencies><group targetFramework="net8.0"><dependency id="Shared.Dependency" version="[1.0.0, 3.0.0)" /></group></dependencies>'
        New-LocalPackage "External.C" "1.0.0" '<dependencies><group targetFramework="net8.0"><dependency id="Other.Dependency" version="[1.0.0, 3.0.0)" /></group></dependencies>'
        @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="local" value="$feedPath" />
  </packageSources>
  <config>
    <add key="globalPackagesFolder" value="$packagesPath" />
  </config>
</configuration>
"@ | Set-Content $nugetConfigPath

        $localProjectB = Join-Path $fixtureRoot "sdk/example/B/src/B.csproj"
        $localProjectD = Join-Path $fixtureRoot "sdk/example/D/src/D.csproj"
        $localContributor = Join-Path $fixtureRoot "sdk/example/Contributor/src/Local.Contributor.csproj"
        $childProject = Join-Path $fixtureRoot "sdk/example/Child/src/Child.csproj"
        $testProject = Join-Path $fixtureRoot "sdk/example/A/tests/A.Tests.csproj"
        $nonAssemblyTestProject = Join-Path $fixtureRoot "sdk/example/Excluded/tests/Excluded.Tests.csproj"
        @(
            "Node|$testProject|net8.0|A.Tests|$(Split-Path (Split-Path $testProject -Parent) -Parent)|true|false|false|false"
            "Node|$testProject|net8.0|A.Tests|$(Split-Path (Split-Path $testProject -Parent) -Parent)|true|false|false|false"
            "Node|$nonAssemblyTestProject|net8.0|Excluded.Tests|$(Split-Path (Split-Path $nonAssemblyTestProject -Parent) -Parent)|true|false|false|false"
            "Node|$childProject|net8.0|Child|$(Split-Path (Split-Path $childProject -Parent) -Parent)|true|false|false|false"
            "Node|$localProjectB|net8.0|Azure.B|$(Split-Path (Split-Path $localProjectB -Parent) -Parent)|true|false|true|false"
            "Node|$localProjectD|net8.0|Azure.D|$(Split-Path (Split-Path $localProjectD -Parent) -Parent)|true|false|true|false"
            "Node|$localContributor|net8.0|Local.Contributor|$(Split-Path (Split-Path $localContributor -Parent) -Parent)|true|false|true|false"
            "PackageReference|$testProject|net8.0|External.A||all||1.0.0"
            "PackageReference|$testProject|net8.0|External.C||all||1.0.0"
            "PackageReference|$testProject|net8.0|Local.Contributor||all||1.0.0"
            "ProjectReference|$testProject|net8.0|$childProject|||||net8.0"
            "PackageReference|$nonAssemblyTestProject|net8.0|External.A||all||1.0.0"
            "ProjectReference|$nonAssemblyTestProject|net8.0|$childProject|false||||net8.0"
            "PackageReference|$childProject|net8.0|Shared.Dependency||all||2.0.0"
        ) | Set-Content $inputRecordsPath

        $repositoryRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
        $taskProject = Join-Path $repositoryRoot "eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj"
        $taskAssembly = Join-Path $repositoryRoot "artifacts/bin/RepositoryProjectGraph/Debug/net10.0/RepositoryProjectGraph.dll"
        @"
<Project>
  <UsingTask TaskName="Azure.Sdk.Tools.RepositoryProjectGraph.ResolveExternalPackageClosureWithNuGetTask"
             AssemblyFile="$taskAssembly" />
  <Target Name="Resolve">
    <ResolveExternalPackageClosureWithNuGetTask RecordsPath="$inputRecordsPath"
                                                OutputPath="$closureRecordsPath"
                                                NuGetConfigPath="$nugetConfigPath"
                                                RestoreOutputPath="$restorePath"
                                                DegreeOfParallelism="2" />
  </Target>
</Project>
"@ | Set-Content $driverPath

        & dotnet build $taskProject --no-restore -v:minimal
        $LASTEXITCODE | Should -Be 0
        & dotnet msbuild -nologo -v:minimal -t:Resolve $driverPath
        $LASTEXITCODE | Should -Be 0

        $closureRecords = Get-Content $closureRecordsPath
        $closureRecords | Should -Contain "TransitivePackageReference|$testProject|net8.0|Azure.B"
        $closureRecords | Should -Contain "TransitivePackageReference|$testProject|net8.0|Azure.D"
        $closureRecords | Should -Contain "TransitivePackageReference|$childProject|net8.0|Azure.B"
        $closureRecords | Should -Not -Contain "TransitivePackageReference|$nonAssemblyTestProject|net8.0|Azure.B"
        $summary = ($closureRecords | Where-Object { $_ -like "PackageClosureSummary|*" }).Split('|')
        $summary[1..4] | Should -Be @("5", "5", "3", "0")
        $summary[6..8] | Should -Be @("nuget-restore-graph", "False", "True")
        $summary[9..10] | Should -Be @("3", "3")
        [int]$summary[11] | Should -BeGreaterThan 0

        & $scriptPath -Operation Build -GraphPath $closureGraphPath -RecordsPath $inputRecordsPath -PackageRecordsPath $closureRecordsPath -RepoRoot $fixtureRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }
        $closureGraph = Get-Content -Raw $closureGraphPath | ConvertFrom-Json -Depth 100
        $closureGraph.diagnostics.packageClosure.projectContextCount | Should -Be 3
        $closureGraph.diagnostics.packageClosure.restoreRequestCount | Should -Be 3
        $closureGraph.diagnostics.packageClosure.selectedPackageCount | Should -BeGreaterThan 0
        $closureGraph.diagnostics.configurationGraph.isExact | Should -BeTrue
    }

    It "collects TFM-specific records with the strongly typed ProjectGraph task" {
        $fixtureRoot = Join-Path $TestDrive "task-fixture"
        $fixtureA = Join-Path $fixtureRoot "sdk/example/A/tests/A.Tests.csproj"
        $fixtureB = Join-Path $fixtureRoot "sdk/example/B/src/B.csproj"
        $hintAssembly = Join-Path $fixtureRoot "sdk/shared/lib/Shared.dll"
        $analyzerAssembly = Join-Path $fixtureRoot "sdk/shared/analyzers/Shared.Analyzer.dll"
        $driverPath = Join-Path $fixtureRoot "driver.proj"
        $taskRecordsPath = Join-Path $fixtureRoot "task.records"
        $taskGraphPath = Join-Path $fixtureRoot "task.json"
        New-Item -ItemType Directory -Path (Split-Path $fixtureA -Parent), (Split-Path $fixtureB -Parent), `
            (Split-Path $hintAssembly -Parent), (Split-Path $analyzerAssembly -Parent) -Force | Out-Null
        Set-Content $hintAssembly "fixture"
        Set-Content $analyzerAssembly "fixture"

        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net8.0;net9.0</TargetFrameworks>
    <PackageId>Azure.A.Tests</PackageId>
    <IsClientLibrary>true</IsClientLibrary>
    <IsTestProject>true</IsTestProject>
    <WarningsAsErrors>
      NU1605,
      NU1608
    </WarningsAsErrors>
    <NoWarn>
      NU1901;
      NU1902
    </NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <PackageVersion Include="Azure.B" Version="1.2.3" />
    <PackageVersion Include="Azure.C" Version="2.0.0" />
    <PackageReference Include="Azure.B" Condition="'$(TargetFramework)' == 'net8.0'" />
    <PackageReference Include="Azure.C" />
    <ProjectReference Include="../../B/src/B.csproj" ReferenceOutputAssembly="false" Condition="'$(TargetFramework)' == 'net9.0'" />
    <Reference Include="Shared" HintPath="../../../shared/lib/Shared.dll" />
    <Analyzer Include="../../../shared/analyzers/Shared.Analyzer.dll" />
  </ItemGroup>
</Project>
'@ | Set-Content $fixtureA
        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net8.0;netstandard2.0</TargetFrameworks>
    <PackageId>Azure.B</PackageId>
    <IsClientLibrary>true</IsClientLibrary>
    <IsShippingLibrary>true</IsShippingLibrary>
  </PropertyGroup>
</Project>
'@ | Set-Content $fixtureB

        $repositoryRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
        $taskProject = Join-Path $repositoryRoot "eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj"
        $taskAssembly = Join-Path $repositoryRoot "artifacts/bin/RepositoryProjectGraph/Debug/net10.0/RepositoryProjectGraph.dll"
        @"
<Project>
  <UsingTask TaskName="Azure.Sdk.Tools.RepositoryProjectGraph.RepositoryProjectGraphTask"
             AssemblyFile="$taskAssembly" />
  <Target Name="BuildGraph">
    <ItemGroup>
      <GraphProject Include="$fixtureA;$fixtureB" />
      <GraphRoot Include="$fixtureA" />
    </ItemGroup>
    <RepositoryProjectGraphTask Projects="@(GraphProject)"
                                RootProjects="@(GraphRoot)"
                                RecordsPath="$taskRecordsPath"
                                RepositoryRoot="$fixtureRoot"
                                IncludeInputs="true"
                                DegreeOfParallelism="2" />
  </Target>
</Project>
"@ | Set-Content $driverPath

        & dotnet build $taskProject --no-restore -v:minimal
        $LASTEXITCODE | Should -Be 0
        & dotnet msbuild -nologo -v:minimal -t:BuildGraph $driverPath
        $LASTEXITCODE | Should -Be 0
        & $scriptPath -Operation Build -GraphPath $taskGraphPath -RecordsPath $taskRecordsPath -RepoRoot $fixtureRoot
        if ($LASTEXITCODE) { throw "Graph build failed with exit code $LASTEXITCODE" }

        $taskGraph = Get-Content -Raw $taskGraphPath | ConvertFrom-Json -Depth 100
        $taskGraph.diagnostics.isComplete | Should -BeTrue
        $taskGraph.diagnostics.configurationGraph.isExact | Should -BeTrue
        $taskGraph.diagnostics.generation.configuration | Should -Be "Debug"
        $taskGraph.diagnostics.generation.includesInputs | Should -BeTrue
        Get-Content $taskRecordsPath | Should -Contain "GraphGeneration|Debug|True"
        $taskNodeRecord = Get-Content $taskRecordsPath | Where-Object { $_ -like "Node|$fixtureA|net8.0|*" }
        $taskNodeFields = $taskNodeRecord.Split('|')
        $taskNodeFields[13].Split(';') | Should -Contain "NU1605"
        $taskNodeFields[13].Split(';') | Should -Contain "NU1608"
        $taskNodeFields[14].Split(';') | Should -Contain "NU1901"
        $taskNodeFields[14].Split(';') | Should -Contain "NU1902"
        ($taskGraph.nodes | Where-Object packageId -eq "Azure.A.Tests").targetFrameworks | Should -Be @("net8.0", "net9.0")
        $taskPackageEdge = @($taskGraph.configurationEdges | Where-Object {
            $_.kind -eq "PackageReference" -and $_.to -eq "Azure.B"
        })
        $taskPackageEdge.fromTargetFramework | Should -Be @("net8.0")
        @($taskGraph.configurationEdges | Where-Object { $_.to -eq "Azure.C" }) | Should -BeNullOrEmpty
        $taskGraph.diagnostics.externalPackageReferences | Should -Contain "Azure.C"
        $taskProjectEdges = @($taskGraph.configurationEdges | Where-Object {
            $_.kind -eq "ProjectReference" -and $_.fromProject -like "*/A.Tests.csproj"
        })
        @($taskProjectEdges.fromTargetFramework | Select-Object -Unique) | Should -Be @("net9.0")
        @($taskProjectEdges.toTargetFramework | Sort-Object) | Should -Be @("net8.0", "netstandard2.0")
        Get-Content $taskRecordsPath | Should -Contain "ProjectReference|$fixtureA|net9.0|$fixtureB|false||||net8.0"
        $hintInput = $taskGraph.inputs | Where-Object path -eq "sdk/shared/lib/Shared.dll"
        $hintInput.targetFrameworks | Should -Be @("net8.0", "net9.0")
        $analyzerInput = $taskGraph.inputs | Where-Object {
            $_.path -eq "sdk/shared/analyzers/Shared.Analyzer.dll"
        }
        $analyzerInput.path | Should -Be "sdk/shared/analyzers/Shared.Analyzer.dll"
        $analyzerInput.targetFrameworks | Should -Be @("net8.0", "net9.0")
        @($taskGraph.checkoutRoots.'configuration:sdk/example/A/tests/A.Tests.csproj|net8.0') |
            Should -Contain '/sdk/shared/*'
        Get-Content $taskRecordsPath | Should -Contain "CheckoutRoot|$fixtureA|net8.0|/sdk/shared/*"
    }

    It "evaluates Debug even when the invoking build uses Release" {
        $fixtureRoot = Join-Path $TestDrive "debug-configuration-fixture"
        $project = Join-Path $fixtureRoot "Configuration.csproj"
        $driverPath = Join-Path $fixtureRoot "driver.proj"
        $recordsPath = Join-Path $fixtureRoot "task.records"
        New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Debug.Dependency" Version="1.0.0" Condition="'$(Configuration)' == 'Debug'" />
    <PackageReference Include="Release.Dependency" Version="1.0.0" Condition="'$(Configuration)' == 'Release'" />
  </ItemGroup>
</Project>
'@ | Set-Content $project

        $repositoryRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
        $taskProject = Join-Path $repositoryRoot "eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj"
        $taskAssembly = Join-Path $repositoryRoot "artifacts/bin/RepositoryProjectGraph/Debug/net10.0/RepositoryProjectGraph.dll"
        @"
<Project>
  <UsingTask TaskName="Azure.Sdk.Tools.RepositoryProjectGraph.RepositoryProjectGraphTask"
             AssemblyFile="$taskAssembly" />
  <Target Name="BuildGraph">
    <RepositoryProjectGraphTask Projects="$project"
                                RecordsPath="$recordsPath"
                                RepositoryRoot="$fixtureRoot" />
  </Target>
</Project>
"@ | Set-Content $driverPath

        & dotnet build $taskProject --no-restore -v:minimal
        $LASTEXITCODE | Should -Be 0
        & dotnet msbuild -nologo -v:minimal -t:BuildGraph $driverPath /p:Configuration=Release
        $LASTEXITCODE | Should -Be 0
        $records = Get-Content $recordsPath
        $records | Should -Contain "GraphGeneration|Debug|False"
        $records | Should -Contain "PackageReference|$project|net8.0|Debug.Dependency||||1.0.0"
        @($records | Where-Object { $_ -like "PackageReference|$project|net8.0|Release.Dependency|*" }) |
            Should -BeNullOrEmpty
    }

    It "fails closed when references create dependency-only global-property configurations" {
        $fixtureRoot = Join-Path $TestDrive "dependency-only-fixture"
        $projectA = Join-Path $fixtureRoot "A/A.csproj"
        $projectB = Join-Path $fixtureRoot "B/B.csproj"
        $driverPath = Join-Path $fixtureRoot "driver.proj"
        $recordsPath = Join-Path $fixtureRoot "task.records"
        New-Item -ItemType Directory -Path (Split-Path $projectA -Parent), (Split-Path $projectB -Parent) -Force | Out-Null

        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="../B/B.csproj" AdditionalProperties="GraphFlavor=Referenced" />
  </ItemGroup>
</Project>
'@ | Set-Content $projectA
        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
</Project>
'@ | Set-Content $projectB

        $repositoryRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
        $taskProject = Join-Path $repositoryRoot "eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj"
        $taskAssembly = Join-Path $repositoryRoot "artifacts/bin/RepositoryProjectGraph/Debug/net10.0/RepositoryProjectGraph.dll"
        @"
<Project>
  <UsingTask TaskName="Azure.Sdk.Tools.RepositoryProjectGraph.RepositoryProjectGraphTask"
             AssemblyFile="$taskAssembly" />
  <Target Name="BuildGraph">
    <ItemGroup>
      <GraphProject Include="$projectA;$projectB" />
    </ItemGroup>
    <RepositoryProjectGraphTask Projects="@(GraphProject)"
                                RecordsPath="$recordsPath"
                                RepositoryRoot="$fixtureRoot" />
  </Target>
</Project>
"@ | Set-Content $driverPath

        & dotnet build $taskProject --no-restore -v:minimal
        $LASTEXITCODE | Should -Be 0
        $output = & dotnet msbuild -nologo -v:minimal -t:BuildGraph $driverPath 2>&1
        $LASTEXITCODE | Should -Not -Be 0
        $output | Out-String | Should -Match "dependency-only configurations that schema 6 cannot represent"
        Test-Path $recordsPath | Should -BeFalse
    }
}

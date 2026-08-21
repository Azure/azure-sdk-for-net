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
        $inputA = Join-Path $repoRoot "sdk/example/A/src/A.cs"
        $packageA = Split-Path (Split-Path $projectA -Parent) -Parent
        $packageB = Split-Path (Split-Path $projectB -Parent) -Parent
        $testPackage = Split-Path (Split-Path $testProject -Parent) -Parent

        New-Item -ItemType Directory -Path $repoRoot -Force | Out-Null
        @(
            "Node|$projectA|net8.0|Azure.A|Azure.A|$packageA|true|||true"
            "Node|$projectA|net9.0|Azure.A|Azure.A|$packageA|true|||true"
            "PackageReference|$projectA|net9.0|Azure.B|||"
            "Input|$projectA|net8.0|Compile|$inputA"
            "Node|$projectB|net8.0|Azure.B|Different.Assembly|$packageB|true|||true"
            "Node|$testProject|net8.0|Azure.A.Tests|Azure.A.Tests|$testPackage|true||true|"
            "Node|$testProject|net9.0|Azure.A.Tests|Azure.A.Tests|$testPackage|true||true|"
            "ProjectReference|$testProject|net8.0|$projectA||"
            "ProjectReference|$testProject|net9.0|$projectA||"
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
        $graph.schemaVersion | Should -Be 1
        $graph.diagnostics.isComplete | Should -BeTrue
        $node = $graph.nodes | Where-Object packageId -eq "Azure.A" | Select-Object -First 1
        $node.targetFrameworks | Should -Be @("net8.0", "net9.0")
        $edge = $graph.edges | Where-Object { $_.kind -eq "PackageReference" -and $_.fromProject -like "*/A/src/A.csproj" }
        $edge.to | Should -Be "Azure.B"
        $edge.targetFrameworks | Should -Be @("net9.0")
        $graph.diagnostics.unmappedRepositoryPackageReferences | Should -Contain "Azure.External"
        $graph.diagnostics.hasUnresolvedExternalPackageClosure | Should -BeTrue
    }

    It "uses package identity rather than assembly name in the reverse query" {
        $outputPath = Join-Path $TestDrive "reverse.txt"
        & $scriptPath -Operation Reverse -GraphPath $graphPath -Dependencies "Azure.B" -OutputPath $outputPath
        if ($LASTEXITCODE) { throw "Reverse query failed with exit code $LASTEXITCODE" }
        Get-Content $outputPath | Should -Be '$(RepoRoot)sdk/example/A/tests/A.Tests.csproj'
    }

    It "returns the transitive project and optional input closure in the forward query" {
        $outputPath = Join-Path $TestDrive "forward.txt"
        & $scriptPath -Operation Forward -GraphPath $graphPath -RootProjects "sdk/example/A/tests/A.Tests.csproj" -ForwardOutputKind All -OutputPath $outputPath
        if ($LASTEXITCODE) { throw "Forward query failed with exit code $LASTEXITCODE" }
        $result = Get-Content $outputPath
        $result | Should -Contain "Project|sdk/example/A/src/A.csproj"
        $result | Should -Contain "Project|sdk/example/B/src/B.csproj"
        $result | Should -Contain "Input|sdk/example/A/src/A.cs"
    }

    It "validates known resolved assembly references against source reachability" {
        $oraclePath = Join-Path $TestDrive "oracle.txt"
        $resultPath = Join-Path $TestDrive "oracle-result.json"
        "$testProject|net9.0|Different.Assembly" | Set-Content $oraclePath
        & $scriptPath -Operation ValidateOracle -GraphPath $graphPath -OraclePath $oraclePath -OutputPath $resultPath
        if ($LASTEXITCODE) { throw "Oracle validation failed with exit code $LASTEXITCODE" }
        $result = Get-Content -Raw $resultPath | ConvertFrom-Json
        $result.checkedResolvedRepositoryReferences | Should -Be 1
        $result.missingCount | Should -Be 0
    }

    It "marks missing repository project references in diagnostics" {
        $missingRecordsPath = Join-Path $TestDrive "missing.records"
        $missingGraphPath = Join-Path $TestDrive "missing.json"
        @(
            "Node|$testProject|net8.0|Azure.A.Tests|Azure.A.Tests|$testPackage|true||true|"
            "ProjectReference|$testProject|net8.0|$(Join-Path $repoRoot 'sdk/example/Missing/src/Missing.csproj')||"
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
        $graph.schemaVersion = 2
        $graph | ConvertTo-Json -Depth 100 | Set-Content $unsupportedPath
        $outputPath = Join-Path $TestDrive "unsupported.txt"
        { & $scriptPath -Operation Reverse -GraphPath $unsupportedPath -Dependencies "Azure.A" -OutputPath $outputPath } |
            Should -Throw "*schema version '2'*"
    }

    It "diagnoses unevaluated declarations and cross-TFM identity conflicts" {
        $conflictRecordsPath = Join-Path $TestDrive "conflict.records"
        $conflictGraphPath = Join-Path $TestDrive "conflict.json"
        @(
            "Node|$projectA|net8.0|Azure.A|Azure.A|$packageA|true|||true"
            "Node|$projectA|net9.0|Azure.Renamed|Azure.A|$packageA|true|||true"
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

    It "collects TFM-specific records with the strongly typed ProjectGraph task" {
        $fixtureRoot = Join-Path $TestDrive "task-fixture"
        $fixtureA = Join-Path $fixtureRoot "sdk/example/A/tests/A.Tests.csproj"
        $fixtureB = Join-Path $fixtureRoot "sdk/example/B/src/B.csproj"
        $driverPath = Join-Path $fixtureRoot "driver.proj"
        $taskRecordsPath = Join-Path $fixtureRoot "task.records"
        $taskGraphPath = Join-Path $fixtureRoot "task.json"
        New-Item -ItemType Directory -Path (Split-Path $fixtureA -Parent), (Split-Path $fixtureB -Parent) -Force | Out-Null

        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net8.0;net9.0</TargetFrameworks>
    <PackageId>Azure.A.Tests</PackageId>
    <IsClientLibrary>true</IsClientLibrary>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Azure.B" Condition="'$(TargetFramework)' == 'net8.0'" />
    <ProjectReference Include="../../B/src/B.csproj" Condition="'$(TargetFramework)' == 'net9.0'" />
  </ItemGroup>
</Project>
'@ | Set-Content $fixtureA
        @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net8.0;net9.0</TargetFrameworks>
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
        ($taskGraph.nodes | Where-Object packageId -eq "Azure.A.Tests").targetFrameworks | Should -Be @("net8.0", "net9.0")
        ($taskGraph.edges | Where-Object { $_.kind -eq "PackageReference" -and $_.fromProject -like "*/A.Tests.csproj" }).targetFrameworks | Should -Be @("net8.0")
        ($taskGraph.edges | Where-Object { $_.kind -eq "ProjectReference" -and $_.fromProject -like "*/A.Tests.csproj" }).targetFrameworks | Should -Be @("net9.0")
    }
}

#Requires -Version 7.0

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

Describe 'ProjectGraph sparse checkout projection' -Tag 'UnitTest' {
    BeforeAll {
        $script:RepositoryRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')
        $script:TaskProject = Join-Path $script:RepositoryRoot 'eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj'
        $script:ResolvePathsPath = Join-Path $PSScriptRoot '..' 'Resolve-SparseCheckoutPaths.ps1'
        $script:NewPipelineInputsPath = Join-Path $script:RepositoryRoot `
            'eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/New-PipelineValidationInputs.ps1'
        $script:AddUnownedTestsPath = Join-Path $script:RepositoryRoot `
            'eng/tools/RepositoryProjectGraph/ValidateSparseCheckout/Add-UnownedTestProjects.ps1'

        function Invoke-SparseCheckoutProjection(
            [string] $PackageInfoDirectory,
            [string] $RepoRoot,
            [string] $GraphPath,
            [string] $OutputPath,
            [string] $SourceCommit) {
            $output = @(& dotnet msbuild /nologo /nr:false /v:minimal /t:CreateSparseCheckoutGraph `
                $script:TaskProject `
                "/p:SparseCheckoutPackageInfoDirectory=$PackageInfoDirectory" `
                "/p:SparseCheckoutRepoRoot=$RepoRoot" `
                "/p:SparseCheckoutSourceGraphPath=$GraphPath" `
                "/p:SparseCheckoutOutputPath=$OutputPath" `
                "/p:SparseCheckoutSourceCommit=$SourceCommit" 2>&1)
            if ($LASTEXITCODE -ne 0) {
                throw ($output -join "`n")
            }
            Write-Host ($output -join "`n")
        }
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
            'sdk/unused/U/src/U.csproj',
            'common/Perf/Azure.Test.Perf/Azure.Test.Perf.csproj',
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
            schemaVersion = 8
            repositoryRoot = $repo.Replace('\', '/')
            sourceCommit = $sourceCommit
            nodes = @(
                # Test projects commonly infer a nested package root rather than the PackageInfo directory.
                @{ projectPath = 'sdk/alpha/A/tests/A.Tests.csproj'; packageRoot = 'sdk/alpha/A/tests'; targetFrameworks = @('net8.0', 'net9.0'); packageId = 'Azure.A.Tests'; isShippingLibrary = $false }
                @{ projectPath = 'sdk/beta/B/src/B.csproj'; packageRoot = 'sdk/beta/B'; targetFrameworks = @('net8.0'); packageId = 'Azure.B'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/gamma/C/src/C.csproj'; packageRoot = 'sdk/gamma/C'; targetFrameworks = @('net9.0'); packageId = 'Azure.C'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/delta/D/src/D.csproj'; packageRoot = 'sdk/delta/D'; targetFrameworks = @('net8.0'); packageId = 'Azure.D'; isShippingLibrary = $true }
                @{ projectPath = 'sdk/epsilon/E/src/E.csproj'; packageRoot = 'sdk/epsilon/E'; targetFrameworks = @('net8.0'); packageId = 'Azure.E'; isShippingLibrary = $true }
                @{ projectPath = 'common/Perf/Azure.Test.Perf/Azure.Test.Perf.csproj'; packageRoot = 'common/Perf'; targetFrameworks = @('net8.0'); packageId = 'Azure.Test.Perf'; isShippingLibrary = $false }
            )
            configurationEdges = @(
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'sdk/beta/B/src/B.csproj'; toTargetFramework = 'net8.0' }
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net9.0'; to = 'sdk/gamma/C/src/C.csproj'; toTargetFramework = 'net9.0' }
                @{ kind = 'ProjectReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'common/Perf/Azure.Test.Perf/Azure.Test.Perf.csproj'; toTargetFramework = 'net8.0' }
                @{ kind = 'PackageReference'; fromProject = 'sdk/alpha/A/tests/A.Tests.csproj'; fromTargetFramework = 'net8.0'; to = 'Azure.D'; toTargetFramework = '' }
                # NuGet identities are case-insensitive; serialized projection keys are not.
                @{ kind = 'PackageReference'; fromProject = 'sdk/delta/D/src/D.csproj'; fromTargetFramework = 'net8.0'; to = 'azure.e' }
            )
            checkoutRoots = [ordered]@{
                'configuration:sdk/alpha/A/tests/A.Tests.csproj|net8.0' = @('/sdk/alpha/*', '/sdk/shared/*')
                'configuration:sdk/alpha/A/tests/A.Tests.csproj|net9.0' = @('/sdk/alpha/*')
                'configuration:sdk/beta/B/src/B.csproj|net8.0' = @('/sdk/beta/*')
                'configuration:sdk/gamma/C/src/C.csproj|net9.0' = @('/sdk/gamma/*')
                'configuration:sdk/delta/D/src/D.csproj|net8.0' = @('/sdk/delta/*')
                'configuration:sdk/epsilon/E/src/E.csproj|net8.0' = @('/sdk/epsilon/*')
            }
            diagnostics = @{
                isComplete = $true
                generation = @{
                    configuration = 'Debug'
                    includesInputCheckoutRoots = $true
                }
                packageClosure = @{ resolutionMode = 'nuget-restore-graph' }
                checkoutRoots = @{ isComplete = $true }
            }
        } | ConvertTo-Json -Depth 20 | Set-Content $graphPath
    }

    It 'extracts only the requested artifact closure from the shared graph' {
        Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit

        $checkoutGraph = Get-Content $checkoutGraphPath -Raw | ConvertFrom-Json
        $checkoutGraph.schemaVersion | Should -Be 1
        $checkoutGraph.sourceCommit | Should -Be $sourceCommit
        @($checkoutGraph.artifacts.'Azure.A').Count | Should -Be 2
        @($checkoutGraph.alwaysIncludedPaths) | Should -Be @('/*', '!/*/', '/eng', '/.config', '/common')
        @($checkoutGraph.paths.PSObject.Properties.Name | Where-Object { $_ -like 'package:*' }) |
            Should -BeNullOrEmpty
        @($checkoutGraph.paths.PSObject.Properties | ForEach-Object { @($_.Value) } |
            Where-Object { $_ -notlike '/sdk/*' }) |
            Should -BeNullOrEmpty

        $paths = @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A' `
            -ExpectedSourceCommit $sourceCommit)
        @($paths | Where-Object { $_ -match '^/sdk/(alpha|beta|delta|epsilon|gamma|shared)/' }) | Should -Be @(
            '/sdk/alpha/*',
            '/sdk/beta/*',
            '/sdk/delta/*',
            '/sdk/epsilon/*',
            '/sdk/gamma/*',
            '/sdk/shared/*')
        $paths | Should -Not -Contain '/sdk/unused/*'
        $paths | Should -Contain '/common'
    }

    It 'rejects incomplete and non-NuGet source graphs instead of narrowing' {
        $graph = Get-Content $graphPath -Raw | ConvertFrom-Json
        $graph.diagnostics.isComplete = $false
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath

        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*graph is incomplete*'

        $graph.diagnostics.isComplete = $true
        $graph.diagnostics.packageClosure.resolutionMode = 'unsupported-resolution-mode'
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*requires the NuGet restore graph*'

        $graph.diagnostics.packageClosure.resolutionMode = 'nuget-restore-graph'
        $graph.diagnostics.generation.includesInputCheckoutRoots = $false
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*requires a Debug repository graph*'

        $graph.diagnostics.generation.includesInputCheckoutRoots = $true
        $graph.diagnostics.generation.configuration = 'Release'
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*requires a Debug repository graph*'

        $graph.diagnostics.generation.configuration = 'Debug'
        $graph.checkoutRoots.'configuration:sdk/alpha/A/tests/A.Tests.csproj|net8.0' += '/artifacts/obj/*'
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*non-SDK checkout root*artifacts*'

        $graph.checkoutRoots.'configuration:sdk/alpha/A/tests/A.Tests.csproj|net8.0' = @('/sdk/alpha/*', '/sdk/shared/*')
        $graph.checkoutRoots = $null
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*requires a complete checkout-root index*'
    }

    It 'rejects graph provenance when tracked source differs from the recorded commit' {
        $graph = Get-Content $graphPath -Raw | ConvertFrom-Json
        $graph.sourceCommit = 'stale'
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*does not match requested sparse-checkout provenance*'

        $graph.sourceCommit = $sourceCommit
        $graph | ConvertTo-Json -Depth 20 | Set-Content $graphPath
        Set-Content -LiteralPath (Join-Path $repo 'sdk/alpha/A/tests/A.Tests.csproj') -Value 'modified'

        { Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit } |
            Should -Throw '*has tracked changes*'
    }

    It 'unions duplicate artifact seeds instead of silently retaining the first directory' {
        @{
            ArtifactName = 'Azure.A'
            DirectoryPath = 'sdk/beta/B'
        } | ConvertTo-Json | Set-Content (Join-Path $packageInfo 'Azure.A.duplicate.json')

        Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit

        $checkoutGraph = Get-Content $checkoutGraphPath -Raw | ConvertFrom-Json
        @($checkoutGraph.artifacts.'Azure.A').Count | Should -Be 3
    }

    It 'unions artifact batches and returns no paths for missing or stale graph data' {
        [ordered]@{
            schemaVersion = 1
            sourceCommit = $sourceCommit
            isComplete = $true
            failureReason = ''
            alwaysIncludedPaths = @('/*', '!/*/', '/eng', '/common')
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
                '/*', '!/*/', '/eng', '/common', '/sdk/alpha/*', '/sdk/beta/*', '/sdk/shared/*')
        @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A,Missing' `
            -ExpectedSourceCommit $sourceCommit) | Should -BeNullOrEmpty
        @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A' `
            -ExpectedSourceCommit 'stale') | Should -BeNullOrEmpty

        $checkoutGraph = Get-Content $checkoutGraphPath -Raw | ConvertFrom-Json
        $checkoutGraph.paths.'configuration:Shared|net8.0' = @('/artifacts/obj/*')
        $checkoutGraph | ConvertTo-Json -Depth 10 | Set-Content $checkoutGraphPath
        @(& $script:ResolvePathsPath -GraphPath $checkoutGraphPath -ArtifactNames 'Azure.A' `
            -ExpectedSourceCommit $sourceCommit) | Should -BeNullOrEmpty
    }

    It 'expands a generated pipeline batch into singleton validation cases' {
        Invoke-SparseCheckoutProjection $packageInfo $repo $graphPath $checkoutGraphPath $sourceCommit
        $inputRoot = Join-Path $TestDrive 'pipeline-inputs'
        $inputPackageInfo = Join-Path $inputRoot 'PackageInfo'
        $inputGraph = Join-Path $inputRoot 'checkout-graph.json'
        New-Item -ItemType Directory -Path $inputPackageInfo -Force | Out-Null
        Copy-Item -LiteralPath (Join-Path $packageInfo 'Azure.A.json') -Destination $inputPackageInfo
        Copy-Item -LiteralPath $checkoutGraphPath -Destination $inputGraph
        @{
            ArtifactName = 'Azure.B'
            DirectoryPath = 'sdk/beta/B'
        } | ConvertTo-Json | Set-Content (Join-Path $inputPackageInfo 'Azure.B.json')
        $pipelineGraph = Get-Content -Raw -LiteralPath $inputGraph | ConvertFrom-Json -Depth 100
        $pipelineGraph.artifacts | Add-Member -NotePropertyName 'Azure.B' -NotePropertyValue @(
            'configuration:sdk/beta/B/src/B.csproj|net8.0')
        $pipelineGraph | ConvertTo-Json -Depth 100 | Set-Content -LiteralPath $inputGraph

        & $script:NewPipelineInputsPath `
            -RepoRoot $repo `
            -InputRoot $inputRoot `
            -PackageInfoDirectory $inputPackageInfo `
            -CheckoutGraphPath $inputGraph `
            -ArtifactNames 'Azure.A,Azure.B' `
            -SourceCommit $sourceCommit `
            -TargetHost Linux `
            -MatrixName Linux_net80 `
            -TargetFramework net8.0 `
            -BuildConfiguration Debug `
            -AdditionalTestArguments '/p:UseProjectReferenceToAzureClients=false'

        $manifest = Get-Content -Raw -LiteralPath (Join-Path $inputRoot 'manifest.json') |
            ConvertFrom-Json
        $cases = @(Get-Content -Raw -LiteralPath (Join-Path $inputRoot 'cases.json') |
            ConvertFrom-Json)
        $manifest.sourceCommit | Should -Be $sourceCommit
        $manifest.caseCount | Should -Be 2
        $manifest.packageInfoDirectory | Should -Be 'PackageInfo'
        ($cases | Where-Object artifactName -eq 'Azure.A').includeSourceProjects | Should -BeFalse
        ($cases | Where-Object artifactName -eq 'Azure.B').includeSourceProjects | Should -BeTrue
        foreach ($case in $cases) {
            $case.matrixName | Should -Be 'Linux_net80'
            $case.additionalTestArguments | Should -Be '/p:UseProjectReferenceToAzureClients=false'
        }
    }

    It 'adds validation-only singleton artifacts for unowned test projects' {
        $publishingPackageInfo = Join-Path $TestDrive 'PackageInfoPublishing'
        New-Item -ItemType Directory -Path $publishingPackageInfo -Force | Out-Null
        Copy-Item -LiteralPath (Join-Path $packageInfo 'Azure.A.json') -Destination $publishingPackageInfo

        $coverageGraphPath = Join-Path $TestDrive 'coverage-graph.json'
        $coverageGraph = Get-Content -Raw -LiteralPath $graphPath | ConvertFrom-Json -Depth 100
        $coverageGraph.nodes += [pscustomobject]@{
            projectPath = 'sdk/tools/Standalone/tests/Standalone.Tests.csproj'
            packageRoot = 'sdk/tools/Standalone/tests'
            targetFrameworks = @('net10.0')
            packageId = 'Standalone.Tests'
            isShippingLibrary = $false
        }
        $coverageGraph.nodes += [pscustomobject]@{
            projectPath = 'sdk/tools/Modern/tests/Modern.Tests.csproj'
            packageRoot = 'sdk/tools/Modern/tests'
            targetFrameworks = @('net8.0', 'net9.0', 'net10.0')
            packageId = 'Modern.Tests'
            isShippingLibrary = $false
        }
        $coverageGraph | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $coverageGraphPath
        $coverageOutput = Join-Path $TestDrive 'test-project-coverage.json'

        & $script:AddUnownedTestsPath `
            -SourceGraphPath $coverageGraphPath `
            -PackageInfoDirectories @($packageInfo, $publishingPackageInfo) `
            -CoverageOutputPath $coverageOutput `
            -RepoRoot $script:RepositoryRoot `
            -DefaultMatrixConfigPath (Join-Path $script:RepositoryRoot `
                'eng/pipelines/templates/stages/platform-matrix.json') `
            -GeneratedMatrixDirectory (Join-Path $TestDrive 'generated-matrices')

        $coverage = Get-Content -Raw -LiteralPath $coverageOutput | ConvertFrom-Json
        $coverage.testProjectCount | Should -Be 3
        $coverage.syntheticArtifactCount | Should -Be 2
        $coverage.uncoveredTestProjectCount | Should -Be 0
        $synthetic = @(Get-ChildItem -LiteralPath $packageInfo -Filter 'SparseCheckoutValidation.*.json')
        $synthetic.Count | Should -Be 2
        $syntheticPackages = @($synthetic | ForEach-Object {
            Get-Content -Raw -LiteralPath $_.FullName | ConvertFrom-Json
        })
        $syntheticPackage = $syntheticPackages | Where-Object {
            $_.SourceTestProject -eq 'sdk/tools/Standalone/tests/Standalone.Tests.csproj'
        }
        $syntheticPackage.DirectoryPath | Should -Be 'sdk/tools/Standalone/tests'
        $syntheticPackage.SourceTestProject | Should -Be 'sdk/tools/Standalone/tests/Standalone.Tests.csproj'
        $syntheticPackage.CIParameters.CIMatrixConfigs.Count | Should -Be 1
        $matrixReference = $syntheticPackage.CIParameters.CIMatrixConfigs[0].Path
        # Path.GetRelativePath returns a rooted path when Windows inputs reside on another drive.
        $generatedMatrix = [System.IO.Path]::IsPathRooted($matrixReference) ? $matrixReference :
            (Join-Path $script:RepositoryRoot $matrixReference)
        $matrix = Get-Content -Raw -LiteralPath $generatedMatrix | ConvertFrom-Json
        @($matrix.matrix.ValidationCase.PSObject.Properties.Value.TestTargetFramework |
            Sort-Object -Unique) | Should -Be @('net10.0')
        ($syntheticPackages | Where-Object {
            $_.SourceTestProject -eq 'sdk/tools/Modern/tests/Modern.Tests.csproj'
        }).CIParameters.CIMatrixConfigs.Count | Should -Be 0
        foreach ($file in $synthetic) {
            Test-Path -LiteralPath (Join-Path $publishingPackageInfo $file.Name) | Should -BeTrue
        }
    }
}

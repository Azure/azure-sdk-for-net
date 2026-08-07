# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
#
# Generates the local end-to-end TypeSpec test projects under
# `generator/TestProjects/Local/`. Compiles each project's `tspconfig.yaml`
# with `tsp compile` (which invokes the AspNet server emitter), then builds
# the produced .NET project to make sure the generated code compiles.
#
# When a project defines multiple API versions the script invokes the compiler
# once per version (passing --option api-version=<version>). Because the base
# .NET generator removes files that were not produced in the current run, each
# version's output is staged to a temp directory immediately after its compile
# so that earlier versions are not deleted by later ones. The staged outputs
# are merged back into src/Generated/ after all versions have been compiled.
#
# Run from a developer shell (PowerShell 7+) at the repo's
# `eng/packages/http-server-csharp-aspnet` folder, after a successful
# `npm install` and `npm run build`.

[CmdletBinding()]
param(
    [string]$Filter = $null
)

$ErrorActionPreference = "Stop"

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot ".." "..")
$emitterPackageDir = $packageRoot.Path
$tspJs = Join-Path $packageRoot 'node_modules\@typespec\compiler\cmd\tsp.js'
$testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'

$testProjects = @(
    @{
        FilterName = "AzureSql"
        Folder     = "AzureSql"
        EntryTsp   = "main.tsp"
        Versions   = @(
            "2025-11-01"
            "2025-12-01"
            "2026-02-01"
        )
        Csproj     = "Azure.TypeSpec.Generator.AspNetServer.AzureSql.csproj"
        TestCsproj = "Azure.TypeSpec.Generator.AspNetServer.AzureSql.Tests.csproj"
    }
)

foreach ($project in $testProjects) {
    if (-not [string]::IsNullOrEmpty($Filter) -and $Filter -ne $project.FilterName) {
        continue
    }

    $projectDir = Join-Path $testProjectsLocalDir $project.Folder
    $entryTsp = Join-Path $projectDir $project.EntryTsp
    $configFile = Join-Path $projectDir 'tspconfig.yaml'
    $generatedDir = Join-Path $projectDir 'src' 'Generated'

    Write-Host "Generating $($project.FilterName)..." -ForegroundColor Cyan
    Remove-Item -Recurse -Force $generatedDir -ErrorAction SilentlyContinue

    $versions = $project.Versions
    if (-not $versions -or $versions.Count -eq 0) {
        $versions = @($null)
    }

    # Staging directory: accumulates per-version outputs across multiple compiler
    # runs, since the base .NET generator removes stale files on each invocation.
    $stagingDir = Join-Path ([System.IO.Path]::GetTempPath()) "tsp-staging-$($project.FilterName)"
    Remove-Item -Recurse -Force $stagingDir -ErrorAction SilentlyContinue
    New-Item -ItemType Directory -Path $stagingDir -Force | Out-Null

    try {
        foreach ($apiVersion in $versions) {
            if ($apiVersion) {
                Write-Host "Running tsp compile for $($project.FilterName) version $apiVersion..." -ForegroundColor Cyan
            } else {
                Write-Host "Running tsp compile for $($project.FilterName)..." -ForegroundColor Cyan
            }

            $nodeArgs = @($tspJs, "compile", $entryTsp, "--emit", $emitterPackageDir,
                         "--option", "@azure-typespec/http-server-csharp-aspnet.emitter-output-dir=$projectDir")
            if (Test-Path $configFile) {
                $nodeArgs += @("--config", $configFile)
            }
            if ($apiVersion) {
                $nodeArgs += @("--option", "@azure-typespec/http-server-csharp-aspnet.api-version=$apiVersion")
            }

            & node @nodeArgs
            if ($LASTEXITCODE -ne 0) {
                $label = if ($apiVersion) { "$($project.FilterName) version $apiVersion" } else { $project.FilterName }
                throw "tsp compile failed for $label (exit $LASTEXITCODE)."
            }

            # Stage the freshly generated output. The generator cleans up files it
            # did not produce in the current run, so version N's output would be
            # deleted when version N+1 runs. Copying to staging preserves it.
            if (Test-Path $generatedDir) {
                Copy-Item -Recurse -Path "$generatedDir\*" -Destination $stagingDir -Force
            }
        }

        # Merge staged outputs (all versions) back into the final Generated directory.
        Remove-Item -Recurse -Force $generatedDir -ErrorAction SilentlyContinue
        New-Item -ItemType Directory -Path $generatedDir -Force | Out-Null
        Copy-Item -Recurse -Path "$stagingDir\*" -Destination $generatedDir -Force
    } finally {
        Remove-Item -Recurse -Force $stagingDir -ErrorAction SilentlyContinue
    }

    $csproj = Join-Path $projectDir 'src' $project.Csproj
    if (Test-Path $csproj) {
        Write-Host "Building $csproj..." -ForegroundColor Cyan
        & dotnet build $csproj
        if ($LASTEXITCODE -ne 0) {
            throw "dotnet build failed for $($project.FilterName) (exit $LASTEXITCODE)."
        }
    }

    $testCsproj = Join-Path $projectDir 'tests' $project.TestCsproj
    if (Test-Path $testCsproj) {
        Write-Host "Testing $testCsproj..." -ForegroundColor Cyan
        & dotnet test $testCsproj
        if ($LASTEXITCODE -ne 0) {
            throw "dotnet test failed for $($project.FilterName) (exit $LASTEXITCODE)."
        }
    }
}

Write-Host "All test projects generated successfully." -ForegroundColor Green

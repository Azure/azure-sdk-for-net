# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
#
# Generates the local end-to-end TypeSpec test projects under
# `generator/TestProjects/Local/`. Compiles each project's `tspconfig.yaml`
# with `tsp compile` (which invokes the AspNet server emitter), then builds
# the produced .NET project to make sure the generated code compiles.
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
$testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'

$testProjects = @(
    @{
        FilterName = "AzureSql"
        Folder     = "AzureSql"
        EntryTsp   = "main.tsp"
        Csproj     = "Microsoft.TypeSpec.Generator.AspNetServer.AzureSql.csproj"
    }
)

foreach ($project in $testProjects) {
    if (-not [string]::IsNullOrEmpty($Filter) -and $Filter -ne $project.FilterName) {
        continue
    }

    $projectDir = Join-Path $testProjectsLocalDir $project.Folder
    $entryTsp = Join-Path $projectDir $project.EntryTsp
    $configFile = Join-Path $projectDir 'tspconfig.yaml'

    Write-Host "Generating $($project.FilterName)..." -ForegroundColor Cyan

    $command = "npx tsp compile `"$entryTsp`""
    $command += " --emit `"$emitterPackageDir`""
    if (Test-Path $configFile) {
        $command += " --config=`"$configFile`""
    }
    $command += " --option @azure-typespec/http-server-csharp-aspnet.emitter-output-dir=`"$projectDir`""

    Write-Host $command
    Push-Location $packageRoot
    try {
        Invoke-Expression $command
    } finally {
        Pop-Location
    }

    if ($LASTEXITCODE -ne 0) {
        throw "tsp compile failed for $($project.FilterName) (exit $LASTEXITCODE)."
    }

    $csproj = Join-Path $projectDir 'src' $project.Csproj
    if (Test-Path $csproj) {
        Write-Host "Building $csproj..." -ForegroundColor Cyan
        & dotnet build $csproj
        if ($LASTEXITCODE -ne 0) {
            throw "dotnet build failed for $($project.FilterName) (exit $LASTEXITCODE)."
        }
    }
}

Write-Host "All test projects generated successfully." -ForegroundColor Green

#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

$packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"

function Get-TspCommand {
    param (
        [string]$specFile,
        [string]$generationDir
    )
    $command = "npx tsp compile $specFile"
    $command += " --trace @azure-typespec/http-client-csharp"
    $command += " --emit @azure-typespec/http-client-csharp"
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $command += " --config=$configFile"
    }
    $command += " --option @azure-typespec/http-client-csharp.emitter-output-dir=$generationDir"
    $command += " --option @azure-typespec/http-client-csharp.save-inputs=true"
    $command += " --option @azure-typespec/http-client-csharp.new-project=true"
    return $command
}

function Refresh-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke-LoggedCommand "npm run build:emitter"

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    # generating Azure.Generator.csproj is enough
    Invoke-LoggedCommand "dotnet build $packageRoot/generator/Azure.Generator/src"
}

$testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'
$basicTypespecTestProject = Join-Path $testProjectsLocalDir "Basic-TypeSpec"
$mgmtTypespecTestProject = Join-Path $testProjectsLocalDir "Mgmt-TypeSpec"

Push-Location $packageRoot

Write-Host "Generating test projects ..."
Refresh-Build

Write-Host "Generating BasicTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand (Get-TspCommand "$basicTypespecTestProject/Basic-TypeSpec.tsp" $basicTypespecTestProject)

Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand "dotnet build $packageRoot/generator/TestProjects/Local/Basic-TypeSpec/src/BasicTypeSpec.csproj"

Write-Host "Generating MgmtTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand (Get-TspCommand "$mgmtTypespecTestProject/main.tsp" $mgmtTypespecTestProject)

# temporarily disable building MgmtTypeSpec because now the generated code of this project cannot build
# Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
# Invoke-LoggedCommand "dotnet build $packageRoot/generator/TestProjects/Local/Mgmt-TypeSpec/src/MgmtTypeSpec.csproj"

Pop-Location

Write-Host 'Code generation is completed.'

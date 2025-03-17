#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

$packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"
$mgmtPackageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp-mgmt"

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

function Get-MgmtTspCommand {
    param (
        [string]$specFile,
        [string]$generationDir
    )
    $mgmtCommand = "npx tsp compile $specFile"
    $mgmtCommand += " --trace @azure-typespec/http-client-csharp-mgmt"
    $mgmtCommand += " --emit @azure-typespec/http-client-csharp-mgmt"
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $mgmtCommand += " --config=$configFile"
    }
    $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$generationDir"
    $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.save-inputs=true"
    $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.new-project=true"
    # $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.debug=true"
    return $mgmtCommand
}

function Refresh-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke-LoggedCommand "npm run build:emitter"

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    # generating Azure.Generator.csproj is enough
    Invoke-LoggedCommand "dotnet build $packageRoot/generator/Azure.Generator/src"
}

function Refresh-Mgmt-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke-LoggedCommand "npm run build:emitter"

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    # generating Azure.Generator.csproj is enough
    Invoke-LoggedCommand "dotnet build $mgmtPackageRoot/generator/Azure.Generator.Mgmt/src"
}

$testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'
$mgmtTestProjectsLocalDir = Join-Path $mgmtPackageRoot 'generator' 'TestProjects' 'Local'
$basicTypespecTestProject = Join-Path $testProjectsLocalDir "Basic-TypeSpec"
$mgmtTypespecTestProject = Join-Path $mgmtTestProjectsLocalDir "Mgmt-TypeSpec"

# Push-Location $packageRoot

# Write-Host "Generating test projects ..."
# Refresh-Build

# Write-Host "Generating BasicTypeSpec" -ForegroundColor Cyan
# Invoke-LoggedCommand (Get-TspCommand "$basicTypespecTestProject/Basic-TypeSpec.tsp" $basicTypespecTestProject)

# Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
# Invoke-LoggedCommand "dotnet build $packageRoot/generator/TestProjects/Local/Basic-TypeSpec/src/BasicTypeSpec.csproj"

# Pop-Location

Push-Location $mgmtPackageRoot

Write-Host "Generating test projects ..."
Refresh-Mgmt-Build

Write-Host "Generating MgmtTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand (Get-MgmtTspCommand "$mgmtTypespecTestProject/main.tsp" $mgmtTypespecTestProject)

Write-Host "Building MgmtTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand "dotnet build $mgmtPackageRoot/generator/TestProjects/Local/Mgmt-TypeSpec/src/MgmtTypeSpec.csproj"

Write-Host 'Code generation is completed.'

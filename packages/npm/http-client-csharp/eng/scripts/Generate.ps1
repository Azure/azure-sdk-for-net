#Requires -Version 7.0

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

Refresh-Build

Write-Host "Generating BasicTypeSpec" -ForegroundColor Cyan
$testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'

$basicTypespecTestProject = Join-Path $testProjectsLocalDir "Basic-TypeSpec"

Invoke (Get-TspCommand "$basicTypespecTestProject/Basic-TypeSpec.tsp" $basicTypespecTestProject)

# exit if the generation failed
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
Invoke "dotnet build $packageRoot/generator/TestProjects/Local/Basic-TypeSpec/src/BasicTypeSpec.csproj"

# exit if the generation failed
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

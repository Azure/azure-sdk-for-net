#Requires -Version 7.0

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

Refresh-Build

Write-Host "Generating UnbrandedTypeSpec" -ForegroundColor Cyan
$testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'

$unbrandedTypespecTestProject = Join-Path $testProjectsLocalDir "Unbranded-TypeSpec"

Invoke (Get-TspCommand "$unbrandedTypespecTestProject/Unbranded-TypeSpec.tsp" $unbrandedTypespecTestProject)

# exit if the generation failed
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

Write-Host "Building UnbrandedTypeSpec" -ForegroundColor Cyan
Invoke "dotnet build $packageRoot/generator/TestProjects/Local/Unbranded-TypeSpec/src/UnbrandedTypeSpec.csproj"

# exit if the generation failed
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

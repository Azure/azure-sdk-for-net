#Requires -Version 7.0

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;
Import-Module "$PSScriptRoot\Spector-Helper.psm1" -DisableNameChecking -Force;

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

Refresh-Mgmt-Build

$spectorRoot = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector'
$spectorCsproj = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector.Tests' 'Azure.Generator.Spector.Tests.csproj'
$coverageDir = Join-Path $packageRoot 'generator' 'artifacts' 'coverage'

if (-not (Test-Path $coverageDir)) {
    New-Item -ItemType Directory -Path $coverageDir | Out-Null
}

$specs = Get-Sorted-Specs

foreach ($specFile in $specs) {
    $subPath = Get-SubPath $specFile
    $outputDir = Join-Path $spectorRoot $subPath

    Write-Host "Regenerating $subPath" -ForegroundColor Cyan
    Invoke (Get-Mgmt-TspCommand $specFile $outputDir)

    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

Write-Host "Generating Spector coverage" -ForegroundColor Cyan
Invoke "dotnet test $spectorCsproj"

if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

foreach ($specFile in $specs) {
    $subPath = Get-SubPath $specFile
    $outputDir = Join-Path $spectorRoot $subPath

    Write-Host "Restoring $subPath" -ForegroundColor Cyan
    Invoke "git clean -xfd $outputDir"

    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    $trackedFiles = & git ls-files $outputDir
    if ($trackedFiles) {
        Invoke "git restore $outputDir"

        if ($LASTEXITCODE -ne 0) {
            exit $LASTEXITCODE
        }
    }
}

#Requires -Version 7.0

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;
Import-Module "$PSScriptRoot\Spector-Helper.psm1" -DisableNameChecking -Force;

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

Refresh-Build

$spectorRoot = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector'
$spectorCsproj = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector.Tests' 'TestProjects.Spector.Tests.csproj'

$coverageDir = Join-Path $packageRoot 'generator' 'artifacts' 'coverage'

if (-not (Test-Path $coverageDir)) {
    New-Item -ItemType Directory -Path $coverageDir | Out-Null
}

$specs = Get-Sorted-Specs

# generate all
foreach ($specFile in $specs) {
    $subPath = Get-SubPath $specFile

    Write-Host "Regenerating $subPath" -ForegroundColor Cyan
    $outputDir = Join-Path $spectorRoot $subPath

    if ($subPath.Contains("versioning")) {
        # this will generate v1 and v2 so we only need to call it once for one of the versions
        Generate-Versioning (Split-Path $specFile) $outputDir -createOutputDirIfNotExist $false
        continue
    }

    if ($subPath.Contains("srv-driven")) {
        # this will generate v1 and v2 so we only need to call it once for one of the versions
        Generate-Srv-Driven (Split-Path $specFile) $outputDir -createOutputDirIfNotExist $false
        continue
    }

    $command = Get-TspCommand $specFile $outputDir
    Invoke $command

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

# test all
Write-Host "Generating Spector coverage" -ForegroundColor Cyan
$command  = "dotnet test $spectorCsproj"
Invoke $command
# exit if the testing failed
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

# restore all
foreach ($specFile in $specs) {
    $subPath = Get-SubPath $specFile

    Write-Host "Restoring $subPath" -ForegroundColor Cyan

    $outputDir = Join-Path $spectorRoot $subPath
    $command = "git clean -xfd $outputDir"
    Invoke $command
    # exit if the restore failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
    $command = "git restore $outputDir"
    Invoke $command
    # exit if the restore failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

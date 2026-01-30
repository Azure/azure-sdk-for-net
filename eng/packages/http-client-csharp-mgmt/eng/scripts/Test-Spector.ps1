#Requires -Version 7.0

param($filter)

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

foreach ($specFile in Get-Sorted-Specs) {
    $subPath = Get-SubPath $specFile

    # skip the HTTP root folder when computing the namespace filter
    $folders = $subPath.Split([System.IO.Path]::DirectorySeparatorChar) | Select-Object -Skip 1

    if (-not (Compare-Paths $subPath $filter)) {
        continue
    }

    $testPath = Join-Path "$spectorRoot.Tests" "Http"
    $testFilter = "TestProjects.Spector.Tests.Http"
    foreach ($folder in $folders) {
        $segment = "$(Get-Namespace $folder)"

        # the test directory names match the test namespace names, but the source directory names will not have the leading underscore
        # so check to see if the filter should contain a leading underscore by comparing with the test directory
        if (-not (Test-Path (Join-Path $testPath $segment))) {
          $testFilter += "._$segment"
          $testPath = Join-Path $testPath "_$segment"
        }
        else{
          $testFilter += ".$segment"
          $testPath = Join-Path $testPath $segment
        }
    }

    Write-Host "Regenerating $subPath" -ForegroundColor Cyan

    $outputDir = Join-Path $spectorRoot $subPath

    $command = Get-Mgmt-TspCommand $specFile $outputDir
    Invoke $command

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "Testing $subPath" -ForegroundColor Cyan
    $command = "dotnet test $spectorCsproj --filter `"FullyQualifiedName~$testFilter`""
    Invoke $command
    # exit if the testing failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "Restoring $subPath" -ForegroundColor Cyan

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

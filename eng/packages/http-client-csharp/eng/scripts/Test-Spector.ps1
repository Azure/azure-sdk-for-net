#Requires -Version 7.0

param($filter)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;
Import-Module "$PSScriptRoot\Spector-Helper.psm1" -DisableNameChecking -Force;

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

Refresh-Build

$specsDirectory = Join-Path $packageRoot 'node_modules' '@typespec' 'http-specs' 'specs'
$azureSpecsDirectory = Join-Path $packageRoot 'node_modules' '@azure-tools' 'azure-http-specs' 'specs'
$spectorRoot = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector' 
$spectorRootHttp = Join-Path $spectorRoot 'http'
$directories = Get-ChildItem -Path "$spectorRootHttp" -Directory -Recurse
$spectorCsproj = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector.Tests' 'TestProjects.Spector.Tests.csproj'

$coverageDir = Join-Path $packageRoot 'generator' 'artifacts' 'coverage'

if (-not (Test-Path $coverageDir)) {
    New-Item -ItemType Directory -Path $coverageDir | Out-Null
}

foreach ($directory in $directories) {
    if (-not (IsGenerated $directory.FullName)) {
        continue
    }

    $outputDir = $directory.FullName.Substring(0, $directory.FullName.IndexOf("src") - 1)
    $subPath = $outputDir.Substring($spectorRootHttp.Length + 1)
    $folders = $subPath.Split([System.IO.Path]::DirectorySeparatorChar)

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

    $specFile = Join-Path $specsDirectory $subPath "client.tsp"
    if (-not (Test-Path $specFile)) {
        $specFile = Join-Path $specsDirectory $subPath "main.tsp"
    }
    if (-not (Test-Path $specFile)) {
        $specFile = Join-Path $azureSpecsDirectory $subPath "client.tsp"
    }
    if (-not (Test-Path $specFile)) {
        $specFile = Join-Path $azureSpecsDirectory $subPath "main.tsp"
    }
    
    if ($subPath.Contains("versioning")) {
        if ($subPath.Contains("v1")) {
            # this will generate v1 and v2 so we only need to call it once for one of the versions
            Generate-Versioning ($(Join-Path $specsDirectory $subPath) | Split-Path) $($outputDir | Split-Path) -createOutputDirIfNotExist $false
        }
    }
    elseif ($subPath.Contains("srv-driven")) {
        if ($subPath.Contains("v1")) {
            Generate-Srv-Driven ($(Join-Path $azureSpecsDirectory $subPath) | Split-Path) $($outputDir | Split-Path) -createOutputDirIfNotExist $false
        }
    }
    else {
        $command = Get-TspCommand $specFile $outputDir
        Invoke $command
    }

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "Testing $subPath" -ForegroundColor Cyan
    $command  = "dotnet test $spectorCsproj --filter `"FullyQualifiedName~$testFilter`""
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

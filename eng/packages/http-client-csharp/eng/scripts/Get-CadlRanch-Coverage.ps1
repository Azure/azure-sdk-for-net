#Requires -Version 7.0

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;
Import-Module "$PSScriptRoot\CadlRanch-Helper.psm1" -DisableNameChecking -Force;

$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

Refresh-Build

$specsDirectory = Join-Path $packageRoot 'node_modules' '@typespec' 'http-specs' 'specs'
$azureSpecsDirectory = Join-Path $packageRoot 'node_modules' '@azure-tools' 'azure-http-specs' 'specs'
$cadlRanchRoot = Join-Path $packageRoot 'generator' 'TestProjects' 'CadlRanch' 'http'
$directories = Get-ChildItem -Path "$cadlRanchRoot" -Directory -Recurse
$cadlRanchCsproj = Join-Path $packageRoot 'generator' 'TestProjects' 'CadlRanch.Tests' 'TestProjects.CadlRanch.Tests.csproj'

$coverageDir = Join-Path $packageRoot 'generator' 'artifacts' 'coverage'

if (-not (Test-Path $coverageDir)) {
    New-Item -ItemType Directory -Path $coverageDir | Out-Null
}

# generate all
foreach ($directory in $directories) {
    if (-not (IsGenerated $directory.FullName)) {
        continue
    }

    $outputDir = $directory.FullName.Substring(0, $directory.FullName.IndexOf("src") - 1)
    $subPath = $outputDir.Substring($cadlRanchRoot.Length + 1)

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
        continue
    }

    if ($subPath.Contains("srv-driven")) {
        if ($subPath.Contains("v1")) {
            # this will generate v1 and v2 so we only need to call it once for one of the versions
            Generate-Srv-Driven ($(Join-Path $azureSpecsDirectory $subPath) | Split-Path) $($outputDir | Split-Path) -createOutputDirIfNotExist $false
        }
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
Write-Host "Generating CadlRanch coverage" -ForegroundColor Cyan
$command  = "dotnet test $cadlRanchCsproj"
Invoke $command
# exit if the testing failed
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

# restore all
foreach ($directory in $directories) {
    if (-not (IsGenerated $directory.FullName)) {
        continue
    }

    $outputDir = $directory.FullName.Substring(0, $directory.FullName.IndexOf("src") - 1)
    $subPath = $outputDir.Substring($cadlRanchRoot.Length + 1)

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

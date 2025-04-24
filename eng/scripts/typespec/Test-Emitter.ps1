#Requires -Version 7.0

param(
    [switch] $UnitTests,
    [switch] $GenerationChecks,
    [string] $Filter = ".",
    [string] $OutputDirectory,
    [string] $EmitterPackagePath
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

# strip leading slash from emitterPackagePath if it exists
if ($EmitterPackagePath.StartsWith("/")) {
    $EmitterPackagePath = $EmitterPackagePath.Substring(1)
}

$packageRoot = Resolve-Path "$RepoRoot/$EmitterPackagePath"
$testResultsPath = $OutputDirectory ? $OutputDirectory : (Join-Path $packageRoot "artifacts" "test")

$errors = @()

function Build-Emitter {
    param (
        [string]$packageRoot,
        [string]$testResultsPath
    )

        # restore the package.json and package-lock.json files to their original state
        Write-Host "Restoring package.json and package-lock.json to their original state"
        Invoke-LoggedCommand "git restore package.json package-lock.json"

        if ($UnitTests) {
            # test the emitter
            Invoke-LoggedCommand "npm run prettier" -GroupOutput -ErrorAction Continue
            if ($LastExitCode) {
                $errors += "Prettier failed"
            }

            Invoke-LoggedCommand "npm run lint" -GroupOutput -ErrorAction Continue
            if ($LastExitCode) {
                $errors += "Lint failed"
            }

            Invoke-LoggedCommand "npm install @types/node --save-dev" -GroupOutput
            Invoke-LoggedCommand "npm run build:emitter" -GroupOutput
            Invoke-LoggedCommand "npm run test:emitter" -GroupOutput -ErrorAction Continue
            if ($LastExitCode) {
                $errors += "Emitter tests failed"
            }

            Invoke-LoggedCommand "npm run build:generator" -GroupOutput
            Invoke-LoggedCommand "npm run test:generator" -GroupOutput -ErrorAction Continue
            if ($LastExitCode) {
                $errors += "Generator tests failed"
            }
        }
}

Push-Location $packageRoot

try {
    Build-Emitter -packageRoot $packageRoot -testResultsPath $testResultsPath

    # we only run spector test for Azure emitter
    if ($UnitTests -and $EmitterPackagePath.EndsWith("http-client-csharp")) {
        Invoke-LoggedCommand "$packageRoot/eng/scripts/Get-Spector-Coverage.ps1" -GroupOutput

        $testResultsFile = "$packageRoot/generator/artifacts/coverage/tsp-spector-coverage-azure.json"

        # copy test results to the artifacts directory
        if (Test-Path $testResultsFile) {
            New-Item -ItemType Directory -Force -Path $testResultsPath | Out-Null
            Copy-Item -Path $testResultsFile -Destination $testResultsPath -Force
        }
        else {
            LogWarning "No test results file found at $testResultsFile"
        }
    }

    if ($GenerationChecks) {
        Set-StrictMode -Version 1
        # run E2E Test for TypeSpec emitter
        try
        {
            & "$RepoRoot/eng/scripts/typespec/Check-CodeGeneration.ps1" -EmitterPackagePath $packageRoot -Filter $Filter -Reset
        }
        catch
        {
            $errors += "Code generation check failed"
        }
    }
}
finally {
    Pop-Location
}

if ($errors.Length) {
    Write-Host ''
    Write-Error ($errors -join ', ')
    exit 1
}

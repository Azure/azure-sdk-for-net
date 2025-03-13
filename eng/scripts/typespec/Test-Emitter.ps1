#Requires -Version 7.0

param(
    [switch] $UnitTests,
    [switch] $GenerationChecks,
    [string] $Filter = ".",
    [string] $OutputDirectory
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

$packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"
$testResultsPath = $OutputDirectory ? $OutputDirectory : (Join-Path $packageRoot "artifacts" "test")
$errors = @()
Push-Location $packageRoot
try {
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

        Invoke-LoggedCommand "npm run build:generator" -GroupOutput
        Invoke-LoggedCommand "npm run test:generator" -GroupOutput -ErrorAction Continue
        if ($LastExitCode) {
            $errors += "Genereator tests failed"
        }

        Invoke-LoggedCommand "npm run build:emitter" -GroupOutput
        Invoke-LoggedCommand "npm run test:emitter" -GroupOutput -ErrorAction Continue
        if ($LastExitCode) {
            $errors += "Emitter tests failed"
        }

        $testResultsFile = "$packageRoot/generator/Azure.Generator/test/TestResults/debug.trx"

        # copy test results to the artifacts directory
        if (Test-Path $testResultsFile) {
            New-Item -ItemType Directory -Force -Path $testResultsPath | Out-Null
            Copy-Item -Path $testResultsFile -Destination $testResultsPath -Force
        }
        else {
            LogWarning "No test results file found at $testResultsFile"
        }

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
            & "$RepoRoot/eng/scripts/typespec/Check-CodeGeneration.ps1" -Filter $Filter -Reset
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

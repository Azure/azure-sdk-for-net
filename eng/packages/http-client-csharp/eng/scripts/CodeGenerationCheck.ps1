#Requires -Version 6.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

Write-Host "Generating test projects ..."
& (Join-Path $PSScriptRoot 'Generate.ps1') -reset
Write-Host 'Code generation is completed.'

Write-Host 'Checking generated files difference...'
git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
if ($LastExitCode -ne 0) {
    Write-Error 'Generated codes are not up to date. Please run: eng/packages/http-client-csharp/eng/Generate.ps1'
    exit 1
}
Write-Host 'Done. No change is detected.'

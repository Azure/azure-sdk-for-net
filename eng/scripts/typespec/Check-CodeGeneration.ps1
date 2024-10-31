#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

& "$PSScriptRoot/Generate-Code.ps1"

Write-Host 'Checking generated files difference...'
git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
if ($LastExitCode -ne 0) {
    Write-Error 'Generated codes are not up to date. Please run: eng/scripts/typespec/Generate-Code.ps1'
    exit 1
}
Write-Host 'Done. No change is detected.'

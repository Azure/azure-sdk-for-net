#Requires -Version 7.0

param(
    [string] $EmitterPackagePath
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

Push-Location $EmitterPackagePath

try {
    & "$EmitterPackagePath/eng/scripts/Generate.ps1"

    Write-Host 'Checking generated files difference...'
    git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
    if ($LastExitCode -ne 0) {
        Write-Error 'Generated code of Azure generator is not up to date. Please run: /eng/scripts/Generate.ps1'
        exit 1
    }
    Write-Host 'Done for Azure generator. No change is detected.'
}
finally {
    Pop-Location
}

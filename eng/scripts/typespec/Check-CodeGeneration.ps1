#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

$packageRoot = Resolve-Path "$PSScriptRoot../../../packages/http-client-csharp"
Push-Location $packageRoot

try {
    & "$packageRoot/eng/scripts/Generate.ps1"

    Write-Host 'Checking generated files difference...'
    git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
    if ($LastExitCode -ne 0) {
        Write-Error 'Generated codes of Azure generator are not up to date. Please run: eng/packages/http-client-csharp/eng/scripts/Generate.ps1'
        exit 1
    }
    Write-Host 'Done for Azure generator. No change is detected.'
}
finally {
    Pop-Location
}

$mgmtPackageRoot = Resolve-Path "$PSScriptRoot../../../packages/http-client-csharp-mgmt"
Push-Location $mgmtPackageRoot

try {
    & "$mgmtPackageRoot/eng/scripts/Generate.ps1"

    Write-Host 'Checking generated files difference...'
    git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
    if ($LastExitCode -ne 0) {
        Write-Error 'Generated codes of mgmt generator are not up to date. Please run: eng/packages/http-client-csharp/eng/scripts/Generate.ps1'
        exit 1
    }
    Write-Host 'Done for mgmt generator. No change is detected.'
}
finally {
    Pop-Location
}

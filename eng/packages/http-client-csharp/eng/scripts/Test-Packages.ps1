#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$packageRoot = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
Write-Host $packageRoot
. "$packageRoot/eng/scripts/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

Push-Location $packageRoot
try {
    Push-Location "$packageRoot"
    try {
        # test the generator
        Invoke-LoggedCommand "dotnet test ./generator" -GroupOutput
    }
    finally {
        Pop-Location
    }
}
finally {
    Pop-Location
}

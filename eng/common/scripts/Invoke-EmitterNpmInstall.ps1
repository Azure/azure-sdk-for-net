. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1
. $PSScriptRoot/common.ps1

Push-Location $RepoRoot
try {
    $currentDur = Resolve-Path "."

    if (Test-Path "node_modules") {
        Write-Host "node_modules folder already exists. Skipping npm install."
        exit 0
    }

    Write-Host "Installing npm dependencies in $currentDur"

    if (Test-Path "package.json") {
        Write-Host "Removing existing package.json"
        Remove-Item -Path "package.json" -Force
    }

    if (Test-Path "package-lock.json") {
        Write-Host "Removing existing package-lock.json"
        Remove-Item -Path "package-lock.json" -Force
    }

    if (Test-Path ".npmrc") {
        Write-Host "Removing existing .nprc"
        Remove-Item -Path ".npmrc" -Force
    }

    Write-Host("Copying package.json from eng/emitter-package.json")
    Copy-Item -Path './eng/emitter-package.json' -Destination "package.json" -Force

    $usingLockFile = Test-Path './eng/emitter-package-lock.json'

    if ($usingLockFile) {
        Write-Host("Copying package-lock.json from eng/emitter-package-lock.json")
        Copy-Item -Path './eng/emitter-package-lock.json' -Destination "package-lock.json" -Force
    }

    $useAlphaNpmRegistry = (Get-Content 'package.json' -Raw).Contains("-alpha.")

    if ($useAlphaNpmRegistry) {
        Write-Host "Package.json contains '-alpha.' in the version, Creating .npmrc using public/azure-sdk-for-js-test-autorest feed."
        "registry=https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest@local/npm/registry/" | Out-File '.npmrc'
    }

    if ($usingLockFile) {
        Invoke-LoggedCommand "npm ci"
    }
    else {
        Invoke-LoggedCommand "npm install"
    }

    Remove-Item -Path "package.json" -Force
    Remove-Item -Path "package-lock.json" -Force

    if ($useAlphaNpmRegistry) {
        Remove-Item -Path ".npmrc" -Force
    }

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}
param(
  [switch] $Force
)

. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1
. $PSScriptRoot/common.ps1

Push-Location $RepoRoot
try {
    $currentDur = Resolve-Path "."
    $usingLockFile = Test-Path './eng/emitter-package-lock.json'

    Write-Host "Installing npm dependencies in $currentDur"

    if (!$Force -and $usingLockFile -and (Test-Path "node_modules/.package-lock.json")) {
        # If we have a lock file and a node_modules/.package-lock.json we may 
        # be able to skip npm install.

        # After install, the lock file in node_modules should match outer lock
        # file, except for an empty string "self" package that only exists in
        # the outer lock file.
        $outerLockFile = Get-Content './eng/emitter-package-lock.json' -Raw | ConvertFrom-Json -AsHashtable
        $outerLockFile.packages.Remove('')
        
        $nodeModulesLockFile = Get-Content 'node_modules/.package-lock.json' -Raw | ConvertFrom-Json -AsHashtable

        if (($outerLockFile | ConvertTo-Json -Depth 100 -Compress) -eq ($nodeModulesLockFile | ConvertTo-Json -Depth 100 -Compress)) {
            Write-Host "Skipping npm install because node_modules is up to date"
            exit 0
        }
    }

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
[CmdLetBinding()]
param
(
  [string]$WorkingDirectory
)

. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1
. $PSScriptRoot/common.ps1

Push-Location $WorkingDirectory
try {
    $currentDur = Resolve-Path "."
    Write-Host "Generating from $currentDur"

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

  if (Test-Path "node_modules") {
      Write-Host "Removing existing node_modules folder"
      Remove-Item -Path "node_modules" -Force -Recurse
  }

    #default to root/eng/emitter-package.json but you can override by writing
    #Get-${Language}-EmitterPackageJsonPath in your Language-Settings.ps1
    $replacementPackageJson = Join-Path $PSScriptRoot "../../emitter-package.json"
    if (Test-Path "Function:$GetEmitterPackageJsonPathFn") {
        $replacementPackageJson = &$GetEmitterPackageJsonPathFn
    }

    Write-Host("Copying package.json from $replacementPackageJson")
    Copy-Item -Path $replacementPackageJson -Destination "package.json" -Force

    #default to root/eng/emitter-package-lock.json but you can override by writing
    #Get-${Language}-EmitterPackageLockPath in your Language-Settings.ps1
    $emitterPackageLock = Join-Path $PSScriptRoot "../../emitter-package-lock.json"
    if (Test-Path "Function:$GetEmitterPackageLockPathFn") {
        $emitterPackageLock = &$GetEmitterPackageLockPathFn
    }

    $usingLockFile = Test-Path $emitterPackageLock

    if ($usingLockFile) {
        Write-Host("Copying package-lock.json from $emitterPackageLock")
        Copy-Item -Path $emitterPackageLock -Destination "package-lock.json" -Force
    }

    $useAlphaNpmRegistry = (Get-Content $replacementPackageJson -Raw).Contains("-alpha.")

    if($useAlphaNpmRegistry) {
        Write-Host "Package.json contains '-alpha.' in the version, Creating .npmrc using public/azure-sdk-for-js-test-autorest feed."
        "registry=https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest@local/npm/registry/" | Out-File '.npmrc'
    }

    if ($usingLockFile) {
        Invoke-LoggedCommand "npm ci"
    }
    else {
        Invoke-LoggedCommand "npm install"
    }

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}
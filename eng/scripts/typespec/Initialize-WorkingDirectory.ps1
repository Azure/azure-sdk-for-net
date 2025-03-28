#Requires -Version 7.0

param(
    [string] $BuildArtifactsPath,
    [switch] $UseTypeSpecNext
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

if ($UseTypeSpecNext) {
    Write-Host "##vso[build.addbuildtag]typespec_next"
}

Invoke-LoggedCommand "npm install -g pnpm" # Pnpm manage-package-manager-versions will respect packageManager field

Push-Location $RepoRoot
try {
    if (Test-Path "./node_modules") {
        Remove-Item -Recurse -Force "./node_modules"
    }

    # install and list npm packages
    if ($BuildArtifactsPath) {
        $lockFilesPath = Resolve-Path "$BuildArtifactsPath/lock-files"
        # if we were passed a build_artifacts path, use the package.json and package-lock.json from there
        Write-Host "Using package.json and package-lock.json from $lockFilesPath"
        Copy-Item "$lockFilesPath/package.json" './package.json' -Force
        Copy-Item "$lockFilesPath/pnpm-lock.yaml" './pnpm-lock.yaml' -Force

        Invoke-LoggedCommand "pnpm install --frozen-lockfile"
    }
    elseif ($UseTypeSpecNext) {
        if (Test-Path "./package-lock.json") {
            Remove-Item -Force "./package-lock.json"
        }

        Write-Host "Using TypeSpec.Next"
        Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --add-npm-overrides package.json"
        Invoke-LoggedCommand "pnpm install"
    }
    else {
        Invoke-LoggedCommand "pnpm install"
    }

    $artifactStagingDirectory = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
    if ($artifactStagingDirectory -and !$BuildArtifactsPath) {
        $lockFilesPath = "$artifactStagingDirectory/lock-files"
        New-Item -ItemType Directory -Path "$lockFilesPath" | Out-Null
        Write-Host "Copying package.json and pnpm-lock.json  to $lockFilesPath"
        Copy-Item "./package.json" "$lockFilesPath/package.json" -Force
        Copy-Item "./pnpm-lock.json" "$lockFilesPath/pnpm-lock.json" -Force
    }
}
finally {
    Pop-Location
}

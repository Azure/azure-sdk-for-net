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

$packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"
Push-Location $packageRoot
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
        Copy-Item "$lockFilesPath/package-lock.json" './package-lock.json' -Force

        Invoke-LoggedCommand "npm ci"
    }
    elseif ($UseTypeSpecNext) {
        if (Test-Path "./package-lock.json") {
            Remove-Item -Force "./package-lock.json"
        }

        Write-Host "Using TypeSpec.Next"
        Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --add-npm-overrides package.json"
        Invoke-LoggedCommand "npm install"
    }
    else {
        Invoke-LoggedCommand "npm ci"
    }

    Invoke-LoggedCommand "npm ls -a" -GroupOutput

    $artifactStagingDirectory = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
    if ($artifactStagingDirectory -and !$BuildArtifactsPath) {
        $lockFilesPath = "$artifactStagingDirectory/lock-files"
        New-Item -ItemType Directory -Path "$lockFilesPath" | Out-Null
        Write-Host "Copying package.json and package-lock.json to $lockFilesPath"
        Copy-Item "./package.json" "$lockFilesPath/package.json" -Force
        Copy-Item "./package-lock.json" "$lockFilesPath/package-lock.json" -Force
    }
}
finally {
    Pop-Location
}

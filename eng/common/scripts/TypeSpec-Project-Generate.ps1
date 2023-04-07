# For details see https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/TypeSpec-Project-Scripts.md

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory,
    [Parameter(Position=1)]
    [string] $typespecAdditionalOptions ## addtional typespec emitter options, separated by semicolon if more than one, e.g. option1=value1;option2=value2
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/common.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

function GetNpmPackageVersion([string]$packagePath) {
    $packagePath = Resolve-Path $packagePath
    $packageFolder = Split-Path -Parent $packagePath
    $packageName = Split-Path -Leaf $packagePath
    Push-Location $packageFolder
    try {
        $packageVersion = node -p -e "require('./$packageName').version"
        return $packageVersion
    }
    finally {
        Pop-Location
    }
}

function GetEmitterDependencyVersion([string]$packagePath) {
    $matchString = "`"$emitterName`": `"(.*?)`""
    If ((Get-Content -Raw $packagePath) -match $matchString) {
        return $Matches[1]
    }
}

function NpmInstallAtRoot() {
    $root = Resolve-Path "$PSScriptRoot/../../.."
    Push-Location $root
    try {
        #default to root/eng/emitter-package.json but you can override by writing
        #Get-${Language}-EmitterPackageJsonPath in your Language-Settings.ps1
        $replacementPackageJson = "$PSScriptRoot/../../emitter-package.json"
        if (Test-Path "Function:$GetEmitterPackageJsonPathFn") {
            $replacementPackageJson = &$GetEmitterPackageJsonPathFn
        }

        $replacementVersion = GetEmitterDependencyVersion $replacementPackageJson
        Write-Host "Replacement emitter version: $replacementVersion"

        $installedPath = Join-Path $root "node_modules" $emitterName "package.json"
        Write-Host "Checking installed emitter at $installedPath"
        if (Test-Path $installedPath) {
            $installedVersion = GetNpmPackageVersion $installedPath
            Write-Host "Installed emitter version: $installedVersion"

            if ($installedVersion -eq $replacementVersion) {
                Write-Host "Emitter already installed. Skip installing."
                return
            }
        }

        Write-Host "Installing package at"(Get-Location)

        if (Test-Path "node_modules") {
            Write-Host "Remove existing node_modules at"(Get-Location)
            Remove-Item -Path "node_modules" -Force -Recurse
        }

        $hasPackageFile = Test-Path "package.json"

        $npmInstallCommand = "npm install --prefix $root $emitterName@$replacementVersion --no-package-lock --omit=dev"
        Write-Host($npmInstallCommand)
        Invoke-Expression $npmInstallCommand

        if ($hasPackageFile) {
            git restore package.json
        }
        else {
            rm package.json
        }

        if ($LASTEXITCODE) { exit $LASTEXITCODE }
    }
    finally {
        Pop-Location
    }
}

function NpmInstallForProject([string]$workingDirectory) {
    Push-Location $workingDirectory
    try {
        $currentDur = Resolve-Path "."
        Write-Host "Generating from $currentDur"

        if (Test-Path "package.json") {
            Remove-Item -Path "package.json" -Force
        }

        if (Test-Path ".npmrc") {
            Remove-Item -Path ".npmrc" -Force
        }

        if (Test-Path "node_modules") {
            Remove-Item -Path "node_modules" -Force -Recurse
        }

        if (Test-Path "package-lock.json") {
            Remove-Item -Path "package-lock.json" -Force
        }

        NpmInstallAtRoot
    }
    finally {
        Pop-Location
    }
}

$resolvedProjectDirectory = Resolve-Path $ProjectDirectory
$emitterName = &$GetEmitterNameFn
$typespecConfigurationFile = Resolve-Path "$ProjectDirectory/tsp-location.yaml"

Write-Host "Reading configuration from $typespecConfigurationFile"
$configuration = Get-Content -Path $typespecConfigurationFile -Raw | ConvertFrom-Yaml

$specSubDirectory = $configuration["directory"]
$innerFolder = Split-Path $specSubDirectory -Leaf

$tempFolder = "$ProjectDirectory/TempTypeSpecFiles"
$npmWorkingDir = Resolve-Path $tempFolder/$innerFolder
$mainTypeSpecFile = If (Test-Path "$npmWorkingDir/client.*") { Resolve-Path "$npmWorkingDir/client.*" } Else { Resolve-Path "$npmWorkingDir/main.*"}

try {
    Push-Location $npmWorkingDir
    NpmInstallForProject $npmWorkingDir

    if ($LASTEXITCODE) { exit $LASTEXITCODE }

    if (Test-Path "Function:$GetEmitterAdditionalOptionsFn") {
        $emitterAdditionalOptions = &$GetEmitterAdditionalOptionsFn $resolvedProjectDirectory
        if ($emitterAdditionalOptions.Length -gt 0) {
            $emitterAdditionalOptions = " $emitterAdditionalOptions"
        }
    }
    $typespecCompileCommand = "npx tsp compile $mainTypeSpecFile --emit $emitterName$emitterAdditionalOptions"
    if ($typespecAdditionalOptions) {
        $options = $typespecAdditionalOptions.Split(";");
        foreach ($option in $options) {
            $typespecCompileCommand += " --option $emitterName.$option"
        }
    }
    Write-Host($typespecCompileCommand)
    Invoke-Expression $typespecCompileCommand

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}

$shouldCleanUp = $configuration["cleanup"] ?? $true
if ($shouldCleanUp) {
    Remove-Item $tempFolder -Recurse -Force
}

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/../common/scripts/Helpers/PSModule-Helpers.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

function AddSparseCheckoutPath([string]$subDirectory) {
    $file = ".git/info/sparse-checkout"
    if (!(Test-Path $file) -or !((Get-Content $file).Contains($subDirectory))) {
        Write-Output $subDirectory >> .git/info/sparse-checkout
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
        npm install "@azure-tools/cadl-csharp"
        if ($LASTEXITCODE) { exit $LASTEXITCODE }
    }
    finally {
        Pop-Location
    }
}

function CopySpecToProjectIfNeeded([string]$pullResult, [string]$specCloneRoot, [string]$mainSpecDir, [string]$dest, [string[]]$specAdditionalSubDirectories) {
    if (!($pullResult.Contains("Already up to date.")) && Test-Path $dest) {

        $source = "$specCloneRoot/$mainSpecDir"
        Write-Host "Copying spec from $source"
        Copy-Item -Path $source -Destination $dest -Recurse -Force
        foreach($additionalDir in $specAdditionalSubDirectories)
        {
            $source = "$specCloneRoot/$additionalDir"
            Write-Host "Copying spec from $source"
            Copy-Item -Path $source -Destination $dest -Recurse -Force
        }
    }
}

function UpdateSparseCheckoutFile([string]$mainSpecDir, [string[]]$specAdditionalSubDirectories) {
    AddSparseCheckoutPath $mainSpecDir
    foreach($subDir in $specAdditionalSubDirectories)
    {
        AddSparseCheckoutPath $subDir
    }
}

function InitializeSparseGitClone([string]$repo) {
    if (!(Test-Path ".git")) {
        git init
        if ($LASTEXITCODE) { exit $LASTEXITCODE }
        git remote add origin $repo
        if ($LASTEXITCODE) { exit $LASTEXITCODE }
        git config core.sparseCheckout true
        if ($LASTEXITCODE) { exit $LASTEXITCODE }
    }
}

function GetSpecCloneDir([string]$projectName) {
    Push-Location $ProjectDirectory
    try {
        $root = git rev-parse --show-toplevel
    }
    finally {
        Pop-Location
    }

    $sparseSpecCloneDir = "$root/../temp/$projectName"
    New-Item $sparseSpecCloneDir -Type Directory -Force | Out-Null
    $createResult = Resolve-Path $sparseSpecCloneDir
    return $createResult
}

$cadlConfigurationFile = Resolve-Path "$ProjectDirectory/src/cadl-location.yaml"
Write-Host "Reading configuration from $cadlConfigurationFile"
$configuration = Get-Content -Path $cadlConfigurationFile -Raw | ConvertFrom-Yaml

$pieces = $cadlConfigurationFile.Path.Replace("\","/").Split("/")
$projectName = $pieces[$pieces.Count - 3]

$specCloneDir = GetSpecCloneDir $projectName

Write-Host "Setting up sparse clone for $projectName"
Push-Location $specCloneDir.Path
try {
    InitializeSparseGitClone $configuration["repo"]

    $specSubDirectory = $configuration["directory"]
    UpdateSparseCheckoutFile $specSubDirectory $configuration["additionalDirectories"]

    $result = (git pull origin $configuration["commit"])
    Write-Host $result
}
finally {
    Pop-Location
}

$specDir = Resolve-Path "$specCloneDir/$specSubDirectory"

$tempCadlDir = "$ProjectDirectory/temp"
New-Item $tempCadlDir -Type Directory -Force | Out-Null
CopySpecToProjectIfNeeded `
    -pullResult $result `
    -specCloneRoot $specCloneDir `
    -mainSpecDir $specSubDirectory `
    -dest $tempCadlDir `
    -specAdditionalSubDirectories $configuration["additionalDirectories"]

$innerFolder = Split-Path $specDir -Leaf
NpmInstallForProject (Resolve-Path "$tempCadlDir/$innerFolder")

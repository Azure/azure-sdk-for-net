[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory
)

$ErrorActionPreference = "Stop"

function AddSparseCheckoutPath([string]$subDirectory, [string]$file) {
    if (!(Test-Path $file) -or !((Get-Content $file).Contains($subDirectory))) {
        Write-Output $subDirectory >> .git/info/sparse-checkout
    }
}

function NpmInstallForProject([string]$workingDirectory) {
    Push-Location $workingDirectory

    $currentDur = Resolve-Path "."
    Write-Host "Generating from $currentDur"
    if (Test-Path ".\package.json") {
        Remove-Item -Path ".\package.json" -Force
    }
    if (Test-Path ".\.npmrc") {
        Remove-Item -Path ".\.npmrc" -Force
    }
    npm install "@azure-tools/cadl-csharp"

    Pop-Location
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
    $sparseCheckoutFile = ".git/info/sparse-checkout"
    AddSparseCheckoutPath $mainSpecDir $sparseCheckoutFile
    foreach($subDir in $specAdditionalSubDirectories)
    {
        AddSparseCheckoutPath $subDir $sparseCheckoutFile
    }
}

function InitializeSparseGitClone([string]$repo) {
    if (!(Test-Path ".git")) {
        git init
        git remote add origin $repo
        git config core.sparseCheckout true
    }
}

function GetSpecCloneDir([string]$projectName) {
    Push-Location $ProjectDirectory
    $root = git rev-parse --show-toplevel
    Pop-Location
    $sparseSpecCloneDir = "$root/../temp/$projectName"
    New-Item $sparseSpecCloneDir -Type Directory -Force | Out-Null
    $createResult = Resolve-Path $sparseSpecCloneDir
    return $createResult
}

$cadlConfigurationFile = Resolve-Path "$ProjectDirectory/src/cadl-location.yaml"
Write-Host "Reading configuration from $cadlConfigurationFile"
$configuration = Get-Content -Path $cadlConfigurationFile -Raw | ConvertFrom-Yaml

$pieces = $cadlConfigurationFile.Path.Split("\")
$projectName = $pieces[$pieces.Count - 3]

$specCloneDir = GetSpecCloneDir $projectName

Write-Host "Setting up sparse clone for $projectName"
Push-Location $specCloneDir.Path
InitializeSparseGitClone $configuration["repo"]

$specSubDirectory = $configuration["directory"]
UpdateSparseCheckoutFile $specSubDirectory $configuration["additionalDirectories"]

$result = (git pull origin $configuration["commit"])
Write-Host $result
Pop-Location

$specDir = Resolve-Path "$specCloneDir/$specSubDirectory"

$tempCadlDir = "$ProjectDirectory/temp"
New-Item $tempCadlDir -Type Directory -Force | Out-Null
CopySpecToProjectIfNeeded $result $specCloneDir $specSubDirectory $tempCadlDir $configuration["additionalDirectories"]

$innerFolder = Split-Path $specDir -Leaf
NpmInstallForProject (Resolve-Path "$tempCadlDir\$innerFolder")

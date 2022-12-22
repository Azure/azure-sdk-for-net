[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/../common/scripts/Helpers/PSModule-Helpers.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
$sparseCheckoutFile = ".git/info/sparse-checkout"
$sdkGitRemoteAPI = "https://api.github.com/repos/Azure/azure-sdk-for-net/git/refs/heads/main"
$sdkGitRemote = "https://github.com/Azure/azure-sdk-for-net.git"

function GetLatestCommit() {
    $response =  Invoke-WebRequest $sdkGitRemoteAPI
    $responseContent = ConvertFrom-Json $([String]::new($response.Content))
    return $responseContent.object.sha
}

function GetProjectRelativePath() {
    $rootPath = Resolve-Path "$PSScriptRoot/../.."
    return [System.IO.Path]::GetRelativePath($rootPath, $ProjectDirectory).Replace("\","/")
}

function AddSparseCheckoutPath([string]$subDirectory) {
    if (!(Test-Path $sparseCheckoutFile) -or !((Get-Content $sparseCheckoutFile).Contains($subDirectory))) {
        Write-Output $subDirectory >> .git/info/sparse-checkout
    }
}

function CopySpecToProjectIfNeeded([string]$specCloneRoot, [string]$mainSpecDir, [string]$dest, [string[]]$specAdditionalSubDirectories) {
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

function UpdateSparseCheckoutFile([string]$mainSpecDir, [string[]]$specAdditionalSubDirectories) {
    AddSparseCheckoutPath $mainSpecDir
    foreach($subDir in $specAdditionalSubDirectories)
    {
        AddSparseCheckoutPath $subDir
    }
}

function GetGitRemoteValue([string]$repo) {
    Push-Location $ProjectDirectory
    $result = ""
    try {
        $gitRemotes = (git remote -v)
        foreach ($remote in $gitRemotes)
        {
            if ($remote.StartsWith("origin")) {
                if ($remote -match 'https://github.com/\S+[\.git]') {
                    $result = "https://github.com/$repo.git"
                    break
                } elseif ($remote -match "git@github.com:\S+[\.git]"){
                    $result = "git@github.com:$repo.git"
                    break
                } else {
                    throw "Unknown git remote format found: $remote"
                }
            }
        }
    }
    finally {
        Pop-Location
    }

    return $result
}

function InitializeSparseGitClone([string]$repo) {
    git clone --no-checkout --filter=tree:0 $repo .
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
    git sparse-checkout init
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
    Remove-Item $sparseCheckoutFile -Force
}

function GetSparseCloneDir([string]$projectName, [string]$repoName) {
    Push-Location $ProjectDirectory
    try {
        $root = git rev-parse --show-toplevel
    }
    finally {
        Pop-Location
    }

    $sparseSpecCloneDir = "$root/../sparse-spec/$repoName/$projectName"
    New-Item $sparseSpecCloneDir -Type Directory -Force | Out-Null
    $createResult = Resolve-Path $sparseSpecCloneDir
    return $createResult
}

$cadlConfigurationFile = Resolve-Path "$ProjectDirectory/src/cadl-location.yaml"
Write-Host "Reading configuration from $cadlConfigurationFile"
$configuration = Get-Content -Path $cadlConfigurationFile -Raw | ConvertFrom-Yaml

$pieces = $cadlConfigurationFile.Path.Replace("\","/").Split("/")
$projectName = $pieces[$pieces.Count - 3]

$specSubDirectory = $configuration["directory"]
if ( $configuration["repo"] -and $configuration["commit"]) {
    $specCloneDir = GetSparseCloneDir $projectName "spec"
    $gitRemoteValue = GetGitRemoteValue $configuration["repo"]

    Write-Host "Setting up sparse clone for $projectName at $specCloneDir"
    
    Push-Location $specCloneDir.Path
    try {
        if (!(Test-Path ".git")) {
            InitializeSparseGitClone $gitRemoteValue
            UpdateSparseCheckoutFile $specSubDirectory $configuration["additionalDirectories"]
        }
        git checkout $configuration["commit"]
    }
    finally {
        Pop-Location
    }
} elseif ( $configuration["spec-root-dir"] ) {
    $specCloneDir = $configuration["spec-root-dir"]
}


$tempCadlDir = "$ProjectDirectory/TempCadlFiles"
New-Item $tempCadlDir -Type Directory -Force | Out-Null
CopySpecToProjectIfNeeded `
    -specCloneRoot $specCloneDir `
    -mainSpecDir $specSubDirectory `
    -dest $tempCadlDir `
    -specAdditionalSubDirectories $configuration["additionalDirectories"]


# Download the existing SDK
$latestCommit = GetLatestCommit
if ($latestCommit) {
    $sdkCloneDir = GetSparseCloneDir $projectName "sdk"

    Write-Host "Setting up sparse clone for $projectName at $sdkCloneDir"

    Push-Location $sdkCloneDir.Path
    try {
        if (!(Test-Path ".git")) {
            InitializeSparseGitClone $sdkGitRemote
            AddSparseCheckoutPath (GetProjectRelativePath)
        }
        git checkout $latestCommit
    }
    finally {
        Pop-Location
    }
}


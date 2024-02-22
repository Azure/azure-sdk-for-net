[CmdletBinding()]
param (
    [parameter(Mandatory = $true)]
    [string]$EmitterPackageJsonPath,

    [parameter(Mandatory = $true)]
    [string]$OutputDirectory,

    [parameter(Mandatory = $false)]
    [string]$NpmrcPath,

    [parameter(Mandatory = $false)]
    [string]$LockFileName = "emitter-package-lock.json"
)

New-Item $OutputDirectory -ItemType Directory -ErrorAction SilentlyContinue | Out-Null
$OutputDirectory = Resolve-Path $OutputDirectory

$tempFile = New-TemporaryFile
Remove-Item $tempFile

# use a consistent folder name to avoid random package name in package-lock.json
Write-Host "Creating temporary folder $tempFile/emitter-consumer"
$tempFolder = New-Item "$tempFile/emitter-consumer" -ItemType Directory

if ($NpmrcPath) {
    Write-Host "Copy npmrc from $NpmrcPath to $tempFolder/.npmrc"
    Copy-Item $NpmrcPath "$tempFolder/.npmrc"
}

Push-Location $tempFolder

try {
    Write-Host "Copy $EmitterPackageJsonPath to $tempFolder/package.json"
    Copy-Item $EmitterPackageJsonPath "$tempFolder/package.json"

    Write-Host 'npm install --legacy-peer-deps'
    npm install --legacy-peer-deps

    if ($LASTEXITCODE) {
      Write-Error "npm install failed with exit code $LASTEXITCODE"
      exit $LASTEXITCODE
    }

    Write-Host '##[group]npm list --all'
    npm list --all
    Write-Host '##[endgroup]'

    $dest = Join-Path $OutputDirectory $LockFileName
    Write-Host "Copy package-lock.json to $dest"
    Copy-Item 'package-lock.json' $dest
}
finally {
    Pop-Location
}

Remove-Item $tempFolder -Recurse -Force

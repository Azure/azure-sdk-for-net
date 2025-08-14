#Requires -Version 7.0

<#
.SYNOPSIS
Update the http-client-csharp-mgmt package to reference the latest version of http-client-csharp.

.DESCRIPTION
This script updates the dependency version of @azure-typespec/http-client-csharp in the
http-client-csharp-mgmt package.json file and updates the corresponding NuGet version 
in eng/Packages.Data.props, then runs npm install to update the lock file.

.PARAMETER NewVersion
The new version of @azure-typespec/http-client-csharp to update to.

.PARAMETER RepoRoot
The root directory of the repository. Defaults to the current repository root.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string] $NewVersion,
    [string] $RepoRoot = (Get-Item $PSScriptRoot).Parent.Parent.FullName
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

. "$PSScriptRoot/../common/scripts/common.ps1"
Set-ConsoleEncoding

Write-Host "Updating http-client-csharp-mgmt to use version $NewVersion"

# Update the mgmt package.json dependency
$mgmtPackageJsonPath = Join-Path $RepoRoot "eng/packages/http-client-csharp-mgmt/package.json"
Write-Host "Updating dependency in $mgmtPackageJsonPath"

if (-not (Test-Path $mgmtPackageJsonPath)) {
    Write-Error "Could not find mgmt package.json at $mgmtPackageJsonPath"
}

# Read and update the package.json
$packageJsonContent = Get-Content $mgmtPackageJsonPath -Raw | ConvertFrom-Json

# Update the dependency version
if ($packageJsonContent.dependencies -and $packageJsonContent.dependencies.'@azure-typespec/http-client-csharp') {
    $oldVersion = $packageJsonContent.dependencies.'@azure-typespec/http-client-csharp'
    $packageJsonContent.dependencies.'@azure-typespec/http-client-csharp' = $NewVersion
    Write-Host "Updated dependency from $oldVersion to $NewVersion"
    
    # Write back to file with proper formatting
    $packageJsonContent | ConvertTo-Json -Depth 100 | Set-Content $mgmtPackageJsonPath -Encoding UTF8
    Write-Host "Updated $mgmtPackageJsonPath successfully"
} else {
    Write-Error "Could not find @azure-typespec/http-client-csharp dependency in $mgmtPackageJsonPath"
}

# Update eng/Packages.Data.props AzureGeneratorVersion
$packagesDataPropsPath = Join-Path $RepoRoot "eng/Packages.Data.props"
Write-Host "Updating AzureGeneratorVersion in $packagesDataPropsPath"

if (-not (Test-Path $packagesDataPropsPath)) {
    Write-Error "Could not find Packages.Data.props at $packagesDataPropsPath"
}

# Read the XML content
[xml]$packagesDataContent = Get-Content $packagesDataPropsPath

# Find and update the AzureGeneratorVersion property
$azureGeneratorVersionProperty = $packagesDataContent.Project.PropertyGroup | Where-Object { $_.AzureGeneratorVersion } | Select-Object -First 1

if ($azureGeneratorVersionProperty -and $azureGeneratorVersionProperty.AzureGeneratorVersion) {
    $oldNugetVersion = $azureGeneratorVersionProperty.AzureGeneratorVersion
    $azureGeneratorVersionProperty.AzureGeneratorVersion = $NewVersion
    Write-Host "Updated AzureGeneratorVersion from $oldNugetVersion to $NewVersion"
    
    # Save the updated XML
    $packagesDataContent.Save($packagesDataPropsPath)
    Write-Host "Updated $packagesDataPropsPath successfully"
} else {
    Write-Error "Could not find AzureGeneratorVersion property in $packagesDataPropsPath"
}

# Run npm install in the mgmt package directory to update the lock file
$mgmtPackageDir = Join-Path $RepoRoot "eng/packages/http-client-csharp-mgmt"
Push-Location $mgmtPackageDir
try {
    Write-Host "Running npm install in $mgmtPackageDir to update package-lock.json"
    Invoke-LoggedCommand "npm install"
    Write-Host "Successfully updated package-lock.json"
} finally {
    Pop-Location
}

Write-Host "Successfully updated http-client-csharp-mgmt package to version $NewVersion"
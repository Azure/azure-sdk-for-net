<#
.DESCRIPTION
This script checks AOT compatibility packages within the specified folder, limited to just the projects named in the ProjectNames param.

.PARAMETER PackageInfoFolder
The package info folder containing the JSON files with package metadata.

.PARAMETER ProjectNames
The comma-separated list of project names targeted for the current batch.

#>
param(
    [Parameter(Mandatory=$true)]
    [string]$PackageInfoFolder,
    [string]$ProjectNames
)

if (-not (Test-Path $PackageInfoFolder)) {
    Write-Error "Package info folder '$PackageInfoFolder' does not exist."
    exit 1
}

$projectNamesArray = @()
if ($ProjectNames) {
    $projectNamesArray = $ProjectNames.Split(',') | ForEach-Object { $_.Trim() }
}
else {
    Write-Error "ProjectNames parameter doesn't target any packages. Please provide a comma-separated list of project names."
    exit 0
}

$filteredPackages = Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -File `
    | ForEach-Object { Get-Content -Raw $_.FullName | ConvertFrom-Json  } `
    | Where-Object { $projectNamesArray.Contains($_.ArtifactName) }

$failedAotChecks = $false
foreach ($package in $filteredPackages) {
    Write-Host "Processing package: $($package.ArtifactName) and ci param value is $($package.CIParameters.CheckAOTCompat)"
    if ($package.CIParameters.CheckAOTCompat) {
        Write-Host "Running Check-AOT-Compatibility.ps1 for Package: $($package.ArtifactName) Service $($package.ServiceDirectory)"
        
        # Check if AOTTestInputs exists and has ExpectedWarningsFilePath, otherwise use "None"
        $expectedWarningsFilePath = "None"
        if ($package.CIParameters.AOTTestInputs -and $package.CIParameters.AOTTestInputs.ExpectedWarningsFilePath) {
            $expectedWarningsFilePath = $package.CIParameters.AOTTestInputs.ExpectedWarningsFilePath
        }
        
        & $PSScriptRoot/Check-AOT-Compatibility.ps1 `
            -PackageName $package.ArtifactName `
            -ServiceDirectory $package.ServiceDirectory `
            -ExpectedWarningsFilePath $expectedWarningsFilePath

        if ($LASTEXITCODE -ne 0) {
            $failedAotChecks = $true
        }
    }
}

if ($failedAotChecks) {
    Write-Error "AOT compatibility check failed for one or more packages."
    exit 1
}

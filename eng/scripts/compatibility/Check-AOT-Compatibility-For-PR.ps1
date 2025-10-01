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
    Write-Host "Processing package: $($package.ArtifactName)" -ForegroundColor Cyan
    Write-Host "  IsAotCompatibleClientLibrary: '$($package.IsAotCompatibleClientLibrary)'" -ForegroundColor White
    Write-Host "  CIParameters.CheckAOTCompat: '$($package.CIParameters.CheckAOTCompat)'" -ForegroundColor White
    # Check both old and new ways to determine if AOT compatibility check should run
    $shouldRunAotCheck = $package.CIParameters.CheckAOTCompat -eq $true -or $package.IsAotCompatibleClientLibrary -eq "true" -or $package.IsAotCompatibleClientLibrary -eq $true
    
    Write-Host "  Should run AOT check: $shouldRunAotCheck" -ForegroundColor $(if ($shouldRunAotCheck) { "Green" } else { "Yellow" })
    
    if ($shouldRunAotCheck) {
        
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

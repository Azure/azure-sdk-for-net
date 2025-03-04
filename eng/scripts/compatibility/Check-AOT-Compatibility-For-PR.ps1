param([string]$PackageInfoFolder = "C:/repo/azure-sdk-for-net/PackageInfo", [string]$ProjectNames = "Azure.Core")

if (-not (Test-Path $PackageInfoFolder)) {
    Write-Error "Package info folder '$PackageInfoFolder' does not exist."
    exit 1
}

$projectNamesArray = @()
if ($ProjectNames) {
    $projectNamesArray = $ProjectNames.Split(',') | ForEach-Object { $_.Trim() }
}

$filteredPackages = Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -File `
    | ForEach-Object { Get-Content -Raw $_.FullName | ConvertFrom-Json  } `
    | Where-Object { $projectNamesArray.Contains($_.ArtifactName) }

$failedAotChecks = $false
foreach ($package in $filteredPackages) {
    if ($package.CIParameters["CheckAOTCompat"]) {
        $aotDetails = $package.CIParameters["AOTArtifact"]
        & $PSScriptRoot/Check-AOT-Compatibility.ps1 `
            -ProjectName $package.ArtifactName `
            -ServiceDirectory $package.ServiceDirectory `
            -ExpectedWarningsFilePath $aotDetails["ExpectedWarningsFilePath"]
    }
}

if ($failedAotChecks) {
    Write-Error "AOT compatibility check failed for one or more packages."
    exit 1
}

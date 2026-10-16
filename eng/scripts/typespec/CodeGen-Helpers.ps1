#Requires -Version 7.0

function Get-NpmDependencyVersion([string]$PackageJsonPath, [string]$PackageName, [switch]$DependenciesOnly) {
    $json = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json -AsHashtable
    $dependencies = $json["dependencies"]
    $peerDependencies = $json["peerDependencies"]
    $version = if ($dependencies) { $dependencies[$PackageName] }
    if (-not $version -and -not $DependenciesOnly -and $peerDependencies) {
        $version = $peerDependencies[$PackageName]
    }
    return $version
}

function Get-PackageJsonVersion([string]$PackageJsonPath) {
    $json = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json
    return $json.version
}

function Assert-VersionNotNewerThanApproved(
    [string]$Name,
    [string]$Version,
    [string]$ApprovedVersion,
    [string]$ApprovedVersionPath
) {
    try {
        $current = [System.Management.Automation.SemanticVersion]::new($Version)
        $approved = [System.Management.Automation.SemanticVersion]::new($ApprovedVersion)
    }
    catch {
        throw "Unable to compare $Name version '$Version' with approved version '$ApprovedVersion': $($_.Exception.Message)"
    }

    if ($current.CompareTo($approved) -gt 0) {
        throw "$Name version '$Version' is newer than the approved version '$ApprovedVersion' in '$ApprovedVersionPath'. Wait for the approved emitter package descriptor to be updated before advancing this dependency."
    }
}

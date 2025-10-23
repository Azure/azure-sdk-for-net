# Automation-Update-Metadata.ps1
# This script is used to update metadata for the Azure SDK automation process

param(
    [Parameter(Mandatory = $true)]
    [string]$sdkRepoPath,  # Absolute path to the root folder of the local SDK repository.
    
    [Parameter(Mandatory = $true)]
    [string]$packagePath   # Absolute path to the root folder of the local SDK project.
)

# Step 1: Resolve both paths to absolute paths
try {
    $resolvedPackage = Resolve-Path -Path $packagePath -ErrorAction Stop
    $fullPackagePath = $resolvedPackage.ProviderPath
} catch {
    # If it's not resolvable (e.g., path doesn't exist), fall back to raw input
    $fullPackagePath = $packagePath
}

try {
    $resolvedRepo = Resolve-Path -Path $sdkRepoPath -ErrorAction Stop
    $fullRepoPath = $resolvedRepo.ProviderPath
} catch {
    $fullRepoPath = $sdkRepoPath
}

# Step 2: Remove repo root from package path to get relative path
$fullRepoPath = $fullRepoPath.TrimEnd('\', '/')
if (-not $fullPackagePath.StartsWith($fullRepoPath, [System.StringComparison]::OrdinalIgnoreCase)) {
    Write-Error "Package path '$fullPackagePath' does not start with repo path '$fullRepoPath'"
    exit 1
}

$relativePath = $fullPackagePath.Substring($fullRepoPath.Length).TrimStart('\', '/')

# Step 3: Split relative path and find 'sdk' segment
$parts = $relativePath -split '[\\/]+'

$sdkIndex = $parts.IndexOf('sdk')
if ($sdkIndex -lt 0 -or $sdkIndex -ge ($parts.Count - 1)) {
    Write-Error "The relative path does not contain a valid 'sdk' segment: $relativePath"
    exit 1
}

# Extract everything after 'sdk'
$slugParts = $parts[($sdkIndex + 1)..($parts.Count - 1)]
$packagePath = ($slugParts -join '/')

Write-Host "Extracted package path: $packagePath"

# Call Export-API.ps1 script with the package path
$exportApiScript = Join-Path $sdkRepoPath "eng" "scripts" "Export-API.ps1"
Write-Host "Calling Export-API.ps1 with package path: $packagePath"

try {
    & $exportApiScript $packagePath
    Write-Host "Export-API.ps1 completed successfully"
} catch {
    Write-Error "Failed to execute Export-API.ps1: $($_.Exception.Message)"
    exit 1
}

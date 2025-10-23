# Automation-Update-Metadata.ps1
# This script is used to update metadata for the Azure SDK automation process

param(
    [Parameter(Mandatory = $true)]
    [string]$sdkRepoPath,  # Absolute path to the root folder of the local SDK repository.
    
    [Parameter(Mandatory = $true)]
    [string]$packagePath   # Absolute path to the root folder of the local SDK project.
)

# Function to normalize paths for cross-platform compatibility
function Normalize-Path {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path
    )
    
    # Convert all separators to platform-specific directory separator and trim trailing separator
    return $Path.Replace('/', [System.IO.Path]::DirectorySeparatorChar).Replace('\', [System.IO.Path]::DirectorySeparatorChar).TrimEnd([System.IO.Path]::DirectorySeparatorChar)
}

# Extract service name from package path
# Normalize paths to use consistent separators
$normalizedSdkRepoPath = Normalize-Path $sdkRepoPath
$normalizedPackagePath = Normalize-Path $packagePath

# Remove the SDK repo path from the package path
if (-not $normalizedPackagePath.StartsWith($normalizedSdkRepoPath, [System.StringComparison]::OrdinalIgnoreCase)) {
    Write-Error "Package path '$packagePath' does not start with SDK repo path '$sdkRepoPath'"
    exit 1
}

$relativePath = $normalizedPackagePath.Substring($normalizedSdkRepoPath.Length).TrimStart([System.IO.Path]::DirectorySeparatorChar)

# Split the relative path by directory separators
$pathSegments = $relativePath -split [regex]::Escape([System.IO.Path]::DirectorySeparatorChar) | Where-Object { $_ -ne "" }

# The service name is the second segment (after 'sdk')
# Expected format: sdk/<serviceName>/<packageName>
if ($pathSegments.Count -ge 2 -and $pathSegments[0] -eq "sdk") {
    $serviceName = $pathSegments[1]
    Write-Host "Extracted service name: $serviceName"
} else {
    $separator = [System.IO.Path]::DirectorySeparatorChar
    Write-Error "Invalid package path format. Expected: <sdkRepoPath>${separator}sdk${separator}<serviceName>${separator}<packageName>"
    exit 1
}

# Call Export-API.ps1 script with the service name
$exportApiScript = Join-Path $sdkRepoPath "eng" "scripts" "Export-API.ps1"
Write-Host "Calling Export-API.ps1 with service name: $serviceName"

try {
    & $exportApiScript $serviceName
    Write-Host "Export-API.ps1 completed successfully"
} catch {
    Write-Error "Failed to execute Export-API.ps1: $($_.Exception.Message)"
    exit 1
}

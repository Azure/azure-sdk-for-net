# Automation-Update-Metadata.ps1
# This script is used to update metadata for the Azure SDK automation process

param(
    [Parameter(Mandatory = $true)]
    [string]$sdkRepoPath,  # Absolute path to the root folder of the local SDK repository.
    
    [Parameter(Mandatory = $true)]
    [string]$packagePath   # Absolute path to the root folder of the local SDK project.
)

# Step 1: Find the csproj file in the src directory
$srcPath = Join-Path $packagePath "src"
$csprojFile = Get-ChildItem -Path $srcPath -Filter "*.csproj" | Select-Object -First 1

Write-Host "Found csproj file: $($csprojFile.Name)"

# Step 2: Get ServiceDirectory from csproj file using dotnet msbuild
$csprojPath = $csprojFile.FullName
$serviceName = (dotnet msbuild /t:GetPackageInfo /getProperty:ServiceDirectory "$csprojPath" 2>&1 | Select-Object -Last 1).Trim()

Write-Host "Service name: $serviceName"

# Step 3: Extract namespace name from package path
$parts = $packagePath -split '[\\/]+'
$namespaceName = $parts[-1]  # Last segment is the namespace name

Write-Host "Namespace name: $namespaceName"

# Step 4: Call Export-API.ps1 with serviceName/namespaceName
$exportApiScript = Join-Path $sdkRepoPath "eng" "scripts" "Export-API.ps1"
$apiPath = Join-Path $serviceName $namespaceName
Write-Host "Calling Export-API.ps1 $apiPath"

try {
    & $exportApiScript $apiPath
    Write-Host "Export-API.ps1 completed successfully"
} catch {
    Write-Error "Failed to execute Export-API.ps1: $($_.Exception.Message)"
    exit 1
}

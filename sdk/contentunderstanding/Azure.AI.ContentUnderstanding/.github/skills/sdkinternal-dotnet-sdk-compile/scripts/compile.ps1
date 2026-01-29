# Compile Azure SDK for .NET
# Usage: .\compile.ps1 [-Configuration Debug|Release]

param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug"
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

# Find SDK root directory
$sdkDir = Get-Location
$srcProject = Join-Path $sdkDir "src" "*.csproj"
$testsProject = Join-Path $sdkDir "tests" "*.csproj"

# Check if we're in SDK module directory
if (-not (Test-Path $srcProject)) {
    Write-ColorOutput "Error: No src/*.csproj found. Are you in the SDK module directory?" "Red"
    exit 1
}

Write-ColorOutput "Building Azure SDK for .NET..." "Yellow"
Write-ColorOutput "Configuration: $Configuration" "Cyan"

# Build main library
Write-ColorOutput "`nBuilding main library..." "Yellow"
$srcFiles = Get-ChildItem $srcProject
foreach ($proj in $srcFiles) {
    Write-ColorOutput "  Building: $($proj.Name)" "Cyan"
    dotnet build $proj.FullName -c $Configuration
    if ($LASTEXITCODE -ne 0) {
        Write-ColorOutput "Build failed for $($proj.Name)" "Red"
        exit $LASTEXITCODE
    }
}

# Build test project if exists
if (Test-Path $testsProject) {
    Write-ColorOutput "`nBuilding test project..." "Yellow"
    $testFiles = Get-ChildItem $testsProject
    foreach ($proj in $testFiles) {
        Write-ColorOutput "  Building: $($proj.Name)" "Cyan"
        dotnet build $proj.FullName -c $Configuration
        if ($LASTEXITCODE -ne 0) {
            Write-ColorOutput "Build failed for $($proj.Name)" "Red"
            exit $LASTEXITCODE
        }
    }
}

Write-ColorOutput "`nBuild completed successfully!" "Green"

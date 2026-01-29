# Load environment variables from .env file
# Usage: . .\load-env.ps1 [path\to\.env]

param(
    [string]$EnvFile = ".env"
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

# Find .env file
if (-not (Test-Path $EnvFile)) {
    # Try to find .env in parent directories
    $dir = Get-Location
    while ($dir -ne $null) {
        $testPath = Join-Path $dir ".env"
        if (Test-Path $testPath) {
            $EnvFile = $testPath
            break
        }
        $dir = Split-Path $dir -Parent
    }
}

if (-not (Test-Path $EnvFile)) {
    Write-ColorOutput "Error: .env file not found" "Red"
    Write-ColorOutput "Create a .env file with your Azure credentials"
    exit 1
}

Write-ColorOutput "Loading environment from: $EnvFile" "Yellow"

# Load variables
Get-Content $EnvFile | ForEach-Object {
    $line = $_.Trim()

    # Skip comments and empty lines
    if ($line -match "^#" -or [string]::IsNullOrEmpty($line)) {
        return
    }

    # Parse key=value
    if ($line -match "^([^=]+)=(.*)$") {
        $key = $matches[1].Trim()
        $value = $matches[2].Trim()

        # Remove surrounding quotes
        $value = $value -replace '^["'']|["'']$', ''

        # Set environment variable
        [Environment]::SetEnvironmentVariable($key, $value, "Process")
        Write-ColorOutput "  Loaded: $key" "Green"
    }
}

Write-ColorOutput "Environment loaded successfully!" "Green"

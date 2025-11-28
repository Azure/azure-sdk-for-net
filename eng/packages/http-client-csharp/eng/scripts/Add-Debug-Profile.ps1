#Requires -Version 7.0

<#
.SYNOPSIS
    Script to add launch settings profile for easy debugging of TypeSpec generation

.DESCRIPTION
    This script:
    1. Ensures tsp-client dependencies are installed locally in eng/common/tsp-client
    2. Runs tsp-client sync in the target SDK directory using the local installation
    3. Runs tsp-client generate --save-inputs to create tspCodeModel.json
    4. Reads the emitter configuration from tsp-location.yaml to determine the generator
    5. Adds a new debug profile to launchSettings.json that targets the DLL
    
    The script automatically detects which emitter/generator to use by:
    - First checking tsp-location.yaml for the configured emitter package
    - Falling back to auto-detection based on SDK path if tsp-location.yaml is not found
      (e.g., paths containing "ResourceManager" use ManagementClientGenerator)

.PARAMETER SdkDirectory
    Path to the target SDK service directory

.EXAMPLE
    .\Add-Debug-Profile.ps1 -SdkDirectory "C:\path\to\azure-sdk-for-net\sdk\storage\Azure.Storage.Blobs"
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$SdkDirectory
)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

# Helper function to run commands and get output
function Invoke-Command-Safe {
    param(
        [string]$Command,
        [string]$WorkingDirectory = $null
    )

    try {
        $originalLocation = Get-Location
        if ($WorkingDirectory) {
            Set-Location $WorkingDirectory
        }

        $result = Invoke-Expression $Command 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "Command failed with exit code $LASTEXITCODE : $result"
        }
        # Write output to console
        $result | ForEach-Object { Write-Host $_ }
        return $result
    }
    catch {
        throw "Command failed: $Command `n$($_.Exception.Message)"
    }
    finally {
        if ($WorkingDirectory) {
            Set-Location $originalLocation
        }
    }
}

# Helper function to check if a command exists
function Test-CommandExists {
    param([string]$Command)

    try {
        Get-Command $Command -ErrorAction Stop | Out-Null
        return $true
    }
    catch {
        return $false
    }
}


# Get the path to the local tsp-client installation directory
function Get-TspClientDirectory {
    $repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..' '..')
    return Join-Path $repoRoot 'eng' 'common' 'tsp-client'
}

# Ensure tsp-client dependencies are installed locally
function Install-TspClient {
    $tspClientDir = Get-TspClientDirectory

    Write-Host "Installing tsp-client dependencies in $tspClientDir..." -ForegroundColor Yellow

    if (-not (Test-Path $tspClientDir)) {
        throw "tsp-client directory not found at $tspClientDir"
    }

    Invoke-Command-Safe "npm ci" -WorkingDirectory $tspClientDir
    Write-Host "tsp-client dependencies installed successfully." -ForegroundColor Green
}

# Check if local tsp-client is available
function Test-TspClientInstalled {
    $tspClientDir = Get-TspClientDirectory

    try {
        Invoke-Command-Safe "npm exec --prefix `"$tspClientDir`" --no -- tsp-client --version" | Out-Null
        return $true
    }
    catch {
        return $false
    }
}

# Run tsp-client commands in the target directory
function Invoke-TspClientCommands {
    param([string]$SdkPath)

    $tspClientDir = Get-TspClientDirectory

    Write-Host "Running tsp-client commands in $SdkPath using local installation..." -ForegroundColor Cyan
    Write-Host "Using tsp-client from: $tspClientDir" -ForegroundColor Gray

    try {
        Write-Host "Running tsp-client sync..." -ForegroundColor Yellow
        try {
            Invoke-Command-Safe "npx --prefix `"$tspClientDir`" --no -- tsp-client sync --no-prompt" -WorkingDirectory $SdkPath
        }
        catch {
            Write-Warning "tsp-client sync failed. This might be expected if the directory is not a proper TypeSpec SDK directory."
            Write-Warning "Error: $($_.Exception.Message)"
        }

        Write-Host "Running tsp-client generate --save-inputs..." -ForegroundColor Yellow
        Invoke-Command-Safe "npx --prefix `"$tspClientDir`" --no -- tsp-client generate --save-inputs --no-prompt" -WorkingDirectory $SdkPath

        Write-Host "tsp-client commands completed." -ForegroundColor Green
    }
    catch {
        Write-Error "Failed to run tsp-client commands: $($_.Exception.Message)"
        throw
    }
}

# Get the path to launchSettings.json
function Get-LaunchSettingsPath {
    $packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
    return Join-Path $packageRoot 'generator' 'Azure.Generator' 'src' 'Properties' 'launchSettings.json'
}

function Set-LaunchSettings {
  param([object]$LaunchSettings)

  $packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
  $launchSettingsPath = Join-Path $packageRoot 'generator' 'Azure.Generator' 'src' 'Properties' 'launchSettings.json'
  $content = $LaunchSettings | ConvertTo-Json | ForEach-Object { ($_ -replace "`r`n", "`n") + "`n" }
  Set-Content $launchSettingsPath $content -NoNewLine
}

# Read and parse launchSettings.json
function Get-LaunchSettings {
    $launchSettingsPath = Get-LaunchSettingsPath
    $content = Get-Content $launchSettingsPath -Raw
    return $content | ConvertFrom-Json
}

# Generate a profile name from the SDK directory
function Get-ProfileName {
    param([string]$SdkPath)

    $dirName = Split-Path $SdkPath -Leaf
    # Replace invalid characters and make it a valid profile name
    return $dirName -replace '[^a-zA-Z0-9\-_.]', '-'
}

# Read and parse tsp-location.yaml to get emitter configuration
function Get-EmitterFromTspLocation {
    param([string]$SdkPath)

    $tspLocationPath = Join-Path $SdkPath "tsp-location.yaml"

    if (-not (Test-Path $tspLocationPath)) {
        Write-Host "tsp-location.yaml not found at $tspLocationPath" -ForegroundColor Yellow
        return $null
    }

    try {
        # Read the YAML file
        $content = Get-Content $tspLocationPath -Raw

        # Parse emitterPackageJsonPath field to determine emitter type
        # Format: emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json"
        # or: emitterPackageJsonPath: eng/http-client-csharp-emitter-package.json
        if ($content -match 'emitterPackageJsonPath:\s*["'']?[^"''\n]*azure-typespec-http-client-csharp-mgmt[^"''\n]*["'']?') {
            return "@azure-typespec/http-client-csharp-mgmt"
        }
        elseif ($content -match 'emitterPackageJsonPath:\s*["'']?[^"''\n]*azure-typespec-http-client-csharp[^"''\n]*["'']?') {
            return "@azure-typespec/http-client-csharp"
        }
        elseif ($content -match 'emitterPackageJsonPath:\s*["'']?[^"''\n]*http-client-csharp[^"''\n]*["'']?') {
            return "@typespec/http-client-csharp"
        }
        else {
            Write-Host "Could not determine emitter from tsp-location.yaml" -ForegroundColor Yellow
            return $null
        }
    }
    catch {
        Write-Warning "Failed to parse tsp-location.yaml: $($_.Exception.Message)"
        return $null
    }
}

# Map emitter package name to generator name and package name
function Get-GeneratorConfig {
    param(
        [string]$EmitterPackage
    )

    # EmitterPackage must be set
    if (-not $EmitterPackage) {
        throw "EmitterPackage must be specified. Could not find emitter configuration in tsp-location.yaml"
    }

    # Map emitter package to generator configuration
    switch ($EmitterPackage) {
        "@azure-typespec/http-client-csharp-mgmt" {
            return @{
                PackageName = "http-client-csharp-mgmt"
                GeneratorName = "ManagementClientGenerator"
                ScopeName = "@azure-typespec"
            }
        }
        "@typespec/http-client-csharp" {
            return @{
                PackageName = "http-client-csharp"
                GeneratorName = "ScmCodeModelGenerator"
                ScopeName = "@typespec"
            }
        }
        "@azure-typespec/http-client-csharp" {
            return @{
                PackageName = "http-client-csharp"
                GeneratorName = "AzureClientGenerator"
                ScopeName = "@azure-typespec"
            }
        }
    }
}

# Rebuild the local generator solution to ensure fresh DLLs
function Build-LocalGeneratorSolution {
    param(
        [string]$PackageRoot,
        [bool]$IsMgmt = $false
    )

    $solutionPath = Join-Path $PackageRoot "generator/Azure.Generator.sln"

    if (-not (Test-Path $solutionPath)) {
        Write-Warning "Solution file not found at: $solutionPath"
        return $false
    }

    Write-Host "Rebuilding local generator solution to ensure fresh DLLs..." -ForegroundColor Yellow

    try {
        $result = & dotnet build $solutionPath --configuration Release 2>&1
        if ($LASTEXITCODE -ne 0) {
            Write-Warning "Build failed with exit code $LASTEXITCODE : $result"
            return $false
        }
        Write-Host "Azure.Generator build completed successfully." -ForegroundColor Green

        # If this is a management library, also build the mgmt generator
        if ($IsMgmt) {
            $mgmtPackageRoot = Join-Path (Split-Path $PackageRoot -Parent) "http-client-csharp-mgmt"
            $mgmtSolutionPath = Join-Path $mgmtPackageRoot "generator/Azure.Generator.Management.sln"

            if (Test-Path $mgmtSolutionPath) {
                Write-Host "Rebuilding management generator solution..." -ForegroundColor Yellow
                $result = & dotnet build $mgmtSolutionPath --configuration Release 2>&1
                if ($LASTEXITCODE -ne 0) {
                    Write-Warning "Management build failed with exit code $LASTEXITCODE : $result"
                    return $false
                }
                Write-Host "Management generator build completed successfully." -ForegroundColor Green
            }
            else {
                Write-Warning "Management solution file not found at: $mgmtSolutionPath"
            }
        }

        return $true
    }
    catch {
        Write-Warning "Build failed: $($_.Exception.Message)"
        return $false
    }
}

# Copy local generator DLLs to the SDK's node_modules location
function Copy-LocalGeneratorDlls {
    param(
        [string]$SdkPath,
        [string]$PackageName,
        [string]$ScopeName
    )

    $scriptDir = Split-Path $MyInvocation.PSCommandPath -Parent
    $packageRoot = Split-Path (Split-Path $scriptDir -Parent) -Parent
    $sourceDir = Join-Path $packageRoot "dist/generator"

    $targetDir = Join-Path $SdkPath "TempTypeSpecFiles/node_modules/$ScopeName/$PackageName/dist/generator"

    # Check if this is a management library
    $isMgmt = $PackageName -eq "http-client-csharp-mgmt"

    # Rebuild the solution first to ensure fresh DLLs
    $buildSuccess = Build-LocalGeneratorSolution $packageRoot $isMgmt
    if (-not $buildSuccess) {
        Write-Warning "Build failed, but continuing with existing DLLs..."
    }

    # Base DLLs to always copy
    $dllsToCopy = @(
        "Azure.Generator.dll",
        "Microsoft.TypeSpec.Generator.dll",
        "Microsoft.TypeSpec.Generator.ClientModel.dll",
        "Microsoft.TypeSpec.Generator.Input.dll"
    )

    # If this is a management library, also copy the management DLL and its dependencies
    if ($isMgmt) {
        $mgmtPackageRoot = Join-Path (Split-Path $packageRoot -Parent) "http-client-csharp-mgmt"
        $mgmtSourceDir = Join-Path $mgmtPackageRoot "dist/generator"

        $dllsToCopy += "Azure.Generator.Management.dll"

        Write-Host "Copying management generator DLLs from $mgmtSourceDir..." -ForegroundColor Yellow
    }

    Write-Host "Copying local generator DLLs to $targetDir..." -ForegroundColor Yellow

    foreach ($dll in $dllsToCopy) {
        # Determine source path based on DLL name
        if ($dll -eq "Azure.Generator.Management.dll" -and $isMgmt) {
            $mgmtPackageRoot = Join-Path (Split-Path $packageRoot -Parent) "http-client-csharp-mgmt"
            $mgmtSourceDir = Join-Path $mgmtPackageRoot "dist/generator"
            $sourcePath = Join-Path $mgmtSourceDir $dll
        }
        else {
            $sourcePath = Join-Path $sourceDir $dll
        }

        $targetPath = Join-Path $targetDir $dll

        if (Test-Path $sourcePath) {
            Copy-Item $sourcePath $targetPath -Force
            Write-Host "  Copied: $dll" -ForegroundColor Green
        } else {
            Write-Warning "Source DLL not found: $sourcePath"
        }
    }

    Write-Host "DLL copying completed." -ForegroundColor Green
}

# Add or update a debug profile in launchSettings.json
function Add-DebugProfile {
    param(
        [string]$SdkPath
    )

    $launchSettings = Get-LaunchSettings
    $profileName = Get-ProfileName $SdkPath
    $resolvedSdkPath = Resolve-Path $SdkPath

    # Try to read emitter configuration from tsp-location.yaml
    $emitterPackage = Get-EmitterFromTspLocation $SdkPath

    # Get generator configuration based on emitter package
    $generatorConfig = Get-GeneratorConfig $emitterPackage
    $packageName = $generatorConfig.PackageName
    $generatorName = $generatorConfig.GeneratorName
    $scopeName = $generatorConfig.ScopeName

    # Copy local DLLs to the node_modules location
    Copy-LocalGeneratorDlls $resolvedSdkPath $packageName $scopeName

    # Use the node_modules DLL path
    $dllPath = "`"$resolvedSdkPath/TempTypeSpecFiles/node_modules/$scopeName/$packageName/dist/generator/Microsoft.TypeSpec.Generator.dll`""

    # Create the new profile
    $newProfile = @{
        commandLineArgs = "$dllPath `"$resolvedSdkPath`" -g $generatorName"
        commandName = "Executable"
        executablePath = "dotnet"
    }

    # Add or update the profile
    $launchSettings.profiles | Add-Member -Name $profileName -Value $newProfile -MemberType NoteProperty -Force

    Set-LaunchSettings $launchSettings

    Write-Host "Added debug profile '$profileName' to launchSettings.json" -ForegroundColor Green
    Write-Host "Profile configuration:" -ForegroundColor Cyan
    Write-Host "  - Executable: dotnet" -ForegroundColor White
    Write-Host "  - Arguments: $dllPath `"$resolvedSdkPath`" -g $generatorName" -ForegroundColor White
    Write-Host "  - Generator: $generatorName" -ForegroundColor White
    Write-Host "  - Package: $packageName" -ForegroundColor White
    Write-Host "  - Emitter: $emitterPackage (from tsp-location.yaml)" -ForegroundColor White
    return $profileName
}

# Main execution
try {
    # Check if SDK directory exists
    $sdkPath = Resolve-Path $SdkDirectory -ErrorAction Stop

    # Check if npm is available
    if (-not (Test-CommandExists "npm")) {
        throw "npm is not installed or not in PATH"
    }

    Write-Host "Setting up debug profile for Azure SDK..." -ForegroundColor Cyan

    # Ensure tsp-client dependencies are installed locally
    if (-not (Test-TspClientInstalled)) {
        Write-Host "Local tsp-client is not available. Installing dependencies..." -ForegroundColor Yellow
        try {
            Install-TspClient
        }
        catch {
            Write-Warning "Failed to install tsp-client dependencies. You may need to run 'npm ci' manually in:"
            Write-Warning "$(Get-TspClientDirectory)"
            Write-Warning "Error: $($_.Exception.Message)"
        }
    }
    else {
        Write-Host "Local tsp-client is already available." -ForegroundColor Green
    }

    # Run tsp-client commands to set up the project
    $tspSuccess = Invoke-TspClientCommands -SdkPath $sdkPath -PackageName $packageName -ScopeName $scopeName
    if (-not $tspSuccess) {
        Write-Error "tsp-client commands failed. Cannot proceed with debug profile setup."
        throw "tsp-client generate did not complete successfully"
    }

    # Add debug profile
        $profileName = Add-DebugProfile $sdkPath

    Write-Host "`nSetup completed successfully!" -ForegroundColor Green
    Write-Host "You can now debug the '$profileName' profile in Visual Studio or VS Code." -ForegroundColor Cyan
}
catch {
    Write-Error "Error: $($_.Exception.Message)"
    exit 1
}
# Azure SDK for .NET Libraries Inventory Generator
#
# This script generates an inventory of libraries in the Azure SDK for .NET repository,
# categorizing them as data plane or management plane, and by the type of generator used
# (Swagger or TypeSpec).
#
# Usage:
#     powershell Library_Inventory.ps1 [-Json]
#
# Options:
#     -Json    Generate a JSON file with the inventory data

[CmdletBinding()]
Param (
    [switch]$Json
)

$EmitterMap = @{
    'eng/azure-typespec-http-client-csharp-emitter-package.json' = '@azure-typespec/http-client-csharp'
    'eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json' = '@azure-typespec/http-client-csharp-mgmt'
    'eng/http-client-csharp-emitter-package.json' = '@typespec/http-client-csharp'
}

function Test-MgmtLibrary {
    param([string]$Path)

    # Check if a library is a management plane library
    return ($Path -match "Azure\.ResourceManager" -or $Path -match "\.Management\.")
}

function Test-ProvisioningLibrary {
    param([string]$Path)

    # Check if a library is a provisioning library
    $libraryName = Split-Path $Path -Leaf
    return ($libraryName -match "^Azure\.Provisioning")
}

function Get-GeneratorType {
    param([string]$Path)

    # Identify if a library is generated using swagger or tsp.
    # Returns: "Swagger", a specific TypeSpec generator name, "TSP-Old", "Provisioning", or "No Generator"

    # Special case for Provisioning libraries which use a custom reflection-based generator
    if (Test-ProvisioningLibrary $Path) {
        return "Provisioning"
    }

    # Special case for Azure.AI.OpenAI which uses TypeSpec with new generator via special handling
    if ((Split-Path $Path -Leaf) -eq "Azure.AI.OpenAI" -and $Path -match "openai") {
        return "@typespec/http-client-csharp"
    }

    # First check for direct TypeSpec indicators
    $tspConfigPath = Join-Path $Path "src\tspconfig.yaml"
    $tspDir = Join-Path $Path "src\tsp"
    $tspFiles = Get-ChildItem -Path (Join-Path $Path "src") -Filter "*.tsp" -ErrorAction SilentlyContinue

    # Check for tsp-location.yaml files
    $tspLocationPaths = @()
    if (Test-Path $Path) {
        $tspLocationPaths = Get-ChildItem -Path $Path -Recurse -Filter "tsp-location.yaml" -ErrorAction SilentlyContinue | ForEach-Object { $_.FullName }
    }

    # If there's a tsp-location.yaml file and it contains emitterPackageJsonPath, extract the generator name
    foreach ($tspLocationPath in $tspLocationPaths) {
        try
        {
            $content = Get-Content $tspLocationPath -Raw -ErrorAction SilentlyContinue
            if ($content -and $content -match "emitterPackageJsonPath") {
                # Extract the emitterPackageJsonPath value
                if ($content -match 'emitterPackageJsonPath:\s*(?<val>"[^"]+"|[^,\s]+)\s*,?') {
                    $emitterPath = $matches['val'].Trim('"')

                    if ($EmitterMap.ContainsKey($emitterPath))
                    {
                        return $EmitterMap[$emitterPath]
                    }

                    # If we didn't match the known emitters, return TSP-Old
                    return "TSP-Old"
                }
            }
            else {
                # Found tsp-location.yaml but no emitterPackageJsonPath, it's using the old TypeSpec generator
                return "TSP-Old"
            }
        }
        catch {
            # Continue to next file if error
        }
    }

    if ((Test-Path $tspConfigPath) -or (Test-Path $tspDir) -or $tspFiles) {
        return "TSP-Old"
    }

    # Check autorest.md for generator information
    $autorestMdPath = Join-Path $Path "src\autorest.md"
    if (Test-Path $autorestMdPath) {
        # If autorest.md exists, assume it's a Swagger library
        return "Swagger"
    }

    # No autorest.md but Generated folder exists, assume Swagger
    if (Test-Path (Join-Path $Path "src\Generated")) {
        return "Swagger"
    }

    # If we couldn't identify a generator, it's "No Generator"
    return "No Generator"
}

function Test-HasTspLocation {
    param([string]$Path)

    # Check if the library has a tsp-location.yaml file
    $tspLocationFiles = Get-ChildItem -Path $Path -Recurse -Filter "tsp-location.yaml" -ErrorAction SilentlyContinue
    return ($tspLocationFiles.Count -gt 0)
}

function Get-SdkLibraries {
    param([string]$SdkRoot)

    # Scan all libraries in the sdk directory.

    $libraries = @()

    # Scan through all service directories
    $serviceDirs = Get-ChildItem -Path $SdkRoot -Directory -Force -ErrorAction SilentlyContinue
    foreach ($serviceDir in $serviceDirs) {
        # Look for library directories
        $libraryDirs = Get-ChildItem -Path $serviceDir.FullName -Directory -Force -ErrorAction SilentlyContinue
        foreach ($libraryDir in $libraryDirs) {
            # Skip directories that don't look like libraries
            if ($libraryDir.Name -in @("tests", "samples", "perf", "assets", "docs")) {
                continue
            }

            # Skip libraries that start with "Microsoft." or don't start with "Azure."
            if ($libraryDir.Name.StartsWith("Microsoft.") -or -not $libraryDir.Name.StartsWith("Azure.")) {
                continue
            }

            # If it has a /src directory or a csproj file, it's likely a library
            $srcPath = Join-Path $libraryDir.FullName "src"
            $csprojFiles = Get-ChildItem -Path $libraryDir.FullName -Filter "*.csproj" -ErrorAction SilentlyContinue

            if ((Test-Path $srcPath) -or $csprojFiles) {
                $libraryType = if (Test-MgmtLibrary $libraryDir.FullName) { "Management" } else { "Data Plane" }
                $generator = Get-GeneratorType $libraryDir.FullName
                $hasTspLocation = Test-HasTspLocation $libraryDir.FullName

                # Calculate relative path from parent of SDK root (to include 'sdk' prefix)
                $repoRoot = Split-Path $SdkRoot -Parent
                $relativePath = $libraryDir.FullName.Substring($repoRoot.Length + 1)  # +1 to remove leading separator
                $relativePath = $relativePath -replace "\\", "/"  # Normalize to forward slashes

                $libraries += [PSCustomObject]@{
                    service = $serviceDir.Name
                    library = $libraryDir.Name
                    path = $relativePath
                    type = $libraryType
                    generator = $generator
                    hasTspLocation = $hasTspLocation
                }
            }
        }
    }

    return $libraries
}

function New-MarkdownReport {
    param([array]$Libraries)

    # Generate a markdown report from the library inventory.

    # Define exclusion list for generator types that are not TypeSpec new emitters
    $excludedGenerators = @("Swagger", "TSP-Old", "No Generator", "Provisioning")

    # Group by type and generator
    $mgmtLibraries = $Libraries | Where-Object { $_.type -eq "Management" }
    $dataLibraries = $Libraries | Where-Object { $_.type -eq "Data Plane" }
    $provisioningLibraries = $Libraries | Where-Object { $_.generator -eq "Provisioning" }
    $noGenerator = $Libraries | Where-Object { $_.generator -eq "No Generator" }
    
    # Calculate the count of Data Plane libraries excluding provisioning
    $dataPlaneNonProvisioning = $dataLibraries | Where-Object { $_.generator -ne "Provisioning" }

    # Count libraries by generator type (excluding provisioning from data plane)
    $mgmtSwagger = $mgmtLibraries | Where-Object { $_.generator -eq "Swagger" }
    $mgmtNewEmitter = $mgmtLibraries | Where-Object { $_.generator -notin $excludedGenerators }
    $mgmtTspOld = $mgmtLibraries | Where-Object { $_.generator -eq "TSP-Old" }

    # For Data Plane, explicitly exclude provisioning libraries from all counts
    $dataSwagger = $dataPlaneNonProvisioning | Where-Object { $_.generator -eq "Swagger" }
    $dataNewEmitter = $dataPlaneNonProvisioning | Where-Object { $_.generator -notin $excludedGenerators }
    $dataTspOld = $dataPlaneNonProvisioning | Where-Object { $_.generator -eq "TSP-Old" }

    # Calculate TypeSpec library counts (only those with tsp-location.yaml or Azure.AI.OpenAI with special handling)
    # Exclude provisioning libraries from data plane TypeSpec counts
    $mgmtTypeSpecLibs = $mgmtLibraries | Where-Object { $_.hasTspLocation -eq $true }
    $dataTypeSpecLibs = $dataPlaneNonProvisioning | Where-Object { $_.hasTspLocation -eq $true -or $_.library -eq "Azure.AI.OpenAI" }

    # Calculate migration percentages (migrated / total TypeSpec libraries)
    $mgmtMigrated = $mgmtNewEmitter.Count
    $mgmtTypeSpecTotal = $mgmtTypeSpecLibs.Count
    $mgmtPercentage = if ($mgmtTypeSpecTotal -gt 0) { [math]::Round(($mgmtMigrated / $mgmtTypeSpecTotal) * 100, 1) } else { 0 }

    $dataMigrated = $dataNewEmitter.Count
    $dataTypeSpecTotal = $dataTypeSpecLibs.Count
    $dataPercentage = if ($dataTypeSpecTotal -gt 0) { [math]::Round(($dataMigrated / $dataTypeSpecTotal) * 100, 1) } else { 0 }

    $report = @()
    $report += "# Azure SDK for .NET Libraries Inventory`n"

    # Table of Contents
    $report += "## Table of Contents`n"
    $report += "- [Summary](#summary)"
    $report += "- [Data Plane Libraries (DPG) - Migrated to New Emitter](#data-plane-libraries-dpg---migrated-to-new-emitter)"
    $report += "- [Data Plane Libraries (DPG) - Still on Swagger](#data-plane-libraries-dpg---still-on-swagger)"
    $report += "- [Management Plane Libraries (MPG) - Migrated to New Emitter](#management-plane-libraries-mpg---migrated-to-new-emitter)"
    $report += "- [Management Plane Libraries (MPG) - Still on Swagger](#management-plane-libraries-mpg---still-on-swagger)"
    $report += "- [Provisioning Libraries](#provisioning-libraries)"
    $report += "- [Libraries with No Generator](#libraries-with-no-generator)"
    $report += "`n"

    $report += "## Summary`n"
    $report += "- Total libraries: $($Libraries.Count)"
    $report += "- Management Plane (MPG): $($mgmtLibraries.Count)"
    $report += "  - Autorest/Swagger: $($mgmtSwagger.Count)"
    $report += "  - New Emitter (TypeSpec): $($mgmtNewEmitter.Count)"
    $report += "  - Old TypeSpec: $($mgmtTspOld.Count)"
    $report += "- Data Plane (DPG): $($dataPlaneNonProvisioning.Count)"
    $report += "  - Autorest/Swagger: $($dataSwagger.Count)"
    $report += "  - New Emitter (TypeSpec): $($dataNewEmitter.Count)"
    $report += "  - Old TypeSpec: $($dataTspOld.Count)"
    $report += "- Provisioning: $($provisioningLibraries.Count)"
    $report += "  - Custom reflection-based generator: $($provisioningLibraries.Count)"
    $report += "- No generator: $($noGenerator.Count)"
    $report += "`n"

    # Data Plane Libraries Table (migrated to new emitter) - only include libraries with tsp-location.yaml
    $report += "## Data Plane Libraries (DPG) - Migrated to New Emitter`n"
    $report += "Libraries that provide client APIs for Azure services and have been migrated to the new TypeSpec emitter.`n"
    $report += "**Migration Status**: $dataMigrated / $dataTypeSpecTotal ($dataPercentage%)`n"
    $report += "| Service | Library | New Emitter |"
    $report += "| ------- | ------- | ----------- |"
    # Only include non-provisioning libraries that have tsp-location.yaml or are Azure.AI.OpenAI (special case with hardcoded handling)
    $sortedDataLibs = $dataPlaneNonProvisioning | Where-Object { $_.hasTspLocation -eq $true -or $_.library -eq "Azure.AI.OpenAI" } | Sort-Object service, library
    foreach ($lib in $sortedDataLibs) {
        $newEmitter = if ($lib.generator -notin $excludedGenerators) { "✅" } else { "" }
        $report += "| $($lib.service) | $($lib.library) | $newEmitter |"
    }
    $report += "`n"

    # Data Plane Libraries still on Swagger
    if ($dataSwagger.Count -gt 0) {
        $report += "## Data Plane Libraries (DPG) - Still on Swagger`n"
        $report += "Libraries that have not yet been migrated to the new TypeSpec emitter. Total: $($dataSwagger.Count)`n"
        $report += "| Service | Library |"
        $report += "| ------- | ------- |"
        $sortedDataSwagger = $dataSwagger | Sort-Object service, library
        foreach ($lib in $sortedDataSwagger) {
            $report += "| $($lib.service) | $($lib.library) |"
        }
        $report += "`n"
    }

    # Management Plane Libraries Table (migrated to new emitter) - only include libraries with tsp-location.yaml
    $report += "## Management Plane Libraries (MPG) - Migrated to New Emitter`n"
    $report += "Libraries that provide resource management APIs for Azure services and have been migrated to the new TypeSpec emitter.`n"
    $report += "**Migration Status**: $mgmtMigrated / $mgmtTypeSpecTotal ($mgmtPercentage%)`n"
    $report += "| Service | Library | New Emitter |"
    $report += "| ------- | ------- | ----------- |"
    # Only include libraries that have tsp-location.yaml
    $sortedMgmtLibs = $mgmtLibraries | Where-Object { $_.hasTspLocation -eq $true } | Sort-Object service, library
    foreach ($lib in $sortedMgmtLibs) {
        $newEmitter = if ($lib.generator -notin $excludedGenerators) { "✅" } else { "" }
        $report += "| $($lib.service) | $($lib.library) | $newEmitter |"
    }
    $report += "`n"

    # Management Plane Libraries still on Swagger
    if ($mgmtSwagger.Count -gt 0) {
        $report += "## Management Plane Libraries (MPG) - Still on Swagger`n"
        $report += "Libraries that have not yet been migrated to the new TypeSpec emitter. Total: $($mgmtSwagger.Count)`n"
        $report += "| Service | Library |"
        $report += "| ------- | ------- |"
        $sortedMgmtSwagger = $mgmtSwagger | Sort-Object service, library
        foreach ($lib in $sortedMgmtSwagger) {
            $report += "| $($lib.service) | $($lib.library) |"
        }
        $report += "`n"
    }

    # Provisioning Libraries
    if ($provisioningLibraries.Count -gt 0) {
        $report += "## Provisioning Libraries`n"
        $report += "Libraries that provide infrastructure-as-code capabilities for Azure services using a custom reflection-based generator. These libraries allow you to declaratively specify Azure infrastructure natively in .NET and generate Bicep templates for deployment.`n"
        $report += "**Note**: Unlike other Azure SDK libraries, Provisioning libraries use a custom reflection-based generator that analyzes Azure Resource Manager SDK types to produce strongly-typed infrastructure definition APIs.`n"
        $report += "Total: $($provisioningLibraries.Count)`n"
        $report += "| Service | Library |"
        $report += "| ------- | ------- |"
        $sortedProvisioning = $provisioningLibraries | Sort-Object service, library
        foreach ($lib in $sortedProvisioning) {
            $report += "| $($lib.service) | $($lib.library) |"
        }
        $report += "`n"
    }

    # No Generator Libraries
    $report += "## Libraries with No Generator`n"
    $report += "Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: $($noGenerator.Count)`n"
    $report += "| Service | Library |"
    $report += "| ------- | ------- |"
    $sortedLibs = $noGenerator | Sort-Object service, library
    foreach ($lib in $sortedLibs) {
        $report += "| $($lib.service) | $($lib.library) |"
    }

    return ($report -join "`n")
}

# Main execution
try {
    # Define the path to the SDK root directory
    $sdkRoot = Join-Path $PSScriptRoot "..\..\sdk"
    $sdkRoot = Resolve-Path $sdkRoot

    # Scan libraries
    Write-Host "Scanning libraries..." -ForegroundColor Green
    $libraries = Get-SdkLibraries $sdkRoot

    # Print summary counts
    $mgmtSwagger = ($libraries | Where-Object { $_.type -eq "Management" -and $_.generator -eq "Swagger" }).Count
    $mgmtTspOld = ($libraries | Where-Object { $_.type -eq "Management" -and $_.generator -eq "TSP-Old" }).Count
    $dataSwagger = ($libraries | Where-Object { $_.type -eq "Data Plane" -and $_.generator -eq "Swagger" }).Count
    $dataTspOld = ($libraries | Where-Object { $_.type -eq "Data Plane" -and $_.generator -eq "TSP-Old" }).Count
    $noGenerator = ($libraries | Where-Object { $_.generator -eq "No Generator" }).Count

    # Get counts for specific TypeSpec generators
    $newGeneratorTypes = $libraries | Where-Object { $_.generator -notin @("Swagger", "TSP-Old", "No Generator") } |
                        Select-Object -ExpandProperty generator -Unique | Sort-Object

    Write-Host "Total libraries found: $($libraries.Count)"
    Write-Host "Management Plane (Swagger): $mgmtSwagger"
    Write-Host "Management Plane (TSP-Old): $mgmtTspOld"

    # Print counts for each new generator type in Management Plane
    foreach ($genType in $newGeneratorTypes) {
        $mgmtGenCount = ($libraries | Where-Object { $_.type -eq "Management" -and $_.generator -eq $genType }).Count
        if ($mgmtGenCount -gt 0) {
            Write-Host "Management Plane (TypeSpec - $genType): $mgmtGenCount"
        }
    }

    Write-Host "Data Plane (Swagger): $dataSwagger"
    Write-Host "Data Plane (TSP-Old): $dataTspOld"

    # Print counts for each new generator type in Data Plane
    foreach ($genType in $newGeneratorTypes) {
        $dataGenCount = ($libraries | Where-Object { $_.type -eq "Data Plane" -and $_.generator -eq $genType }).Count
        if ($dataGenCount -gt 0) {
            Write-Host "Data Plane (TypeSpec - $genType): $dataGenCount"
        }
    }

    Write-Host "No generator: $noGenerator"

    # Generate the inventory markdown file
    $markdownReport = New-MarkdownReport $libraries
    $inventoryMdPath = Join-Path $PSScriptRoot "Library_Inventory.md"
    $markdownReport | Out-File -FilePath $inventoryMdPath -Encoding UTF8

    Write-Host "Library inventory markdown generated at: $inventoryMdPath"

    # Export JSON only if requested via the -Json flag
    if ($Json) {
        $jsonPath = Join-Path $PSScriptRoot "Library_Inventory.json"
        $libraries | ConvertTo-Json -Depth 3 | Out-File -FilePath $jsonPath -Encoding UTF8
        Write-Host "Library inventory JSON generated at: $jsonPath"
    }
    else {
        Write-Host "JSON file generation skipped. Use -Json flag to generate the JSON file."
    }
}
catch {
    Write-Error "An error occurred: $($_.Exception.Message)"
    exit 1
}
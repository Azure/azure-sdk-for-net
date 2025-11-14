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

function Get-GeneratorType {
    param([string]$Path)

    # Identify if a library is generated using swagger or tsp.
    # Returns: "Swagger", a specific TypeSpec generator name, "TSP-Old", or "No Generator"

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

                    # If we couldn't extract a specific name, use a default fully qualified name
                    return "Unknown TypeSpec Generator: $emitterPath"
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

            # Skip libraries that start with "Microsoft."
            if ($libraryDir.Name.StartsWith("Microsoft.")) {
                continue
            }

            # If it has a /src directory or a csproj file, it's likely a library
            $srcPath = Join-Path $libraryDir.FullName "src"
            $csprojFiles = Get-ChildItem -Path $libraryDir.FullName -Filter "*.csproj" -ErrorAction SilentlyContinue

            if ((Test-Path $srcPath) -or $csprojFiles) {
                $libraryType = if (Test-MgmtLibrary $libraryDir.FullName) { "Management" } else { "Data Plane" }
                $generator = Get-GeneratorType $libraryDir.FullName

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
                }
            }
        }
    }

    return $libraries
}

function New-MarkdownReport {
    param([array]$Libraries)

    # Generate a markdown report from the library inventory.

    # Group by type and generator
    $mgmtSwagger = $Libraries | Where-Object { $_.type -eq "Management" -and $_.generator -eq "Swagger" }
    $dataSwagger = $Libraries | Where-Object { $_.type -eq "Data Plane" -and $_.generator -eq "Swagger" }

    # Old TypeSpec libraries
    $mgmtTspOld = $Libraries | Where-Object { $_.type -eq "Management" -and $_.generator -eq "TSP-Old" }
    $dataTspOld = $Libraries | Where-Object { $_.type -eq "Data Plane" -and $_.generator -eq "TSP-Old" }

    # Group by specific TypeSpec generator
    # First, identify all unique new generator types
    $newGeneratorTypes = $Libraries | Where-Object { $_.generator -notin @("Swagger", "TSP-Old", "No Generator") } |
                        Select-Object -ExpandProperty generator -Unique | Sort-Object

    # Create groups for each generator type
    $mgmtTspByGenerator = @{}
    $dataTspByGenerator = @{}

    foreach ($genType in $newGeneratorTypes) {
        $mgmtTspByGenerator[$genType] = $Libraries | Where-Object { $_.type -eq "Management" -and $_.generator -eq $genType }
        $dataTspByGenerator[$genType] = $Libraries | Where-Object { $_.type -eq "Data Plane" -and $_.generator -eq $genType }
    }

    $noGenerator = $Libraries | Where-Object { $_.generator -eq "No Generator" }

    $report = @()
    $report += "# Azure SDK for .NET Libraries Inventory`n"

    $report += "## Summary`n"
    $report += "- Total libraries: $($Libraries.Count)"
    $report += "- Management Plane (Swagger): $($mgmtSwagger.Count)"
    $report += "- Management Plane (TSP-Old): $($mgmtTspOld.Count)"

    # List all new generator types with counts
    foreach ($genType in $newGeneratorTypes) {
        $report += "- Management Plane (TypeSpec - $genType): $($mgmtTspByGenerator[$genType].Count)"
    }

    $report += "- Data Plane (Swagger): $($dataSwagger.Count)"
    $report += "- Data Plane (TSP-Old): $($dataTspOld.Count)"

    # List all new generator types with counts for data plane
    foreach ($genType in $newGeneratorTypes) {
        $report += "- Data Plane (TypeSpec - $genType): $($dataTspByGenerator[$genType].Count)"
    }

    $report += "- No generator: $($noGenerator.Count)"
    $report += "`n"

    # Add sections for each TypeSpec generator for Data Plane
    foreach ($genType in $newGeneratorTypes) {
        if ($dataTspByGenerator[$genType].Count -gt 0) {
            $report += "## Data Plane Libraries using TypeSpec ($genType)`n"
            $report += "TypeSpec with $genType generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing $genType, or through special handling for specific libraries. Total: $($dataTspByGenerator[$genType].Count)`n"
            $report += "| Service | Library | Path |"
            $report += "| ------- | ------- | ---- |"
            $sortedLibs = $dataTspByGenerator[$genType] | Sort-Object service, library
            foreach ($lib in $sortedLibs) {
                $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
            }
            $report += "`n"
        }
    }

    # Old TypeSpec Data Plane Libraries
    if ($dataTspOld.Count -gt 0) {
        $report += "## Data Plane Libraries using TypeSpec (Old Generator)`n"
        $report += "TypeSpec with old generator is detected by the presence of a tsp-location.yaml file without an emitterPackageJsonPath value, tspconfig.yaml file, tsp directory, or *.tsp files. Total: $($dataTspOld.Count)`n"
        $report += "| Service | Library | Path |"
        $report += "| ------- | ------- | ---- |"
        $sortedLibs = $dataTspOld | Sort-Object service, library
        foreach ($lib in $sortedLibs) {
            $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
        }
        $report += "`n"
    }

    # Data Plane Swagger Libraries
    if ($dataSwagger.Count -gt 0) {
        $report += "## Data Plane Libraries using Swagger`n"
        $report += "Total: $($dataSwagger.Count)`n"
        $report += "| Service | Library | Path |"
        $report += "| ------- | ------- | ---- |"
        $sortedLibs = $dataSwagger | Sort-Object service, library
        foreach ($lib in $sortedLibs) {
            $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
        }
        $report += "`n"
    }

    # Add sections for each TypeSpec generator for Management Plane
    foreach ($genType in $newGeneratorTypes) {
        if ($mgmtTspByGenerator[$genType].Count -gt 0) {
            $report += "## Management Plane Libraries using TypeSpec ($genType)`n"
            $report += "TypeSpec with $genType generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing $genType, or through special handling for specific libraries. Total: $($mgmtTspByGenerator[$genType].Count)`n"
            $report += "| Service | Library | Path |"
            $report += "| ------- | ------- | ---- |"
            $sortedLibs = $mgmtTspByGenerator[$genType] | Sort-Object service, library
            foreach ($lib in $sortedLibs) {
                $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
            }
            $report += "`n"
        }
    }

    # Old TypeSpec Management Plane Libraries
    if ($mgmtTspOld.Count -gt 0) {
        $report += "## Management Plane Libraries using TypeSpec (Old Generator)`n"
        $report += "TypeSpec with old generator is detected by the presence of a tsp-location.yaml file without an emitterPackageJsonPath value, tspconfig.yaml file, tsp directory, or *.tsp files. Total: $($mgmtTspOld.Count)`n"
        $report += "| Service | Library | Path |"
        $report += "| ------- | ------- | ---- |"
        $sortedLibs = $mgmtTspOld | Sort-Object service, library
        foreach ($lib in $sortedLibs) {
            $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
        }
        $report += "`n"
    }

    # Management Plane Swagger Libraries
    if ($mgmtSwagger.Count -gt 0) {
        $report += "## Management Plane Libraries using Swagger`n"
        $report += "Total: $($mgmtSwagger.Count)`n"
        $report += "| Service | Library | Path |"
        $report += "| ------- | ------- | ---- |"
        $sortedLibs = $mgmtSwagger | Sort-Object service, library
        foreach ($lib in $sortedLibs) {
            $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
        }
        $report += "`n"
    }

    # No Generator Libraries
    $report += "## Libraries with No Generator`n"
    $report += "Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: $($noGenerator.Count)`n"
    $report += "| Service | Library | Path |"
    $report += "| ------- | ------- | ---- |"
    $sortedLibs = $noGenerator | Sort-Object service, library
    foreach ($lib in $sortedLibs) {
        $report += "| $($lib.service) | $($lib.library) | $($lib.path) |"
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
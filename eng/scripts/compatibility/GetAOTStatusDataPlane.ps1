<#
.SYNOPSIS
    Finds all packages in ci.yml files with name entries within the Artifacts section.

.DESCRIPTION
    This script searches through all subdirectories in the sdk folder and identifies packages from ci.yml files.
    It extracts name values from Artifacts entries and organizes them by service directory.
    Then it runs AOT compatibility checks for each package and saves the expected warning patterns.
    
.PARAMETER SpecificPackages
    Optional. An array of specific package names to process instead of scanning all packages.
    Format: @("Azure.Core", "Azure.Identity")
    
.PARAMETER SpecificServiceDirectory
    Optional. The name of a specific service directory to scan (e.g., "core", "identity").
    Use with SpecificPackages to narrow down the search.
    
.NOTES
    File Name      : Find-AzureDataPlanePackages.ps1
    Author         : GitHub Copilot
    Prerequisite   : PowerShell 5.1 or higher
#>

param (
    [string[]]$SpecificPackages,
    [string]$SpecificServiceDirectory
)

# Get the repository root directory
$repoRoot = Resolve-Path -Path (Join-Path -Path $PSScriptRoot -ChildPath "..\..\..")
$sdkDir = Join-Path -Path $repoRoot -ChildPath "sdk"

# If specific service directory is provided, limit the search
if ($SpecificServiceDirectory) {
    $serviceDirPath = Join-Path -Path $sdkDir -ChildPath $SpecificServiceDirectory
    if (Test-Path $serviceDirPath -PathType Container) {
        Write-Host "Limiting search to service directory: $SpecificServiceDirectory" -ForegroundColor Yellow
        $serviceDirs = Get-Item -Path $serviceDirPath
    } else {
        Write-Error "Specified service directory not found: $SpecificServiceDirectory"
        exit 1
    }
} else {
    Write-Host "Finding Artifacts entries and their names in ci.yml files in: $sdkDir" -ForegroundColor Cyan
    # List all directories under sdk
    $serviceDirs = Get-ChildItem -Path $sdkDir -Directory
}

# Initialize an array to store the results
$foundPackages = @()

# Total count for progress display
$totalDirs = $serviceDirs.Count
$currentDir = 0

foreach ($serviceDir in $serviceDirs) {
    $currentDir++
    Write-Progress -Activity "Scanning sdk directories" -Status "Checking $($serviceDir.Name)" -PercentComplete (($currentDir / $totalDirs) * 100)
    
    # Look for ci.yml files in this service directory
    $ciYmlFiles = Get-ChildItem -Path $serviceDir.FullName -Filter "ci.yml" -Recurse -ErrorAction SilentlyContinue
    
    foreach ($ciYmlFile in $ciYmlFiles) {
        # Read the ci.yml file to extract artifact name
        try {            $ciYmlContent = Get-Content -Path $ciYmlFile.FullName -Raw
            
            # Look for Artifacts sections with name entries
            $artifactSections = [regex]::Matches($ciYmlContent, 'Artifacts:(.*?)(?:\r?\n\S|\z)', [System.Text.RegularExpressions.RegexOptions]::Singleline)
            
            foreach ($artifactSection in $artifactSections) {
                $sectionContent = $artifactSection.Groups[1].Value
                
                # Find all name entries within this Artifacts section
                $nameMatches = [regex]::Matches($sectionContent, 'name:\s*["'']?(.*?)["'']?\s')
                
                foreach ($nameMatch in $nameMatches) {
                    $packageName = $nameMatch.Groups[1].Value.Trim()
                      # Add to our collection
                    $foundPackages += [PSCustomObject]@{
                        PackageName = $packageName
                        ServiceDirectory = $serviceDir.Name
                    }
                    
                    Write-Host "  Found Artifacts.name: $packageName in $($serviceDir.Name)" -ForegroundColor Green
                    
                    Write-Host "  Found Artifacts.name: $packageName in $($serviceDir.Name)" -ForegroundColor Green
                }
            }
        } catch {
            Write-Warning "Error processing $($ciYmlFile.FullName): $_"
        }
    }
}

Write-Progress -Activity "Scanning sdk directories" -Completed

# Display summary
Write-Host "`nScanned $($serviceDirs.Count) service directories" -ForegroundColor Yellow
Write-Host "Found $($foundPackages.Count) artifacts in ci.yml files:" -ForegroundColor Green

if ($foundPackages.Count -gt 0) {
    $foundPackages | Format-Table -Property PackageName, ServiceDirectory
} else {
    Write-Host "No artifacts found in ci.yml files." -ForegroundColor Red
    exit 1
}

# If specific packages were specified, filter the found packages
if ($SpecificPackages -and $SpecificPackages.Count -gt 0) {
    Write-Host "Filtering for specific packages: $($SpecificPackages -join ', ')" -ForegroundColor Yellow
    $filteredPackages = @()
    foreach ($package in $foundPackages) {
        if ($SpecificPackages -contains $package.PackageName) {
            $filteredPackages += $package
            Write-Host "  Selected package: $($package.PackageName) in $($package.ServiceDirectory)" -ForegroundColor Green
        }
    }
    
    if ($filteredPackages.Count -eq 0) {
        Write-Warning "None of the specified packages were found in the scan results."
        exit 1
    }
    
    # Replace the full list with just the filtered packages
    $foundPackages = $filteredPackages
    Write-Host "Processing $($foundPackages.Count) selected packages." -ForegroundColor Cyan
}

# Process each package to run AOT compatibility check
Write-Host "`nRunning AOT compatibility checks for each package..." -ForegroundColor Cyan

$processedPackages = 0
$successfulPackages = 0
$failedPackages = 0

foreach ($package in $foundPackages) {
    $processedPackages++
    Write-Host "`nProcessing [$processedPackages/$($foundPackages.Count)] $($package.PackageName) in $($package.ServiceDirectory)..." -ForegroundColor Yellow
    
    # Construct path to the Check-AOT-Compatibility.ps1 script
    $checkAotScriptPath = Join-Path -Path $PSScriptRoot -ChildPath "Check-AOT-Compatibility.ps1"
    
    # Construct the path to the package directory following the structure: repoRoot/sdk/serviceDirectory/packageName
    $packageDir = Join-Path -Path (Join-Path -Path $sdkDir -ChildPath $package.ServiceDirectory) -ChildPath $package.PackageName
    
    # Check if the package directory exists
    if (!(Test-Path $packageDir)) {
        Write-Warning "  Package directory does not exist: $packageDir"
        $failedPackages++
        continue
    }
    
    # # Create the compatibility directory for the output
    # $testsDir = Join-Path -Path $packageDir -ChildPath "tests"
    # $compatibilityDir = Join-Path -Path $testsDir -ChildPath "compatibility"
    
    # # Create directory if it doesn't exist
    # if (!(Test-Path $testsDir)) {
    #     New-Item -ItemType Directory -Path $testsDir -Force | Out-Null
    #     Write-Host "  Created directory: $testsDir" -ForegroundColor Gray
    # }
    
    # if (!(Test-Path $compatibilityDir)) {
    #     New-Item -ItemType Directory -Path $compatibilityDir -Force | Out-Null
    #     Write-Host "  Created directory: $compatibilityDir" -ForegroundColor Gray
    # }
      # Determine the output file path
    # $outputFilePath = Join-Path -Path $compatibilityDir -ChildPath "ExpectedWarnings.txt"
      # Run the AOT compatibility check and extract warnings
    Write-Host "  Running Check-AOT-Compatibility.ps1 for $($package.PackageName)..." -ForegroundColor Gray
    try {        # Run the compatibility check with "None" to force it to report all warnings and capture all output
        $output = & $checkAotScriptPath -ServiceDirectory $package.ServiceDirectory -PackageName $package.PackageName -ExpectedWarningsFilePath "None" *>&1
        
        # Split the output into lines and find warnings
        $outputLines = $output -split "`r`n"
        $warningLines = @()

        if ($warningLines.Count -eq 0) {
            $warningLines = $outputLines | Where-Object { $_ -match "IL\d+:" }
        }
        
        # Process each warning line
        # $warningPatterns = @()
        # foreach ($line in $warningLines) {
        #     # Clean up the line - remove color codes and normalize whitespace
        #     $cleanLine = $line -replace '\e\[\d+(;\d+)*m', '' -replace '\s+', ' ' -replace '^\s+|\s+$', ''
            
        #     # Remove filepath in brackets at the end if it exists
        #     $cleanLine = $cleanLine -replace '\s+\[.+?\]$', ''
        #       # Handle filepath at the beginning (replace with .* up to package name)
        #     if ($cleanLine -match "\\sdk\\.*?\\($($package.PackageName))\\") {
        #         $cleanLine = $cleanLine -replace "^.*\\sdk\\.*?\\($($package.PackageName))", ".*$($package.PackageName)"
        #     }
            
        #     # Replace line numbers with \d*
        #     $cleanLine = $cleanLine -replace '\(\d+\)', '(\d*)'
            
        #     # Escape special regex characters (except those we want to keep as wildcards)
        #     $escapedLine = [regex]::Escape($cleanLine)

        #     $escapedLine = $escapedLine -replace '\\\\d\\\*', '\d*'  # Keep \d* wildcards
        #     $escapedLine = $escapedLine -replace '\\.\\\*', '.*'  # Keep .* wildcards

            
        #     $warningPatterns += $escapedLine
        # }
        
        # Save the warning patterns to the file
        if ($warningLines.Count -gt 0) {
            # $warningPatterns | Out-File -FilePath $outputFilePath -Force
            Write-Host "  Counted $($warningLines.Count) warnings" -ForegroundColor Yellow
        } else {
            # Create an empty file if no warnings found
            Write-Host "  No warnings found." -ForegroundColor Green
        }
        
        $successfulPackages++
    } catch {
        Write-Warning "  Error running Check-AOT-Compatibility.ps1 for $($package.PackageName): $_"
        $failedPackages++
    }
}

# Display summary of results
Write-Host "`nAOT compatibility check summary:" -ForegroundColor Cyan
Write-Host "  Total packages processed: $processedPackages" -ForegroundColor White
Write-Host "  Successful: $successfulPackages" -ForegroundColor Green
Write-Host "  Failed: $failedPackages" -ForegroundColor $(if ($failedPackages -gt 0) { "Red" } else { "Green" })

Write-Host "`nCompleted AOT compatibility checks for all packages" -ForegroundColor Green
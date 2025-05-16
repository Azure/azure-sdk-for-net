<#
.SYNOPSIS
    Finds all packages in ci.yml files with name entries within the Artifacts section.
    
.PARAMETER PackageName
    The PackageName to collect AOT warnings for.
    
.PARAMETER ServiceDirectory
    The ServiceDirectory holding the package (e.g., "core", "identity").

.PARAMETER DirectoryName
    Optional. The name of a specific directory to scan within the service directory.
    This is assumed to be PackageName if not provided.
#>

param (
    [string]$PackageName,
    [string]$ServiceDirectory,
    [string]$DirectoryName
)


Write-Host "`nProcessing $($package.PackageName) in $($package.ServiceDirectory)..." -ForegroundColor Yellow
    
    # Construct path to the Check-AOT-Compatibility.ps1 script
    $checkAotScriptPath = Join-Path -Path $PSScriptRoot -ChildPath "Check-AOT-Compatibility.ps1"
    
    # Construct the path to the package directory following the structure: repoRoot/sdk/serviceDirectory/packageName
    $packageDir = Join-Path -Path (Join-Path -Path $sdkDir -ChildPath $package.ServiceDirectory) -ChildPath $package.PackageName
    
    # Create the compatibility directory for the output
    $testsDir = Join-Path -Path $packageDir -ChildPath "tests"
    $compatibilityDir = Join-Path -Path $testsDir -ChildPath "compatibility"
    
    # Create directory if it doesn't exist
    if (!(Test-Path $testsDir)) {
        New-Item -ItemType Directory -Path $testsDir -Force | Out-Null
        Write-Host "  Created directory: $testsDir" -ForegroundColor Gray
    }
    
    if (!(Test-Path $compatibilityDir)) {
        New-Item -ItemType Directory -Path $compatibilityDir -Force | Out-Null
        Write-Host "  Created directory: $compatibilityDir" -ForegroundColor Gray
    }
      # Determine the output file path
    $outputFilePath = Join-Path -Path $compatibilityDir -ChildPath "ExpectedWarnings.txt"
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
        $warningPatterns = @()
        foreach ($line in $warningLines) {
            # Clean up the line - remove color codes and normalize whitespace
            $cleanLine = $line -replace '\e\[\d+(;\d+)*m', '' -replace '\s+', ' ' -replace '^\s+|\s+$', ''
            
            # Remove filepath in brackets at the end if it exists
            $cleanLine = $cleanLine -replace '\s+\[.+?\]$', ''
              # Handle filepath at the beginning (replace with .* up to package name)
            if ($cleanLine -match "\\sdk\\.*?\\($($package.PackageName))\\") {
                $cleanLine = $cleanLine -replace "^.*\\sdk\\.*?\\($($package.PackageName))", ".*$($package.PackageName)"
            }
            
            # Replace line numbers with \d*
            $cleanLine = $cleanLine -replace '\(\d+\)', '(\d*)'
            
            # Escape special regex characters (except those we want to keep as wildcards)
            $escapedLine = [regex]::Escape($cleanLine)

            $escapedLine = $escapedLine -replace '\\\\d\\\*', '\d*'  # Keep \d* wildcards
            $escapedLine = $escapedLine -replace '\\.\\\*', '.*'  # Keep .* wildcards

            
            $warningPatterns += $escapedLine
        }
        
        # Save the warning patterns to the file
        if ($warningPatterns.Count -gt 0) {
            $warningPatterns | Out-File -FilePath $outputFilePath -Force
            Write-Host "  Saved $($warningPatterns.Count) warning patterns to: $outputFilePath" -ForegroundColor Green
        } else {
            # Create an empty file if no warnings found
            Write-Host "  No warnings found." -ForegroundColor Yellow
        }
        
        $successfulPackages++
    } catch {
        Write-Warning "  Error running Check-AOT-Compatibility.ps1 for $($package.PackageName): $_"
        $failedPackages++
    }

# Display summary of results
Write-Host "`nAOT compatibility check summary:" -ForegroundColor Cyan
Write-Host "  Total packages processed: $processedPackages" -ForegroundColor White
Write-Host "  Successful: $successfulPackages" -ForegroundColor Green
Write-Host "  Failed: $failedPackages" -ForegroundColor $(if ($failedPackages -gt 0) { "Red" } else { "Green" })

Write-Host "`nCompleted AOT compatibility checks for all packages" -ForegroundColor Green
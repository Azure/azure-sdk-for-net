<#
.SYNOPSIS
    Finds all packages in ci.yml files and adds AOT opt-out properties for packages that fail to build.

.DESCRIPTION
    This script searches through all subdirectories in the sdk folder and identifies packages from ci.yml files.
    It extracts name values from Artifacts entries and organizes them by service directory.
    For each package, it attempts to build the project. If the build fails, it adds <AotCompatOptOut>true</AotCompatOptOut> 
    to the project file to opt out of AOT compatibility requirements.
    
.PARAMETER SpecificPackages
    Optional. An array of specific package names to process instead of scanning all packages.
    Format: @("Azure.Core", "Azure.Identity")
    
.PARAMETER SpecificServiceDirectory
    Optional. The name of a specific service directory to scan (e.g., "core", "identity").
    Use with SpecificPackages to narrow down the search.
    
.NOTES
    File Name      : GetAOTStatusDataPlane.ps1
    Author         : GitHub Copilot
    Prerequisite   : PowerShell 5.1 or higher, .NET SDK
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
    
    # Look for ci.yml and ci.{something}.yml files in this service directory, excluding mgmt variants
    $ciYmlFiles = Get-ChildItem -Path $serviceDir.FullName -Filter "ci*.yml" -Recurse -ErrorAction SilentlyContinue | 
        Where-Object { $_.Name -eq "ci.yml" -or ($_.Name -match "^ci\..*\.yml$" -and $_.Name -notlike "*mgmt*") }
    
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
                    
                    # Look for directoryName in the same artifact entry
                    $directoryName = $null
                    $nameEndIndex = $nameMatch.Index + $nameMatch.Length
                    
                    # Find the next artifact entry or end of artifacts section to define the scope
                    $nextNameMatch = $nameMatches | Where-Object { $_.Index -gt $nameMatch.Index } | Sort-Object Index | Select-Object -First 1
                    $searchEndIndex = if ($nextNameMatch) { $nextNameMatch.Index } else { $sectionContent.Length }
                    
                    # Extract the text between this name entry and the next (or end of section)
                    $artifactEntryContent = $sectionContent.Substring($nameEndIndex, $searchEndIndex - $nameEndIndex)
                    
                    # Look for directoryName within this artifact entry
                    $directoryNameMatch = [regex]::Match($artifactEntryContent, 'directoryName:\s*["'']?(.*?)["'']?\s*(?:\r?\n|$)')
                    if ($directoryNameMatch.Success) {
                        $directoryName = $directoryNameMatch.Groups[1].Value.Trim()
                    }
                    
                    # Add to our collection
                    $foundPackages += [PSCustomObject]@{
                        PackageName = $packageName
                        ServiceDirectory = $serviceDir.Name
                        DirectoryName = $directoryName
                    }
                    
                    $displayName = if ($directoryName) { "$packageName (dir: $directoryName)" } else { $packageName }
                    Write-Host "  Found Artifacts.name: $displayName in $($serviceDir.Name)" -ForegroundColor Green
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
    $foundPackages | Format-Table -Property PackageName, ServiceDirectory, DirectoryName
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

# Process each package to build and check for AOT compatibility
Write-Host "`nBuilding packages to check for AOT compatibility..." -ForegroundColor Cyan

$processedPackages = 0
$successfulPackages = 0
$failedPackages = 0

foreach ($package in $foundPackages) {
    $processedPackages++
    Write-Host "`nProcessing [$processedPackages/$($foundPackages.Count)] $($package.PackageName) in $($package.ServiceDirectory)..." -ForegroundColor Yellow
    
    # Construct the path to the package directory following the structure: repoRoot/sdk/serviceDirectory/packageName
    # Use DirectoryName if available, otherwise fall back to PackageName
    $packageFolderName = if ($package.DirectoryName) { $package.DirectoryName } else { $package.PackageName }
    $packageDir = Join-Path -Path (Join-Path -Path $sdkDir -ChildPath $package.ServiceDirectory) -ChildPath $packageFolderName
    
    # Check if the package directory exists
    if (!(Test-Path $packageDir)) {
        Write-Warning "  Package directory does not exist: $packageDir"
        $failedPackages++
        continue
    }
    
    # Find the csproj file
    $csprojPath = Join-Path -Path $packageDir -ChildPath "src\$($package.PackageName).csproj"
    if (!(Test-Path $csprojPath)) {
        Write-Warning "  Could not find csproj file at expected location: $csprojPath"
        $failedPackages++
        continue
    }
    
    Write-Host "  Found csproj file: $csprojPath" -ForegroundColor Gray
    
    # Check if AotCompatOptOut already exists
    try {
        [xml]$csprojXml = Get-Content -Path $csprojPath
        $hasAotOptOut = $csprojXml.SelectNodes("//AotCompatOptOut") | Where-Object { $_ -ne $null }
        
        if ($hasAotOptOut.Count -gt 0) {
            Write-Host "  AotCompatOptOut already exists in csproj file, skipping build test" -ForegroundColor Yellow
            $successfulPackages++
            continue
        }
    } catch {
        Write-Warning "  Error reading csproj file: $_"
        $failedPackages++
        continue
    }
    
    # Try to build the project
    Write-Host "  Building project..." -ForegroundColor Gray
    try {
        # Build the project and capture output
        $buildOutput = dotnet build $csprojPath --configuration Release --verbosity quiet 2>&1
        $buildExitCode = $LASTEXITCODE
        
        if ($buildExitCode -eq 0) {
            Write-Host "  Build succeeded" -ForegroundColor Green
            $successfulPackages++
        } else {
            Write-Host "  Build failed, adding AotCompatOptOut property" -ForegroundColor Red
            
            # Add AotCompatOptOut property to the csproj file
            try {
                [xml]$csprojXml = Get-Content -Path $csprojPath
                
                # Find or create a PropertyGroup to add the opt-out property
                $propertyGroup = $csprojXml.Project.PropertyGroup | Select-Object -First 1
                if (-not $propertyGroup) {
                    # Create a new PropertyGroup if none exists
                    $propertyGroup = $csprojXml.CreateElement("PropertyGroup")
                    $csprojXml.Project.AppendChild($propertyGroup) | Out-Null
                }
                
                # Add AotCompatOptOut property
                $aotOptOutElement = $csprojXml.CreateElement("AotCompatOptOut")
                $aotOptOutElement.InnerText = "true"
                $propertyGroup.AppendChild($aotOptOutElement) | Out-Null
                
                # Save the updated csproj file
                $csprojXml.Save($csprojPath)
                Write-Host "  Added <AotCompatOptOut>true</AotCompatOptOut> to csproj file" -ForegroundColor Green
                
                # Verify the fix by building again
                Write-Host "  Verifying fix by building again..." -ForegroundColor Gray
                $verifyBuildOutput = dotnet build $csprojPath --configuration Release --verbosity quiet 2>&1
                $verifyBuildExitCode = $LASTEXITCODE
                
                if ($verifyBuildExitCode -eq 0) {
                    Write-Host "  Verification build succeeded - opt-out fixed the issue" -ForegroundColor Green
                    $successfulPackages++
                } else {
                    Write-Host "  Verification build still failed - opt-out did not fix the issue" -ForegroundColor Red
                    Write-Host "  This indicates a deeper build problem unrelated to AOT compatibility" -ForegroundColor Yellow
                    $failedPackages++
                    
                    # Show verification build output for debugging
                    Write-Host "  Verification build output:" -ForegroundColor DarkGray
                    $verifyBuildOutput | ForEach-Object { Write-Host "    $_" -ForegroundColor DarkGray }
                }
            } catch {
                Write-Warning "  Error adding AotCompatOptOut to csproj file: $_"
                $failedPackages++
            }
        }
        
        # Show original build output if first build failed for debugging
        # if ($buildExitCode -ne 0) {
        #     Write-Host "  Original build output:" -ForegroundColor DarkGray
        #     $buildOutput | ForEach-Object { Write-Host "    $_" -ForegroundColor DarkGray }
        # }
        
    } catch {
        Write-Warning "  Error building project: $_"
        $failedPackages++
    }
}

# Display summary of results
Write-Host "`nBuild and AOT opt-out processing summary:" -ForegroundColor Cyan
Write-Host "  Total packages processed: $processedPackages" -ForegroundColor White
Write-Host "  Successful: $successfulPackages (built successfully or opt-out fixed the issue)" -ForegroundColor Green
Write-Host "  Failed: $failedPackages (couldn't process or opt-out didn't fix the issue)" -ForegroundColor $(if ($failedPackages -gt 0) { "Red" } else { "Green" })

Write-Host "`nCompleted build checks and AOT opt-out processing for all packages" -ForegroundColor Green

# $processedPackages = 0
# $successfulPackages = 0
# $failedPackages = 0

# foreach ($package in $foundPackages) {
#     $processedPackages++
#     Write-Host "`nProcessing [$processedPackages/$($foundPackages.Count)] $($package.PackageName) in $($package.ServiceDirectory)..." -ForegroundColor Yellow
    
#     # Construct path to the Check-AOT-Compatibility.ps1 script
#     $checkAotScriptPath = Join-Path -Path $PSScriptRoot -ChildPath "Check-AOT-Compatibility.ps1"
    
#     # Construct the path to the package directory following the structure: repoRoot/sdk/serviceDirectory/packageName
#     # Use DirectoryName if available, otherwise fall back to PackageName
#     $packageFolderName = if ($package.DirectoryName) { $package.DirectoryName } else { $package.PackageName }
#     $packageDir = Join-Path -Path (Join-Path -Path $sdkDir -ChildPath $package.ServiceDirectory) -ChildPath $packageFolderName
    
#     # Check if the package directory exists
#     if (!(Test-Path $packageDir)) {
#         Write-Warning "  Package directory does not exist: $packageDir"
#         $failedPackages++
#         continue
#     }
    
#     Write-Host "  Running Check-AOT-Compatibility.ps1 for $($package.PackageName)..." -ForegroundColor Gray
#     try {        # Run the compatibility check with "None" to force it to report all warnings and capture all output
#         # Pass DirectoryName parameter if available
#         if ($package.DirectoryName) {
#             $output = & $checkAotScriptPath -ServiceDirectory $package.ServiceDirectory -PackageName $package.PackageName -ExpectedWarningsFilePath "None" -DirectoryName $package.DirectoryName *>&1
#         } else {
#             $output = & $checkAotScriptPath -ServiceDirectory $package.ServiceDirectory -PackageName $package.PackageName -ExpectedWarningsFilePath "None" *>&1
#         }
        
#         # Split the output into lines and find warnings
#         $outputLines = $output -split "`r`n"
#         $warningLines = @()

#         if ($warningLines.Count -eq 0) {
#             $warningLines = $outputLines | Where-Object { $_ -match "IL\d+:" }
#         }
        
#         if ($warningLines.Count -gt 0) {
#             # $warningPatterns | Out-File -FilePath $outputFilePath -Force
#             Write-Host "  Counted $($warningLines.Count) warnings" -ForegroundColor Yellow
#         } else {
#             # Create an empty file if no warnings found
#             Write-Host "  No warnings found." -ForegroundColor Green
            
#             # Try to find and update the csproj file to add AOT compatibility properties
#             $csprojPath = Join-Path -Path $packageDir -ChildPath "src\$($package.PackageName).csproj"
#             if (Test-Path $csprojPath) {
#                 Write-Host "  Found csproj file: $csprojPath" -ForegroundColor Gray
#                 try {
#                     # Read the csproj file
#                     [xml]$csprojXml = Get-Content -Path $csprojPath
                    
#                     # Check if AOT properties already exist
#                     $hasIsTrimmable = $csprojXml.SelectNodes("//IsTrimmable") | Where-Object { $_ -ne $null }
#                     $hasIsAotCompatible = $csprojXml.SelectNodes("//IsAotCompatible") | Where-Object { $_ -ne $null }
                    
#                     if ($hasIsTrimmable.Count -eq 0 -or $hasIsAotCompatible.Count -eq 0) {
#                         # Find or create a PropertyGroup to add the properties to
#                         $propertyGroup = $csprojXml.Project.PropertyGroup | Select-Object -First 1
#                         if (-not $propertyGroup) {
#                             # Create a new PropertyGroup if none exists
#                             $propertyGroup = $csprojXml.CreateElement("PropertyGroup")
#                             $csprojXml.Project.AppendChild($propertyGroup) | Out-Null
#                         }
                        
#                         # Add IsTrimmable if it doesn't exist
#                         if ($hasIsTrimmable.Count -eq 0) {
#                             $isTrimmableElement = $csprojXml.CreateElement("IsTrimmable")
#                             $isTrimmableElement.SetAttribute("Condition", "`$([MSBuild]::IsTargetFrameworkCompatible('`$(TargetFramework)', 'net6.0'))")
#                             $isTrimmableElement.InnerText = "true"
#                             $propertyGroup.AppendChild($isTrimmableElement) | Out-Null
#                             Write-Host "  Added IsTrimmable property" -ForegroundColor Green
#                         }
                        
#                         # Add IsAotCompatible if it doesn't exist
#                         if ($hasIsAotCompatible.Count -eq 0) {
#                             $isAotCompatibleElement = $csprojXml.CreateElement("IsAotCompatible")
#                             $isAotCompatibleElement.SetAttribute("Condition", "`$([MSBuild]::IsTargetFrameworkCompatible('`$(TargetFramework)', 'net7.0'))")
#                             $isAotCompatibleElement.InnerText = "true"
#                             $propertyGroup.AppendChild($isAotCompatibleElement) | Out-Null
#                             Write-Host "  Added IsAotCompatible property" -ForegroundColor Green
#                         }
                        
#                         # Save the updated csproj file
#                         $csprojXml.Save($csprojPath)
#                         Write-Host "  Updated csproj file with AOT compatibility properties" -ForegroundColor Green
#                     } else {
#                         Write-Host "  AOT compatibility properties already exist in csproj file" -ForegroundColor Yellow
#                     }
#                 } catch {
#                     Write-Warning "  Error updating csproj file: $_"
#                 }
#             } else {
#                 Write-Warning "  Could not find csproj file at expected location: $csprojPath"
#             }
#         }
        
#         $successfulPackages++
#     } catch {
#         Write-Warning "  Error running Check-AOT-Compatibility.ps1 for $($package.PackageName): $_"
#         $failedPackages++
#     }
# }

# # Display summary of results
# Write-Host "`nAOT compatibility check summary:" -ForegroundColor Cyan
# Write-Host "  Total packages processed: $processedPackages" -ForegroundColor White
# Write-Host "  Successful: $successfulPackages" -ForegroundColor Green
# Write-Host "  Failed: $failedPackages" -ForegroundColor $(if ($failedPackages -gt 0) { "Red" } else { "Green" })

# Write-Host "`nCompleted AOT compatibility checks for all packages" -ForegroundColor Green
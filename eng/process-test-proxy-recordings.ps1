param(
    [Parameter(Mandatory=$true)]
    [string]$Path
)

# Ensure the path is absolute
$absolutePath = Resolve-Path -Path $Path -ErrorAction Stop

Write-Host "Processing test proxy recordings for path: $absolutePath"

# Step 1: Execute test-proxy restore under the given path
Write-Host "Step 1: Executing test-proxy restore..."
Push-Location $absolutePath
try {
    $restoreResult = & test-proxy restore -a assets.json 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "test-proxy restore command failed with exit code: $LASTEXITCODE"
        Write-Warning "Output: $restoreResult"
    } else {
        Write-Host "test-proxy restore completed successfully"
    }
} catch {
    Write-Error "Failed to execute test-proxy restore: $_"
    return
} finally {
    Pop-Location
}

# Step 2: Find the .assets folder in parent directories
Write-Host "Step 2: Finding .assets folder..."
$currentPath = $absolutePath
$assetsPath = $null

while ($currentPath -and (Split-Path $currentPath -Parent) -ne $currentPath) {
    $potentialAssetsPath = Join-Path $currentPath ".assets"
    if (Test-Path $potentialAssetsPath -PathType Container) {
        $assetsPath = $potentialAssetsPath
        Write-Host "Found .assets folder at: $assetsPath"
        break
    }
    $currentPath = Split-Path $currentPath -Parent
}

if (-not $assetsPath) {
    Write-Error "Could not find .assets folder in any parent directory"
    return
}

# Step 3: Find all *.json files recursively in .assets folder
Write-Host "Step 3: Finding JSON files in .assets folder..."
$jsonFiles = Get-ChildItem -Path $assetsPath -Filter "*.json" -Recurse -File
Write-Host "Found $($jsonFiles.Count) JSON files to process"

# Step 4-7: Process each JSON file
$totalProcessed = 0
$totalModified = 0

foreach ($jsonFile in $jsonFiles) {
    Write-Host "Processing: $($jsonFile.FullName)"
    $totalProcessed++
    
    try {
        # Read and parse JSON content
        $jsonContent = Get-Content -Path $jsonFile.FullName -Raw -Encoding UTF8
        $jsonObject = $jsonContent | ConvertFrom-Json
        
        # Check if Entries property exists and is an array
        if (-not $jsonObject.PSObject.Properties["Entries"] -or $jsonObject.Entries -isnot [System.Array]) {
            Write-Host "  Skipping - no Entries array found"
            continue
        }
        
        $modified = $false
        $entriesWithNullResponse = 0
        $entriesModified = 0
        
        # Process each entry
        for ($i = 0; $i -lt $jsonObject.Entries.Count; $i++) {
            $entry = $jsonObject.Entries[$i]
            
            # Check if entry has ResponseBody property with null value (either actual null or string "null")
            if ($entry.PSObject.Properties["ResponseBody"] -and 
                ($entry.ResponseBody -eq $null -or $entry.ResponseBody -eq "null")) {
                $entriesWithNullResponse++
                $responseBodyType = if ($entry.ResponseBody -eq $null) { "actual null" } else { "string 'null'" }
                Write-Host "  Entry $i has ResponseBody=null ($responseBodyType)"
                
                # Check if RequestHeaders exists and has Accept property
                if ($entry.PSObject.Properties["RequestHeaders"] -and 
                    $entry.RequestHeaders.PSObject.Properties["Accept"]) {
                    
                    Write-Host "    Removing Accept header from entry $i"
                    $entry.RequestHeaders.PSObject.Properties.Remove("Accept")
                    $modified = $true
                    $entriesModified++
                } else {
                    Write-Host "    No Accept header to remove"
                }
            }
        }
        
        Write-Host "  Found $entriesWithNullResponse entries with null ResponseBody, modified $entriesModified entries"
        
        # Save the file if it was modified
        if ($modified) {
            $totalModified++
            Write-Host "  Saving modified file..."
            
            # Convert back to JSON with proper formatting
            $updatedJson = $jsonObject | ConvertTo-Json -Depth 100 -Compress:$false
            
            # Write back to file with UTF8 encoding (no BOM)
            [System.IO.File]::WriteAllText($jsonFile.FullName, $updatedJson, [System.Text.UTF8Encoding]::new($false))
            
            Write-Host "  File updated successfully"
        } else {
            Write-Host "  No changes needed"
        }
        
    } catch {
        Write-Error "Failed to process file $($jsonFile.FullName): $_"
        continue
    }
}

Write-Host ""
Write-Host "Processing complete!"
Write-Host "Total files processed: $totalProcessed"
Write-Host "Total files modified: $totalModified"

# Step 8: Execute test-proxy push to save changes
# if ($totalModified -gt 0) {
#     Write-Host ""
#     Write-Host "Step 8: Executing test-proxy push to save changes..."
#     Push-Location $absolutePath
#     try {
#         $pushResult = & test-proxy push -a assets.json 2>&1
#         if ($LASTEXITCODE -ne 0) {
#             Write-Warning "test-proxy push command failed with exit code: $LASTEXITCODE"
#             Write-Warning "Output: $pushResult"
#         } else {
#             Write-Host "test-proxy push completed successfully"
#         }
#     } catch {
#         Write-Error "Failed to execute test-proxy push: $_"
#     } finally {
#         Pop-Location
#     }
# } else {
#     Write-Host ""
#     Write-Host "No files were modified, skipping test-proxy push"
# }

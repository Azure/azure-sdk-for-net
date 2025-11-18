<#
.SYNOPSIS
Processes frameworks.xml to add import elements for assemblies with maximum versions.

.DESCRIPTION
This script replicates the functionality of the archived PopImport tool.
It reads a frameworks.xml file, scans for XML/DLL pairs in each framework,
extracts file versions from DLLs, identifies assemblies with the maximum version
across all frameworks, and adds import elements to the XML.

.PARAMETER FrameworksPath
The path to the directory containing the frameworks.xml file.

.EXAMPLE
Invoke-PopImport.ps1 -FrameworksPath "C:\path\to\frameworks"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [Alias("f")]
    [string]$FrameworksPath
)

$ErrorActionPreference = "Stop"

# Define the frameworks file name
$frameworksFile = "frameworks.xml"
$frameworksFilePath = Join-Path $FrameworksPath $frameworksFile

# Check if frameworks.xml exists
if (-not (Test-Path $frameworksFilePath)) {
    Write-Error "There was no frameworks.xml file found at path: $frameworksFilePath"
    exit 1
}

Write-Verbose "Loading frameworks.xml from: $frameworksFilePath"

# Load the XML document
[xml]$xDoc = Get-Content -Path $frameworksFilePath

# Collection to store framework information
$frameworks = @()

# Process each Framework element
foreach ($frameworkElement in $xDoc.Frameworks.Framework) {
    $frameworkName = $frameworkElement.Name
    $sourcePath = $frameworkElement.Source
    
    Write-Host "Operating on $frameworkName"
    
    $fullSourcePath = Join-Path $FrameworksPath $sourcePath
    $assemblyVersionMapping = @{}
    
    # Find all XML files in the source path
    if (Test-Path $fullSourcePath) {
        $xmlFiles = Get-ChildItem -Path $fullSourcePath -Filter "*.xml" -File
        
        foreach ($xmlFile in $xmlFiles) {
            $fileNameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($xmlFile.Name)
            $dllPath = Join-Path $fullSourcePath "$fileNameWithoutExtension.dll"
            
            # Check if corresponding DLL exists
            if (Test-Path $dllPath) {
                try {
                    # Get file version from DLL
                    $versionInfo = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllPath)
                    $version = $versionInfo.FileVersion
                    
                    if (-not [string]::IsNullOrEmpty($version)) {
                        $assemblyVersionMapping[$xmlFile.Name] = $version
                    }
                }
                catch {
                    Write-Warning "Failed to get version info for $dllPath : $_"
                }
            }
        }
    }
    
    # Store framework information
    $frameworks += @{
        Name = $frameworkName
        SourcePath = $sourcePath
        XMLElement = $frameworkElement
        AssemblyVersionMapping = $assemblyVersionMapping
    }
}

# Find maximum version for each assembly across all frameworks
$maxVersions = @{}

foreach ($framework in $frameworks) {
    foreach ($assembly in $framework.AssemblyVersionMapping.GetEnumerator()) {
        $assemblyName = $assembly.Key
        $version = $assembly.Value
        
        if (-not $maxVersions.ContainsKey($assemblyName)) {
            $maxVersions[$assemblyName] = $version
        }
        else {
            # Compare versions as strings (same behavior as original C# code)
            if ($version -gt $maxVersions[$assemblyName]) {
                $maxVersions[$assemblyName] = $version
            }
        }
    }
}

# Add import elements to frameworks with maximum version assemblies
foreach ($framework in $frameworks) {
    foreach ($assembly in $framework.AssemblyVersionMapping.GetEnumerator()) {
        $assemblyName = $assembly.Key
        $version = $assembly.Value
        
        # Check if this assembly has the maximum version
        if ($maxVersions.ContainsKey($assemblyName) -and $version -eq $maxVersions[$assemblyName]) {
            $importPath = "$($framework.SourcePath)\$assemblyName"
            
            # Create import element
            $importElement = $xDoc.CreateElement("import")
            $importElement.InnerText = $importPath
            
            # Add to the framework element
            [void]$framework.XMLElement.AppendChild($importElement)
        }
    }
}

# Save the updated XML document
Write-Verbose "Saving updated frameworks.xml to: $frameworksFilePath"
$xDoc.Save($frameworksFilePath)

Write-Verbose "PopImport processing completed successfully"

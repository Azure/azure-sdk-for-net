#Requires -Version 7.0

<#
.SYNOPSIS
    This script will help to fetch the latest build information from a PR build and update the UnbrandedGeneratorVersion in the props file.
.PARAMETER PRNumber
    The PR number for which the latest build information needs to be fetched.
.EXAMPLE
    .\BumpMTG.ps1 -PRNumber 1234
    This command will fetch the latest build information for PR 1234 and update the props file with the UnbrandedGeneratorVersion.
.EXAMPLE
    .\BumpMTG.ps1 1234
    Using positional parameter to specify the PR number.
#>
[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [string] $PRNumber
)

$ErrorActionPreference = 'Stop'

<#
.SYNOPSIS
    This function will update the UnbrandedGeneratorVersion in the Packages.Data.props file.
.PARAMETER PropsFilePath
    The path to the Packages.Data.props file.
.PARAMETER NewVersion
    The new version to set for UnbrandedGeneratorVersion.
#>
function Update-UnbrandedGeneratorVersion([string] $PropsFilePath, [string] $NewVersion) {
    if (-not $NewVersion) {
        Write-Warning "No version provided to update UnbrandedGeneratorVersion"
        return
    }

    Write-Host "Updating UnbrandedGeneratorVersion to '$NewVersion' in '$PropsFilePath'..."
    
    # Read the XML content with UTF8 encoding for cross-platform compatibility
    $content = Get-Content $PropsFilePath -Raw -Encoding UTF8
    [xml]$propsXml = $content
    
    # Find the PropertyGroup that contains UnbrandedGeneratorVersion
    $propertyGroup = $propsXml.Project.PropertyGroup | Where-Object { $_.UnbrandedGeneratorVersion }
    
    if ($propertyGroup) {
        $propertyGroup.UnbrandedGeneratorVersion = $NewVersion
    } else {
        Write-Warning "Could not find UnbrandedGeneratorVersion property in $PropsFilePath"
        return
    }
    
    # Configure XML writer settings for consistent formatting across platforms
    $xmlWriterSettings = New-Object System.Xml.XmlWriterSettings
    $xmlWriterSettings.Indent = $true
    $xmlWriterSettings.IndentChars = "  "
    $xmlWriterSettings.NewLineChars = "`n"  # Use Unix line endings for consistency
    $xmlWriterSettings.Encoding = [System.Text.Encoding]::UTF8
    
    # Save the updated XML with proper formatting
    $xmlWriter = [System.Xml.XmlWriter]::Create($PropsFilePath, $xmlWriterSettings)
    try {
        $propsXml.Save($xmlWriter)
    }
    finally {
        $xmlWriter.Close()
    }
    
    Write-Host "Successfully updated UnbrandedGeneratorVersion to '$NewVersion'"
}

# Use cross-platform path resolution
$PropsFilePath = Join-Path (Resolve-Path "$PSScriptRoot/../../../..") "Packages.Data.props"

Write-Host "Querying DevOps for the latest build for PR '$PRNumber'..."
$BuildJson = (az pipelines build list --organization "https://dev.azure.com/azure-sdk" --project "internal" --branch "refs/pull/$PRNumber/merge" --top 1 --query "[0]" --output json | ConvertFrom-Json)
Write-Host 'Done'

# Construct version from build number and update props file
Write-Host "Constructing version from build information..."
try {
    # Construct version using the known format: 1.0.0-alpha.{buildNumber}
    $buildNumber = $BuildJson.buildNumber
    
    if (-not $buildNumber) {
        throw "Build number not found in build information"
    }
    
    $UnbrandedGeneratorVersion = "1.0.0-alpha.$buildNumber"
    
    Update-UnbrandedGeneratorVersion $PropsFilePath $UnbrandedGeneratorVersion
    
    Write-Host "Done. UnbrandedGeneratorVersion update completed successfully."
}
catch {
    Write-Error "Failed to construct and update version: $($_.Exception.Message)"
}
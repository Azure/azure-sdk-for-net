# Generates an index page for cataloging different versions of the Docs
[CmdletBinding()]
Param (
    $DocFx,
    $RepoRoot,
    $DocGenDir
)
. (Join-Path $PSScriptRoot common.ps1)

function Get-TocMapping { 
    Param (
        [Parameter(Mandatory = $true)] [Object[]] $metadata,
        [Parameter(Mandatory = $true)] [String[]] $artifacts
    )
    # Used for sorting the toc display order
    $orderServiceMapping = @{}

    foreach ($artifact in $artifacts) {
        $packageInfo = $metadata | ? {$_.Package -eq $artifact}
        
        if ($packageInfo -and $packageInfo[0].Hide -eq 'true') {
            LogDebug "The artifact $artifact set 'Hide' to 'true'."
            continue
        }
        $serviceName = ""
        if (!$packageInfo -or !$packageInfo[0].ServiceName) {
            LogWarning "There is no service name for artifact $artifact. Please check csv of Azure/azure-sdk/_data/release/latest repo if this is intended. "
            # If no service name retrieved, print out warning message, and put it into Other page.
            $serviceName = "Other"
        }
        else {
            if ($packageInfo.Length -gt 1) {
                LogWarning "There are more than 1 packages fetched out for artifact $artifact. Please check csv of Azure/azure-sdk/_data/release/latest repo if this is intended. "
            }
            $serviceName = $packageInfo[0].ServiceName.Trim()
        }
        $orderServiceMapping[$artifact] = $serviceName
    }
    return $orderServiceMapping                   
}

function GenerateDocfxTocContent([Hashtable]$tocContent, [String]$lang) {
    LogDebug "Start generating the docfx toc and build docfx site..."
    $DocOutDir = "${RepoRoot}/docfx_project"

    LogDebug "Initializing Default DocFx Site..."
    & $($DocFx) init -q -o "${DocOutDir}"
    # The line below is used for testing in local
    # docfx init -q -o "${DocOutDir}"
    LogDebug "Copying template and configuration..."
    New-Item -Path "${DocOutDir}" -Name "templates" -ItemType "directory" -Force
    Copy-Item "${DocGenDir}/templates/*" -Destination "${DocOutDir}/templates" -Force -Recurse
    Copy-Item "${DocGenDir}/docfx.json" -Destination "${DocOutDir}/" -Force
    $YmlPath = "${DocOutDir}/api"
    New-Item -Path $YmlPath -Name "toc.yml" -Force
    $visitedService = @{}
    # Sort and display toc service name by alphabetical order.
    foreach ($serviceMapping in $tocContent.getEnumerator() | Sort Value) {
        $artifact = $serviceMapping.Key
        $serviceName = $serviceMapping.Value
        $fileName = ($serviceName -replace '\s', '').ToLower().Trim()
        if ($visitedService.ContainsKey($serviceName)) {
            Add-Content -Path "$($YmlPath)/${fileName}.md" -Value "#### $artifact"
        }
        else {
            Add-Content -Path "$($YmlPath)/toc.yml" -Value "- name: ${serviceName}`r`n  href: ${fileName}.md"
            New-Item -Path $YmlPath -Name "${fileName}.md" -Force
            Add-Content -Path "$($YmlPath)/${fileName}.md" -Value "#### $artifact"
            $visitedService[$serviceName] = $true
        }
    }

    # Generate toc homepage.
    LogDebug "Creating Site Title and Navigation..."
    New-Item -Path "${DocOutDir}" -Name "toc.yml" -Force
    Add-Content -Path "${DocOutDir}/toc.yml" -Value "- name: Azure SDK for $lang APIs`r`n  href: api/`r`n  homepage: api/index.md"

    LogDebug "Copying root markdowns"
    Copy-Item "$($RepoRoot)/README.md" -Destination "${DocOutDir}/api/index.md" -Force
    Copy-Item "$($RepoRoot)/CONTRIBUTING.md" -Destination "${DocOutDir}/api/CONTRIBUTING.md" -Force

    LogDebug "Building site..."
    & $($DocFx) build "${DocOutDir}/docfx.json"
    # The line below is used for testing in local
    # docfx build "${DocOutDir}/docfx.json"
    Copy-Item "${DocGenDir}/assets/logo.svg" -Destination "${DocOutDir}/_site/" -Force    
}

if ((Get-ChildItem -Path Function: | ? { $_.Name -eq $GetGithubIoDocIndexFn  }).Count -gt 0)
{
    &$GetGithubIoDocIndexFn
else
{
    LogWarning "The function '$GetGithubIoDocIndexFn' was not found."
}
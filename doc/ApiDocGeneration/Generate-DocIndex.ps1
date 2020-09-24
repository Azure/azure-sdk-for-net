# Generates an index page for cataloging different versions of the Docs

[CmdletBinding()]
Param (
    $RepoRoot,
    $DocGenDir,
    $ExcludeDocIndexFile = "$PSScriptRoot/exclude-doc-index.json",
    $lang = ".net",
    $includeMgmt = $false
)
. (Join-Path $PSScriptRoot ../../eng/common/scripts/common.ps1)

Write-Verbose "Name Reccuring paths with variable names"
$DocFxTool = "${RepoRoot}/docfx/docfx.exe"
$DocOutDir = "${RepoRoot}/docfx_project"

Write-Verbose "Initializing Default DocFx Site..."
& "${DocFxTool}" init -q -o "${DocOutDir}"

Write-Verbose "Copying template and configuration..."
New-Item -Path "${DocOutDir}" -Name "templates" -ItemType "directory" -Force
Copy-Item "${DocGenDir}/templates/*" -Destination "${DocOutDir}/templates" -Force -Recurse
Copy-Item "${DocGenDir}/docfx.json" -Destination "${DocOutDir}/" -Force

Write-Verbose "Creating Index using service directory and package names from repo..."
$ServiceListData = Get-ChildItem "${RepoRoot}/sdk" -Directory | Where-Object {$_.PSIsContainer}
$YmlPath = "${DocOutDir}/api"
New-Item -Path $YmlPath -Name "toc.yml" -Force

$metadata = GetMetaData -lang $lang
$ExcludeData = Get-Content -Raw -Path $ExcludeDocIndexFile | ConvertFrom-Json
foreach ($serviceDir in $ServiceListData)
{
    $dirName = $serviceDir.name
    if ($ExcludeData -and ($ExcludeData.services -contains $dirName)) {
        continue
    }
    $serviceName = ""
    $clientArr = @()
    $artifacts = Get-AllPkgProperties -ServiceDirectory $dirName -includeMgmt $includeMgmt
    foreach ($pkgInfo in $artifacts) {
        if (!$serviceName) {
            $serviceInfo = $metadata | ? { $_.Package -eq $pkgInfo.Name -and (!$_.GroupId -or $_.GroupId -eq $pkgInfo.Group)} 
            if ($serviceInfo -and $serviceInfo.ServiceName) {
                $serviceName = $serviceInfo.ServiceName
            } 
        }
        if ($ExcludeData -and ($ExcludeData.artifacts -contains $pkgInfo.Name)) {
            continue
        }
        $clientArr += $pkgInfo.Name
    }
    if (!$serviceName) {
        $serviceName = $dirName.ToUpper()
    }
    if ($clientArr.Count -gt 0)
    {
        New-Item -Path $YmlPath -Name "${dirName}.md" -Force
        Add-Content -Path "$($YmlPath)/toc.yml" -Value "- name: ${serviceName}`r`n  href: ${dirName}.md"
        # loop through the arrays and add the appropriate artifacts under the appropriate headings
        if ($clientArr.Count -gt 0)
        {
            Add-Content -Path "$($YmlPath)/${dirName}.md" -Value "# Client Libraries"
            foreach($lib in $clientArr) 
            {
                Write-Host "Write $($lib) to ${dirName}.md"
                Add-Content -Path "$($YmlPath)/${dirName}.md" -Value "#### $lib"
            }
        }
    }
}

Write-Verbose "Creating Site Title and Navigation..."
New-Item -Path "${DocOutDir}" -Name "toc.yml" -Force
Add-Content -Path "${DocOutDir}/toc.yml" -Value "- name: Azure SDK for NET APIs`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Copying root markdowns"
Copy-Item "$($RepoRoot)/README.md" -Destination "${DocOutDir}/api/index.md" -Force
Copy-Item "$($RepoRoot)/CONTRIBUTING.md" -Destination "${DocOutDir}/api/CONTRIBUTING.md" -Force

Write-Verbose "Building site..."
& "${DocFxTool}" build "${DocOutDir}/docfx.json"

Copy-Item "${DocGenDir}/assets/logo.svg" -Destination "${DocOutDir}/_site/" -Force
Copy-Item "${DocGenDir}/assets/toc.yml" -Destination "${DocOutDir}/_site/" -Force

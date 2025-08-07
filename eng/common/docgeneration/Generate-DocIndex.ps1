# Generates an index page for cataloging different versions of the Docs
[CmdletBinding()]
Param (
    $DocFx,
    $RepoRoot,
    $DocGenDir,
    $DocOutDir = "${RepoRoot}/docfx_project",
    $DocfxJsonPath = "${PSScriptRoot}\docfx.json",
    $MainJsPath = "${PSScriptRoot}\templates\matthews\styles\main.js"
)
. "${PSScriptRoot}\..\scripts\common.ps1"

# Fetch a list of "artifacts" from blob storage corresponding to the given
# language (-storagePrefix). Remove the prefix from the path names to arrive at
# an "artifact" name.
function Get-BlobStorage-Artifacts(
  $blobDirectoryRegex,
  $blobArtifactsReplacement,
  $storageAccountName,
  $storageContainerName,
  $storagePrefix
) {
    LogDebug "Reading artifact from storage blob ..."
    # "--only-show-errors" suppresses warnings about the fact that the az CLI is not authenticated
    # "--query '[].name'" returns a list of only blob names
    # "--num-results *" handles pagination so the caller does not have to
    $artifacts = az storage blob list `
        --auth-mode login `
        --account-name $storageAccountName `
        --container-name $storageContainerName `
        --prefix $storagePrefix `
        --delimiter / `
        --only-show-errors `
        --query '[].name' `
        --num-results * | ConvertFrom-Json 
    LogDebug "Number of artifacts found: $($artifacts.Length)"

    # example: "python/azure-storage-blob" -> "azure-storage-blob"
    $artifacts = $artifacts.ForEach({ $_ -replace $blobDirectoryRegex, $blobArtifactsReplacement })
    return $artifacts
}

function Get-TocMapping {
    Param (
        [Parameter(Mandatory = $true)] [Object[]] $metadata,
        [Parameter(Mandatory = $true)] [String[]] $artifacts
    )
    # Used for sorting the toc display order
    $orderServiceMapping = @{}

    foreach ($artifact in $artifacts) {
        $packageInfo = $metadata | ? { $_.Package -eq $artifact -and $_.Hide -ne "true" }
      
        $serviceName = ""
        if (!$packageInfo) {
            LogDebug "There is no service name for artifact $artifact or it is marked as hidden. Please check csv of Azure/azure-sdk/_data/release/latest repo if this is intended. "
            continue
        }
        elseif (!$packageInfo[0].ServiceName) {
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
        
        # Define the order of "New", "Type", if not match, return the length of the array.
        $CustomOrder_New = "true", "false", ""
        $newIndex = $CustomOrder_New.IndexOf($packageInfo[0].New.ToLower())
        $newIndex = $newIndex -eq -1 ?  $CustomOrder_New.Count : $newIndex
        $CustomOrder_Type = "client", "mgmt", "compat", "spring", ""
        $typeIndex = $CustomOrder_Type.IndexOf($packageInfo[0].Type.ToLower())
        $typeIndex = $typeIndex -eq -1 ? $CustomOrder_Type.Count : $typeIndex
        $orderServiceMapping[$artifact] = [PSCustomObject][ordered]@{
            NewIndex = $newIndex
            TypeIndex = $typeIndex
            ServiceName = $serviceName
            DisplayName = $packageInfo[0].DisplayName.Trim()
            Artifact = $artifact
       }
    }
    return $orderServiceMapping
}

function GenerateDocfxTocContent([Hashtable]$tocContent, [String]$lang, [String]$campaignId = "UA-62780441-46") {
    LogDebug "Start generating the docfx toc and build docfx site..."

    LogDebug "Initializing Default DocFx Site..."
    & $($DocFx) init -q -o "${DocOutDir}"
    # The line below is used for testing in local
    #docfx init -q -o "${DocOutDir}"
    LogDebug "Copying template and configuration..."
    New-Item -Path "${DocOutDir}" -Name "templates" -ItemType "directory" -Force
    Copy-Item "${DocGenDir}/templates/*" -Destination "${DocOutDir}/templates" -Force -Recurse

    $headerTemplateLocation = "${DocOutDir}/templates/matthews/partials/head.tmpl.partial"

    if ($campaignId -and (Test-Path $headerTemplateLocation)){
        $headerTemplateContent = Get-Content -Path $headerTemplateLocation -Raw
        $headerTemplateContent = $headerTemplateContent -replace "GA_CAMPAIGN_ID", $campaignId
        Set-Content -Path $headerTemplateLocation -Value $headerTemplateContent -NoNewline
    }

    Copy-Item "${DocGenDir}/docfx.json" -Destination "${DocOutDir}/" -Force
    $YmlPath = "${DocOutDir}/api"
    New-Item -Path $YmlPath -Name "toc.yml" -Force
    $visitedService = @{}
    # Sort and display toc service name by alphabetical order, and then sort artifact by order.
    $sortedToc = $tocContent.Values | Sort-Object ServiceName, NewIndex, TypeIndex, DisplayName, Artifact
    foreach ($serviceMapping in $sortedToc) {
        $artifact = $serviceMapping.Artifact
        $serviceName = $serviceMapping.ServiceName
        $displayName = $serviceMapping.DisplayName

        # handle spaces in service name, EG "Confidential Ledger"
        # handle / in service name, EG "Database for MySQL/PostgreSQL". Leaving a "/" present will generate a bad link location.
        $fileName = ($serviceName -replace '\s', '').Replace("/","").ToLower().Trim()
        if ($visitedService.ContainsKey($serviceName)) {
            if ($displayName) {
                Add-Content -Path "$($YmlPath)/${fileName}.md" -Value "#### $artifact`n##### ($displayName)"
            }
            else {
                Add-Content -Path "$($YmlPath)/${fileName}.md" -Value "#### $artifact"
            }
        }
        else {
            Add-Content -Path "$($YmlPath)/toc.yml" -Value "- name: ${serviceName}`r`n  href: ${fileName}.md"
            New-Item -Path $YmlPath -Name "${fileName}.md" -Force
            if ($displayName) {
                Add-Content -Path "$($YmlPath)/${fileName}.md" -Value "#### $artifact`n##### ($displayName)"
            }
            else {
                Add-Content -Path "$($YmlPath)/${fileName}.md" -Value "#### $artifact"
            }
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
    #docfx build "${DocOutDir}/docfx.json"
    Copy-Item "${DocGenDir}/assets/logo.svg" -Destination "${DocOutDir}/_site/" -Force
}

function UpdateDocIndexFiles {
    Param (
        [Parameter(Mandatory=$false)] [String]$appTitleLang = $Language,
        [Parameter(Mandatory=$false)] [String]$lang = $Language,
        [Parameter(Mandatory=$false)] [String]$packageRegex = "`"`"",
        [Parameter(Mandatory=$false)] [String]$regexReplacement = ""
    )
    # Update docfx.json
    $docfxContent = Get-Content -Path $DocfxJsonPath -Raw
    $docfxContent = $docfxContent -replace "`"_appTitle`": `"`"", "`"_appTitle`": `"Azure SDK for $appTitleLang`""
    $docfxContent = $docfxContent -replace "`"_appFooter`": `"`"", "`"_appFooter`": `"Azure SDK for $appTitleLang`""
    Set-Content -Path $DocfxJsonPath -Value $docfxContent -NoNewline
    # Update main.js var lang
    $mainJsContent = Get-Content -Path $MainJsPath -Raw
    $mainJsContent = $mainJsContent -replace "var SELECTED_LANGUAGE = ''", "var SELECTED_LANGUAGE = '$lang'"
    # Update main.js package regex and replacement
    $mainJsContent = $mainJsContent -replace "var PACKAGE_REGEX = ''", "var PACKAGE_REGEX = $packageRegex"
    $mainJsContent = $mainJsContent -replace "var PACKAGE_REPLACEMENT = ''", "var PACKAGE_REPLACEMENT = `"$regexReplacement`""

    Set-Content -Path $MainJsPath -Value $mainJsContent -NoNewline
}

if ($GetGithubIoDocIndexFn -and (Test-Path "function:$GetGithubIoDocIndexFn"))
{
    &$GetGithubIoDocIndexFn
}
else
{
    LogWarning "The function for 'GetGithubIoDocIndexFn' was not found.`
    Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
    See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
}

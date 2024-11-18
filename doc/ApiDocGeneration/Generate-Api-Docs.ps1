<#
.SYNOPSIS
Generates API Docs from the Azure-SDK-for-NET repo

.DESCRIPTION
This script generates API documentation for libraries in the Azure-SDK-for-Net repo using DocFx Doc tool.

.PARAMETER ArtifactName
The name of the Package whose API doc should be generated. Usually the name of the Package Directory e.g. Azure.Core

.PARAMETER ServiceDirectory
The Name of the servicedirectory, usually the name of the service e.g. core

.PARAMETER ArtifactsDirectoryName
Used in the case where the package directory name is different from the package name. e.g in cognitiveservice packages

.PARAMETER RepoRoot
The root of the Azure-SDK-for-Net Repo

.PARAMETER BinDirectory
A directory to hold tools and intermediate files for the Docfx Process.
If runing script locally this directory should already contain the following tools in respectively named directories
Directory Name: docfx , Download Link: https://github.com/dotnet/docfx/releases/download/v2.43.2/docfx.zip
Directory Name: ECMA2Yml , Download Link: https://www.nuget.org/packages/Microsoft.DocAsCode.ECMA2Yaml
Directory Name: mdoc , Download Link: https://github.com/mono/api-doc-tools/releases/download/mdoc-5.7.4.9/mdoc-5.7.4.9.zip
Directory Name: PopImport: https://azuresdkartifacts.blob.core.windows.net/azure-sdk-tools/flatcontainer/popimport/1.0.0/popimport.1.0.0.nupkg

.PARAMETER BinDirectory
RepoRoot\doc\ApiDocGeneration

#>

[CmdletBinding()]
Param (
    [Parameter(Mandatory = $True)]
    $ArtifactName,
    [Parameter(Mandatory = $True)]
    $ServiceDirectory,
    $ArtifactsDirectoryName,
    $RepoRoot = "${PSScriptRoot}/../..",
    [Parameter(Mandatory = $True)]
    $BinDirectory,
    $DocGenDir = "${PSScriptRoot}",
    $ArtifactStagingDirectory
)

function Log-Warning($message) {
    Write-Host "##vso[task.logissue type=warning;]$message"
}

function UpdateDocIndexFiles([string]$docPath, [string] $mainJsPath) {
    # Update docfx.json
    $docfxContent = Get-Content -Path $docPath -Raw
    $docfxContent = $docfxContent -replace "`"_appTitle`": `"`"", "`"_appTitle`": `"Azure SDK for .NET`""
    $docfxContent = $docfxContent -replace "`"_appFooter`": `"`"", "`"_appFooter`": `"Azure SDK for .NET`""
    Set-Content -Path $docPath -Value $docfxContent -NoNewline
    # Update main.js var lang
    $mainJsContent = Get-Content -Path $mainJsPath -Raw
    $mainJsContent = $mainJsContent -replace "var SELECTED_LANGUAGE = ''", "var SELECTED_LANGUAGE = 'dotnet'"
    # Update main.js var index html
    $mainJsContent = $mainJsContent -replace "var INDEX_HTML = ''", "var INDEX_HTML = 'index.html'"
    Set-Content -Path $mainJsPath -Value $mainJsContent -NoNewline
}

Write-Verbose "Name Reccuring paths with variable names"
if ([System.String]::IsNullOrEmpty($ArtifactsDirectoryName)) {
    $ArtifactsDirectoryName = $ArtifactName
}
$PackageLocation = "${ServiceDirectory}/${ArtifactsDirectoryName}"
$FrameworkDir = "${BinDirectory}/${ArtifactsDirectoryName}/dll-docs"
$ApiDir = "${FrameworkDir}/my-api"
$ApiDependenciesDir = "${FrameworkDir}/dependencies/my-api"
$XmlOutDir = "${BinDirectory}/${ArtifactsDirectoryName}/dll-xml-output"
$YamlOutDir = "${BinDirectory}/${ArtifactsDirectoryName}/dll-yaml-output"
$DocOutDir = "${BinDirectory}/${ArtifactsDirectoryName}/docfx-output/docfx_project"
$DocOutApiDir = "${DocOutDir}/api"
$DocOutHtmlDir = "${DocOutDir}/_site"
$MDocTool = "${BinDirectory}/mdoc/mdoc.exe"
$DocFxTool = "${BinDirectory}/docfx/docfx.exe"
$DocCommonGenDir = "${RepoRoot}/eng/common/docgeneration"
$GACampaignId = "UA-62780441-41"

Write-Verbose "Package Location ${PackageLocation}"

Write-Verbose "Create Directories Required for Doc Generation"
Write-Verbose "Creating ApiDir '$ApiDir'"
mkdir $ApiDir
Write-Verbose "Creating ApiDependenciesDir '$ApiDependenciesDir'"
mkdir $ApiDependenciesDir
Write-Verbose "Creating XmlOutDir '$XmlOutDir'"
mkdir $XmlOutDir
Write-Verbose "Creating YamlOutDir '$YamlOutDir'"
mkdir $YamlOutDir
Write-Verbose "Creating DocOutDir '$DocOutDir'"
mkdir $DocOutDir

Write-Verbose "Build Packages for Doc Generation - Client"
Write-Verbose "dotnet build '${RepoRoot}/eng/service.proj' /p:ServiceDirectory=$ServiceDirectory /p:Project=$ArtifactsDirectoryName /p:IncludeTests=false /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:BuildInParallel=false /p:OutputPath=$ApiDir"
dotnet build "${RepoRoot}/eng/service.proj" /p:ServiceDirectory=$ServiceDirectory /p:Project=$ArtifactsDirectoryName /p:IncludeTests=false /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:BuildInParallel=false /p:OutputPath=$ApiDir
if ($LASTEXITCODE -ne 0) {
    Log-Warning "Build Packages for Doc Generation - Client failed with $LASTEXITCODE please see output above"
    exit 0
}

Write-Verbose "Include Client Dependencies"
Write-Verbose "'${RepoRoot}/eng/service.proj' /p:ServiceDirectory=$ServiceDirectory /p:Project=$ArtifactsDirectoryName /p:IncludeTests=false /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:BuildInParallel=false /p:OutputPath=$ApiDependenciesDir /p:CopyLocalLockFileAssemblies=true"
dotnet build "${RepoRoot}/eng/service.proj" /p:ServiceDirectory=$ServiceDirectory /p:Project=$ArtifactsDirectoryName /p:IncludeTests=false /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:BuildInParallel=false /p:OutputPath=$ApiDependenciesDir /p:CopyLocalLockFileAssemblies=true
if ($LASTEXITCODE -ne 0) {
    Log-Warning "Include Client Dependencies build failed with $LASTEXITCODE please see output above"
    exit 0
}

Write-Verbose "Remove all unneeded artifacts from build output directory"
Remove-Item -Path "${ApiDir}/*" -Include * -Exclude "${ArtifactName}.dll", "${ArtifactName}.xml" -Recurse -Force

Write-Verbose "Initialize Frameworks File"
& "${MDocTool}" fx-bootstrap "${FrameworkDir}"

Write-Verbose "Include XML Files"
& "${BinDirectory}/PopImport/popimport.exe" -f "${FrameworkDir}"

Write-Verbose "Produce ECMAXML"
& "${MDocTool}" update -fx "${FrameworkDir}" -o "${XmlOutDir}" --debug -lang docid -lang vb.net -lang fsharp --delete

Write-Verbose "Generate YAML"
& "${BinDirectory}/ECMA2Yml/ECMA2Yaml.exe" -s "${XmlOutDir}" -o "${YamlOutDir}"

Write-Verbose "Provision DocFX Directory"
& "${DocFxTool}" init -q -o "${DocOutDir}"

Write-Verbose "Copy over Package ReadMe"
$PkgReadMePath = "${RepoRoot}/sdk/${PackageLocation}/README.md"
if ([System.IO.File]::Exists($PkgReadMePath)) {
    Copy-Item $PkgReadMePath -Destination "${DocOutApiDir}/index.md" -Force
}
else {
    New-Item "${DocOutApiDir}/index.md" -Force
    Add-Content -Path "${DocOutApiDir}/index.md" -Value "This Package Contains no Readme."
    Write-Verbose "Package ReadMe was not found"
}

Write-Verbose "Make changes to docfx.json and main.js."
UpdateDocIndexFiles -docPath "${DocCommonGenDir}/docfx.json" -mainJsPath "${DocCommonGenDir}\templates\matthews\styles\main.js"

Write-Verbose "Copy over generated yml and other assets"
Copy-Item "${YamlOutDir}/*"-Destination "${DocOutApiDir}" -Recurse -Force
New-Item -Path "${DocOutDir}" -Name templates -ItemType directory
Copy-Item "${DocCommonGenDir}/templates/**" -Destination "${DocOutDir}/templates" -Recurse -Force
Copy-Item "${DocCommonGenDir}/docfx.json" -Destination "${DocOutDir}" -Force

$headerTemplateLocation = "${DocOutDir}/templates/matthews/partials/head.tmpl.partial"

if (Test-Path $headerTemplateLocation){
    $headerTemplateContent = Get-Content -Path $headerTemplateLocation -Raw
    $headerTemplateContent = $headerTemplateContent -replace "GA_CAMPAIGN_ID", $GACampaignId
    Set-Content -Path $headerTemplateLocation -Value $headerTemplateContent -NoNewline
}

Write-Verbose "Create Toc for Site Navigation"
New-Item "${DocOutDir}/toc.yml" -Force
Add-Content -Path "${DocOutDir}/toc.yml" -Value "- name: ${ArtifactName}`r`n  href: index.md"

Write-Verbose "Build Doc Content"
& "${DocFxTool}" build "${DocOutDir}/docfx.json"

Write-Verbose "Copy over site Logo"
Copy-Item "${DocCommonGenDir}/assets/logo.svg" -Destination "${DocOutHtmlDir}" -Recurse -Force

# Copy everything inside of /api out.
Write-Verbose "Copy index.html and toc.yml out."
$destFolder = "${DocOutHtmlDir}/"
Copy-Item -Path "${DocOutHtmlDir}/api/index.html" -Destination $destFolder -Confirm:$false -Force

# Change the relative path inside index.html.
Write-Verbose "Make changes on relative path on page index.html."
$baseUrl = $destFolder + "index.html"
$content = Get-Content -Path $baseUrl -Raw
$hrefRegex = "[""']\.\.\/([^""']*)[""']"
$tocRegex = "[""'](./)?toc.html[""']"
# The order matters for the following mutations. If excutes the latter one, then we will see two same toc.html path.
$mutatedContent = $content -replace $tocRegex , "`"./api/toc.html`""
$mutatedContent = $mutatedContent -replace $hrefRegex, '"./$1"'
Set-Content -Path $baseUrl -Value $mutatedContent -NoNewline

Write-Verbose "Compress and copy HTML into the staging Area"
Compress-Archive -Path "${DocOutHtmlDir}/*" -DestinationPath "${ArtifactStagingDirectory}/${ArtifactName}/${ArtifactName}.docs.zip" -CompressionLevel Fastest

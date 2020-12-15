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

.PARAMETER LibType
Specifies if its a client or management library

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
    [ValidateSet('client', 'management')]
    $LibType = "client",
    $RepoRoot = "${PSScriptRoot}/../..",
    [Parameter(Mandatory = $True)]
    $BinDirectory,
    $DocGenDir = "${PSScriptRoot}",
    $ArtifactStagingDirectory
)

Write-Verbose "Name Reccuring paths with variable names"
if ([System.String]::IsNullOrEmpty($ArtifactsDirectoryName)) {$ArtifactsDirectoryName = $ArtifactName}
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
$DocCommonGenDir = "$RepoRoot/eng/common/docgeneration"

if ($LibType -eq 'management') {
    $ArtifactName = $ArtifactName.Substring($ArtifactName.LastIndexOf('.Management') + 1)
}

Write-Verbose "Package Location ${PackageLocation}"

Write-Verbose "Create Directories Required for Doc Generation"
mkdir $ApiDir
mkdir $ApiDependenciesDir
mkdir $XmlOutDir
mkdir $YamlOutDir
mkdir $DocOutDir

if ($LibType -eq 'client') { 
    Write-Verbose "Build Packages for Doc Generation - Client"
    dotnet build "${RepoRoot}/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:OutputPath=$ApiDir /p:TargetFramework=netstandard2.0

    Write-Verbose "Include client Dependencies"
    dotnet build "${RepoRoot}/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:OutputPath=$ApiDependenciesDir /p:TargetFramework=netstandard2.0 /p:CopyLocalLockFileAssemblies=true
}

if ($LibType -eq 'management') {
    # Management Package
    Write-Verbose "Build Packages for Doc Generation - Management"
    dotnet msbuild "${RepoRoot}/eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath=$ApiDir -maxcpucount:1 -nodeReuse:false

    Write-Verbose "Include Management Dependencies"
    dotnet msbuild "${RepoRoot}/eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath=$ApiDependenciesDir /p:CopyLocalLockFileAssemblies=true -maxcpucount:1 -nodeReuse:false
}

Write-Verbose "Remove all unneeded artifacts from build output directory"
Remove-Item –Path "${ApiDir}/*" -Include * -Exclude "${ArtifactName}.dll", "${ArtifactName}.xml"

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
    Copy-Item $PkgReadMePath -Destination "${DocOutDir}/index.md" -Force
}
else {
    New-Item "${DocOutApiDir}/index.md" -Force
    Add-Content -Path "${DocOutApiDir}/index.md" -Value "This Package Contains no Readme."
    Copy-Item "${DocOutApiDir}/index.md" -Destination "${DocOutDir}/index.md" -Force
    Write-Verbose "Package ReadMe was not found"
}

Write-Verbose "Copy over generated yml and other assets"
Copy-Item "${YamlOutDir}/*"-Destination "${DocOutApiDir}" -Recurse -Force
Copy-Item "${DocGenDir}/assets/docfx.json" -Destination "${DocOutDir}" -Recurse -Force
New-Item -Path "${DocOutDir}" -Name templates -ItemType directory
Copy-Item "${DocCommonGenDir}/templates/**" -Destination "${DocOutDir}/templates" -Recurse -Force

Write-Verbose "Create Toc for Site Navigation"
New-Item "${DocOutDir}/toc.yml" -Force
Add-Content -Path "${DocOutDir}/toc.yml" -Value "- name: ${ArtifactName}`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Build Doc Content"
& "${DocFxTool}" build "${DocOutDir}/docfx.json"

Write-Verbose "Copy over site Logo"
Copy-Item "${DocCommonGenDir}/assets/logo.svg" -Destination "${DocOutHtmlDir}" -Recurse -Force

Write-Verbose "Compress and copy HTML into the staging Area"
Compress-Archive -Path "${DocOutHtmlDir}/*" -DestinationPath "${ArtifactStagingDirectory}/${ArtifactName}/${ArtifactName}.docs.zip" -CompressionLevel Fastest
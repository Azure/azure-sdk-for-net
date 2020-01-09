# Generates API Docs from the Azure-SDK-for-NET repo
 
[CmdletBinding()]
Param (
    $ArtifactName,
    $ServiceDirectory,
    $ArtifactsDirectoryName,
    $LibType,
    $RepoRoot,
    $BinDirectory,
    $DocGenDir
)

Write-Verbose "Name Reccuring paths with variable names"
if ($ArtifactsDirectoryName -eq '') {$ArtifactsDirectoryName = $ArtifactName}
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

if ($ServiceDirectory -eq '*') {
    $PackageLocation = "core/${ArtifactName}"
}

if ($LibType -eq 'Management') {
    $ArtifactName = $ArtifactName.Substring($ArtifactName.LastIndexOf('.Management') + 1)
}

Write-Verbose "Package Location ${PackageLocation}"

Write-Verbose "Create Directories Required for Doc Generation"
mkdir $ApiDir
mkdir $ApiDependenciesDir
mkdir $XmlOutDir
mkdir $YamlOutDir
mkdir $DocOutDir

if ($LibType -eq '') { 
    Write-Verbose "Build Packages for Doc Generation - Client"
    dotnet build "${RepoRoot}/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath=$ApiDir /p:TargetFramework=netstandard2.0

    Write-Verbose "Include client Dependencies"
    dotnet build "${RepoRoot}/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath=$ApiDependenciesDir /p:TargetFramework=netstandard2.0 /p:CopyLocalLockFileAssemblies=true
}

if ($LibType -eq 'Management') { # Management Package
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
if ([System.IO.File]::Exists($PkgReadMePath))
{
    Copy-Item $PkgReadMePath -Destination "${DocOutApiDir}/index.md" -Force
    Copy-Item $PkgReadMePath -Destination "${DocOutDir}/index.md" -Force
}
else
{
    New-Item "${DocOutApiDir}/index.md" -Force
    Add-Content -Path "${DocOutApiDir}/index.md" -Value "This Package Contains no Readme."
    Copy-Item "${DocOutApiDir}/index.md" -Destination "${DocOutDir}/index.md" -Force
    Write-Verbose "Package ReadMe was not found"
}

Write-Verbose "Copy over generated yml and other assets"
Copy-Item "${YamlOutDir}/*"-Destination "${DocOutDir}/api" -Recurse
Copy-Item "${DocGenDir}/assets/docfx.json" -Destination "${DocOutDir}" -Recurse -Force
New-Item -Path "${DocOutDir}" -Name templates -ItemType directory
Copy-Item "${DocGenDir}/templates/**" -Destination "${DocOutDir}/templates" -Recurse -Force

Write-Verbose "Create Toc for Site Navigation"
New-Item "${DocOutDir}/toc.yml" -Force
Add-Content -Path "${DocOutDir}/toc.yml" -Value "- name: ${ArtifactName}`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Build Doc Content"
& "${DocFxTool}" build "${DocOutDir}/docfx.json"

Write-Verbose "Copy over site Logo"
Copy-Item "${DocGenDir}/assets/logo.svg" -Destination "${DocOutHtmlDir}" -Recurse -Force

Write-Verbose "Set variable for publish pipeline step"
echo "##vso[task.setvariable variable=PublishTargetPath]${DocOutHtmlDir}"
# Generates API Docs from the Azure-SDK-for-NET repo
 
[CmdletBinding()]
Param (
    $ArtifactName,
    $ServiceDirectory,
    $ArtifactsSafeName,
    $ArtifactsDirectoryName,
    $LibType,
    $RepoRoot,
    $BinDirectory
)

# Include if runing Build-Docs locally
# Get-DocTools -DownloadDirectory $BinDirectory -RepoRoot $RepoRoot

Write-Verbose "Create variables for identifying package location and package safe names"
$PackageLocation = "$($ServiceDirectory)/$($ArtifactName)"
Write-Verbose "Package Location $($PackageLocation)"
$SafeName = $ArtifactsSafeName

if ($ServiceDirectory -eq '*') {
    $PackageLocation = "core/$($ArtifactName)"
}

if ($ServiceDirectory -eq 'cognitiveservices') {
    $PackageLocation = "cognitiveservices/$($ArtifactsDirectoryName)"
    $SafeName = $ArtifactsDirectoryName
}

if ($LibType -eq 'Management') {
    $PackageLocation = "$($ServiceDirectory)/$($ArtifactName)"
    $SafeName = $($ArtifactName)
    $SafeName = $SafeName.Substring($SafeName.LastIndexOf('.Management') + 1)
}

Write-Verbose "Set variable for publish pipeline step"
echo "##vso[task.setvariable variable=artifactsafename]$($SafeName)"

Write-Verbose "Create Directories Required for Doc Generation"
mkdir "$($BinDirectory)/$($SafeName)/dll-docs/my-api"
mkdir "$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api"
mkdir "$($BinDirectory)/$($SafeName)/dll-xml-output"
mkdir "$($BinDirectory)/$($SafeName)/dll-yaml-output"
mkdir "$($BinDirectory)/$($SafeName)/docfx-output"

$ApiDir = "$($BinDirectory)/$($SafeName)/dll-docs/my-api"
$ApiDependenciesDir = "$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api"
$XmlOutDir = "$($BinDirectory)/$($SafeName)/dll-xml-output"
$YamlOutDir = "$($BinDirectory)/$($SafeName)/dll-yaml-output"
$DocOutDir = "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project"

if ($LibType -eq '') { 
    Write-Verbose "Build Packages for Doc Generation - Client"
    dotnet build "$($RepoRoot)/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath=$ApiDir /p:TargetFramework=netstandard2.0

    Write-Verbose "Include client Dependencies"
    dotnet build "$($RepoRoot)/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath=$ApiDependenciesDir /p:TargetFramework=netstandard2.0 /p:CopyLocalLockFileAssemblies=true
}

if ($LibType -eq 'Management') { # Management Package
    Write-Verbose "Build Packages for Doc Generation - Management"
    dotnet msbuild "eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath=$ApiDir -maxcpucount:1 -nodeReuse:false

    Write-Verbose "Include Management Dependencies"
    dotnet msbuild "eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath=$ApiDependenciesDir /p:CopyLocalLockFileAssemblies=true -maxcpucount:1 -nodeReuse:false
}

Write-Verbose "Remove all unneeded artifacts from build output directory"
Remove-Item –Path "$($ApiDir)/*" -Include * -Exclude "$($ArtifactName).dll", "$($ArtifactName).xml"

Write-Verbose "Initialize Frameworks File"
& "$($BinDirectory)/mdoc/mdoc.exe" fx-bootstrap "$($BinDirectory)/$($SafeName)/dll-docs"

Write-Verbose "Include XML Files"
& "$($BinDirectory)/PopImport/popimport.exe" -f "$($BinDirectory)/$($SafeName)/dll-docs"

Write-Verbose "Produce ECMAXML"
& "$($BinDirectory)/mdoc/mdoc.exe" update -fx "$($BinDirectory)/$($SafeName)/dll-docs" -o $XmlOutDir --debug -lang docid -lang vb.net -lang fsharp --delete

Write-Verbose "Generate YAML"
& "$($BinDirectory)/ECMA2Yml/ECMA2Yaml.exe" -s $XmlOutDir -o $YamlOutDir

Write-Verbose "Provision DocFX Directory"
& "$($BinDirectory)/docfx/docfx.exe" init -q -o "$($DocOutDir)"

Write-Verbose "Copy over Package ReadMe"
$PkgReadMePath = "$($RepoRoot)/sdk/$($PackageLocation)/README.md"
if ([System.IO.File]::Exists($PkgReadMePath))
{
    Copy-Item $PkgReadMePath -Destination "$($DocOutDir)/api/index.md" -Force
    Copy-Item $PkgReadMePath -Destination "$($DocOutDir)/index.md" -Force
}
else
{
    New-Item "$($DocOutDir)/api/index.md" -Force
    Add-Content -Path "$($DocOutDir)/api/index.md" -Value "This Package Contains no Readme."
    Copy-Item "$($DocOutDir)/api/index.md" -Destination "$($DocOutDir)/index.md"-Force
    Write-Verbose "Package ReadMe was not found"
}

Write-Verbose "Copy over generated yml and other assets"
Copy-Item "$($YamlOutDir)/*"-Destination "$($DocOutDir)/api" -Recurse
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/docfx.json" -Destination "$($DocOutDir)" -Recurse -Force
New-Item -Path "$($DocOutDir)" -Name templates -ItemType directory
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/templates/**" -Destination "$($DocOutDir)/templates" -Recurse -Force

Write-Verbose "Create Toc for Site Navigation"
New-Item "$($DocOutDir)/toc.yml" -Force
Add-Content -Path "$($DocOutDir)/toc.yml" -Value "- name: $ArtifactName`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Build Doc Content"
& "$($BinDirectory)/docfx/docfx.exe" build "$($DocOutDir)/docfx.json"

Write-Verbose "Copy over site Logo"
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/logo.svg" -Destination "$($DocOutDir)/_site" -Recurse -Force
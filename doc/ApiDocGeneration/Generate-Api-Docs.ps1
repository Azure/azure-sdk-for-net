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

if ($LibType -eq '') { 
    Write-Verbose "Build Packages for Doc Generation - Client"
    dotnet build "$($RepoRoot)/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/my-api" /p:TargetFramework=netstandard2.0

    Write-Verbose "Include client Dependencies"
    dotnet build "$($RepoRoot)/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api" /p:TargetFramework=netstandard2.0 /p:CopyLocalLockFileAssemblies=true
}

if ($LibType -eq 'Management') { # Management Package
    Write-Verbose "Build Packages for Doc Generation - Management"
    dotnet msbuild "eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/my-api" -maxcpucount:1 -nodeReuse:false

    Write-Verbose "Include Management Dependencies"
    dotnet msbuild "eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api" /p:CopyLocalLockFileAssemblies=true -maxcpucount:1 -nodeReuse:false
}

Write-Verbose "Remove all unneeded artifacts from build output directory"
Remove-Item –Path "$($BinDirectory)/$($SafeName)/dll-docs/my-api/*" -Include * -Exclude "$($ArtifactName).dll", "$($ArtifactName).xml"

Write-Verbose "Initialize Frameworks File"
& "$($BinDirectory)/mdoc/mdoc.exe" fx-bootstrap "$($BinDirectory)/$($SafeName)/dll-docs"

Write-Verbose "Include XML Files"
& "$($BinDirectory)/PopImport/popimport.exe" -f "$($BinDirectory)/$($SafeName)/dll-docs"

Write-Verbose "Produce ECMAXML"
& "$($BinDirectory)/mdoc/mdoc.exe" update -fx "$($BinDirectory)/$($SafeName)/dll-docs" -o "$($BinDirectory)/$($SafeName)/dll-xml-output" --debug -lang docid -lang vb.net -lang fsharp --delete

Write-Verbose "Generate YAML"
& "$($BinDirectory)/ECMA2Yml/ECMA2Yaml.exe" -s "$($BinDirectory)/$($SafeName)/dll-xml-output" -o "$($BinDirectory)/$($SafeName)/dll-yaml-output"

Write-Verbose "Provision DocFX Directory"
& "$($BinDirectory)/docfx/docfx.exe" init -q -o "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project"

Write-Verbose "Copy over Package ReadMe"
$PkgReadMePath = "$($RepoRoot)/sdk/$($PackageLocation)/README.md"
if ([System.IO.File]::Exists($PkgReadMePath))
{
    Copy-Item $PkgReadMePath -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Force
    Copy-Item $PkgReadMePath -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/index.md" -Force
}
else
{
    New-Item "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Force
    Add-Content -Path "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Value "This Package Contains no Readme."
    Copy-Item "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/index.md"-Force
    Write-Verbose "Package ReadMe was not found"
}

Write-Verbose "Copy over generated yml and other assets"
Copy-Item "$($BinDirectory)/$($SafeName)/dll-yaml-output/*"-Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api" -Recurse
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/docfx.json" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project" -Recurse -Force
New-Item -Path "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project" -Name templates -ItemType directory
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/templates/**" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/templates" -Recurse -Force

Write-Verbose "Create Toc for Site Navigation"
New-Item "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/toc.yml" -Force
Add-Content -Path "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/toc.yml" -Value "- name: $ArtifactName`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Build Doc Content"
& "$($BinDirectory)/docfx/docfx.exe" build "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/docfx.json"

Write-Verbose "Copy over site Logo"
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/logo.svg" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/_site" -Recurse -Force
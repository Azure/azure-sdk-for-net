param(
    [Parameter(Mandatory=$true)]
    [string] $PackageInfoFolder,
    [Parameter(Mandatory=$true)]
    [string] $SdkType,
    [Parameter(Mandatory=$true)]
    [string] $ProjectNames,
    [Parameter(Mandatory=$false)]
    [string] $BuildConfiguration,
    [Parameter(Mandatory=$false)]
    [string] $DiagnosticArguments
)
. $PSScriptRoot/splittestdependencies/generate-dependency-functions.ps1

$ErrorActionPreference = "Stop"
Set-StrictMode -Version 4

$TargetProjects = $ProjectNames -split ","
$RepoRoot = Resolve-Path (Join-Path "$PSScriptRoot" ".." "..")

$snippetEnabledProjects = Get-ChildItem -Recurse "$PackageInfoFolder" *.json `
| Foreach-Object { Get-Content -Raw -Path $_.FullName | ConvertFrom-Json } `
| Where-Object { $_.ArtifactName -in $TargetProjects -and $_.CIParameters.BuildSnippets -eq $true }
| ForEach-Object { $_.ArtifactName }

if ($snippetEnabledProjects) {
    $scopedFile = Write-PkgInfoToDependencyGroupFile -OutputPath "$RepoRoot" -PackageInfoFolder $PackageInfoFolder -ProjectNames $snippetEnabledProjects

    Write-Host "Writing project list to $scopedFile"
    Write-Host (Get-Content -Raw -Path $scopedFile)

    dotnet build eng/service.proj -warnaserror `
    /t:rebuild `
    /p:DebugType=none `
    /p:SDKType=$SdkType `
    /p:ServiceDirectory=* `
    /p:IncludePerf=false `
    /p:IncludeStress=false `
    /p:PublicSign=false `
    /p:Configuration="$BuildConfiguration" `
    /p:EnableSourceLink=false `
    /p:BuildSnippets=true `
    /p:ProjectListOverrideFile="$scopedFile" `
    $DiagnosticArguments
}
else {
    Write-Host "There are no projects with BuildSnippets set to true. Evaluated projects: $ProjectNames"
}


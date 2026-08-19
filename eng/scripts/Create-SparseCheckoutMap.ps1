#!/usr/bin/env pwsh

<#
.SYNOPSIS
Builds artifact-to-checkout-path mappings from evaluated MSBuild project graphs.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $PackageInfoDirectory,

  [Parameter(Mandatory = $true)]
  [string] $RepoRoot,

  [Parameter(Mandatory = $true)]
  [string] $OutputPath
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$repositoryRoot = (Resolve-Path -LiteralPath $RepoRoot).Path
$packageInfoRoot = (Resolve-Path -LiteralPath $PackageInfoDirectory).Path
$outputFullPath = [System.IO.Path]::GetFullPath($OutputPath)
$outputDirectory = Split-Path -Parent $outputFullPath
$targetsPath = Join-Path $repositoryRoot 'eng/SparseCheckout.targets'
$workDirectory = Join-Path ([System.IO.Path]::GetTempPath()) "azsdk-sparse-map-$([guid]::NewGuid().ToString('N'))"

$alwaysIncludedPaths = @(
  '/*'
  '!/*/'
  '/eng'
  '/.config'
  '/.devcontainer'
  '/.github'
  '/.vscode'
  '/common'
  '/doc'
  '/samples'
  '/sdk/core/*'
  '/sdk/common/*'
  '/sdk/identity/*'
  '/sdk/resourcemanager/*'
  '/sdk/template/*'
  '/sdk/tools/*'
)

function ConvertTo-XmlAttribute([string] $Value) {
  return [System.Security.SecurityElement]::Escape($Value)
}

function ConvertTo-CheckoutPath([string] $Directory) {
  return "/$($Directory.Trim('/').Replace('\', '/'))/*"
}

$map = [ordered]@{
  '$alwaysIncludedPaths' = $alwaysIncludedPaths
}

try {
  $null = New-Item -ItemType Directory -Path $workDirectory -Force
  $packageInfoFiles = @(Get-ChildItem -LiteralPath $packageInfoRoot -Filter '*.json' -File -Recurse | Sort-Object FullName)
  if ($packageInfoFiles.Count -eq 0) {
    throw "No package information files were found under '$packageInfoRoot'."
  }

  foreach ($packageInfoFile in $packageInfoFiles) {
    $packageInfo = Get-Content -LiteralPath $packageInfoFile.FullName -Raw | ConvertFrom-Json
    $artifactName = [string] $packageInfo.ArtifactName
    $directoryPath = ([string] $packageInfo.DirectoryPath).Replace('\', '/').Trim('/')
    if ([string]::IsNullOrWhiteSpace($artifactName) -or [string]::IsNullOrWhiteSpace($directoryPath)) {
      Write-Warning "Package info '$($packageInfoFile.FullName)' is missing ArtifactName or DirectoryPath; it cannot be narrowed."
      continue
    }
    if ($map.Contains($artifactName)) {
      continue
    }
    if ($directoryPath -notmatch '^sdk/[^/]+/[^/]+(?:/|$)') {
      Write-Warning "Artifact '$artifactName' has unsupported directory '$directoryPath'; it will use a full checkout."
      $map[$artifactName] = $null
      continue
    }

    $packageRoot = Join-Path $repositoryRoot $directoryPath
    $projects = @(Get-ChildItem -LiteralPath $packageRoot -Filter '*.csproj' -File -Recurse -ErrorAction SilentlyContinue)
    if ($projects.Count -eq 0) {
      Write-Warning "Artifact '$artifactName' has no projects under '$directoryPath'; it will use a full checkout."
      $map[$artifactName] = $null
      continue
    }

    $safeName = $artifactName -replace '[^A-Za-z0-9_.-]', '_'
    $entryProject = Join-Path $workDirectory "$safeName.proj"
    $manifestPath = Join-Path $workDirectory "$safeName.manifest"
    $projectReferences = $projects | Sort-Object FullName | ForEach-Object {
      "    <ProjectReference Include=`"$(ConvertTo-XmlAttribute $_.FullName)`" />"
    }
    @(
      '<Project>'
      '  <ItemGroup>'
      $projectReferences
      '  </ItemGroup>'
      "  <Import Project=`"$(ConvertTo-XmlAttribute $targetsPath)`" />"
      '</Project>'
    ) | Set-Content -LiteralPath $entryProject -Encoding utf8NoBOM

    Write-Host "Evaluating sparse checkout closure for $artifactName"
    & dotnet msbuild $entryProject /t:GenerateSparseCheckoutManifest `
      "/p:RepoRoot=$repositoryRoot" `
      "/p:SparseCheckoutManifestPath=$manifestPath" `
      '/p:UseProjectReferenceToAzureClients=true' `
      --nologo --verbosity:minimal
    if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $manifestPath -PathType Leaf)) {
      Write-Warning "MSBuild could not evaluate '$artifactName'; it will use a full checkout."
      $map[$artifactName] = $null
      continue
    }

    $map[$artifactName] = @(
      Get-Content -LiteralPath $manifestPath |
        Where-Object { $_ } |
        ForEach-Object { ConvertTo-CheckoutPath $_ } |
        Sort-Object -Unique
    )
  }

  $null = New-Item -ItemType Directory -Path $outputDirectory -Force
  $map | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $outputFullPath -Encoding utf8NoBOM
}
finally {
  if (Test-Path -LiteralPath $workDirectory) {
    Remove-Item -LiteralPath $workDirectory -Recurse -Force
  }
}

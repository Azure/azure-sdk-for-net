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

function Add-PathSetValue(
  [System.Collections.Generic.Dictionary[string, object]] $Dictionary,
  [string] $Key,
  [string] $Value
) {
  if (-not $Dictionary.ContainsKey($Key)) {
    $Dictionary[$Key] = [System.Collections.Generic.HashSet[string]]::new($pathComparer)
  }
  $null = $Dictionary[$Key].Add($Value)
}

function ConvertTo-CheckoutPath([string] $Path, [bool] $IsProject) {
  $cacheKey = "$IsProject|$Path"
  if ($checkoutPathCache.ContainsKey($cacheKey)) {
    return $checkoutPathCache[$cacheKey]
  }

  $fullPath = [System.IO.Path]::GetFullPath($Path)
  if (-not $fullPath.StartsWith($rootWithSeparator, $pathComparison)) {
    if ($IsProject) {
      throw "Sparse-checkout graph project '$fullPath' is outside repository root '$repositoryRoot'."
    }
    $checkoutPathCache[$cacheKey] = $null
    return $null
  }
  if (-not (Test-Path -LiteralPath $fullPath -PathType Leaf)) {
    if ($IsProject) {
      throw "Sparse-checkout graph project '$fullPath' does not exist."
    }
    $checkoutPathCache[$cacheKey] = $null
    return $null
  }

  $relativePath = [System.IO.Path]::GetRelativePath($repositoryRoot, $fullPath).Replace('\', '/')
  if (-not $IsProject -and $trackedFiles -and -not $trackedFiles.Contains($relativePath)) {
    $checkoutPathCache[$cacheKey] = $null
    return $null
  }
  $segments = @($relativePath -split '/' | Where-Object { $_ })
  if ($segments.Count -lt 2 -or $segments[0] -eq '..') {
    $checkoutPathCache[$cacheKey] = $null
    return $null
  }
  if ($segments[0] -eq 'sdk') {
    if ($segments.Count -lt 3) {
      throw "SDK graph path '$fullPath' is not beneath a service directory."
    }
    $checkoutPathCache[$cacheKey] = "/sdk/$($segments[1])/*"
    return $checkoutPathCache[$cacheKey]
  }
  if ($alwaysIncludedRootDirectories.Contains($segments[0])) {
    $checkoutPathCache[$cacheKey] = $null
    return $null
  }

  $directory = [System.IO.Path]::GetDirectoryName($relativePath).Replace('\', '/')
  if ([string]::IsNullOrWhiteSpace($directory) -or $directory -eq '.') {
    $checkoutPathCache[$cacheKey] = $null
    return $null
  }
  $checkoutPathCache[$cacheKey] = "/$($directory.Trim('/'))/*"
  return $checkoutPathCache[$cacheKey]
}

$map = [ordered]@{
  '$alwaysIncludedPaths' = $alwaysIncludedPaths
}
$pathComparison = if ($IsWindows) {
  [System.StringComparison]::OrdinalIgnoreCase
}
else {
  [System.StringComparison]::Ordinal
}
$pathComparer = if ($IsWindows) {
  [System.StringComparer]::OrdinalIgnoreCase
}
else {
  [System.StringComparer]::Ordinal
}
$repositoryRoot = $repositoryRoot.TrimEnd(
  [System.IO.Path]::DirectorySeparatorChar,
  [System.IO.Path]::AltDirectorySeparatorChar)
$rootWithSeparator = $repositoryRoot + [System.IO.Path]::DirectorySeparatorChar
$alwaysIncludedRootDirectories = [System.Collections.Generic.HashSet[string]]::new(
  [System.StringComparer]::Ordinal)
foreach ($path in $alwaysIncludedPaths) {
  if ($path -match '^/([^/*]+)(?:/\*)?$' -and $Matches[1] -ne 'sdk') {
    $null = $alwaysIncludedRootDirectories.Add($Matches[1])
  }
}
$checkoutPathCache = [System.Collections.Generic.Dictionary[string, object]]::new(
  [System.StringComparer]::Ordinal)
$trackedFiles = $null
$isGitWorkTree = & git -C $repositoryRoot rev-parse --is-inside-work-tree 2>$null
if ($LASTEXITCODE -eq 0 -and $isGitWorkTree -eq 'true') {
  $trackedFiles = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
  foreach ($trackedFile in (& git -C $repositoryRoot ls-files)) {
    $null = $trackedFiles.Add($trackedFile.Replace('\', '/'))
  }
  if ($LASTEXITCODE -ne 0) {
    throw "Unable to enumerate tracked files under '$repositoryRoot'."
  }
}

try {
  $null = New-Item -ItemType Directory -Path $workDirectory -Force
  $packageInfoFiles = @(Get-ChildItem -LiteralPath $packageInfoRoot -Filter '*.json' -File -Recurse | Sort-Object FullName)
  if ($packageInfoFiles.Count -eq 0) {
    throw "No package information files were found under '$packageInfoRoot'."
  }

  $artifactProjects = [ordered]@{}
  $allEntryProjects = [System.Collections.Generic.SortedSet[string]]::new($pathComparer)
  foreach ($packageInfoFile in $packageInfoFiles) {
    $packageInfo = Get-Content -LiteralPath $packageInfoFile.FullName -Raw | ConvertFrom-Json
    $artifactName = [string] $packageInfo.ArtifactName
    $directoryPath = ([string] $packageInfo.DirectoryPath).Replace('\', '/').Trim('/')
    if ([string]::IsNullOrWhiteSpace($artifactName) -or [string]::IsNullOrWhiteSpace($directoryPath)) {
      Write-Warning "Package info '$($packageInfoFile.FullName)' is missing ArtifactName or DirectoryPath; it cannot be narrowed."
      continue
    }
    if ($artifactProjects.Contains($artifactName) -or $map.Contains($artifactName)) {
      continue
    }
    if ($directoryPath -notmatch '^sdk/[^/]+/[^/]+(?:/|$)') {
      Write-Warning "Artifact '$artifactName' has unsupported directory '$directoryPath'; it will use a full checkout."
      $map[$artifactName] = $null
      continue
    }

    $packageRoot = Join-Path $repositoryRoot $directoryPath
    $projects = @(
      Get-ChildItem -LiteralPath $packageRoot -Filter '*.csproj' -File -Recurse -ErrorAction SilentlyContinue |
        Where-Object {
          if (-not $trackedFiles) {
            return $true
          }
          $relativeProject = [System.IO.Path]::GetRelativePath($repositoryRoot, $_.FullName).Replace('\', '/')
          return $trackedFiles.Contains($relativeProject)
        })
    if ($projects.Count -eq 0) {
      Write-Warning "Artifact '$artifactName' has no projects under '$directoryPath'; it will use a full checkout."
      $map[$artifactName] = $null
      continue
    }

    $artifactProjects[$artifactName] = @($projects.FullName | Sort-Object -Unique)
    foreach ($project in $artifactProjects[$artifactName]) {
      $null = $allEntryProjects.Add($project)
    }
  }

  if ($allEntryProjects.Count -eq 0) {
    throw 'Package information did not produce any sparse-checkout entry projects.'
  }

  $entryProject = Join-Path $workDirectory 'SparseCheckoutGraph.proj'
  $graphPath = Join-Path $workDirectory 'SparseCheckoutGraph.txt'
  $projectReferences = $allEntryProjects | ForEach-Object {
    "    <ProjectReference Include=`"$(ConvertTo-XmlAttribute $_)`" />"
  }
  @(
    '<Project>'
    '  <ItemGroup>'
    $projectReferences
    '  </ItemGroup>'
    "  <Import Project=`"$(ConvertTo-XmlAttribute $targetsPath)`" />"
    '</Project>'
  ) | Set-Content -LiteralPath $entryProject -Encoding utf8NoBOM

  $graphWatch = [System.Diagnostics.Stopwatch]::StartNew()
  Write-Host "Evaluating one sparse checkout graph for $($artifactProjects.Count) artifacts and $($allEntryProjects.Count) entry projects"
  & dotnet msbuild $entryProject /t:GenerateSparseCheckoutGraph /m `
    "/p:RepoRoot=$repositoryRoot" `
    "/p:SparseCheckoutGraphPath=$graphPath" `
    '/p:UseProjectReferenceToAzureClients=true' `
    --nologo --verbosity:minimal
  $graphWatch.Stop()
  if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $graphPath -PathType Leaf)) {
    throw "MSBuild could not evaluate the sparse-checkout graph (exit code $LASTEXITCODE)."
  }

  $graphProjects = [System.Collections.Generic.HashSet[string]]::new($pathComparer)
  $referencesByProject = [System.Collections.Generic.Dictionary[string, object]]::new($pathComparer)
  $inputsByProject = [System.Collections.Generic.Dictionary[string, object]]::new($pathComparer)
  foreach ($record in (Get-Content -LiteralPath $graphPath | Where-Object { $_ })) {
    $parts = @($record -split '\|', 3)
    switch ($parts[0]) {
      'Project' {
        if ($parts.Count -ne 2) {
          throw "Invalid sparse-checkout project record '$record'."
        }
        $null = $graphProjects.Add([System.IO.Path]::GetFullPath($parts[1]))
      }
      'Reference' {
        if ($parts.Count -ne 3) {
          throw "Invalid sparse-checkout reference record '$record'."
        }
        Add-PathSetValue $referencesByProject `
          ([System.IO.Path]::GetFullPath($parts[1])) `
          ([System.IO.Path]::GetFullPath($parts[2]))
      }
      'Input' {
        if ($parts.Count -ne 3) {
          throw "Invalid sparse-checkout input record '$record'."
        }
        Add-PathSetValue $inputsByProject `
          ([System.IO.Path]::GetFullPath($parts[1])) `
          ([System.IO.Path]::GetFullPath($parts[2]))
      }
      default {
        throw "Unknown sparse-checkout graph record '$record'."
      }
    }
  }

  $closureWatch = [System.Diagnostics.Stopwatch]::StartNew()
  foreach ($artifact in $artifactProjects.GetEnumerator()) {
    $pending = [System.Collections.Generic.Stack[string]]::new()
    foreach ($project in $artifact.Value) {
      $pending.Push([System.IO.Path]::GetFullPath($project))
    }
    $visited = [System.Collections.Generic.HashSet[string]]::new($pathComparer)
    $checkoutPaths = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::Ordinal)
    $complete = $true

    try {
      while ($pending.Count -gt 0) {
        $project = $pending.Pop()
        if (-not $visited.Add($project)) {
          continue
        }
        if (-not $graphProjects.Contains($project)) {
          Write-Warning "Artifact '$($artifact.Key)' is missing graph project '$project'; it will use a full checkout."
          $complete = $false
          break
        }

        $projectCheckoutPath = ConvertTo-CheckoutPath $project $true
        if ($projectCheckoutPath) {
          $null = $checkoutPaths.Add($projectCheckoutPath)
        }
        if ($inputsByProject.ContainsKey($project)) {
          foreach ($inputPath in $inputsByProject[$project]) {
            $inputCheckoutPath = ConvertTo-CheckoutPath $inputPath $false
            if ($inputCheckoutPath) {
              $null = $checkoutPaths.Add($inputCheckoutPath)
            }
          }
        }
        if ($referencesByProject.ContainsKey($project)) {
          foreach ($reference in $referencesByProject[$project]) {
            $pending.Push($reference)
          }
        }
      }
    }
    catch {
      Write-Warning "Artifact '$($artifact.Key)' has an invalid graph closure ($_); it will use a full checkout."
      $complete = $false
    }

    if ($complete -and $checkoutPaths.Count -gt 0) {
      $map[$artifact.Key] = @($checkoutPaths)
    }
    else {
      $map[$artifact.Key] = $null
    }
  }
  $closureWatch.Stop()

  Write-Host (
    "Sparse checkout map: $($graphProjects.Count) evaluated projects, " +
    "$($artifactProjects.Count) artifact closures, " +
    "$([math]::Round($graphWatch.Elapsed.TotalSeconds, 3))s graph evaluation, " +
    "$([math]::Round($closureWatch.Elapsed.TotalSeconds, 3))s closure calculation")

  $null = New-Item -ItemType Directory -Path $outputDirectory -Force
  $map | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $outputFullPath -Encoding utf8NoBOM
}
finally {
  if (Test-Path -LiteralPath $workDirectory) {
    Remove-Item -LiteralPath $workDirectory -Recurse -Force
  }
}

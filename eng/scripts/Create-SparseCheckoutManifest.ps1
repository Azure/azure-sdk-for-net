#!/usr/bin/env pwsh

<#
.SYNOPSIS
Converts an evaluated MSBuild project graph into safe repository-relative roots.

.DESCRIPTION
SDK projects are conservatively collapsed to sdk/<service>. Projects elsewhere in
the repository retain their project directory. Empty, repository-wide, missing, and
out-of-repository roots are rejected rather than broadening the checkout.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $ProjectListPath,

  [Parameter(Mandatory = $true)]
  [string] $RepoRoot,

  [Parameter(Mandatory = $true)]
  [string] $OutputPath
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$repositoryRoot = [System.IO.Path]::GetFullPath($RepoRoot).TrimEnd(
  [System.IO.Path]::DirectorySeparatorChar,
  [System.IO.Path]::AltDirectorySeparatorChar)
$rootWithSeparator = $repositoryRoot + [System.IO.Path]::DirectorySeparatorChar
$comparison = if ($IsWindows) {
  [System.StringComparison]::OrdinalIgnoreCase
}
else {
  [System.StringComparison]::Ordinal
}

if (Test-Path -LiteralPath $OutputPath) {
  Remove-Item -LiteralPath $OutputPath -Force
}
if (-not (Test-Path -LiteralPath $ProjectListPath -PathType Leaf)) {
  throw "Sparse-checkout project graph '$ProjectListPath' does not exist."
}

$roots = [System.Collections.Generic.SortedSet[string]]::new([System.StringComparer]::Ordinal)
foreach ($projectPath in (Get-Content -LiteralPath $ProjectListPath | Where-Object { $_ })) {
  $fullPath = [System.IO.Path]::GetFullPath($projectPath)
  if (-not $fullPath.StartsWith($rootWithSeparator, $comparison)) {
    throw "Sparse-checkout graph project '$fullPath' is outside repository root '$repositoryRoot'."
  }
  if (-not (Test-Path -LiteralPath $fullPath -PathType Leaf)) {
    throw "Sparse-checkout graph project '$fullPath' does not exist."
  }

  $relativePath = [System.IO.Path]::GetRelativePath($repositoryRoot, $fullPath).Replace('\', '/')
  $segments = @($relativePath -split '/' | Where-Object { $_ })
  if ($segments.Count -lt 2 -or $segments[0] -eq '..') {
    throw "Sparse-checkout graph project '$fullPath' did not produce a safe repository-relative directory."
  }

  if ($segments[0] -eq 'sdk') {
    if ($segments.Count -lt 3) {
      throw "SDK project '$fullPath' is not beneath a service directory."
    }
    $directory = "sdk/$($segments[1])"
  }
  else {
    $directory = [System.IO.Path]::GetDirectoryName($relativePath).Replace('\', '/')
  }

  if ([string]::IsNullOrWhiteSpace($directory) -or $directory -eq '.') {
    throw "Sparse-checkout graph project '$fullPath' produced an empty or repository-wide directory root."
  }

  $null = $roots.Add($directory.Trim('/'))
}

if ($roots.Count -eq 0) {
  throw 'The sparse-checkout project graph did not produce any directory roots.'
}

$outputDirectory = Split-Path -Parent ([System.IO.Path]::GetFullPath($OutputPath))
if ($outputDirectory) {
  $null = New-Item -ItemType Directory -Path $outputDirectory -Force
}
$roots | Set-Content -LiteralPath $OutputPath -Encoding utf8NoBOM

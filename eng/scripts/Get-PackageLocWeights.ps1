<#
.SYNOPSIS
Counts lines of code per package and generates a weight file for build/analyze batching.

.DESCRIPTION
For each PackageInfo JSON file, finds the corresponding src directory and counts
total lines of C# code. Outputs a JSON mapping of package name to LOC count.

.PARAMETER PackageInfoFolder
Path to the folder containing PackageInfo JSON files.

.PARAMETER RepoRoot
Root of the repository.

.PARAMETER OutputFile
Path to write the LOC weights JSON file.
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$PackageInfoFolder,
  [Parameter(Mandatory = $true)][string]$RepoRoot,
  [Parameter(Mandatory = $true)][string]$OutputFile
)

Set-StrictMode -Version 4

$weights = @{}
$packageFiles = Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse

foreach ($file in $packageFiles) {
  $json = Get-Content $file.FullName | ConvertFrom-Json
  $name = $json.ArtifactName
  $dirPath = $json.DirectoryPath

  if (-not $dirPath) {
    $weights[$name] = 1
    continue
  }

  $srcPath = Join-Path $dirPath "src"
  if (-not (Test-Path $srcPath)) {
    $weights[$name] = 1
    continue
  }

  $loc = 0
  Get-ChildItem $srcPath -Filter "*.cs" -Recurse -ErrorAction SilentlyContinue | ForEach-Object {
    $loc += (Get-Content $_.FullName -ErrorAction SilentlyContinue).Count
  }

  $weights[$name] = [math]::Max($loc, 1)
}

Write-Host "Counted LOC for $($weights.Count) packages."
$topPkgs = $weights.GetEnumerator() | Sort-Object Value -Descending | Select-Object -First 5
foreach ($p in $topPkgs) {
  Write-Host "  $($p.Key): $($p.Value) LOC"
}

$weights | ConvertTo-Json -Depth 1 | Set-Content $OutputFile -Encoding utf8
Write-Host "LOC weights written to $OutputFile"

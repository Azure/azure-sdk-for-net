<#
.SYNOPSIS
Counts lines of code per package and generates a weight file for build/analyze batching.

.DESCRIPTION
For each PackageInfo JSON file, finds the corresponding src directory and counts
total lines of C# code. Outputs a JSON mapping of artifact name (the `ArtifactName`
field from PackageInfo) to LOC count.

This script runs inside the matrix-generation job, which every Build and Analyze job
depends on, so it sits directly on the PR-CI critical path. Line counting is therefore
done with a compiled byte-scanning reader and packages are counted in parallel.

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

Add-Type -TypeDefinition @"
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

public static class AzSdkLocCounter
{
    // Kept under the 85,000 byte large-object-heap threshold so repeated scans never touch the LOH.
    private const int BufferSize = 64 * 1024;

    private static long CountFile(string path, byte[] buffer)
    {
        long lines = 0;
        bool any = false;
        byte last = 0;
        // bufferSize 1 disables FileStream's own buffering; we already read into our own buffer.
        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1, FileOptions.SequentialScan))
        {
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                any = true;
                for (int i = 0; i < read; i++)
                {
                    if (buffer[i] == (byte)10) { lines++; }
                }
                last = buffer[read - 1];
            }
        }

        // Count a trailing line that is not newline-terminated.
        if (any && last != (byte)10) { lines++; }
        return lines;
    }

    public static long CountDirectory(string root)
    {
        long total = 0;
        // Allocated once per directory scan (so once per parallel worker) rather than once per
        // file, which would otherwise churn one allocation for every .cs file in the repo.
        byte[] buffer = new byte[BufferSize];
        try
        {
            foreach (string file in Directory.EnumerateFiles(root, "*.cs", SearchOption.AllDirectories))
            {
                try { total += CountFile(file, buffer); }
                catch { /* unreadable file, ignore */ }
            }
        }
        catch { /* unreadable directory, ignore */ }

        return total;
    }

    // names and roots are parallel arrays; roots[i] may be null for packages with no src directory.
    public static ConcurrentDictionary<string, long> CountAll(string[] names, string[] roots)
    {
        var results = new ConcurrentDictionary<string, long>();
        Parallel.For(0, names.Length, i =>
        {
            results[names[i]] = string.IsNullOrEmpty(roots[i]) ? 0 : CountDirectory(roots[i]);
        });
        return results;
    }
}
"@

$names = [System.Collections.Generic.List[string]]::new()
$roots = [System.Collections.Generic.List[string]]::new()

$packageFiles = Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse

foreach ($file in $packageFiles) {
  $json = Get-Content $file.FullName -Raw | ConvertFrom-Json
  $name = $json.ArtifactName
  $dirPath = $json.DirectoryPath

  $srcPath = $null
  if ($dirPath) {
    if ([System.IO.Path]::IsPathRooted($dirPath)) {
      $candidate = Join-Path $dirPath "src"
    }
    else {
      $candidate = Join-Path $RepoRoot $dirPath "src"
    }
    if (Test-Path $candidate) {
      $srcPath = $candidate
    }
  }

  $names.Add($name)
  $roots.Add($srcPath)
}

$counted = [AzSdkLocCounter]::CountAll($names.ToArray(), $roots.ToArray())

$weights = @{}
foreach ($name in $names) {
  $weights[$name] = [int][math]::Max([long]$counted[$name], 1)
}

Write-Host "Counted LOC for $($weights.Count) packages."
$topPkgs = $weights.GetEnumerator() | Sort-Object Value -Descending | Select-Object -First 5
foreach ($p in $topPkgs) {
  Write-Host "  $($p.Key): $($p.Value) LOC"
}

$weights | ConvertTo-Json -Depth 1 | Set-Content $OutputFile -Encoding utf8
Write-Host "LOC weights written to $OutputFile"

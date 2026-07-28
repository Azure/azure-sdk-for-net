<#
.SYNOPSIS
Calculates repository-derived test weights for SDK packages.

.DESCRIPTION
Produces a JSON object mapping package ArtifactName to a relative test cost. The estimate uses
only files already present in the repository:

  source LOC + (test LOC * 3) + (test markers * 250) + (test projects * 20000) + 5000

The values are intentionally relative rather than seconds. They are consumed by weighted
batching while the package-count-based bucket count remains unchanged.
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public sealed class AzSdkTestWeightMetrics
{
    public long SourceLines;
    public long TestLines;
    public int TestMarkers;
    public int TestProjects;

    public long Weight
    {
        get { return SourceLines + (TestLines * 3) + ((long)TestMarkers * 250) + ((long)TestProjects * 20000) + 5000; }
    }
}

public static class AzSdkTestWeightCounter
{
    private const int BufferSize = 64 * 1024;
    private static readonly Regex TestMarker = new Regex(
        @"^\s*\[(?:Test|TestCase|TestCaseSource|Theory|Fact|InlineData|MemberData|ClassData|TestMethod|DataTestMethod|DataRow)(?:Attribute)?(?:\s*[\(\],])",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static long CountFileLines(string path, byte[] buffer)
    {
        long lines = 0;
        bool any = false;
        byte last = 0;
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

        if (any && last != (byte)10) { lines++; }
        return lines;
    }

    private static long CountDirectoryLines(string root)
    {
        if (!Directory.Exists(root)) { return 0; }

        long total = 0;
        byte[] buffer = new byte[BufferSize];
        foreach (string file in Directory.EnumerateFiles(root, "*.cs", SearchOption.AllDirectories))
        {
            try { total += CountFileLines(file, buffer); }
            catch { /* unreadable file, ignore */ }
        }
        return total;
    }

    private static int CountTestMarkers(string root)
    {
        if (!Directory.Exists(root)) { return 0; }

        int total = 0;
        foreach (string file in Directory.EnumerateFiles(root, "*.cs", SearchOption.AllDirectories))
        {
            try
            {
                foreach (string line in File.ReadLines(file))
                {
                    if (TestMarker.IsMatch(line)) { total++; }
                }
            }
            catch { /* unreadable file, ignore */ }
        }
        return total;
    }

    private static int CountTestProjects(string root)
    {
        if (!Directory.Exists(root)) { return 0; }
        try
        {
            int count = 0;
            foreach (string ignored in Directory.EnumerateFiles(root, "*.csproj", SearchOption.AllDirectories)) { count++; }
            return count;
        }
        catch { return 0; }
    }

    private static AzSdkTestWeightMetrics CountPackage(string packageRoot)
    {
        string sourceRoot = Path.Combine(packageRoot, "src");
        string testRoot = Path.Combine(packageRoot, "tests");
        return new AzSdkTestWeightMetrics
        {
            SourceLines = CountDirectoryLines(sourceRoot),
            TestLines = CountDirectoryLines(testRoot),
            TestMarkers = CountTestMarkers(testRoot),
            TestProjects = CountTestProjects(testRoot)
        };
    }

    public static ConcurrentDictionary<string, AzSdkTestWeightMetrics> CountAll(string[] names, string[] roots)
    {
        var results = new ConcurrentDictionary<string, AzSdkTestWeightMetrics>();
        Parallel.For(0, names.Length, i =>
        {
            results[names[i]] = string.IsNullOrEmpty(roots[i])
                ? new AzSdkTestWeightMetrics()
                : CountPackage(roots[i]);
        });
        return results;
    }
}
"@

$names = [System.Collections.Generic.List[string]]::new()
$roots = [System.Collections.Generic.List[string]]::new()

Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse | ForEach-Object {
  $json = Get-Content $_.FullName -Raw | ConvertFrom-Json
  $names.Add($json.ArtifactName)

  if (!$json.DirectoryPath) {
    $roots.Add($null)
  }
  elseif ([System.IO.Path]::IsPathRooted($json.DirectoryPath)) {
    $roots.Add($json.DirectoryPath)
  }
  else {
    $roots.Add((Join-Path $RepoRoot $json.DirectoryPath))
  }
}

$metrics = [AzSdkTestWeightCounter]::CountAll($names.ToArray(), $roots.ToArray())
$weights = [ordered]@{}

foreach ($name in ($metrics.Keys | Sort-Object)) {
  $value = $metrics[$name]
  $weights[$name] = $value.Weight
  Write-Host "$name`: weight=$($value.Weight), src=$($value.SourceLines), tests=$($value.TestLines), markers=$($value.TestMarkers), projects=$($value.TestProjects)"
}

$outputDirectory = Split-Path $OutputFile -Parent
if ($outputDirectory) {
  New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
}

$weights | ConvertTo-Json | Set-Content $OutputFile

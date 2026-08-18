[CmdLetBinding()]
param (
  [Parameter()]
  [string]$OutputDirectory,

  [Parameter()]
  [string]$OutputVariableName,

  # Both counts are used as divisors when splitting the items, so reject zero and
  # negative values here rather than failing later with a divide-by-zero.
  [Parameter()]
  [ValidateRange(1, [int]::MaxValue)]
  [int]$JobCount = 8,

  # The minimum number of items per job. If the number of items is less than this, then the number of jobs will be reduced.
  [Parameter()]
  [ValidateRange(1, [int]::MaxValue)]
  [int]$MinimumPerJob = 10,

  [Parameter()]
  [string]$OnlyTypeSpec,

  # Optional comma-separated filter patterns applied to package directory names
  # (e.g., 'Azure.ResourceManager*,Azure.Provisioning*')
  [Parameter()]
  [string]$DirectoryFilterPattern,

  # Balance jobs by existing C# LOC plus a fixed per-package cost instead of by
  # package count. The generated source is a strong proxy for regeneration time.
  [Parameter()]
  [string]$UseLocWeighting,

  [Parameter()]
  [ValidateRange(0, [int]::MaxValue)]
  [int]$LocBaseCost = 30000
)

. (Join-Path $PSScriptRoot common.ps1)

[bool]$OnlyTypespec = $OnlyTypespec -in @("true", "t", "1", "yes", "y")
[bool]$UseLocWeighting = $UseLocWeighting -in @("true", "t", "1", "yes", "y")

if ($UseLocWeighting) {
  Add-Type -TypeDefinition @"
using System;
using System.IO;
using System.Threading.Tasks;

public static class RegenerationLocCounter
{
    private const int BufferSize = 64 * 1024;

    private static long CountDirectory(string root)
    {
        if (!Directory.Exists(root))
        {
            return 1;
        }

        long total = 0;
        byte[] buffer = new byte[BufferSize];
        foreach (string file in Directory.EnumerateFiles(root, "*.cs", SearchOption.AllDirectories))
        {
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1, FileOptions.SequentialScan))
            {
                int read;
                bool any = false;
                byte last = 0;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    any = true;
                    for (int i = 0; i < read; i++)
                    {
                        if (buffer[i] == (byte)10)
                        {
                            total++;
                        }
                    }
                    last = buffer[read - 1];
                }
                if (any && last != (byte)10)
                {
                    total++;
                }
            }
        }
        return Math.Max(total, 1);
    }

    public static long[] CountAll(string[] roots)
    {
        var results = new long[roots.Length];
        Parallel.For(0, roots.Length, i => results[i] = CountDirectory(roots[i]));
        return results;
    }
}
"@
}

# Divide the items into groups of approximately equal size.
function Split-Items([array]$Items) {
  # given $Items.Length = 22 and $JobCount = 5
  # then $itemsPerGroup = 4
  # and $largeJobCount = 2
  # and $group.Length = 5, 5, 4, 4, 4
  $itemCount = $Items.Length
  $jobsForMinimum = $itemCount -lt $MinimumPerJob ? 1 : [math]::Floor($itemCount / $MinimumPerJob)

  if ($JobCount -gt $jobsForMinimum) {
    $JobCount = $jobsForMinimum
  }
  
  $itemsPerGroup = [math]::Floor($itemCount / $JobCount)
  # The remainder has to be taken over the number of groups, not the size of a group.
  # Taking it over $itemsPerGroup produces too few large groups whenever
  # $itemCount % $itemsPerGroup -lt $itemCount % $JobCount, and the trailing items are
  # then silently dropped from the matrix.
  $largeJobCount = $itemCount % $JobCount
  $groups = [object[]]::new($JobCount)

  $i = 0
  for ($g = 0; $g -lt $JobCount; $g++) {
    $groupLength = if ($g -lt $largeJobCount) { $itemsPerGroup + 1 } else { $itemsPerGroup }
    $group = [object[]]::new($groupLength)
    $groups[$g] = $group
    for ($gi = 0; $gi -lt $groupLength; $gi++) {
      $group[$gi] = $Items[$i++]
    }
  }

  Write-Host "$itemCount items split into $JobCount groups of approximately $itemsPerGroup items each."

  return , $groups
}

function Split-ItemsByWeight([array]$Items) {
  $itemCount = $Items.Length
  $jobsForMinimum = $itemCount -lt $MinimumPerJob ? 1 : [math]::Floor($itemCount / $MinimumPerJob)
  $effectiveJobCount = [math]::Min($JobCount, $jobsForMinimum)

  $sourceRoots = [string[]]@($Items | ForEach-Object {
    Join-Path $RepoRoot "sdk/$($_.PackageDirectory)/src"
  })
  $locCounts = [RegenerationLocCounter]::CountAll($sourceRoots)

  $weightedItems = for ($i = 0; $i -lt $Items.Length; $i++) {
    [PSCustomObject]@{
      Item = $Items[$i]
      Loc = $locCounts[$i]
      Weight = $locCounts[$i] + $LocBaseCost
    }
  }
  $weightedItems = @($weightedItems | Sort-Object -Property Weight -Descending)

  $buckets = @(
    for ($i = 0; $i -lt $effectiveJobCount; $i++) {
      [PSCustomObject]@{
        Items = [System.Collections.ArrayList]::new()
        TotalLoc = [long]0
        TotalWeight = [long]0
      }
    }
  )

  foreach ($weightedItem in $weightedItems) {
    $bucket = $buckets | Sort-Object -Property TotalWeight | Select-Object -First 1
    [void]$bucket.Items.Add($weightedItem.Item)
    $bucket.TotalLoc += $weightedItem.Loc
    $bucket.TotalWeight += $weightedItem.Weight
  }

  for ($i = 0; $i -lt $buckets.Count; $i++) {
    $bucket = $buckets[$i]
    $bucket.Items = [System.Collections.ArrayList]@($bucket.Items | Sort-Object -Property PackageDirectory)
    Write-Host "Weighted group $i`: $($bucket.Items.Count) packages, $($bucket.TotalLoc) LOC, weight $($bucket.TotalWeight)"
  }
  Write-Host "$itemCount items split into $effectiveJobCount LOC-weighted groups with base cost $LocBaseCost per package."

  $groups = [object[]]::new($buckets.Count)
  for ($i = 0; $i -lt $buckets.Count; $i++) {
    $groups[$i] = [object[]]$buckets[$i].Items
  }
  return , $groups
}

# ensure the output directory exists
New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

if (Test-Path "Function:$GetDirectoriesForGenerationFn") {
  $directoriesForGeneration = &$GetDirectoriesForGenerationFn -OnlyTypeSpec $OnlyTypespec
}
else {
  $directoriesForGeneration = Get-ChildItem "$RepoRoot/sdk" -Directory | Get-ChildItem -Directory
  if ($OnlyTypespec) {
    $directoriesForGeneration = $directoriesForGeneration | Where-Object { Test-Path "$_/tsp-location.yaml" }
  }
}

if ($DirectoryFilterPattern) {
  $patterns = $DirectoryFilterPattern -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_ }
  $directoriesForGeneration = @($directoriesForGeneration | Where-Object {
    $name = $_.Name
    $patterns | Where-Object { $name -like $_ }
  })
  Write-Host "Filtered directories to pattern(s) '$DirectoryFilterPattern': $($directoriesForGeneration.Count) matches"
}
else {
  $directoriesForGeneration = @($directoriesForGeneration)
}

if ($directoriesForGeneration.Count -eq 0) {
  Write-Error "No directories found for generation after applying filters. DirectoryFilterPattern='$DirectoryFilterPattern', OnlyTypeSpec='$OnlyTypespec'."
  return
}

[array]$packageDirectories = $directoriesForGeneration
| Sort-Object -Property FullName
| ForEach-Object {
  [ordered]@{
    "PackageDirectory" = "$($_.Parent.Name)/$($_.Name)"
    "ServiceArea"   = $_.Parent.Name
  }
}

$batches = if ($UseLocWeighting) {
  Split-ItemsByWeight -Items $packageDirectories
}
else {
  Split-Items -Items $packageDirectories
}

$matrix = [ordered]@{}
for ($i = 0; $i -lt $batches.Length; $i++) {
  $batch = $batches[$i]
  $json = $batch.PackageDirectory | ConvertTo-Json -AsArray

  $firstPrefix = $batch[0].ServiceArea.Substring(0, 2)
  $lastPrefix = $batch[-1].ServiceArea.Substring(0, 2)
  
  $key = "$firstPrefix`_$lastPrefix`_$i"
  $fileName = "$key.json"
  
  Write-Host "`n`n=================================="
  Write-Host $fileName
  Write-Host "=================================="
  $json | Out-Host
  $json | Out-File "$OutputDirectory/$fileName"

  $matrix[$key] = [ordered]@{ "JobKey" = $key; "DirectoryList" = $fileName }
}

$compressed = ConvertTo-Json $matrix -Depth 100 -Compress
Write-Output "##vso[task.setVariable variable=$OutputVariableName;isOutput=true]$compressed"

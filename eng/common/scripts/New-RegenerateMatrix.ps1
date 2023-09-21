[CmdLetBinding()]
param (
  [Parameter()]
  [string]$OutputDirectory,

  [Parameter()]
  [string]$OutputVariableName,

  [Parameter()]
  [int]$JobCount = 8,

  # The minimum number of items per job. If the number of items is less than this, then the number of jobs will be reduced.
  [Parameter()]
  [int]$MinimumPerJob = 10,

  [Parameter()]
  [string]$OnlyTypespec
)

. (Join-Path $PSScriptRoot common.ps1)

[bool]$OnlyTypespec = $OnlyTypespec -in @("true", "t", "1", "yes", "y")

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
  $largeJobCount = $itemCount % $itemsPerGroup
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

# ensure the output directory exists
New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

if (Test-Path "Function:$GetDirectoriesForGenerationFn") {
  $directoriesForGeneration = &$GetDirectoriesForGenerationFn
}
else {
  $directoriesForGeneration = Get-ChildItem "$RepoRoot/sdk" -Directory | Get-ChildItem -Directory
}

if ($OnlyTypespec) {
  $directoriesForGeneration = $directoriesForGeneration | Where-Object { Test-Path "$_/tsp-location.yaml" }
}

[array]$packageDirectories = $directoriesForGeneration
| Sort-Object -Property FullName
| ForEach-Object {
  [ordered]@{
    "PackageDirectory" = "$($_.Parent.Name)/$($_.Name)"
    "ServiceArea"   = $_.Parent.Name
  }
}

$batches = Split-Items -Items $packageDirectories

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

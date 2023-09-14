[CmdLetBinding()]
param (
  [Parameter()]
  [string]$OutputDirectory,

  [Parameter()]
  [string]$OutputVariableName,

  [Parameter()]
  [int]$JobCount = 8
)

. (Join-Path $PSScriptRoot common.ps1)

# Divide the items into groups of approximately equal size.
function Split-Items([array]$Items) {
  # given $Items.Length = 22 and $JobCount = 5
  # then $itemsPerGroup = 4
  # and $largeJobCount = 2
  # and $group.Length = 5, 5, 4, 4, 4
  $itemsPerGroup = [math]::Floor($Items.Length / $JobCount)
  $largeJobCount = $Items.Length % $itemsPerGroup
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

  return , $groups
}

# ensure the output directory exists
New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

if (Test-Path "Function:$GetFoldersForGenerationFn") {
  $foldersForGeneration = &$GetFoldersForGenerationFn
} else {
  $foldersForGeneration = Get-ChildItem "$RepoRoot/sdk" -Directory | Get-ChildItem -Directory
}

[array]$packageFolders = $foldersForGeneration
| Sort-Object -Property FullName
| ForEach-Object {
  [ordered]@{
    "PackageFolder"   = "$($_.Parent.Name)/$($_.Name)"
    "ServiceArea" = $_.Parent.Name
  }
}

$batches = Split-Items -Items $packageFolders

$matrix = [ordered]@{}
for ($i = 0; $i -lt $batches.Length; $i++) {
  $batch = $batches[$i]
  $firstPrefix = $batch[0].ServiceArea.Substring(0, 2)
  $lastPrefix = $batch[-1].ServiceArea.Substring(0, 2)
  $key = "$firstPrefix`_$lastPrefix`_$i"
  $fileName = "$i.json"
  $batch.PackageFolder | ConvertTo-Json -AsArray | Out-File "$OutputDirectory/$fileName"
  $matrix[$key] = [ordered]@{ "JobKey" = $key; "FolderList" = $fileName }
}

$compressed = ConvertTo-Json $matrix -Depth 100 -Compress
Write-Output "##vso[task.setVariable variable=$OutputVariableName;isOutput=true]$compressed"

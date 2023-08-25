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

$pattern = '^.*?/(sdk/(.*?)/.*)'
Push-Location "$RepoRoot/sdk"
[array]$packageFolders = Get-ChildItem -Directory -Recurse
| ForEach-Object {
  $_.FullName.Replace("\" , "/")
}
| Where-Object { $_ -match $pattern }
| ForEach-Object {
  [ordered]@{
    "SdkFolder"   = $Matches[1]
    "ServiceArea" = $Matches[2]
  }
}
Pop-Location

$batches = Split-Items -Items $packageFolders

$matrix = [ordered]@{}
for ($i = 0; $i -lt $batches.Length; $i++) {
  $batch = $batches[$i]
  $firstPrefix = $batch[0].ServiceArea.Substring(0, 1)
  $lastPrefix = $batch[-1].ServiceArea.Substring(0, 1)
  $key = "Batch_$i`_$firstPrefix`_$lastPrefix"
  $fileName = "$i.json"
  $batch.SdkFolder | ConvertTo-Json -AsArray | Out-File "$OutputDirectory/$fileName"
  $matrix[$key] = [ordered]@{ "JobKey" = $key; "FolderList" = $fileName }
}

$compressed = ConvertTo-Json $matrix -Depth 100 -Compress
Write-Output "##vso[task.setVariable variable=$OutputVariableName;isOutput=true]$compressed"

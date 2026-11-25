# Set the output matrix for the Windows CI test job after removing equivalent
# non-coverage entries. The input is the JSON produced by the matrix generator.
param([Parameter(Mandatory = $true)][string] $MatrixJson)

$ErrorActionPreference = 'Stop'
$matrix = ConvertFrom-Json -InputObject $MatrixJson -AsHashtable
$entries = @($matrix.GetEnumerator() | ForEach-Object {
  @{ name = $_.Key; parameters = $_.Value }
})
$filtered = @(& "$PSScriptRoot/Remove-DuplicateCoverageJobs.ps1" -Matrix $entries)
$result = [ordered]@{}
foreach ($entry in $filtered) {
  $result[$entry.name] = $entry.parameters
}
$json = ConvertTo-Json -InputObject $result -Depth 100 -Compress
Write-Host "##vso[task.setvariable variable=matrix;isOutput=true]$json"

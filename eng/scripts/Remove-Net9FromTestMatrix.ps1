[CmdletBinding()]
param ([Parameter(Mandatory = $true)][string] $MatrixPath)

$ErrorActionPreference = 'Stop'
$matrix = Get-Content $MatrixPath -Raw | ConvertFrom-Json -AsHashtable
if ($matrix.matrix.Agent -isnot [System.Collections.IDictionary]) {
  throw "Cannot remove net9 agents from matrix '$MatrixPath'."
}
foreach ($name in @($matrix.matrix.Agent.Keys)) {
  if ($matrix.matrix.Agent[$name].TestTargetFramework -eq 'net9.0') {
    $matrix.matrix.Agent.Remove($name)
  }
}
if ($matrix.include) {
  $matrix.include = @($matrix.include | Where-Object {
    $agents = $_.Agent
    -not $agents -or -not @($agents.Values | Where-Object { $_.TestTargetFramework -eq 'net9.0' }).Count
  })
}
$matrix | ConvertTo-Json -Depth 100 | Set-Content $MatrixPath

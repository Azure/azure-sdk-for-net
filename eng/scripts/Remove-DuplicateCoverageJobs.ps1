# Remove the ordinary Windows .NET 10 PackageRef job only when the coverage job
# runs the same projects with the same effective configuration and parameters.
param([Parameter(Mandatory = $true)][AllowEmptyCollection()][array] $Matrix)

function Get-ComparableParameters($entry) {
  $parameters = @{}
  foreach ($key in $entry.parameters.Keys) {
    if ($key -notin @('CollectCoverage', 'SupportsRecording')) {
      $parameters[$key] = $entry.parameters[$key]
    }
  }
  if (!$parameters.ContainsKey('BuildConfiguration')) {
    $parameters['BuildConfiguration'] = $env:BUILDCONFIGURATION
  }
  return $parameters
}

# Serialization retains only the first entry for a duplicate job name. Only that
# entry can provide coverage for a removed job.
$seenNames = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
$coverageJobs = @(foreach ($entry in $Matrix) {
  if ($seenNames.Add([string]$entry.name) -and
      $entry.name -match '^Windows2022_NET100_Coverage_Record_PackageRef($|_)' -and
      [string]$entry.parameters['CollectCoverage'] -ieq 'true') {
    $entry
  }
})

foreach ($entry in $Matrix) {
  $duplicate = $false
  if ($entry.name -match '^Windows2022_NET100_PackageRef_(Debug|Release)($|_)' -and
      [string]$entry.parameters['CollectCoverage'] -ine 'true') {
    $parameters = Get-ComparableParameters $entry
    if (![string]::IsNullOrWhiteSpace([string]$parameters['BuildConfiguration'])) {
      foreach ($coverage in $coverageJobs) {
        $other = Get-ComparableParameters $coverage
        if ($parameters.Count -ne $other.Count) { continue }
        $equal = $true
        foreach ($key in $parameters.Keys) {
          if (!$other.ContainsKey($key) -or
              (ConvertTo-Json -InputObject $parameters[$key] -Compress -Depth 100) -cne (ConvertTo-Json -InputObject $other[$key] -Compress -Depth 100)) {
            $equal = $false
            break
          }
        }
        if ($equal) {
          $duplicate = $true
          break
        }
      }
    }
  }
  if (!$duplicate) { $entry }
}

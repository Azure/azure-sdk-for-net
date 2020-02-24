param (
  [Parameter(Mandatory = $true)]
  [String]$ChangeLogLocation,
  [String]$VersionString,
  [String]$ReleaseNotesPropsPath
)

$ErrorActionPreference = 'Stop'

try {
  $releaseNotesForVersion = &"${PSScriptRoot}/common/Extract-ReleaseNotes.ps1" -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString
  Set-Content -Path $ReleaseNotesPropsPath -Value $releaseNotesForVersion
}
catch {
  Write-Host "Entered Catch Block"
  exit 94
}

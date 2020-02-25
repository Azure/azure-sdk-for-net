param (
  [Parameter(Mandatory = $true)]
  [String]$ChangeLogLocation,
  [String]$VersionString,
  [String]$ReleaseNotesPropsPath
)

$ErrorActionPreference = 'Stop'

try {
  $ReleaseNotesForVersion = . ${PSScriptRoot}/common/Extract-ReleaseNotes.ps1 -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString # Dot Sourced to get $RELEASE_TITLE_REGEX into scope
  $ReleaseNotesArray = $ReleaseNotesForVersion.Split([Environment]::NewLine)
  $ProcessedNotes = New-Object System.Collections.ArrayList
  foreach ($line in $ReleaseNotesArray)
  {
    $lineIsTitle = $line.Startswith('#') -And ($line -match $RELEASE_TITLE_REGEX)
    if (-Not $lineIsTitle)
    {
      $ProcessedNotes.Add($line.Trim('#')) > $null
    }
  }
  Set-Content -Path $ReleaseNotesPropsPath -Value ($ProcessedNotes -Join "`r")
}
catch {
  Write-Host "Entered Catch Block"
  exit 94
}

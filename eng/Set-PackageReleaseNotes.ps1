param (
  [Parameter(Mandatory = $true)]
  [String]$ChangeLogLocation
)

$ReleaseNotesTable = &"${PSScriptRoot}/common/Extract-ReleaseNotes.ps1" -ChangeLogLocation $ChangeLogLocation
$LatestReleaseNoteEntry= $ReleaseNotesTable.GetEnumerator() | Select -First 1
$LatestReleaseNote = $LatestReleaseNoteEntry.Value.ReleaseContent
$ActualReleaseNotes = $LatestReleaseNote.Substring($LatestReleaseNote.IndexOf('`n') + 1)
Write-Host $ActualReleaseNotes




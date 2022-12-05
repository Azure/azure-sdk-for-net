# cSpell:ignore Committish
# cSpell:ignore PULLREQUEST
# cSpell:ignore TARGETBRANCH
param (
  # The root repo we scanned with.
  [string] $RootRepo = '$PSScriptRoot/../../..',
  # The target branch to compare with.
  [string] $targetBranch = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "/refs/heads/")
)

. (Join-Path $PSScriptRoot common.ps1)

return Get-ChangedFiles -TargetCommittish $targetBranch -DiffPath '*.md'
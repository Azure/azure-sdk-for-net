# cSpell:ignore Committish
# cSpell:ignore committish
# cSpell:ignore PULLREQUEST
# cSpell:ignore TARGETBRANCH
# cSpell:ignore SOURCECOMMITID
# cSpell:ignore elete
# cSpell:ignore ename
<#
  .SYNOPSIS
  Returns git diff changes in pull request.
  .DESCRIPTION
  The script is to return diff changes in pull request.
  .PARAMETER SourceCommittish
  The branch committish PR merges from.
  Definition of committish: https://git-scm.com/docs/gitglossary#Documentation/gitglossary.txt-aiddefcommit-ishacommit-ishalsocommittish
  .PARAMETER TargetCommittish
  The branch committish PR targets to merge into.
  .PARAMETER DiffPath
  The files which git diff to scan against. Support regex match. E.g. "eng/common/*", "*.md"
  .PARAMETER DiffFilterType
  The filter type A(a)dd, D(d)elete, R(r)ename, U(u)pate. 
  E.g. 'ad' means filter out the newly added file and deleted file 
  E.g. '' means no filter on file mode.
#>
[CmdletBinding()]
param (
  [string] $SourceCommittish = "${env:SYSTEM_PULLREQUEST_SOURCECOMMITID}",
  [string] $TargetCommittish = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/"),
  [string] $DiffPath = "",
  [string] $DiffFilterType = 'd'
)

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)

return Get-ChangedFiles -SourceCommittish $SourceCommittish `
-TargetCommittish $TargetCommittish `
-DiffPath $DiffPath `
-DiffFilterType $DiffFilterType
# cSpell:ignore LASTEXITCODE
# cSpell:ignore errrrrorrrrr
# cSpell:ignore sepleing
<#
.SYNOPSIS
Uses cspell (from NPM) to check spelling of recently changed files

.DESCRIPTION
This script checks files that have changed relative to a base branch (default
branch) for spelling errors. Dictionaries and spelling configurations reside
in a configurable `cspell.json` location.

This script uses `npx` and assumes that NodeJS (and by extension `npm` and
`npx`) are installed on the machine. If it does not detect `npx` it will warn
the user and exit with an error.

The entire file is scanned, not just changed sections. Spelling errors in parts
of the file not touched will still be shown.

This script copies the config file supplied in CspellConfigPath to a temporary
location, mutates the config file to include only the files that have changed,
and then uses the mutated config file to call cspell. In the case of success
the temporary file is deleted. In the case of failure the temporary file, whose
location was logged to the console, remains on disk.

.PARAMETER SpellCheckRoot
Root folder from which to generate relative paths for spell checking. Mostly
used in testing.

.PARAMETER CspellConfigPath
Optional location to use for cspell.json path. Default value is 
`./.vscode/cspell.json`

.PARAMETER ExitWithError
Exit with error code 1 if spelling errors are detected.

.PARAMETER SourceCommittish
Commit SHA (or ref) used for file list generation. This is the later commit. The
default value is useful for Azure DevOps pipelines. The default value is
`${env:SYSTEM_PULLREQUEST_SOURCECOMMITID}`

.PARAMETER TargetCommittish
Commit SHA (or ref) used for file list generation. This is the "base" commit.
The default value is useful for Azure DevOps pipelines. The default value is
`origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}` with some string manipulation to
remove the `refs/heads/` prefix.

.EXAMPLE
./eng/common/scripts/check-spelling-in-changed-files.ps1 

This will run spell check with changes in the current branch with respect to 
`target_branch_name`

#>

[CmdletBinding()]
Param (
    [Parameter()]
    [string] $CspellConfigPath = (Resolve-Path "$PSScriptRoot/../../../.vscode/cspell.json"),

    [Parameter()]
    [string] $SpellCheckRoot = (Resolve-Path "$PSScriptRoot/../../../"),

    [Parameter()]
    [switch] $ExitWithError,

    [Parameter()]
    [string]$SourceCommittish = "${env:SYSTEM_PULLREQUEST_SOURCECOMMITID}",

    [Parameter()]
    [string]$TargetCommittish = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/")
)

Set-StrictMode -Version 3.0

$ErrorActionPreference = "Continue"
. $PSScriptRoot/common.ps1

if ((Get-Command git | Measure-Object).Count -eq 0) {
    LogError "Could not locate git. Install git https://git-scm.com/downloads"
    exit 1
}

if (!(Test-Path $CspellConfigPath)) {
    LogError "Could not locate config file $CspellConfigPath"
    exit 1
}

# Lists names of files that were in some way changed between the
# current branch and default target branch. Excludes files that were deleted to
# prevent errors in Resolve-Path
$changedFilesList = Get-ChangedFiles `
    -SourceCommittish $SourceCommittish `
    -TargetCommittish $TargetCommittish

$changedFiles = @()
foreach ($file in $changedFilesList) {
  $changedFiles += Resolve-Path $file
}

$changedFilesCount = ($changedFiles | Measure-Object).Count
Write-Host "Git Detected $changedFilesCount changed file(s). Files checked by cspell may exclude files according to cspell.json"

if ($changedFilesCount -eq 0) {
    Write-Host "No changes detected"
    exit 0
}

$changedFilePaths = @()
foreach ($file in $changedFiles) {
    $changedFilePaths += $file.Path
}

$spellingErrors = &"$PSScriptRoot/../spelling/Invoke-Cspell.ps1" `
  -CspellConfigPath $CspellConfigPath `
  -SpellCheckRoot $SpellCheckRoot `
  -FileList $changedFilePaths

if ($spellingErrors) {
    $errorLoggingFunction = Get-Item 'Function:LogWarning'
    if ($ExitWithError) {
        $errorLoggingFunction = Get-Item 'Function:LogError'
    }

    foreach ($spellingError in $spellingErrors) {
        &$errorLoggingFunction $spellingError
    }
    &$errorLoggingFunction "Spelling errors detected. To correct false positives or learn about spell checking see: https://aka.ms/azsdk/engsys/spellcheck"

    if ($ExitWithError) {
        exit 1
    }
} else {
  Write-Host "No spelling errors detected"
}

exit 0

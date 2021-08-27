[CmdletBinding()]
Param (
    [Parameter()]
    [string] $TargetBranch,

    [Parameter()]
    [string] $SourceBranch,

    [Parameter()]
    [string] $CspellConfigPath = "./.vscode/cspell.json",

    [Parameter()]
    [switch] $ExitWithError
)

$ErrorActionPreference = "Continue"
. $PSScriptRoot/logging.ps1

if ((Get-Command git | Measure-Object).Count -eq 0) { 
    LogError "Could not locate git. Install git https://git-scm.com/downloads"
    exit 1
}

if ((Get-Command npx | Measure-Object).Count -eq 0) { 
    LogError "Could not locate npx. Install NodeJS (includes npx and npx) https://nodejs.org/en/download/"
    exit 1
}

if (!(Test-Path $CspellConfigPath)) {
    LogError "Could not locate config file $CspellConfigPath"
    exit 1
}

# Lists names of files that were in some way changed between the 
# current $SourceBranch and $TargetBranch. Excludes files that were deleted to
# prevent errors in Resolve-Path
Write-Host "git diff --diff-filter=d --name-only $TargetBranch $SourceBranch"
$changedFiles = git diff --diff-filter=d --name-only $TargetBranch $SourceBranch `
    | Resolve-Path

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

# Using GetTempPath because it works on linux and windows. Setting .json
# extension because cspell requires the file have a .json or .jsonc extension
$cspellConfigTemporaryPath = Join-Path `
    ([System.IO.Path]::GetTempPath()) `
    "$([System.IO.Path]::GetRandomFileName()).json"

$cspellConfigContent = Get-Content $CspellConfigPath -Raw
$cspellConfig = ConvertFrom-Json $cspellConfigContent

# If the config has no "files" property this adds it. If the config has a
# "files" property this sets the value, overwriting the existing value. In this
# case, spell checking is only intended to check files from $changedFiles so
# preexisting entries in "files" will be overwritten.
Add-Member `
    -MemberType NoteProperty `
    -InputObject $cspellConfig `
    -Name "files" `
    -Value $changedFilePaths `
    -Force

# Set the temporary config file with the mutated configuration. The temporary
# location is used to configure the command and the original file remains
# unchanged.
Write-Host "Setting config in: $cspellConfigTemporaryPath"
Set-Content `
    -Path $cspellConfigTemporaryPath `
    -Value (ConvertTo-Json $cspellConfig -Depth 100)

# IGNORE_FILE_ -- In some cases a PR contains changes to only files which are
# excluded. In these cases `cspell` will produce an error when the files listed
# in the "files" config are excluded. Specifying a file name on the command line
# (even one which does not exist) will prevent this error.

# Use the mutated configuration file when calling cspell
Write-Host "npx cspell lint --config $cspellConfigTemporaryPath --no-must-find-files IGNORE_FILE_"
$spellingErrors = npx cspell lint --config $cspellConfigTemporaryPath --no-must-find-files IGNORE_FILE_

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
    Write-Host "No spelling errors detected. Removing temporary config file."
    Remove-Item -Path $cspellConfigTemporaryPath -Force
}

exit 0

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

.PARAMETER TargetBranch
Git ref to compare changes. This is usually the "base" (GitHub) or "target" 
(DevOps) branch for which a pull request would be opened.

.PARAMETER SourceBranch
Git ref to use instead of changes in current repo state. Use `HEAD` here to 
check spelling of files that have been committed and exclude any new files or
modified files that are not committed. This is most useful in CI scenarios where
builds may have modified the state of the repo. Leaving this parameter blank  
includes files for whom changes have not been committed. 

.PARAMETER CspellConfigPath
Optional location to use for cspell.json path. Default value is 
`./.vscode/cspell.json`

.PARAMETER ExitWithError
Exit with error code 1 if spelling errors are detected.

.EXAMPLE
./eng/common/scripts/check-spelling-in-changed-files.ps1 -TargetBranch 'target_branch_name'

This will run spell check with changes in the current branch with respect to 
`target_branch_name`

#>

[CmdletBinding()]
Param (
    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $TargetRef = 'master', 

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $CspellConfigPath = "./.vscode/cspell.json"
)

. $PSScriptRoot/logging.ps1

if ((Get-Command git | Measure-Object).Count -eq 0) { 
    LogError "Could not locate git. Install git https://git-scm.com/downloads"
    exit 1
}

if ((Get-Command npx | Measure-Object).Count -eq 0) { 
    LogError "Could not locate npx. Install NodeJS (includes npm and npx) https://nodejs.org/en/download/"
    exit 1
}

$initialDirectory = Get-Location
$exitCode = 0
try { 
    Set-Location "$PSScriptRoot/../../.."

    # Lists names of files that were in some way changed between the 
    # current ref and $TargetRef. Excludes files that were deleted to
    # prevent errors in Resolve-Path
    Write-Host "git diff --diff-filter=d --name-only $TargetRef"
    $changedFiles = git diff --diff-filter=d --name-only $TargetRef `
        | Resolve-Path
    
    $changedFilesCount = ($changedFiles | Measure-Object).Count
    Write-Host "Git Detected $changedFilesCount changed file(s). Files checked by cspell may exclude files according to cspell.json"

    if ($changedFilesCount -eq 0) {
        Write-Host "No changes detected"
        # The finally block still runs after calling exit here
        exit $exitCode
    }

    $changedFilesString = $changedFiles | Join-String -Separator ' '

    Write-Host "npx cspell --config $CspellConfigPath $changedFilesString"
    $spellingErrors = Invoke-Expression "npx cspell --config $CspellConfigPath $changedFilesString"

    if ($spellingErrors) {
        $exitCode = 1
        foreach ($spellingError in $spellingErrors) { 
            LogWarning $spellingError
        }    
    }
} finally {
    Set-Location $initialDirectory
}

exit $exitCode

<#
.SYNOPSIS
Uses cspell (from NPM) to check spelling of recently changed files

.DESCRIPTION
This script checks files that have changed relative to a base branch (default 
`master`) for spelling errors. Dictionaries and spelling configurations reside 
in a configurable `cspell.json` location.

This script uses `npx` and assumes that NodeJS (and by extension `npm` and `npx`
) are installed on the machine. If it does not detect `npx` it will warn the 
user and exit with an error. 

The entire file is scanned, not just changed sections. Spelling errors in parts 
of the file not touched will still be shown.

Running this on the local machine will trigger tests 

.PARAMETER TargetRef
Optional git ref to compare changes. Default value is `master`.

.PARAMETER CspellConfigPath
Optional location to use for cspell.json path. Default value is 
`./.vscode/cspell.json`

#>

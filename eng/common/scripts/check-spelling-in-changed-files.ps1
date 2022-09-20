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

.PARAMETER Test
Run test functions against the script logic

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
    [switch] $Test
)

Set-StrictMode -Version 3.0

function TestSpellChecker() {
    Test-Exit0WhenAllFilesExcluded
    ResetTest
    Test-Exit1WhenIncludedFileHasSpellingError
    ResetTest
    Test-Exit0WhenIncludedFileHasNoSpellingError
    ResetTest
    Test-Exit1WhenChangedFileAlreadyHasSpellingError
    ResetTest
    Test-Exit0WhenUnalteredFileHasSpellingError
    ResetTest
    Test-Exit0WhenSpellingErrorsAndNoExitWithError
}

function Test-Exit0WhenAllFilesExcluded() {
    # Arrange
    "sepleing errrrrorrrrr" > ./excluded/excluded-file.txt
    git add -A
    git commit -m "One change"

    # Act
    &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
        -CspellConfigPath "./.vscode/cspell.json" `
        -SpellCheckRoot "./" `
        -ExitWithError

    # Assert
    if ($LASTEXITCODE -ne 0) {
        throw "`$LASTEXITCODE != 0"
    }
}

function Test-Exit1WhenIncludedFileHasSpellingError() {
    # Arrange
    "sepleing errrrrorrrrr" > ./included/included-file.txt
    git add -A
    git commit -m "One change"

    # Act
    &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
        -CspellConfigPath "./.vscode/cspell.json" `
        -SpellCheckRoot "./" `
        -ExitWithError

    # Assert
    if ($LASTEXITCODE -ne 1) {
        throw "`$LASTEXITCODE != 1"
    }
}

function Test-Exit0WhenIncludedFileHasNoSpellingError() {
    # Arrange
    "correct spelling" > ./included/included-file.txt
    git add -A
    git commit -m "One change"

    # Act
    &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
        -CspellConfigPath "./.vscode/cspell.json" `
        -SpellCheckRoot "./" `
        -ExitWithError

    # Assert
    if ($LASTEXITCODE -ne 0) {
        throw "`$LASTEXITCODE != 0"
    }
}

function Test-Exit1WhenChangedFileAlreadyHasSpellingError() {
    # Arrange
    "sepleing errrrrorrrrr" > ./included/included-file.txt
    git add -A
    git commit -m "First change"

    "A statement without spelling errors" >> ./included/included-file.txt
    git add -A
    git commit -m "Second change"

    # Act
    &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
        -CspellConfigPath "./.vscode/cspell.json" `
        -SpellCheckRoot "./" `
        -ExitWithError

    # Assert
    if ($LASTEXITCODE -ne 1) {
        throw "`$LASTEXITCODE != 1"
    }
}

function Test-Exit0WhenUnalteredFileHasSpellingError() {
    # Arrange
    "sepleing errrrrorrrrr" > ./included/included-file-1.txt
    git add -A
    git commit -m "One change"

    "A statement without spelling errors" > ./included/included-file-2.txt
    git add -A
    git commit -m "Second change"

    # Act
    &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
        -CspellConfigPath "./.vscode/cspell.json" `
        -SpellCheckRoot "./" `
        -ExitWithError

    # Assert
    if ($LASTEXITCODE -ne 0) {
        throw "`$LASTEXITCODE != 0"
    }
}

function Test-Exit0WhenSpellingErrorsAndNoExitWithError() {
    # Arrange
    "sepleing errrrrorrrrr" > ./included/included-file-1.txt
    git add -A
    git commit -m "One change"

    # Act
    &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
        -CspellConfigPath "./.vscode/cspell.json" `
        -SpellCheckRoot "./"

    # Assert
    if ($LASTEXITCODE -ne 0) {
        throw "`$LASTEXITCODE != 0"
    }
}

function SetupTest($workingDirectory) {
    Write-Host "Create test temp dir: $workingDirectory"
    New-Item -ItemType Directory -Force -Path $workingDirectory | Out-Null

    Push-Location $workingDirectory | Out-Null
    git init

    New-Item -ItemType Directory -Force -Path "./excluded"
    New-Item -ItemType Directory -Force -Path "./included"
    New-Item -ItemType Directory -Force -Path "./.vscode"

    "Placeholder" > "./excluded/placeholder.txt"
    "Placeholder" > "./included/placeholder.txt"

    $configJsonContent = @"
{
    "version": "0.1",
    "language": "en",
    "ignorePaths": [
        ".vscode/cspell.json",
        "excluded/**"
    ]
}
"@
    $configJsonContent > "./.vscode/cspell.json"

    git add -A
    git commit -m "Init"
}

function ResetTest() {
    # Empty out the working tree
    git checkout .
    git clean -xdf

    $revCount = git rev-list --count HEAD
    if ($revCount -gt 1) {
        # Reset N-1 changes so there is only the initial commit
        $revisionsToReset = $revCount - 1
        git reset --hard HEAD~$revisionsToReset
    }
}

function TeardownTest($workingDirectory) {
    Pop-Location | Out-Null
    Write-Host "Remove  test temp dir: $workingDirectory"
    Remove-Item -Path $workingDirectory -Recurse -Force | Out-Null
}

if ($Test) {
    $workingDirectory = Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName())

    SetupTest $workingDirectory
    TestSpellChecker
    TeardownTest $workingDirectory
    Write-Host "Test complete"
    exit 0
}

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
$changedFilesList = Get-ChangedFiles

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
  -ScanGlobs $changedFilePaths

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

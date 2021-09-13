
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

.PARAMETER Test
Run test functions against the script logic

.EXAMPLE
./eng/common/scripts/check-spelling-in-changed-files.ps1 -TargetBranch 'target_branch_name'

This will run spell check with changes in the current branch with respect to 
`target_branch_name`

#>

[CmdletBinding()]
Param (
    [Parameter()]
    [string] $TargetBranch,

    [Parameter()]
    [string] $SourceBranch,

    [Parameter()]
    [string] $CspellConfigPath = "./.vscode/cspell.json",

    [Parameter()]
    [switch] $ExitWithError,

    [Parameter()]
    [switch] $Test
)
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
        -TargetBranch HEAD~1 `
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
        -TargetBranch HEAD~1 `
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
        -TargetBranch HEAD~1 `
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
        -TargetBranch HEAD~1 `
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
        -TargetBranch HEAD~1 `
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
        -TargetBranch HEAD~1 `

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

# The "files" list must always contain a file which exists, is not empty, and is
# not excluded in ignorePaths. In this case it will be a file with the contents
# "1" (no spelling errors will be detected)
$notExcludedFile = (New-TemporaryFile).ToString()
"1" >> $notExcludedFile
$changedFilePaths += $notExcludedFile

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
Write-Host "Setting config in: $CspellConfigPath"
Set-Content `
    -Path $CspellConfigPath `
    -Value (ConvertTo-Json $cspellConfig -Depth 100)

# Use the mutated configuration file when calling cspell
Write-Host "npx cspell lint --config $CspellConfigPath --no-must-find-files "
$spellingErrors = npx cspell lint --config $CspellConfigPath --no-must-find-files

Write-Host "cspell run complete, restoring original configuration."
Set-Content -Path $CspellConfigPath -Value $cspellConfigContent -NoNewLine

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
    Write-Host "No spelling errors detected. Removing temporary file."
    Remove-Item -Path $notExcludedFile -Force | Out-Null
}

exit 0

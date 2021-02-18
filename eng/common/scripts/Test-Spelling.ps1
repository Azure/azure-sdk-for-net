[CmdletBinding()]
Param (
    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $TargetRef = 'master'
)

. $PSScriptRoot/logging.ps1


if ((Get-Command npx | Measure-Object).Count -eq 0) { 
    Write-Error "Could not locate npx. Install NodeJS (includes npm and npx) https://nodejs.org/en/download/"
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

    Write-Host "npx cspell --config ./eng/cspell.json $changedFilesString"
    $spellingErrors = Invoke-Expression "npx cspell --config ./eng/cspell.json $changedFilesString"

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
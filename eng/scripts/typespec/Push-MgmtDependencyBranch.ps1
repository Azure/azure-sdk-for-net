#Requires -Version 7.0
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $RepoRoot,
    [Parameter(Mandatory)] [string] $Branch,
    [Parameter(Mandatory)] [string] $Version,
    [Parameter(Mandatory)] [string] $GitUrl,
    [Parameter(Mandatory)] [bool] $Failed,
    [string] $AuthToken
)

$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $false
$prefix = if ($Failed) { 'Failed: ' } else { '' }
$title = "${prefix}Update management generator branded dependency to $Version"
$normalTitle = "Update management generator branded dependency to $Version"
$failedTitle = "Failed: $normalTitle"
$oldCount = $env:GIT_CONFIG_COUNT
$index = if ($oldCount) { [int]$oldCount } else { 0 }
$keyName = "GIT_CONFIG_KEY_$index"
$valueName = "GIT_CONFIG_VALUE_$index"

Push-Location $RepoRoot
try {
    if ($AuthToken) {
        $header = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes("x-access-token:$AuthToken"))
        [Environment]::SetEnvironmentVariable($keyName, 'http.https://github.com/.extraheader')
        [Environment]::SetEnvironmentVariable($valueName, "AUTHORIZATION: basic $header")
        $env:GIT_CONFIG_COUNT = [string]($index + 1)
    }

    git diff --cached --quiet --exit-code
    if ($LASTEXITCODE -eq 0) { Write-Host 'No staged update to push.'; return }
    if ($LASTEXITCODE -ne 1) { throw 'Failed to inspect staged changes.' }
    git -c user.name=azure-sdk -c user.email=azuresdk@microsoft.com commit -m $title
    if ($LASTEXITCODE -ne 0) { throw 'Failed to commit the management update.' }

    # An empty expected value makes this atomic: the push succeeds only if the
    # remote branch does not already exist, even if a normal push would fast-forward.
    $pushOutput = git push "--force-with-lease=refs/heads/${Branch}:" $GitUrl "HEAD:refs/heads/$Branch" 2>&1
    $pushResult = $LASTEXITCODE
    $pushOutput | ForEach-Object { Write-Host $_ }
    if ($pushResult -eq 0) {
        Write-Host '##vso[task.setvariable variable=HasChanges]true'
        return
    }

    # A competing attempt may have created the branch since preflight. Reuse its
    # exact commit; never reapply our changes or overwrite the remote branch.
    $remote = git ls-remote --heads $GitUrl "refs/heads/$Branch"
    if ($LASTEXITCODE -ne 0 -or -not $remote) { throw 'Failed to create the update branch.' }
    git fetch --no-tags --depth=1 $GitUrl "refs/heads/$Branch"
    if ($LASTEXITCODE -ne 0) { throw 'Failed to fetch the competing update branch.' }
    $subject = git log -1 --format=%s FETCH_HEAD
    if ($LASTEXITCODE -ne 0 -or ($subject -ne $normalTitle -and $subject -ne $failedTitle)) {
        throw 'The competing update branch has an unexpected head; refusing to overwrite it.'
    }
    git reset --hard HEAD~1
    if ($LASTEXITCODE -ne 0) { throw 'Failed to discard the local competing update.' }
    Write-Host '##vso[task.setvariable variable=HasChanges]false'
    Write-Host '##vso[task.setvariable variable=ReuseExistingDependencyPR]true'
    $remoteFailed = ($subject -eq $failedTitle).ToString().ToLowerInvariant()
    Write-Host "##vso[task.setvariable variable=MgmtDependencyFailed]$remoteFailed"
} finally {
    if ($AuthToken) {
        [Environment]::SetEnvironmentVariable($keyName, $null)
        [Environment]::SetEnvironmentVariable($valueName, $null)
        [Environment]::SetEnvironmentVariable('GIT_CONFIG_COUNT', $oldCount)
    }
    Pop-Location
}

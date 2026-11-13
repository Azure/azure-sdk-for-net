<#
.SYNOPSIS
Evaluates whether codeowners verification should be skipped and sets a pipeline
variable with the result.

.DESCRIPTION
Verification is skipped only for an allow listed person. Who that is gets
established differently depending on how the build started:
  - Pull request builds: the GitHub login of the pull request author, resolved
    from the GitHub API. 'Build.RequestedForEmail' is empty here, because the
    build is queued by the 'GitHub' app service principal rather than by a user.
  - Manually queued builds: 'Build.RequestedForEmail', and only when the
    'Skip.VerifyCodeowners' queue time variable is also 'true'. That variable
    cannot be supplied on a pull request build, so it is ignored there.

Matching on the pull request author, rather than on whoever pushed most
recently, keeps the decision a property of the pull request. Agent opened pull
requests report the agent (for example 'Copilot') as the author, so they are
never exempt.

If the author cannot be resolved, verification runs. A GitHub outage or an
exhausted rate limit never blocks a build, and never silently grants a skip.

.PARAMETER RequestedForEmail
The email of the person who requested the build (e.g. Build.RequestedForEmail).
Only populated for manually queued builds.

.PARAMETER SkipVerifyCodeowners
The 'Skip.VerifyCodeowners' pipeline variable. Ignored on pull request builds,
where queue time variables cannot be supplied.

.PARAMETER BuildReason
The 'Build.Reason' pipeline variable.

.PARAMETER Repo
The GitHub repository in '<owner>/<name>' form (e.g. Build.Repository.Name).
Used to resolve the pull request author.

.PARAMETER PullRequestNumber
The pull request number (e.g. System.PullRequest.PullRequestNumber). Used to
resolve the pull request author.

.PARAMETER AdditionalSkipEmails
Emails allowed to skip verification, in addition to the default set. Accepts a
comma-, semicolon-, or whitespace-separated list.

.PARAMETER AdditionalSkipAliases
GitHub aliases (logins) allowed to skip verification, in addition to the default
set. Accepts a comma-, semicolon-, or whitespace-separated list.

.PARAMETER OutputVariableName
The name of the pipeline variable to set with the boolean result.
#>
[CmdletBinding()]
param (
    [string] $RequestedForEmail = '',
    [string] $SkipVerifyCodeowners = $env:SKIP_VERIFYCODEOWNERS,
    [string] $BuildReason = $env:BUILD_REASON,
    [string] $Repo = $env:BUILD_REPOSITORY_NAME,
    [string] $PullRequestNumber = $env:SYSTEM_PULLREQUEST_PULLREQUESTNUMBER,
    [string] $AdditionalSkipEmails = '',
    [string] $AdditionalSkipAliases = '',
    [string] $OutputVariableName = 'ShouldSkipVerifyCodeowners'
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

# Microsoft emails allowed to skip verification. Only usable on manually queued
# builds, where Build.RequestedForEmail is populated.
$defaultSkipEmails = @(
    'bebroder@microsoft.com',
    'mharder@microsoft.com',
    'djurek@microsoft.com',
    'chononiw@microsoft.com',
    'raychen@microsoft.com'
)

# GitHub aliases (logins) allowed to skip verification. Used on pull request
# builds, where the GitHub login of the user who triggered the build is the only
# identity available. These are the same people as $defaultSkipEmails above; keep
# the two lists in sync.
$defaultSkipAliases = @(
    'benbp',
    'mikeharder',
    'danieljurek',
    'chidozieononiwu',
    'raych1'
)

function Get-NormalizedSet {
    param (
        [string[]] $Default,
        [string] $Additional
    )

    $extra = @($Additional -split '[,;\s]+' | Where-Object { $_ })

    return @($Default + $extra) |
        ForEach-Object { $_.Trim().ToLowerInvariant() } |
        Where-Object { $_ } |
        Select-Object -Unique
}

# Returns the GitHub login of the pull request author, or an empty string if it
# cannot be determined.
function Get-PullRequestAuthor {
    param (
        [string] $Repo,
        [string] $PullRequestNumber
    )

    $uri = "https://api.github.com/repos/$Repo/pulls/$PullRequestNumber"

    # The request is unauthenticated and subject to GitHub's anonymous per IP
    # rate limit. Retries are kept low, because every attempt spends budget.
    try {
        $pullRequest = Invoke-RestMethod -Uri $uri -MaximumRetryCount 3 -RetryIntervalSec 2
        $author = "$($pullRequest.user.login)"

        if ($pullRequest.user.type -eq 'Bot') {
            Write-Host "Pull request $PullRequestNumber was opened by the '$author' app rather than by a person, so it is attributed to the app and not to whoever dispatched it. Verification will run."
        }

        return $author
    } catch {
        Write-Host "Failed to resolve the author of '$uri': $_"
        return ''
    }
}

function Set-Result {
    param (
        [bool] $ShouldSkip
    )

    $value = $ShouldSkip.ToString().ToLowerInvariant()
    Write-Host "Setting $OutputVariableName to $value"
    Write-Host "##vso[task.setvariable variable=$OutputVariableName]$value"
}

$isPullRequest = $BuildReason -eq 'PullRequest'

Write-Host "Build.Reason: $BuildReason"

# Skip.VerifyCodeowners is a queue-time variable, which cannot be supplied on a
# pull request build, so it only applies outside of pull requests. There,
# skipping must be explicitly requested.
if (!$isPullRequest) {
    Write-Host "Skip.VerifyCodeowners: $SkipVerifyCodeowners"

    if ($SkipVerifyCodeowners -ne 'true') {
        Write-Host "This is not a pull request build and Skip.VerifyCodeowners is not set to 'true' (value: '$SkipVerifyCodeowners'). Verification will run."
        Set-Result -ShouldSkip $false
        return
    }
}

$allowedSkipAliases = Get-NormalizedSet -Default $defaultSkipAliases -Additional $AdditionalSkipAliases

if ($isPullRequest) {
    # Build.RequestedForEmail is empty on GitHub pull request builds, so match on
    # the PR author's GitHub login instead.
    $pullRequestAuthor = Get-PullRequestAuthor -Repo $Repo -PullRequestNumber $PullRequestNumber

    $normalizedAlias = $pullRequestAuthor.Trim().ToLowerInvariant()

    if (!$normalizedAlias) {
        Write-Host "Could not determine the pull request author. Codeowners verification will run."
        Set-Result -ShouldSkip $false
        return
    }

    Write-Host "Pull request author: $normalizedAlias"

    if ($allowedSkipAliases -notcontains $normalizedAlias) {
        Write-Host "The GitHub alias '$normalizedAlias' is not in the allowed skip list."
        Set-Result -ShouldSkip $false
        return
    }

    Write-Host "The GitHub alias '$normalizedAlias' is allowed to skip verification."
    Set-Result -ShouldSkip $true
    return
}

$allowedSkipEmails = Get-NormalizedSet -Default $defaultSkipEmails -Additional $AdditionalSkipEmails
$normalizedEmail = $RequestedForEmail.Trim().ToLowerInvariant()

if (!$normalizedEmail) {
    Write-Host "Could not determine the email of the person who requested the build. Verification will run."
    Set-Result -ShouldSkip $false
    return
}

if ($allowedSkipEmails -notcontains $normalizedEmail) {
    Write-Host "The email '$normalizedEmail' is not in the allowed skip list."
    Set-Result -ShouldSkip $false
    return
}

Write-Host "The email '$normalizedEmail' is allowed to skip verification."
Set-Result -ShouldSkip $true

return

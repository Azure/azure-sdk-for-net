<#
.SYNOPSIS
Evaluates whether codeowners verification should be skipped and sets a pipeline
variable with the result.

.DESCRIPTION
Codeowners verification can be skipped when the 'Skip.VerifyCodeowners' variable
is set to 'true' and the person who requested the build is a member of an allowed
set of emails. The allowed set is the union of a default list (kept in sync with
the emails used by create-apireview.yml) and any additional emails passed via
the AdditionalSkipEmails parameter.

The result is written to an Azure DevOps pipeline variable (default name
'ShouldSkipVerifyCodeowners') so that later steps can gate on a single variable.

.PARAMETER RequestedForEmail
The email of the person who requested the build (e.g. Build.RequestedForEmail).

.PARAMETER SkipVerifyCodeowners
The value of the 'Skip.VerifyCodeowners' pipeline variable. Verification is only
eligible to be skipped when this is 'true'.

.PARAMETER AdditionalSkipEmails
Additional emails allowed to skip verification, in addition to the
default set. Accepts a comma-, semicolon-, or whitespace-separated list.

.PARAMETER OutputVariableName
The name of the pipeline variable to set with the boolean result.
#>
[CmdletBinding()]
param (
    [string] $RequestedForEmail = '',
    [string] $SkipVerifyCodeowners = $env:SKIP_VERIFYCODEOWNERS,
    [string] $AdditionalSkipEmails = '',
    [string] $OutputVariableName = 'ShouldSkipVerifyCodeowners'
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

if ($SkipVerifyCodeowners -ne 'true') {
    Write-Host "Skip.VerifyCodeowners is not set. Verification will run."
    Write-Host "##vso[task.setvariable variable=$OutputVariableName]false"
    return
}

$defaultSkipEmails = @(
    'bebroder@microsoft.com',
    'mharder@microsoft.com',
    'djurek@microsoft.com',
    'chononiw@microsoft.com',
    'raychen@microsoft.com'
)

$extraSkipEmails = @($AdditionalSkipEmails -split '[,;\s]+' | Where-Object { $_ })

$allowedSkipEmails = @($defaultSkipEmails + $extraSkipEmails) |
    ForEach-Object { $_.Trim().ToLowerInvariant() } |
    Where-Object { $_ } |
    Select-Object -Unique

$normalizedEmail = $RequestedForEmail.Trim().ToLowerInvariant()

$shouldSkip = $allowedSkipEmails -contains $normalizedEmail

if ($shouldSkip) {
    Write-Host "Skipping codeowners verification. Skip.VerifyCodeowners is set and '$normalizedEmail' is an allowed email."
} else {
    Write-Host "Skip.VerifyCodeowners is set but '$normalizedEmail' is not an allowed email. Verification will run."
}

Write-Host "##vso[task.setvariable variable=$OutputVariableName]$($shouldSkip.ToString().ToLowerInvariant())"

return

param(
    [Parameter(Mandatory = $true)]
    [string]$AzureSDKEmailUri,

    [Parameter(Mandatory = $false)]
    [int]$PullRequestNumber = 0,

    [Parameter(Mandatory = $false)]
    [string]$Repository = "$env:BUILD_REPOSITORY_NAME",

    [Parameter(Mandatory = $false)]
    [string]$GitHubUser = "",

    [Parameter(Mandatory = $false)]
    [string]$ReleasePlanLink = "",

    [Parameter(Mandatory = $false)]
    [string]$SpecPullRequestUrl = "",

    [Parameter(Mandatory = $false)]
    [string]$EmailCC = "azsdkapex@microsoft.com"
)

<#
.SYNOPSIS
    Sends an email notification to the spec pull request author after a release plan is auto-created.

.DESCRIPTION
    This script runs as a pipeline step after the release plan creation step. It resolves the GitHub
    login of the spec pull request author, maps that login to a Microsoft email address using the
    opensource portal people links API (repos.opensource.microsoft.com), and sends an informational
    email using the Azure SDK emailer service.

    The email is only sent when the emailer service URL is provided (i.e. when running from the
    automation pipeline). Local executions without the URL are skipped so no email is sent.

    This script never fails the pipeline: any lookup or send failure is logged and the script exits 0
    so release plan creation is not blocked by notification problems.

.PARAMETER AzureSDKEmailUri
    The Uri of the app used to send email notifications. If empty, the script exits without sending.

.PARAMETER PullRequestNumber
    The spec pull request number. Used to resolve the author's GitHub login when GitHubUser is not provided.

.PARAMETER Repository
    The GitHub repository (owner/name) that contains the pull request. Defaults to BUILD_REPOSITORY_NAME.

.PARAMETER GitHubUser
    The spec pull request author's GitHub login. If provided, the pull request lookup is skipped.

.PARAMETER ReleasePlanLink
    Link to the created release plan, included in the email body.

.PARAMETER SpecPullRequestUrl
    Link to the spec pull request, included in the email body for context.

.PARAMETER EmailCC
    The CC address for the notification email.
#>

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot Helpers Metadata-Helpers.ps1)

# The aad resource (application id) for the opensource portal REST API.
$OpensourceApiResource = "api://2efaf292-00a0-426c-ba7d-f5d2b214b8fc"

function SendEmailNotification($emailTo, $emailCC, $emailSubject, $emailBody) {
    try {
        $body = @{ EmailTo = $emailTo; CC = $emailCC; Subject = $emailSubject; Body = $emailBody } | ConvertTo-Json -Depth 3
        Write-Host "Sending Email - To: $emailTo`nCC: $emailCC`nSubject: $emailSubject"
        Invoke-RestMethod -Uri $AzureSDKEmailUri -Method Post -Body $body -ContentType "application/json" | Out-Null
        Write-Host "Successfully sent email to $emailTo"
    }
    catch {
        Write-Warning "Failed to send email to $emailTo. Exception message: $($_.Exception.Message)"
    }
}

function BuildEmailBody([string]$displayName, [string]$releasePlanLink, [string]$specPullRequestUrl) {
    $greetingName = if ($displayName) { $displayName } else { "there" }
    $planLinkHtml = if ($releasePlanLink) { "<a href=`"$releasePlanLink`">$releasePlanLink</a>" } else { "the Release Planner tool" }
    $prLine = if ($specPullRequestUrl) { "<li><strong>Spec pull request:</strong> <a href=`"$specPullRequestUrl`">$specPullRequestUrl</a></li>" } else { "" }

    return @"
<html>
<body>
    <p>Hello $greetingName,</p>
    <p>Our automation has created a release plan for your recently merged API specification pull request.
    A release plan tracks the work required to generate and publish the Azure SDKs for your service.</p>
    <ul>
        <li><strong>Release plan:</strong> $planLinkHtml</li>
        $prLine
    </ul>
    <p><strong>Next steps:</strong></p>
    <ol>
        <li>Open the release plan and review the auto-populated details (service, product, target release date).</li>
        <li>Confirm the SDK languages and target release month are correct, and update them if needed.</li>
        <li>Follow the release plan to generate, review, and publish the SDKs for each language.</li>
    </ol>
    <p>For guidance on completing a release plan, see the
    <a href="https://eng.ms/docs/products/azure-developer-experience/plan/release-plan">Azure SDK release plan documentation</a>.</p>
    <p>Best regards,</p>
    <p>Azure SDK PM Team</p>
</body>
</html>
"@
}

# Skip when no emailer service URL is provided (e.g. local runs). This keeps notifications scoped to the pipeline.
if ([string]::IsNullOrWhiteSpace($AzureSDKEmailUri)) {
    Write-Host "AzureSDKEmailUri was not provided. Skipping release plan owner notification."
    exit 0
}

# Resolve the pull request author's GitHub login if not explicitly provided.
if ([string]::IsNullOrWhiteSpace($GitHubUser)) {
    if ($PullRequestNumber -le 0 -or [string]::IsNullOrWhiteSpace($Repository)) {
        Write-Warning "GitHubUser was not provided and PullRequestNumber/Repository are missing. Cannot resolve the pull request author. Skipping notification."
        exit 0
    }

    try {
        Write-Host "Resolving pull request author for $Repository#$PullRequestNumber"
        $GitHubUser = (gh pr view $PullRequestNumber --repo $Repository --json author --jq ".author.login").Trim()
    }
    catch {
        Write-Warning "Failed to resolve pull request author using gh CLI. Exception message: $($_.Exception.Message). Skipping notification."
        exit 0
    }
}

if ([string]::IsNullOrWhiteSpace($GitHubUser)) {
    Write-Warning "Could not determine the pull request author's GitHub login. Skipping notification."
    exit 0
}

# Get an aad token for the opensource portal API using the pipeline's Azure CLI login.
$token = ""
try {
    $token = (az account get-access-token --resource $OpensourceApiResource --query accessToken --output tsv).Trim()
}
catch {
    Write-Warning "Failed to acquire an access token for the opensource portal API. Exception message: $($_.Exception.Message). Skipping notification."
    exit 0
}

if ([string]::IsNullOrWhiteSpace($token)) {
    Write-Warning "Access token for the opensource portal API was empty. Skipping notification."
    exit 0
}

# Look up the GitHub -> Microsoft identity mapping.
$links = GetAllGithubUsers -Token $token
if (-not $links) {
    Write-Warning "Failed to retrieve GitHub alias links from the opensource portal API. Skipping notification."
    exit 0
}

$userLink = $links | Where-Object { $_.github -and $_.github.login -and ($_.github.login -eq $GitHubUser) } | Select-Object -First 1
if (-not $userLink -or -not $userLink.aad) {
    Write-Warning "No Microsoft identity link found for GitHub user '$GitHubUser'. Skipping notification."
    exit 0
}

$emailTo = $userLink.aad.userPrincipalName
if ([string]::IsNullOrWhiteSpace($emailTo)) {
    $emailTo = $userLink.aad.emailAddress
}

if ([string]::IsNullOrWhiteSpace($emailTo)) {
    Write-Warning "Resolved Microsoft identity for GitHub user '$GitHubUser' has no email address. Skipping notification."
    exit 0
}

$displayName = $userLink.aad.preferredName
$subject = "Action Required: Review the release plan for your Azure API specification"
$body = BuildEmailBody -displayName $displayName -releasePlanLink $ReleasePlanLink -specPullRequestUrl $SpecPullRequestUrl

SendEmailNotification -emailTo $emailTo -emailCC $EmailCC -emailSubject $subject -emailBody $body
exit 0

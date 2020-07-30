param(
    [Parameter(Mandatory = $true)]
    $RepoOwner,

    [Parameter(Mandatory = $true)]
    $RepoName,

    [Parameter(Mandatory = $false)]
    $GitHubUsers = "",

    [Parameter(Mandatory = $false)]
    $GitHubTeams = "",

    [Parameter(Mandatory = $true)]
    $PRNumber,
  
    [Parameter(Mandatory = $true)]
    $AuthToken
)

# at least one of these needs to be populated
if (-not $GitHubUsers -and -not $GitHubTeams) {
  Write-Host "No user provided for addition, exiting."
  exit 0
}

$userAdditions = @($GitHubUsers.Split(",") | % { $_.Trim() } | ? { return $_ })
$teamAdditions = @($GitHubTeams.Split(",") | % { $_.Trim() } | ? { return $_ })

$headers = @{
  Authorization = "bearer $AuthToken"
}
$uri = "https://api.github.com/repos/$RepoOwner/$RepoName/pulls/$PRNumber/requested_reviewers"

try {
  $resp = Invoke-RestMethod -Headers $headers $uri -MaximumRetryCount 3
}
catch {
  Write-Error "Invoke-RestMethod [$uri] failed with exception:`n$_"
  exit 1
}

# the response object takes this form: https://developer.github.com/v3/pulls/review_requests/#response-1
# before we can push a new reviewer, we need to pull the simple Ids out of the complex objects that came back in the response
$userReviewers = @($resp.users | % { return $_.login })
$teamReviewers = @($resp.teams | % { return $_.slug })

if (!$usersReviewers) { $modifiedUserReviewers = @() } else { $modifiedUserReviewers = $usersReviewers.Clone() }
$modifiedUserReviewers += ($modifiedUserReviewers | ? { !$usersReviews.Contains($_) })

if ($teamReviewers) { $modifiedTeamReviewers = @() } else { $modifiedTeamReviewers = $teamReviewers.Clone() }
$modifiedTeamReviewers += ($modifiedUserReviewers | ? { !$teamReviewers.Contains($_) })

$detectedUserDiffs = Compare-Object -ReferenceObject $userReviewers -DifferenceObject $modifiedUserReviewers
$detectedTeamDiffs = Compare-Object -ReferenceObject $teamReviewers -DifferenceObject $modifiedTeamReviewers

# Compare-Object returns values when there is a difference between the comparied objects.
# we only want to run the update if there IS a difference.
if ($detectedUserDiffs -or $detectedTeamDiffs) {
  $postResp = @{}

  if ($modifiedUserReviewers) { $postResp["reviewers"] = $modifiedUserReviewers }
  if ($modifiedTeamReviewers) { $postResp["team_reviewers"] = $modifiedTeamReviewers }

  $postResp = $postResp | ConvertTo-Json

  try {
    $resp = Invoke-RestMethod -Method Post -Headers $headers -Body $postResp -Uri $uri -MaximumRetryCount 3
    $resp | Write-Verbose
  }
  catch {
    Write-Error "Unable to update PR reviewers. `n$_"
  }
}
else {
  $results = $GitHubUsers + $GitHubTeams
  Write-Host "Reviewers $results already added. Exiting."
  exit(0)
}

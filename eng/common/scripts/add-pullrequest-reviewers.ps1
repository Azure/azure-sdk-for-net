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

function AddMembers($memberName, $additionSet) {
  $headers = @{
    Authorization = "bearer $AuthToken"
  }
  $uri = "https://api.github.com/repos/$RepoOwner/$RepoName/pulls/$PRNumber/requested_reviewers"
  $errorOccurred = $false

  foreach ($id in $additionSet) {
    try {
      $postResp = @{}
      $postResp[$memberName] = @($id)
      $postResp = $postResp | ConvertTo-Json

      Write-Host $postResp
      $resp = Invoke-RestMethod -Method Post -Headers $headers -Body $postResp -Uri $uri -MaximumRetryCount 3
      $resp | Write-Verbose
    }
    catch {
      Write-Host "Error attempting to add $user `n$_"
      $errorOccurred = $true
    }
  }

  return $errorOccurred
}

# at least one of these needs to be populated
if (-not $GitHubUsers -and -not $GitHubTeams) {
  Write-Host "No user provided for addition, exiting."
  exit 0
}

$userAdditions = @($GitHubUsers.Split(",") | % { $_.Trim() } | ? { return $_ })
$teamAdditions = @($GitHubTeams.Split(",") | % { $_.Trim() } | ? { return $_ })

$errorsOccurredAddingUsers = AddMembers -memberName "reviewers" -additionSet $userAdditions
$errorsOccurredAddingTeams = AddMembers -memberName "team_reviewers" -additionSet $teamAdditions

if ($errorsOccurredAddingUsers -or $errorsOccurredAddingTeams) {
  exit 1
}

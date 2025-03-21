function MapLanguageToRequestParam($language)
{
    $lang = $language
    # Update language name to match those in API cosmos DB. Cosmos SQL is case sensitive and handling this within the query makes it slow.
    if($lang -eq 'javascript'){
        $lang = "JavaScript"
    }
    elseif ($lang -eq "dotnet"){
        $lang = "C%23"
    }
    elseif ($lang -eq "java"){
        $lang = "Java"
    }
    elseif ($lang -eq "python"){
        $lang = "Python"
    }
    else{
      $lang = $null
    }
    return $lang
}

function Check-ApiReviewStatus($packageName, $packageVersion, $language, $url, $apiKey, $apiApprovalStatus = $null, $packageNameStatus = $null)
{
  # Get API view URL and API Key to check status
  Write-Host "Checking API review status for package: ${packageName}"
  $lang = MapLanguageToRequestParam -language $language
  if ($lang -eq $null) {
    return
  }
  $headers = @{ "ApiKey" = $apiKey }

  if (!$apiApprovalStatus) {
    $apiApprovalStatus = [PSCustomObject]@{
      IsApproved = $false
      Details = ""
    }
  }

  if (!$packageNameStatus) {
    $packageNameStatus = [PSCustomObject]@{
      IsApproved = $false
      Details = ""
    }
  }

  try
  {
    $requestUrl = "${url}?language=${lang}&packageName=${packageName}&packageVersion=${packageVersion}"
    Write-Host "Request to APIView: [${requestUrl}]"
    $response = Invoke-WebRequest $requestUrl -Method 'GET' -Headers $headers
    Write-Host "Response: $($response.StatusCode)"
    Process-ReviewStatusCode -statusCode $response.StatusCode -packageName $packageName -apiApprovalStatus $apiApprovalStatus -packageNameStatus $packageNameStatus
    if ($apiApprovalStatus.IsApproved) {
      Write-Host $($apiApprovalStatus.Details)
    }
    else {
      Write-warning $($apiApprovalStatus.Details)
    }
    if ($packageNameStatus.IsApproved) {
      Write-Host $($packageNameStatus.Details)
    }
    else {
      Write-warning $($packageNameStatus.Details)
    }
  }
  catch
  {
    Write-Warning "Failed to check API review status for package $($PackageName). You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
  }
}

function Process-ReviewStatusCode($statusCode, $packageName, $apiApprovalStatus, $packageNameStatus)
{
  $apiApproved = $false
  $apiApprovalDetails = "API Review is not approved for package $($packageName). Release pipeline will fail if API review is not approved for a GA version release. You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
  $apiApprovalDetails += " Once your API is approved, re-trigger the release pipeline again."

  $packageNameApproved = $false
  $packageNameApprovalDetails = ""

  # 200 API approved and Package name approved
  # 201 API review is not approved, Package name is approved
  # 202 API review is not approved, Package name is not approved

  switch ($statusCode)
  {
    200
    {
      $apiApprovalDetails = "API Review is approved for package $($packageName)"
      $apiApproved = $true

      $packageNameApproved = $true
      $packageNameApprovalDetails = "Package name is approved for package $($packageName)"
    }
    201
    {
      $packageNameApproved = $true
      $packageNameApprovalDetails = "Package name is approved for package $($packageName)"
    }
    202
    {
      $packageNameApprovalDetails = "Package name $($packageName) is not yet approved by an SDK API approver. Package name must be approved to release a beta version if $($packageName) was never released as a stable version."
      $packageNameApprovalDetails += " You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on package name Approval."
    }
    default
    {
      $apiApprovalDetails = "Invalid status code from APIView. status code $($statusCode)"
      $packageNameApprovalDetails = "Invalid status code from APIView. status code $($statusCode)"
      Write-Error "Failed to process API Review status for for package $($PackageName). Please reach out to Azure SDK engineering systems on teams channel."
    }
  }

  $apiApprovalStatus.IsApproved = $apiApproved
  $apiApprovalStatus.Details = $apiApprovalDetails

  $packageNameStatus.IsApproved = $packageNameApproved
  $packageNameStatus.Details = $packageNameApprovalDetails
}

function Set-ApiViewCommentForRelatedIssues {
  param (
    [Parameter(Mandatory = $true)]
    [string]$SourceCommish,
    [Parameter(Mandatory = $true)]
    [string]$HeadCommitish,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )
  . ${PSScriptRoot}\..\common.ps1
  $issuesForCommit = $null
  try {
    $issuesForCommit = Search-GitHubIssues -CommitHash $HeadCommitish
    if ($issuesForCommit.items.Count -eq 0) {
      LogError "No issues found for commit: $HeadCommitish"
      exit 1
    }
  } catch {
    LogError "No issues found for commit: $HeadCommitish"
    exit 1
  }
  $issuesForCommit.items | ForEach-Object {
    $urlParts = $_.url -split "/"
    Set-ApiViewCommentForPR -RepoOwner $urlParts[4] -RepoName $urlParts[5] -PrNumber $urlParts[7] -SourceCommish $SourceCommish -AuthToken $AuthToken
  }
}

function Set-ApiViewCommentForPR {
  param (
    [Parameter(Mandatory = $true)]
    [string]$RepoOwner,
    [Parameter(Mandatory = $true)]
    [string]$RepoName,
    [Parameter(Mandatory = $true)]
    [string]$PrNumber,
    [Parameter(Mandatory = $true)]
    [string]$SourceCommish,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )
  $repoFullName = "$RepoOwner/$RepoName"
  $apiviewEndpoint = "https://apiview.dev/api/pullrequests?pullRequestNumber=$PrNumber&repoName=$repoFullName&commitSHA=$SourceCommish"
  LogDebug "Get APIView information for PR using endpoint: $apiviewEndpoint"

  $commentText = @()
  $commentText += "## API Change Check"
  try {
    $response = Invoke-RestMethod -Uri $apiviewEndpoint -Method Get -MaximumRetryCount 3
    if ($response.Count -eq 0) {
      LogWarning "API changes are not detected in this pull request."
      $commentText += ""
      $commentText += "API changes are not detected in this pull request."
    }
    else {
      LogSuccess "APIView identified API level changes in this PR and created $($response.Count) API reviews"
      $commentText += ""
      $commentText += "APIView identified API level changes in this PR and created the following API reviews"
      $commentText += ""
      $commentText += "| Language | APIView |"
      $commentText += "|----------|---------|"
      $response | ForEach-Object {
        $commentText += "| $($_.language) | [$($_.packageName)]($($_.url)) |"
      }
    }
  } catch{
    LogError "Failed to get API View information for PR: $PrNumber in repo: $repoFullName with commitSHA: $Commitish. Error: $_"
    exit 1
  }

  $commentText = $commentText -join "`r`n"
  $existingComment = $null;
  $existingAPIViewComment = $null;

  try {
    $existingComment = Get-GitHubIssueComments -RepoOwner $RepoOwner -RepoName $RepoName -IssueNumber $PrNumber -AuthToken $AuthToken
    $existingAPIViewComment = $existingComment | Where-Object { 
      $_.body.StartsWith("**API Change Check**", [StringComparison]::OrdinalIgnoreCase) -or $_.body.StartsWith("## API Change Check", [StringComparison]::OrdinalIgnoreCase) }
  } catch {
    LogWarning "Failed to get comments from Pull Request: $PrNumber in repo: $repoFullName"
  }
  
  try {
    if ($existingAPIViewComment) {
      LogDebug "Updating existing APIView comment..."
      Update-GitHubIssueComment -RepoOwner $RepoOwner -RepoName $RepoName `
                                -CommentId $existingAPIViewComment.id -Comment $commentText `
                                -AuthToken $AuthToken
    } else {
      LogDebug "Creating new APIView comment..."
      Add-GitHubIssueComment -RepoOwner $RepoOwner -RepoName $RepoName `
                             -IssueNumber $PrNumber -Comment $commentText `
                             -AuthToken $AuthToken
    }
  } catch {
    LogError "Failed to set PR comment for APIView. Error: $_"
    exit 1
  }
}

. ${PSScriptRoot}\..\logging.ps1

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
    [string]$HeadCommitish,
    [string]$APIViewHost = "https://apiview.dev",
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )
  . ${PSScriptRoot}\..\common.ps1
  $issuesForCommit = $null
  try {
    $issuesForCommit = Search-GitHubIssues -CommitHash $HeadCommitish
    if ($issuesForCommit.items.Count -eq 0) {
      LogInfo "No issues found for commit: $HeadCommitish"
      Write-Host "##vso[task.complete result=SucceededWithIssues;]DONE"
      exit 0
    }
  } catch {
    LogError "No issues found for commit: $HeadCommitish"
    exit 1
  }
  $issuesForCommit.items | ForEach-Object {
    $urlParts = $_.url -split "/"
    Set-ApiViewCommentForPR -RepoOwner $urlParts[4] -RepoName $urlParts[5] -PrNumber $urlParts[7] -HeadCommitish $HeadCommitish -APIViewHost $APIViewHost -AuthToken $AuthToken
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
    [string]$HeadCommitish,
    [Parameter(Mandatory = $true)]
    [string]$APIViewHost,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory = $true)]
    $AuthToken
  )
  $repoFullName = "$RepoOwner/$RepoName"
  $apiviewEndpoint = "$APIViewHost/api/pullrequests?pullRequestNumber=$PrNumber&repoName=$repoFullName&commitSHA=$HeadCommitish"
  LogDebug "Get APIView information for PR using endpoint: $apiviewEndpoint"

  $commentText = @()
  $commentText += "## API Change Check"
  try {
    $response = Invoke-WebRequest -Uri $apiviewEndpoint -Method Get -MaximumRetryCount 3
    LogInfo "OperationId: $($response.Headers['X-Operation-Id'])"
    if ($response.StatusCode -ne 200) {
      LogInfo "API changes are not detected in this pull request."
      exit 0
    }
    else {
      LogSuccess "APIView identified API level changes in this PR and created $($response.Count) API reviews"
      $commentText += ""
      $commentText += "APIView identified API level changes in this PR and created the following API reviews"
      $commentText += ""

      $responseContent = $response.Content | ConvertFrom-Json
      if ($RepoName.StartsWith(("azure-sdk-for-"))) {
        $responseContent | ForEach-Object {
          $commentText += "[$($_.packageName)]($($_.url))"
        }
      } else {
        $commentText += "| Language | API Review for Package |"
        $commentText += "|----------|---------|"
        $responseContent | ForEach-Object {
          $commentText += "| $($_.language) | [$($_.packageName)]($($_.url)) |"
        }
      }
    }
  } catch{
    LogError "Failed to get API View information for PR: $PrNumber in repo: $repoFullName with commitSHA: $HeadCommitish. Error: $_"
    exit 1
  }

  $commentText += "<!-- Fetch URI: $apiviewEndpoint -->"
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

# Helper function used to create API review requests for Spec generation SDKs pipelines
function Create-API-Review {
  param (
    [string]$apiviewEndpoint = "https://apiview.dev/PullRequest/DetectAPIChanges",
    [string]$specGenSDKArtifactPath,
    [string]$apiviewArtifactName,
    [string]$buildId,
    [string]$commitish,
    [string]$repoName,
    [string]$pullRequestNumber
  )
  $specGenSDKContent = Get-Content -Path $SpecGenSDKArtifactPath -Raw | ConvertFrom-Json
  $language = ($specGenSDKContent.language -split "-")[-1]
  
  foreach ($requestData in $specGenSDKContent.apiViewRequestData) {
    $requestUri = [System.UriBuilder]$apiviewEndpoint
    $requestParam = [System.Web.HttpUtility]::ParseQueryString('')
    $requestParam.Add('artifactName', $apiviewArtifactName)
    $requestParam.Add('buildId', $buildId)
    $requestParam.Add('commitSha', $commitish)
    $requestParam.Add('repoName', $repoName)
    $requestParam.Add('pullRequestNumber', $pullRequestNumber)
    $requestParam.Add('packageName', $requestData.packageName)
    $requestParam.Add('filePath', $requestData.filePath)
    $requestParam.Add('language', $language)
    $requestUri.query = $requestParam.toString()
    $correlationId = [System.Guid]::NewGuid().ToString()

    $headers = @{
      "Content-Type"  = "application/json"
      "x-correlation-id" = $correlationId
    }

    LogInfo "Request URI: $($requestUri.Uri.OriginalString)"
    LogInfo "Correlation ID: $correlationId"

    try
    {
      $response = Invoke-WebRequest -Method 'GET' -Uri $requestUri.Uri -Headers $headers -MaximumRetryCount 3
      if ($response.StatusCode -eq 201) {
        LogSuccess "Status Code: $($response.StatusCode)`nAPI review request created successfully.`n$($response.Content)"
      }
      elseif ($response.StatusCode -eq 208) {
        LogSuccess "Status Code: $($response.StatusCode)`nThere is no API change compared with the previous version."
      }
      else {
        LogError "Failed to create API review request. $($response)"
        exit 1
      }
    }
    catch
    {
      LogError "Error : $($_.Exception)"
      exit 1
    }
  }
}
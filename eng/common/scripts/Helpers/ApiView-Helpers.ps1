function MapLanguageName($language)
{
    $lang = $language
    # Update language name to match those in API cosmos DB. Cosmos SQL is case sensitive and handling this within the query makes it slow.
    if($lang -eq 'javascript'){
        $lang = "JavaScript"
    }
    elseif ($lang -eq "dotnet"){
        $lang = "C#"
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
  Write-Host "Checking API review status"
  $lang = MapLanguageName -language $language
  if ($lang -eq $null) {
    return
  }
  $headers = @{ "ApiKey" = $apiKey }
  $body = @{
    language = $lang
    packageName = $packageName
    packageVersion = $packageVersion
  }

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
    $response = Invoke-WebRequest $url -Method 'GET' -Headers $headers -Body $body
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
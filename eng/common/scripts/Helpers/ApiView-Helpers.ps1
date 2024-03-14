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

function Check-ApiReviewStatus($packageName, $packageVersion, $language, $url, $apiKey)
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

  try
  {
    $response = Invoke-WebRequest $url -Method 'GET' -Headers $headers -Body $body
    if ($response.StatusCode -eq '200')
    {
      Write-Host "API Review is approved for package $($packageName)"
    }
    elseif ($response.StatusCode -eq '202')
    {
      Write-Host "Package name $($packageName) is not yet approved by an SDK API approver. Package name must be approved to release a beta version if $($packageName) was never released a stable version."
      Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on package name Approval."
    }
    elseif ($response.StatusCode -eq '201')
    {
      Write-Warning "API Review is not approved for package $($packageName). Release pipeline will fail if API review is not approved for a stable version release."
      Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
    }
    else
    {
      Write-Warning "API review status check returned unexpected response. $($response)"
      Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
    }
  }
  catch
  {
    Write-Warning "Failed to check API review status for package $($PackageName). You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
  }
}

function Process-ReviewStatusCode($statusCode, $packageName, $apiApprovalStat, $packageNameStat)
{
  $apiApproved = $false
  $apiApprovalDetails = "API Review is not approved for package $($packageName). Release pipeline will fail if API review is not approved for a GA version release."

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

  $apiApprovalStat.IsApproved = $apiApproved
  $apiApprovalStat.Details = $apiApprovalDetails

  $packageNameStat.IsApproved = $packageNameApproved
  $packageNameStat.Details = $packageNameApprovalDetails
}
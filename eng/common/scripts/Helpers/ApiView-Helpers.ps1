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
    else
    {
      Write-Warning "API Review is not approved for package $($packageName). Release pipeline will fail if API review is not approved."
      Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
    }
  }
  catch
  {
    Write-Warning "Failed to check API review status for package $($PackageName). You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
  }
}
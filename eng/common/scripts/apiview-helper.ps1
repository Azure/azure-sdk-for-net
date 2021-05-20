

function Map-LanguageToAPiview-Filter($language)
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
    return $lang
}

function Check-ApiReviewStatus($packageName, $language)
{
  # Get API view URL and API Key to check status
  Login-AzAccount
  $url = Get-AzKeyvaultSecret -VaultName "AzureSDKPrepRelease-KV" -Name APIURL -AsPlainText
  $apiKey = Get-AzKeyvaultSecret -VaultName "AzureSDKPrepRelease-KV" -Name APIKEY -AsPlainText

  $lang = Map-LanguageToAPiview-Filter -language $language
  $headers = @{ "ApiKey" = $apiKey }
  $body = @{
    language = $lang
    packageName = $packageName
  }

  try
  {
    $Response = Invoke-WebRequest $url -Method 'GET' -Headers $headers -Body $body
    if ($Response.StatusCode -eq '200')
    {
      Write-Host "API Review is approved for package $($packageName)"
      return $true
    }
    else
    {
      Write-Host "API Review is not approved for package $($packageName). Please get automatic API review approved by architects."
      Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
    }
  }
  catch
  {
    Write-Host "Exception details: $($_.Exception.Response)"
    Write-Host "Failed to check API review status for package $($PackageName). You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
  }
  return $false
}
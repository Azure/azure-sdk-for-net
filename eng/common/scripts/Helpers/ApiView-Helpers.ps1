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

function Check-ApiReviewStatus($packageName, $packageVersion, $language)
{
  # Get API view URL and API Key to check status
  Write-Host "Checking API review status"
  try
  {
    az login -o none
    $url = az keyvault secret show --name "APIURL" --vault-name "AzureSDKPrepRelease-KV" --query "value" --output "tsv"
    $apiKey = az keyvault secret show --name "APIKEY" --vault-name "AzureSDKPrepRelease-KV" --query "value" --output "tsv"
  }
  catch
  {
    Write-Host "Failed to get APIView URL and API Key from Keyvault AzureSDKPrepRelease-KV. Please check and ensure you have access to this Keyvault as reader."
    Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details."
  }
  
  $lang = Map-LanguageToAPiview-Filter -language $language
  $headers = @{ "ApiKey" = $apiKey }
  $body = @{
    language = $lang
    packageName = $packageName
    packageVersion = $packageVersion
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
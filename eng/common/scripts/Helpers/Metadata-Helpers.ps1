function Generate-AadToken ($TenantId, $ClientId, $ClientSecret)
{
    $LoginAPIBaseURI = "https://login.microsoftonline.com/$TenantId/oauth2/token"

    $headers = @{
        "content-type" = "application/x-www-form-urlencoded"
    }

    $body = @{
        "grant_type" = "client_credentials"
        "client_id" = $ClientId
        "client_secret" = $ClientSecret
        "resource" = "api://2789159d-8d8b-4d13-b90b-ca29c1707afd"
    }
    Write-Host "Generating aad token..."
    $resp = Invoke-RestMethod $LoginAPIBaseURI -Method 'POST' -Headers $headers -Body $body
    return $resp.access_token
}

function GetAllGithubUsers ([string]$TenantId, [string]$ClientId, [string]$ClientSecret)
{
    # API documentation (out of date): https://github.com/microsoft/opensource-management-portal/blob/main/docs/api.md
    $OpensourceAPIBaseURI = "https://repos.opensource.microsoft.com/api/people/links"

    $Headers = @{
        "Content-Type" = "application/json"
        "api-version" = "2019-10-01"
    }

    try {
        $opsAuthToken = Generate-AadToken -TenantId $TenantId -ClientId $ClientId -ClientSecret $ClientSecret
        $Headers["Authorization"] = "Bearer $opsAuthToken"
        Write-Host "Fetching all github alias links"
        $resp = Invoke-RestMethod $OpensourceAPIBaseURI -Method 'GET' -Headers $Headers -MaximumRetryCount 3
    } catch {
        Write-Warning $_
        return $null
    }

    return $resp
}

function GetDocsMsService($packageInfo, $serviceName) 
{
  $service = $serviceName.ToLower().Replace(' ', '').Replace('/', '-')
  if ($packageInfo.MSDocService) {
    # Use MSDocService in csv metadata to override the service directory    
    # TODO: Use taxonomy for service name -- https://github.com/Azure/azure-sdk-tools/issues/1442
    $service = $packageInfo.MSDocService
  }
  Write-Host "The service of package: $service"
  return $service
}

function compare-and-merge-metadata ($original, $updated) {
  $updateMetdata = ($updated.GetEnumerator() | ForEach-Object { "$($_.Key): $($_.Value)" }) -join "`r`n"
  $updateMetdata += "`r`n"
  if (!$original) {
    return $updateMetdata 
  }
  $originalTable = ConvertFrom-StringData -StringData $original -Delimiter ":"
  foreach ($key in $originalTable.Keys) {
    if (!($updated.Contains($key))) {
      Write-Warning "New metadata missed the entry: $key. Adding back."
      $updateMetdata += "$key`: $($originalTable[$key])`r`n"
    }
  }
  return $updateMetdata
}

function GenerateDocsMsMetadata(
  $originalMetadata,
  $language,
  $languageDisplayName,
  $serviceName,
  $msService
) {
  $langTitle = "Azure $serviceName SDK for $languageDisplayName"
  $langDescription = "Reference for Azure $serviceName SDK for $languageDisplayName"
  $date = Get-Date -Format "MM/dd/yyyy"

  $metadataTable = [ordered]@{
    "title"= $langTitle
    "description"= $langDescription
    "ms.date"= $date
    "ms.topic"= "reference"
    "ms.devlang"= $language
    "ms.service"= $msService
  }
  $updatedMetadata = compare-and-merge-metadata -original $originalMetadata -updated $metadataTable
  return "---`r`n$updatedMetadata---`r`n"
}

function ServiceLevelReadmeNameStyle($serviceName) {
  return $serviceName.ToLower().Replace(' ', '-').Replace('/', '-')
}

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
        "resource" = "api://repos.opensource.microsoft.com/audience/7e04aa67"
    }
    Write-Host "Generating aad token..."
    $resp = Invoke-RestMethod $LoginAPIBaseURI -Method 'POST' -Headers $headers -Body $body
    return $resp.access_token
}

function GetMsAliasFromGithub ([string]$TenantId, [string]$ClientId, [string]$ClientSecret, [string]$GithubUser)
{
    # API documentation (out of date): https://github.com/microsoft/opensource-management-portal/blob/main/docs/api.md
    $OpensourceAPIBaseURI = "https://repos.opensource.microsoft.com/api/people/links/github/$GithubUser"

    $Headers = @{
        "Content-Type" = "application/json"
        "api-version" = "2019-10-01"
    }

    try {
        $opsAuthToken = Generate-AadToken -TenantId $TenantId -ClientId $ClientId -ClientSecret $ClientSecret
        $Headers["Authorization"] = "Bearer $opsAuthToken"
        Write-Host "Fetching aad identity for github user: $GithubUser"
        $resp = Invoke-RestMethod $OpensourceAPIBaseURI -Method 'GET' -Headers $Headers -MaximumRetryCount 3
    } catch {
        Write-Warning $_
        return $null
    }

    $resp | Write-Verbose

    if ($resp.aad) {
        Write-Host "Fetched aad identity $($resp.aad.alias) for github user $GithubUser. "
        return $resp.aad.alias
    }
    Write-Warning "Failed to retrieve the aad identity from given github user: $GithubName"
    return $null
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

function GetPrimaryCodeOwner ([string]$TargetDirectory)
{
    $codeOwnerArray = &"$PSScriptRoot/../get-codeowners.ps1" -TargetDirectory $TargetDirectory
    if ($codeOwnerArray) {
        Write-Host "Code Owners are $codeOwnerArray."
        return $codeOwnerArray[0]
    }
    Write-Warning "No code owner found in $TargetDirectory."
    return $null
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

function GenerateDocsMsMetadata($language, $langTitle = "", $serviceName, $tenantId, $clientId, $clientSecret, $msService) 
{
  if (!$langTitle) {
    $langTitle = "Azure $serviceName SDK for $language"
  }
  $langDescription = "Reference for Azure $serviceName SDK for $language"
  # Github url for source code: e.g. https://github.com/Azure/azure-sdk-for-js
  $serviceBaseName = $serviceName.ToLower().Replace(' ', '').Replace('/', '-')
  $author = GetPrimaryCodeOwner -TargetDirectory "/sdk/$serviceBaseName/"
  $msauthor = ""
  if (!$author) {
    LogError "Cannot fetch the author from CODEOWNER file."
    return
  }
  elseif ($TenantId -and $ClientId -and $ClientSecret) {
    $msauthor = GetMsAliasFromGithub -TenantId $tenantId -ClientId $clientId -ClientSecret $clientSecret -GithubUser $author
  }
  # Default value
  if (!$msauthor) {
    LogError "No ms.author found for $author. "
    $msauthor = $author
  }
  $date = Get-Date -Format "MM/dd/yyyy"
  $header = @"
---
title: $langTitle
description: $langDescription
author: $author
ms.author: $msauthor
ms.date: $date
ms.topic: reference
ms.devlang: $language
ms.service: $msService
---
"@
  return $header
}

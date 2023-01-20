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

function GenerateDocsMsMetadata($originalMetadata, $language, $languageDisplayName, $serviceName, $author, $msAuthor, $msService) 
{
  $langTitle = "Azure $serviceName SDK for $languageDisplayName"
  $langDescription = "Reference for Azure $serviceName SDK for $languageDisplayName"
  $date = Get-Date -Format "MM/dd/yyyy"

  $metadataTable = [ordered]@{
    "title"= $langTitle
    "description"= $langDescription
    "author"= $author
    "ms.author"= $msauthor
    "ms.data"= $date
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

function compareAndGetLatest($v1, $v2) {
  if (!$v1 -and !$v2) {
    return ''
  }
  if (!$v1 -or ($v1 -lt $v2)) {
    return $v2
  }
  return $v1
}

function MergeObject($toObject, $fromObject) {
  foreach($toProperty in $toObject.PSObject.Properties) {
    if ($toProperty.Name -eq 'Version') {
      $toObject.Version = compareAndGetLatest $fromObject.Version $toObject.Version
      continue
    }
    foreach ($fromProperty in $fromObject.PSObject.Properties) {
      if ($toProperty.Name -eq $fromProperty.Name) {
        $toProperty.Value = $fromProperty.Value
      }
    }
  }
}

function MergeCSVToDocsMetadata($csvPackages, $docsMetadata, $moniker, $dailyDocs) {
  $isGroupId = $csvPackages.PSObject.Properties.Name -contains 'GroupId'
  # Define the object with all properties (hard-coded)
  $mergedPackages = @{}
  # forloop into docs metadata
  foreach ($metadata in $docsMetadata) {
    $key = $metadata.Name
    if ($isGroupId) {
      $key = "$key-$($metadata.Group)"
    }
    $newMergedObject = &$CreateNewPackageObjectFn
    if ($metadata.PSObject.Properties.Name -contains 'SkdType') {
      $metadata | Add-Member -MemberType NoteProperty -Name 'Type' -Value $metadata.SdkType
    }
    if ($metadata.PSObject.Properties.Name -contains 'IsNewSdk') {
      $metadata | Add-Member -MemberType NoteProperty -Name 'New' -Value $metadata.IsNewSdk
    }
    MergeObject -toObject $newMergedObject -fromObject $metadata
    $mergedPackages[$key] = $newMergedObject
  }
  # forloop into csv packages
  foreach ($metadata in $csvPackages) {    
    $key = $metadata.Package
    if ($isGroupId) {
      $key = "$key-$($metadata.GroupId)"
    }
    if (!$mergedPackages.ContainsKey($key)) {
      $mergedPackages[$key] = &$CreateNewPackageObjectFn
    }
    $version = $metadata.VersionGA
    if ($moniker -eq 'preview' -or !$version) {
      $version = $metadata.VersionPreview
    }
    # Normalized the property name with combined one.
    $metadata | Add-Member -MemberType NoteProperty -Name 'Name' -Value $metadata.Package
    if ($metadata.PSObject.Properties.Name -contains 'GroupId') {
      $metadata | Add-Member -MemberType NoteProperty -Name 'Group' -Value $metadata.GroupId
    }
    $metadata | Add-Member -MemberType NoteProperty -Name 'Version' -Value $version
    MergeObject -toObject $mergedPackages[$key] -fromObject $metadata
  }
  return $mergedPackages.Values
}
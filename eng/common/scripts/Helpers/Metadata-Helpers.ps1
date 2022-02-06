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

function GetMsAliasFromGithub ($TenantId, $ClientId, $ClientSecret, $GithubUser) 
{
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
    }
    catch { 
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

function GetPrimaryCodeOwner ($TargetDirectory) 
{
    $codeOwnerArray = &"$PSScriptRoot/../get-codeowners.ps1" -TargetDirectory $TargetDirectory
    if ($codeOwnerArray) {
        Write-Host "Code Owners are $codeOwnerArray."
        return $codeOwnerArray[0]
    }
    Write-Warning "No code owner found in $TargetDirectory."
    return $null
}

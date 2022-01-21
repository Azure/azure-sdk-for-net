<#
.DESCRIPTION
Get the corresponding ms alias from github identity
.PARAMETER AadToken
The aad access token.
.PARAMETER GithubName
Github identity. E.g sima-zhu
.PARAMETER ContentType
Content type of http requests.
.PARAMETER AdditionalHeaders
Additional parameters for http request headers in key-value pair format, e.g. @{ key1 = val1; key2 = val2; key3 = val3}
#>
[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$TenantId,
  
  [Parameter(Mandatory = $true)]
  [string]$ClientId,
  
  [Parameter(Mandatory = $true)]
  [string]$ClientSecret,

  [Parameter(Mandatory = $true)]
  [string]$GithubName
)
. "${PSScriptRoot}\logging.ps1"

$OpensourceAPIBaseURI = "https://repos.opensource.microsoft.com/api/people/links/github/$GithubName"

function Generate-AadToken ($TenantId, $ClientId, $ClientSecret) {
    $LoginAPIBaseURI = "https://login.microsoftonline.com/$TenantId/oauth2/token"
    try {
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
    }
    catch { 
        LogError $_
        exit 1
    }
    
    $resp | Write-Verbose
    
    return $resp.access_token
} 

$Headers = @{
    "Content-Type" = "application/json"
    "api-version" = "2019-10-01"
}

try {
    $aadToken = Generate-AadToken -TenantId $TenantId -ClientId $ClientId -ClientSecret $ClientSecret
    $Headers["Authorization"] = "Bearer $aadToken"
    Write-Host "Fetching ms alias for github identity: $GithubName."
    $resp = Invoke-RestMethod $OpensourceAPIBaseURI -Method 'GET' -Headers $Headers
}
catch { 
    LogError $_
    exit 1
}

$resp | Write-Verbose

if ($resp.aad) {
    return $resp.aad.alias
}

LogError "Failed to retrieve the ms alias from given github identity: $GithubName."

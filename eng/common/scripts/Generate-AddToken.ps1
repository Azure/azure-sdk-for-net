<#
.DESCRIPTION
Generate aadToken for Azure Directory app using client secrets.

.PARAMETER TenantId
The aad tenant id/Directory ID. 

.PARAMETER ClientId
The aad client id/application id. 

.PARAMETER ClientSecret
The client secret generates from add.

.PARAMETER Resource
The App ID URI of the web service.
E.g. https://graph.windows.net/

.PARAMETER Scope
The full scope string defining the requested permissions.

.PARAMETER GrantType
OAuth defines four grant types: authorization code, implicit,
resource owner password credentials, and client credentials.

.PARAMETER ContentType
Content type of http requests.

.PARAMETER AdditionalHeaders
Additional parameters for http request headers in key-value pair format, e.g. @{ key1 = val1; key2 = val2; key3 = val3}

.PARAMETER AdditionalBody
Additional parameters for http request body in key-value pair format, e.g. @{ key1 = val1; key2 = val2; key3 = val3}
#>
[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$TenantId,

  [Parameter(Mandatory = $true)]
  [string]$ClientId,

  [Parameter(Mandatory = $true)]
  [string]$ClientSecret,

  [Parameter(Mandatory = $false)]
  [string]$Resource,

  [Parameter(Mandatory = $false)]
  [string]$Scope,

  [Parameter(Mandatory = $false)]
  [string]$GrantType = "client_credentials",

  [Parameter(Mandatory = $false)]
  [string]$ContentType = "application/x-www-form-urlencoded",

  [Parameter(Mandatory = $false)]
  [hashtable]$AdditionalHeaders,

  [Parameter(Mandatory = $false)]
  [hashtable]$AdditionalBody
)
. "${PSScriptRoot}\logging.ps1"

$LoginAPIBaseURI = "https://login.microsoftonline.com/$TenantId/oauth2/token"

$Headers = @{
    content_type = $ContentType
}

$Body = @{
    grant_type = $GrantType
    client_id = $ClientId
    client_secret = $ClientSecret
}

function Load-RequestHeaders() {
    if ($AdditionalHeaders) {
        return $Headers + $AdditionalHeaders
    }
    return $Headers
}

function Load-RequestBody() {
    if ($Resource) {
        $Body.Add("resource", $Resource)
    } 
    if ($Scope) {
        $Body.Add("scope", $Scope)
    } 
    if ($AdditionalBody) {
        return $Body + $AdditionalBody
    }
    return $Body
}

try {
    $headers = Load-RequestHeaders
    $body = Load-RequestBody
    $resp = Invoke-RestMethod $LoginAPIBaseURI -Method 'POST' -Headers $headers -Body $body
}
catch { 
    LogError $PSItem.ToString()
    exit 1
}

$resp | Write-Verbose

return $resp.access_token

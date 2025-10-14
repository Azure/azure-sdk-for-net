<#
.SYNOPSIS
  Mints a GitHub App installation access token using Azure Key Vault 'sign' (non-exportable key),
  and logs in the GitHub CLI by setting GH_TOKEN (and GITHUB_TOKEN).

.PARAMETER KeyVaultName
  Name of the Azure Key Vault containing the non-exportable RSA key.

.PARAMETER KeyName
  Name of the RSA key in Key Vault (imported as a *key*, not a secret).

.PARAMETER GitHubAppId
  Numeric App ID (not client ID) of your GitHub App.

.PARAMETER PipelineVariableName
  Name of the ADO variable to set when -SetPipelineVariable is used (default: GH_TOKEN).

.OUTPUTS
  Writes minimal info to stdout. Token is placed in $env:GH_TOKEN and $env:GITHUB_TOKEN.

.NOTES
  Requires: Azure CLI (az), git (optional), gh (optional if ShowGhAuthStatus is used).
#>

[CmdletBinding()]
param(
  [string] $KeyVaultName = "azuresdkengkeyvault",
  [string] $KeyName = "azure-sdk-automation",
  [string] $GitHubAppId = '1086291',
  [string] $InstallationTokenOwner = "Azure",
  [string] $PipelineVariableName = "GH_TOKEN"
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

$GitHubApiBaseUrl = "https://api.github.com"
$GitHubApiVersion = "2022-11-28"

function Get-Headers {
  param(
    [Parameter(Mandatory)][string] $Jwt,
    [Parameter(Mandatory)][string] $ApiVersion
  )
  return @{
    'Authorization'        = "Bearer $Jwt"
    'Accept'               = 'application/vnd.github+json'
    'X-GitHub-Api-Version' = $ApiVersion
    'User-Agent'           = 'ado-pwsh-ghapp'
  }
}

function New-GitHubAppJwt {
  param(
    [Parameter(Mandatory)] [string] $VaultName,
    [Parameter(Mandatory)] [string] $KeyName,
    [Parameter(Mandatory)] [string] $AppId
  )

  function Base64UrlEncode($json) {
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $base64 = [Convert]::ToBase64String($bytes)
    return $base64.TrimEnd('=') -replace '\+', '-' -replace '/', '_'
  }

  # === STEP 1: Create JWT Header and Payload ===
  $Header = @{
      alg = "RS256"
      typ = "JWT"
  }
  $Now = [int][double]::Parse((Get-Date -UFormat %s))
  $Payload = @{
      iat = $Now
      exp = $Now + 600  # 10 minutes
      iss = $AppId
  }

  $EncodedHeader = Base64UrlEncode (ConvertTo-Json $Header -Compress)
  $EncodedPayload = Base64UrlEncode (ConvertTo-Json $Payload -Compress)
  $UnsignedToken = "$EncodedHeader.$EncodedPayload"

  # === STEP 2: Sign the token using Azure CLI ===
  $UnsignedTokenBytes = [System.Security.Cryptography.SHA256]::Create().ComputeHash([Text.Encoding]::ASCII.GetBytes($UnsignedToken))
  $Base64Value = [Convert]::ToBase64String($UnsignedTokenBytes)

  $SignResultJson = az keyvault key sign `
      --vault-name $VaultName `
      --name $KeyName `
      --algorithm RS256 `
      --digest $Base64Value | ConvertFrom-Json

  $Signature = $SignResultJson.signature
  return "$UnsignedToken.$Signature"
}

function Get-GitHubInstallationId {
    param(
        [Parameter(Mandatory)][string] $Jwt,
        [Parameter(Mandatory)][string] $ApiBase,
        [Parameter(Mandatory)][string] $ApiVersion,
        [Parameter(Mandatory)][string] $InstallationTokenOwner
    )

    $headers = Get-Headers -Jwt $Jwt -ApiVersion $ApiVersion

    $uri = "$ApiBase/app/installations"
    $resp = Invoke-RestMethod -Method Get -Headers $headers -Uri $uri -TimeoutSec 30

    $resp | Foreach-Object { Write-Host "  $($_.id): $($_.account.login) [$($_.target_type)]" }

    $resp = $resp | Where-Object { $_.account.login -ieq $InstallationTokenOwner }
    if (!$resp.id) { throw "No installations found for this App." }
    return $resp.id
}

function New-GitHubInstallationToken {
  param(
    [Parameter(Mandatory)] [string] $Jwt,
    [Parameter(Mandatory)] [string] $InstallationId,
    [Parameter(Mandatory)] [string] $ApiBase,
    [Parameter(Mandatory)] [string] $ApiVersion
  )
  $headers = Get-Headers -Jwt $Jwt -ApiVersion $ApiVersion
  $uri = "$ApiBase/app/installations/$InstallationId/access_tokens"
  $resp = Invoke-RestMethod -Method Post -Headers $headers -Uri $uri -TimeoutSec 30
  if (!$resp.token) { throw "Failed to obtain installation access token for installation $InstallationId." }
  return $resp.token
}

Write-Host "Generating GitHub App JWT by signing via Azure Key Vault (no key export)..."
$jwt = New-GitHubAppJwt -VaultName $KeyVaultName -KeyName $KeyName -AppId $GitHubAppId

Write-Host "Fetching installation ID for $InstallationTokenOwner ..."
$installationId = Get-GitHubInstallationId -Jwt $jwt -ApiBase $GitHubApiBaseUrl -ApiVersion $GitHubApiVersion -InstallationTokenOwner $InstallationTokenOwner

Write-Host "Installation ID resolved: $installationId"

Write-Host "Exchanging JWT for installation access token..."
$installationToken = New-GitHubInstallationToken -Jwt $jwt -InstallationId $installationId -ApiBase $GitHubApiBaseUrl -ApiVersion $GitHubApiVersion

# Export for gh CLI & git
$env:GH_TOKEN = $installationToken
Write-Host "GH_TOKEN has been set in the current process."

# Optionally set an Azure DevOps secret variable (so later tasks can reuse it)
if ($PipelineVariableName) {
  Write-Host "##vso[task.setvariable variable=$PipelineVariableName;issecret=true]$installationToken"
  Write-Host "Azure DevOps variable '$PipelineVariableName' has been set (secret)."
}

try {
  Write-Host "`n--- gh auth status ---"
  & gh auth status
}
catch {
  Write-Warning "gh CLI not found or auth status failed: $($_.Exception.Message)"
}
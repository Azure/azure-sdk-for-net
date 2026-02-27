<#
.SYNOPSIS
  Mints a GitHub App installation access token using Azure Key Vault 'sign' (non-exportable key),
  and logs in the GitHub CLI by setting GH_TOKEN.

  Works in both Azure DevOps pipelines and GitHub Actions workflows.
  Requires Azure CLI to be pre-authenticated (via AzureCLI@2 in ADO, or azure/login in GH Actions).

.PARAMETER KeyVaultName
  Name of the Azure Key Vault containing the non-exportable RSA key.

.PARAMETER KeyName
  Name of the RSA key in Key Vault (imported as a *key*, not a secret).

.PARAMETER GitHubAppId
  Numeric App ID (not client ID) of your GitHub App.

.PARAMETER InstallationTokenOwners
  List of GitHub organizations or users for which to obtain installation tokens.

.PARAMETER VariableNamePrefix
  Prefix for the exported variable name (default: GH_TOKEN).
  With a single owner, exports as GH_TOKEN. With multiple owners, exports as GH_TOKEN_<Owner>.

.OUTPUTS
  Sets environment variables in the current process and exports them to the CI system:
  - Azure DevOps: sets secret pipeline variables via ##vso logging commands
  - GitHub Actions: writes to GITHUB_ENV / GITHUB_OUTPUT and masks the token
#>

[CmdletBinding()]
param(
  [string] $KeyVaultName = "azuresdkengkeyvault",
  [string] $KeyName = "azure-sdk-automation",
  [string] $GitHubAppId = '1086291', # Azure SDK Automation App ID
  [string[]] $InstallationTokenOwners = @("Azure"),
  [string] $VariableNamePrefix = "GH_TOKEN"
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

  function Base64UrlEncode {
    param(
      [string]$Data,
      [switch]$IsBase64String
    )
    if ($IsBase64String) {
      $base64 = $Data
    } else {
      $bytes = [System.Text.Encoding]::UTF8.GetBytes($Data)
      $base64 = [Convert]::ToBase64String($bytes)
    }
    return $base64.TrimEnd('=') -replace '\+', '-' -replace '/', '_'
  }

  # === STEP 1: Create JWT Header and Payload ===
  $Header = @{
      alg = "RS256"
      typ = "JWT"
  }
  $Now = [int][double]::Parse((Get-Date -UFormat %s))
  $Payload = @{
      iat = $Now - 10 # 10 seconds clock skew
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

  if ($LASTEXITCODE -ne 0) {
    throw "Failed to sign JWT with Azure Key Vault. Error: $SignResult"
  }

  if (!$SignResultJson.signature) {
    throw "Azure Key Vault response does not contain a signature. Response: $($SignResultJson | ConvertTo-Json -Compress)"
  }

  $Signature = Base64UrlEncode -Data $SignResultJson.signature -IsBase64String
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
    $resp = Invoke-RestMethod -Method Get -Headers $headers -Uri $uri -TimeoutSec 30 -MaximumRetryCount 3

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
  $resp = Invoke-RestMethod -Method Post -Headers $headers -Uri $uri -TimeoutSec 30 -MaximumRetryCount 3
  if (!$resp.token) { throw "Failed to obtain installation access token for installation $InstallationId." }
  return $resp.token
}

Write-Host "Generating GitHub App JWT by signing via Azure Key Vault (no key export)..."
$jwt = New-GitHubAppJwt -VaultName $KeyVaultName -KeyName $KeyName -AppId $GitHubAppId

foreach ($InstallationTokenOwner in $InstallationTokenOwners) 
{
  Write-Host "Fetching installation ID for $InstallationTokenOwner ..."
  $installationId = Get-GitHubInstallationId -Jwt $jwt -ApiBase $GitHubApiBaseUrl -ApiVersion $GitHubApiVersion -InstallationTokenOwner $InstallationTokenOwner

  Write-Host "Installation ID resolved: $installationId"

  Write-Host "Exchanging JWT for installation access token..."
  $installationToken = New-GitHubInstallationToken -Jwt $jwt -InstallationId $installationId -ApiBase $GitHubApiBaseUrl -ApiVersion $GitHubApiVersion

  $variableName = $VariableNamePrefix
  if ($InstallationTokenOwners.Count -gt 1)
  {
    $variableName = $VariableNamePrefix + "_" + $InstallationTokenOwner
  }

  Set-Item -Path Env:$variableName -Value $installationToken

  # Export for gh CLI & git
  Write-Host "$variableName has been set in the current process."

  # Azure DevOps: set secret pipeline variable (so later tasks can reuse it)
  if ($null -ne $env:SYSTEM_TEAMPROJECTID) {
    Write-Host "##vso[task.setvariable variable=$variableName;issecret=true]$installationToken"
    Write-Host "Azure DevOps variable '$variableName' has been set (secret)."
  }

  # GitHub Actions: mask the token and export to GITHUB_ENV
  if ($env:GITHUB_ACTIONS -eq 'true') {
    Write-Host "::add-mask::$installationToken"
    Add-Content -Path $env:GITHUB_ENV -Value "$variableName=$installationToken"
    Write-Host "GitHub Actions env variable '$variableName' has been exported."
  }

  try {
    Write-Host "`n--- gh auth status ---"
    $gh_token_value_before = $env:GH_TOKEN
    $env:GH_TOKEN = $installationToken
    & gh auth status
  }
  finally{
    $env:GH_TOKEN = $gh_token_value_before
  }
}

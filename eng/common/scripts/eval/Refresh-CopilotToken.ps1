<#
.SYNOPSIS
    Mints a fresh Copilot-usable GitHub access token from a stored GitHub App
    refresh token, rotating the refresh token in place.

.DESCRIPTION
    Implements the per-run half of the durable eval auth flow (Option A). It
    replaces the weekly-expiring fine-grained PAT with a self-perpetuating
    GitHub App user-to-server token chain that the org's PAT-lifetime policy
    does not govern.

    Each invocation:
      1. Reads the current refresh token + App client secret from Key Vault.
      2. Exchanges the refresh token for a NEW 8h access token and a NEW
         ~6-month refresh token (GitHub single-use-invalidates the old one).
      3. Writes the new refresh token back to Key Vault FIRST (the critical
         step — if this is lost the chain breaks and a re-bootstrap is needed).
      4. Publishes the access token into the access-token secret that the eval
         shards already consume, so no shard wiring changes.

    Intended to run once per pipeline run in the Prepare stage (before the eval
    shards resolve the Key-Vault-backed variable group). Requires an already
    az-authenticated context (e.g. an AzureCLI@2 task) whose identity has
    get + set on the target Key Vault.

.PARAMETER KeyVaultName
    Name of the Azure Key Vault holding the secrets (e.g. AzureSDKEngKeyVault).

.PARAMETER ClientId
    The GitHub App's client id (not a secret).

.PARAMETER ClientSecretName
    Key Vault secret name holding the GitHub App client secret.

.PARAMETER RefreshTokenSecretName
    Key Vault secret name holding (and receiving) the rotating refresh token.

.PARAMETER AccessTokenSecretName
    Key Vault secret name the freshly minted access token is written to. This
    is the same secret the eval pipelines already map into GITHUB_TOKEN /
    COPILOT_GITHUB_TOKEN, so nothing downstream changes.

.PARAMETER TokenUrl
    GitHub OAuth token endpoint. Override only for GHES.

.PARAMETER MaxRetries
    Attempts for each network / Key Vault operation before failing.

.EXAMPLE
    ./Refresh-CopilotToken.ps1 -KeyVaultName AzureSDKEngKeyVault -ClientId Iv1.0123456789abcdef
#>
[CmdletBinding(SupportsShouldProcess)]
param(
    [Parameter(Mandatory = $true)]
    [string] $KeyVaultName,

    [Parameter(Mandatory = $true)]
    [string] $ClientId,

    [Parameter()]
    [string] $ClientSecretName = 'azuresdk-copilot-app-client-secret',

    [Parameter()]
    [string] $RefreshTokenSecretName = 'azuresdk-copilot-refresh-token',

    [Parameter()]
    [string] $AccessTokenSecretName = 'azuresdk-copilot-github-pat',

    [Parameter()]
    [string] $TokenUrl = 'https://github.com/login/oauth/access_token',

    [Parameter()]
    [int] $MaxRetries = 3
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

function Invoke-WithRetry {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)][scriptblock] $Action,
        [Parameter(Mandatory = $true)][string] $Description,
        [int] $Retries = 3
    )

    for ($attempt = 1; $attempt -le $Retries; $attempt++) {
        try {
            return & $Action
        }
        catch {
            if ($attempt -eq $Retries) {
                throw "Failed: $Description (after $Retries attempts). $($_.Exception.Message)"
            }
            $delay = [math]::Pow(2, $attempt)
            Write-Warning "$Description failed (attempt $attempt/$Retries): $($_.Exception.Message). Retrying in ${delay}s."
            Start-Sleep -Seconds $delay
        }
    }
}

function Get-KeyVaultSecretValue {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)][string] $Vault,
        [Parameter(Mandatory = $true)][string] $Name
    )

    return Invoke-WithRetry -Description "read secret '$Name'" -Retries $MaxRetries -Action {
        $value = az keyvault secret show --vault-name $Vault --name $Name --query value -o tsv 2>$null
        if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($value)) {
            throw "az keyvault secret show returned exit code $LASTEXITCODE for secret '$Name'."
        }
        return $value
    }
}

function Set-KeyVaultSecretValue {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)][string] $Vault,
        [Parameter(Mandatory = $true)][string] $Name,
        [Parameter(Mandatory = $true)][string] $Value
    )

    Invoke-WithRetry -Description "write secret '$Name'" -Retries $MaxRetries -Action {
        # --value via stdin file to avoid the secret appearing in the process table.
        $tmp = New-TemporaryFile
        try {
            Set-Content -Path $tmp -Value $Value -NoNewline -Encoding utf8
            $null = az keyvault secret set --vault-name $Vault --name $Name --file $tmp -o none 2>$null
            if ($LASTEXITCODE -ne 0) {
                throw "az keyvault secret set returned exit code $LASTEXITCODE for secret '$Name'."
            }
        }
        finally {
            Remove-Item -Path $tmp -Force -ErrorAction SilentlyContinue
        }
    }
}

Write-Host "Reading App client secret and refresh token from Key Vault '$KeyVaultName'..."
$clientSecret = Get-KeyVaultSecretValue -Vault $KeyVaultName -Name $ClientSecretName
$refreshToken = Get-KeyVaultSecretValue -Vault $KeyVaultName -Name $RefreshTokenSecretName

Write-Host "Exchanging refresh token for a fresh access token..."
$response = Invoke-WithRetry -Description 'refresh-token exchange' -Retries $MaxRetries -Action {
    $body = @{
        client_id     = $ClientId
        client_secret = $clientSecret
        grant_type    = 'refresh_token'
        refresh_token = $refreshToken
    }
    Invoke-RestMethod -Method Post -Uri $TokenUrl -Body $body -Headers @{ Accept = 'application/json' }
}

if ($response.PSObject.Properties.Name -contains 'error') {
    $desc = if ($response.PSObject.Properties.Name -contains 'error_description') { $response.error_description } else { '' }
    throw "GitHub rejected the refresh token: $($response.error). $desc`n" +
          "The refresh-token chain is broken (or the App/secret changed). Re-run Bootstrap-CopilotToken.ps1 " +
          "signed in as the Copilot-seated bot account to seed a new refresh token."
}

if ([string]::IsNullOrWhiteSpace($response.access_token) -or [string]::IsNullOrWhiteSpace($response.refresh_token)) {
    throw "GitHub token response was missing access_token or refresh_token. Cannot continue."
}

# Persist the NEW refresh token first: GitHub already invalidated the previous one,
# so losing this value breaks the chain. Do it before publishing the access token.
if ($PSCmdlet.ShouldProcess($RefreshTokenSecretName, 'Write rotated refresh token to Key Vault')) {
    Set-KeyVaultSecretValue -Vault $KeyVaultName -Name $RefreshTokenSecretName -Value $response.refresh_token
    Write-Host "Rotated refresh token written to '$RefreshTokenSecretName'."
}

if ($PSCmdlet.ShouldProcess($AccessTokenSecretName, 'Write fresh access token to Key Vault')) {
    Set-KeyVaultSecretValue -Vault $KeyVaultName -Name $AccessTokenSecretName -Value $response.access_token
    Write-Host "Fresh access token written to '$AccessTokenSecretName'."
}

$expiresIn = if ($response.PSObject.Properties.Name -contains 'expires_in') { [int]$response.expires_in } else { 0 }
Write-Host "Done. Access token valid for ~$([math]::Round($expiresIn / 3600, 1))h; refresh token rotated."

return [pscustomobject]@{
    AccessTokenSecret       = $AccessTokenSecretName
    RefreshTokenSecret      = $RefreshTokenSecretName
    AccessTokenExpiresInSec = $expiresIn
}

<#
.SYNOPSIS
    One-time bootstrap for the durable eval Copilot auth flow (Option A): runs
    the GitHub App device-flow authorization and seeds the first refresh token.

.DESCRIPTION
    Run this ONCE, interactively, signed in as the Copilot-seated bot account
    (e.g. the azure-sdk bot). It authorizes the GitHub App and produces the
    initial user-to-server access token + refresh token. From then on the
    per-run Refresh-CopilotToken.ps1 keeps the chain alive automatically with
    no further manual rotation.

    Prerequisites (org admin / bot owner):
      - A GitHub App registered with "Expire user authorization tokens" and
        "Enable Device Flow" turned on, approved in the org.
      - The bot account that owns the token has an active Copilot seat.
      - The App client secret already stored in Key Vault (for the refresh
        script) as the ClientSecretName secret.

    When -KeyVaultName is supplied the resulting refresh token is written
    straight to Key Vault; otherwise the token is printed so you can store it
    manually. The access token is short-lived (8h) and only useful for a quick
    smoke test.

.PARAMETER ClientId
    The GitHub App's client id.

.PARAMETER KeyVaultName
    Optional. When set, the refresh token is written to this Key Vault (requires
    an az-authenticated context with set permission).

.PARAMETER RefreshTokenSecretName
    Key Vault secret name to write the refresh token to.

.PARAMETER AccessTokenSecretName
    Optional Key Vault secret name to also write the short-lived access token
    to (handy for an immediate smoke test). Leave blank to skip.

.PARAMETER DeviceCodeUrl
    GitHub device-code endpoint. Override only for GHES.

.PARAMETER TokenUrl
    GitHub OAuth token endpoint. Override only for GHES.

.EXAMPLE
    ./Bootstrap-CopilotToken.ps1 -ClientId Iv1.0123456789abcdef -KeyVaultName AzureSDKEngKeyVault
#>
[CmdletBinding(SupportsShouldProcess)]
param(
    [Parameter(Mandatory = $true)]
    [string] $ClientId,

    [Parameter()]
    [string] $KeyVaultName,

    [Parameter()]
    [string] $RefreshTokenSecretName = 'azuresdk-copilot-refresh-token',

    [Parameter()]
    [string] $AccessTokenSecretName,

    [Parameter()]
    [string] $DeviceCodeUrl = 'https://github.com/login/device/code',

    [Parameter()]
    [string] $TokenUrl = 'https://github.com/login/oauth/access_token'
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

Write-Host 'Requesting a device code from GitHub...'
$device = Invoke-RestMethod -Method Post -Uri $DeviceCodeUrl `
    -Body @{ client_id = $ClientId } -Headers @{ Accept = 'application/json' }

if ($device.PSObject.Properties.Name -contains 'error') {
    throw "GitHub device-code request failed: $($device.error). Confirm the App client id and that Device Flow is enabled."
}

Write-Host ''
Write-Host '=========================================================='
Write-Host " 1. Open:  $($device.verification_uri)"
Write-Host " 2. Enter code:  $($device.user_code)"
Write-Host ' 3. Sign in as the COPILOT-SEATED BOT account and Authorize.'
Write-Host '=========================================================='
Write-Host ''

$interval = [int]$device.interval
if ($interval -le 0) { $interval = 5 }
$deadline = (Get-Date).AddSeconds([int]$device.expires_in)

$tokens = $null
while ((Get-Date) -lt $deadline) {
    Start-Sleep -Seconds $interval

    $poll = Invoke-RestMethod -Method Post -Uri $TokenUrl -Headers @{ Accept = 'application/json' } -Body @{
        client_id   = $ClientId
        device_code = $device.device_code
        grant_type  = 'urn:ietf:params:oauth:grant-type:device_code'
    }

    if ($poll.PSObject.Properties.Name -contains 'error') {
        switch ($poll.error) {
            'authorization_pending' { continue }
            'slow_down'             { $interval += 5; continue }
            default { throw "Device-flow authorization failed: $($poll.error). $($poll.error_description)" }
        }
    }

    $tokens = $poll
    break
}

if ($null -eq $tokens) {
    throw 'Timed out waiting for device-flow authorization. Re-run and complete the browser step sooner.'
}

if ([string]::IsNullOrWhiteSpace($tokens.refresh_token)) {
    throw "Authorization succeeded but no refresh_token was returned. Enable 'Expire user authorization tokens' on the GitHub App and retry."
}

Write-Host 'Authorization succeeded.'

if ($KeyVaultName) {
    if ($PSCmdlet.ShouldProcess($RefreshTokenSecretName, "Write refresh token to Key Vault '$KeyVaultName'")) {
        $tmp = New-TemporaryFile
        try {
            Set-Content -Path $tmp -Value $tokens.refresh_token -NoNewline -Encoding utf8
            $null = az keyvault secret set --vault-name $KeyVaultName --name $RefreshTokenSecretName --file $tmp -o none
            if ($LASTEXITCODE -ne 0) { throw "az keyvault secret set failed for '$RefreshTokenSecretName' (exit $LASTEXITCODE)." }
        }
        finally {
            Remove-Item -Path $tmp -Force -ErrorAction SilentlyContinue
        }
        Write-Host "Refresh token stored in '$RefreshTokenSecretName'."

        if ($AccessTokenSecretName -and $PSCmdlet.ShouldProcess($AccessTokenSecretName, 'Write access token to Key Vault')) {
            $tmp2 = New-TemporaryFile
            try {
                Set-Content -Path $tmp2 -Value $tokens.access_token -NoNewline -Encoding utf8
                $null = az keyvault secret set --vault-name $KeyVaultName --name $AccessTokenSecretName --file $tmp2 -o none
                if ($LASTEXITCODE -ne 0) { throw "az keyvault secret set failed for '$AccessTokenSecretName' (exit $LASTEXITCODE)." }
            }
            finally {
                Remove-Item -Path $tmp2 -Force -ErrorAction SilentlyContinue
            }
            Write-Host "Access token stored in '$AccessTokenSecretName'."
        }
    }
}
else {
    Write-Host ''
    Write-Warning "No -KeyVaultName supplied. Store this refresh token in Key Vault secret '$RefreshTokenSecretName' now:"
    Write-Host $tokens.refresh_token
}

Write-Host 'Bootstrap complete. Future runs rotate automatically via Refresh-CopilotToken.ps1.'

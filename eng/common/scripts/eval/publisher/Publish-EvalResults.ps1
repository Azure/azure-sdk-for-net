# Uploads one saved archive with Azure CLI, then signals the dashboard without local status files.
#requires -Version 7.4
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [ValidatePattern('^[a-z0-9]{3,24}$')] [string] $StorageAccountName,
    [Parameter(Mandatory)] [string] $BundlePath,
    [string] $DashboardRefreshUrl = '',
    [string] $DashboardResource = ''
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

function Invoke-AzJson([string[]] $Arguments) {
    # Capture all CLI output, especially tokens and errors; never echo raw Azure responses.
    $output = az @Arguments --only-show-errors --output json 2>&1
    if ($LASTEXITCODE -ne 0) { throw 'Azure CLI operation failed.' }
    # ConvertFrom-Json auto-converts ISO strings into dates on some PowerShell versions.
    # Keep Blob metadata strings exact, including their required UTC Z suffix.
    $document = [System.Text.Json.JsonDocument]::Parse($output -join "`n")
    try { return $document.RootElement.Clone() } finally { $document.Dispose() }
}

$operation = 'validate_inputs'
$failureCode = 'invalid_bundle'
$stored = $false
try {
    $BundlePath = [System.IO.Path]::GetFullPath($BundlePath)
    $archive = Get-Item -LiteralPath $BundlePath
    $descriptor = Get-Item -LiteralPath "$BundlePath.json"
    if ($archive.PSIsContainer -or $archive.LinkType -or $archive.Length -le 0 -or $archive.Length -gt 32MB -or
        $descriptor.PSIsContainer -or $descriptor.LinkType -or $descriptor.Length -gt 64KB) { throw 'Invalid saved archive.' }
    $prepared = Get-Content -LiteralPath $descriptor.FullName -Raw | ConvertFrom-Json -AsHashtable
    $hash = (Get-FileHash -LiteralPath $BundlePath -Algorithm SHA256).Hash.ToLowerInvariant()
    $name = [string] $prepared.blobName
    if ($prepared.bytes -ne $archive.Length -or $prepared.sha256 -cne $hash -or $name.Length -gt 800 -or
        $name -cnotmatch '^v1/[a-z0-9][a-z0-9-]{0,99}/(?:[a-z0-9_.~-]|%[0-9A-F]{2})+/[1-9][0-9]{0,19}/[1-9][0-9]{0,19}/[1-9][0-9]*/dashboard-bundle\.zip$') {
        throw 'Archive identity or checksum differs from its preparation descriptor.'
    }

    # Deployment values belong to protected pipeline configuration, not queue-time input.
    # Never acquire a notification token for a noncanonical or non-App-Service destination.
    $refreshUri = $null
    $notificationValid = $DashboardRefreshUrl.Length -le 2048 -and
        [Uri]::TryCreate($DashboardRefreshUrl, [UriKind]::Absolute, [ref]$refreshUri) -and
        $refreshUri.Scheme -ceq 'https' -and $refreshUri.IsDefaultPort -and
        $refreshUri.Host -match '^[a-z0-9][a-z0-9.-]*\.azurewebsites\.net$' -and
        !$refreshUri.UserInfo -and !$refreshUri.Query -and !$refreshUri.Fragment -and
        $refreshUri.AbsolutePath -ceq '/api/refresh' -and $refreshUri.AbsoluteUri -ceq $DashboardRefreshUrl -and
        $DashboardResource -cmatch '^api://[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}\z'

    $operation = 'acquire_storage_identity'
    $failureCode = 'storage_identity'
    $token = (Invoke-AzJson -Arguments @('account', 'get-access-token', '--resource', 'https://storage.azure.com/')).GetProperty('accessToken').GetString()
    $payload = $token.Split('.')[1].Replace('-', '+').Replace('_', '/')
    $claims = [System.Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($payload.PadRight([int]([Math]::Ceiling($payload.Length / 4) * 4), '='))) | ConvertFrom-Json -AsHashtable
    foreach ($key in @('tid', 'oid')) {
        if ($claims[$key] -notmatch '^[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}$') { throw 'Invalid publisher identity.' }
    }
    $owner = [Convert]::ToHexString([System.Security.Cryptography.SHA256]::HashData([System.Text.Encoding]::UTF8.GetBytes("$($claims.tid):$($claims.oid)"))).ToLowerInvariant()
    $storedAt = [DateTime]::UtcNow.ToString('o')
    $storage = @('--account-name', $StorageAccountName, '--container-name', 'vally-results', '--name', $name, '--auth-mode', 'login')

    $operation = 'publish_blob'
    $failureCode = 'publication_failed'
    $duplicate = $false
    try {
        # CLI owns transport retries. Never overwrite, rebuild the ZIP, or create a container.
        Invoke-AzJson -Arguments (@('storage', 'blob', 'upload') + $storage + @('--file', $BundlePath,
            '--type', 'block', '--overwrite', 'false', '--if-none-match', '*', '--content-type', 'application/zip',
            '--metadata', 'schema=1', "sha256=$hash", "publisher=$owner", "storedat=$storedAt", '--timeout', '30', '--socket-timeout', '30')) | Out-Null
    } catch {
        # Also covers a lost success response: adopt only the same already-stored archive.
        $operation = 'verify_existing_blob'
        $saved = Invoke-AzJson -Arguments (@('storage', 'blob', 'show') + $storage + @('--timeout', '30'))
        $failureCode = 'submission_conflict'
        $metadata = $saved.GetProperty('metadata')
        $savedTime = $metadata.GetProperty('storedat').GetString()
        $parsedTime = [DateTimeOffset]::MinValue
        # Accept canonical UTC time only; .NET's loose parser otherwise admits spaces
        # that the dashboard rejects. Truncate fractions to the reader's millisecond precision.
        $validTime = $savedTime -cmatch '^\d{4}-\d{2}-\d{2}T(?:[01]\d|2[0-3]):[0-5]\d(?::[0-5]\d(?:\.\d+)?)?Z\z' -and
            [DateTimeOffset]::TryParse(($savedTime -replace '(\.\d{3})\d+(?=Z\z)', '$1'), [Globalization.CultureInfo]::InvariantCulture, [Globalization.DateTimeStyles]::None, [ref]$parsedTime) -and
            $parsedTime.UtcDateTime.ToString('yyyy-MM-dd') -ceq $savedTime.Substring(0, 10)
        if ($saved.GetProperty('properties').GetProperty('contentLength').GetInt64() -ne $archive.Length -or $metadata.GetProperty('schema').GetString() -cne '1' -or
            $metadata.GetProperty('sha256').GetString() -cne $hash -or $metadata.GetProperty('publisher').GetString() -cne $owner -or !$validTime) { throw 'Conflicting archive.' }
        $duplicate = $true
    }

    $stored = $true
    Write-Host "Result archive stored: $name (duplicate: $duplicate)."

    $body = @{ blobName = $name; sha256 = $hash } | ConvertTo-Json -Compress
    if ([System.Text.Encoding]::UTF8.GetByteCount($body) -gt 2048) { throw 'Invalid refresh signal.' }
    $notificationSucceeded = $false
    for ($attempt = 0; $notificationValid -and $attempt -lt 4; $attempt++) {
        $status = 0; $headers = @{}
        try {
            $token = (Invoke-AzJson -Arguments @('account', 'get-access-token', '--resource', $DashboardResource)).GetProperty('accessToken').GetString()
            $response = Invoke-WebRequest -Uri $refreshUri `
                -Method Post -ContentType 'application/json' -Body $body -Headers @{ Authorization = "Bearer $token" } `
                -MaximumRedirection 0 -TimeoutSec 180 -OperationTimeoutSeconds 180 -SkipHttpErrorCheck
            $status = [int]$response.StatusCode; $headers = $response.Headers
            if ($status -eq 200) {
                $report = $response.Content | ConvertFrom-Json -AsHashtable
                if ($report.status -eq 'succeeded' -and $report.failureCount -eq 0) {
                    $notificationSucceeded = $true; break
                }
            }
        } catch {
            # Redirect errors can throw even with SkipHttpErrorCheck. Never retry/follow them.
            if ($_.FullyQualifiedErrorId.Split(',')[0] -eq 'MaximumRedirectExceeded') { $status = 302 }
            elseif ($_.Exception.PSObject.Properties['Response'] -and $_.Exception.Response) { $status = [int]$_.Exception.Response.StatusCode }
        }
        if (($status -ne 0 -and $status -ne 200 -and $status -notin @(408, 429, 500, 502, 503, 504)) -or $attempt -eq 3) { break }
        $seconds = [Math]::Pow(2, $attempt)
        if ($headers['Retry-After']) {
            $value = [string]($headers['Retry-After'] | Select-Object -First 1)
            $retryDate = [DateTimeOffset]::MinValue; $retrySeconds = 0.0
            if ([double]::TryParse($value, [ref]$retrySeconds) -and [double]::IsFinite($retrySeconds)) { $seconds = $retrySeconds }
            elseif ([DateTimeOffset]::TryParse($value, [ref]$retryDate)) { $seconds = ($retryDate - [DateTimeOffset]::UtcNow).TotalSeconds }
        }
        Start-Sleep -Milliseconds ([int]([Math]::Clamp($seconds, 0, 60) * 1000))
    }
    if (!$notificationValid) { Write-Warning 'Archive stored; dashboard notification configuration is missing or invalid. Reload/startup/daily reconciliation can recover it.' }
    elseif (!$notificationSucceeded) { Write-Warning 'Archive stored; dashboard refresh failed. Reload/startup/daily reconciliation can recover it.' }
    else { Write-Host 'Dashboard refresh succeeded.' }
} catch {
    # Raw CLI output and exceptions can contain tokens. Stored data needs no local status file.
    if ($stored) {
        Write-Warning 'Archive stored; dashboard refresh failed. Reload/startup/daily reconciliation can recover it.'
    } else {
        throw "Evaluation publication failed: $operation ($failureCode). No raw Azure response was logged."
    }
}
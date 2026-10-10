# Uploads one saved archive with Azure CLI, retains its receipt, then signals the dashboard.
#requires -Version 7.4
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [ValidatePattern('^[a-z0-9]{3,24}$')] [string] $StorageAccountName,
    [Parameter(Mandatory)] [string] $BundlePath,
    [Parameter(Mandatory)] [string] $ResultPath
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

function Save-Receipt($Receipt) {
    $temporary = "$ResultPath.tmp"
    [System.IO.File]::WriteAllText($temporary, ($Receipt | ConvertTo-Json -Depth 5) + "`n")
    [System.IO.File]::Move($temporary, $ResultPath, $true)
}

$operation = 'validate_inputs'
$failureCode = 'invalid_bundle'
$stored = $false
try {
    $BundlePath = [System.IO.Path]::GetFullPath($BundlePath)
    $ResultPath = [System.IO.Path]::GetFullPath($ResultPath)
    if ($ResultPath -eq $BundlePath -or $ResultPath -eq "$BundlePath.json") { throw 'Receipt and archive paths must differ.' }
    $archive = Get-Item -LiteralPath $BundlePath
    $descriptor = Get-Item -LiteralPath "$BundlePath.json"
    if ($archive.PSIsContainer -or $archive.LinkType -or $archive.Length -le 0 -or $archive.Length -gt 32MB -or
        $descriptor.PSIsContainer -or $descriptor.LinkType -or $descriptor.Length -gt 64KB) { throw 'Invalid saved archive.' }
    $prepared = Get-Content -LiteralPath $descriptor.FullName -Raw | ConvertFrom-Json -AsHashtable
    $hash = (Get-FileHash -LiteralPath $BundlePath -Algorithm SHA256).Hash.ToLowerInvariant()
    $name = [string] $prepared.blobName
    if ($prepared.bytes -ne $archive.Length -or $prepared.sha256 -cne $hash -or $name.Length -gt 800 -or
        $name -cnotmatch '^v1/[a-z0-9][a-z0-9-]{0,99}/(?:[a-z0-9_.~-]|%[0-9A-F]{2})+/[1-9][0-9]{0,19}/[1-9][0-9]{0,19}/[1-9][0-9]*/dashboard-bundle\.zip$') {
        throw 'Archive identity or checksum differs from its preparation receipt.'
    }
    [System.IO.Directory]::CreateDirectory([System.IO.Path]::GetDirectoryName($ResultPath)) | Out-Null

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
        $validTime = $savedTime -match '^\d{4}-\d{2}-\d{2}T.*Z$' -and
            [DateTimeOffset]::TryParse($savedTime, [Globalization.CultureInfo]::InvariantCulture, [Globalization.DateTimeStyles]::None, [ref]$parsedTime)
        if ($saved.GetProperty('properties').GetProperty('contentLength').GetInt64() -ne $archive.Length -or $metadata.GetProperty('schema').GetString() -cne '1' -or
            $metadata.GetProperty('sha256').GetString() -cne $hash -or $metadata.GetProperty('publisher').GetString() -cne $owner -or !$validTime) { throw 'Conflicting archive.' }
        $duplicate = $true
    }

    $operation = 'persist_storage_result'
    $failureCode = 'receipt_failed'
    $receipt = @{ status = 'stored'; blobName = $name; sha256 = $hash; duplicate = $duplicate; notification = @{ status = 'pending' } }
    Save-Receipt $receipt
    $stored = $true

    $body = @{ blobName = $name; sha256 = $hash } | ConvertTo-Json -Compress
    if ([System.Text.Encoding]::UTF8.GetByteCount($body) -gt 2048) { throw 'Invalid refresh signal.' }
    $receipt.notification = @{ status = 'failed'; errorCode = 'notification_failed' }
    for ($attempt = 0; $attempt -lt 4; $attempt++) {
        $status = 0; $headers = @{}
        try {
            $token = (Invoke-AzJson -Arguments @('account', 'get-access-token', '--resource', 'api://258998df-81ec-460c-bdd7-56a9bdde1e48')).GetProperty('accessToken').GetString()
            $response = Invoke-WebRequest -Uri 'https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net/api/refresh' `
                -Method Post -ContentType 'application/json' -Body $body -Headers @{ Authorization = "Bearer $token" } `
                -MaximumRedirection 0 -TimeoutSec 180 -OperationTimeoutSeconds 180 -SkipHttpErrorCheck
            $status = [int]$response.StatusCode; $headers = $response.Headers
            if ($status -eq 200) {
                $report = $response.Content | ConvertFrom-Json -AsHashtable
                if ($report.status -eq 'succeeded' -and $report.failureCount -eq 0) {
                    $receipt.notification = @{ status = 'succeeded' }; break
                }
            }
        } catch {
            # Redirect errors can throw even with SkipHttpErrorCheck. Never retry/follow them.
            if ($_.Exception.PSObject.Properties['Response'] -and $_.Exception.Response) { $status = [int]$_.Exception.Response.StatusCode }
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
    try { Save-Receipt $receipt }
    catch { Write-Warning 'Archive stored; notification status could not be saved. The original storage receipt is retained.' }
    Write-Host "Result archive stored: $name (duplicate: $duplicate)."
    if ($receipt.notification.status -eq 'failed') { Write-Warning 'Archive stored; dashboard refresh failed. Reload/startup/daily reconciliation can recover it.' }
} catch {
    # Preserve an existing stored receipt. Raw CLI output and exceptions can contain tokens.
    if (!$stored -and $operation -ne 'validate_inputs') {
        try { Save-Receipt @{ status = 'failed'; operation = $operation; errorCode = $failureCode } } catch { }
    }
    throw "Evaluation publication failed: $operation ($failureCode). No raw Azure response was logged."
}
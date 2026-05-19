# Post-regeneration patch script.
# Apply after running `dotnet build /t:GenerateCode` to work around MPG generator bugs:
#  1) `IEnumerable<T>.ToRequestContent(arg)` (invalid C#) — replaced by BillingRequestContentHelper.ToRequestContent
#  2) `DateTimeOffset.ToRequestContent(arg)`              — replaced by BillingRequestContentHelper.ToRequestContent
#  3) `SubscriptionRenewalTermDetails.TermDuration` emits as `TimeSpan?` despite TSP `string` — re-typed to `string`
#
# Run with PowerShell from anywhere; resolves files relative to its own location.

$ErrorActionPreference = 'Stop'
$gen = Resolve-Path (Join-Path $PSScriptRoot '..\Generated')
$models = Join-Path $gen 'Models'

function PatchFile([string]$path, [scriptblock]$transform) {
    if (-not (Test-Path $path)) { Write-Warning "Missing $path"; return }
    $orig = Get-Content -Raw $path
    $new = & $transform $orig
    if ($new -ne $orig) {
        Set-Content -Path $path -Value $new -NoNewline
        Write-Host "Patched $path"
    }
}

# 1) Fix invalid IEnumerable<T>.ToRequestContent(...) and DateTimeOffset.ToRequestContent(...) call sites.
$broken = @(
    (Join-Path $gen 'BillingAccountResource.cs'),
    (Join-Path $gen 'Extensions\MockableBillingTenantResource.cs')
)
foreach ($f in $broken) {
    PatchFile $f {
        param($c)
        $c = [regex]::Replace($c, 'IEnumerable<[^>]+>\.ToRequestContent\(([^)]+)\)', 'BillingRequestContentHelper.ToRequestContent($1)')
        $c = [regex]::Replace($c, 'DateTimeOffset\.ToRequestContent\(([^)]+)\)', 'BillingRequestContentHelper.ToRequestContent($1)')
        return $c
    }
}

# 2) SubscriptionRenewalTermDetails.TermDuration should be string, not TimeSpan?
$srt = Join-Path $models 'SubscriptionRenewalTermDetails.cs'
PatchFile $srt {
    param($c)
    # PowerShell -replace is case-insensitive; use -creplace for case-sensitive substitution.
    $c = $c -creplace 'TimeSpan\? termDuration', 'string termDuration'
    $c = $c -creplace 'TimeSpan\? TermDuration', 'string TermDuration'
    return $c
}

# 3) SubscriptionRenewalTermDetails serialization — write string + read string
$srtSer = Join-Path $models 'SubscriptionRenewalTermDetails.Serialization.cs'
PatchFile $srtSer {
    param($c)
    # Replace WriteStringValue(TermDuration.Value) with WriteStringValue(TermDuration)
    $c = $c -creplace 'writer\.WriteStringValue\(TermDuration\.Value\);', 'writer.WriteStringValue(TermDuration);'
    # Replace local "TimeSpan? termDuration = default;" with "string termDuration = default;"
    $c = $c -creplace 'TimeSpan\? termDuration = default;', 'string termDuration = default;'
    # Replace termDuration prop reader: GetTimeSpan() → GetString()
    $c = $c -creplace 'termDuration = prop\.Value\.GetTimeSpan\(\);', 'termDuration = prop.Value.GetString();'
    return $c
}

# 4) ArmBillingModelFactory.cs — factory method TimeSpan? termDuration → string termDuration
$factory = Join-Path $gen 'ArmBillingModelFactory.cs'
PatchFile $factory {
    param($c)
    # Only patch the SubscriptionRenewalTermDetails factory method signature
    $c = [regex]::Replace($c,
        '(public static SubscriptionRenewalTermDetails SubscriptionRenewalTermDetails\([^)]*?)TimeSpan\? termDuration',
        '$1string termDuration')
    return $c
}

# 5) BillingExtensions.cs — fix broken XML doc cref with bare IEnumerable to IEnumerable{T}.
$ext = Join-Path $gen 'Extensions\BillingExtensions.cs'
PatchFile $ext {
    param($c)
    $c = $c -creplace 'DownloadDocumentsByBillingSubscriptionAsync\(WaitUntil, string, IEnumerable, CancellationToken\)', 'DownloadDocumentsByBillingSubscriptionAsync(WaitUntil, string, IEnumerable{BillingDocumentDownloadRequestContent}, CancellationToken)'
    $c = $c -creplace 'DownloadDocumentsByBillingSubscription\(WaitUntil, string, IEnumerable, CancellationToken\)', 'DownloadDocumentsByBillingSubscription(WaitUntil, string, IEnumerable{BillingDocumentDownloadRequestContent}, CancellationToken)'
    return $c
}

Write-Host "Post-regen patches applied successfully."